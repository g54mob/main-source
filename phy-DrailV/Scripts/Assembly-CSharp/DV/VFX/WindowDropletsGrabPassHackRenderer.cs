using UnityEngine;

namespace DV.VFX
{
	public class WindowDropletsGrabPassHackRenderer : MonoBehaviour
	{
		public MeshFilter meshFilter;

		private static Mesh mesh;

		static WindowDropletsGrabPassHackRenderer()
		{
			Application.quitting += OnQuit;
		}

		private static void OnQuit()
		{
			Object.Destroy(mesh);
		}

		private void Awake()
		{
			if (mesh == null)
			{
				mesh = new Mesh();
				mesh.bounds = new Bounds
				{
					extents = Vector3.one * 50f
				};
			}
			meshFilter.sharedMesh = mesh;
		}
	}
}
