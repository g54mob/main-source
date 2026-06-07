using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class TreeDialog : BaseDialog
	{
		[Serializable]
		public struct FrameSprite
		{
			public eFrameState state;

			public Sprite sprite;
		}

		public enum eFrameState
		{
			None = 0,
			SourceUnlock = 1,
			SourceLock = 2,
			SourceUnlockPick = 3,
			SourceLockPick = 4,
			UnitUnlock = 5,
			UnitLock = 6,
			UnitUnlockPick = 7,
			UnitLockPick = 8
		}

		[Serializable]
		public struct TreeTab
		{
			public eWriterId writerId;

			public eTreeTab tabType;

			public Button tabButton;

			public GameObject padGuide;

			public GameObject content;

			public GameObject unlockedHeroGroup;

			public RectTransform unlockContent;

			public List<RectTransform> searchParents;

			public NoticeBadge noticeBadge;
		}

		public enum eTreeTab
		{
			None = 0,
			Human = 1,
			Fairy = 2,
			Robot = 3,
			Spell = 4,
			Special = 5
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass43_0
		{
			public ScrollRect scrollRect;

			internal bool _003CScrollToCenter_003Eb__0()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CPositionDetailWithDelay_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TreeDialog _003C_003E4__this;

			public HeroTreeNode child;

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
			public _003CPositionDetailWithDelay_003Ed__24(int _003C_003E1__state)
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
		private sealed class _003CScrollToCenter_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ScrollRect scrollRect;

			public GameObject go;

			private _003C_003Ec__DisplayClass43_0 _003C_003E8__1;

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
			public _003CScrollToCenter_003Ed__43(int _003C_003E1__state)
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

		public RectTransform closeButtonRect;

		public RectTransform tutorialUnmaskWindow;

		[SerializeField]
		private List<FrameSprite> frameSprites;

		[SerializeField]
		private List<TreeTab> tabs;

		[SerializeField]
		private RectTransform unlockedHeroContent;

		[SerializeField]
		private TreeUnlockHeroButton unlockButtonPrefab;

		[SerializeField]
		private Sprite selectedTabSprite;

		[SerializeField]
		private Sprite unSelectedTabSprite;

		[SerializeField]
		private LuggageAbilityDetail luggageAbilityDetail;

		[SerializeField]
		private ScrollRect scrollRect;

		private Dictionary<eTreeTab, List<HeroTreeNode>> _heroTreeNodeCache;

		private Dictionary<eTreeTab, List<TreeUnlockHeroButton>> _unlockHeroCache;

		private Dictionary<eTreeTab, HeroTreeNode> _selectedUnlockHero;

		private eWriterId _targetWriter;

		private eTreeTab _openTab;

		private TreeTab _targetTab;

		private List<TreeTab> _enabledTabs;

		private InputActionController input;

		private void Awake()
		{
		}

		public void InitAction()
		{
		}

		[IteratorStateMachine(typeof(_003CPositionDetailWithDelay_003Ed__24))]
		private IEnumerator PositionDetailWithDelay(HeroTreeNode child)
		{
			return null;
		}

		public void OpenAction()
		{
		}

		public override void Init()
		{
		}

		public override void Open()
		{
		}

		public override void Init<T>(T args)
		{
		}

		public override void Open<T>(T args)
		{
		}

		public void UpdateUnlockHero(eTreeTab targetTab)
		{
		}

		public void UpdateFrame(HeroTreeNode node, bool parent = false, bool select = false)
		{
		}

		public void UpdateEffect(HeroTreeNode node, bool parent = false, bool select = false)
		{
		}

		public void UpdateTabBadge()
		{
		}

		public void OnClickTab(eTreeTab openTab, eLuggage selectLuggage = eLuggage.None)
		{
		}

		public void SelectCreateableHero(eLuggage selectLuggage)
		{
		}

		public void SelectHuman()
		{
		}

		public void OnClickTab(int raceNum)
		{
		}

		public void OnNextUnlockHero()
		{
		}

		public void OnNextTab()
		{
		}

		public void OnPrevTab()
		{
		}

		private void ToggleTab(TreeTab treeTab)
		{
		}

		public void ReturnMainContents()
		{
		}

		[IteratorStateMachine(typeof(_003CScrollToCenter_003Ed__43))]
		private IEnumerator ScrollToCenter(ScrollRect scrollRect, GameObject go)
		{
			return null;
		}

		public override void Back()
		{
		}

		public void OnDisable()
		{
		}
	}
}
