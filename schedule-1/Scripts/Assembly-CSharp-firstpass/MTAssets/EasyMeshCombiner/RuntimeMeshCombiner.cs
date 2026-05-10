using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MTAssets.EasyMeshCombiner
{
	[AddComponentMenu("MT Assets/Easy Mesh Combiner/Runtime Mesh Combiner")]
	public class RuntimeMeshCombiner : MonoBehaviour
	{
		private class GameObjectWithMesh
		{
			public GameObject gameObject;

			public MeshFilter meshFilter;

			public MeshRenderer meshRenderer;

			public GameObjectWithMesh(GameObject gameObject, MeshFilter meshFilter, MeshRenderer meshRenderer)
			{
			}
		}

		private class OriginalGameObjectWithMesh
		{
			public GameObject gameObject;

			public bool originalGoState;

			public MeshRenderer meshRenderer;

			public bool originalMrState;

			public OriginalGameObjectWithMesh(GameObject gameObject, bool originalGoState, MeshRenderer meshRenderer, bool originalMrState)
			{
			}
		}

		private class SubMeshToCombine
		{
			public Transform transform;

			public MeshFilter meshFilter;

			public MeshRenderer meshRenderer;

			public int subMeshIndex;

			public SubMeshToCombine(Transform transform, MeshFilter meshFilter, MeshRenderer meshRenderer, int subMeshIndex)
			{
			}
		}

		public enum CombineOnStart
		{
			Disabled = 0,
			OnStart = 1,
			OnAwake = 2
		}

		public enum AfterMerge
		{
			DisableOriginalMeshes = 0,
			DeactiveOriginalGameObjects = 1,
			DoNothing = 2
		}

		private int MAX_VERTICES_FOR_16BITS_MESH;

		private Vector3 originalPosition;

		private Vector3 originalEulerAngles;

		private Vector3 originalScale;

		private List<OriginalGameObjectWithMesh> originalGameObjectsWithMeshToRestore;

		private bool targetMeshesMerged;

		[HideInInspector]
		public AfterMerge afterMerge;

		[HideInInspector]
		public bool addMeshColliderAfter;

		[HideInInspector]
		public CombineOnStart combineMeshesAtStartUp;

		[HideInInspector]
		public bool combineInChildren;

		[HideInInspector]
		public bool combineInactives;

		[HideInInspector]
		public bool recalculateNormals;

		[HideInInspector]
		public bool recalculateTangents;

		[HideInInspector]
		public bool optimizeResultingMesh;

		[HideInInspector]
		public List<GameObject> targetMeshes;

		[HideInInspector]
		public bool showDebugLogs;

		[HideInInspector]
		public bool garbageCollectorAfterUndo;

		public UnityEvent onDoneMerge;

		public UnityEvent onDoneUnmerge;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private GameObjectWithMesh[] GetValidatedTargetGameObjects()
		{
			return null;
		}

		public bool CombineMeshes()
		{
			return false;
		}

		public bool UndoMerge()
		{
			return false;
		}

		public bool isTargetMeshesMerged()
		{
			return false;
		}
	}
}
