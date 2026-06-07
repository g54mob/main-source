using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LineSpriteObj : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_Run_003Ed__11 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LineSpriteObj _003C_003E4__this;

		private LaserFXInfo _003Cinfo_003E5__2;

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
		public _003C_Run_003Ed__11(int _003C_003E1__state)
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

	public LaserFXType Type;

	public SpriteAnimator SprAnimLeft;

	public SpriteAnimator SprAnimRight;

	public float Width;

	public Color MainColor;

	private Vector3 _centerPosLocal;

	private bool _inited;

	private void InitInternal(LaserFXType type, Color c)
	{
	}

	public void Init(LaserFXType type, float leftWidth, float rightWidth, Color c)
	{
	}

	public void Init(LaserFXType type, Vector3 pt1, Vector3 pt2, Color c)
	{
	}

	public Vector3 GetCenter()
	{
		return default(Vector3);
	}

	[IteratorStateMachine(typeof(_003C_Run_003Ed__11))]
	private IEnumerator<float> _Run()
	{
		return null;
	}
}
