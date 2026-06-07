using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class BoxRangeViz : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_FadeIn_003Ed__7 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BoxRangeViz _003C_003E4__this;

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
		public _003C_FadeIn_003Ed__7(int _003C_003E1__state)
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
	private sealed class _003C_FadeOut_003Ed__12 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BoxRangeViz _003C_003E4__this;

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
		public _003C_FadeOut_003Ed__12(int _003C_003E1__state)
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

	public MeshRenderer InnerRend;

	public MeshRenderer OuterRend;

	public BoxCollider2D Col;

	private Color _color;

	private CoroutineHandle _curAnim;

	private const float kFadeLen = 0.3f;

	public void InitLaser(EnemyLaserObj l)
	{
	}

	public void Init(Vector3 startPos, Vector3 tgtPos, float thickness)
	{
	}

	[IteratorStateMachine(typeof(_003C_FadeIn_003Ed__7))]
	private IEnumerator<float> _FadeIn()
	{
		return null;
	}

	public void SetVisible(bool isVis)
	{
	}

	public void Reset()
	{
	}

	public void FadeOutAndRemove()
	{
	}

	[IteratorStateMachine(typeof(_003C_FadeOut_003Ed__12))]
	private IEnumerator<float> _FadeOut()
	{
		return null;
	}

	public void SetAlpha(float alpha)
	{
	}
}
