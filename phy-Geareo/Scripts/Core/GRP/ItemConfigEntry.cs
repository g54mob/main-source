using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/ItemConfigEntry", fileName = "ItemConfigEntry")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class ItemConfigEntry : ConfigEntry
	{
		public ItemConfig config;
	}
}
