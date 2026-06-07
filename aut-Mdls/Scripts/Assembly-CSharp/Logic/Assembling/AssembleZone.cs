using System;
using System.Collections.Generic;
using DG.Tweening;
using Data.FactoryFloor.Behaviours;
using Data.Shapes;
using Events;
using Presentation.FactoryFloor.ParticleSystemPool;
using Presentation.Shapes;
using Shapes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Utils;

namespace Logic.Assembling
{
	public class AssembleZone : MonoBehaviour
	{
		[SerializeField]
		private float _sizeInVoxels = 10f;

		[SerializeField]
		private ShapeMeshLibrary _shapeMeshLibrary;

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private Material _material;

		[SerializeField]
		private InputActionReference _leftClick;

		[SerializeField]
		private InputActionReference _mousePos;

		[SerializeField]
		private BaseEvent _updatePhysics;

		[SerializeField]
		private ShapeRotationControls _shapeRotationControls;

		[SerializeField]
		private ShapeMoveControls _shapeMoveControls;

		[SerializeField]
		private ParticleSystem _shapeExplodePrefabRef;

		[SerializeField]
		private Transform _plane;

		private ComponentPool<PoolableParticleSystem> _shapeExplodeParticlePool;

		private readonly List<ClickableShape> _placedShapes = new List<ClickableShape>();

		private bool _isHoldingShape;

		private Vector3 _holdingOffset;

		private ClickableShape _currentHoldingShape;

		private ClickableShape _selectedShape;

		private Polyline _assembleZoneLine;

		public Action<ClickableShape> OnRemovedShape = delegate
		{
		};

		public Action OnPlacedShape = delegate
		{
		};

		public Action OnPickupShape = delegate
		{
		};

		private bool _mouseOverGameObject;

		private Sequence _resetSequence;

		private int _holdingShapeIndex;

		public List<ClickableShape> PlacedShapes => _placedShapes;

		public bool IsHoldingShape => _isHoldingShape;

		public int HoldingShapeIndex => _holdingShapeIndex;

		public ClickableShape CurrentHoldingShape => _currentHoldingShape;

		private void Awake()
		{
			CreateLineRenderer();
			_shapeExplodeParticlePool = new ComponentPool<PoolableParticleSystem>(20, _shapeExplodePrefabRef.GetComponent<PoolableParticleSystem>(), base.transform);
		}

		private void PlayVFX(Vector3 worldPosition, Transform parent, ComponentPool<PoolableParticleSystem> pool)
		{
			PoolableParticleSystem component = pool.GetComponent();
			component.transform.SetParent(parent);
			component.transform.SetPositionAndRotation(worldPosition, Quaternion.identity);
			component.Init(pool);
		}

		private void OnEnable()
		{
			_leftClick.action.performed += Deselect;
		}

		private void OnDisable()
		{
			_leftClick.action.performed -= Deselect;
		}

		private void Update()
		{
			_mouseOverGameObject = EventSystem.current.IsPointerOverGameObject();
			_updatePhysics.Fire();
			DragShape();
		}

		private void CreateLineRenderer()
		{
			GameObject gameObject = new GameObject("AssembleZoneLine");
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.SetPositionAndRotation(base.transform.position + Vector3.up * 0.001f, Quaternion.Euler(90f, 0f, 0f));
			_assembleZoneLine = gameObject.AddComponent<Polyline>();
			Vector3[] points = new Vector3[4]
			{
				new Vector3((0f - _sizeInVoxels) * 0.05f, (0f - _sizeInVoxels) * 0.05f, 0f),
				new Vector3((0f - _sizeInVoxels) * 0.05f, _sizeInVoxels * 0.05f, 0f),
				new Vector3(_sizeInVoxels * 0.05f, _sizeInVoxels * 0.05f, 0f),
				new Vector3(_sizeInVoxels * 0.05f, (0f - _sizeInVoxels) * 0.05f, 0f)
			};
			_assembleZoneLine.Geometry = PolylineGeometry.Flat2D;
			_assembleZoneLine.SetPoints(points);
			_assembleZoneLine.Color = Color.black;
			_assembleZoneLine.Thickness = 0.01f;
		}

