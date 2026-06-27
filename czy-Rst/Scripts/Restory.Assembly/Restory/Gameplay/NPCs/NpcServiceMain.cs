using System;
using System.Collections;
using RSG;
using Restory.Data.Microstories;
using Restory.Data.NPCs;
using Restory.Gameplay.Common;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.OverlayActivators;
using Restory.Gameplay.TimeSystems;
using Restory.Gameplay.Work.StateMachine;
using Restory.Infrastructure.StateMachine;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.NPCs
{
	public class NpcServiceMain : MonoBehaviour, IActiveStateSwitchRequester
	{
		private class NpcInScene
		{
			public INpcInfo Info;
		}

		[SerializeField]
		private NpcDialogueInteractionService npcDialogueInteractionService;

		private NpcCreationService npcCreator;

		private GameCalendar gameCalendar;

		private GlobalStateMachine globalStateMachine;

		private WorkStateMachine workStateMachine;

		private NpcMovementAnimator npcMovementAnimator;

		private NpcTextureSwitcher npcTextureSwitcher;

		private NpcInScene currentNPC;

		private Coroutine doCallbackWhenInteractionIsPossibleCoroutine;

		private Coroutine doCallbackWhenTimeIsUpCoroutine;

		private Promise<bool> npcArrivedAtInteractionPointPromise;

		private Promise<bool> waitForPlayerInteractionPromise;

		private WindowShuttersStoreInteractiveItem windowShuttersStoreInteractiveItem;

		private PcActivator pcActivator;

		private InventoryActivator inventoryActivator;

		public INpcInfo CurrentNpc => currentNPC?.Info;

		public CurrentVisitState CurrentVisitState { get; private set; }

		public event Action OnVisitStarted;

		public event Action OnVisitEnded;

		public event Action OnNpcArrivedAtStoreWindow;

		public event Action OnBeforeNpcStartedMovingToExit;

		[Inject]
		private void Construct(NpcCreationService npcCreationService, GameCalendar gameCalendar, GlobalStateMachine globalStateMachine, WorkStateMachine workStateMachine, NpcMovementAnimator npcMovementAnimator, NpcTextureSwitcher npcTextureSwitcher, WindowShuttersStoreInteractiveItem windowShuttersStoreInteractiveItem, PcActivator pcActivator, InventoryActivator inventoryActivator)
		{
			this.npcTextureSwitcher = npcTextureSwitcher;
			this.gameCalendar = gameCalendar;
			npcCreator = npcCreationService;
			this.workStateMachine = workStateMachine;
			this.globalStateMachine = globalStateMachine;
			this.npcMovementAnimator = npcMovementAnimator;
			this.windowShuttersStoreInteractiveItem = windowShuttersStoreInteractiveItem;
			this.pcActivator = pcActivator;
			this.inventoryActivator = inventoryActivator;
		}

		public bool TryToStartNpcVisitWithInteraction(INpcInfo npcInfo, string npcStartingTextureId = "", Action onInteractionStartedCallback = null, Action onNpcStartedMovingToExitCallback = null, Action onVisitCompletedCallback = null)
		{
			CurrentVisitState = CurrentVisitState.NoVisitInProgress;
			if (workStateMachine.ActiveState is DraggingWorkState)
			{
				return false;
			}
			StoryNpcInfo storyNpcInfo = npcInfo as StoryNpcInfo;
			if (!TryToSpawnNPC(storyNpcInfo, npcStartingTextureId))
			{
				return false;
			}
			Debug.Log("NPC is starting a visit with possible interaction");
			CurrentVisitState = CurrentVisitState.VisitWithInteraction_Starting;
			windowShuttersStoreInteractiveItem.BlockWindow(this);
			MoveNpcToStoreWindow(storyNpcInfo).Then(delegate(bool hasNpcReachedTheWindowBeforeHavingToLeave)
			{
				Debug.Log("Npc reached store window");
				if (hasNpcReachedTheWindowBeforeHavingToLeave)
				{
					Debug.Log("and has time to interact");
					CurrentVisitState = CurrentVisitState.VisitWithInteraction_WaitingForInteraction;
					this.OnNpcArrivedAtStoreWindow?.Invoke();
					return WaitForInteractionPossibility();
				}
				return Promise<bool>.Resolved(promisedValue: false);
			}).Then(delegate(bool wasInteractionInitiated)
			{
				if (wasInteractionInitiated)
				{
					Debug.Log("Npc is starting a conversation");
					CurrentVisitState = CurrentVisitState.VisitWithInteraction_InteractionInProgress;
					onInteractionStartedCallback?.Invoke();
					return TalkToNpc();
				}
				Debug.Log("NPC cannot wait any longer and has to leave");
				return Promise.Resolved();
			}).Then(delegate
			{
				Debug.Log("NPC started leaving");
				CurrentVisitState = CurrentVisitState.VisitWithInteraction_Ending;
				onNpcStartedMovingToExitCallback?.Invoke();
				this.OnBeforeNpcStartedMovingToExit?.Invoke();
				return MoveNpcToExit();
			})
				.Then((Action)DespawnNpc)
				.Finally(delegate
				{
					if (windowShuttersStoreInteractiveItem.MonoShellExists())
					{
						windowShuttersStoreInteractiveItem.UnblockWindow(this);
					}
					Debug.Log("NPC left");
					CurrentVisitState = CurrentVisitState.NoVisitInProgress;
					onVisitCompletedCallback?.Invoke();
					this.OnVisitEnded?.Invoke();
				})
				.Done();
			this.OnVisitStarted?.Invoke();
			return true;
		}

		public bool TryToStartNpcVisitWithoutInteractionSegment(INpcInfo npcInfo, string npcStartingTextureId = "", Action onReachedStoreWindowCallback = null, Action onNpcStartedMovingToExitCallback = null, Action onVisitCompletedCallback = null)
		{
			CurrentVisitState = CurrentVisitState.NoVisitInProgress;
			if (workStateMachine.ActiveState is DraggingWorkState)
			{
				return false;
			}
			StoryNpcInfo storyNpcInfo = npcInfo as StoryNpcInfo;
			if (!TryToSpawnNPC(storyNpcInfo, npcStartingTextureId))
			{
				return false;
			}
			Debug.Log("NPC is starting a visit with no interaction");
			CurrentVisitState = CurrentVisitState.VisitWithNoInteraction_Starting;
			windowShuttersStoreInteractiveItem.BlockWindow(this);
			MoveNpcToStoreWindow(storyNpcInfo).Then(delegate(bool hasNpcReachedTheWindowBeforeHavingToLeave)
			{
				Debug.Log("NPC reached window");
				if (hasNpcReachedTheWindowBeforeHavingToLeave)
				{
					Debug.Log("and can grab whatever is on the counter");
					onReachedStoreWindowCallback?.Invoke();
					this.OnNpcArrivedAtStoreWindow?.Invoke();
				}
				return Promise.Resolved();
			}).Then(delegate
			{
				Debug.Log("NPC is starting to leave");
				CurrentVisitState = CurrentVisitState.VisitWithNoInteraction_Ending;
				onNpcStartedMovingToExitCallback?.Invoke();
				this.OnBeforeNpcStartedMovingToExit?.Invoke();
				return MoveNpcToExit();
			}).Then((Action)DespawnNpc)
				.Finally(delegate
				{
					Debug.Log("NPC left");
					CurrentVisitState = CurrentVisitState.NoVisitInProgress;
					if (windowShuttersStoreInteractiveItem.MonoShellExists())
					{
						windowShuttersStoreInteractiveItem.UnblockWindow(this);
					}
					onVisitCompletedCallback?.Invoke();
					this.OnVisitEnded?.Invoke();
				})
				.Done();
			this.OnVisitStarted?.Invoke();
			return true;
		}

		public void ForceStopCurrentNpcVisit()
		{
			if (doCallbackWhenTimeIsUpCoroutine != null)
			{
				StopCoroutine(doCallbackWhenTimeIsUpCoroutine);
				doCallbackWhenTimeIsUpCoroutine = null;
			}
			if (doCallbackWhenInteractionIsPossibleCoroutine != null)
			{
				StopCoroutine(doCallbackWhenInteractionIsPossibleCoroutine);
				doCallbackWhenInteractionIsPossibleCoroutine = null;
			}
			if (currentNPC != null)
			{
				Promise<bool> promise = npcArrivedAtInteractionPointPromise;
				if (promise != null && promise.CurState == PromiseState.Pending)
				{
					npcArrivedAtInteractionPointPromise.Resolve(value: false);
				}
				promise = waitForPlayerInteractionPromise;
				if (promise != null && promise.CurState == PromiseState.Pending)
				{
					waitForPlayerInteractionPromise.Resolve(value: false);
				}
			}
		}

		public void ChangeCurrentNpcTexture(string newTextureID)
		{
			NpcInScene npcInScene = currentNPC;
			if (npcInScene != null && npcInScene.Info is StoryNpcInfo storyNpcInfo)
			{
				npcTextureSwitcher.SetNpcTexture(storyNpcInfo.GetTextureByIdOrDefaultTexture(newTextureID));
			}
		}

		private bool CanSpawnNPC()
		{
			return currentNPC == null;
		}

		private bool TryToSpawnNPC(StoryNpcInfo npcInfo, string npcTextureId = "")
		{
			if (npcInfo == null || !CanSpawnNPC())
			{
				return false;
			}
			npcTextureSwitcher.SetNpcTexture(npcInfo.GetTextureByIdOrDefaultTexture(npcTextureId));
			currentNPC = new NpcInScene
			{
				Info = npcInfo
			};
			return true;
		}

		private bool TryToSpawnNPC(MicroStoryInfo microStoryInfo)
		{
			if (microStoryInfo == null || !CanSpawnNPC())
			{
				return false;
			}
			npcCreator.CreateNPC(microStoryInfo, null, out var generatedNpcInfo);
			currentNPC = new NpcInScene
			{
				Info = generatedNpcInfo
			};
			return true;
		}

		private IPromise TalkToNpc()
		{
			Promise dialogueEndedPromise = new Promise();
			string conversationToStart = ((currentNPC.Info is StoryNpcInfo storyNpcInfo) ? storyNpcInfo.DialogueActorLogicCenterConversation : string.Empty);
			workStateMachine.Enter<DialogueWorkState>();
			npcDialogueInteractionService.StartDialogue(conversationToStart, delegate
			{
				workStateMachine.Enter<DetectionWorkState>();
				if (dialogueEndedPromise.CurState == PromiseState.Pending)
				{
					dialogueEndedPromise.Resolve();
				}
			});
			return dialogueEndedPromise;
		}

		private IPromise<bool> MoveNpcToStoreWindow(StoryNpcInfo storyNpcInfo)
		{
			npcArrivedAtInteractionPointPromise = new Promise<bool>();
			NpcMovementOptions movementDirectionOption = storyNpcInfo.SpawnAndExitPoints switch
			{
				NpcSpawnAndExitPoints.Default => NpcMovementOptions.RightToLeft, 
				NpcSpawnAndExitPoints.AboveStore => NpcMovementOptions.FromAboveAndBackUp, 
				_ => throw new NotImplementedException(), 
			};
			npcMovementAnimator.StartMovingNpcToStoreWindow(movementDirectionOption, delegate
			{
				if (npcArrivedAtInteractionPointPromise.CurState == PromiseState.Pending)
				{
					npcArrivedAtInteractionPointPromise.Resolve(value: true);
				}
			});
			return npcArrivedAtInteractionPointPromise;
		}

		private IPromise MoveNpcToExit()
		{
			Promise npcArrivedAtExitPointPromise = new Promise();
			npcMovementAnimator.StartMovingNpcFromStoreWindow(delegate
			{
				if (npcArrivedAtExitPointPromise.CurState == PromiseState.Pending)
				{
					npcArrivedAtExitPointPromise.Resolve();
				}
			});
			return npcArrivedAtExitPointPromise;
		}

		private IPromise<bool> WaitForInteractionPossibility()
		{
			Promise<bool> playerBecameReadyForInteractionPromise = new Promise<bool>();
			if (doCallbackWhenInteractionIsPossibleCoroutine != null)
			{
				StopCoroutine(doCallbackWhenInteractionIsPossibleCoroutine);
			}
			if (doCallbackWhenTimeIsUpCoroutine != null)
			{
				StopCoroutine(doCallbackWhenTimeIsUpCoroutine);
			}
			Promise<bool> promise = new Promise<bool>(delegate(Action<bool> resolve, Action<Exception> reject)
			{
				doCallbackWhenInteractionIsPossibleCoroutine = StartCoroutine(DoCallbackWhenInteractionIsPossibleCoroutine(delegate
				{
					resolve(obj: true);
				}));
			});
			waitForPlayerInteractionPromise = new Promise<bool>();
			Promise<bool>.Race(promise, waitForPlayerInteractionPromise).Then(delegate(bool resolvedBoolResult)
			{
				playerBecameReadyForInteractionPromise.Resolve(resolvedBoolResult);
			}).Catch(delegate(Exception ex)
			{
				playerBecameReadyForInteractionPromise.Reject(ex);
			});
			return playerBecameReadyForInteractionPromise;
		}

		private IEnumerator DoCallbackWhenTimeIsUpCoroutine(TimeSpan waitTime, Action callback)
		{
			DateTime timeOutTime = gameCalendar.CurrentDateTime + waitTime;
			while (gameCalendar.CurrentDateTime < timeOutTime)
			{
				yield return null;
			}
			if (doCallbackWhenInteractionIsPossibleCoroutine != null)
			{
				StopCoroutine(doCallbackWhenInteractionIsPossibleCoroutine);
				doCallbackWhenInteractionIsPossibleCoroutine = null;
			}
			doCallbackWhenTimeIsUpCoroutine = null;
			callback?.Invoke();
		}

		private IEnumerator DoCallbackWhenInteractionIsPossibleCoroutine(Action callback)
		{
			while (!IsInteractionPossible())
			{
				yield return null;
			}
			if (doCallbackWhenTimeIsUpCoroutine != null)
			{
				StopCoroutine(doCallbackWhenTimeIsUpCoroutine);
				doCallbackWhenTimeIsUpCoroutine = null;
			}
			doCallbackWhenInteractionIsPossibleCoroutine = null;
			callback?.Invoke();
		}

		private bool IsInteractionPossible()
		{
			if (globalStateMachine.IsInGameLoop && workStateMachine.ActiveState is DetectionWorkState && !pcActivator.IsActivated)
			{
				return !inventoryActivator.IsActivated;
			}
			return false;
		}

		private void DespawnNpc()
		{
			currentNPC = null;
		}
	}
}
