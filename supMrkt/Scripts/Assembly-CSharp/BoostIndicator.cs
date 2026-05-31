using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BoostIndicator : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CStartBoostCountdown_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BoostIndicator _003C_003E4__this;

		private float _003CboostDuration_003E5__2;

		private float _003CtimePassed_003E5__3;

		private Image _003CcurrentImage_003E5__4;

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
		public _003CStartBoostCountdown_003Ed__19(int _003C_003E1__state)
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
	private Image[] Images;

	[SerializeField]
	private int m_PunchVibrato;

	[SerializeField]
	private float m_PunchElasticity;

	[SerializeField]
	private float m_PunchScale;

	[SerializeField]
	private Transform m_CanvasTransform;

	private float[] BoostDurations;

	private float[] CurrentBoostDurations;

	private float m_TotalAmount;

	private float m_TimeLeft;

	private int m_CurrentBoostLevel;

	private Coroutine m_CountdownCoroutine;

	private Tweener m_CachedTween;

	public Action<int> onBoostLevelChanged;

	public float TimeLeft
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public void AddBoost(float boostAmount)
	{
	}

	public float GetBoostAmount()
	{
		return 0f;
	}

	public void SetBoost(float boostAmount)
	{
	}

	[IteratorStateMachine(typeof(_003CStartBoostCountdown_003Ed__19))]
	private IEnumerator StartBoostCountdown()
	{
		return null;
	}

	private void SetTimeLeft()
	{
	}

	public void InitializeIndicator()
	{
	}

	private void CheckLevelComplete()
	{
	}

	public void ResetIndicator()
	{
	}

	private void ResetBoostLevels()
	{
	}

	private void OnDisable()
	{
	}
}
