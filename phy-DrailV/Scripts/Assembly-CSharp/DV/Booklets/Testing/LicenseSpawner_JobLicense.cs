using System.Collections.Generic;
using System.Linq;
using DV.ThingTypes;
using UnityEngine;

namespace DV.Booklets.Testing
{
	public class LicenseSpawner_JobLicense : ALicenseSpawner<JobLicenseType_v2>
	{
		protected override IEnumerable<JobLicenseType_v2> GetLicenses()
		{
			return Globals.G.Types.jobLicenses.Where((JobLicenseType_v2 l) => l.v1 != JobLicenses.Basic);
		}

		protected override GameObject Create(JobLicenseType_v2 license)
		{
			return BookletCreator_Licenses.CreateLicense(license, base.transform.position, base.transform.rotation, base.transform, dontAddToStorage: true);
		}
	}
}
