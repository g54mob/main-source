using System;
using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CTS.Core
{
	public class WorldSelector : CTSSingleton<WorldSelector>, ILockable
	{
		private abstract class SelectionAction
		{
			public abstract void Invoke(object selection, bool selected);
		}

		private class SelectionAction<T> : SelectionAction
		{
			private static readonly SelectionAction<T> _defaultAction = new SelectionAction<T>();

			public bool IsEmpty
			{
				get
				{
					if (this._action != null)
					{
						return this._action.GetInvocationList().Length == 0;
					}
					return true;
				}
			}

			private event Action<T, bool> _action;

			public static SelectionAction<T> GetAction()
			{
				return _defaultAction;
			}

			public override void Invoke(object selection, bool selected)
			{
				if (selection is T arg)
				{
					this._action?.Invoke(arg, selected);
				}
			}

			public void AddListener(Action<T, bool> callback)
			{
				_action += callback;
			}

			public void RemoveListener(Action<T, bool> callback)
			{
				_action -= callback;
			}
		}

		[Header("Modes")]
		[SerializeField]
		private List<SelectionMode> _defaultSelectionModes;

		[SerializeField]
		private SelectionMode _startSelectionMode;

		[SerializeField]
		[Inject(false)]
		private WorldSelectorInputBase _inputs;

		[Header("Raycast")]
		[SerializeField]
		private float _selectionDistance = 50f;

		private readonly SerializableDictionary<StringKey<SelectionMode>, SelectionMode> _selectionModes = new SerializableDictionary<StringKey<SelectionMode>, SelectionMode>();

		private SelectableObject _currentHovered;

		private bool _inputSelectBuffer;

		private bool _inputDeselectBuffer;

		private bool _changedSelectionModeThisFrame;

		private readonly List<SelectableObject> _currentSelectedList = new List<SelectableObject>();

		private static readonly Dictionary<Type, SelectionAction> _selectionCallbacks = new Dictionary<Type, SelectionAction>();

		[field: SerializeField]
		public Camera ActiveCamera { get; set; }

		public ReadOnlyList<SelectableObject> CurrentSelectedList => _currentSelectedList;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public static bool PointerIsOverUI { get; private set; }

		public SelectionMode CurrentSelectionMode { get; private set; }

		public static Vector2 MousePositionScreenSpace => Input.mousePosition;

		public static Vector3? MousePositionWorldSpace { get; private set; }

		private static Vector3 MouseScreenPosition => Input.mousePosition.ToScreenPoint();

		private bool IsPressingMultipleSelection
		{
			get
			{
				if ((bool)_inputs)
				{
					return _inputs.IsMultiSelectionPressed();
				}
				return false;
			}
		}

		public static event Action<SelectionMode> SelectionModeChanged;

		public static event Action<Component> AnyObjectSelected;

		public static event Action<Component> AnyObjectDeselected;

		public static event Action<WorldSelector> SelectionChanged;

		protected override void SingletonAwake()
		{
			foreach (SelectionMode defaultSelectionMode in _defaultSelectionModes)
			{
				if (!_selectionModes.ContainsKey(defaultSelectionMode))
				{
					_selectionModes[defaultSelectionMode] = defaultSelectionMode;
				}
			}
			SetSelectionMode(_startSelectionMode);
			SubscribeInputs();
		}

		protected override void OnSingletonDestroy()
		{
			DeselectAll();
			PointerIsOverUI = false;
			UnsubscribeInputs();
		}

		private void Update()
		{
			PointerIsOverUI = IsPointerOverUI();
			if (PointerIsOverUI || !IsActive())
			{
				StopHoverCurrent();
				return;
			}
			HandleInput();
			RaycastHit hitInfo;
			if (!ActiveCamera)
			{
				StopHoverCurrent();
			}
			else if (Physics.Raycast(ActiveCamera.ScreenPointToRay(MouseScreenPosition), out hitInfo, _selectionDistance, CurrentSelectionMode.PhysicsMask))
			{
				HoverCollider(hitInfo.collider);
				MousePositionWorldSpace = hitInfo.point;
			}
			else
			{
				StopHoverCurrent();
			}
		}

		private void LateUpdate()
		{
			_inputDeselectBuffer = false;
			_inputSelectBuffer = false;
			_changedSelectionModeThisFrame = false;
		}

		public void SetSelectionMode(StringKey<SelectionMode> key)
		{
			key.AssertKeyValidity();
			if (key == CurrentSelectionMode)
			{
				return;
			}
			if (!_selectionModes.ContainsKey(key))
			{
				throw new ArgumentException("Passed key doesn't correspond to any selection mode.");
			}
			CurrentSelectionMode = _selectionModes[key];
			for (int num = _currentSelectedList.Count - 1; num >= 0; num--)
			{
				SelectableObject selectableObject = _currentSelectedList[num];
				if (!selectableObject.CanBeSelectedByMode(CurrentSelectionMode))
				{
					Deselect(selectableObject);
				}
			}
			_changedSelectionModeThisFrame = true;
			_inputDeselectBuffer = false;
			_inputSelectBuffer = false;
			WorldSelector.SelectionModeChanged?.Invoke(CurrentSelectionMode);
		}

		public static bool IsObjectSelected(SelectableObject selectableObject)
		{
			if (!CTSSingleton<WorldSelector>.InstanceExists())
			{
				return false;
			}
			return CTSSingleton<WorldSelector>.Instance._currentSelectedList.Contains(selectableObject);
		}

		public static bool IsObjectSelected(Component obj)
		{
			if ((object)obj == null)
			{
				return false;
			}
			if (!CTSSingleton<WorldSelector>.InstanceExists())
			{
				return false;
			}
			Type type = obj.GetType();
			foreach (SelectableObject currentSelected in CTSSingleton<WorldSelector>.Instance._currentSelectedList)
			{
				if (obj == currentSelected)
				{
					return true;
				}
				Component component;
				if ((object)currentSelected.SelectionTarget == null)
				{
					if (currentSelected.TryGetComponent(type, out component) && component == obj)
					{
						return true;
					}
					continue;
				}
				if (currentSelected.SelectionTarget == obj)
				{
					return true;
				}
				if (currentSelected.SelectionTarget.TryGetComponent(type, out component) && component == obj)
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsObjectSelected(object obj)
		{
			return IsObjectSelected(obj as Component);
		}

		public static bool IsAnythingSelected()
		{
			if (!CTSSingleton<WorldSelector>.InstanceExists())
			{
				return false;
			}
			return CTSSingleton<WorldSelector>.Instance._currentSelectedList.Count > 0;
		}

		public static TComponent GetHovered<TComponent>()
		{
			if (!CTSSingleton<WorldSelector>.InstanceExists())
			{
				return default(TComponent);
			}
			WorldSelector instance = CTSSingleton<WorldSelector>.Instance;
			if (instance._currentHovered == null)
			{
				return default(TComponent);
			}
			Component selectionTarget = instance._currentHovered.SelectionTarget;
			if (selectionTarget is TComponent)
			{
				return (TComponent)(object)((selectionTarget is TComponent) ? selectionTarget : null);
			}
			TComponent component2;
			if ((bool)instance._currentHovered.SelectionTarget)
			{
				if (instance._currentHovered.SelectionTarget.TryGetComponent<TComponent>(out var component))
				{
					return component;
				}
			}
			else if (instance._currentHovered.TryGetComponent<TComponent>(out component2))
			{
				return component2;
			}
			return default(TComponent);
		}

		public static bool IsHoveringSomething()
		{
			if (!CTSSingleton<WorldSelector>.InstanceExists())
			{
				return false;
			}
			return (object)CTSSingleton<WorldSelector>.Instance._currentHovered != null;
		}

		public static int GetSelectedCount()
		{
			if (!CTSSingleton<WorldSelector>.InstanceExists())
			{
				return 0;
			}
			return CTSSingleton<WorldSelector>.Instance._currentSelectedList.Count;
		}

		public static int GetSelectedCount<T>() where T : Component
		{
			if (!CTSSingleton<WorldSelector>.InstanceExists())
			{
				return 0;
			}
			int num = 0;
			foreach (SelectableObject currentSelected in CTSSingleton<WorldSelector>.Instance._currentSelectedList)
			{
				Component component = (currentSelected.SelectionTarget ? currentSelected.SelectionTarget : currentSelected);
				if (!(component == null) && component is T)
				{
					num++;
				}
			}
			return num;
		}

		public static SelectableObject GetFirstSelected()
		{
			if (!CTSSingleton<WorldSelector>.InstanceExists())
			{
				return null;
			}
			WorldSelector instance = CTSSingleton<WorldSelector>.Instance;
			if (instance._currentSelectedList.Count <= 0)
			{
				return null;
			}
			return instance._currentSelectedList[0];
		}

		public static T GetFirstSelected<T>() where T : Component
		{
			if (!CTSSingleton<WorldSelector>.InstanceExists())
			{
				return null;
			}
			if (!CTSSingleton<WorldSelector>.Instance.TryGetFirstSelected<T>(out var obj, out var _))
			{
				return null;
			}
			return obj;
		}

		private bool TryGetFirstSelected<T>(out T obj, out SelectableObject selectableObject)
		{
			if (_currentSelectedList.Count <= 0)
			{
				return ReturnSelectionNull<T>(out obj, out selectableObject);
			}
			foreach (SelectableObject currentSelected in _currentSelectedList)
			{
				Component component = (currentSelected.SelectionTarget ? currentSelected.SelectionTarget : currentSelected);
				if (!(component == null) && component is T val)
				{
					obj = val;
					selectableObject = currentSelected;
					return true;
				}
			}
			return ReturnSelectionNull<T>(out obj, out selectableObject);
		}

		public static SelectableObject GetLastSelected()
		{
			if (!CTSSingleton<WorldSelector>.InstanceExists())
			{
				return null;
			}
			WorldSelector instance = CTSSingleton<WorldSelector>.Instance;
			if (instance._currentSelectedList.Count <= 0)
			{
				return null;
			}
			List<SelectableObject> currentSelectedList = instance._currentSelectedList;
			return currentSelectedList[currentSelectedList.Count - 1];
		}

		public static T GetLastSelected<T>()
		{
			if (!CTSSingleton<WorldSelector>.InstanceExists())
			{
				return default(T);
			}
			if (!CTSSingleton<WorldSelector>.Instance.TryGetLastSelected<T>(out var obj, out var _))
			{
				return default(T);
			}
			return obj;
		}

		public static SelectableObject GetLastSelected<T>(out T selectedObj)
		{
			if (!CTSSingleton<WorldSelector>.InstanceExists())
			{
				selectedObj = default(T);
				return null;
			}
			CTSSingleton<WorldSelector>.Instance.TryGetLastSelected<T>(out var obj, out var selectableObject);
			selectedObj = obj;
			return selectableObject;
		}

		private bool TryGetLastSelected<T>(out T obj, out SelectableObject selectableObject)
		{
			if (_currentSelectedList.Count <= 0)
			{
				return ReturnSelectionNull<T>(out obj, out selectableObject);
			}
			for (int num = _currentSelectedList.Count - 1; num >= 0; num--)
			{
				SelectableObject selectableObject2 = _currentSelectedList[num];
				Component component = (selectableObject2.SelectionTarget ? selectableObject2.SelectionTarget : selectableObject2);
				if (!(component == null) && component is T val)
				{
					obj = val;
					selectableObject = selectableObject2;
					return true;
				}
			}
			return ReturnSelectionNull<T>(out obj, out selectableObject);
		}

		private static bool ReturnSelectionNull<T>(out T obj, out SelectableObject selectableObject)
		{
			obj = default(T);
			selectableObject = null;
			return false;
		}

		public static void GetAllSelected(List<SelectableObject> list)
		{
			list.Clear();
			if (CTSSingleton<WorldSelector>.InstanceExists())
			{
				list.AddRange(CTSSingleton<WorldSelector>.Instance._currentSelectedList);
			}
		}

		public static void GetAllSelected<T>(List<T> list) where T : Component
		{
			list.Clear();
			if (!CTSSingleton<WorldSelector>.InstanceExists())
			{
				return;
			}
			foreach (SelectableObject currentSelected in CTSSingleton<WorldSelector>.Instance._currentSelectedList)
			{
				Component component = (currentSelected.SelectionTarget ? currentSelected.SelectionTarget : currentSelected);
				if (!(component == null) && component is T item)
				{
					list.Add(item);
				}
			}
		}

		public bool IsActive()
		{
			if (ObjectLock.IsUnlocked())
			{
				return CurrentSelectionMode != null;
			}
			return false;
		}

		private static bool IsPointerOverUI()
		{
			if (EventSystem.current == null)
			{
				return false;
			}
			return EventSystem.current.IsPointerOverGameObject();
		}

		private void SubscribeInputs()
		{
			if ((bool)_inputs)
			{
				_inputs.InputSelectPressed += OnSelectInput;
				_inputs.InputDeselectPressed += OnDeselectInput;
			}
		}

		private void UnsubscribeInputs()
		{
			if ((bool)_inputs)
			{
				_inputs.InputSelectPressed -= OnSelectInput;
				_inputs.InputDeselectPressed -= OnDeselectInput;
			}
		}

		private void OnSelectInput()
		{
			if (!ObjectLock.IsLocked() && !_changedSelectionModeThisFrame)
			{
				_inputSelectBuffer = true;
			}
		}

		private void OnDeselectInput()
		{
			if (!ObjectLock.IsLocked() && !_changedSelectionModeThisFrame)
			{
				_inputDeselectBuffer = true;
			}
		}

		private void HandleInput()
		{
			if (_inputSelectBuffer)
			{
				if (_inputDeselectBuffer)
				{
					OnBothInputsPressed();
				}
				else
				{
					OnSelectPressed();
				}
			}
			else if (_inputDeselectBuffer)
			{
				OnDeselectPressed();
			}
		}

		private void OnBothInputsPressed()
		{
			if ((object)_currentHovered == null || _currentSelectedList.Contains(_currentHovered))
			{
				OnDeselectPressed();
			}
			else
			{
				OnSelectPressed();
			}
		}

		private void OnSelectPressed()
		{
			SelectHovered(IsPressingMultipleSelection);
		}

		private void OnDeselectPressed()
		{
			if (CurrentSelectionMode.AllowMultipleSelection && IsPressingMultipleSelection && (bool)_currentHovered)
			{
				Deselect(_currentHovered);
			}
			else
			{
				DeselectAll();
			}
		}

		private void HoverCollider(Collider coll)
		{
			if (!coll.TryGetComponent<SelectableObject>(out var component) || !component.Selectable)
			{
				StopHoverCurrent();
			}
			else if (component == _currentHovered && !_currentHovered.Selectable)
			{
				StopHoverCurrent();
			}
			else if (!component.CanBeSelectedByMode(CurrentSelectionMode))
			{
				StopHoverCurrent();
			}
			else
			{
				SetHover(component);
			}
		}

		private void SetHover(SelectableObject selectable)
		{
			if (!(_currentHovered == selectable))
			{
				StopHoverCurrent();
				_currentHovered = selectable;
				_currentHovered.EnterHover(CurrentSelectionMode);
			}
		}

		private void StopHoverCurrent()
		{
			MousePositionWorldSpace = null;
			if ((bool)_currentHovered)
			{
				_currentHovered.ExitHover(CurrentSelectionMode);
			}
			_currentHovered = null;
		}

		private void SelectHovered(bool allowMultiple)
		{
			if (!(_currentHovered == null))
			{
				SelectObject(_currentHovered, allowMultiple);
			}
		}

		public static void SelectObject(SelectableObject selectableObject, bool allowMultiple = false, bool bypassMode = false)
		{
			if (selectableObject == null)
			{
				throw new NullReferenceException("Cannot select nothing.");
			}
			if (!CTSSingleton<WorldSelector>.TryGetInstance(out var instance))
			{
				throw new NullReferenceException("Cannot select anything because no World Selector exists.");
			}
			if (!instance._currentSelectedList.Contains(selectableObject) && (bypassMode || selectableObject.CanBeSelectedByMode(instance.CurrentSelectionMode)))
			{
				if (!allowMultiple || !instance.CurrentSelectionMode.AllowMultipleSelection)
				{
					DeselectAll();
				}
				instance._currentSelectedList.Add(selectableObject);
				selectableObject.Select(instance.CurrentSelectionMode);
				if ((object)selectableObject.SelectionTarget != null)
				{
					SendSelectionCallback(selectableObject.SelectionTarget);
				}
				else
				{
					SendSelectionCallback(selectableObject);
				}
			}
			void SendSelectionCallback(Component component)
			{
				foreach (var (type2, selectionAction2) in _selectionCallbacks)
				{
					if (type2.IsInstanceOfType(component))
					{
						selectionAction2.Invoke(component, selected: true);
					}
				}
				WorldSelector.AnyObjectSelected?.Invoke(component);
				WorldSelector.SelectionChanged?.Invoke(instance);
			}
		}

		public static void DeselectAll<T>()
		{
			if (CTSSingleton<WorldSelector>.InstanceExists())
			{
				WorldSelector instance = CTSSingleton<WorldSelector>.Instance;
				T obj;
				SelectableObject selectableObject;
				while (instance.TryGetLastSelected<T>(out obj, out selectableObject))
				{
					Deselect(selectableObject);
				}
			}
		}

		public static void DeselectAll()
		{
			if (!CTSSingleton<WorldSelector>.InstanceExists())
			{
				return;
			}
			List<SelectableObject> currentSelectedList = CTSSingleton<WorldSelector>.Instance._currentSelectedList;
			for (int num = currentSelectedList.Count - 1; num >= 0; num--)
			{
				SelectableObject selectedObject = currentSelectedList[num];
				int count = currentSelectedList.Count;
				Deselect(selectedObject);
				if (count == currentSelectedList.Count)
				{
					currentSelectedList.RemoveAt(num);
				}
			}
		}

		public static void Deselect(SelectableObject selectedObject)
		{
			if (!CTSSingleton<WorldSelector>.InstanceExists())
			{
				return;
			}
			WorldSelector instance = CTSSingleton<WorldSelector>.Instance;
			if ((object)selectedObject == null)
			{
				throw new NullReferenceException("Cannot deselect nothing.");
			}
			if (instance._currentSelectedList.Contains(selectedObject))
			{
				instance._currentSelectedList.Remove(selectedObject);
				selectedObject.Deselect(instance.CurrentSelectionMode);
				if ((object)selectedObject.SelectionTarget != null)
				{
					SendDeselectionCallback(selectedObject.SelectionTarget);
				}
				else
				{
					SendDeselectionCallback(selectedObject);
				}
			}
			void SendDeselectionCallback(Component component)
			{
				foreach (var (type2, selectionAction2) in _selectionCallbacks)
				{
					if (type2.IsInstanceOfType(component))
					{
						selectionAction2.Invoke(component, selected: false);
					}
				}
				WorldSelector.AnyObjectDeselected?.Invoke(component);
				WorldSelector.SelectionChanged?.Invoke(instance);
			}
		}

		void ILockable.OnLocked()
		{
			UnsubscribeInputs();
		}

		void ILockable.OnUnlocked()
		{
			SubscribeInputs();
		}

		public static void RegisterToSelection<T>(Action<T, bool> selectionCallback)
		{
			Type typeFromHandle = typeof(T);
			SelectionAction<T> action = SelectionAction<T>.GetAction();
			_selectionCallbacks.TryAdd(typeFromHandle, action);
			action.AddListener(selectionCallback);
		}

		public static void UnregisterToSelection<T>(Action<T, bool> selectionCallback)
		{
			Type typeFromHandle = typeof(T);
			if (_selectionCallbacks.ContainsKey(typeFromHandle))
			{
				SelectionAction<T> action = SelectionAction<T>.GetAction();
				action.RemoveListener(selectionCallback);
				if (action.IsEmpty)
				{
					_selectionCallbacks.Remove(typeFromHandle);
				}
			}
		}
	}
}
