using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Febucci.UI;
using TMPro;
using UnityEngine;

public class UI_WaveAnnounce : AUISituational
{
	[CompilerGenerated]
	private sealed class _003CCR_Proc_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_WaveAnnounce _003C_003E4__this;

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
		public _003CCR_Proc_003Ed__6(int _003C_003E1__state)
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
	private float waitTime;

	[SerializeField]
	private TMP_Text text_WaveCount;

	[SerializeField]
	private TypewriterByCharacter text_EnemyIncoming;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnWaveIndexChanged(int index, bool isFinalWave)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Proc_003Ed__6))]
	private IEnumerator CR_Proc()
	{
		return null;
	}
}