		private void DragShape()
		{
			if (_isHoldingShape)
			{
				Ray ray = _camera.ScreenPointToRay(_mousePos.action.ReadValue<Vector2>());
				if (new Plane(Vector3.up, _plane.position).Raycast(ray, out var enter))
				{
					_currentHoldingShape.ShapeLoader.Position = ray.GetPoint(enter) + _holdingOffset;
					Vector3 lhs = new Vector3(float.MinValue, base.transform.position.y, float.MinValue);
					_currentHoldingShape.ShapeLoader.Position = Vector3.Max(lhs, _currentHoldingShape.ShapeLoader.Position);
					_currentHoldingShape.ShapeLoader.Position = ShapeUtils.SnapPositionToVoxelGrid(_currentHoldingShape.ShapeLoader.Position, _currentHoldingShape.ShapeLoader.Shape);
					MoveShapeToNotOverlap(_currentHoldingShape);
				}
			}
		}

		private void OnShapeRotate(ShapeLoader shapeLoader, string axisName, bool inverse)
		{
			shapeLoader.Position = ShapeUtils.SnapPositionToVoxelGrid(shapeLoader.Position, shapeLoader.Shape);
			MoveShapeToNotOverlap(_selectedShape);
			OnPlacedShape();
		}

		private void ClickOnShape(ClickableShape shape, Vector3 pos)
		{
			if (!_mouseOverGameObject)
			{
				HoldShape(shape, shape.transform.position - pos);
			}
		}

		public void HoldShape(ClickableShape shape, Vector3 offset)
		{
			if (!_isHoldingShape)
			{
				if (_placedShapes.Contains(shape))
				{
					_placedShapes.Remove(shape);
				}
				_currentHoldingShape = shape;
				_holdingOffset = offset;
				_isHoldingShape = true;
				_holdingShapeIndex = shape.StackIndex;
				shape.ShapeLoader.MeshCollider.enabled = false;
				shape.OnShapeReleased = (Action<ClickableShape>)Delegate.Combine(shape.OnShapeReleased, new Action<ClickableShape>(StopHoldingShape));
				shape.SetIsPressed(isPressed: true);
				_shapeRotationControls.Hide();
				ShapeRotationControls shapeRotationControls = _shapeRotationControls;
				shapeRotationControls.OnRotatedShape = (Action<ShapeLoader, string, bool>)Delegate.Remove(shapeRotationControls.OnRotatedShape, new Action<ShapeLoader, string, bool>(OnShapeRotate));
				_shapeMoveControls.Hide();
				SetSelectedShape(shape);
				OnPickupShape?.Invoke();
			}
		}

		private void RemoveShape(ClickableShape shape)
		{
			_shapeRotationControls.Hide();
			ShapeRotationControls shapeRotationControls = _shapeRotationControls;
			shapeRotationControls.OnRotatedShape = (Action<ShapeLoader, string, bool>)Delegate.Remove(shapeRotationControls.OnRotatedShape, new Action<ShapeLoader, string, bool>(OnShapeRotate));
			if (_currentHoldingShape == shape)
			{
				StopHoldingShape(shape);
			}
			if (_placedShapes.Contains(shape))
			{
				_placedShapes.Remove(shape);
			}
			OnRemovedShape?.Invoke(shape);
			UnityEngine.Object.Destroy(shape.gameObject);
		}

