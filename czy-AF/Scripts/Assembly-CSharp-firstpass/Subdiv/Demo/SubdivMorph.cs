using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace Subdiv.Demo
{
	[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
	public class SubdivMorph : MonoBehaviour
	{
		[SerializeField]
		[Range(1f, 3f)]
		protected int details = 2;

		[SerializeField]
		protected Vector3 noise = new Vector3(1f, 1f, 1f);

		[SerializeField]
		protected float speed = 1f;

		protected ComputeBuffer buffer;

		protected Renderer renderer;

		protected MaterialPropertyBlock block;

		protected const string kBufferKey = "_VertexBuffer";

		protected const string kNoiseParamsKey = "_NoiseParams";

		private void Start()
		{
			MeshFilter component = GetComponent<MeshFilter>();
			Mesh mesh = component.mesh;
			Model model = SubdivisionSurface.Subdivide(SubdivisionSurface.Weld(mesh, float.Epsilon, mesh.bounds.size.x), details);
			Setup(component, mesh, model);
		}

		private void Update()
		{
			block.SetVector("_NoiseParams", new Vector4(noise.x, noise.y, noise.z, Time.timeSinceLevelLoad * speed));
			renderer.SetPropertyBlock(block);
		}

		private void Setup(MeshFilter filter, Mesh source, Model model)
		{
			Vector3[] vertices = source.vertices;
			Vector3[] normals = source.normals;
			Mesh mesh = new Mesh();
			int[] array = new int[model.triangles.Count * 3];
			Vector3[] array2 = new Vector3[model.triangles.Count * 3];
			buffer = new ComputeBuffer(array2.Length, Marshal.SizeOf(typeof(MVertex_t)));
			MVertex_t[] array3 = new MVertex_t[buffer.count];
			int i = 0;
			for (int count = model.triangles.Count; i < count; i++)
			{
				Triangle triangle = model.triangles[i];
				int num = i * 3;
				int num2 = i * 3 + 1;
				int num3 = i * 3 + 2;
				array2[num] = triangle.v0.p;
				array2[num2] = triangle.v1.p;
				array2[num3] = triangle.v2.p;
				array[num] = num;
				array[num2] = num2;
				array[num3] = num3;
				array3[num] = new MVertex_t(vertices[triangle.v0.index], normals[triangle.v0.index]);
				array3[num2] = new MVertex_t(vertices[triangle.v1.index], normals[triangle.v1.index]);
				array3[num3] = new MVertex_t(vertices[triangle.v2.index], normals[triangle.v2.index]);
			}
			mesh.vertices = array2;
			mesh.indexFormat = ((mesh.vertexCount >= 65535) ? IndexFormat.UInt32 : IndexFormat.UInt16);
			mesh.triangles = array;
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			buffer.SetData(array3);
			filter.sharedMesh = mesh;
			block = new MaterialPropertyBlock();
			renderer = GetComponent<Renderer>();
			renderer.GetPropertyBlock(block);
			block.SetBuffer("_VertexBuffer", buffer);
			renderer.SetPropertyBlock(block);
		}

		private void OnDestroy()
		{
			if (buffer != null)
			{
				buffer.Release();
				buffer = null;
			}
		}
	}
}
