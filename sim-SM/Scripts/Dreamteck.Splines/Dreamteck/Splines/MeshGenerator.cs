using UnityEngine;
using UnityEngine.Rendering;

namespace Dreamteck.Splines
{
	public class MeshGenerator : SplineUser
	{
		public enum UVMode
		{
			Clip = 0,
			UniformClip = 1,
			Clamp = 2,
			UniformClamp = 3
		}

		public enum NormalMethod
		{
			Recalculate = 0,
			SplineNormals = 1
		}

		protected const int UNITY_16_VERTEX_LIMIT = 65535;

		[SerializeField]
		[HideInInspector]
		private bool _baked;

		[SerializeField]
		[HideInInspector]
		private bool _markDynamic;

		[SerializeField]
		[HideInInspector]
		private float _size;

		[SerializeField]
		[HideInInspector]
		private Color _color;

		[SerializeField]
		[HideInInspector]
		private Vector3 _offset;

		[SerializeField]
		[HideInInspector]
		private NormalMethod _normalMethod;

		[SerializeField]
		[HideInInspector]
		private bool _calculateTangents;

		[SerializeField]
		[HideInInspector]
		private bool _useSplineSize;

		[SerializeField]
		[HideInInspector]
		private bool _useSplineColor;

		[SerializeField]
		[HideInInspector]
		[Range(-360f, 360f)]
		private float _rotation;

		[SerializeField]
		[HideInInspector]
		private bool _flipFaces;

		[SerializeField]
		[HideInInspector]
		private bool _doubleSided;

		[SerializeField]
		[HideInInspector]
		private UVMode _uvMode;

		[SerializeField]
		[HideInInspector]
		private Vector2 _uvScale;

		[SerializeField]
		[HideInInspector]
		private Vector2 _uvOffset;

		[SerializeField]
		[HideInInspector]
		private float _uvRotation;

		[SerializeField]
		[HideInInspector]
		private IndexFormat _meshIndexFormat;

		[SerializeField]
		[HideInInspector]
		private Mesh _bakedMesh;

		[HideInInspector]
		public float colliderUpdateRate;

		protected bool _updateCollider;

		protected float _lastUpdateTime;

		private float _vDist;

		protected static Vector2 __uvs;

		protected Mesh _mesh;

		protected MeshFilter filter;

		protected MeshRenderer meshRenderer;

		protected MeshCollider meshCollider;

		public float size
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Color color
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Vector3 offset
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public NormalMethod normalMethod
		{
			get
			{
				return default(NormalMethod);
			}
			set
			{
			}
		}

		public bool useSplineSize
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool useSplineColor
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool calculateTangents
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float rotation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool flipFaces
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool doubleSided
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public UVMode uvMode
		{
			get
			{
				return default(UVMode);
			}
			set
			{
			}
		}

		public Vector2 uvScale
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector2 uvOffset
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public float uvRotation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public IndexFormat meshIndexFormat
		{
			get
			{
				return default(IndexFormat);
			}
			set
			{
			}
		}

		public bool baked => false;

		public bool markDynamic
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected virtual string meshName => null;

		protected TS_Mesh _tsMesh { get; private set; }

		protected override void Awake()
		{
		}

		protected override void Reset()
		{
		}

		private void GetComponents()
		{
		}

		public override void Rebuild()
		{
		}

		public override void RebuildImmediate()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void UpdateCollider()
		{
		}

		protected override void LateRun()
		{
		}

		protected override void Build()
		{
		}

		protected override void PostBuild()
		{
		}

		protected virtual void ClearMesh()
		{
		}

		protected virtual void BuildMesh()
		{
		}

		protected virtual void WriteMesh()
		{
		}

		protected virtual void AllocateMesh(int vertexCount, int trisCount)
		{
		}

		protected void ResetUVDistance()
		{
		}

		protected void AddUVDistance(int sampleIndex)
		{
		}

		protected void CalculateUVs(double percent, float u)
		{
		}

		protected float GetBaseSize(SplineSample sample)
		{
			return 0f;
		}

		protected Color GetBaseColor(SplineSample sample)
		{
			return default(Color);
		}

		protected virtual void CreateMesh()
		{
		}

		private void RefreshMesh()
		{
		}
	}
}
