using System.Collections.Generic;
using Motorways;
using UnityEngine;

public class TrainShadowView : MonoBehaviour
{
	private struct Edge
	{
		public readonly int firstVertIndex;

		public readonly int secondVertIndex;

		public Edge(int firstVertIndex, int secondVertIndex)
		{
			this.firstVertIndex = firstVertIndex;
			this.secondVertIndex = secondVertIndex;
		}
	}

	private static readonly Vector3 SunDirectionWorld = new Vector3(1f, -1f, 0f).normalized;

	[SerializeField]
	private Transform _carriageTransform;

	[SerializeField]
	private MeshFilter _mainShadowMeshFilter;

	[SerializeField]
	private MeshFilter _gapShadowMeshFilter;

	private Mesh _gapShadowMesh;

	private Vector3[] _mainShadowMeshBoundaryVertices;

	private Quaternion _lightToWorldRotation = Quaternion.identity;

	private Quaternion _worldToLightRotation = Quaternion.identity;

	private VisualConstantsData _visualConstantsData;

	public void OnCreatedInScope(VisualConstantsData visualConstantsData)
	{
		_visualConstantsData = visualConstantsData;
	}

	private void Start()
	{
		UpdateMainShadowPosition();
		Mesh mesh = _mainShadowMeshFilter.mesh;
		List<Edge> edges = GenerateEdgesFromTriangles(mesh.triangles);
		edges = FindBoundaryEdges(edges);
		Vector3[] vertices = _mainShadowMeshFilter.mesh.vertices;
		_mainShadowMeshBoundaryVertices = new Vector3[edges.Count];
		for (int i = 0; i < edges.Count; i++)
		{
			_mainShadowMeshBoundaryVertices[i] = vertices[edges[i].firstVertIndex];
		}
		_lightToWorldRotation = Quaternion.LookRotation(Vector3.forward, SunDirectionWorld);
		_worldToLightRotation = Quaternion.Inverse(_lightToWorldRotation);
		_gapShadowMesh = new Mesh
		{
			vertices = CalculateGapMeshVertices(),
			triangles = new int[6] { 0, 1, 3, 0, 3, 2 }
		};
		_gapShadowMeshFilter.mesh = _gapShadowMesh;
	}

	private void UpdateMainShadowPosition()
	{
		_mainShadowMeshFilter.transform.position = _carriageTransform.position + _visualConstantsData.TrainShadowOffset * SunDirectionWorld;
	}

	private void Update()
	{
		UpdateMainShadowPosition();
		Vector3[] vertices = CalculateGapMeshVertices();
		_gapShadowMesh.vertices = vertices;
	}

	private Vector3[] CalculateGapMeshVertices()
	{
		Quaternion quaternion = _carriageTransform.rotation * _worldToLightRotation;
		Quaternion quaternion2 = Quaternion.Inverse(quaternion);
		Vector4 vector = quaternion * _mainShadowMeshBoundaryVertices[0];
		Vector3 vector2 = vector;
		Vector3 vector3 = vector;
		for (int i = 1; i < _mainShadowMeshBoundaryVertices.Length; i++)
		{
			Vector4 vector4 = quaternion * _mainShadowMeshBoundaryVertices[i];
			if (vector4.x > vector3.x)
			{
				vector3 = vector4;
			}
			if (vector4.x < vector2.x)
			{
				vector2 = vector4;
			}
		}
		Vector3 vector5 = vector2 - _visualConstantsData.TrainShadowOffset * Vector3.up;
		Vector3 vector6 = vector3 - _visualConstantsData.TrainShadowOffset * Vector3.up;
		Vector3 vector7 = quaternion2 * vector2;
		Vector3 vector8 = quaternion2 * vector3;
		Vector3 vector9 = quaternion2 * vector5;
		Vector3 vector10 = quaternion2 * vector6;
		return new Vector3[4] { vector7, vector8, vector9, vector10 };
	}

	private List<Edge> GenerateEdgesFromTriangles(int[] triangles)
	{
		List<Edge> list = new List<Edge>();
		for (int i = 0; i < triangles.Length; i += 3)
		{
			int num = triangles[i];
			int num2 = triangles[i + 1];
			int num3 = triangles[i + 2];
			list.Add(new Edge(num, num2));
			list.Add(new Edge(num2, num3));
			list.Add(new Edge(num3, num));
		}
		return list;
	}

	private List<Edge> FindBoundaryEdges(List<Edge> edges)
	{
		List<Edge> list = new List<Edge>(edges);
		for (int num = list.Count - 1; num > 0; num--)
		{
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				if (list[num].firstVertIndex == list[num2].secondVertIndex && list[num].secondVertIndex == list[num2].firstVertIndex)
				{
					list.RemoveAt(num);
					list.RemoveAt(num2);
					num--;
					break;
				}
			}
		}
		return list;
	}
}
