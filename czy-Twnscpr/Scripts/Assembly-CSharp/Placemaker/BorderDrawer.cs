using UnityEngine;

namespace Placemaker
{
	public class BorderDrawer : MonoBehaviour
	{
		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		private Mesh mesh;

		[SerializeField]
		private Material material;

		private MaterialPropertyBlock block;

		private void OnEnable()
		{
		}

		private void SetupBlock()
		{
		}

		public void OnStart()
		{
		}

		public void BoundsUpdated()
		{
		}

		public void Draw()
		{
		}
	}
}
