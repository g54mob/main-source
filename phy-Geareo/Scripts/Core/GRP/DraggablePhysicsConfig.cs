using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/DraggablePhysicsConfig", fileName = "DraggablePhysicsConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class DraggablePhysicsConfig : ScriptableObject
	{
		public DraggablePhysicsLine line;

		public float force;

		public float linearDamping;

		public float angularDamping;
	}
}
