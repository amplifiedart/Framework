using AA.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrameWorkTests
{
	[TestClass]
	public class DataDrivenRangeTest
	{
		private TestContext context;

		public TestContext TestContext
		{
			get { return context; }
			set { context = value; }
		}

		[TestMethod]
		[DeploymentItem("data.xlsx")]
		[DataSource("MyExcelDataSource")]
		public void GenericRangeTest()
		{

		}
	}
}
