using Rhizomatic;
using UnityEngine;

namespace GRP.Net
{
	[CreateAssetMenu(menuName = "GRP/Net/NetPartyConfig", fileName = "NetPartyConfig")]
	[AssetCreator(typeof(NetAssetCategory))]
	public class NetPartyConfig : NetModuleConfig
	{
		public Color[] colors;

		public Color GetColor(int id)
		{
			return default(Color);
		}

		public Color GetColor(Id id)
		{
			return default(Color);
		}
	}
}
