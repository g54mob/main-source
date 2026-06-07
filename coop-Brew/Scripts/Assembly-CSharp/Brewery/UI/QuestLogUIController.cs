using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Quest;
using Brewery.Stand;
using Brewery.UI.Components;
using Favors;
using InventorySystem;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.UI
{
	public class QuestLogUIController : BaseBreweryUIController
	{
		private enum Tab
		{
			Active = 0,
			Favors = 1,
			Completed = 2
		}

		[CompilerGenerated]
		private sealed class _003CDelayedRefresh_003Ed__81 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public QuestLogUIController _003C_003E4__this;

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
			public _003CDelayedRefresh_003Ed__81(int _003C_003E1__state)
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

		private const string TemplatePath = "UI/QuestLogUI";

		private const string StylesheetPath = "UI/QuestLogUI";

		private new VisualElement root;

		private VisualElement activeQuestsContainer;

		private VisualElement completedQuestsContainer;

		private VisualElement noActiveQuestsState;

		private VisualElement noCompletedQuestsState;

		private VisualElement activeTabContent;

		private VisualElement completedTabContent;

		private Label footerLabel;

		private Label activeCountLabel;

		private Label completedCountLabel;

		private VisualElement activeTabBadge;

		private VisualElement completedTabBadge;

		private VisualElement favorsTabContent;

		private VisualElement availableFavorsContainer;

		private VisualElement myFavorsContainer;

		private VisualElement noFavorsState;

		private Label favorsCountLabel;

		private VisualElement favorsTabBadge;

		private InputReader inputReader;

		private bool isDirty;

		private Tab currentTab;

		private static TabDefinition[] _tabDefinitions;

		private StandServingManager cachedServingManager;

		private int localStandSaleCount;

		public static QuestLogUIController Instance { get; private set; }

		private static TabDefinition[] TabDefinitions => null;

		protected override void RegisterSingleton()
		{
		}

		protected override VisualElement GetContainer()
		{
			return null;
		}

		protected override void OnUIHiding()
		{
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void BuildUI()
		{
		}

		private void FindInputReader()
		{
		}

		private void OnLocalInputReaderReady(InputReader reader)
		{
		}

		private void BindToInputReader(InputReader reader)
		{
		}

		private void UnsubscribeFromInput()
		{
		}

		private void HandleQuestLogToggle()
		{
		}

		private void SubscribeToQuestManager()
		{
		}

		private void UnsubscribeFromQuestManager()
		{
		}

		private void HandleQuestListChanged()
		{
		}

		private void HandleActiveQuestChanged(string questId)
		{
		}

		private void HandleSaveDataRestored()
		{
		}

		private void HandleFavorsChanged()
		{
		}

		public void ShowUI()
		{
		}

		private void Update()
		{
		}

		private void RefreshUI()
		{
		}

		private void RefreshActiveQuests()
		{
		}

		private void RefreshFavors()
		{
		}

		private void RefreshCompletedQuests()
		{
		}

		private void RefreshBadges()
		{
		}

		private void RefreshFooter()
		{
		}

		private void ShowEmptyState(VisualElement emptyState, bool show)
		{
		}

		private Sprite GetNpcPortrait(string npcId)
		{
			return null;
		}

		private string GetNpcDisplayName(string npcId)
		{
			return null;
		}

		private VisualElement CreateQuestCard(string questId, QuestChain chain, QuestProgress progress, bool isActiveQuest, bool isCompleted)
		{
			return null;
		}

		private VisualElement CreateUnlocksSection(QuestChain chain)
		{
			return null;
		}

		private string ResolveQuestPlaceholders(string text)
		{
			return null;
		}

		private VisualElement CreateDeliveryRequirementsSection(QuestStep step)
		{
			return null;
		}

		private VisualElement CreateCollectionProgressSection(QuestStep step)
		{
			return null;
		}

		private VisualElement CreateStandSaleProgressSection(QuestStep step)
		{
			return null;
		}

		private void OnStandSaleEvent(QuestEventType eventType, string context)
		{
		}

		private int GetStandSaleCount()
		{
			return 0;
		}

		private VisualElement CreateObjectivesSection(QuestStep step)
		{
			return null;
		}

		private InventoryManager GetLocalPlayerInventory()
		{
			return null;
		}

		private VisualElement CreateFavorCard(FavorRequest favor, bool isMyFavor)
		{
			return null;
		}

		private VisualElement CreateActiveFavorCard(FavorRequest favor)
		{
			return null;
		}

		private VisualElement CreateCompletedFavorCard(FavorRequest favor)
		{
			return null;
		}

		private void AddFavorRewardDisplay(VisualElement parent, FavorRequest favor)
		{
		}

		private void OnAcceptFavorClicked(int favorId)
		{
		}

		private void OnSetActiveClicked(string questId)
		{
		}

		private void OnClearActiveClicked()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedRefresh_003Ed__81))]
		private IEnumerator DelayedRefresh()
		{
			return null;
		}

		private void HandleTabChanged(string tabKey)
		{
		}

		protected override void HandleCustomKeys(KeyDownEvent evt)
		{
		}
	}
}