		private void StopHoldingShape(ClickableShape shape)
		{
			if (_isHoldingShape)
			{
				shape.ShapeLoader.MeshCollider.enabled = true;
				ClickableShape currentHoldingShape = _currentHoldingShape;
				currentHoldingShape.OnShapeReleased = (Action<ClickableShape>)Delegate.Remove(currentHoldingShape.OnShapeReleased, new Action<ClickableShape>(StopHoldingShape));
				ClickableShape currentHoldingShape2 = _currentHoldingShape;
				currentHoldingShape2.OnShapePressed = (Action<ClickableShape, Vector3>)Delegate.Combine(currentHoldingShape2.OnShapePressed, new Action<ClickableShape, Vector3>(ClickOnShape));
				_placedShapes.Add(shape);
				_currentHoldingShape = null;
				_holdingOffset = Vector3.zero;
				_isHoldingShape = false;
				SetSelectedShape(shape);
				_shapeMoveControls.Show();
				if (!IsShapeInsideZone(shape))
				{
					RemoveShape(shape);
				}
				else
				{
					OnPlacedShape();
				}
			}
		}

		public bool TryResetSequence(out Sequence sequence)
		{
			if (_resetSequence != null && _resetSequence.active && !_resetSequence.IsComplete())
			{
				sequence = _resetSequence;
				return false;
			}
			_shapeRotationControls.Hide();
			ShapeRotationControls shapeRotationControls = _shapeRotationControls;
			shapeRotationControls.OnRotatedShape = (Action<ShapeLoader, string, bool>)Delegate.Remove(shapeRotationControls.OnRotatedShape, new Action<ShapeLoader, string, bool>(OnShapeRotate));
			if (_isHoldingShape)
			{
				UnityEngine.Object.Destroy(_currentHoldingShape.gameObject);
				_currentHoldingShape = null;
				_isHoldingShape = false;
			}
			_resetSequence = DOTween.Sequence();
			foreach (ClickableShape placedShape in _placedShapes)
			{
				PlayVFX(placedShape.ShapeLoader.Position, base.transform, _shapeExplodeParticlePool);
				AnimateDestroy(_resetSequence, placedShape, append: false);
			}
			foreach (ClickableShape shape in _placedShapes)
			{
				_resetSequence.AppendCallback(delegate
				{
					UnityEngine.Object.Destroy(shape.gameObject);
				});
			}
			_placedShapes.Clear();
			_resetSequence.Play();
			sequence = _resetSequence;
			return true;
		}

		public void Reset()
		{
			_shapeRotationControls.Hide();
			ShapeRotationControls shapeRotationControls = _shapeRotationControls;
			shapeRotationControls.OnRotatedShape = (Action<ShapeLoader, string, bool>)Delegate.Remove(shapeRotationControls.OnRotatedShape, new Action<ShapeLoader, string, bool>(OnShapeRotate));
			if (_isHoldingShape)
			{
				UnityEngine.Object.Destroy(_currentHoldingShape.gameObject);
				_currentHoldingShape = null;
				_isHoldingShape = false;
			}
			foreach (ClickableShape placedShape in _placedShapes)
			{
				UnityEngine.Object.Destroy(placedShape.gameObject);
			}
			_placedShapes.Clear();
		}

		private void AnimateDestroy(Sequence sequence, ClickableShape shapeLoader, bool append)
		{
			shapeLoader.transform.localScale = Vector3.one;
			if (append)
			{
				sequence.Append(shapeLoader.transform.DOScale(Vector3.zero, 0.15f).SetEase(Ease.InBack));
			}
			else
			{
				sequence.Join(shapeLoader.transform.DOScale(Vector3.zero, 0.15f).SetEase(Ease.InBack));
			}
		}

		private bool IsShapeOverlappingWithAnyPlacedShape(ClickableShape shape)
		{
			foreach (ClickableShape placedShape in _placedShapes)
			{
				if (!(shape.gameObject == placedShape.gameObject) && shape.ShapeLoader.Shape.IsOverlappingWithShape(placedShape.ShapeLoader.Shape, out var _))
				{
					return true;
				}
			}
			return false;
		}

		private void MoveShapeToNotOverlap(ClickableShape shape)
		{
			while (IsShapeOverlappingWithAnyPlacedShape(shape))
			{
				shape.ShapeLoader.Position += Vector3.up * 0.1f;
			}
		}

