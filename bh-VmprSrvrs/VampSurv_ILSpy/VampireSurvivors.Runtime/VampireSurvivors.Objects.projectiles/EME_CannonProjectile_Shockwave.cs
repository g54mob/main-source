using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_CannonProjectile_Shockwave : Projectile
{
	private sealed class _003CDespawnInAFrame_003Ed__6(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public EME_CannonProjectile_Shockwave _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			//IL_00bc: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E4__this.Despawn();
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private ParticleSystem _shockwaveVFX;

	private Transform _targetEnemy;

	private Timer _expireTimer;

	private Timer _despawnTimer;

	protected override void Awake()
	{
		base.Awake();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0060: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_02a8: Expected O, but got I4
		//IL_01a3->IL01bb: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		Transform targetEnemy = base.AimForRandomEnemyInScreen();
		_targetEnemy = targetEnemy;
		Transform targetEnemy2 = _targetEnemy;
		if ((object)_targetEnemy != null && ((UnityEngine.Object)targetEnemy2).m_CachedPtr != (IntPtr)0)
		{
			BaseBody baseBody = body.setCircle(32f, (float?)(object)1, (float?)(object)1);
			BaseBody baseBody2 = body;
			baseBody2._enable = true;
			float num = weapon.PArea();
			object obj = default(object);
			float num2 = (float)obj - 1f;
			float num3 = num2 * 0.5f;
			float num4 = num3 + 1f;
			bool flag = 1f > num4;
			float num5 = 1f;
			if (!flag)
			{
				num5 = num4;
			}
			bool flag2 = num5 > 2f;
			float xScale = 2f;
			if (!flag2)
			{
				xScale = num5;
			}
			ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
			ArcadeSprite arcadeSprite2 = setVisible(visible: false);
			object targetEnemy3 = _targetEnemy;
			_isCullable = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rdi_v6 (System.Object)+10]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rdi_v6 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			float2 float5 = default(float2);
			base.position = float5;
			_shockwaveVFX.Play(withChildren: true);
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			Action onComplete = StartDespawn;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer expireTimer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
		}
		else
		{
			_003CDespawnInAFrame_003Ed__6 obj2 = null;
			obj2._003C_003E1__state = 0;
			obj2._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj2);
		}
	}

	private IEnumerator DespawnInAFrame()
	{
		_003CDespawnInAFrame_003Ed__6 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void StartDespawn()
	{
		//IL_005d: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_CannonProjectile_Shockwave>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(3.0000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_despawnTimer = despawnTimer;
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		BaseBody baseBody = body;
		baseBody._enable = false;
		if ((object)_shockwaveVFX != null)
		{
			_shockwaveVFX.Clear(withChildren: true);
		}
		_isCullable = true;
		base.Despawn();
	}
}
