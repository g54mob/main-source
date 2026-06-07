using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ScrapMasterExpBar : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_LerpExpDisplay_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_ScrapMasterExpBar _003C_003E4__this;

		public float duration;

		public int targetExp;

		public int maxExp;

		private float _003CelapsedTime_003E5__2;

		private int _003CstartExp_003E5__3;

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
		public _003CCR_LerpExpDisplay_003Ed__13(int _003C_003E1__state)
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
	private Image image_Bar;

	[SerializeField]
	private TMP_Text text_Level;

	[SerializeField]
	private TMP_Text text_Exp;

	private int actualExp;

	private int displayExp;

	private float startFillAmount;

	private void Start()
	{
	}

	public void Init()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnScrapMasterLevelChanged(int level)
	{
	}

	private void OnScrapMasterExpChanged(int level, int exp, int maxExp)
	{
	}

	public void UpdateExp(int level, int exp, int maxExp)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_LerpExpDisplay_003Ed__13))]
	private IEnumerator CR_LerpExpDisplay(int targetExp, int maxExp, float duration)
	{
		return null;
	}
}
