using System;
using VampireSurvivors.App.Framework;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;

namespace VampireSurvivors.Framework;

public class DestructibleFactory : GenericPoolFactory<PropType>
{
	protected override GenericPoolFactory<PropType> GetDlcFactory(BundleManifestData bmd)
	{
		if ((object)bmd != null)
		{
			return bmd._DestructibleFactory;
		}
		return (GenericPoolFactory<PropType>)(object)new NullReferenceException();
	}
}
