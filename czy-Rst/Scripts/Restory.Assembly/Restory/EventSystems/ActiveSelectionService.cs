using System;
using System.Collections.Generic;
using Restory.Infrastructure.CommonServices;
using Restory.Utils;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Restory.EventSystems
{
	public class ActiveSelectionService : SerializedMonoBehaviour, IDisposable
	{
		[SerializeField]
		private bool clearNonValidationSelection;

		[SerializeField]
		private bool canRestoreSelection = true;

		[SerializeField]
		private bool restoreLastSelection;

		private GameObject currentSelection;

		private GameObject lastSelection;

		private EventSystem eventSystem;

		private ControlsManager controlsManager;

		private readonly HashSet<IPrioritizedSelection> firstSelections = new HashSet<IPrioritizedSelection>();

		private BaseEventData baseEventData;

		public ICollection<IPrioritizedSelection> FirstSelection => firstSelections;

		public GameObject CurrentSelection
		{
			get
			{
				if (!(eventSystem != null))
				{
					return null;
				}
				return eventSystem.currentSelectedGameObject;
			}
		}

		public GameObject LastSelection => lastSelection;

		public bool CanRestoreCurrentSelection
		{
			get
			{
				return canRestoreSelection;
			}
			set
			{
				canRestoreSelection = value;
			}
		}

		public bool RestoreLastSelection
		{
			get
			{
				return restoreLastSelection;
			}
			set
			{
				restoreLastSelection = value;
			}
		}

		public event Action<GameObject> CurrentSelectionChanged = delegate
		{
		};

		[Inject]
		private void Construct(ControlsManager controlsManager, EventSystem eventSystem)
		{
			this.eventSystem = eventSystem;
			this.controlsManager = controlsManager;
			if (base.isActiveAndEnabled)
			{
				OnEnable();
			}
		}

		private void OnEnable()
		{
			if ((bool)controlsManager)
			{
				controlsManager.OnControlsTypeChanged += ResolveOnControlsTypeChanged;
			}
		}

		private void OnDisable()
		{
			if (controlsManager.MonoShellExists())
			{
				controlsManager.OnControlsTypeChanged -= ResolveOnControlsTypeChanged;
			}
		}

		private void Update()
		{
			if ((bool)controlsManager)
			{
				UpdateCurrentSelectedGameObject();
				if (clearNonValidationSelection)
				{
					ClearNonValidationSelection();
				}
				if (canRestoreSelection)
				{
					RestoreCurrentSelection(restoreLastSelection);
				}
			}
		}

		public void Select(GameObject value)
		{
			if (CanSelect())
			{
				SetSelectedGameObject(value);
			}
		}

		public void ClearSelection()
		{
			SetSelectedGameObject(null);
		}

		private void ClearNonValidationSelection()
		{
			if (!ValidateGameObject(CurrentSelection))
			{
				ClearSelection();
			}
		}

		private void RestoreCurrentSelection(bool useLastSelection)
		{
			if (!HasSelection() && CanSelect())
			{
				GameObject firstSelection = GetFirstSelection();
				if (ValidateGameObject(firstSelection))
				{
					SetSelectedGameObject(firstSelection);
				}
				else if (useLastSelection && ValidateGameObject(lastSelection))
				{
					SetSelectedGameObject(lastSelection);
				}
			}
		}

		public GameObject GetCurrentSelection()
		{
			if (!(eventSystem != null))
			{
				return null;
			}
			return eventSystem.currentSelectedGameObject;
		}

		public GameObject GetCurrentOrLastSelection()
		{
			GameObject gameObject = CurrentSelection;
			if (!(gameObject == null))
			{
				return gameObject;
			}
			return lastSelection;
		}

		public bool HasSelection()
		{
			return eventSystem.currentSelectedGameObject != null;
		}

		public bool CanSelect()
		{
			if (IsGamepadActive())
			{
				return !eventSystem.alreadySelecting;
			}
			return false;
		}

		private bool IsGamepadActive()
		{
			if ((bool)controlsManager)
			{
				return controlsManager.ControlType == InputControlsType.Joystick;
			}
			return false;
		}

		private bool ValidateGameObject(GameObject value)
		{
			if (value != null)
			{
				return value.activeInHierarchy;
			}
			return false;
		}

		public void RegisterFirstSelection(IPrioritizedSelection value)
		{
			firstSelections.Add(value);
		}

		public bool UnregisterFirstSelection(IPrioritizedSelection value)
		{
			return firstSelections.Remove(value);
		}

		public GameObject GetFirstSelection()
		{
			GameObject result = null;
			NavigationPriority navigationPriority = NavigationPriority.None;
			foreach (IPrioritizedSelection firstSelection in firstSelections)
			{
				if (firstSelection != null && ValidateGameObject(firstSelection.TargetNavigation) && firstSelection.Priority > navigationPriority)
				{
					navigationPriority = firstSelection.Priority;
					result = firstSelection.TargetNavigation;
				}
			}
			return result;
		}

		private void SetSelectedGameObject(GameObject value)
		{
			if (eventSystem == null)
			{
				Debug.LogError("SetSelectedGameObject called but eventSystem is null! Value: " + ((value != null) ? value.name : "null") + ", " + string.Format("{0} exists: {1}", "controlsManager", controlsManager != null));
			}
			else if (!(eventSystem.currentSelectedGameObject == value))
			{
				eventSystem.SetSelectedGameObject(value, GetBaseEventData());
				UpdateCurrentSelectedGameObject();
			}
		}

		private void UpdateCurrentSelectedGameObject()
		{
			if ((bool)eventSystem && !(currentSelection == eventSystem.currentSelectedGameObject))
			{
				if (currentSelection != null)
				{
					lastSelection = currentSelection;
				}
				currentSelection = eventSystem.currentSelectedGameObject;
				this.CurrentSelectionChanged?.Invoke(currentSelection);
			}
		}

		private void ResolveOnControlsTypeChanged(InputControlsType controlsType)
		{
			ClearSelection();
			if (canRestoreSelection)
			{
				RestoreCurrentSelection(restoreLastSelection);
			}
		}

		private BaseEventData GetBaseEventData()
		{
			if (baseEventData == null)
			{
				baseEventData = new BaseEventData(eventSystem);
			}
			baseEventData.Reset();
			return baseEventData;
		}

		public void Dispose()
		{
			this.CurrentSelectionChanged = null;
			if (controlsManager.MonoShellExists())
			{
				controlsManager.OnControlsTypeChanged -= ResolveOnControlsTypeChanged;
			}
			firstSelections.Clear();
		}
	}
}
