using System.Collections.Generic;
using UnityEngine;

namespace GogoGaga.OptimizedRopesAndCables
{
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(Rope))]
	public class RopeMesh : MonoBehaviour
	{
		[Range(3f, 25f)]
		public int OverallDivision;

		[Range(0.01f, 10f)]
		public float ropeWidth;

		[Range(3f, 20f)]
		public int radialDivision;

		[Tooltip("For now only base color is applied")]
		public Material material;

		[Tooltip("Tiling density per meter of the rope")]
		public float tilingPerMeter;

		private Rope rope;

		private MeshFilter meshFilter;

		private MeshRenderer meshRenderer;

		private Mesh ropeMesh;

		private bool isStartOrEndPointMissing;

		private List<Vector3> vertices;

		private List<int> triangles;

		private List<Vector2> uvs;

		private void OnValidate()
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void InitializeComponents()
		{
		}

		private void CheckEndPoints()
		{
		}

		private void SubscribeToRopeEvents()
		{
		}

		private void UnsubscribeFromRopeEvents()
		{
		}

		public void CreateRopeMesh(Vector3[] points, float radius, int segmentsPerWire)
		{
		}

		private void GenerateMesh()
		{
		}

		private void Update()
		{
		}

		private void DelayedGenerateMesh()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
