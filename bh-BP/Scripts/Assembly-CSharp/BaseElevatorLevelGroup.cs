using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BaseElevatorLevelGroup : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateLevelUp_003Ed__3 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseElevatorLevelGroup _003C_003E4__this;

		public int idx;

		private Transform _003CsubObj_003E5__2;

		private float _003CstartTime_003E5__3;

		private float _003Clen_003E5__4;

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
		public _003C_AnimateLevelUp_003Ed__3(int _003C_003E1__state)
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

	public List<BuildingSFXPalette> SFXPalettes;

	[Header("Auto")]
	public List<Transform> SubObjects;

	public void AnimateLevelUp()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateLevelUp_003Ed__3))]
	private IEnumerator<float> _AnimateLevelUp(int idx)
	{
		return null;
	}
}
