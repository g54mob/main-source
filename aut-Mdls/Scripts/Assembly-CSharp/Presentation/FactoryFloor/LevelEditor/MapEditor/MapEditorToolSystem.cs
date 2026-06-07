using System;
using Data.UI.Controls;
using Events;
using Events.Generic;
using Logic.FactoryTools.IslandEditor;
using Logic.FactoryTools.MapEditor;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Presentation.FactoryFloor.LevelEditor.MapEditor
{
	public class MapEditorToolSystem : MonoBehaviour
	{
		[SerializeField]
		private GUIDEvent _islandButtonPressed;

		[SerializeField]
		private BaseEvent _selectToolButtonPressedEvent;

		[SerializeField]
		private BaseEvent _moveToolButtonPressedEvent;

		[SerializeField]
		private BaseEvent _deleteToolButtonPressed;

		[SerializeField]
		private BaseEvent _actionCanceledEvent;

		[SerializeField]
		private PlaceIslandMapTool _placeIslandMapTool;

		[SerializeField]
		private SelectIslandMapTool _selectIslandMapTool;

		[SerializeField]
		private DeleteMapEditorTool _deleteMapEditorTool;

		[SerializeField]
		private MoveMapEditorTool _moveMapEditorTool;

		[SerializeField]
		private MouseToGridInput _mouseToGridInput;

		[SerializeField]
		private GridLocator _gridMapLocator;

		[SerializeField]
		private InputActionReference _startAction;

		[SerializeField]
		private InputActionReference _endAction;

		[SerializeField]
		private InputActionReference _rotateAction;

		[SerializeField]
		private InputActionReference _mirrorAction;

		[SerializeField]
		private InputActionReference _cancelAction;

		[SerializeField]
		private SettingsRebindRuntimeInfo _settingsRebindRuntimeInfo;

		private bool _isPointerOverGameObject;

		private MapEditorTool _selectedTool;

		private void Awake()
		{
			_settingsRebindRuntimeInfo.Initialize();
		}

		private void OnEnable()
		{
			_selectedTool = _selectIslandMapTool;
			_selectedTool.SelectTool();
			_startAction.action.performed += StartActionPerformed;
			_endAction.action.performed += EndActionPerformed;
			_rotateAction.action.performed += RotateActionPerformed;
			_mirrorAction.action.performed += MirrorActionPerformed;
			_cancelAction.action.performed += CancelAction;
			_islandButtonPressed.Register(PlaceIslandTool);
			_selectToolButtonPressedEvent.Register(SelectDefaultTool);
			_deleteToolButtonPressed.Register(SelectDeleteTool);
			_moveToolButtonPressedEvent.Register(SelectMoveTool);
		}

		private void OnDisable()
		{
			_islandButtonPressed.UnRegister(PlaceIslandTool);
			_selectToolButtonPressedEvent.UnRegister(SelectDefaultTool);
			_deleteToolButtonPressed.UnRegister(SelectDeleteTool);
			_moveToolButtonPressedEvent.UnRegister(SelectMoveTool);
			_startAction.action.performed -= StartActionPerformed;
			_endAction.action.performed -= EndActionPerformed;
			_rotateAction.action.performed -= RotateActionPerformed;
			_mirrorAction.action.performed -= MirrorActionPerformed;
			_cancelAction.action.performed -= CancelAction;
		}

		private void SelectDefaultTool()
		{
			SelectTool(_selectIslandMapTool);
		}

		private void PlaceIslandTool(Guid id)
		{
			SelectTool(_placeIslandMapTool, new PlaceMapEditorData
			{
				Id = id
			});
		}

		private void SelectMoveTool()
		{
			SelectTool(_moveMapEditorTool);
		}

		private void SelectDeleteTool()
		{
			SelectTool(_deleteMapEditorTool);
		}

		private void StartActionPerformed(InputAction.CallbackContext obj)
		{
			if (!_isPointerOverGameObject)
			{
				Vector3 selectedMapPosition = _mouseToGridInput.GetSelectedMapPosition();
				_selectedTool.OnActionIntent(_gridMapLocator.GetCellPosition(selectedMapPosition));
			}
		}

		private void Update()
		{
			_isPointerOverGameObject = EventSystem.current.IsPointerOverGameObject();
			if (_selectedTool != null)
			{
				Vector3 selectedMapPosition = _mouseToGridInput.GetSelectedMapPosition();
				_selectedTool.UpdateTool(_gridMapLocator.GetCellPosition(selectedMapPosition));
			}
		}

		private void RotateActionPerformed(InputAction.CallbackContext obj)
		{
			_selectedTool.Rotate(90);
		}

		private void MirrorActionPerformed(InputAction.CallbackContext obj)
		{
			_selectedTool.Mirror();
		}

		private void EndActionPerformed(InputAction.CallbackContext obj)
		{
			if (!_isPointerOverGameObject)
			{
				Vector3 selectedMapPosition = _mouseToGridInput.GetSelectedMapPosition();
				_selectedTool.DoAction(_gridMapLocator.GetCellPosition(selectedMapPosition));
			}
			else
			{
				SelectDefaultTool();
			}
		}

		private void CancelAction(InputAction.CallbackContext obj)
		{
			SelectDefaultTool();
			_actionCanceledEvent.Fire();
		}

		private void SelectTool(MapEditorTool newTool, EmptyIslandEditorData data = null)
		{
			if (_selectedTool != null)
			{
				_selectedTool.CancelAction();
			}
			_selectedTool = newTool;
			_selectedTool.SelectTool(data);
		}
	}
}
