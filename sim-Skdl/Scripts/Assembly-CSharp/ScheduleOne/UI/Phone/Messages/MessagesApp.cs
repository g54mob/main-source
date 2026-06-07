using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Messaging;
using ScheduleOne.UI.Tooltips;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.Messages
{
	public class MessagesApp : App<MessagesApp>
	{
		[Serializable]
		public class CategoryInfo
		{
			public EConversationCategory Category;

			public string Name;

			public Color Color;
		}

		[CompilerGenerated]
		private sealed class _003CDelaySelect_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MessagesApp _003C_003E4__this;

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
			public _003CDelaySelect_003Ed__56(int _003C_003E1__state)
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
		private sealed class _003CDelaySelectCurrentSelectedSelectable_003Ed__55 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MessagesApp _003C_003E4__this;

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
			public _003CDelaySelectCurrentSelectedSelectable_003Ed__55(int _003C_003E1__state)
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
		private sealed class _003CDelaySelectDialogueUIPanel_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MessagesApp _003C_003E4__this;

			public UIPanel uIPanel;

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
			public _003CDelaySelectDialogueUIPanel_003Ed__58(int _003C_003E1__state)
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

		public static List<MSGConversation> Conversations;

		public static List<MSGConversation> ActiveConversations;

		public List<CategoryInfo> categoryInfos;

		[SerializeField]
		[Header("References")]
		protected RectTransform conversationEntryContainer;

		[SerializeField]
		protected RectTransform conversationContainer;

		public GameObject homePage;

		public GameObject dialoguePage;

		public Text dialoguePageNameText;

		public RectTransform relationshipContainer;

		public Scrollbar relationshipScrollbar;

		public Tooltip relationshipTooltip;

		public RectTransform debtContainer;

		public Text debtLabel;

		public RectTransform standardsContainer;

		public Image standardsStar;

		public Tooltip standardsTooltip;

		public RectTransform iconContainerRect;

		public Image iconImage;

		public Sprite BlankAvatarSprite;

		public DealWindowSelector DealWindowSelector;

		public PhoneShopInterface PhoneShopInterface;

		public CounterofferInterface CounterofferInterface;

		public RectTransform ClearFilterButton;

		public Button[] CategoryButtons;

		public AudioSourceController MessageReceivedSound;

		public AudioSourceController MessageSentSound;

		public ConfirmationPopup ConfirmationPopup;

		[Header("Prefabs")]
		[SerializeField]
		protected GameObject conversationEntryPrefab;

		[SerializeField]
		protected GameObject conversationContainerPrefab;

		public GameObject messageBubblePrefab;

		public List<MSGConversation> unreadConversations;

		[Header("Custom UI")]
		public UIScreen mainMessagesUIScreen;

		public UIPanel mainMessagesUIPanel;

		public UIScreen dialogueMainUIScreen;

		public MSGConversation currentConversation { get; private set; }

		protected override void Start()
		{
		}

		protected override void Update()
		{
		}

		private void Loaded()
		{
		}

		private void Clean()
		{
		}

		public void CreateConversationUI(MSGConversation c, out RectTransform entry, out RectTransform container)
		{
			entry = null;
			container = null;
		}

		public void RepositionEntries()
		{
		}

		public void ReturnButtonClicked()
		{
		}

		public void RefreshNotifications()
		{
		}

		public override void Exit(ExitAction exit)
		{
		}

		public void SetCurrentConversation(MSGConversation conversation)
		{
		}

		public CategoryInfo GetCategoryInfo(EConversationCategory category)
		{
			return null;
		}

		public void FilterByCategory(int category)
		{
		}

		public void ClearFilter()
		{
		}

		public override void SetOpen(bool open)
		{
		}

		protected override void OnPhoneOpened()
		{
		}

		private void SelectMessageSelectable()
		{
		}

		[IteratorStateMachine(typeof(_003CDelaySelectCurrentSelectedSelectable_003Ed__55))]
		private IEnumerator DelaySelectCurrentSelectedSelectable()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDelaySelect_003Ed__56))]
		private IEnumerator DelaySelect()
		{
			return null;
		}

		public void SelectDialogueUIPanel(UIPanel uIPanel)
		{
		}

		[IteratorStateMachine(typeof(_003CDelaySelectDialogueUIPanel_003Ed__58))]
		private IEnumerator DelaySelectDialogueUIPanel(UIPanel uIPanel)
		{
			return null;
		}
	}
}
