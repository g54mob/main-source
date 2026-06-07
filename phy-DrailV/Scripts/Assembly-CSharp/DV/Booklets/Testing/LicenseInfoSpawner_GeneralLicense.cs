using System.Collections.Generic;
using DV.ThingTypes;
using UnityEngine;

namespace DV.Booklets.Testing
{
	public class LicenseInfoSpawner_GeneralLicense : ALicenseSpawner<GeneralLicenseType_v2>
	{
		protected override IEnumerable<GeneralLicenseType_v2> GetLicenses()
		{
			return Globals.G.Types.generalLicenses;
		}

		protected override GameObject Create(GeneralLicenseType_v2 license)
		{
			return BookletCreator_Licenses.CreateLicenseInfo(license, base.transform.position, base.transform.rotation, base.transform, dontAddToStorage: true);
		}
	}
}
