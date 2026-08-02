using Rhizomatic;
using UnityEngine;

namespace GRP.Steam
{
	[CreateAssetMenu(menuName = "GRP/Main/SteamWishlistConfig", fileName = "SteamWishlistConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class SteamWishlistConfig : ScriptableObject
	{
		public uint appId;
	}
}
