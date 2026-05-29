using System;
using System.Collections.Generic;
using UnityEngine;

namespace StylizedWater2
{
	[ExecuteInEditMode]
	[AddComponentMenu("Stylized Water 2/Water Grid")]
	public class WaterGrid : MonoBehaviour
	{
		[Tooltip("Material used on the tile meshes")]
		public Material material;

		[Tooltip("When not in play-mode, the water will follow the scene-view camera position.")]
		public bool followSceneCamera;

		[Tooltip("If enabled, the object with the \"MainCamera\" tag will be assigned as the follow target when entering play mode")]
		public bool autoAssignCamera;

		[Tooltip("The grid will follow this Transform's position on the XZ axis. Ideally set to the camera's transform.")]
		public Transform followTarget;

		[Tooltip("Scale of the entire grid in the length and width")]
		public float scale;

		[Tooltip("Distance between vertices, rather higher than lower")]
		[Range(0.15f, 10f)]
		public float vertexDistance;

		[Min(0f)]
		public int rowsColumns;

		[HideInInspector]
		public int m_rowsColumns;

		[SerializeField]
		[HideInInspector]
		private Mesh mesh;

		[HideInInspector]
		[SerializeField]
		private List<WaterObject> objects;

		[NonSerialized]
		private float tileSize;

		[NonSerialized]
		private WaterObject m_waterObject;

		[NonSerialized]
		private Transform actualFollowTarget;

		[NonSerialized]
		private Vector3 targetPosition;

		private void Reset()
		{
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		public void Recreate()
		{
		}

		private void CalculateTileSize()
		{
		}

		private void RecreateMesh()
		{
		}

		private void ReassignMesh()
		{
		}

		private Vector3 GridLocalCenterPosition(int x, int z)
		{
			return default(Vector3);
		}

		public static Vector3 SnapToGrid(Vector3 position, float cellSize)
		{
			return default(Vector3);
		}

		private static float SnapToGrid(float position, float cellSize)
		{
			return 0f;
		}
	}
}
