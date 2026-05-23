using DG.Tweening;
using Data.Shapes;
using Data.Variables;
using Presentation.Shapes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Presentation.UI.ModuleViewer
{
	public class ShapeViewer : MonoBehaviour
	{
		[SerializeField]
		protected ShapeMeshLibrary _shapeMeshLibrary;

		[SerializeField]
		private Transform _centerModuleParent;

		[SerializeField]
		private Material _shapeMaterial;

		[SerializeField]
		private InputActionReference pointerPositionInputAction;

		[SerializeField]
		private InputActionReference pointerClickInputAction;

		[SerializeField]
		private Vector2 rotationSpeed = new Vector2(0.5f, 0.5f);

		[SerializeField]
		private float _lerpSpeed = 0.9f;

		[Header("Hover Controls")]
		[SerializeField]
		private ModuleViewerHoverComponent _hoverComponent;

		[SerializeField]
		private BoolVariableSO _isHoveringOverScrollComponent;

		[SerializeField]
		private InputActionAsset _inputActionAsset;

		private ShapeLoader _shapeLoader;

		private Vector2? _previousPointer;

		private Vector2? _pointerDelta;

		private Sequence _introTween;

		private InputActionMap _moduleViewerActionMap;

		private bool _isRotating;

		private Quaternion _prevShapeRotation;

		private Quaternion _prevCenterRotation;

		private void Awake()
		{
			_moduleViewerActionMap = _inputActionAsset.FindActionMap("ModuleViewer");
		}

		public void ShowShape(ShapeData data, bool animateRotation = true)
		{
			if (!animateRotation && _shapeLoader != null && _centerModuleParent != null)
			{
				_prevShapeRotation = _shapeLoader.transform.localRotation;
				_prevCenterRotation = _centerModuleParent.transform.localRotation;
			}
			DestroyShapeLoader();
			_shapeLoader = ShapeLoader.CreateFromShapeData(data, _shapeMeshLibrary, _shapeMaterial, _centerModuleParent.transform.position, Quaternion.identity, createCollider: true);
			_shapeLoader.transform.SetParent(_centerModuleParent, worldPositionStays: true);
			_shapeLoader.transform.localPosition -= Vector3.up * ((float)_shapeLoader.ShapeData.Bounds.y * 0.5f * 0.1f);
			_shapeLoader.gameObject.layer = _centerModuleParent.gameObject.layer;
			if (animateRotation)
			{
				_introTween = DOTween.Sequence();
				_introTween.Append(_shapeLoader.transform.DOLocalRotate(new Vector3(0f, 45f, 0f), 0.5f));
				_introTween.Join(_centerModuleParent.DOLocalRotate(new Vector3(-30f, 0f, 0f), 0.5f));
			}
			else
			{
				_shapeLoader.transform.localRotation = _prevShapeRotation;
				_centerModuleParent.transform.localRotation = _prevCenterRotation;
			}
			_hoverComponent.OnHoverStart += HoverStart;
			_hoverComponent.OnHoverEnd += HoverEnd;
			pointerClickInputAction.action.started += HandleRightClickStart;
			pointerClickInputAction.action.canceled += HandleRightClickEnd;
			_moduleViewerActionMap.Enable();
		}

		private void HandleRightClickStart(InputAction.CallbackContext obj)
		{
			if (_isHoveringOverScrollComponent.Value)
			{
				_isRotating = true;
			}
		}

		private void HandleRightClickEnd(InputAction.CallbackContext obj)
		{
			_isRotating = false;
		}

		private void Update()
		{
			UpdatePointer();
		}

		private void UpdatePointer()
		{
			if (_shapeLoader == null || _introTween.active)
			{
				return;
			}
			if (_isRotating)
			{
				ApplyRotation();
				_shapeLoader.transform.localRotation *= Quaternion.Euler(0f, _pointerDelta.Value.x * (0f - rotationSpeed.x), 0f);
				_centerModuleParent.localRotation *= Quaternion.Euler(_pointerDelta.Value.y * rotationSpeed.y, 0f, 0f);
			}
			else if (_pointerDelta.HasValue)
			{
				if (_pointerDelta.Value.magnitude > 0.01f)
				{
					_previousPointer = null;
					_pointerDelta = _pointerDelta.Value * _lerpSpeed;
					_shapeLoader.transform.localRotation *= Quaternion.Euler(0f, _pointerDelta.Value.x * (0f - rotationSpeed.x), 0f);
					_centerModuleParent.localRotation *= Quaternion.Euler(_pointerDelta.Value.y * rotationSpeed.y, 0f, 0f);
				}
				else
				{
					_previousPointer = null;
					_pointerDelta = null;
				}
			}
		}

		private void ApplyRotation()
		{
			Vector2 vector = pointerPositionInputAction.action.ReadValue<Vector2>();
			Vector2 valueOrDefault = _previousPointer.GetValueOrDefault();
			if (!_previousPointer.HasValue)
			{
				valueOrDefault = vector;
				_previousPointer = valueOrDefault;
			}
			valueOrDefault = vector;
			Vector2? previousPointer = _previousPointer;
			_pointerDelta = valueOrDefault - previousPointer;
			_previousPointer = vector;
		}

		private void DestroyShapeLoader()
		{
			_isRotating = false;
			_introTween.Kill();
			pointerClickInputAction.action.performed -= HandleRightClickStart;
			pointerClickInputAction.action.performed -= HandleRightClickEnd;
			pointerClickInputAction.action.canceled -= HandleRightClickEnd;
			_hoverComponent.OnHoverStart -= HoverStart;
			_hoverComponent.OnHoverEnd -= HoverEnd;
			_moduleViewerActionMap?.Disable();
			if (_shapeLoader != null)
			{
				Object.Destroy(_shapeLoader.gameObject);
			}
		}

		private void HoverEnd()
		{
			_isHoveringOverScrollComponent.SetValue(value: false);
		}

		private void HoverStart()
		{
			_isHoveringOverScrollComponent.SetValue(value: true);
		}

		public void Hide()
		{
			DestroyShapeLoader();
		}
	}
}
