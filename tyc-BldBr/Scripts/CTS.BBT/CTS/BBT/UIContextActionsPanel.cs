using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS.BBT
{
	public class UIContextActionsPanel : UICanvasGroup
	{
		private enum EWorkerStatus
		{
			Normal = 0,
			Walking = 1,
			Occupied = 2
		}

		private Worker _currentWorker;

		private IContextActor _currentContextActor;

		private ContextualActions _currentContextActions;

		[SerializeField]
		private RectTransform _contentAnchor;

		[SerializeField]
		private int _maxButtons = 5;

		[SerializeField]
		private bool _debug;

		[SerializeField]
		private float _buttonDistance = 1f;

		[SerializeField]
		private float _constraintX = 500f;

		[SerializeField]
		private float _constraintY = 400f;

		private object _currentSelection;

		private UIContextActionsButton _buttonPrefab;

		private List<UIContextActionsButton> _buttons = new List<UIContextActionsButton>();

		private readonly List<Worker> _sortedWorkerList = new List<Worker>();

		protected override void Awake()
		{
			base.Awake();
			_buttonPrefab = _contentAnchor.GetComponentInChildren<UIContextActionsButton>(includeInactive: true);
			_buttonPrefab.gameObject.SetActive(value: false);
			for (int i = 0; i < _maxButtons; i++)
			{
				_buttons.Add(Object.Instantiate(_buttonPrefab, _contentAnchor));
				_buttons[i].gameObject.SetActive(value: false);
			}
			EventsManager.OnRightClickContextActor += OnContextActor;
			InputManager.game.unselect.onComplete += OnInputUnselect;
			WorldSelector.RegisterToSelection<Worker>(OnWorkerSelectionChanged);
			SetActive(p_state: false);
		}

		private void OnDestroy()
		{
			EventsManager.OnRightClickContextActor -= OnContextActor;
			InputManager.game.unselect.onComplete -= OnInputUnselect;
			WorldSelector.UnregisterToSelection<Worker>(OnWorkerSelectionChanged);
		}

		private void OnInputUnselect(InputAction.CallbackContext ctx)
		{
			if (!WorldSelector.PointerIsOverUI && base.IsActive)
			{
				SetActive(p_state: false);
			}
		}

		protected override void OnUIDisabled()
		{
			base.OnUIDisabled();
			_currentContextActor = null;
			_currentContextActions = null;
		}

		private void UpdateButtons()
		{
			_sortedWorkerList.Clear();
			MonoBehaviour monoBehaviour = (MonoBehaviour)_currentContextActor;
			WorkerList.Get(_sortedWorkerList);
			_sortedWorkerList.Sort(MonoBehaviourDistanceComparer.Get(monoBehaviour.transform.position, 4f));
			int buttonIndex = 0;
			InitButtonsForChores(ref buttonIndex);
			InitButtonsForContextualActions(ref buttonIndex);
			if (buttonIndex == 0)
			{
				SetActive(p_state: false);
				return;
			}
			DisableSuperfluousButtons(buttonIndex);
			SetActive(p_state: true);
			UpdateButtonPositions(buttonIndex);
			if (!_currentWorker)
			{
				SelectableObject componentInChildren = monoBehaviour.GetComponentInChildren<SelectableObject>(includeInactive: false);
				if ((bool)componentInChildren)
				{
					WorldSelector.SelectObject(componentInChildren);
				}
			}
		}

		private void UpdateButtonPositions(int p_count)
		{
			Vector2 mousePositionScreenSpace = WorldSelector.MousePositionScreenSpace;
			mousePositionScreenSpace.x = mousePositionScreenSpace.x.Remap(0f, Screen.width, -1920f, 1920f);
			mousePositionScreenSpace.y = mousePositionScreenSpace.y.Remap(0f, Screen.height, -1080f, 1080f);
			Vector3 p_center = mousePositionScreenSpace.ToScreenPoint();
			float num = _buttonDistance * (float)p_count;
			bool flag = p_center.x < -1920f + _constraintX;
			bool flag2 = p_center.x > 1920f - _constraintX;
			bool flag3 = p_center.y < -1080f + _constraintY;
			bool flag4 = p_center.y > 1080f - _constraintY;
			bool flag5 = flag || flag2;
			bool flag6 = flag3 || flag4;
			float num2 = 360f;
			if (flag5 ^ flag6)
			{
				num2 = 150f;
				num *= 1.5f;
			}
			else if (flag5 && flag6)
			{
				num2 = 80f;
				num *= 2f;
			}
			float num3 = num2 / (float)(((flag5 || flag6) && p_count > 1) ? (p_count - 1) : p_count);
			float num4;
			if (flag5 || flag6)
			{
				num4 = ((flag && flag3) ? 315f : ((flag && flag4) ? 225f : ((flag2 && flag4) ? 135f : ((flag2 && flag3) ? 405f : (flag ? 270f : (flag4 ? 180f : ((!flag2) ? 360f : 90f)))))));
				if (p_count > 1)
				{
					num4 += num2 * 0.5f;
				}
			}
			else
			{
				num4 = 360f;
			}
			for (int i = 0; i < p_count; i++)
			{
				_buttons[i].UpdatePosition(p_center, num4 - num3 * (float)i, num);
			}
		}

		private void InitButtonsForContextualActions(ref int buttonIndex)
		{
			if (!_currentContextActions)
			{
				return;
			}
			foreach (ContextualAction action in _currentContextActions.Actions)
			{
				if (IsIndexOutOfRange(buttonIndex))
				{
					break;
				}
				if (!action.IsAuthorized())
				{
					continue;
				}
				Worker worker = _currentWorker;
				if (action.IsWorkerAction && worker == null)
				{
					if (!action.CanBeExecutedWithoutWorker())
					{
						continue;
					}
					worker = FindSuitableWorker(action, out var performable);
					if (worker == null)
					{
						if (performable)
						{
							InitButton(ref buttonIndex, worker, action, interactable: false);
						}
						continue;
					}
				}
				if (action.CanBePerformed(worker))
				{
					InitButton(ref buttonIndex, worker, action, interactable: true);
				}
				else if (action.ShowAlways())
				{
					InitButton(ref buttonIndex, worker, action, interactable: false);
				}
			}
		}

		private Worker FindSuitableWorker(IPerformable<Agent> action, out bool performable)
		{
			performable = false;
			Worker worker = null;
			foreach (Worker sortedWorker in _sortedWorkerList)
			{
				Worker worker2 = sortedWorker;
				if (!action.CanBePerformedBy(worker2))
				{
					continue;
				}
				performable = true;
				EWorkerStatus eWorkerStatus = GetWorkerValidity();
				if (eWorkerStatus != EWorkerStatus.Occupied)
				{
					if (eWorkerStatus != EWorkerStatus.Walking || (object)worker != null)
					{
						return worker2;
					}
					worker = worker2;
				}
				EWorkerStatus GetWorkerValidity()
				{
					if (!worker2.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
					{
						return EWorkerStatus.Occupied;
					}
					if (worker2.ActionPlayer.CurrentAction == null)
					{
						return EWorkerStatus.Normal;
					}
					if (worker2.ActionPlayer.CurrentAction.Status > AgentAction.EStatus.Wait)
					{
						return EWorkerStatus.Occupied;
					}
					return EWorkerStatus.Walking;
				}
			}
			return worker;
		}

		private void InitButtonsForChores(ref int buttonIndex)
		{
			if (_currentContextActor == null)
			{
				return;
			}
			foreach (WorkerChore associatedChore in _currentContextActor.ContextActorData.AssociatedChores)
			{
				if (IsIndexOutOfRange(buttonIndex))
				{
					break;
				}
				if (!associatedChore.VisibleInContextualMenu || associatedChore.Status > AgentAction.EStatus.InProgress || !associatedChore.IsAuthorized())
				{
					continue;
				}
				Worker worker = _currentWorker;
				if (worker == null)
				{
					if (!associatedChore.CanBePerformedWithoutSelectedWorker())
					{
						continue;
					}
					worker = FindSuitableWorker(associatedChore, out var performable);
					if (worker == null)
					{
						if (performable)
						{
							InitButton(ref buttonIndex, worker, associatedChore, interactable: false);
						}
						continue;
					}
				}
				if (associatedChore.CanBePerformed(worker))
				{
					InitButton(ref buttonIndex, worker, associatedChore, interactable: true);
				}
				else if (!associatedChore.DisableIfImpossible)
				{
					InitButton(ref buttonIndex, worker, associatedChore, interactable: false);
				}
			}
		}

		private void InitButton(ref int buttonIndex, Worker worker, WorkerChore action, bool interactable)
		{
			_buttons[buttonIndex].Init(worker, action, buttonIndex);
			_buttons[buttonIndex].Interactable = interactable;
			buttonIndex++;
		}

		private void InitButton(ref int buttonIndex, Worker worker, ContextualAction action, bool interactable)
		{
			_buttons[buttonIndex].Init(worker, action, buttonIndex);
			_buttons[buttonIndex].Interactable = interactable;
			buttonIndex++;
		}

		private bool IsIndexOutOfRange(int p_index)
		{
			return p_index > _maxButtons - 1;
		}

		private void DisableSuperfluousButtons(int p_currentButtonIndex)
		{
			while (p_currentButtonIndex < _maxButtons)
			{
				_buttons[p_currentButtonIndex].gameObject.SetActive(value: false);
				p_currentButtonIndex++;
			}
		}

		private void OnContextActor(IContextActor p_contextActor)
		{
			if (p_contextActor is MonoBehaviour monoBehaviour && monoBehaviour.TryGetComponent<ContextualActions>(out var component))
			{
				_currentContextActions = component;
			}
			else
			{
				_currentContextActions = null;
			}
			_currentContextActor = p_contextActor;
			if (p_contextActor.ContextActorData.ChoresCount > 0 || ((bool)_currentContextActions && _currentContextActions.Actions.Count > 0))
			{
				UpdateButtons();
			}
		}

		private void OnWorkerSelectionChanged(Worker worker, bool selected)
		{
			if ((bool)_currentWorker && !selected)
			{
				if (worker == _currentWorker)
				{
					SetActive(p_state: false);
					_currentWorker = null;
				}
			}
			else
			{
				_currentWorker = worker;
			}
		}
	}
}
