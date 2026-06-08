using UnityEngine;

namespace GRP
{
	public class BevelGearHoleVisual : MonoBehaviour
	{
		public BevelGearVisual visual;

		public GameObject colliderObj;

		private GearModule module;

		private BevelGearVisualOptions options;

		public void Build(BevelGearVisualOptions options, GearConfig config)
		{
		}

		public void Destroy()
		{
		}

		public Mesh[] BuildColliderMesh(BevelGearVisualOptions options, GearConfig config)
		{
			return null;
		}
	}
}
