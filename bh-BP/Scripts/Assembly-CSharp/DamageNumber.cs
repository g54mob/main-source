using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I2.Loc;
using MEC;
using TMPro;
using UnityEngine;

public class DamageNumber : FastPooledObject
{
	[CompilerGenerated]
	private sealed class _003C_Run_003Ed__5 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public bool randomizePos;

		public Vector3 pos;

		public DamageNumber _003C_003E4__this;

		public float fadeOutLen;

		private float _003CstartTime_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_Run_003Ed__5(int _003C_003E1__state)
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

	public TextMeshPro Txt;

	public Localize Loc;

	public LocalizationParamsManager Params;

	private CoroutineHandle _curAnim;

	public void Run(Vector3 pos, string str, Color c, bool isPrelocalized, float len)
	{
	}

	[IteratorStateMachine(typeof(_003C_Run_003Ed__5))]
	private IEnumerator<float> _Run(Vector3 pos, bool randomizePos, float fadeOutLen = 0.75f)
	{
		return null;
	}

	public void CancelCurAnim()
	{
	}
}
