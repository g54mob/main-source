using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UI_DamageNumber : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CEffectProc_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UI_DamageNumber _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003CrndOffset_003E5__3;

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
		public _003CEffectProc_003Ed__18(int _003C_003E1__state)
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
	private Animation animation;

	[SerializeField]
	private AnimationClip animClip_Normal;

	[SerializeField]
	private AnimationClip animClip_Crit;

	[SerializeField]
	private TMP_Text text_Value;

	[SerializeField]
	private Transform node_RandomOffset;

	[SerializeField]
	private float duration;

	[SerializeField]
	private float width;

	[SerializeField]
	private float randomOffsetWidth;

	private Vector3 worldPosition;

	private Vector3 curCameraPos;

	private bool isCrit;

	private readonly int shrinkSizeDamageThreshold;

	private readonly float shrinkSizeScale;

	private Coroutine coroutine_EffectProc;

	public float Width => 0f;

	public void Trigger(Vector3 worldPos, int value, bool isCrit, eDamageType damageType)
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CEffectProc_003Ed__18))]
	private IEnumerator EffectProc()
	{
		return null;
	}
}
