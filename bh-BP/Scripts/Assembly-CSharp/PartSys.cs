using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PartSys : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_DetachAndRemove_003Ed__29 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PartSys _003C_003E4__this;

		public bool doRemove;

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
		public _003C_DetachAndRemove_003Ed__29(int _003C_003E1__state)
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
	private sealed class _003C_FadeOutAndRemove_003Ed__34 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PartSys _003C_003E4__this;

		public float fadeLen;

		public bool doRemove;

		private bool _003CusesColorOverLifetime_003E5__2;

		private Color _003CstartColor_003E5__3;

		private Color _003CtgtColor_003E5__4;

		private float _003CstartTime_003E5__5;

		private int _003Ccount_003E5__6;

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
		public _003C_FadeOutAndRemove_003Ed__34(int _003C_003E1__state)
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
	private sealed class _003C_ShrinkAndRemove_003Ed__33 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PartSys _003C_003E4__this;

		public float shrinkLen;

		public bool doRemove;

		private bool _003CusesSizeOverLifetime_003E5__2;

		private float _003CstartTime_003E5__3;

		private int _003Ccount_003E5__4;

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
		public _003C_ShrinkAndRemove_003Ed__33(int _003C_003E1__state)
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
	private sealed class _003C_SpeedUpParticlesForRemoval_003Ed__35 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PartSys _003C_003E4__this;

		public float mult;

		private ParticleSystem.MinMaxCurve _003CdefaultGravity_003E5__2;

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
		public _003C_SpeedUpParticlesForRemoval_003Ed__35(int _003C_003E1__state)
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
	private sealed class _003C_WaitAndRemove_003Ed__32 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public PartSys _003C_003E4__this;

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
		public _003C_WaitAndRemove_003Ed__32(int _003C_003E1__state)
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

	public PartSysType Type;

	public ParticleSystem Sys;

	private ParticleSystem.MainModule _main;

	private ParticleSystem.ShapeModule _shape;

	private ParticleSystem.ColorOverLifetimeModule _colorOverLifetime;

	private ParticleSystem.SizeOverLifetimeModule _sizeOverLifetime;

	public ParticleSystemRenderer Rend;

	private ParticleSystem.Particle[] _particleBuffer;

	private float[] _particleFloatBuffer;

	public bool IgnoreTimeScale;

	public bool IsGlobal;

	public bool RemoveAfterLifetime;

	private float _defaultLifetime;

	private float _simulationSpeedMult;

	private ParticleSystem.MinMaxGradient _defaultStartColor;

	public bool DisableLoopOnPlay;

	private bool _isAnimatingRemoval;

	public PartSysComponent[] Components;

	private ParticleSystem.EmitParams _emitParams;

	protected virtual void Awake()
	{
	}

	protected virtual void Reset()
	{
	}

	public virtual void Run()
	{
	}

	public virtual void Run(Vector2 aimDir)
	{
	}

	public virtual void Stop()
	{
	}

	public virtual void SetStartColor(ParticleSystem.MinMaxGradient col)
	{
	}

	public void SetStartLifetime(float f)
	{
	}

	public void SetDuration(float d)
	{
	}

	public void SetStartSize(float s)
	{
	}

	public float GetStartSize()
	{
		return 0f;
	}

	public void DetachAndRemove(bool doRemove)
	{
	}

	[IteratorStateMachine(typeof(_003C_DetachAndRemove_003Ed__29))]
	public IEnumerator<float> _DetachAndRemove(bool doRemove)
	{
		return null;
	}

	public bool IsRunning()
	{
		return false;
	}

	public void WaitAndRemove()
	{
	}

	[IteratorStateMachine(typeof(_003C_WaitAndRemove_003Ed__32))]
	protected virtual IEnumerator<float> _WaitAndRemove()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_ShrinkAndRemove_003Ed__33))]
	public IEnumerator<float> _ShrinkAndRemove(float shrinkLen, bool doRemove)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_FadeOutAndRemove_003Ed__34))]
	public IEnumerator<float> _FadeOutAndRemove(float fadeLen, bool doRemove)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_SpeedUpParticlesForRemoval_003Ed__35))]
	public IEnumerator<float> _SpeedUpParticlesForRemoval(float mult)
	{
		return null;
	}

	public bool IsAnimatingRemoval()
	{
		return false;
	}

	public void OnGameSpeedChanged()
	{
	}

	public virtual void OnGameSpeedChanged(float speed)
	{
	}

	public ParticleSystem.MainModule GetMain()
	{
		return default(ParticleSystem.MainModule);
	}

	public void SetShapeRot(Vector3 rot)
	{
	}

	public void SetShapeRadius(float rad)
	{
	}

	public void SetSortLayer(SortLayerType st)
	{
	}

	public void SetSortOrder(int order)
	{
	}

	public ParticleSystem.ShapeModule GetShape()
	{
		return default(ParticleSystem.ShapeModule);
	}

	public virtual void SetScale(float sc)
	{
	}

	public virtual void EmitFromMeshRenderer(MeshRenderer rend, bool force = false)
	{
	}

	public virtual void EmitFromSkinnedMeshRenderer(SkinnedMeshRenderer rend, bool force = false)
	{
	}

	public void EmitAt(Vector3 position)
	{
	}

	public void SetDefaultStartColor(Color c)
	{
	}

	public void SetDefaultStartColor(ParticleSystem.MinMaxGradient c)
	{
	}
}
