using UnityEngine;

namespace GRP
{
	public class BevelGearInlayVisual : MonoBehaviour
	{
		public BevelGearVisual visual;

		public MeshCollider meshCollider;

		public GearInlayContainer inlayContainer;

		private GearModule module;

		private BevelGearVisualOptions options;

		public void Build(BevelGearVisualOptions options, GearConfig config)
		{
		}

		public void Destroy()
		{
		}

		public Mesh BuildColliderMesh(BevelGearVisualOptions options, GearConfig config)
		{
			return null;
		}

		private void OnDrawGizmos()
		{
		}
	}
}
