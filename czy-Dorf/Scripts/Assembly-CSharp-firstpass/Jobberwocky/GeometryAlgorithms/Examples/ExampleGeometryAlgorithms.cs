using Jobberwocky.GeometryAlgorithms.Examples.Data;
using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples
{
	public abstract class ExampleGeometryAlgorithms : MonoBehaviour
	{
		protected void CreatePointSpheres(Vector3[] vertices, float scale, Mesh mesh, Material material, GameObject parent)
		{
			GameObject[] array = new GameObject[vertices.Length];
			for (int i = 0; i < vertices.Length; i++)
			{
				array[i] = new GameObject("Point " + i);
				array[i].transform.parent = parent.transform;
				array[i].transform.localPosition = vertices[i];
				array[i].transform.localScale = new Vector3(scale, scale, scale);
				array[i].AddComponent<MeshFilter>().mesh = mesh;
				array[i].AddComponent<MeshRenderer>().material = material;
			}
		}

		protected void CreateLineCylinders(Vector3[] vertices, float scale, Mesh mesh, Material material, GameObject parent)
		{
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 vector = vertices[i];
				Vector3 vector2 = vertices[(i + 1) % vertices.Length];
				GameObject obj = new GameObject(parent.name + " Cylinder " + i);
				obj.transform.parent = parent.transform;
				obj.transform.localPosition = (vector2 - vector) / 2f + vector;
				obj.transform.localScale = new Vector3(scale, (vector2 - vector).magnitude / 2f, scale);
				obj.transform.rotation = Quaternion.FromToRotation(Vector3.up, vector2 - vector);
				obj.AddComponent<MeshFilter>().mesh = mesh;
				obj.AddComponent<MeshRenderer>().material = material;
			}
		}

		protected void CreateBoundaries(Shape shape, float scale, Mesh mesh, Material material, GameObject parent)
		{
			if (shape.GetBoundaryPointCount() > 0)
			{
				CreateLineCylinders(shape.Boundary, scale, mesh, material, parent);
			}
			int holeCount = shape.GetHoleCount();
			if (holeCount > 0)
			{
				Vector3[][] holes = shape.Holes;
				for (int i = 0; i < holeCount; i++)
				{
					CreateLineCylinders(holes[i], scale, mesh, material, parent);
				}
			}
		}

		protected void CreateWireframe(Mesh mesh, float scale, Mesh wireframeMesh, Material material, GameObject parent)
		{
			int[] indices = mesh.GetIndices(0);
			Vector3[] vertices = mesh.vertices;
			Vector3[] array = new Vector3[3];
			for (int i = 0; i < indices.Length; i += 3)
			{
				for (int j = 0; j < 3; j++)
				{
					array[j] = vertices[indices[i + j]];
				}
				CreateLineCylinders(array, scale, wireframeMesh, material, parent);
			}
		}
	}
}
