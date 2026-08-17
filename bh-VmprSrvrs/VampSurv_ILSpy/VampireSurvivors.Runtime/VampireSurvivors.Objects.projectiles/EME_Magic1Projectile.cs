using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_Magic1Projectile : Projectile
{
	private sealed class _003CWaitForParticlesToFinish_003Ed__22(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public EME_Magic1Projectile _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0038: Expected I4, but got I8
			//IL_0188: Expected O, but got I4
			//IL_00ad->IL01a5: Incompatible stack heights: 3 vs 4
			EME_Magic1Projectile eME_Magic1Projectile = _003C_003E4__this;
			if (_003C_003E1__state <= 1)
			{
				_003C_003E1__state = -1;
				bool flag = (object)_003C_003E4__this == null;
				object chosenSpiritRing = eME_Magic1Projectile._chosenSpiritRing;
				bool flag2 = (object)eME_Magic1Projectile._chosenSpiritRing == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rsi_v2 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rsi_v2 (System.Object)+10]");
				object obj = ParticleSystem.IsAlive_Injected((IntPtr)0, true);
				if (obj != null)
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				BaseBody body = eME_Magic1Projectile.body;
				bool flag4 = eME_Magic1Projectile.body == null;
				body._enable = false;
				if ((object)eME_Magic1Projectile._chosenSpiritRing != null)
				{
					eME_Magic1Projectile._chosenSpiritRing.Clear(withChildren: true);
				}
				eME_Magic1Projectile._isCullable = true;
				((Projectile)_003C_003E4__this).Despawn();
				return false;
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

	protected List<ParticleSystem> _availableSpiritRings;

	private float _defaultOrbitRadius = 0.5f;

	private float _maximumOrbitRadius = 4.5f;

	private float _startingAngleOffset;

	private float _defaultHitboxRadius = 10f;

	private float _maximumHitboxRadius;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private Vector3 _chosenSpiritRingScale;

	protected bool _activate;

	protected float _positionInCircumference;

	protected ParticleSystem _chosenSpiritRing;

	protected virtual float OrbitSpeed
	{
		get
		{
			float num = _weapon.PDuration();
			object obj = default(object);
			float num2 = (float)obj * 0.001f;
			float num3 = 360f / num2;
			return num3 * ((float)Math.PI / 180f);
		}
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00bd: Expected O, but got I4
		//IL_00bd: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body;
		baseBody._enable = true;
		_isCullable = false;
		_activate = false;
		_speed = 0f;
		float radius = _maximumHitboxRadius;
		float num = _weapon.PArea();
		object obj = default(object);
		float num2 = (float)obj * _defaultHitboxRadius;
		if (_maximumHitboxRadius > num2)
		{
			radius = num2;
		}
		BaseBody baseBody2 = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
		SetupTimers();
	}

	private void SetupMechanics()
	{
		//IL_00ab: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		BaseBody baseBody = body;
		baseBody._enable = true;
		_isCullable = false;
		_activate = false;
		_speed = 0f;
		float radius = _maximumHitboxRadius;
		float num = _weapon.PArea();
		object obj = default(object);
		float num2 = (float)obj * _defaultHitboxRadius;
		if (_maximumHitboxRadius > num2)
		{
			radius = num2;
		}
		BaseBody baseBody2 = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
	}

	private void SetupProjectileScale()
	{
		//IL_006d: Expected O, but got I4
		//IL_006d: Expected O, but got I4
		float radius = _maximumHitboxRadius;
		float num = _weapon.PArea();
		object obj = default(object);
		float num2 = (float)obj * _defaultHitboxRadius;
		if (_maximumHitboxRadius > num2)
		{
			radius = num2;
		}
		BaseBody baseBody = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
	}

	private void SetupTimers()
	{
		//IL_00a9: Expected I, but got O
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			if (_objectsHit != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			}
		};
		float num = hitBoxDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(num, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		float num2 = _weapon.PDuration();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_Magic1Projectile>)+370]");
		Action onComplete2 = new Action(this, (IntPtr)0);
		nint num3 = (nint)this;
		float duration = num * 0.001f;
		Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Ref, but got Unknown
		//IL_00ad->IL0077: Incompatible stack heights: 1 vs 0
		if (_activate)
		{
			Transform cachedTransform = _cachedTransform;
			float orbitSpeed = OrbitSpeed;
			float deltaTime = PauseSystem.DeltaTime;
			object obj = default(object);
			float orbitSpeed2 = deltaTime * (float)obj;
			Vector3 vector = OrbitPositionAroundPlayer(ref *(float*)(this + 272), orbitSpeed2);
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref *(Vector3*)(&value));
		}
	}

	protected unsafe Vector3 OrbitPositionAroundPlayer(ref float positionInCircumference, float orbitSpeed)
	{
		//IL_0009: Expected native int or pointer, but got O
		//IL_0017: Expected native int or pointer, but got O
		//IL_0038: Expected Ref, but got F4
		//IL_0184: Expected native int or pointer, but got O
		//IL_0192: Expected native int or pointer, but got O
		//IL_01e0: Expected native int or pointer, but got O
		//IL_022e: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = 0f;
		((Vector3*)(nint)vector)->z = 0f;
		float num = orbitSpeed + positionInCircumference;
		ref float reference = ref *(float*)num;
		float num2 = _startingAngleOffset * ((float)Math.PI / 180f);
		float num3 = _maximumOrbitRadius;
		if ((object)_weapon != null)
		{
			float num4 = _weapon.PArea();
			object obj = default(object);
			float num5 = (float)obj * _defaultOrbitRadius;
			Weapon weapon = _weapon;
			if (_maximumOrbitRadius > num5)
			{
				num3 = num5;
			}
			if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					float ret;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
					((Vector3*)(nint)vector)->x = ret;
					((Vector3*)(nint)vector)->z = 0f;
					float num6 = num2 + positionInCircumference;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					float num7 = num6 * num3;
					float x = num7 + vector.x;
					((Vector3*)(nint)vector)->x = x;
					float num8 = num2 + positionInCircumference;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num9 = num8 * num3;
					float y = vector.y - num9;
					((Vector3*)(nint)vector)->y = y;
					return vector;
				}
			}
		}
		throw new NullReferenceException();
	}

	public virtual void SetOffsetPosition(int index)
	{
		//IL_0013: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		//IL_005d->IL0180: Incompatible stack heights: 1 vs 0
		//IL_00c3->IL0180: Incompatible stack heights: 1 vs 0
		//IL_00ef->IL0180: Incompatible stack heights: 1 vs 0
		//IL_0236->IL0180: Incompatible stack heights: 2 vs 0
		//IL_0128->IL0180: Incompatible stack heights: 2 vs 0
		List<ParticleSystem> availableSpiritRings = _availableSpiritRings;
		float positionInCircumference = (float)index * ((float)Math.PI * 2f / 5f);
		_positionInCircumference = positionInCircumference;
		if (_availableSpiritRings != null)
		{
			object obj = index - 1;
			bool flag = (nint)obj >= availableSpiritRings._size;
			ParticleSystem[] items = availableSpiritRings._items;
			if (availableSpiritRings._items != null)
			{
				object obj2 = index - 1;
				if ((nint)obj2 >= items.Length)
				{
					throw new IndexOutOfRangeException();
				}
				_chosenSpiritRing = items[obj2];
				if ((object)_chosenSpiritRing != null)
				{
					Transform transform = _chosenSpiritRing.transform;
					if ((object)transform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v24 (UnityEngine.Transform)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v24 (UnityEngine.Transform)+10]");
						Transform.get_localScale_Injected((IntPtr)0, out Vector3 ret);
						_chosenSpiritRingScale = ret;
						_ = 0;
						if ((object)_chosenSpiritRing != null)
						{
							Transform transform2 = _chosenSpiritRing.transform;
							if ((object)_weapon != null)
							{
								float num = _weapon.PArea();
								bool flag3 = (object)transform2 == null;
								bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
								bool flag5 = (object)_chosenSpiritRing == null;
								_chosenSpiritRing.Play(withChildren: true);
								_activate = true;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if ((object)_chosenSpiritRing != null)
		{
			_chosenSpiritRing.Stop();
			if ((object)_chosenSpiritRing != null)
			{
				Transform transform = _chosenSpiritRing.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					_003CWaitForParticlesToFinish_003Ed__22 obj = null;
					obj._003C_003E1__state = 0;
					obj._003C_003E4__this = this;
					Coroutine coroutine = StartCoroutine(obj);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private IEnumerator WaitForParticlesToFinish()
	{
		_003CWaitForParticlesToFinish_003Ed__22 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void _003CSetupTimers_003Eb__17_0()
	{
		if (_objectsHit != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	private void _003C_003En__0()
	{
		base.Despawn();
	}
}
