using Rhizomatic;
using UnityEngine;

namespace GRP.Steam
{
	[CreateAssetMenu(menuName = "GRP/Main/SteamworksConfig", fileName = "SteamworksConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class SteamworksConfig : ScriptableObject
	{
		public uint appId;
	}
}
