using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LineRendFX : LineFX
{
	[CompilerGenerated]
	private sealed class _003C_Run_003Ed__13 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public LineRendFX _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private float _003CentryLen_003E5__3;

		private float _003CtgtWidth_003E5__4;

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
		public _003C_Run_003Ed__13(int _003C_003E1__state)
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

	protected MaterialPropertyBlock _lineRendProps;

	public MeshRenderer LineMesh;

	public Transform StartXfm;

	public Transform EndXfm;

	public float ThicknessMultiplier;

	public LineRendFX[] SubFX;

	public Renderer[] ExtraRenderers;

	private MaterialPropertyBlock[] _extraRendProps;

	public Transform[] XfmsToRotate;

	public override void Init(DamageType dt, Vector3 startPos, Vector3 endPos, bool isBaby, float thickness = 0f, LineFX parent = null)
	{
	}

	protected new float GetThickness()
	{
		return 0f;
	}

	protected void SetThickness(float w)
	{
	}

	public override void Run(DamageType dt, Vector3 startPos, Vector3 endPos, bool isBaby, float thickness = 0f)
	{
	}

	[IteratorStateMachine(typeof(_003C_Run_003Ed__13))]
	private IEnumerator<float> _Run()
	{
		return null;
	}
}
