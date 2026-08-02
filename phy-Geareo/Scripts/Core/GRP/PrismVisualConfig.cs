using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/PrismVisualConfig", fileName = "PrismVisualConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class PrismVisualConfig : ScriptableObject
	{
		public float size;

		public int topIndex;

		public int bottomIndex;

		public int sideIndex;

		public int backIndex;
	}
}
