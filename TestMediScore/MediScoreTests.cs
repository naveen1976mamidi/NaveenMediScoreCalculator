using MediScoreCalculation;

namespace TestMediScore
{
	[TestClass]
	public class MediScoreTests
	{
		int normal = 0;

		[TestMethod]
		public void IsNormal()
		{

			int medi_score = MediScoreCalculator.Calculate(0, 0, 0, 95, 37.1F);

			Assert.AreEqual(medi_score, normal, "The tests are normal.");
		}

		[TestMethod]
		public void IsAbnormal()
		{

			int medi_score = MediScoreCalculator.Calculate(2, 0, 17, 95, 37.0F);
			Assert.AreNotEqual(medi_score, normal, "The tests are abnormal.");

		}

		[TestMethod]
		public void IsBelowAbnormal()
		{

			int medi_score = MediScoreCalculator.Calculate(2, 0, 17, 95, 37.0F);
			Assert.AreEqual(medi_score, 4, "The tests are below abnormal.");
		}

		[TestMethod]
		public void IsAboveAbnormal()
		{
			int medi_score = MediScoreCalculator.Calculate(2, 1, 23, 88, 38.5F);
			Assert.AreEqual(medi_score, 8, "The tests are above abnormal.");

		}

		public void IsTemperatureConvertedtoSinglePrecison()
		{
			int medi_score = MediScoreCalculator.Calculate(0, 0, 0, 95, 37.1000303F);

			Assert.AreEqual(medi_score, normal, "The tests are normal, temperature converted to  single precison .");
		}


		[TestMethod]
		public void InvalidTest()
		{
			try
			{
				int medi_score = MediScoreCalculator.Calculate(-99, -99, 1, 95, 37.1000303F);

			}
			catch (Exception ex)
			{
				Assert.IsTrue(ex is ArgumentException);
			}

		}
	}
}