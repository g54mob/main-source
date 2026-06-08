using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/GearModule", fileName = "GearModule")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class GearModule : ScriptableObject
	{
		public int key;

		public float toothDepth;

		public float toothWidth;

		public float attachDistance;

		public float simPadding;

		public Mesh toothMesh;

		public Mesh toothMeshSkip;

		public float halfToothDepth => 0f;
	}
}
