using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Audio;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class UnitRewardWindow : BaseRewardWindow
	{
		public enum StatusInfo
		{
			Overview = 0,
			HeroStatus = 1,
			Product = 2
		}

		[CompilerGenerated]
		private sealed class _003CAutoToggle_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UnitRewardWindow _003C_003E4__this;

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
			public _003CAutoToggle_003Ed__26(int _003C_003E1__state)
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
		private sealed class _003CDisplayAbility_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UnitRewardWindow _003C_003E4__this;

			public RectTransform enterContent;

			public eLuggage luggage;

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
			public _003CDisplayAbility_003Ed__28(int _003C_003E1__state)
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

		[SerializeField]
		private UnitUnlockRewardChoiceButton _button;

		[SerializeField]
		private Button[] _infoButtons;

		[SerializeField]
		private GameObject[] _infoButtonGuides;

		[SerializeField]
		private LuggageAbilityDetail _abilityContent;

		[SerializeField]
		private Vector3 _hoverUIOffset;

		[SerializeField]
		private GameObject _infoContent;

		[SerializeField]
		private PlaySEElement _playSEElement;

		private int _lastFocusObjID;

		private UISetting _uiSetting;

		private RewardSetting _rewardSetting;

		private Coroutine _hoverCoroutine;

		private const int tryMaxCount = 5;

		private List<eLuggage> _prevDatas;

		public override int GetFreeReloadCount => 0;

		public override void SetFreeReloadCount(int add)
		{
		}

		public override void Init(eUpgradePack pack, int desinatedChoice = -1, List<int> desinatedRewards = null, bool enableReload = true, Action reloadAction = null)
		{
		}

		public override void CreateReward(UnityAction selectedAction = null)
		{
		}

		public (List<eLuggage>, bool) SelectionLuggage(MstUpgradePackEntities mstPack, int choiceCount)
		{
			return default((List<eLuggage>, bool));
		}

		public List<eLuggage> GetUpgradeUnitPool(List<PlayUnlockData> unlockData)
		{
			return null;
		}

		public List<eLuggage> GetUnlockUnitPool(List<PlayUnlockData> unlockData)
		{
			return null;
		}

		public List<eLuggage> GetUnlockSpellPool(List<PlayUnlockData> unlockData)
		{
			return null;
		}

		public void OnToggleInfo(int infoNumber)
		{
		}

		private void ToggleInfo(int infoNumber)
		{
		}

		private void ResetButtonEnable(int infoIdx)
		{
		}

		[IteratorStateMachine(typeof(_003CAutoToggle_003Ed__26))]
		private IEnumerator AutoToggle()
		{
			return null;
		}

		private bool CheckDuplicate(List<eLuggage> list1, List<eLuggage> list2)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CDisplayAbility_003Ed__28))]
		private IEnumerator DisplayAbility(RectTransform enterContent, eLuggage luggage)
		{
			return null;
		}

		protected override void OffButtonUI()
		{
		}

		public override void OnRightTrigger()
		{
		}

		public override void OnLeftTrigger()
		{
		}
	}
}
