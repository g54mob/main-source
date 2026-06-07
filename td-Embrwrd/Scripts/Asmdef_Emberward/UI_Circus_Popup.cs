using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Circus_Popup : APopupWindow
{
	public enum eCircusRewardType
	{
		NONE = -1,
		TOWER = 0,
		RELIC = 1,
		REROLL = 2,
		MISS = 3
	}

	[CompilerGenerated]
	private sealed class _003CCR_GiveReward_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public eCircusRewardType rewardType;

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
		public _003CCR_GiveReward_003Ed__41(int _003C_003E1__state)
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
	private sealed class _003CCR_Spin_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_Circus_Popup _003C_003E4__this;

		private float _003Ct_003E5__2;

		private float _003Ctime_003E5__3;

		private float _003Cduration_003E5__4;

		private eCircusRewardType _003CrewardType_003E5__5;

		private float _003CflashDuration_003E5__6;

		private float _003CflashTime_003E5__7;

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
		public _003CCR_Spin_003Ed__39(int _003C_003E1__state)
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
	private Button button_StartRoulette;

	[SerializeField]
	private Button button_Leave;

	[SerializeField]
	private Button button_TowerLoadout;

	[SerializeField]
	private CanvasGroup canvasGroup_StartButton;

	[SerializeField]
	private Transform node_WheelSpin;

	[SerializeField]
	private List<UI_Obj_RouletteItem> list_RouletteItems;

	[SerializeField]
	private Transform node_SelectedEffect;

	[SerializeField]
	private Image image_SelectedEffect;

	[SerializeField]
	private ParticleSystemGroup particleSystemGroup_Confetti;

	[SerializeField]
	private ParticleSystem particle_Spinning;

	[SerializeField]
	private Transform node_Cost;

	[SerializeField]
	private TMP_Text text_Start;

	[SerializeField]
	private TMP_Text text_Cost;

	[SerializeField]
	private float startTime;

	[SerializeField]
	private float waitTime;

	[SerializeField]
	private float endTime;

	[SerializeField]
	private Easing.Type easingType;

	[SerializeField]
	private Color color_SelectedEffect_Good;

	[SerializeField]
	private Color color_SelectedEffect_Bad;

	[SerializeField]
	private UI_RelicList ui_relicList;

	private int cost_Roulette;

	private List<eCircusRewardType> list_DefaultRewardTypes;

	private List<eCircusRewardType> list_RewardTypes;

	private CardData[] cardDatas;

	private bool isSpinning;

	private int selectedCount;

	private int selectCountLimit;

	private float lastWheelTickRotation;

	private float spinDegreePerSecond;

	private void Awake()
	{
	}

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnGemChanged(int value)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	private void OnButtonStartRouletteClick()
	{
	}

	private void Update()
	{
	}

	private void SetupRewardTypes()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Spin_003Ed__39))]
	private IEnumerator CR_Spin()
	{
		return null;
	}

	private Coroutine GiveReward(eCircusRewardType rewardType)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_GiveReward_003Ed__41))]
	private IEnumerator CR_GiveReward(eCircusRewardType rewardType)
	{
		return null;
	}

	private void OnButtonCancelClick()
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
