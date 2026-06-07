using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class Obj_EnigmaSanctumFloorBlock : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public Obj_EnigmaSanctumFloorBlock _003C_003E4__this;

		public Vector3 targetPos;

		public float duration;

		public Ease ease;

		public TweenCallback _003C_003E9__10;

		internal void _003CCR_SwitchState_003Eb__9()
		{
		}

		internal void _003CCR_SwitchState_003Eb__0()
		{
		}

		internal void _003CCR_SwitchState_003Eb__1()
		{
		}

		internal void _003CCR_SwitchState_003Eb__10()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_LerpRendererColor_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float fullDuration;

		public Obj_EnigmaSanctumFloorBlock _003C_003E4__this;

		public Color offSetColor;

		public float lerpRate;

		private float _003Cduration_003E5__2;

		private Color _003CfromColor1_003E5__3;

		private Color _003CfromColor2_003E5__4;

		private Color _003CtoColor1_003E5__5;

		private Color _003CtoColor2_003E5__6;

		private float _003Celapsed_003E5__7;

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
		public _003CCR_LerpRendererColor_003Ed__15(int _003C_003E1__state)
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
	private sealed class _003CCR_SwitchState_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_EnigmaSanctumFloorBlock _003C_003E4__this;

		public float duration;

		public float delay;

		public eMazeBlockState newState;

		private _003C_003Ec__DisplayClass13_0 _003C_003E8__1;

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
		public _003CCR_SwitchState_003Ed__13(int _003C_003E1__state)
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
	private Transform node_Content;

	[SerializeField]
	private Color color_MatMainTexColor;

	[SerializeField]
	private Color color_MatSecondaryTexColor;

	[SerializeField]
	private Color color_L1PlatformLerpColor;

	[SerializeField]
	private Renderer renderer_Block;

	[SerializeField]
	private GameObject node_CollisionContent;

	[SerializeField]
	private GameObject collisionBlock;

	[SerializeField]
	private Transform node_MechanicBindPoint;

	[SerializeField]
	private Transform node_Spikes;

	[SerializeField]
	private List<(eMazeBlockState, Vector3)> list_StateOffset;

	[SerializeField]
	private eMazeBlockState state;

	[SerializeField]
	private GameObject currentMechanicObj;

	[SerializeField]
	private GameObject previousMechanicObj;

	private void Update()
	{
	}

	public void SwitchState(eMazeBlockState newState, float duration = 1f, float delay = 0f)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SwitchState_003Ed__13))]
	private IEnumerator CR_SwitchState(eMazeBlockState newState, float duration, float delay)
	{
		return null;
	}

	private void LerpRendererColor(Color offSetColor, float duration, float lerpRate = 0.5f)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_LerpRendererColor_003Ed__15))]
	private IEnumerator CR_LerpRendererColor(Color offSetColor, float fullDuration, float lerpRate)
	{
		return null;
	}

	public void BindMechanic(GameObject mechanicObj)
	{
	}

	private void SwapMechanicObject()
	{
	}
}
