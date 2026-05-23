using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Drones;
using Data.Operator;
using Events;
using Presentation.FactoryFloor.Toolbar;
using Presentation.Locators;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.OperatorUIs.OperatorHoverUIs;
using Presentation.UI.OperatorUIs.OperatorPanelUIs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Menus
{
	public class FactoryPanelUIMenu : UIMenu
	{
		[Header("UI Refs")]
		[SerializeField]
		protected UIMenuManagerLocator _uiMenuManagerLocator;

		[SerializeField]
		protected Canvas _canvas;

		[SerializeField]
		private CameraLocator _mainCameraLocator;

		[SerializeField]
		private RectTransform _panel;

		[SerializeField]
		protected TextMeshProUGUI _titleText;

		[Header("Events")]
		[SerializeField]
		private BaseEvent _closeOperatorUI;

		[Header("Audio")]
		[SerializeField]
		protected AudioManagerLocator _audioManagerLocator;

		[Header("Activate Widgets")]
		[Header("Leave blank for anything you don't want to toggle between hovered and clicked state")]
		[SerializeField]
		private List<GameObject> _hoveredWidgets = new List<GameObject>();

		[SerializeField]
		private List<GameObject> _clickedWidgets = new List<GameObject>();

		[Header("Widgets (optional)")]
		[SerializeField]
		private OperatorStateInfoView _operatorState;

		[SerializeField]
		protected SpeedInfo _speedInfo;

		[SerializeField]
		protected ShapesOutputView _shapesOutput;

		[SerializeField]
		private OperatorCoolantInfoView _coolantInfo;

		[SerializeField]
		private DroneInfoView _droneInfo;

		[Header("Undo/redo")]
		[SerializeField]
		private BaseEvent _onUndoEvent;

		[SerializeField]
		private BaseEvent _onRedoEvent;

		protected FactoryObjectUIData _factoryObjectUIData;

		protected FactoryObject _factoryObject;

		protected bool _isOpen;

		protected FactoryObjectBehaviour _factoryObjectBehaviour;

		protected AbstractUIMenuData.UIMenuState _state;

		private OperatorStateBehaviour _stateBehaviour;

		private Dictionary<GameObject, bool> _widgetActiveStates = new Dictionary<GameObject, bool>();

		private bool _listenersAdded;

		private RectTransform _canvasRect;

		private readonly Vector2 cursorPadding = new Vector2(60f, 60f);

		private readonly Vector2 edgePadding = new Vector2(50f, 300f);

		private readonly float smoothSpeed = 20f;

		private readonly Vector3[] _canvasLocalCorners = new Vector3[4];

		private float _pivotOffsetX;

		private float _pivotOffsetY;

		private Vector3 _mousePosition;

		private bool _smoothMovementInitialized;

		private bool _followInitialized;

		private Vector3 _clickedWorldPosition;

		private void Awake()
		{
			SetupPositioning();
			HandleOnAwake();
			if (_onUndoEvent != null)
			{
				_onUndoEvent.Register(HandleUndo);
			}
			if (_onRedoEvent != null)
			{
				_onRedoEvent.Register(HandleUndo);
			}
		}

		private void OnDestroy()
		{
			HandleOnDestroy();
			if (_onUndoEvent != null)
			{
				_onUndoEvent.UnRegister(HandleUndo);
			}
			if (_onRedoEvent != null)
			{
				_onRedoEvent.UnRegister(HandleUndo);
			}
		}

		protected virtual void HandleOnAwake()
		{
		}

		protected virtual void HandleOnDestroy()
		{
		}

		protected virtual void SetTexts()
		{
			_titleText.SetText(LocalizationUtility.GetLocalizedText(_factoryObjectUIData.NameLocKey));
		}

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			UIMenuBehaviourData uIMenuBehaviourData = menuData as UIMenuBehaviourData;
			_factoryObjectBehaviour = uIMenuBehaviourData.Behaviour;
			_factoryObjectUIData = uIMenuBehaviourData.FactoryObject.FactoryObjectData.UIData;
			_factoryObject = uIMenuBehaviourData.FactoryObject;
			_isOpen = true;
			InitiateWidgets();
			_stateBehaviour?.HideState();
			base.gameObject.SetActive(value: true);
			SetState(uIMenuBehaviourData.State);
			base.UIMenuIsStacked = _state == AbstractUIMenuData.UIMenuState.ConfigureMode;
			_followInitialized = false;
			ResetPositioningValuesOnShow();
			Initialized();
			SetTexts();
		}

		public override void ShowMenu(FactoryObjectUIData factoryObjectUIData)
		{
			_factoryObjectUIData = factoryObjectUIData;
			_factoryObjectBehaviour = _factoryObjectUIData.FactoryObjectBehaviour;
			_factoryObject = null;
			_isOpen = true;
			InitiateWidgets();
			_stateBehaviour?.HideState();
			base.gameObject.SetActive(value: true);
			SetState(AbstractUIMenuData.UIMenuState.InfoMode);
			base.UIMenuIsStacked = false;
			_followInitialized = false;
			ResetPositioningValuesOnShow();
			Initialized();
			SetTexts();
		}

		public override void HideMenu()
		{
			_isOpen = false;
			_stateBehaviour?.ShowState();
			ResetPositioningValuesOnHide();
			base.gameObject.SetActive(value: false);
			RemoveListeners();
			_closeOperatorUI?.Fire();
		}

		protected virtual void Initialized()
		{
		}

		protected virtual void SetState(AbstractUIMenuData.UIMenuState state)
		{
			_state = state;
			switch (_state)
			{
			case AbstractUIMenuData.UIMenuState.InfoMode:
				ToggleWidgets(_hoveredWidgets, _clickedWidgets);
				break;
			case AbstractUIMenuData.UIMenuState.ConfigureMode:
				ToggleWidgets(_clickedWidgets, _hoveredWidgets);
				break;
			}
		}

		protected virtual void InitiateWidgets()
		{
			InitiateOperatorState();
			int uniqueInputsCount = 0;
			int uniqueOutputsCount = 0;
			int totalOutputsCount = 0;
			if (_shapesOutput != null)
			{
				bool active = _factoryObject != null && _shapesOutput.SetContent(_factoryObject, out uniqueInputsCount, out uniqueOutputsCount, out totalOutputsCount);
				AddWidgetActiveState(_shapesOutput.gameObject, active);
			}
			if (_speedInfo != null)
			{
				_speedInfo.SetSpeedsFromConfiguredOperator(_factoryObjectUIData, totalOutputsCount, uniqueInputsCount, uniqueOutputsCount, _factoryObject);
			}
			if (_coolantInfo != null)
			{
				bool active2 = _factoryObject != null && _coolantInfo.SetContent(_factoryObject);
				AddWidgetActiveState(_coolantInfo.gameObject, active2);
			}
			if (!(_droneInfo != null))
			{
				return;
			}
			if (!(_factoryObjectBehaviour is SupplyTankRecipientBehaviour supplyTankRecipientBehaviour))
			{
				_droneInfo.Show(show: false);
				return;
			}
			bool flag = supplyTankRecipientBehaviour.DroneBehaviour != null;
			_droneInfo.Show(flag);
			if (flag)
			{
				_droneInfo.SetContent(supplyTankRecipientBehaviour.DroneBehaviour.TotalTimeInSeconds, supplyTankRecipientBehaviour.DroneIsFastEnough);
			}
		}

		private void AddListeners()
		{
			if (!_listenersAdded)
			{
				_listenersAdded = true;
				_stateBehaviour.OnStateChanged.RegisterMainThread(OperatorStateChanged);
			}
		}

		private void RemoveListeners()
		{
			_listenersAdded = false;
			if (_stateBehaviour != null)
			{
				_stateBehaviour.OnStateChanged.UnRegisterMainThread(OperatorStateChanged);
			}
		}

		protected void InitiateOperatorState()
		{
			if (_factoryObject == null)
			{
				AddWidgetActiveState(_operatorState.gameObject, active: false);
			}
			else if (_operatorState != null)
			{
				if (_factoryObject.TryGetFactoryObjectBehaviour<OperatorStateBehaviour>(out var behaviour))
				{
					_stateBehaviour = behaviour;
					AddListeners();
					OperatorStateChanged(_stateBehaviour.CurrentState);
				}
				else
				{
					AddWidgetActiveState(_operatorState.gameObject, active: false);
				}
			}
		}

		private void OperatorStateChanged(OperatorStateBehaviour.State state)
		{
			_operatorState.SetStateContent(state);
			bool active = state.StateType != OperatorStateBehaviour.StateType.None;
			AddWidgetActiveState(_operatorState.gameObject, active);
		}

		private void AddWidgetActiveState(GameObject gameObject, bool active)
		{
			if (_widgetActiveStates.ContainsKey(gameObject))
			{
				_widgetActiveStates[gameObject] = active;
			}
			else
			{
				_widgetActiveStates.Add(gameObject, active);
			}
			gameObject.SetActive(active);
		}

		private void ToggleWidgets(List<GameObject> widgetsToShow, List<GameObject> widgetsToHide)
		{
			for (int i = 0; i < widgetsToHide.Count; i++)
			{
				if (widgetsToHide[i].activeSelf)
				{
					widgetsToHide[i].SetActive(value: false);
				}
			}
			for (int j = 0; j < widgetsToShow.Count; j++)
			{
				if (!widgetsToShow[j].activeSelf && ((_widgetActiveStates.ContainsKey(widgetsToShow[j]) && _widgetActiveStates[widgetsToShow[j]]) || !_widgetActiveStates.ContainsKey(widgetsToShow[j])))
				{
					widgetsToShow[j].SetActive(value: true);
				}
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(_panel);
		}

		private void ResetPositioningValuesOnShow()
		{
			_panel.pivot = new Vector2(0f, 0f);
			_pivotOffsetX = _panel.rect.width * _panel.pivot.x;
			_pivotOffsetY = _panel.rect.height * _panel.pivot.y;
			_smoothMovementInitialized = false;
		}

		private void ResetPositioningValuesOnHide()
		{
			_followInitialized = false;
			base.UIMenuIsStacked = false;
		}

		private void SetupPositioning()
		{
			_canvasRect = _canvas.transform as RectTransform;
			_canvasRect.GetLocalCorners(_canvasLocalCorners);
		}

		private void LateUpdate()
		{
			if (base.gameObject.activeInHierarchy)
			{
				UpdatePanelPosition();
			}
		}

		private void UpdatePanelPosition()
		{
			_mousePosition = Input.mousePosition;
			if (_state == AbstractUIMenuData.UIMenuState.InfoMode)
			{
				UpdateInfoModePanelPosition();
			}
			else
			{
				UpdateConfigModePanelPosition();
			}
		}

		private void UpdateConfigModePanelPosition()
		{
			if (!_followInitialized)
			{
				Vector3 vector = _mainCameraLocator.Camera.ScreenToWorldPoint(new Vector3(_mousePosition.x, _mousePosition.y, 0.25f));
				Ray ray = new Ray(vector, vector - _mainCameraLocator.Camera.transform.position);
				if (!new Plane(Vector3.up, Vector3.zero).Raycast(ray, out var enter))
				{
					return;
				}
				_clickedWorldPosition = ray.GetPoint(enter);
				_followInitialized = true;
			}
			Vector3 clickedScreenPosition = _mainCameraLocator.Camera.WorldToScreenPoint(_clickedWorldPosition);
			clickedScreenPosition = MoveIfTooCloseToScreenEdges(clickedScreenPosition);
			if (clickedScreenPosition.x < 0f - _panel.rect.width || clickedScreenPosition.x > (float)Screen.width || clickedScreenPosition.y < 0f - _panel.rect.height || clickedScreenPosition.y > (float)Screen.height)
			{
				_uiMenuManagerLocator.UIMenuManager.GoBack();
			}
			else
			{
				_panel.localPosition = GetPositionOnCanvas(clickedScreenPosition, stayWithinBounds: true);
			}
		}

		private Vector3 MoveIfTooCloseToScreenEdges(Vector3 clickedScreenPosition)
		{
			if (clickedScreenPosition.y - edgePadding.y + 4f * cursorPadding.y > _canvasRect.rect.height / 2f)
			{
				clickedScreenPosition -= new Vector3(0f, _panel.rect.height + 2f * cursorPadding.y, 0f);
			}
			if (clickedScreenPosition.x + _panel.rect.width + edgePadding.x + 2f * cursorPadding.x > _canvasRect.rect.width)
			{
				clickedScreenPosition -= new Vector3(_panel.rect.width + 2f * cursorPadding.x, 0f, 0f);
			}
			return clickedScreenPosition;
		}

		private void UpdateInfoModePanelPosition()
		{
			_panel.localPosition = GetPositionOnCanvas(Input.mousePosition, stayWithinBounds: true);
		}

		private Vector3 GetPositionOnCanvas(Vector3 screenPos, bool stayWithinBounds)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, screenPos, null, out var localPoint);
			Vector2 vector = localPoint;
			if (stayWithinBounds)
			{
				_canvasRect.GetLocalCorners(_canvasLocalCorners);
				Vector3 vector2 = _canvasLocalCorners[0];
				Vector3 vector3 = _canvasLocalCorners[2];
				float num = vector3.x - localPoint.x;
				float num2 = vector3.y - localPoint.y;
				float num3 = _panel.rect.width + cursorPadding.x + edgePadding.x;
				float num4 = _panel.rect.height + cursorPadding.y + edgePadding.y;
				float x = ((num >= num3) ? cursorPadding.x : (0f - (_panel.rect.width + cursorPadding.x)));
				float y = ((num2 >= num4) ? cursorPadding.y : (0f - (_panel.rect.height + cursorPadding.y)));
				vector = localPoint + new Vector2(x, y);
				vector.x = Mathf.Clamp(vector.x, vector2.x + _pivotOffsetX + edgePadding.x, vector3.x - (_panel.rect.width - _pivotOffsetX) - edgePadding.x);
				vector.y = Mathf.Clamp(vector.y, vector2.y + _pivotOffsetY + edgePadding.y, vector3.y - (_panel.rect.height - _pivotOffsetY) - edgePadding.y);
			}
			Vector3 position = _canvasRect.TransformPoint(new Vector3(vector.x, vector.y, 0f));
			Vector3 vector4 = _panel.parent.InverseTransformPoint(position);
			if (!_smoothMovementInitialized)
			{
				_smoothMovementInitialized = true;
				return vector4;
			}
			float t = 1f - Mathf.Exp((0f - smoothSpeed) * Time.unscaledDeltaTime);
			return Vector2.Lerp(_panel.localPosition, vector4, t);
		}

		private void HandleUndo()
		{
			HideMenu();
		}
	}
}
