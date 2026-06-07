using DG.Tweening;
using Data.Shapes;
using Logic.Shapes;
using NaughtyAttributes;
using UnityEngine;

namespace Presentation.Shapes
{
	[ExecuteAlways]
	public class ShapeLoader : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer _meshRenderer;

		[SerializeField]
		private MeshFilter _meshFilter;

		[SerializeField]
		private MeshCollider _meshCollider;

		[SerializeField]
		private Material _material;

		[SerializeField]
		protected ShapeMeshLibrary _shapeMeshLibrary;

		private ShapeData _shapeData;

		private Shape _shape;

		private Vector3Int _rotation;

		private ShapeLoader _animationShapeLoader;

		private bool _isAnimating;

		private bool _shuffle;

		public ShapeData ShapeData => _shapeData;

		public Shape Shape => _shape;

		public MeshRenderer MeshRenderer => _meshRenderer;

		public MeshFilter MeshFilter => _meshFilter;

		public MeshCollider MeshCollider => _meshCollider;

		public Vector3Int Rotation
		{
			get
			{
				return _rotation;
			}
			set
			{
				_rotation = value;
			}
		}

		public Vector3 Position
		{
			get
			{
				return base.transform.position;
			}
			set
			{
				base.transform.position = value;
				Shape.Position = value;
			}
		}

