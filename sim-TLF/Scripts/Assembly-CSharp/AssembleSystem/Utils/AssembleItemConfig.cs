using System.Collections.Generic;
using UnityEngine;

namespace AssembleSystem.Utils
{
	[CreateAssetMenu(menuName = "Assemble/Config")]
	public class AssembleItemConfig : ScriptableObject
	{
		public GameObject ItemPrefab;

		public Sprite CraftItemIcon;

		public List<PartConfig> PartsConfig;
	}
}
