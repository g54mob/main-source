using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/CylinderVisualConfig", fileName = "CylinderVisualConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class CylinderVisualConfig : ScriptableObject
	{
		public float size;

		public int sideIndex;

		public int topIndex;
	}
}
