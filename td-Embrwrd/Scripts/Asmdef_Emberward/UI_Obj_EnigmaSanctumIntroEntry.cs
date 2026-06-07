using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UI_Obj_EnigmaSanctumIntroEntry : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCR_ShineAnimation_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public UI_Obj_EnigmaSanctumIntroEntry _003C_003E4__this;

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
		public _003CCR_ShineAnimation_003Ed__5(int _003C_003E1__state)
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
	private Animator animator;

	[SerializeField]
	private TMP_Text text_EntryContent;

	[SerializeField]
	private ParticleSystem particle_Dust;

	public void Setup(string content)
	{
	}

	public void TriggerShineAnimation(float delay)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShineAnimation_003Ed__5))]
	private IEnumerator CR_ShineAnimation(float delay)
	{
		return null;
	}

	public void CloseUI()
	{
	}
}
