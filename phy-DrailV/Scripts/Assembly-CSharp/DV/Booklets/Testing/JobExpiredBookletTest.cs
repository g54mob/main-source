using UnityEngine;

namespace DV.Booklets.Testing
{
	public class JobExpiredBookletTest : ABookletTest
	{
		public Job_data jobData;

		protected override GameObject CreateBooklet()
		{
			return BookletCreator_JobExpiredReport.Create(jobData, base.transform.position, base.transform.rotation, base.transform).gameObject;
		}
	}
}
