using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tools.Fracturing
{
	public class FractureMeshScript : MonoBehaviour
	{
		private const string CacheDepthFinishedGameObjects = "Finished Game Objects";

		private const string CacheDepthMeshDataOnly = "Mesh Data Only";

		private const string ConfigPropertyGroup = "Fracture Options";

		private const string IndividualMeshPropertyGroup = "Individual Mesh";

		private const string PerfTestingPropertyGroup = "Performance Options";

		[SerializeField]
		private string _cacheDepth = "Finished Game Objects";

		private string[] _cacheDepths = new string[2] { "Mesh Data Only", "Finished Game Objects" };

		[SerializeField]
		private bool _copyNormalData = true;

		[SerializeField]
		private bool _copyUv2Data = true;

		[SerializeField]
		private bool _copyUvData = true;

		[SerializeField]
		private bool _createColliders = true;

		private GameObject _gameObjectCacheForIndividualMesh;

		[SerializeField]
		private MeshRenderer _individualSourceMesh;

		[Range(0f, 50f)]
		[SerializeField]
		private float _maxAngularVelocitySpeed = 17.5f;

		[Range(0f, 500f)]
		[SerializeField]
		private float _maxVelocity = 175f;

		[Range(0f, 50f)]
		[SerializeField]
		[Tooltip("The minimum mesh bounds radius for an original mesh to be processed into fractured pieces, otherwise the mesh will not be discarded. Zero disables discard.")]
		private float _minBoundsRadiusInitial = 2f;

		[Range(0f, 50f)]
		[SerializeField]
		private float _minBoundsRadiusPiece = 1f;

		private List<FractureMesh.FracturePiece> _piecesCacheForIndividualMesh;

		[Range(-0.001f, 1f)]
		[SerializeField]
		private float _trisBasedOnPercentOfMesh = 0.25f;

		[Range(1f, 500f)]
		[SerializeField]
		private int _trisPerPiece;

		public bool CopyNormalData
		{
			get
			{
				return _copyNormalData;
			}
			set
			{
				_copyNormalData = value;
			}
		}

		public bool CopyUv2Data
		{
			get
			{
				return _copyUv2Data;
			}
			set
			{
				_copyUv2Data = value;
			}
		}

		public bool CopyUvData
		{
			get
			{
				return _copyUvData;
			}
			set
			{
				_copyUvData = value;
			}
		}

		public bool CreateColliders
		{
			get
			{
				return _createColliders;
			}
			set
			{
				_createColliders = value;
			}
		}

		public MeshRenderer IndividualSourceMesh
		{
			get
			{
				return _individualSourceMesh;
			}
			set
			{
				_individualSourceMesh = value;
			}
		}

		public float MaxAngularSpinSpeed
		{
			get
			{
				return _maxAngularVelocitySpeed;
			}
			set
			{
				_maxAngularVelocitySpeed = value;
			}
		}

		public float MaxVelocity
		{
			get
			{
				return _maxVelocity;
			}
			set
			{
				_maxVelocity = value;
			}
		}

		public float MinBoundsRadiusInitial
		{
			get
			{
				return _minBoundsRadiusInitial;
			}
			set
			{
				_minBoundsRadiusInitial = value;
			}
		}

		public float MinBoundsRadiusPiece
		{
			get
			{
				return _minBoundsRadiusPiece;
			}
			set
			{
				_minBoundsRadiusPiece = value;
			}
		}

		public float TrisBasedOnPercentOfMesh
		{
			get
			{
				return _trisBasedOnPercentOfMesh;
			}
			set
			{
				_trisBasedOnPercentOfMesh = value;
			}
		}

		public int TrisPerPiece
		{
			get
			{
				return _trisPerPiece;
			}
			set
			{
				_trisPerPiece = value;
			}
		}

		public static int CalculateTrisPerPiece(Mesh mesh, int trisPerPieceSetting, float trisBasedOnPercentOfMeshSetting)
		{
			int result = trisPerPieceSetting;
			if (trisBasedOnPercentOfMeshSetting > 0f)
			{
				result = (int)((float)(mesh.triangles.Length / 3) * trisBasedOnPercentOfMeshSetting);
			}
			return result;
		}

		public void FractureIndividualMesh(MeshRenderer meshRenderer, Transform parentContainer)
		{
			MeshFilter component = meshRenderer.GetComponent<MeshFilter>();
			FractureMesh.TransformInfo transformInfo = FractureMesh.CreateMeshTransformInfo(component);
			Mesh mesh = component.mesh;
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			float num = mesh.bounds.extents.magnitude * meshRenderer.transform.lossyScale.magnitude;
			if (num > _minBoundsRadiusInitial)
			{
				int trisPerPiece = CalculateTrisPerPiece(mesh, _trisPerPiece, _trisBasedOnPercentOfMesh);
				foreach (FractureMesh.FracturePiece item in FractureMesh.CreateMeshFracturePieces(mesh, trisPerPiece, _copyUvData, _copyUv2Data, _copyNormalData, transformInfo))
				{
					FractureMesh.ConstructFromPiece(parentContainer, item, meshRenderer.sharedMaterial, _createColliders, _minBoundsRadiusPiece, _maxAngularVelocitySpeed, _maxVelocity);
				}
			}
			else
			{
				Debug.LogWarning($"Mesh radius ({num}) is less than minimum to process ({_minBoundsRadiusInitial}), rejecting.");
			}
			Debug.Log($"Elapsed:{Time.realtimeSinceStartup - realtimeSinceStartup}s - Processed and and created objects");
		}

		protected virtual void Awake()
		{
			Initialize();
		}

		protected virtual void Initialize()
		{
		}

		private void CreateCacheIndividualMesh()
		{
			MeshRenderer individualSourceMesh = _individualSourceMesh;
			MeshFilter component = individualSourceMesh.GetComponent<MeshFilter>();
			Mesh mesh = component.mesh;
			int trisPerPiece = CalculateTrisPerPiece(mesh, _trisPerPiece, _trisBasedOnPercentOfMesh);
			if (_cacheDepth == "Mesh Data Only")
			{
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				_piecesCacheForIndividualMesh = FractureMesh.CreateMeshFracturePieces(mesh, trisPerPiece, _copyUvData, _copyUv2Data, _copyNormalData, FractureMesh.CreateMeshTransformInfo(component));
				Debug.Log($"Elapsed:{Time.realtimeSinceStartup - realtimeSinceStartup}s - Created mesh data cache");
			}
			else if (_cacheDepth == "Finished Game Objects")
			{
				float realtimeSinceStartup2 = Time.realtimeSinceStartup;
				List<FractureMesh.FracturePiece> list = FractureMesh.CreateMeshFracturePieces(mesh, trisPerPiece, _copyUvData, _copyUv2Data, _copyNormalData, FractureMesh.CreateMeshTransformInfo(component));
				_gameObjectCacheForIndividualMesh = new GameObject("FractureCache");
				foreach (FractureMesh.FracturePiece item in list)
				{
					FractureMesh.ConstructFromPiece(_gameObjectCacheForIndividualMesh.transform, item, individualSourceMesh.sharedMaterial, createCollider: true, _minBoundsRadiusPiece, _maxAngularVelocitySpeed, _maxVelocity);
				}
				_gameObjectCacheForIndividualMesh.SetActive(value: false);
				Debug.Log($"Elapsed:{Time.realtimeSinceStartup - realtimeSinceStartup2}s - Created full cache");
			}
			else
			{
				Debug.LogError("Unsupported cache depth: " + _cacheDepth);
			}
		}

		private void CreateFromCacheIndividualMesh()
		{
			DeleteFracturePieces();
			if (_individualSourceMesh == null)
			{
				Debug.LogError("Set source mesh first");
			}
			else if (_cacheDepth == "Mesh Data Only")
			{
				if (_piecesCacheForIndividualMesh != null && _piecesCacheForIndividualMesh.Count == 0)
				{
					float realtimeSinceStartup = Time.realtimeSinceStartup;
					if (_piecesCacheForIndividualMesh != null)
					{
						foreach (FractureMesh.FracturePiece item in _piecesCacheForIndividualMesh)
						{
							FractureMesh.ConstructFromPiece(base.transform, item, null, _createColliders, _minBoundsRadiusPiece, _maxAngularVelocitySpeed, _maxVelocity);
						}
					}
					Debug.Log($"Elapsed:{Time.realtimeSinceStartup - realtimeSinceStartup}s - Created game-object from cache");
				}
				else
				{
					Debug.LogError("Create cache first");
				}
			}
			else if (_cacheDepth == "Finished Game Objects")
			{
				if (_gameObjectCacheForIndividualMesh != null)
				{
					float realtimeSinceStartup2 = Time.realtimeSinceStartup;
					_gameObjectCacheForIndividualMesh.SetActive(value: true);
					Debug.Log($"Elapsed:{Time.realtimeSinceStartup - realtimeSinceStartup2}s - Created full cache");
				}
				else
				{
					Debug.LogError("Create cache first  (or cache was empty due to filtering options)");
				}
			}
			else
			{
				Debug.LogError("Unsupported cache depth: " + _cacheDepth);
			}
		}

		private void DeleteFracturePieces()
		{
			int childCount = base.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Object.DestroyImmediate(base.transform.GetChild(0).gameObject);
			}
		}

		private void InspectorInitiatedFracture()
		{
			if (_individualSourceMesh == null)
			{
				Debug.LogError("Set source mesh first");
				return;
			}
			DeleteFracturePieces();
			FractureIndividualMesh(_individualSourceMesh, base.transform);
		}
	}
}
