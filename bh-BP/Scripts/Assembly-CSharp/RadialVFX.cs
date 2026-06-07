using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using MEC;
using Sirenix.OdinInspector;
using UnityEngine;

public class RadialVFX : SerializedMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_MyUpdate_003Ed__26 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RadialVFX _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private float _003CtgtRadius_003E5__3;

		private bool _003CisShielded_003E5__4;

		private Vector3 _003Cscale_003E5__5;

		private Vector3 _003Coffset_003E5__6;

		private float _003CentryLen_003E5__7;

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
		public _003C_MyUpdate_003Ed__26(int _003C_003E1__state)
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
	private sealed class _003C_Run_003Ed__27 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RadialVFX _003C_003E4__this;

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
		public _003C_Run_003Ed__27(int _003C_003E1__state)
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
	private sealed class _003C_RunEarthquake_003Ed__28 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public RadialVFX _003C_003E4__this;

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
		public _003C_RunEarthquake_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003C_RunPersistentAOE_003Ed__19 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public HeroInst h;

		public RadialVFX _003C_003E4__this;

		public BallSpecialType special;

		private float _003Cr_003E5__2;

		private float _003Clen_003E5__3;

		private float _003CcycleLen_003E5__4;

		private int _003CminDmg_003E5__5;

		private int _003CmaxDmg_003E5__6;

		private DamageType _003Cdt_003E5__7;

		private float _003CstartTime_003E5__8;

		private float _003ClastDmgTime_003E5__9;

		private float _003CanimStartTime_003E5__10;

		private bool _003CisAnyRunning_003E5__11;

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
		public _003C_RunPersistentAOE_003Ed__19(int _003C_003E1__state)
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
	private sealed class _003C_RunTimeBomb_003Ed__20 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public HeroInst h;

		public RadialVFX _003C_003E4__this;

		private float _003Cr_003E5__2;

		private DamageType _003Cdt_003E5__3;

		private int _003CminDmg_003E5__4;

		private int _003CmaxDmg_003E5__5;

		private float _003CstartTime_003E5__6;

		private Vector3 _003CstartPos_003E5__7;

		private Vector3 _003CtgtPos_003E5__8;

		private float _003Clen_003E5__9;

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
		public _003C_RunTimeBomb_003Ed__20(int _003C_003E1__state)
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

	public RadialVFXType Type;

	public float Radius;

	private Transform _tgt;

	private PassiveInst _tgtPassive;

	private CoroutineHandle _updateAnim;

	public RadialVFXScalable[] XfmsToScale;

	public Renderer[] Renderers;

	public PartSysGroup MainPartGroup;

	public PartSys[] Parts;

	public bool ScalePartsWithRadius;

	private MaterialPropertyBlock[] _matBlocks;

	public List<Color> VFXColorList;

	public ParticleSystem.MinMaxGradient[] DefaultParticleColor;

	public Dictionary<string, HDRColor>[] DefaultMatColors;

	private EventInstance _loopingSfx;

	private const float kFadeLen = 0.2f;

	public void Init(float range, DamageType dt)
	{
	}

	private void Colorize(HeroInst h)
	{
	}

	public void Init(BallObj b, float range)
	{
	}

	public void Init(BallSpecialType special, HeroInst h, Vector3 pos)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunPersistentAOE_003Ed__19))]
	private IEnumerator<float> _RunPersistentAOE(HeroInst h, BallSpecialType special)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunTimeBomb_003Ed__20))]
	private IEnumerator<float> _RunTimeBomb(HeroInst h)
	{
		return null;
	}

	public void InitPlayerPassive(PassiveInst passive, float radius)
	{
	}

	private void OnValidate()
	{
	}

	public void OnAboutToRemove()
	{
	}

	public void SetRadius(float r)
	{
	}

	[IteratorStateMachine(typeof(_003C_MyUpdate_003Ed__26))]
	private IEnumerator<float> _MyUpdate()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_Run_003Ed__27))]
	private IEnumerator<float> _Run()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunEarthquake_003Ed__28))]
	private IEnumerator<float> _RunEarthquake()
	{
		return null;
	}
}
