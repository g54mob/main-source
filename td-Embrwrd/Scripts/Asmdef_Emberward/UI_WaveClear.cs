using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UI_WaveClear : APopupWindow
{
	public enum ExtraTextType
	{
		REWARD = 0,
		SCORE = 1
	}

	[CompilerGenerated]
	private sealed class _003CCR_WaveClearAnnounce_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_WaveClear _003C_003E4__this;

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
		public _003CCR_WaveClearAnnounce_003Ed__13(int _003C_003E1__state)
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
	private TMP_Text text_Clear;

	[SerializeField]
	private RectTransform node_Reward;

	[SerializeField]
	private TMP_Text text_Reward;

	[SerializeField]
	private TMP_Text text_RewardValue;

	[SerializeField]
	private RectTransform node_RoundScore;

	[SerializeField]
	private TMP_Text text_RoundScore;

	[SerializeField]
	private Transform node_EndlessModeReward;

	[SerializeField]
	private UI_CardFace card_EndlessModeReward;

	[SerializeField]
	private float waitTime;

	private bool isHaveEndlessModeReward;

	public void Setup(int value, eEndlessModeRoundRewardType endlessModeRoundRewardType, ExtraTextType extraTextType = ExtraTextType.REWARD)
	{
	}

	private void UpdateText(int value, ExtraTextType extraTextType = ExtraTextType.REWARD)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_WaveClearAnnounce_003Ed__13))]
	private IEnumerator CR_WaveClearAnnounce()
	{
		return null;
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
