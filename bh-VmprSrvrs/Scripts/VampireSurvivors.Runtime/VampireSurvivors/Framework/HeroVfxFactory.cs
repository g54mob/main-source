using UnityEngine;
using VampireSurvivors.App.Framework;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;

namespace VampireSurvivors.Framework
{
	[CreateAssetMenu(fileName = "HeroVfxFactory", menuName = "VampireSurvivors/New HeroVfxFactory")]
	public class HeroVfxFactory : GenericPoolFactory<HeroVfxType>
	{
		protected override GenericPoolFactory<HeroVfxType> GetDlcFactory(BundleManifestData bmd)
		{
			return null;
		}
	}
}
