using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/BoxVisualConfig", fileName = "BoxVisualConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class BoxVisualConfig : ScriptableObject
	{
		public float size;

		public int xIndex;

		public int yIndex;

		public int zIndex;
	}
}
