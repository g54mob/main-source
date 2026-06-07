using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Slicer2D;
using UnityEngine;

public class DestructionSubPart : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_Run_003Ed__5 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public DestructionSubPart _003C_003E4__this;

		public Vector3 dir;

		private float _003CmoveSpeed_003E5__2;

		private float _003CrotSpeed_003E5__3;

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

	public PolygonCollider2D Col;

	public global::Slicer2D.Slicer2D Slicer;

	public MeshRenderer MeshRend;

	private const float kMoveLen = 0.125f;

	public void Init(DestructionPart og)
	{
	}

	[IteratorStateMachine(typeof(_003C_Run_003Ed__5))]
	private IEnumerator<float> _Run(Vector3 dir)
	{
		return null;
	}
}