		private int GetMovementToNextAvaliablePosition(ClickableShape shape, Vector3 direction)
		{
			Vector3 position = shape.ShapeLoader.Position;
			int result = 0;
			int num = 0;
			while (true)
			{
				shape.ShapeLoader.Position += direction * 0.1f;
				num++;
				if (!IsShapeInsideZone(shape))
				{
					break;
				}
				if (!IsShapeOverlappingWithAnyPlacedShape(shape))
				{
					result = num;
					break;
				}
			}
			shape.ShapeLoader.Position = position;
			return result;
		}

		private bool IsShapeInsideZone(ClickableShape shape)
		{
			if (shape.ShapeLoader.Position.x + (float)shape.ShapeLoader.Shape.GetBounds().x * 0.05f > base.transform.position.x + _sizeInVoxels * 0.05f + 0.05f)
			{
				return false;
			}
			if (shape.ShapeLoader.Position.x - (float)shape.ShapeLoader.Shape.GetBounds().x * 0.05f < base.transform.position.x - _sizeInVoxels * 0.05f - 0.05f)
			{
				return false;
			}
			if (shape.ShapeLoader.Position.z + (float)shape.ShapeLoader.Shape.GetBounds().z * 0.05f > base.transform.position.z + _sizeInVoxels * 0.05f + 0.05f)
			{
				return false;
			}
			if (shape.ShapeLoader.Position.z - (float)shape.ShapeLoader.Shape.GetBounds().z * 0.05f < base.transform.position.z - _sizeInVoxels * 0.05f - 0.05f)
			{
				return false;
			}
			if (shape.ShapeLoader.Position.y + (float)shape.ShapeLoader.Shape.GetBounds().y * 0.05f > base.transform.position.y + _sizeInVoxels * 2f * 0.05f + 0.05f)
			{
				return false;
			}
			if (shape.ShapeLoader.Position.y < base.transform.position.y - 0.05f)
			{
				return false;
			}
			return true;
		}

		public void AddShapes(IReadOnlyList<AssemblerBehaviour.ConfiguredAssemblerShape> shapes)
		{
			for (int i = 0; i < shapes.Count; i++)
			{
				if (shapes[i] != null)
				{
					ClickableShape clickableShape = ClickableShape.CreateClickableShape(shapes[i].Data, _shapeMeshLibrary, _material, _camera, i, shapes[i].Position, Quaternion.identity);
					clickableShape.ShapeLoader.Rotate(shapes[i].Rotation);
					clickableShape.ShapeLoader.MeshFilter.sharedMesh = clickableShape.ShapeLoader.MeshFilter.mesh;
					clickableShape.transform.position = shapes[i].Position;
					_placedShapes.Add(clickableShape);
				}
			}
		}

		private void SetSelectedShape(ClickableShape shape)
		{
			_selectedShape = shape;
			_shapeRotationControls.Init(_selectedShape.ShapeLoader);
			_shapeMoveControls.Init(shape, GetMovementToNextAvaliablePosition, MoveShape);
			_shapeRotationControls.Show();
			ShapeRotationControls shapeRotationControls = _shapeRotationControls;
			shapeRotationControls.OnRotatedShape = (Action<ShapeLoader, string, bool>)Delegate.Combine(shapeRotationControls.OnRotatedShape, new Action<ShapeLoader, string, bool>(OnShapeRotate));
		}

		private void Deselect(InputAction.CallbackContext callbackContext)
		{
			if (!_mouseOverGameObject)
			{
				_selectedShape = null;
				_shapeRotationControls.Hide();
				ShapeRotationControls shapeRotationControls = _shapeRotationControls;
				shapeRotationControls.OnRotatedShape = (Action<ShapeLoader, string, bool>)Delegate.Remove(shapeRotationControls.OnRotatedShape, new Action<ShapeLoader, string, bool>(OnShapeRotate));
			}
		}

		private void MoveShape(ClickableShape shape, Vector3 unscaledMovement)
		{
			shape.ShapeLoader.Position += unscaledMovement * 0.1f;
			OnPlacedShape();
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube(base.transform.position, new Vector3(_sizeInVoxels * 0.1f, 0f, _sizeInVoxels * 0.1f));
		}
	}
}
