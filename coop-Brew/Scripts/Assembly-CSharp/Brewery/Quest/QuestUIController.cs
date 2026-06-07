using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.NPC.TradingSystem;
using Brewery.Stand;
using Favors;
using InventorySystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.Quest
{
	public class QuestUIController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAnimateSlideIn_003Ed__89 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VisualElement element;

			public QuestUIController _003C_003E4__this;

			private float _003Celapsed_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CAnimateSlideIn_003Ed__89(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CAnimateSlideOut_003Ed__90 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VisualElement element;

			public QuestUIController _003C_003E4__this;

			private float _003Celapsed_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CAnimateSlideOut_003Ed__90(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CFavorProgressRefreshCoroutine_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuestUIController _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CFavorProgressRefreshCoroutine_003Ed__59(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CFavorTransitionCoroutine_003Ed__61 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuestUIController _003C_003E4__this;

			public FavorRequest favor;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CFavorTransitionCoroutine_003Ed__61(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CHidePanelCoroutine_003Ed__88 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuestUIController _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CHidePanelCoroutine_003Ed__88(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CProgressRefreshCoroutine_003Ed__81 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuestUIController _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CProgressRefreshCoroutine_003Ed__81(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CShowPanelCoroutine_003Ed__86 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuestUIController _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CShowPanelCoroutine_003Ed__86(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CTransitionCoroutine_003Ed__84 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuestUIController _003C_003E4__this;

			public QuestStep newStep;

			public QuestChain chain;

			public int stepIndex;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CTransitionCoroutine_003Ed__84(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CWaitForQuestManager_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuestUIController _003C_003E4__this;

			private float _003Ctimeout_003E5__2;

			private float _003Celapsed_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitForQuestManager_003Ed__46(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private const float SLIDE_IN_DURATION = 0.35f;

		private const float SLIDE_OUT_DURATION = 0.25f;

		private const float SLIDE_OFFSET = 400f;

		private const float STEP_TRANSITION_DELAY = 0.15f;

		private const float PROGRESS_REFRESH_INTERVAL = 0.5f;

		[Header("UI Document")]
		[SerializeField]
		private UIDocument uiDocument;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private VisualElement questPanel;

		private Label titleLabel;

		private Label descriptionLabel;

		private Label hintLabel;

		private Label stepLabel;

		private VisualElement rewardSection;

		private VisualElement rewardIcon;

		private Label rewardNameLabel;

		private VisualElement unlocksSection;

		private VisualElement unlocksContainer;

		private VisualElement progressSection;

		private VisualElement crateIcon;

		private Label plusLabel;

		private VisualElement progressIcon;

		private Label progressText;

		private VisualElement objectivesSection;

		private List<VisualElement> objectiveRows;

		private Dictionary<int, Label> objectiveProgressLabels;

		private VisualElement questMultiIndicator;

		private Label questMoreLabel;

		private Coroutine currentAnimation;

		private Coroutine progressRefreshCoroutine;

		private bool isVisible;

		private string currentQuestId;

		private QuestStep currentStep;

		private InventoryManager cachedInventoryManager;

		private StandServingManager cachedServingManager;

		private int localStandSaleCount;

		private int currentTrackedFavorId;

		private FavorStatus lastShownFavorStatus;

		private bool isShowingFavor;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		private void OnDisable()
		{
		}

		private void FindLocalPlayerInventory()
		{
		}

		private void OnInventoryChanged()
		{
		}

		private void OnClientConnected(ulong clientId)
		{
		}

		private void InitializeUI()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForQuestManager_003Ed__46))]
		private IEnumerator WaitForQuestManager()
		{
			return null;
		}

		private void SubscribeToEvents()
		{
		}

		private void UnsubscribeFromEvents()
		{
		}

		private void HandleActiveQuestChanged(string questId)
		{
		}

		private void HandleStepChanged(string questId, int stepIndex, QuestStep step)
		{
		}

		private void HandleQuestCompleted(string questId, QuestChain chain)
		{
		}

		private void HandleObjectiveCompleted(string questId, int stepIndex, int objectiveIndex)
		{
		}

		private void HandleQuestListChanged()
		{
		}

		private void HandleSaveDataRestored()
		{
		}

		private void RefreshDisplay(bool animate = false)
		{
		}

		private void OnFavorsChanged()
		{
		}

		private void ShowFavor(FavorRequest favor, bool animate)
		{
		}

		private void StartFavorProgressRefresh(FavorRequest favor)
		{
		}

		[IteratorStateMachine(typeof(_003CFavorProgressRefreshCoroutine_003Ed__59))]
		private IEnumerator FavorProgressRefreshCoroutine()
		{
			return null;
		}

		private void TransitionToFavorStep(FavorRequest favor)
		{
		}

		[IteratorStateMachine(typeof(_003CFavorTransitionCoroutine_003Ed__61))]
		private IEnumerator FavorTransitionCoroutine(FavorRequest favor)
		{
			return null;
		}

		private void ShowStep(QuestChain chain, QuestStep step, int stepIndex, bool animate)
		{
		}

		private void UpdateMultiQuestIndicator()
		{
		}

		private string ResolvePlaceholders(string text)
		{
			return null;
		}

		private void HideRewardAndUnlocks()
		{
		}

		private void UpdateUnlocksPreview(QuestChain chain)
		{
		}

		private void CreateUnlocksSection()
		{
		}

		private VisualElement CreateUnlockRow(LockedTrade trade)
		{
			return null;
		}

		private void UpdateHintDisplay(QuestStep step)
		{
		}

		private void UpdateProgressDisplay(QuestStep step)
		{
		}

		private void UpdateObjectivesDisplay(QuestStep step)
		{
		}

		private VisualElement CreateObjectiveRow(QuestObjective objective, int index)
		{
			return null;
		}

		private VisualElement CreateDeliveryItemRow(RequiredItemInfo reqInfo, int index)
		{
			return null;
		}

		private int GetPlayerItemCount(string itemId)
		{
			return 0;
		}

		private bool IsStandSaleProgressStep(QuestStep step)
		{
			return false;
		}

		private void OnStandSaleEvent(QuestEventType eventType, string context)
		{
		}

		private int GetStandSaleCount()
		{
			return 0;
		}

		private void StartProgressRefresh(QuestStep step)
		{
		}

		private bool HasObjectivesWithProgress(QuestStep step)
		{
			return false;
		}

		private bool HasDeliveryItemsWithProgress()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CProgressRefreshCoroutine_003Ed__81))]
		private IEnumerator ProgressRefreshCoroutine()
		{
			return null;
		}

		private void UpdateObjectiveProgressLabels()
		{
		}

		private void TransitionToStep(string questId, QuestStep newStep, int stepIndex)
		{
		}

		[IteratorStateMachine(typeof(_003CTransitionCoroutine_003Ed__84))]
		private IEnumerator TransitionCoroutine(QuestChain chain, QuestStep newStep, int stepIndex)
		{
			return null;
		}

		private void ShowPanel()
		{
		}

		[IteratorStateMachine(typeof(_003CShowPanelCoroutine_003Ed__86))]
		private IEnumerator ShowPanelCoroutine()
		{
			return null;
		}

		private void HidePanel(bool animate)
		{
		}

		[IteratorStateMachine(typeof(_003CHidePanelCoroutine_003Ed__88))]
		private IEnumerator HidePanelCoroutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimateSlideIn_003Ed__89))]
		private IEnumerator AnimateSlideIn(VisualElement element)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimateSlideOut_003Ed__90))]
		private IEnumerator AnimateSlideOut(VisualElement element)
		{
			return null;
		}
	}
}
