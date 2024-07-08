namespace GradesApp.Tests
{
    public class StudentTests
    {
     
        [Test]
        public void Test1()
        {
            //arrange
            var student = new StudentInMemory("Piotr", "Kwarciak");
            student.AddGrade(6);
            student.AddGrade(5);
            student.AddGrade(4);
            student.AddGrade(3);
            student.AddGrade(2);
            student.AddGrade(1);

            //act
            var result = student.GetStatistics();

            //assert
            Assert.AreEqual(3.5, result.Average);
            Assert.AreEqual(6, result.Max);     
            Assert.AreEqual(1, result.Min);
            Assert.AreEqual(6, result.Count);
        }
    }
}