using System.Collections.Generic;
using UnityEngine;

namespace AutoTiling
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	public class AutoTextureTiling : MonoBehaviour
	{
		public float faceUnwrappingNormalTolerance = 30f;

		public bool useUnifiedScaling;

		[SerializeField]
		private Vector2 _topScale = Vector2.one;

		[SerializeField]
		private Vector2 _bottomScale = Vector2.one;

		[SerializeField]
		private Vector2 _leftScale = Vector2.one;

		[SerializeField]
		private Vector2 _rightScale = Vector2.one;

		[SerializeField]
		private Vector2 _frontScale = Vector2.one;

		[SerializeField]
		private Vector2 _backScale = Vector2.one;

		public bool useUnifiedOffset;

		[SerializeField]
		private Vector2 _topOffset = Vector2.zero;

		[SerializeField]
		private Vector2 _bottomOffset = Vector2.zero;

		[SerializeField]
		private Vector2 _leftOffset = Vector2.zero;

		[SerializeField]
		private Vector2 _rightOffset = Vector2.zero;

		[SerializeField]
		private Vector2 _frontOffset = Vector2.zero;

		[SerializeField]
		private Vector2 _backOffset = Vector2.zero;

		[SerializeField]
		private float _topRotation;

		[SerializeField]
		private float _bottomRotation;

		[SerializeField]
		private float _leftRotation;

		[SerializeField]
		private float _rightRotation;

		[SerializeField]
		private float _frontRotation;

		[SerializeField]
		private float _backRotation;

		[SerializeField]
		private int _topMaterialIndex;

		[SerializeField]
		private int _bottomMaterialIndex;

		[SerializeField]
		private int _leftMaterialIndex;

		[SerializeField]
		private int _rightMaterialIndex;

		[SerializeField]
		private int _frontMaterialIndex;

		[SerializeField]
		private int _backMaterialIndex;

		[SerializeField]
		private bool _topFlipX;

		[SerializeField]
		private bool _topFlipY;

		[SerializeField]
		private bool _bottomFlipX;

		[SerializeField]
		private bool _bottomFlipY;

		[SerializeField]
		private bool _leftFlipX;

		[SerializeField]
		private bool _leftFlipY;

		[SerializeField]
		private bool _rightFlipX;

		[SerializeField]
		private bool _rightFlipY;

		[SerializeField]
		private bool _frontFlipX;

		[SerializeField]
		private bool _frontFlipY;

		[SerializeField]
		private bool _backFlipX;

		[SerializeField]
		private bool _backFlipY;

		[SerializeField]
		private bool _useBakedMesh;

		[SerializeField]
		protected FaceData[] _faceUnwrapData;

		[SerializeField]
		private UnwrapType _unwrapMethod = UnwrapType.FaceDependent;

		[SerializeField]
		private bool freshMesh = true;

		protected float scaleX;

		protected float scaleY;

		protected float scaleZ;

		private Mesh bakedSharedMeshAsset;

		private MeshFilter _meshFilter;

		private MeshRenderer meshRenderer;

		private static string extensionString = ".asset";

		private static string meshAssetPathString = "Assets/AutoTextureTilingTool/Meshes/";

		public MeshRenderer Renderer
		{
			get
			{
				if (!meshRenderer)
				{
					meshRenderer = GetComponent<MeshRenderer>();
				}
				if (!meshRenderer)
				{
					Debug.LogError(string.Concat(base.name, ": ", GetType(), ".Renderer_get: there was no MeshRenderer component attached."));
				}
				return meshRenderer;
			}
		}

		public MeshFilter meshFilter
		{
			get
			{
				if (!_meshFilter)
				{
					_meshFilter = GetComponent<MeshFilter>();
				}
				if (!_meshFilter)
				{
					Debug.LogError(string.Concat(base.name, ": ", GetType(), ".meshFilter_get: there was no MeshFilter component attached."));
				}
				return _meshFilter;
			}
		}

		public FaceData[] faceUnwrapData => _faceUnwrapData;

		public UnwrapType unwrapMethod
		{
			get
			{
				return _unwrapMethod;
			}
			set
			{
				_unwrapMethod = value;
				CreateMeshAndUVs();
			}
		}

		public Vector2 topScale
		{
			get
			{
				return _topScale;
			}
			set
			{
				_topScale = value;
				CreateMeshAndUVs();
			}
		}

		public Vector2 bottomScale
		{
			get
			{
				return _bottomScale;
			}
			set
			{
				_bottomScale = value;
				if (useUnifiedScaling)
				{
					_topScale = value;
				}
				CreateMeshAndUVs();
			}
		}

		public Vector2 leftScale
		{
			get
			{
				return _leftScale;
			}
			set
			{
				_leftScale = value;
				if (useUnifiedScaling)
				{
					_topScale = value;
				}
				CreateMeshAndUVs();
			}
		}

		public Vector2 rightScale
		{
			get
			{
				return _rightScale;
			}
			set
			{
				_rightScale = value;
				if (useUnifiedScaling)
				{
					_topScale = value;
				}
				CreateMeshAndUVs();
			}
		}

		public Vector2 frontScale
		{
			get
			{
				return _frontScale;
			}
			set
			{
				_frontScale = value;
				if (useUnifiedScaling)
				{
					_topScale = value;
				}
				CreateMeshAndUVs();
			}
		}

		public Vector2 backScale
		{
			get
			{
				return _backScale;
			}
			set
			{
				_backScale = value;
				if (useUnifiedScaling)
				{
					_topScale = value;
				}
				CreateMeshAndUVs();
			}
		}

		public Vector2 topOffset
		{
			get
			{
				return _topOffset;
			}
			set
			{
				_topOffset = value;
				CreateMeshAndUVs();
			}
		}

		public Vector2 bottomOffset
		{
			get
			{
				return _bottomOffset;
			}
			set
			{
				_bottomOffset = value;
				if (useUnifiedOffset)
				{
					_topOffset = value;
				}
				CreateMeshAndUVs();
			}
		}

		public Vector2 leftOffset
		{
			get
			{
				return _leftOffset;
			}
			set
			{
				_leftOffset = value;
				if (useUnifiedOffset)
				{
					_topOffset = value;
				}
				CreateMeshAndUVs();
			}
		}

		public Vector2 rightOffset
		{
			get
			{
				return _rightOffset;
			}
			set
			{
				_rightOffset = value;
				if (useUnifiedOffset)
				{
					_topOffset = value;
				}
				CreateMeshAndUVs();
			}
		}

		public Vector2 frontOffset
		{
			get
			{
				return _frontOffset;
			}
			set
			{
				_frontOffset = value;
				if (useUnifiedOffset)
				{
					_topOffset = value;
				}
				CreateMeshAndUVs();
			}
		}

		public Vector2 backOffset
		{
			get
			{
				return _backOffset;
			}
			set
			{
				_backOffset = value;
				if (useUnifiedOffset)
				{
					_topOffset = value;
				}
				CreateMeshAndUVs();
			}
		}

		public float topRotation
		{
			get
			{
				return _topRotation;
			}
			set
			{
				_topRotation = value;
				CreateMeshAndUVs();
			}
		}

		public float bottomRotation
		{
			get
			{
				return _bottomRotation;
			}
			set
			{
				_bottomRotation = value;
				CreateMeshAndUVs();
			}
		}

		public float leftRotation
		{
			get
			{
				return _leftRotation;
			}
			set
			{
				_leftRotation = value;
				CreateMeshAndUVs();
			}
		}

		public float rightRotation
		{
			get
			{
				return _rightRotation;
			}
			set
			{
				_rightRotation = value;
				CreateMeshAndUVs();
			}
		}

		public float frontRotation
		{
			get
			{
				return _frontRotation;
			}
			set
			{
				_frontRotation = value;
				CreateMeshAndUVs();
			}
		}

		public float backRotation
		{
			get
			{
				return _backRotation;
			}
			set
			{
				_backRotation = value;
				CreateMeshAndUVs();
			}
		}

		public int topMaterialIndex
		{
			get
			{
				return _topMaterialIndex;
			}
			set
			{
				_topMaterialIndex = value;
				CreateMeshAndUVs();
			}
		}

		public int bottomMaterialIndex
		{
			get
			{
				return _bottomMaterialIndex;
			}
			set
			{
				_bottomMaterialIndex = value;
				CreateMeshAndUVs();
			}
		}

		public int leftMaterialIndex
		{
			get
			{
				return _leftMaterialIndex;
			}
			set
			{
				_leftMaterialIndex = value;
				CreateMeshAndUVs();
			}
		}

		public int rightMaterialIndex
		{
			get
			{
				return _rightMaterialIndex;
			}
			set
			{
				_rightMaterialIndex = value;
				CreateMeshAndUVs();
			}
		}

		public int frontMaterialIndex
		{
			get
			{
				return _frontMaterialIndex;
			}
			set
			{
				_frontMaterialIndex = value;
				CreateMeshAndUVs();
			}
		}

		public int backMaterialIndex
		{
			get
			{
				return _backMaterialIndex;
			}
			set
			{
				_backMaterialIndex = value;
				CreateMeshAndUVs();
			}
		}

		public bool topFlipX
		{
			get
			{
				return _topFlipX;
			}
			set
			{
				_topFlipX = value;
				CreateMeshAndUVs();
			}
		}

		public bool topFlipY
		{
			get
			{
				return _topFlipY;
			}
			set
			{
				_topFlipY = value;
				CreateMeshAndUVs();
			}
		}

		public bool bottomFlipX
		{
			get
			{
				return _bottomFlipX;
			}
			set
			{
				_bottomFlipX = value;
				CreateMeshAndUVs();
			}
		}

		public bool bottomFlipY
		{
			get
			{
				return _bottomFlipY;
			}
			set
			{
				_bottomFlipY = value;
				CreateMeshAndUVs();
			}
		}

		public bool leftFlipX
		{
			get
			{
				return _leftFlipX;
			}
			set
			{
				_leftFlipX = value;
				CreateMeshAndUVs();
			}
		}

		public bool leftFlipY
		{
			get
			{
				return _leftFlipY;
			}
			set
			{
				_leftFlipY = value;
				CreateMeshAndUVs();
			}
		}

		public bool rightFlipX
		{
			get
			{
				return _rightFlipX;
			}
			set
			{
				_rightFlipX = value;
				CreateMeshAndUVs();
			}
		}

		public bool rightFlipY
		{
			get
			{
				return _rightFlipY;
			}
			set
			{
				_rightFlipY = value;
				CreateMeshAndUVs();
			}
		}

		public bool frontFlipX
		{
			get
			{
				return _frontFlipX;
			}
			set
			{
				_frontFlipX = value;
				CreateMeshAndUVs();
			}
		}

		public bool frontFlipY
		{
			get
			{
				return _frontFlipY;
			}
			set
			{
				_frontFlipY = value;
				CreateMeshAndUVs();
			}
		}

		public bool backFlipX
		{
			get
			{
				return _backFlipX;
			}
			set
			{
				_backFlipX = value;
				CreateMeshAndUVs();
			}
		}

		public bool backFlipY
		{
			get
			{
				return _backFlipY;
			}
			set
			{
				_backFlipY = value;
				CreateMeshAndUVs();
			}
		}

		public bool useBakedMesh
		{
			get
			{
				return _useBakedMesh;
			}
			set
			{
				_useBakedMesh = value;
			}
		}

		public virtual void Awake()
		{
			_meshFilter = GetComponent<MeshFilter>();
			if (!_meshFilter)
			{
				Debug.LogError(string.Concat(base.name, ": ", GetType(), ".Awake: there was no MeshFilter component attached."));
			}
			meshRenderer = GetComponent<MeshRenderer>();
			if (!meshRenderer)
			{
				Debug.LogError(string.Concat(base.name, ": ", GetType(), ".Awake: there was no MeshRenderer component attached."));
			}
			scaleX = base.transform.lossyScale.x;
			scaleY = base.transform.lossyScale.y;
			scaleZ = base.transform.lossyScale.z;
			CreateMeshAndUVs();
		}

		public void AlignOffsetCenter(Direction side)
		{
			switch (side)
			{
			case Direction.Back:
				backOffset = Vector2.zero;
				break;
			case Direction.Down:
				bottomOffset = Vector2.zero;
				break;
			case Direction.Forward:
				frontOffset = Vector2.zero;
				break;
			case Direction.Left:
				leftOffset = Vector2.zero;
				break;
			case Direction.Right:
				rightOffset = Vector2.zero;
				break;
			case Direction.Up:
				topOffset = Vector2.zero;
				break;
			}
		}

		public void AlignOffsetCenter(int faceIndex)
		{
			ApplyFaceOffset(faceIndex, Vector2.zero);
		}

		public void AlignOffsetTop(Direction side)
		{
			switch (side)
			{
			case Direction.Back:
				backOffset = new Vector2(backOffset.x, 1f - (base.transform.lossyScale.y - backScale.y) / backScale.y * 0.5f);
				break;
			case Direction.Down:
				bottomOffset = new Vector2(bottomOffset.x, 1f - (base.transform.lossyScale.x - bottomScale.y) / bottomScale.y * 0.5f);
				break;
			case Direction.Forward:
				frontOffset = new Vector2(frontOffset.x, 1f - (base.transform.lossyScale.y - frontScale.y) / frontScale.y * 0.5f);
				break;
			case Direction.Left:
				leftOffset = new Vector2(leftOffset.x, 1f - (base.transform.lossyScale.y - leftScale.y) / leftScale.y * 0.5f);
				break;
			case Direction.Right:
				rightOffset = new Vector2(rightOffset.x, 1f - (base.transform.lossyScale.y - rightScale.y) / rightScale.y * 0.5f);
				break;
			case Direction.Up:
				topOffset = new Vector2(topOffset.x, 1f - (base.transform.lossyScale.x - topScale.y) / topScale.y * 0.5f);
				break;
			}
		}

		public void AlignOffsetTop(int faceIndex)
		{
			if (faceIndex < 0 || faceIndex >= _faceUnwrapData.Length)
			{
				Debug.LogError(string.Concat(base.name, ": ", GetType(), ".ApplyFaceScale: faceIndex out of range: ", faceIndex));
			}
			else
			{
				FaceData faceData = _faceUnwrapData[faceIndex];
				Rect faceBounds = GetFaceBounds(faceData);
				faceData.uvOffset = new Vector2(faceData.uvOffset.x, faceBounds.yMax / faceData.uvScale.y);
				CreateMeshAndUVs();
			}
		}

		public void AlignOffsetBottom(Direction side)
		{
			switch (side)
			{
			case Direction.Back:
				backOffset = new Vector2(backOffset.x, (base.transform.lossyScale.y - backScale.y) / backScale.y * 0.5f);
				break;
			case Direction.Down:
				bottomOffset = new Vector2(bottomOffset.x, (base.transform.lossyScale.x - bottomScale.y) / bottomScale.y * 0.5f);
				break;
			case Direction.Forward:
				frontOffset = new Vector2(frontOffset.x, (base.transform.lossyScale.y - frontScale.y) / frontScale.y * 0.5f);
				break;
			case Direction.Left:
				leftOffset = new Vector2(leftOffset.x, (base.transform.lossyScale.y - leftScale.y) / leftScale.y * 0.5f);
				break;
			case Direction.Right:
				rightOffset = new Vector2(rightOffset.x, (base.transform.lossyScale.y - rightScale.y) / rightScale.y * 0.5f);
				break;
			case Direction.Up:
				topOffset = new Vector2(topOffset.x, (base.transform.lossyScale.x - topScale.y) / topScale.y * 0.5f);
				break;
			}
		}

		public void AlignOffsetBottom(int faceIndex)
		{
			if (faceIndex < 0 || faceIndex >= _faceUnwrapData.Length)
			{
				Debug.LogError(string.Concat(base.name, ": ", GetType(), ".ApplyFaceScale: faceIndex out of range: ", faceIndex));
			}
			else
			{
				FaceData faceData = _faceUnwrapData[faceIndex];
				Rect faceBounds = GetFaceBounds(faceData);
				faceData.uvOffset = new Vector2(faceData.uvOffset.x, faceBounds.y / faceData.uvScale.y);
				CreateMeshAndUVs();
			}
		}

		public void AlignOffsetLeft(Direction side)
		{
			switch (side)
			{
			case Direction.Back:
				backOffset = new Vector2((base.transform.lossyScale.x - backScale.x) / backScale.x * 0.5f, backOffset.y);
				break;
			case Direction.Down:
				bottomOffset = new Vector2((1f - (base.transform.lossyScale.z - bottomScale.x) / bottomScale.x) * 0.5f, bottomOffset.y);
				break;
			case Direction.Forward:
				frontOffset = new Vector2((base.transform.lossyScale.x - frontScale.x) / frontScale.x * 0.5f, frontOffset.y);
				break;
			case Direction.Left:
				leftOffset = new Vector2((base.transform.lossyScale.z - leftScale.x) / leftScale.x * 0.5f, leftOffset.y);
				break;
			case Direction.Right:
				rightOffset = new Vector2((base.transform.lossyScale.z - rightScale.x) / rightScale.x * 0.5f, rightOffset.y);
				break;
			case Direction.Up:
				topOffset = new Vector2((1f - (base.transform.lossyScale.z - topScale.x) / topScale.x) * 0.5f, topOffset.y);
				break;
			}
		}

		public void AlignOffsetLeft(int faceIndex)
		{
			if (faceIndex < 0 || faceIndex >= _faceUnwrapData.Length)
			{
				Debug.LogError(string.Concat(base.name, ": ", GetType(), ".ApplyFaceScale: faceIndex out of range: ", faceIndex));
			}
			else
			{
				FaceData faceData = _faceUnwrapData[faceIndex];
				faceData.uvOffset = new Vector2(GetFaceBounds(faceData).xMax / faceData.uvScale.x, faceData.uvOffset.y);
				CreateMeshAndUVs();
			}
		}

		public void AlignOffsetRight(Direction side)
		{
			switch (side)
			{
			case Direction.Back:
				backOffset = new Vector2(1f - (base.transform.lossyScale.x - backScale.x) / backScale.x * 0.5f, backOffset.y);
				break;
			case Direction.Down:
				bottomOffset = new Vector2((base.transform.lossyScale.z - bottomScale.x) / bottomScale.x * 0.5f, bottomOffset.y);
				break;
			case Direction.Forward:
				frontOffset = new Vector2(1f - (base.transform.lossyScale.x - frontScale.x) / frontScale.x * 0.5f, frontOffset.y);
				break;
			case Direction.Left:
				leftOffset = new Vector2(1f - (base.transform.lossyScale.z - leftScale.x) / leftScale.x * 0.5f, leftOffset.y);
				break;
			case Direction.Right:
				rightOffset = new Vector2(1f - (base.transform.lossyScale.z - rightScale.x) / rightScale.x * 0.5f, rightOffset.y);
				break;
			case Direction.Up:
				topOffset = new Vector2((base.transform.lossyScale.z - topScale.x) / topScale.x * 0.5f, topOffset.y);
				break;
			}
		}

		public void AlignOffsetRight(int faceIndex)
		{
			if (faceIndex < 0 || faceIndex >= _faceUnwrapData.Length)
			{
				Debug.LogError(string.Concat(base.name, ": ", GetType(), ".ApplyFaceScale: faceIndex out of range: ", faceIndex));
			}
			else
			{
				FaceData faceData = _faceUnwrapData[faceIndex];
				faceData.uvOffset = new Vector2(GetFaceBounds(faceData).x / faceData.uvScale.x, faceData.uvOffset.y);
				CreateMeshAndUVs();
			}
		}

		public void SetTextureToFit(Direction side)
		{
			switch (side)
			{
			case Direction.Back:
				backOffset = Vector2.zero;
				backRotation = 0f;
				backScale = new Vector2(base.transform.lossyScale.x, base.transform.lossyScale.y);
				break;
			case Direction.Down:
				bottomOffset = Vector2.zero;
				bottomRotation = 0f;
				bottomScale = new Vector2(base.transform.lossyScale.z, base.transform.lossyScale.x);
				break;
			case Direction.Forward:
				frontOffset = Vector2.zero;
				frontRotation = 0f;
				frontScale = new Vector2(base.transform.lossyScale.x, base.transform.lossyScale.y);
				break;
			case Direction.Left:
				leftOffset = Vector2.zero;
				leftRotation = 0f;
				leftScale = new Vector2(base.transform.lossyScale.z, base.transform.lossyScale.y);
				break;
			case Direction.Right:
				rightOffset = Vector2.zero;
				rightRotation = 0f;
				rightScale = new Vector2(base.transform.lossyScale.z, base.transform.lossyScale.y);
				break;
			case Direction.Up:
				topOffset = Vector2.zero;
				topRotation = 0f;
				topScale = new Vector2(base.transform.lossyScale.z, base.transform.lossyScale.x);
				break;
			}
		}

		public void SetTextureToFit(int faceIndex)
		{
			if (faceIndex < 0 || faceIndex >= _faceUnwrapData.Length)
			{
				Debug.LogError(string.Concat(base.name, ": ", GetType(), ".SetTextureToFit: faceIndex out of range: ", faceIndex));
			}
			else
			{
				FaceData faceData = _faceUnwrapData[faceIndex];
				Rect faceBounds = GetFaceBounds(faceData);
				faceData.rotation = 0f;
				faceData.uvScale = new Vector2(faceBounds.width, faceBounds.height);
				faceData.uvOffset = new Vector2(faceBounds.center.x / faceData.uvScale.x, faceBounds.center.y / faceData.uvScale.y);
				CreateMeshAndUVs();
			}
		}

		public Rect GetFaceBounds(FaceData face)
		{
			if (face == null)
			{
				Debug.LogError(string.Concat(base.name, ": ", GetType(), ".GetFaceBounds: face was null."));
			}
			float num = float.PositiveInfinity;
			float num2 = float.NegativeInfinity;
			float num3 = float.PositiveInfinity;
			float num4 = float.NegativeInfinity;
			Quaternion quaternion = Quaternion.FromToRotation(Vector3.Scale(face.AverageNormal, base.transform.lossyScale), Vector3.up);
			for (int i = 0; i < face.Triangles.Length; i++)
			{
				Vector3 vector = meshFilter.sharedMesh.vertices[face.Triangles[i]];
				Vector3 vector2 = quaternion * new Vector3(vector.x * base.transform.lossyScale.x, vector.y * base.transform.lossyScale.y, vector.z * base.transform.lossyScale.z);
				if (vector2.x < num3)
				{
					num3 = vector2.x;
				}
				else if (vector2.x > num4)
				{
					num4 = vector2.x;
				}
				if (vector2.z < num)
				{
					num = vector2.z;
				}
				else if (vector2.z > num2)
				{
					num2 = vector2.z;
				}
			}
			return new Rect(num3, num, num4 - num3, num2 - num);
		}

		public void ApplyFlipUVX(int faceIndex, bool newFlipX)
		{
			if (faceIndex < 0 || faceIndex >= _faceUnwrapData.Length)
			{
				Debug.LogError(string.Concat(base.name, ": ", GetType(), ".ApplyFaceScale: faceIndex out of range: ", faceIndex));
			}
			else
			{
				_faceUnwrapData[faceIndex].flipUVx = newFlipX;
				CreateMeshAndUVs();
			}
		}

		public void ApplyFlipUVY(int faceIndex, bool newFlipY)
		{
			if (faceIndex < 0 || faceIndex >= _faceUnwrapData.Length)
			{
				Debug.LogError(string.Concat(base.name, ": ", GetType(), ".ApplyFaceScale: faceIndex out of range: ", faceIndex));
			}
			else
			{
				_faceUnwrapData[faceIndex].flipUVy = newFlipY;
				CreateMeshAndUVs();
			}
		}

		public void ApplyFaceMaterial(int faceIndex, int faceMaterialIndex)
		{
			if (faceIndex < 0 || faceIndex >= _faceUnwrapData.Length)
			{
				Debug.LogError(string.Concat(base.name, ": ", GetType(), ".ApplyFaceScale: faceIndex out of range: ", faceIndex));
			}
			else
			{
				_faceUnwrapData[faceIndex].materialIndex = faceMaterialIndex;
				CreateMeshAndUVs();
			}
		}

		public void ApplyFaceOffset(int faceIndex, Vector2 offset)
		{
			if (faceIndex < 0 || faceIndex >= _faceUnwrapData.Length)
			{
				Debug.LogError(string.Concat(base.name, ": ", GetType(), ".ApplyFaceScale: faceIndex out of range: ", faceIndex));
			}
			else
			{
				_faceUnwrapData[(!useUnifiedOffset) ? faceIndex : 0].uvOffset = offset;
				CreateMeshAndUVs();
			}
		}

		public void ApplyFaceRotation(int faceIndex, float rotation)
		{
			if (faceIndex < 0 || faceIndex >= _faceUnwrapData.Length)
			{
				Debug.LogError(string.Concat(base.name, ": ", GetType(), ".ApplyFaceScale: faceIndex out of range: ", faceIndex));
			}
			else
			{
				_faceUnwrapData[faceIndex].rotation = rotation;
				CreateMeshAndUVs();
			}
		}

		public void ApplyFaceScale(int faceIndex, Vector2 scale)
		{
			if (faceIndex < 0 || faceIndex >= _faceUnwrapData.Length)
			{
				Debug.LogError(string.Concat(base.name, ": ", GetType(), ".ApplyFaceScale: faceIndex out of range: ", faceIndex));
			}
			else
			{
				_faceUnwrapData[(!useUnifiedScaling) ? faceIndex : 0].uvScale = scale;
				CreateMeshAndUVs();
			}
		}

		public void CreateMeshAndUVs()
		{
			if (meshFilter == null)
			{
				Debug.LogError(string.Concat(GetType(), ".CreateMeshAndUVs: meshFilter was not set, there is no MeshFilter component attached."));
				return;
			}
			MeshData meshData = new MeshData();
			Mesh mesh = meshFilter.mesh;
			if (mesh == null)
			{
				Debug.LogWarning(string.Concat(GetType(), ".CreateMeshAndUVs: mesh was null. Automatically created a new one. Was this intended?"));
				mesh = new Mesh();
			}
			if (mesh.vertices.Length < 1)
			{
				meshData = CreateStandardCubeMesh();
				mesh.subMeshCount = meshData.subMeshCount;
				mesh.vertices = meshData.Vertices.ToArray();
				for (int i = 0; i < meshData.subMeshCount; i++)
				{
					mesh.SetTriangles(meshData.Triangles[i].ToArray(), i);
				}
				mesh.uv = meshData.UV.ToArray();
				mesh.RecalculateBounds();
				mesh.RecalculateNormals();
			}
			else
			{
				Vector3[] vertices = mesh.vertices;
				Vector3[] normals = mesh.normals;
				if (vertices.Length < 3)
				{
					Debug.LogError(string.Concat(base.name, ": ", GetType(), ".CreateMeshAndUVs: there was something wrong with the mesh, not enough vertices: ", vertices.Length, "."));
					return;
				}
				meshData.SetVertices(vertices);
				if (normals.Length != vertices.Length)
				{
					Debug.LogError(string.Concat(base.name, ": ", GetType(), ".CreateMeshAndUVs: there was something wrong with the mesh, there were ", normals.Length, " normals, but ", vertices.Length, " vertices. They need to have the same count."));
					return;
				}
				meshData.SetNormals(normals);
				meshData.SetTriangles(mesh);
				meshData.SetTangents(mesh.tangents);
				meshData.SetUV2Coordinates(mesh.uv2);
				switch (_unwrapMethod)
				{
				case UnwrapType.CubeProjection:
					meshData = SplitMeshForCubeProjection(meshData);
					break;
				case UnwrapType.FaceDependent:
					meshData = SplitMeshForFaceUnwrapping(meshData);
					break;
				default:
					meshData = SplitMeshForFaceUnwrapping(meshData);
					break;
				}
				mesh.subMeshCount = meshData.subMeshCount;
				if (meshData.Vertices.Count < mesh.vertices.Length)
				{
					for (int j = 0; j < meshData.subMeshCount; j++)
					{
						if (meshData.Triangles[j].Count > 0 && meshData.Triangles[j].Count % 3 != 0)
						{
							Debug.LogError(string.Concat(base.name, ": ", GetType(), ".CreateMeshAndUVs: there was something wrong with the mesh, triangles not divisible by 3. Triangles Count for material index ", j, ": ", meshData.Triangles[j].Count));
							return;
						}
						mesh.SetTriangles(meshData.Triangles[j].ToArray(), j);
					}
					mesh.vertices = meshData.Vertices.ToArray();
				}
				else
				{
					mesh.vertices = meshData.Vertices.ToArray();
					for (int k = 0; k < meshData.subMeshCount; k++)
					{
						if (meshData.Triangles[k] == null)
						{
							Debug.LogError(string.Concat(base.name, ": ", GetType(), ".CreateMeshAndUVs: there was something wrong with the mesh, triangles at ", k, " were null."));
						}
						else if (meshData.Triangles[k].Count > 0 && meshData.Triangles[k].Count % 3 != 0)
						{
							Debug.LogError(string.Concat(base.name, ": ", GetType(), ".CreateMeshAndUVs: there was something wrong with the mesh, triangles not divisible by 3. Triangles Count for material index ", k, ": ", meshData.Triangles[k].Count));
						}
						else
						{
							mesh.SetTriangles(meshData.Triangles[k].ToArray(), k);
						}
					}
				}
				mesh.normals = meshData.Normals.ToArray();
				mesh.tangents = meshData.Tangents.ToArray();
				mesh.uv = meshData.UV.ToArray();
				mesh.uv2 = meshData.UV2.ToArray();
			}
			mesh.name = "Mesh " + base.name;
			meshFilter.mesh = mesh;
			if (freshMesh)
			{
				freshMesh = false;
			}
		}

		private MeshData CreateStandardCubeMesh()
		{
			MeshData meshData = new MeshData();
			meshData.AddVertex(new Vector3(-0.5f, 0.5f, 0.5f));
			meshData.AddVertex(new Vector3(0.5f, 0.5f, 0.5f));
			meshData.AddVertex(new Vector3(0.5f, 0.5f, -0.5f));
			meshData.AddVertex(new Vector3(-0.5f, 0.5f, -0.5f));
			meshData.AddQuadTriangles();
			meshData.AddUVCoordinates(QuadFaceUVs(Direction.Up));
			meshData.AddVertex(new Vector3(-0.5f, -0.5f, -0.5f));
			meshData.AddVertex(new Vector3(0.5f, -0.5f, -0.5f));
			meshData.AddVertex(new Vector3(0.5f, -0.5f, 0.5f));
			meshData.AddVertex(new Vector3(-0.5f, -0.5f, 0.5f));
			meshData.AddQuadTriangles();
			meshData.AddUVCoordinates(QuadFaceUVs(Direction.Down));
			meshData.AddVertex(new Vector3(0.5f, -0.5f, 0.5f));
			meshData.AddVertex(new Vector3(0.5f, 0.5f, 0.5f));
			meshData.AddVertex(new Vector3(-0.5f, 0.5f, 0.5f));
			meshData.AddVertex(new Vector3(-0.5f, -0.5f, 0.5f));
			meshData.AddQuadTriangles();
			meshData.AddUVCoordinates(QuadFaceUVs(Direction.Forward));
			meshData.AddVertex(new Vector3(-0.5f, -0.5f, -0.5f));
			meshData.AddVertex(new Vector3(-0.5f, 0.5f, -0.5f));
			meshData.AddVertex(new Vector3(0.5f, 0.5f, -0.5f));
			meshData.AddVertex(new Vector3(0.5f, -0.5f, -0.5f));
			meshData.AddQuadTriangles();
			meshData.AddUVCoordinates(QuadFaceUVs(Direction.Back));
			meshData.AddVertex(new Vector3(-0.5f, -0.5f, 0.5f));
			meshData.AddVertex(new Vector3(-0.5f, 0.5f, 0.5f));
			meshData.AddVertex(new Vector3(-0.5f, 0.5f, -0.5f));
			meshData.AddVertex(new Vector3(-0.5f, -0.5f, -0.5f));
			meshData.AddQuadTriangles();
			meshData.AddUVCoordinates(QuadFaceUVs(Direction.Left));
			meshData.AddVertex(new Vector3(0.5f, -0.5f, -0.5f));
			meshData.AddVertex(new Vector3(0.5f, 0.5f, -0.5f));
			meshData.AddVertex(new Vector3(0.5f, 0.5f, 0.5f));
			meshData.AddVertex(new Vector3(0.5f, -0.5f, 0.5f));
			meshData.AddQuadTriangles();
			meshData.AddUVCoordinates(QuadFaceUVs(Direction.Right));
			return meshData;
		}

		private Vector2[] QuadFaceUVs(Direction dir)
		{
			Vector2[] array = new Vector2[4];
			float num = 1f;
			float num2 = 1f;
			switch (dir)
			{
			case Direction.Up:
				num = base.transform.lossyScale.z / topScale.x;
				num2 = base.transform.lossyScale.x / topScale.y;
				array[0] = new Vector2(num + topOffset.x, 0f + topOffset.y);
				array[1] = new Vector2(num + topOffset.x, num2 + topOffset.y);
				array[2] = new Vector2(0f + topOffset.x, num2 + topOffset.y);
				array[3] = new Vector2(0f + topOffset.x, 0f + topOffset.y);
				break;
			case Direction.Down:
				num = base.transform.lossyScale.z / (useUnifiedScaling ? topScale.x : bottomScale.x);
				num2 = base.transform.lossyScale.x / (useUnifiedScaling ? topScale.y : bottomScale.y);
				array[0] = new Vector2(num + (useUnifiedOffset ? topOffset.x : bottomOffset.x), 0f + (useUnifiedOffset ? topOffset.y : bottomOffset.y));
				array[1] = new Vector2(num + (useUnifiedOffset ? topOffset.x : bottomOffset.x), num2 + (useUnifiedOffset ? topOffset.y : bottomOffset.y));
				array[2] = new Vector2(0f + (useUnifiedOffset ? topOffset.x : bottomOffset.x), num2 + (useUnifiedOffset ? topOffset.y : bottomOffset.y));
				array[3] = new Vector2(0f + (useUnifiedOffset ? topOffset.x : bottomOffset.x), 0f + (useUnifiedOffset ? topOffset.y : bottomOffset.y));
				break;
			case Direction.Left:
				num = base.transform.lossyScale.z / (useUnifiedScaling ? topScale.x : leftScale.x);
				num2 = base.transform.lossyScale.y / (useUnifiedScaling ? topScale.y : leftScale.y);
				array[0] = new Vector2(num + (useUnifiedOffset ? topOffset.x : leftOffset.x), 0f + (useUnifiedOffset ? topOffset.y : leftOffset.y));
				array[1] = new Vector2(num + (useUnifiedOffset ? topOffset.x : leftOffset.x), num2 + (useUnifiedOffset ? topOffset.y : leftOffset.y));
				array[2] = new Vector2(0f + (useUnifiedOffset ? topOffset.x : leftOffset.x), num2 + (useUnifiedOffset ? topOffset.y : leftOffset.y));
				array[3] = new Vector2(0f + (useUnifiedOffset ? topOffset.x : leftOffset.x), 0f + (useUnifiedOffset ? topOffset.y : leftOffset.y));
				break;
			case Direction.Right:
				num = base.transform.lossyScale.z / (useUnifiedScaling ? topScale.x : rightScale.x);
				num2 = base.transform.lossyScale.y / (useUnifiedScaling ? topScale.y : rightScale.y);
				array[0] = new Vector2(num + (useUnifiedOffset ? topOffset.x : rightOffset.x), 0f + (useUnifiedOffset ? topOffset.y : rightOffset.y));
				array[1] = new Vector2(num + (useUnifiedOffset ? topOffset.x : rightOffset.x), num2 + (useUnifiedOffset ? topOffset.y : rightOffset.y));
				array[2] = new Vector2(0f + (useUnifiedOffset ? topOffset.x : rightOffset.x), num2 + (useUnifiedOffset ? topOffset.y : rightOffset.y));
				array[3] = new Vector2(0f + (useUnifiedOffset ? topOffset.x : rightOffset.x), 0f + (useUnifiedOffset ? topOffset.y : rightOffset.y));
				break;
			case Direction.Forward:
				num = base.transform.lossyScale.x / (useUnifiedScaling ? topScale.x : frontScale.x);
				num2 = base.transform.lossyScale.y / (useUnifiedScaling ? topScale.y : frontScale.y);
				array[0] = new Vector2(num + (useUnifiedOffset ? topOffset.x : frontOffset.x), 0f + (useUnifiedOffset ? topOffset.y : frontOffset.y));
				array[1] = new Vector2(num + (useUnifiedOffset ? topOffset.x : frontOffset.x), num2 + (useUnifiedOffset ? topOffset.y : frontOffset.y));
				array[2] = new Vector2(0f + (useUnifiedOffset ? topOffset.x : frontOffset.x), num2 + (useUnifiedOffset ? topOffset.y : frontOffset.y));
				array[3] = new Vector2(0f + (useUnifiedOffset ? topOffset.x : frontOffset.x), 0f + (useUnifiedOffset ? topOffset.y : frontOffset.y));
				break;
			case Direction.Back:
				num = base.transform.lossyScale.x / (useUnifiedScaling ? topScale.x : backScale.x);
				num2 = base.transform.lossyScale.y / (useUnifiedScaling ? topScale.y : backScale.y);
				array[0] = new Vector2(num + (useUnifiedOffset ? topOffset.x : backOffset.x), 0f + (useUnifiedOffset ? topOffset.y : backOffset.y));
				array[1] = new Vector2(num + (useUnifiedOffset ? topOffset.x : backOffset.x), num2 + (useUnifiedOffset ? topOffset.y : backOffset.y));
				array[2] = new Vector2(0f + (useUnifiedOffset ? topOffset.x : backOffset.x), num2 + (useUnifiedOffset ? topOffset.y : backOffset.y));
				array[3] = new Vector2(0f + (useUnifiedOffset ? topOffset.x : backOffset.x), 0f + (useUnifiedOffset ? topOffset.y : backOffset.y));
				break;
			}
			return array;
		}

		private MeshData SplitMeshForCubeProjection(MeshData data)
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			List<int> list4 = new List<int>();
			List<int> list5 = new List<int>();
			List<int> list6 = new List<int>();
			for (int i = 0; i < data.Triangles.Length; i++)
			{
				for (int j = 0; j < data.Triangles[i].Count; j += 3)
				{
					Vector3 vector = default(Vector3);
					List<int> list7 = new List<int>();
					for (int k = 0; k < 3; k++)
					{
						int num = data.Triangles[i][j + k];
						vector += data.Normals[num];
						list7.Add(num);
					}
					switch (GetCubeProjectionDirectionForNormal(vector.normalized))
					{
					case Direction.Back:
						list6.AddRange(list7);
						break;
					case Direction.Down:
						list2.AddRange(list7);
						break;
					case Direction.Forward:
						list5.AddRange(list7);
						break;
					case Direction.Left:
						list3.AddRange(list7);
						break;
					case Direction.Right:
						list4.AddRange(list7);
						break;
					case Direction.Up:
						list.AddRange(list7);
						break;
					}
				}
			}
			MeshData meshData = new MeshData();
			if (freshMesh)
			{
				HashSet<Vector3> hashSet = new HashSet<Vector3>();
				for (int l = 0; l < list6.Count; l++)
				{
					hashSet.Add(data.Vertices[list6[l]]);
				}
				HashSet<Vector3> hashSet2 = new HashSet<Vector3>();
				for (int m = 0; m < list2.Count; m++)
				{
					hashSet2.Add(data.Vertices[list2[m]]);
				}
				HashSet<Vector3> hashSet3 = new HashSet<Vector3>();
				for (int n = 0; n < list5.Count; n++)
				{
					hashSet3.Add(data.Vertices[list5[n]]);
				}
				HashSet<Vector3> hashSet4 = new HashSet<Vector3>();
				for (int num2 = 0; num2 < list3.Count; num2++)
				{
					hashSet4.Add(data.Vertices[list3[num2]]);
				}
				HashSet<Vector3> hashSet5 = new HashSet<Vector3>();
				for (int num3 = 0; num3 < list4.Count; num3++)
				{
					hashSet5.Add(data.Vertices[list4[num3]]);
				}
				HashSet<Vector3> hashSet6 = new HashSet<Vector3>();
				for (int num4 = 0; num4 < list.Count; num4++)
				{
					hashSet6.Add(data.Vertices[list[num4]]);
				}
				for (int num5 = 0; num5 < data.subMeshCount; num5++)
				{
					HashSet<Vector3> hashSet7 = new HashSet<Vector3>();
					for (int num6 = 0; num6 < data.Triangles[num5].Count; num6++)
					{
						hashSet7.Add(data.Vertices[data.Triangles[num5][num6]]);
					}
					if (hashSet.IsSubsetOf(hashSet7))
					{
						_backMaterialIndex = num5;
					}
					if (hashSet2.IsSubsetOf(hashSet7))
					{
						_bottomMaterialIndex = num5;
					}
					if (hashSet3.IsSubsetOf(hashSet7))
					{
						_frontMaterialIndex = num5;
					}
					if (hashSet4.IsSubsetOf(hashSet7))
					{
						_leftMaterialIndex = num5;
					}
					if (hashSet5.IsSubsetOf(hashSet7))
					{
						_rightMaterialIndex = num5;
					}
					if (hashSet6.IsSubsetOf(hashSet7))
					{
						_topMaterialIndex = num5;
					}
				}
				freshMesh = false;
			}
			meshData.subMeshCount = Mathf.Max(_backMaterialIndex, _bottomMaterialIndex, _frontMaterialIndex, _leftMaterialIndex, _rightMaterialIndex, _topMaterialIndex) + 1;
			meshData = AddMeshDataForTriangleList(list6, Vector3.back, meshData, data, _backMaterialIndex);
			meshData = AddMeshDataForTriangleList(list2, Vector3.down, meshData, data, _bottomMaterialIndex);
			meshData = AddMeshDataForTriangleList(list5, Vector3.forward, meshData, data, _frontMaterialIndex);
			meshData = AddMeshDataForTriangleList(list3, Vector3.left, meshData, data, _leftMaterialIndex);
			meshData = AddMeshDataForTriangleList(list4, Vector3.right, meshData, data, _rightMaterialIndex);
			return AddMeshDataForTriangleList(list, Vector3.up, meshData, data, _topMaterialIndex);
		}

		protected virtual MeshData SplitMeshForFaceUnwrapping(MeshData meshData)
		{
			MeshData meshData2 = meshData.Copy();
			meshData.RemoveDoubles(base.gameObject.isStatic);
			List<FaceData> list = new List<FaceData>();
			for (int i = 0; i < meshData.Triangles.Length; i++)
			{
				for (int j = 0; j < meshData.Triangles[i].Count; j += 3)
				{
					bool flag = false;
					int[] array = new int[3];
					Vector3 zero = Vector3.zero;
					for (int k = 0; k < 3; k++)
					{
						array[k] = meshData.Triangles[i][j + k];
						zero += meshData.Normals[array[k]];
					}
					zero /= 3f;
					zero = new Vector3(zero.x / base.transform.lossyScale.x, zero.y / base.transform.lossyScale.y, zero.z / base.transform.lossyScale.z).normalized;
					for (int l = 0; l < list.Count; l++)
					{
						if (zero != Vector3.zero && list[l].IsWithinNormalAngleRange(zero, faceUnwrappingNormalTolerance))
						{
							list[l].AddTriangle(array, zero);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						FaceData faceData = new FaceData();
						faceData.AddTriangle(array, zero);
						list.Add(faceData);
					}
				}
			}
			List<FaceData> list2 = new List<FaceData>();
			for (int m = 0; m < list.Count; m++)
			{
				List<int> list3 = new List<int>(list[m].Triangles);
				List<List<int>> list4 = new List<List<int>>();
				int num = 0;
				int num2 = 0;
				list4.Add(new List<int>());
				while (list3.Count > 0)
				{
					if (list4[num2].Count < 1 || list4[num2].Contains(list3[num]) || list4[num2].Contains(list3[num + 1]) || list4[num2].Contains(list3[num + 2]))
					{
						list4[num2].Add(list3[num]);
						list4[num2].Add(list3[num + 1]);
						list4[num2].Add(list3[num + 2]);
						list3.RemoveRange(num, 3);
						num = 0;
					}
					else
					{
						num += 3;
					}
					if (list3.Count > 0 && num >= list3.Count)
					{
						num = 0;
						list4.Add(new List<int>());
						num2++;
					}
				}
				for (int n = 0; n < list4.Count; n++)
				{
					if (list4[n].Count < 1)
					{
						continue;
					}
					FaceData faceData2 = new FaceData();
					faceData2.CopySettingsFrom(list[m]);
					for (int num3 = 0; num3 < list4[n].Count; num3 += 3)
					{
						int[] array2 = new int[3]
						{
							list4[n][num3],
							list4[n][num3 + 1],
							list4[n][num3 + 2]
						};
						Vector3 zero2 = Vector3.zero;
						for (int num4 = 0; num4 < 3; num4++)
						{
							zero2 += meshData.Normals[array2[num4]];
						}
						zero2 /= 3f;
						faceData2.AddTriangle(array2, zero2);
					}
					list2.Add(faceData2);
				}
			}
			list = list2;
			MeshData meshData3 = new MeshData();
			meshData3.subMeshCount = 1;
			for (int num5 = 0; num5 < list.Count; num5++)
			{
				FaceData updatedFaceData = list[num5];
				meshData3.subMeshCount = Mathf.Max(meshData3.subMeshCount, list[num5].materialIndex + 1);
				meshData3 = AddMeshDataForFaceData(list[num5], meshData3, meshData, out updatedFaceData);
				list[num5] = updatedFaceData;
			}
			FaceData[] array3 = new FaceData[list.Count];
			List<FaceData> list5 = new List<FaceData>();
			for (int num6 = 0; num6 < list.Count; num6++)
			{
				if (_faceUnwrapData != null)
				{
					for (int num7 = 0; num7 < _faceUnwrapData.Length; num7++)
					{
						bool flag2 = true;
						if (_faceUnwrapData[num7] == null)
						{
							_faceUnwrapData[num7] = new FaceData();
							flag2 = false;
						}
						else
						{
							bool flag3 = false;
							if (_faceUnwrapData[num7].Initialized && _faceUnwrapData[num7].Triangles != null && _faceUnwrapData[num7].Triangles.Length == list[num6].Triangles.Length)
							{
								flag3 = true;
								List<Vector3> list6 = new List<Vector3>();
								for (int num8 = 0; num8 < _faceUnwrapData[num7].Triangles.Length; num8++)
								{
									if (_faceUnwrapData[num7].Triangles[num8] < meshData3.Vertices.Count)
									{
										list6.Add(meshData3.Vertices[_faceUnwrapData[num7].Triangles[num8]]);
									}
								}
								for (int num9 = 0; num9 < list[num6].Triangles.Length; num9++)
								{
									if (!list6.Contains(meshData3.Vertices[list[num6].Triangles[num9]]))
									{
										flag2 = false;
										break;
									}
								}
							}
							if (!flag3)
							{
								flag2 = false;
							}
						}
						if (flag2)
						{
							list[num6].Initialize(_faceUnwrapData[num7]);
							if (num7 < array3.Length)
							{
								array3[num7] = list[num6];
							}
							else
							{
								list5.Add(list[num6]);
							}
							break;
						}
					}
				}
				if (!list[num6].Initialized)
				{
					switch (GetCubeProjectionDirectionForNormal(list[num6].AverageNormal.normalized))
					{
					case Direction.Back:
						list[num6].flipUVx = backFlipX;
						list[num6].flipUVy = backFlipY;
						list[num6].materialIndex = backMaterialIndex;
						list[num6].rotation = backRotation;
						list[num6].uvOffset = backOffset;
						list[num6].uvScale = backScale;
						break;
					case Direction.Down:
						list[num6].flipUVx = bottomFlipX;
						list[num6].flipUVy = bottomFlipY;
						list[num6].materialIndex = bottomMaterialIndex;
						list[num6].rotation = bottomRotation;
						list[num6].uvOffset = bottomOffset;
						list[num6].uvScale = bottomScale;
						break;
					case Direction.Forward:
						list[num6].flipUVx = frontFlipX;
						list[num6].flipUVy = frontFlipY;
						list[num6].materialIndex = frontMaterialIndex;
						list[num6].rotation = frontRotation;
						list[num6].uvOffset = frontOffset;
						list[num6].uvScale = frontScale;
						break;
					case Direction.Left:
						list[num6].flipUVx = leftFlipX;
						list[num6].flipUVy = leftFlipY;
						list[num6].materialIndex = leftMaterialIndex;
						list[num6].rotation = leftRotation;
						list[num6].uvOffset = leftOffset;
						list[num6].uvScale = leftScale;
						break;
					case Direction.Right:
						list[num6].flipUVx = rightFlipX;
						list[num6].flipUVy = rightFlipY;
						list[num6].materialIndex = rightMaterialIndex;
						list[num6].rotation = rightRotation;
						list[num6].uvOffset = rightOffset;
						list[num6].uvScale = rightScale;
						break;
					case Direction.Up:
						list[num6].flipUVx = topFlipX;
						list[num6].flipUVy = topFlipY;
						list[num6].materialIndex = topMaterialIndex;
						list[num6].rotation = topRotation;
						list[num6].uvOffset = topOffset;
						list[num6].uvScale = topScale;
						break;
					}
					list[num6].Initialize();
					list5.Add(list[num6]);
				}
			}
			while (list5.Count > 0)
			{
				for (int num10 = 0; num10 < array3.Length; num10++)
				{
					if (array3[num10] == null)
					{
						array3[num10] = list5[0];
						list5.RemoveAt(0);
						break;
					}
				}
			}
			if (_faceUnwrapData != null)
			{
				list = new List<FaceData>(array3);
			}
			if (freshMesh)
			{
				for (int num11 = 0; num11 < meshData2.subMeshCount; num11++)
				{
					HashSet<Vector3> hashSet = new HashSet<Vector3>();
					for (int num12 = 0; num12 < meshData2.Triangles[num11].Count; num12++)
					{
						hashSet.Add(meshData2.Vertices[meshData2.Triangles[num11][num12]]);
					}
					for (int num13 = 0; num13 < list.Count; num13++)
					{
						HashSet<Vector3> hashSet2 = new HashSet<Vector3>();
						for (int num14 = 0; num14 < list[num13].Triangles.Length; num14++)
						{
							hashSet2.Add(meshData3.Vertices[list[num13].Triangles[num14]]);
						}
						if (hashSet2.IsSubsetOf(hashSet))
						{
							list[num13].materialIndex = num11;
						}
					}
				}
				freshMesh = false;
			}
			MeshData meshData4 = new MeshData();
			meshData4.subMeshCount = 1;
			for (int num15 = 0; num15 < list.Count; num15++)
			{
				FaceData updatedFaceData2 = new FaceData();
				if (list[num15] == null)
				{
					list[num15] = new FaceData();
					list[num15].Initialize();
				}
				meshData4.subMeshCount = Mathf.Max(meshData4.subMeshCount, list[num15].materialIndex + 1);
				meshData4 = AddMeshDataForFaceData(list[num15], meshData4, meshData3, out updatedFaceData2);
			}
			meshData3 = meshData4;
			_faceUnwrapData = list.ToArray();
			return meshData3;
		}

		private void LogFaceDataVertices(FaceData faceData, MeshData meshData)
		{
			string text = "";
			if (faceData == null)
			{
				text += "(ERROR: faceData was null)";
			}
			else if (faceData.Triangles == null)
			{
				text = "(ERROR: faceData triangles were null)";
			}
			else
			{
				for (int i = 0; i < faceData.Triangles.Length; i++)
				{
					int num = faceData.Triangles[i];
					text = ((num >= meshData.Vertices.Count) ? (text + "(ERROR:" + num + " out of bound)") : (text + meshData.Vertices[num].ToString()));
				}
			}
			Debug.Log(text);
		}

		private MeshData AddMeshDataForTriangleList(List<int> triangleIds, Vector3 normalDirection, MeshData newData, MeshData oldData, int materialIndex)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (int triangleId in triangleIds)
			{
				if (!dictionary.ContainsKey(triangleId))
				{
					dictionary[triangleId] = newData.Vertices.Count;
					newData.AddTriangle(newData.Vertices.Count, materialIndex);
					newData.AddVertex(oldData.Vertices[triangleId]);
					if (triangleId < oldData.Tangents.Count)
					{
						newData.AddTangent(oldData.Tangents[triangleId]);
					}
					newData.AddNormal(oldData.Normals[triangleId]);
					newData.AddUVCoordinate(VerticeUVByNormal(oldData.Vertices[triangleId], normalDirection));
					if (triangleId < oldData.UV2.Count)
					{
						newData.AddUV2Coordinate(oldData.UV2[triangleId]);
					}
				}
				else
				{
					newData.AddTriangle(dictionary[triangleId], materialIndex);
				}
			}
			return newData;
		}

		protected MeshData AddMeshDataForFaceData(FaceData faceData, MeshData newData, MeshData oldData, out FaceData updatedFaceData)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			List<int> list = new List<int>();
			int[] triangles = faceData.Triangles;
			foreach (int num in triangles)
			{
				if (!dictionary.ContainsKey(num))
				{
					dictionary[num] = newData.Vertices.Count;
					newData.AddTriangle(newData.Vertices.Count, faceData.materialIndex);
					list.Add(newData.Vertices.Count);
					newData.AddVertex(oldData.Vertices[num]);
					if (num < oldData.Tangents.Count)
					{
						newData.AddTangent(oldData.Tangents[num]);
					}
					newData.AddNormal(oldData.Normals[num]);
					newData.AddUVCoordinate(VerticeUVByFace(oldData.Vertices[num], faceData));
					if (num < oldData.UV2.Count)
					{
						newData.AddUV2Coordinate(oldData.UV2[num]);
					}
				}
				else
				{
					int num2 = dictionary[num];
					newData.AddTriangle(num2, faceData.materialIndex);
					list.Add(num2);
				}
			}
			faceData.SetTriangles(list.ToArray());
			updatedFaceData = faceData;
			return newData;
		}

		public static Direction GetCubeProjectionDirectionForNormal(Vector3 normal)
		{
			Direction result = Direction.Up;
			float num = Vector3.Angle(normal, Vector3.up);
			float num2 = Vector3.Angle(normal, Vector3.down);
			if (num2 < num)
			{
				num = num2;
				result = Direction.Down;
			}
			num2 = Vector3.Angle(normal, Vector3.left);
			if (num2 < num)
			{
				num = num2;
				result = Direction.Left;
			}
			num2 = Vector3.Angle(normal, Vector3.right);
			if (num2 < num)
			{
				num = num2;
				result = Direction.Right;
			}
			num2 = Vector3.Angle(normal, Vector3.forward);
			if (num2 < num)
			{
				num = num2;
				result = Direction.Forward;
			}
			num2 = Vector3.Angle(normal, Vector3.back);
			if (num2 < num)
			{
				num = num2;
				result = Direction.Back;
			}
			return result;
		}

		private Vector2 VerticeUVByNormal(Vector3 vertex, Vector3 normal)
		{
			Direction cubeProjectionDirectionForNormal = GetCubeProjectionDirectionForNormal(normal);
			Vector2 result = new Vector2(1f, 1f);
			switch (cubeProjectionDirectionForNormal)
			{
			case Direction.Up:
				result = Quaternion.Euler(0f, 0f, topRotation) * new Vector2(base.transform.lossyScale.z * vertex.z, base.transform.lossyScale.x * vertex.x);
				result.x = result.x / topScale.x + topOffset.x;
				result.y = result.y / topScale.y + topOffset.y;
				if (topFlipX)
				{
					result.x = 1f - result.x;
				}
				if (topFlipY)
				{
					result.y = 1f - result.y;
				}
				break;
			case Direction.Down:
				result = Quaternion.Euler(0f, 0f, bottomRotation) * new Vector2(base.transform.lossyScale.z * vertex.z, base.transform.lossyScale.x * vertex.x);
				result.x = result.x / (useUnifiedScaling ? topScale.x : bottomScale.x) + (useUnifiedOffset ? topOffset.x : bottomOffset.x);
				result.y = result.y / (useUnifiedScaling ? topScale.y : bottomScale.y) + (useUnifiedOffset ? topOffset.y : bottomOffset.y);
				if (bottomFlipX)
				{
					result.x = 1f - result.x;
				}
				if (bottomFlipY)
				{
					result.y = 1f - result.y;
				}
				break;
			case Direction.Left:
				result = Quaternion.Euler(0f, 0f, leftRotation) * new Vector2(base.transform.lossyScale.z * vertex.z, base.transform.lossyScale.y * vertex.y);
				result.x = result.x / (useUnifiedScaling ? topScale.x : leftScale.x) + (useUnifiedOffset ? topOffset.x : leftOffset.x);
				result.y = result.y / (useUnifiedScaling ? topScale.y : leftScale.y) + (useUnifiedOffset ? topOffset.y : leftOffset.y);
				if (leftFlipX)
				{
					result.x = 1f - result.x;
				}
				if (leftFlipY)
				{
					result.y = 1f - result.y;
				}
				break;
			case Direction.Right:
				result = Quaternion.Euler(0f, 0f, rightRotation) * new Vector2(base.transform.lossyScale.z * vertex.z, base.transform.lossyScale.y * vertex.y);
				result.x = result.x / (useUnifiedScaling ? topScale.x : rightScale.x) + (useUnifiedOffset ? topOffset.x : rightOffset.x);
				result.y = result.y / (useUnifiedScaling ? topScale.y : rightScale.y) + (useUnifiedOffset ? topOffset.y : rightOffset.y);
				if (rightFlipX)
				{
					result.x = 1f - result.x;
				}
				if (rightFlipY)
				{
					result.y = 1f - result.y;
				}
				break;
			case Direction.Forward:
				result = Quaternion.Euler(0f, 0f, frontRotation) * new Vector2(base.transform.lossyScale.x * vertex.x, base.transform.lossyScale.y * vertex.y);
				result.x = result.x / (useUnifiedScaling ? topScale.x : frontScale.x) + (useUnifiedOffset ? topOffset.x : frontOffset.x);
				result.y = result.y / (useUnifiedScaling ? topScale.y : frontScale.y) + (useUnifiedOffset ? topOffset.y : frontOffset.y);
				if (frontFlipX)
				{
					result.x = 1f - result.x;
				}
				if (frontFlipY)
				{
					result.y = 1f - result.y;
				}
				break;
			case Direction.Back:
				result = Quaternion.Euler(0f, 0f, backRotation) * new Vector2(base.transform.lossyScale.x * vertex.x, base.transform.lossyScale.y * vertex.y);
				result.x = result.x / (useUnifiedScaling ? topScale.x : backScale.x) + (useUnifiedOffset ? topOffset.x : backOffset.x);
				result.y = result.y / (useUnifiedScaling ? topScale.y : backScale.y) + (useUnifiedOffset ? topOffset.y : backOffset.y);
				if (backFlipX)
				{
					result.x = 1f - result.x;
				}
				if (backFlipY)
				{
					result.y = 1f - result.y;
				}
				break;
			}
			return result;
		}

		private Vector2 VerticeUVByFace(Vector3 vertex, FaceData faceData)
		{
			Vector3 vector = Quaternion.FromToRotation(Vector3.Scale(faceData.AverageNormal, base.transform.lossyScale), Vector3.up) * new Vector3(vertex.x * base.transform.lossyScale.x, vertex.y * base.transform.lossyScale.y, vertex.z * base.transform.lossyScale.z);
			Vector2 result = Quaternion.Euler(0f, 0f, faceData.rotation) * new Vector2(vector.x, vector.z);
			result.x = result.x / ((useUnifiedScaling && _faceUnwrapData.Length != 0 && _faceUnwrapData[0] != null) ? _faceUnwrapData[0].uvScale.x : faceData.uvScale.x) + ((useUnifiedOffset && _faceUnwrapData.Length != 0 && _faceUnwrapData[0] != null) ? _faceUnwrapData[0].uvOffset.x : faceData.uvOffset.x);
			result.y = result.y / ((useUnifiedScaling && _faceUnwrapData.Length != 0 && _faceUnwrapData[0] != null) ? _faceUnwrapData[0].uvScale.y : faceData.uvScale.y) + ((useUnifiedOffset && _faceUnwrapData.Length != 0 && _faceUnwrapData[0] != null) ? _faceUnwrapData[0].uvOffset.y : faceData.uvOffset.y);
			if (faceData.flipUVx)
			{
				result.x = 1f - result.x;
			}
			if (faceData.flipUVy)
			{
				result.y = 1f - result.y;
			}
			return result;
		}
	}
}
