using System;
using VampireSurvivors.App.Framework;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;

namespace VampireSurvivors.Framework;

public class HeroVfxFactory : GenericPoolFactory<HeroVfxType>
{
	protected override GenericPoolFactory<HeroVfxType> GetDlcFactory(BundleManifestData bmd)
	{
		if ((object)bmd != null)
		{
			return bmd._HeroVfxFactory;
		}
		return (GenericPoolFactory<HeroVfxType>)(object)new NullReferenceException();
	}
}
