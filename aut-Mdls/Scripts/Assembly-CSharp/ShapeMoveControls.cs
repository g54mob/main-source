using System;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.UI;

public class ShapeMoveControls : MonoBehaviour
{
	[SerializeField]
	private GameObject _container;

	[SerializeField]
	private Button _moveUpButton;

	[SerializeField]
	private Button _moveDownButton;

	[Header("Audio")]
	[SerializeField]
	private AudioManagerLocator _audioManagerLocator;

	private bool _initialized;

	private Func<ClickableShape, Vector3, int> _getNextAvaliablePosition;

	private Action<ClickableShape, Vector3> _moveShapePosition;

	private ClickableShape _selectedShape;

	private int _upMovement;

	private int _downMovement;

	public void Init(ClickableShape selectedShape, Func<ClickableShape, Vector3, int> getNextAvaliablePosition, Action<ClickableShape, Vector3> moveShapePosition)
	{
		_selectedShape = selectedShape;
		_getNextAvaliablePosition = getNextAvaliablePosition;
		_moveShapePosition = moveShapePosition;
		_initialized = true;
		UpdateMovements();
	}

	public void Show()
	{
		_container.SetActive(value: true);
	}

	public void Hide()
	{
		_container.SetActive(value: false);
	}

	private void Awake()
	{
		_moveUpButton.onClick.AddListener(MoveUp);
		_moveDownButton.onClick.AddListener(MoveDown);
	}

	private void OnDestroy()
	{
		_moveUpButton.onClick.RemoveListener(MoveUp);
		_moveDownButton.onClick.RemoveListener(MoveDown);
	}

	private void UpdateMovements()
	{
		UpdateMovement(Vector3Int.up, _moveUpButton, out _upMovement);
		UpdateMovement(Vector3Int.down, _moveDownButton, out _downMovement);
	}

	private void UpdateMovement(Vector3Int direction, Button button, out int movement)
	{
		movement = _getNextAvaliablePosition(_selectedShape, direction);
		button.interactable = movement != 0;
	}

	private void MoveUp()
	{
		if (_initialized && _upMovement != 0 && base.gameObject.activeInHierarchy)
		{
			_moveShapePosition(_selectedShape, new Vector3Int(0, _upMovement, 0));
			_audioManagerLocator?.AudioManager.PlayRotateShape();
			UpdateMovements();
		}
	}

	private void MoveDown()
	{
		if (_initialized && _downMovement != 0 && base.gameObject.activeInHierarchy)
		{
			_moveShapePosition(_selectedShape, new Vector3Int(0, -_downMovement, 0));
			_audioManagerLocator?.AudioManager.PlayRotateShape();
			UpdateMovements();
		}
	}
}
