using UnityEngine;
using VampireSurvivors.App.Framework;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;

namespace VampireSurvivors.Framework
{
	[CreateAssetMenu(fileName = "DestructibleFactory", menuName = "VampireSurvivors/New DestructibleFactory")]
	public class DestructibleFactory : GenericPoolFactory<PropType>
	{
		protected override GenericPoolFactory<PropType> GetDlcFactory(BundleManifestData bmd)
		{
			return null;
		}
	}
}
