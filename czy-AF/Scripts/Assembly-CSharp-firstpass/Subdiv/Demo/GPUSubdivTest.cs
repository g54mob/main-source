using UnityEngine;

namespace Subdiv.Demo
{
	[RequireComponent(typeof(MeshFilter))]
	public class GPUSubdivTest : MonoBehaviour
	{
		[SerializeField]
		protected ComputeShader subdivCompute;

		[SerializeField]
		[Range(1f, 4f)]
		protected int details = 1;

		[SerializeField]
		private bool weld;

		private void Start()
		{
			MeshFilter component = GetComponent<MeshFilter>();
			Mesh mesh = component.mesh;
			Mesh sharedMesh = GPUSubdivisionSurface.Subdivide(subdivCompute, SubdivisionSurface.Weld(mesh, float.Epsilon, mesh.bounds.size.x), details, weld);
			component.sharedMesh = sharedMesh;
		}
	}
}
