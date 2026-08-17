using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_WaveProjectile_LineVFX : Projectile
{
	private TrailRenderer _Trail1;

	private EME_WaveWeapon _trueWeapon;

	private bool _isFirstUpdate;

	private EnemyController _targetEnemy;

	private Vector3 p0;

	private Vector3 p1;

	private Vector3 p2;

	private Vector3 p3;

	private float _elapsedLineTime;

	private float _lineDuration = 500f;

	private bool _hasReachedTarget;

	private bool _isDespawning;

	protected override void Awake()
	{
		base.Awake();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_006c: Expected I, but got O
		//IL_0074: Expected I, but got O
		//IL_0084: Expected O, but got I
		//IL_0104: Expected O, but got I4
		//IL_0054: Expected I, but got O
		//IL_00c0: Expected O, but got I
		//IL_00f6: Expected O, but got I4
		//IL_0150: Expected O, but got I4
		//IL_029f->IL01e1: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (body == null)
		{
			goto IL_01e1;
		}
		BaseBody baseBody = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
		_isCullable = false;
		Weapon trueWeapon;
		nint num;
		if ((object)weapon == null)
		{
			num = unchecked((nint)null);
			trueWeapon = null;
			goto IL_0228;
		}
		nint num2 = (nint)typeof(EME_WaveWeapon);
		num = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_WaveWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_WaveWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rax_v33+FFFFFFF8+v160 @ rax_v28*8]");
			if (0 == (nint)typeof(EME_WaveWeapon))
			{
				obj3 = 1;
				goto IL_0237;
			}
		}
		obj3 = 0;
		goto IL_0237;
		IL_01e1:
		throw new NullReferenceException();
		IL_0237:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = weapon;
		}
		goto IL_0228;
		IL_0228:
		_trueWeapon = (EME_WaveWeapon)trueWeapon;
		Weapon weapon2 = (Weapon)(object)body;
		if ((object)_trueWeapon != null)
		{
			LevelUpFactory levelUpFactory = (LevelUpFactory)_trueWeapon.IsEvolved;
			if (body != null)
			{
				((Equipment)weapon2)._levelUpFactory = levelUpFactory;
				Weapon trail = (Weapon)(object)_Trail1;
				if ((object)_Trail1 != null)
				{
					bool flag2 = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
					TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
					if ((object)_Trail1 != null)
					{
						_Trail1.emitting = false;
						_isFirstUpdate = true;
						_hasReachedTarget = false;
						_elapsedLineTime = 0f;
						return;
					}
				}
			}
		}
		goto IL_01e1;
	}

	public void SetTargetEnemy(EnemyController enemy)
	{
		_targetEnemy = enemy;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 50 Invalid \"Jump target not found in method: 0x187245B60\"");
	}

	private void Activate()
	{
		//IL_0114: Expected O, but got F4
		//IL_0122: Expected O, but got F4
		//IL_00d6: Expected O, but got I
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		Weapon weapon = _weapon;
		if (((Equipment)weapon)._003COwner_003Ek__BackingField.flipX)
		{
		}
		float2 float5 = _targetEnemy.position;
		float2 float6 = _targetEnemy.position;
		object obj = UnityEngine.Random.value;
		float2 float7 = _targetEnemy.position;
		Vector3 vector = default(Vector3);
		p0 = vector;
		_ = 0;
		object obj2 = UnityEngine.Random.value;
		p3 = vector;
		_ = 0;
		float2 float8 = _targetEnemy.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_WaveProjectile_LineVFX)+F8]");
		object obj3 = -0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_WaveProjectile_LineVFX)+11C]");
		object obj4 = obj3 - 0;
		float num = (float)obj4 * 0.5f;
		p1 = vector;
	}

	private void LateUpdate()
	{
		//IL_0030: Expected I, but got O
		//IL_00ed: Expected O, but got I
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0213->IL0213: Incompatible stack heights: 2 vs 0
		//IL_0320->IL0193: Incompatible stack heights: 1 vs 0
		//IL_0126->IL027a: Incompatible stack heights: 1 vs 0
		//IL_014d->IL0193: Incompatible stack heights: 1 vs 0
		//IL_0193->IL0193: Incompatible stack heights: 2 vs 0
		if (_lineDuration > _elapsedLineTime)
		{
			EnemyController targetEnemy = _targetEnemy;
			if ((object)_targetEnemy != null && ((UnityEngine.Object)targetEnemy).m_CachedPtr != (IntPtr)0)
			{
				bool flag = (object)_targetEnemy == null;
				float2 float5 = _targetEnemy.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_WaveProjectile_LineVFX)+F8]");
				object obj = -0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_WaveProjectile_LineVFX)+11C]");
				object obj2 = obj - 0;
				float num = (float)obj2 * 0.5f;
				Vector3 vector = default(Vector3);
				p1 = vector;
			}
			float deltaTime = PauseSystem.DeltaTime;
			float num2 = deltaTime * 1000f;
			float num3 = (_elapsedLineTime = num2 + _elapsedLineTime) / _lineDuration;
			Transform transform = base.transform;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			if (!(num3 < 0.45f) && !_hasReachedTarget)
			{
				_hasReachedTarget = true;
				bool flag3 = (object)_trueWeapon == null;
				_trueWeapon.RaptureDamage(_targetEnemy);
			}
		}
		else if (!_isDespawning)
		{
			_isDespawning = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_WaveProjectile_LineVFX>)+370]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num4 = (nint)this;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.15f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
		if (_isFirstUpdate)
		{
			bool flag4 = (object)_Trail1 == null;
			_Trail1.Clear();
			_isFirstUpdate = false;
			bool flag5 = (object)_Trail1 == null;
			_Trail1.emitting = true;
		}
	}

	private unsafe Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
	{
		//IL_00b4: Expected native int or pointer, but got O
		//IL_00c1: Expected native int or pointer, but got O
		float num = 1f - t;
		float num2 = num * num;
		float num3 = p0.z * num2;
		float num4 = num + num;
		float num5 = num4 * t;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ stack_28+8]");
		float num6 = 0f * num5;
		float num7 = num6 + num3;
		float num8 = t * t;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ stack_30+8]");
		float num9 = 0f * num8;
		float z = num9 + num7;
		Vector3 vector = default(Vector3);
		float x = default(float);
		((Vector3*)(nint)vector)->x = x;
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	public void OnTargetReached()
	{
		if (!_hasReachedTarget)
		{
			_hasReachedTarget = true;
			_trueWeapon.RaptureDamage(_targetEnemy);
		}
	}

	private void StartDespawn()
	{
		//IL_002b: Expected I, but got O
		if (!_isDespawning)
		{
			_isDespawning = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_WaveProjectile_LineVFX>)+370]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.15f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	public override void Despawn()
	{
		TrailRenderer trail = _Trail1;
		bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
		TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
		_Trail1.emitting = false;
		base.Despawn();
	}
}
