using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Slicer2D;
using UnityEngine;

public class DestructionPart : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_Run_003Ed__8 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public DestructionPart _003C_003E4__this;

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
		public _003C_Run_003Ed__8(int _003C_003E1__state)
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

	public SpriteRenderer Rend;

	public PolygonCollider2D Col;

	public global::Slicer2D.Slicer2D Sliceable;

	public SpriteRenderer Tgt;

	public Vector2 MainDir;

	public List<DestructionSubPart> SubParts;

	private List<Vector2> _physShape;

	public void Init(SpriteRenderer tgt, Vector2 dir)
	{
	}

	[IteratorStateMachine(typeof(_003C_Run_003Ed__8))]
	private IEnumerator<float> _Run()
	{
		return null;
	}

	public Material GetMat()
	{
		return null;
	}

	public List<Vector2> GetPhysShape()
	{
		return null;
	}
}
