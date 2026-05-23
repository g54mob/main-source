using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using InputControl;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class RewardDialog : BaseDialog
	{
		[Serializable]
		public class PackWindow
		{
			public eUpgradePack pack;

			public BaseRewardWindow rewardWindow;
		}

		[CompilerGenerated]
		private sealed class _003CDelayedSetAutoListItem_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RewardDialog _003C_003E4__this;

			public bool isSelectDummy;

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
			public _003CDelayedSetAutoListItem_003Ed__23(int _003C_003E1__state)
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

		[Header("Parent")]
		[SerializeField]
		private RectTransform windowContent;

		[SerializeField]
		private CursorUIGroup cursorGroup;

		[SerializeField]
		private CursorUIGroup dummyCursorGroup;

		[SerializeField]
		private PadInputConfigure padInputConfigure;

		[Space]
		public PackWindow[] packWindows;

		public GameObject closeButton;

		private List<eUpgradePack> _rewardList;

		private int _detailIndex;

		private UnityAction _callback;

		private int? _packPattern;

		private BaseRewardWindow _openWindow;

		private int _desinatedChoice;

		private List<int> _desinatedRewards;

		private bool _enableReload;

		private CursorUIBase _currentSelect;

		public BaseRewardWindow OpenWindow => null;

		public override void Init<T>(T args)
		{
		}

		public override void Open<T>(T args)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void DisplayNextReward()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedSetAutoListItem_003Ed__23))]
		private IEnumerator DelayedSetAutoListItem(bool isSelectDummy)
		{
			return null;
		}

		public void SetCurrentSelect()
		{
		}

		public void DebugSkipReward()
		{
		}

		public void CreateRewardButton(eUpgradePack pack)
		{
		}

		private BaseRewardWindow CreateRewardWindow(eUpgradePack pack)
		{
			return null;
		}

		public void ReloadReward()
		{
		}

		public void SkipReward()
		{
		}

		public void OpenHelp()
		{
		}

		public void OnRightTrigger()
		{
		}

		public void OnLeftTrigger()
		{
		}

		public void ResetContents()
		{
		}

		public void DebugReloadReward()
		{
		}

		public override void SetInFront()
		{
		}

		public override void PushEscape()
		{
		}

		public void OnCloseButton()
		{
		}

		public override void Back()
		{
		}

		public override void PlayOpenSound()
		{
		}

		public override void PlayCloseSound()
		{
		}
	}
}