		public static ShapeLoader CreateFromShapeData(ShapeData shapeData, ShapeMeshLibrary shapeMeshLibrary, Material material, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion), bool createCollider = false)
		{
			GameObject obj = new GameObject("ShapeLoader");
			obj.transform.SetPositionAndRotation(position, rotation);
			ShapeLoader shapeLoader = obj.AddComponent<ShapeLoader>();
			shapeLoader._shapeMeshLibrary = shapeMeshLibrary;
			shapeLoader.InitMeshRendererAndFilter(material);
			shapeLoader.LoadShapeData(shapeData);
			if (createCollider)
			{
				shapeLoader.CreateCollider();
			}
			return shapeLoader;
		}

		public static ShapeLoader CreateFromShape(Shape shape, ShapeMeshLibrary shapeMeshLibrary, Material material, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion), bool createCollider = false)
		{
			GameObject obj = new GameObject("ShapeLoader");
			ShapeLoader shapeLoader = obj.AddComponent<ShapeLoader>();
			shapeLoader._shapeMeshLibrary = shapeMeshLibrary;
			shapeLoader.InitMeshRendererAndFilter(material);
			shapeLoader.LoadShape(shape);
			obj.transform.SetPositionAndRotation(position, rotation);
			if (createCollider)
			{
				shapeLoader.CreateCollider();
			}
			return shapeLoader;
		}

		public void InitMeshRendererAndFilter(Material material)
		{
			_material = material;
			_meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			_meshRenderer.sharedMaterial = _material;
			_meshFilter = base.gameObject.AddComponent<MeshFilter>();
		}

		public void SetShapesMeshLibrary(ShapeMeshLibrary meshLibrary)
		{
			_shapeMeshLibrary = meshLibrary;
		}

		public void CreateCollider()
		{
			_meshCollider = base.gameObject.AddComponent<MeshCollider>();
			_meshCollider.sharedMesh = _shapeMeshLibrary.GetOrCreate(_shape);
		}

		public virtual void LoadShape(Shape shape)
		{
			_shapeData = shape.ShapeData;
			_shape = shape;
			_meshFilter.mesh = _shapeMeshLibrary.GetOrCreate(_shape);
			Position = shape.Position;
		}

		public virtual void LoadShapeData(ShapeData shapeData)
		{
			_shapeData = shapeData;
			_meshFilter.mesh = _shapeMeshLibrary.GetOrCreate(_shapeData);
			_shape = Shape.Create(_shapeData, base.transform.position);
			_rotation = Vector3Int.zero;
			base.transform.rotation = Quaternion.identity;
		}

		[Button(null, EButtonEnableMode.Always)]
		private void LoadShapeData()
		{
			if (_meshFilter == null)
			{
				InitMeshRendererAndFilter(_material);
			}
			_meshFilter.mesh = _shapeMeshLibrary.GetOrCreate(_shapeData);
			_shape = Shape.Create(_shapeData, base.transform.position);
			_rotation = Vector3Int.zero;
			base.transform.rotation = Quaternion.identity;
			_shape.Regenerate();
			_meshFilter.mesh = _shapeMeshLibrary.GetOrCreate(_shape);
		}

		public void SetCollider(Mesh mesh)
		{
			_meshCollider.sharedMesh = mesh;
		}

		public void SetShapeData(ShapeData shapeData)
		{
			_shapeData = shapeData;
			_meshFilter.mesh = _shapeMeshLibrary.GetOrCreate(_shapeData);
			_shape?.LoadShapeData(shapeData);
		}

		public void UpdateVisual()
		{
			_meshFilter.mesh = _shapeMeshLibrary.GetOrCreate(_shape);
			_meshCollider.sharedMesh = _shapeMeshLibrary.GetOrCreate(_shape);
		}

		[Button(null, EButtonEnableMode.Always)]
		public void RotateShapeX(bool inverse = false)
		{
			_shape.Rotate(inverse ? Shape.RotateDirection.Forward : Shape.RotateDirection.Backward);
			_meshFilter.mesh = _shapeMeshLibrary.GetOrCreate(_shape);
			Quaternion rotation = base.transform.rotation;
			base.transform.rotation = Quaternion.Euler(_rotation);
			base.transform.Rotate(Vector3.right, inverse ? (-90) : 90);
			_rotation = Vector3Int.RoundToInt(base.transform.rotation.eulerAngles);
			base.transform.rotation = rotation;
			if ((bool)_meshCollider)
			{
				_meshCollider.sharedMesh = _shapeMeshLibrary.GetOrCreate(_shape);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void RotateShapeY(bool inverse = false)
		{
			_shape.Rotate(inverse ? Shape.RotateDirection.Left : Shape.RotateDirection.Right);
			_meshFilter.mesh = _shapeMeshLibrary.GetOrCreate(_shape);
			Quaternion rotation = base.transform.rotation;
			base.transform.rotation = Quaternion.Euler(_rotation);
			base.transform.Rotate(Vector3.up, inverse ? (-90) : 90);
			_rotation = Vector3Int.RoundToInt(base.transform.rotation.eulerAngles);
			base.transform.rotation = rotation;
			_shuffle = _shape.GetBounds().x % 2 != 0;
			if ((bool)_meshCollider)
			{
				_meshCollider.sharedMesh = _shapeMeshLibrary.GetOrCreate(_shape);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void RotateShapeZ()
		{
			_shape.Rotate(Shape.RotateDirection.RollLeft);
			_meshFilter.mesh = _shapeMeshLibrary.GetOrCreate(_shape);
			Quaternion rotation = base.transform.rotation;
			base.transform.rotation = Quaternion.Euler(_rotation);
			base.transform.Rotate(Vector3.forward, 90f);
			_rotation = Vector3Int.RoundToInt(base.transform.rotation.eulerAngles);
			base.transform.rotation = rotation;
			if ((bool)_meshCollider)
			{
				_meshCollider.sharedMesh = _shapeMeshLibrary.GetOrCreate(_shape);
			}
		}

		public void Rotate(Vector3Int rotation)
		{
			_shape.Rotate(rotation);
			_meshFilter.mesh = _shapeMeshLibrary.GetOrCreate(_shape);
			_rotation = rotation;
			if ((bool)_meshCollider)
			{
				_meshCollider.sharedMesh = _shapeMeshLibrary.GetOrCreate(_shape);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void SetShapeRotation()
		{
			_shape.LoadShapeData(_shapeData);
			_shape.Rotate(_rotation);
			_meshFilter.mesh = _shapeMeshLibrary.GetOrCreate(_shape);
		}

		public void SnapPositionToGrid()
		{
			Vector3Int bounds = _shape.GetBounds();
			bool num = bounds.x % 2 == 0;
			bool flag = bounds.z % 2 == 0;
			float x = (float)Mathf.RoundToInt((num ? Position.x : (Position.x - 0.05f)) / 0.05f) * 0.05f;
			float z = (float)Mathf.RoundToInt((flag ? Position.z : (Position.z - 0.05f)) / 0.05f) * 0.05f;
			Position = new Vector3(x, base.transform.position.y, z);
		}

		public void SetShuffleState(bool shuffle)
		{
			_shuffle = shuffle;
		}

		public bool RotateShapeXAnimated(float duration = 0.5f, bool inverse = false)
		{
			if (_isAnimating)
			{
				return false;
			}
			_isAnimating = true;
			_animationShapeLoader = CreateFromShape(_shape, _shapeMeshLibrary, _material, base.transform.position, base.transform.rotation);
			MeshRenderer.enabled = false;
			Vector3 position = base.transform.position;
			Vector3Int bounds = _shape.GetBounds();
			_shape.TrimBounds = false;
			Mesh originalMesh = Object.Instantiate(_shapeMeshLibrary.GetOrCreate(_shape));
			RotateShapeX(inverse);
			_animationShapeLoader.MeshFilter.mesh = originalMesh;
			Vector3Int bounds2 = _shape.GetBounds();
			float num = ((bounds.x % 2 != bounds2.x % 2) ? (-0.05f) : 0f);
			float num2 = ((bounds.z % 2 != bounds2.z % 2) ? 0.05f : 0f);
			if (num != 0f || num2 != 0f)
			{
				_shuffle = !_shuffle;
			}
			Position += new Vector3(_shuffle ? num : (0f - num), 0f, _shuffle ? num2 : (0f - num2));
			Vector3 center = _meshRenderer.bounds.center;
			Vector3 center2 = _animationShapeLoader._meshRenderer.bounds.center;
			Vector3 vector = center - center2;
			Quaternion rotation = _animationShapeLoader.transform.rotation;
			_animationShapeLoader.transform.RotateAround(center2, Vector3.right, inverse ? 90 : (-90));
			Quaternion rotation2 = _animationShapeLoader.transform.rotation;
			_animationShapeLoader.transform.rotation = rotation;
			Vector3 endValue = _animationShapeLoader.transform.position + vector;
			_animationShapeLoader.transform.position = position;
			_animationShapeLoader.transform.DOMove(endValue, duration);
			Sequence s = DOTween.Sequence();
			s.Append(_animationShapeLoader.transform.DORotate(rotation2.eulerAngles, duration));
			s.AppendCallback(delegate
			{
				Object.Destroy(_animationShapeLoader.gameObject);
				Object.Destroy(originalMesh);
				MeshRenderer.enabled = true;
				_isAnimating = false;
			});
			return true;
		}

		public bool RotateShapeYAnimated(float duration = 0.5f, bool inverse = false)
		{
			if (_isAnimating)
			{
				return false;
			}
			_isAnimating = true;
			_animationShapeLoader = CreateFromShape(_shape, _shapeMeshLibrary, _material, base.transform.position, base.transform.rotation);
			MeshRenderer.enabled = false;
			Vector3 position = base.transform.position;
			Vector3Int bounds = _shape.GetBounds();
			_shape.TrimBounds = false;
			Mesh originalMesh = Object.Instantiate(_shapeMeshLibrary.GetOrCreate(_shape));
			RotateShapeY(inverse);
			_animationShapeLoader.MeshFilter.mesh = originalMesh;
			Vector3Int bounds2 = _shape.GetBounds();
			float num = ((bounds.x % 2 != bounds2.x % 2) ? (-0.05f) : 0f);
			float num2 = ((bounds.z % 2 != bounds2.z % 2) ? 0.05f : 0f);
			if (num != 0f || num2 != 0f)
			{
				_shuffle = !_shuffle;
			}
			Position += new Vector3(_shuffle ? num : (0f - num), 0f, _shuffle ? num2 : (0f - num2));
			Vector3 center = _meshRenderer.bounds.center;
			Vector3 center2 = _animationShapeLoader._meshRenderer.bounds.center;
			Vector3 vector = center - center2;
			Quaternion rotation = _animationShapeLoader.transform.rotation;
			_animationShapeLoader.transform.RotateAround(center2, Vector3.up, inverse ? (-90) : 90);
			Quaternion rotation2 = _animationShapeLoader.transform.rotation;
			_animationShapeLoader.transform.rotation = rotation;
			Vector3 endValue = _animationShapeLoader.transform.position + vector;
			_animationShapeLoader.transform.position = position;
			_animationShapeLoader.transform.DOMove(endValue, duration);
			Sequence s = DOTween.Sequence();
			s.Append(_animationShapeLoader.transform.DORotate(rotation2.eulerAngles, duration));
			s.AppendCallback(delegate
			{
				Object.Destroy(_animationShapeLoader.gameObject);
				Object.Destroy(originalMesh);
				MeshRenderer.enabled = true;
				_isAnimating = false;
			});
			return true;
		}
	}
}
