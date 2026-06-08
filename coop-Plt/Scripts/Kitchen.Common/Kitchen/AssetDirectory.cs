using System.Collections.Generic;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	[CreateAssetMenu(fileName = "AssetDirectory", menuName = "Kitchen/Asset Directory", order = 1)]
	public class AssetDirectory : KitchenObject
	{
		public Dictionary<ViewType, GameObject> ViewPrefabs;

		public LayoutProfile GenericLayoutProfile;
	}
}
