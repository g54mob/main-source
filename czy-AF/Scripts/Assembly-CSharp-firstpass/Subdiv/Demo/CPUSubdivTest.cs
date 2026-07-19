using UnityEngine;

namespace Subdiv.Demo
{
	[RequireComponent(typeof(MeshFilter))]
	public class CPUSubdivTest : MonoBehaviour
	{
		[SerializeField]
		[Range(1f, 4f)]
		protected int details = 1;

		[SerializeField]
		private bool weld;

		private void Start()
		{
			MeshFilter component = GetComponent<MeshFilter>();
			Mesh mesh = component.mesh;
			Mesh sharedMesh = SubdivisionSurface.Subdivide(SubdivisionSurface.Weld(mesh, float.Epsilon, mesh.bounds.size.x), details, weld);
			component.sharedMesh = sharedMesh;
		}
	}
}
