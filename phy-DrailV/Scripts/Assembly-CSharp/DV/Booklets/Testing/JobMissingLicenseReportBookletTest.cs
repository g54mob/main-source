using UnityEngine;

namespace DV.Booklets.Testing
{
	public class JobMissingLicenseReportBookletTest : ABookletTest
	{
		public bool isJobLicenseMissing;

		public Job_data data;

		protected override GameObject CreateBooklet()
		{
			return BookletCreator_JobMissingLicense.Create(data, isJobLicenseMissing, base.transform.position, base.transform.rotation, base.transform).gameObject;
		}
	}
}
