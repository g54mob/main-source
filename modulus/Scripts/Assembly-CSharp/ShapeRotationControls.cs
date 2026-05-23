using System;
using Presentation.Locators;
using Presentation.Shapes;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShapeRotationControls : MonoBehaviour
{
	[SerializeField]
	private Transform _panel;

	[SerializeField]
	private Camera _3DCamera;

	[SerializeField]
	private Button _rotateYBtn;

	[SerializeField]
	private Button _rotateXBtn;

	[SerializeField]
	private Image _rotateYImg;

	[SerializeField]
	private Image _rotateXImg;

	[SerializeField]
	private int _heightOffset = 4;

	[SerializeField]
	private LineRenderer _line;

	[SerializeField]
	private InputActionReference _rotateYAction;

	[SerializeField]
	private InputActionReference _rotateXAction;

	[SerializeField]
	private InputActionReference _invertRotationAction;

	[SerializeField]
	private Sprite _rotateRightSprite;

	[SerializeField]
	private Sprite _rotateLeftSprite;

	[SerializeField]
	private Sprite _rotateForwardSprite;

	[SerializeField]
	private Sprite _rotateBackwardSprite;

	[SerializeField]
	private Vector3 _panelOffset;

	[Header("Audio")]
	[SerializeField]
	private AudioManagerLocator _audioManagerLocator;

	private static ShapeRotationControls _activeInstance;

	private bool _initialized;

	private ShapeLoader _shapeLoader;

	public Action<ShapeLoader, string, bool> OnRotatedShape = delegate
	{
	};

	public void Init(ShapeLoader shapeLoader)
	{
		_shapeLoader = shapeLoader;
		_initialized = true;
	}

	private void Awake()
	{
		_rotateYBtn.onClick.AddListener(RotateY);
		_rotateXBtn.onClick.AddListener(RotateX);
		_rotateYAction.action.performed += RotateRightActionPerformed;
		_rotateXAction.action.performed += RotateForwardActionPerformed;
		_invertRotationAction.action.started += ShiftActionStarted;
		_invertRotationAction.action.canceled += ShiftActionCanceled;
	}

	private void RotateRightActionPerformed(InputAction.CallbackContext obj)
	{
		if (base.gameObject.activeSelf && _activeInstance == this)
		{
			RotateY();
		}
	}

	private void RotateForwardActionPerformed(InputAction.CallbackContext obj)
	{
		if (base.gameObject.activeSelf && _activeInstance == this)
		{
			RotateX();
		}
	}

	private void ShiftActionStarted(InputAction.CallbackContext obj)
	{
		if (base.gameObject.activeSelf && _activeInstance == this)
		{
			_rotateYImg.sprite = _rotateLeftSprite;
			_rotateXImg.sprite = _rotateBackwardSprite;
		}
	}

	private void ShiftActionCanceled(InputAction.CallbackContext obj)
	{
		_rotateYImg.sprite = _rotateRightSprite;
		_rotateXImg.sprite = _rotateForwardSprite;
	}

	private void OnDestroy()
	{
		_rotateYBtn.onClick.RemoveListener(RotateY);
		_rotateXBtn.onClick.RemoveListener(RotateX);
		_rotateYAction.action.performed -= RotateRightActionPerformed;
		_rotateXAction.action.performed -= RotateForwardActionPerformed;
		_invertRotationAction.action.started -= ShiftActionStarted;
		_invertRotationAction.action.canceled -= ShiftActionCanceled;
	}

	public void Show()
	{
		_activeInstance = this;
		SetPosition();
		base.gameObject.SetActive(value: true);
		_line.enabled = true;
	}

	public void Hide()
	{
		_line.enabled = false;
		base.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		SetPosition();
	}

	private void SetPosition()
	{
		if (_initialized)
		{
			Vector3Int bounds = _shapeLoader.Shape.GetBounds();
			int num = bounds.y + _heightOffset;
			Vector3 position = _shapeLoader.transform.position + 0.1f * (float)num * Vector3.up + _panelOffset;
			_panel.position = _3DCamera.WorldToScreenPoint(position);
			_line.SetPosition(0, position);
			_line.SetPosition(1, _shapeLoader.Shape.VoxelPosToWorldPos(new Vector3Int(0, bounds.y - 1, bounds.z)));
		}
	}

	private void RotateX()
	{
		if (_initialized)
		{
			bool flag = _invertRotationAction.action.IsPressed();
			if (_shapeLoader.RotateShapeXAnimated(0.35f, flag))
			{
				OnRotatedShape(_shapeLoader, "X", flag);
			}
			_audioManagerLocator?.AudioManager.PlayRotateShape();
		}
	}

	private void RotateY()
	{
		if (_initialized)
		{
			bool flag = !_invertRotationAction.action.IsPressed();
			if (_shapeLoader.RotateShapeYAnimated(0.35f, flag))
			{
				OnRotatedShape(_shapeLoader, "Y", flag);
			}
			_audioManagerLocator?.AudioManager.PlayRotateShape();
		}
	}
}
