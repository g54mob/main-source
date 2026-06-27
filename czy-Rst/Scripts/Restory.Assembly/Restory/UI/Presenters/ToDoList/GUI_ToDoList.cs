using DG.Tweening;
using Restory.Data.ToDoList;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.ToDoList;
using Restory.UI.Presenters.Notepad;
using Restory.UI.Presenters.PauseMenu;
using Restory.UI.Presenters.RegularPayment;
using Restory.UI.Views.ToDoList;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.ToDoList
{
	public sealed class GUI_ToDoList : MonoBehaviour
	{
		[SerializeField]
		private GUI_ToDoListView view;

		[SerializeField]
		[Min(0f)]
		private float autoShowHideDuration = 1f;

		[SerializeField]
		[Min(0f)]
		private float autoStartShowDelay = 1f;

		private bool injected;

		private bool subscribed;

		private ToDoListState state = ToDoListState.HiddenAll;

		private Sequence currentSequence;

		private TweenSequencesService tweenSequences;

		private ToDoListService toDoListService;

		private DisassembleStateMachine disassembleStateMachine;

		private GUI_NotepadWindow notepadWindow;

		private GUI_PauseMenu pauseMenu;

		private GUI_RegularPayment regularPayment;

		private bool pointerEnter;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences, ToDoListService toDoListService, DisassembleStateMachine disassembleStateMachine, GUI_NotepadWindow notepadWindow, GUI_PauseMenu pauseMenu, GUI_RegularPayment regularPayment)
		{
			this.tweenSequences = tweenSequences;
			this.toDoListService = toDoListService;
			this.disassembleStateMachine = disassembleStateMachine;
			this.notepadWindow = notepadWindow;
			this.pauseMenu = pauseMenu;
			this.regularPayment = regularPayment;
			injected = true;
			if (base.isActiveAndEnabled)
			{
				Subscribe();
			}
		}

		private void OnEnable()
		{
			if (injected)
			{
				Subscribe();
			}
			view.OnEnter += ResolveOnEnter;
			view.OnExit += ResolveOnExit;
		}

		private void OnDisable()
		{
			Unsubscribe();
			view.OnEnter -= ResolveOnEnter;
			view.OnExit -= ResolveOnExit;
		}

		private void SetToDoListState(ToDoListState state)
		{
			if (this.state != state)
			{
				this.state = state;
				switch (state)
				{
				case ToDoListState.Hidden:
					view.Hide(full: false);
					break;
				case ToDoListState.HiddenAll:
					view.Hide(full: true);
					break;
				case ToDoListState.Shown:
					view.Show();
					break;
				}
			}
		}

		private void UpdateToDoListState()
		{
			ToDoListState toDoListState = ((!toDoListService.IsActive || toDoListService.IsAllCompleted() || !(disassembleStateMachine.ActiveState is DisabledDisassembleState) || notepadWindow.IsVisible || pauseMenu.IsShown || regularPayment.IsVisible) ? ToDoListState.HiddenAll : (pointerEnter ? ToDoListState.Shown : ToDoListState.Hidden));
			SetToDoListState(toDoListState);
		}

		private void Subscribe()
		{
			if (!subscribed)
			{
				subscribed = true;
				if (toDoListService.MonoShellExists())
				{
					toDoListService.OnIsActiveChanged += ResolveOnIsActiveChanged;
					toDoListService.OnCompleted += ResolveOnCompleted;
					toDoListService.OnAdded += ResolveOnAdded;
					toDoListService.OnRemoved += ResolveOnRemoved;
				}
				if (disassembleStateMachine.MonoShellExists())
				{
					disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
				}
				if (notepadWindow.MonoShellExists())
				{
					notepadWindow.OnIsVisibleChanged += ResolveNotepadWindowOnIsVisibleChanged;
				}
				if (pauseMenu.MonoShellExists())
				{
					pauseMenu.OnIsShownChanged += ResolvePauseMenuOnIsShownChanged;
				}
				if (regularPayment.MonoShellExists())
				{
					regularPayment.OnIsVisibleChanged += ResolveRegularPaymentOnIsVisibleChanged;
				}
			}
		}

		private void Unsubscribe()
		{
			if (subscribed)
			{
				subscribed = false;
				if (toDoListService.MonoShellExists())
				{
					toDoListService.OnIsActiveChanged -= ResolveOnIsActiveChanged;
					toDoListService.OnCompleted -= ResolveOnCompleted;
					toDoListService.OnAdded -= ResolveOnAdded;
					toDoListService.OnRemoved -= ResolveOnRemoved;
				}
				if (disassembleStateMachine.MonoShellExists())
				{
					disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
				}
				if (notepadWindow.MonoShellExists())
				{
					notepadWindow.OnIsVisibleChanged -= ResolveNotepadWindowOnIsVisibleChanged;
				}
				if (pauseMenu.MonoShellExists())
				{
					pauseMenu.OnIsShownChanged -= ResolvePauseMenuOnIsShownChanged;
				}
				if (regularPayment.MonoShellExists())
				{
					regularPayment.OnIsVisibleChanged -= ResolveRegularPaymentOnIsVisibleChanged;
				}
			}
		}

		private void InitItems()
		{
			view.SetTitleInfo(toDoListService.Items.Count, toDoListService.CompletedItems.Count);
			view.ClearItems();
			foreach (ToDoItem item in toDoListService.Items)
			{
				if (!toDoListService.IsCompleted(item))
				{
					view.AddItem(item, instantly: true);
				}
			}
		}

		private void AddItem(ToDoItem item)
		{
			view.SetTitleInfo(toDoListService.Items.Count, toDoListService.CompletedItems.Count);
			view.AddItem(item, instantly: false);
		}

		private void RemoveItem(ToDoItem item)
		{
			view.SetTitleInfo(toDoListService.Items.Count, toDoListService.CompletedItems.Count);
			view.RemoveItem(item);
		}

		private void CompleteItem(ToDoItem item)
		{
			view.SetTitleInfo(toDoListService.Items.Count, toDoListService.CompletedItems.Count);
			view.CompleteItem(item);
		}

		private void StartCompleteAnim(ToDoItem item)
		{
			CancelAnim();
			currentSequence = tweenSequences.Create();
			currentSequence.AppendCallback(delegate
			{
				SetToDoListState(ToDoListState.Shown);
			}).AppendInterval(view.ShowHideDuration).AppendCallback(delegate
			{
				CompleteItem(item);
				currentSequence.OnKill(null);
			})
				.AppendInterval(autoShowHideDuration)
				.AppendCallback(delegate
				{
					UpdateToDoListState();
				})
				.OnComplete(delegate
				{
					currentSequence = null;
				})
				.OnKill(delegate
				{
					CompleteItem(item);
				});
		}

		private void StartAddAnim(ToDoItem item)
		{
			CancelAnim();
			currentSequence = tweenSequences.Create();
			currentSequence.AppendCallback(delegate
			{
				SetToDoListState(ToDoListState.Shown);
			}).AppendInterval(view.ShowHideDuration).AppendCallback(delegate
			{
				AddItem(item);
				currentSequence.OnKill(null);
			})
				.AppendInterval(autoShowHideDuration)
				.AppendCallback(delegate
				{
					UpdateToDoListState();
				})
				.OnComplete(delegate
				{
					currentSequence = null;
				})
				.OnKill(delegate
				{
					AddItem(item);
				});
		}

		private void StartInitShow()
		{
			CancelAnim();
			currentSequence = tweenSequences.Create();
			currentSequence.AppendInterval(autoStartShowDelay).AppendCallback(delegate
			{
				SetToDoListState(ToDoListState.Shown);
			}).AppendInterval(autoShowHideDuration)
				.AppendCallback(delegate
				{
					UpdateToDoListState();
				})
				.OnComplete(delegate
				{
					currentSequence = null;
				});
		}

		private void CancelAnim()
		{
			if (currentSequence != null)
			{
				tweenSequences.Kill(currentSequence);
				currentSequence = null;
			}
		}

		private void ResolveOnIsActiveChanged(ToDoListService service)
		{
			if (service.IsActive)
			{
				if (!toDoListService.IsAllCompleted())
				{
					InitItems();
					StartInitShow();
				}
			}
			else
			{
				CancelAnim();
				SetToDoListState(ToDoListState.HiddenAll);
			}
		}

		private void ResolveOnAdded(ToDoListService service, ToDoItem item)
		{
			if (service.IsActive && !service.IsCompleted(item))
			{
				StartAddAnim(item);
			}
		}

		private void ResolveOnRemoved(ToDoListService service, ToDoItem item)
		{
			if (service.IsActive)
			{
				RemoveItem(item);
			}
		}

		private void ResolveOnCompleted(ToDoListService service, ToDoItem item)
		{
			if (service.IsActive)
			{
				StartCompleteAnim(item);
			}
		}

		private void ResolveDisassembleStateChanged()
		{
			CancelAnim();
			UpdateToDoListState();
		}

		private void ResolveNotepadWindowOnIsVisibleChanged()
		{
			CancelAnim();
			UpdateToDoListState();
		}

		private void ResolvePauseMenuOnIsShownChanged(GUI_PauseMenu pauseMenu, bool isShown)
		{
			CancelAnim();
			UpdateToDoListState();
		}

		private void ResolveRegularPaymentOnIsVisibleChanged()
		{
			CancelAnim();
			UpdateToDoListState();
		}

		private void ResolveOnEnter(GUI_ToDoListView view)
		{
			pointerEnter = true;
			CancelAnim();
			UpdateToDoListState();
		}

		private void ResolveOnExit(GUI_ToDoListView view)
		{
			pointerEnter = false;
			CancelAnim();
			UpdateToDoListState();
		}
	}
}
