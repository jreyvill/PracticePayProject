//Add the following reference

namespace PractPayNUnitTestProj
{
    public class Tests
    {
        private List<PayRecord> _records;

        [SetUp]
        public void Setup()
        {
            _records = CsvImporter.ImportPayrecords(@"..\..\Import\employee-payroll-data");
        }

        [Test]
        public void TestImport()
        {

            //Assert.IsNotNull(_records);
            Assert.That(_records, Is.Not.Null);

            //Asert.IsNotEmpty(_records);
            Assert.That(_records, Is.Not.Empty);

            //Assert.AreEqual(5, _records.Count, "Incorrect number of records imported.");
            Assert.That(_records, Has.Count.EqualTo(5), "Incorrect number of records imported.");
           
        }

        [Test]
        public void TestGross() 
        {
            //Threse tests test Gross amount for each employee in the
            //employee-payroll-data.csv file that have been imported into our List<PayRecord>.
            //test employee id 1 (Residential)
            double actual = Math.Round(_records[0].Gross, 2); //_records[0] is the first employee
            double expected = 652; //This is the Gross (hours x rate) amount
            Assert.That(actual, Is.EqualTo(expected), "Gross amount for employe 1 is incorrect");
            
            //Employee 2 - Working Holiday
            actual = Math.Round(_records[1].Gross, 2); 
            expected = 418; 
            Assert.That(actual, Is.EqualTo(expected), "Gross amount for employe 2 is incorrect");
            //Employee 2 - Residential
            actual = Math.Round(_records[2].Gross, 2); 
            expected = 2202.00; 
            Assert.That(actual, Is.EqualTo(expected), "Gross amount for employe 3 is incorrect");

            //Employee 2 - Working Holiday
            actual = Math.Round(_records[3].Gross, 2);
            expected = 1104.00;
            Assert.That(actual, Is.EqualTo(expected), "Gross amount for employe 4 is incorrect");

            //Employee 2 - Residential
            actual = Math.Round(_records[4].Gross, 2);
            expected = 1797.45;
            Assert.That(actual, Is.EqualTo(expected), "Gross amount for employe 5 is incorrect");
        
        }

        [Test]
        public void TestNet() 
        {
            //These tests test the Net amount for each employee in the
            //employee-payroll-data.csv file that have been imported into our List<PayRecord>

            //test employee id 1 (residential)
            double actual = Math.Round(_records[0].Net, 2);
            double expected = 469.55;
            Assert.That(actual, Is.EqualTo(expected), "Net amount for employe 1 is incorrect");

            actual = Math.Round(_records[1].Net, 2);
            expected = 284.24;
            Assert.That(actual, Is.EqualTo(expected), "Net amount for employe 2 is incorrect");

            actual = Math.Round(_records[2].Net, 2);
            expected = 1447.09;
            Assert.That(actual, Is.EqualTo(expected), "Net amount for employe 3 is incorrect");

            actual = Math.Round(_records[3].Net, 2);
            expected = 938.40;
            Assert.That(actual, Is.EqualTo(expected), "Net amount for employe 4 is incorrect");

            actual = Math.Round(_records[4].Net, 2);
            expected = 1200.31;
            Assert.That(actual, Is.EqualTo(expected), "Net amount for employe 5 is incorrect");
        }

        [Test]
        public void TestTax() 
        {
            double actual = Math.Round(_records[0].Tax, 2);
            double expected = 182.45;
            Assert.That(actual, Is.EqualTo(expected), "Tax amount for employe 1 is incorrect");

            actual = Math.Round(_records[1].Tax, 2);
            expected = 133.76;
            Assert.That(actual, Is.EqualTo(expected), "Tax amount for employe 2 is incorrect");

            actual = Math.Round(_records[2].Tax, 2);
            expected = 754.91;
            Assert.That(actual, Is.EqualTo(expected), "Tax amount for employe 3 is incorrect");

            actual = Math.Round(_records[3].Tax, 2);
            expected = 165.6;
            Assert.That(actual, Is.EqualTo(expected), "Tax amount for employe 4 is incorrect");

            actual = Math.Round(_records[4].Tax, 2);
            expected = 597.14;
            Assert.That(actual, Is.EqualTo(expected), "Tax amount for employe 5 is incorrect");
        }

        [Test]
        public void TestExport() 
        {
            string file = $@"..\..\Export\{DateTime.Now.Ticks}-records";
            PayRecordWriter.Write(file, _records, true);
            bool fileExists = File.Exists(Path.GetFullPath($@"..\..\Export\{file}.csv"));

            Assert.IsTrue(fileExists);

        }

        
    }
}