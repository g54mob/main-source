using UnityEngine;

namespace DV.Booklets.Testing
{
	public class JobReportBookletTest : ABookletTest
	{
		public Job_data jobData;

		public Debt_data debtData;

		protected override GameObject CreateBooklet()
		{
			return BookletCreator_JobReport.Create(jobData, debtData, base.transform.position, base.transform.rotation, base.transform).gameObject;
		}
	}
}
