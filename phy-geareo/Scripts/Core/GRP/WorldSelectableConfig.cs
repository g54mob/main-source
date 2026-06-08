using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/WorldSelectableConfig", fileName = "WorldSelectableConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class WorldSelectableConfig : ScriptableObject
	{
		public Material hover;

		public Material down;

		public float hoverScale;

		public float downScale;

		public float smooth;
	}
}
