using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class unused_EME_Pistol1Weapon : EME_Weapon
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public unused_EME_Pistol1Weapon _003C_003E4__this;

		public Vector2 pos;

		public int index;

		public BulletPool pool;

		internal unsafe void _003CFire_FireGlimmerProjectile_003Eb__0()
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected Ref, but got Unknown
			//IL_0046: Expected O, but got I4
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected I4, but got Unknown
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Expected O, but got Unknown
			unused_EME_Pistol1Weapon unused_EME_Pistol1Weapon2 = _003C_003E4__this;
			GameManager core = GM.Core;
			ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)unused_EME_Pistol1Weapon2)._003COwner_003Ek__BackingField + 176);
			Transform target = core._stage.PickRandomEnemyInScreenBounds(ref rng);
			object obj = 0;
			object obj2 = default(object);
			obj = obj2;
			do
			{
				int num = obj + index;
				Projectile projectile = unused_EME_Pistol1Weapon2.FireOneProjectile(pos, num, target);
				obj++;
			}
			while ((nint)obj < 4);
		}
	}

	private Timer _prefireTimer;

	private BulletPool _bdShotPool;

	protected Projectile _bdShotPrefsb;

	protected override int EvolutionLevel => 8;

	protected override int _comboIndex1 => 1;

	protected override int _comboIndex2 => 3;

	protected override int ComboIndexFinal => base.ComboIndex1;

	public override float PSpeed()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PSpeed();
		float num2 = default(float);
		bool flag = !(2.5f > num2);
		float num3 = 2.5f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num4 = num3 * currentWeaponData._003Cspeed_003Ek__BackingField;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			if (characterController2._sineSpeed != null)
			{
				float value = characterController2._sineSpeed.Value;
				num4 *= value;
			}
		}
		return num4;
	}

	protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
	{
		if (level == 1)
		{
			return WeaponType.EME_PISTOL_TECH_01;
		}
		bool flag = level != 2;
		WeaponType result = WeaponType.VOID;
		if (!flag)
		{
			result = WeaponType.EME_PISTOL_TECH_02;
		}
		return result;
	}

	protected override void OnStart()
	{
		//IL_0054: Expected I, but got O
		//IL_00f7: Expected I, but got O
		((Weapon)this).OnStart();
		base.InitGlimmer1BulletPool();
		base.InitGlimmer2BulletPool();
		base.InitGlimmer3BulletPool();
		BulletPool bdShotPool = new BulletPool(_bdShotPrefsb);
		_bdShotPool = bdShotPool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.unused_EME_Pistol1Weapon>)+350]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_bdShotPool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.unused_EME_Pistol1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_bdShotPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			return;
		}
		throw new NullReferenceException();
	}

	public void DoBoundingShotExplosionAt(Vector2 position)
	{
		Projectile projectile = base.FireOneProjectile(position, 0);
	}

	protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		Projectile projectile = base.FireOneProjectile(pos, index, target);
	}

	protected unsafe override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		CS_0024_003C_003E8__locals8.pos = pos;
		BulletPool pool2 = default(BulletPool);
		CS_0024_003C_003E8__locals8.pool = pool2;
		CS_0024_003C_003E8__locals8.index = index;
		if (CS_0024_003C_003E8__locals8.pool != _glimmer1Pool)
		{
			return;
		}
		if (_prefireTimer != null)
		{
			_prefireTimer.Cancel();
		}
		Action onComplete = delegate
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected Ref, but got Unknown
			//IL_0046: Expected O, but got I4
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected I4, but got Unknown
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Expected O, but got Unknown
			unused_EME_Pistol1Weapon unused_EME_Pistol1Weapon2 = CS_0024_003C_003E8__locals8._003C_003E4__this;
			GameManager core = GM.Core;
			ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)unused_EME_Pistol1Weapon2)._003COwner_003Ek__BackingField + 176);
			Transform target2 = core._stage.PickRandomEnemyInScreenBounds(ref rng);
			object obj = 0;
			object obj2 = default(object);
			obj = obj2;
			do
			{
				int index2 = obj + CS_0024_003C_003E8__locals8.index;
				Projectile projectile = unused_EME_Pistol1Weapon2.FireOneProjectile(CS_0024_003C_003E8__locals8.pos, index2, target2);
				obj++;
			}
			while ((nint)obj < 4);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer prefireTimer = Timers.Register(0.001f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_prefireTimer = prefireTimer;
	}

	private unsafe void FireCrossShotAfterDelay(Vector2 pos, int index, BulletPool pool)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected Ref, but got Unknown
		//IL_0034: Expected O, but got I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected I4, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		GameManager core = GM.Core;
		ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)this)._003COwner_003Ek__BackingField + 176);
		Transform target = core._stage.PickRandomEnemyInScreenBounds(ref rng);
		object obj = 0;
		object obj2 = default(object);
		obj = obj2;
		do
		{
			int index2 = obj + index;
			Projectile projectile = base.FireOneProjectile(pos, index2, target);
			obj++;
		}
		while ((nint)obj < 4);
	}

	public override void ParadoxFire()
	{
		Fire(skipTriggers: true);
		Action onComplete = delegate
		{
			Fire(skipTriggers: true);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.05f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			Fire(skipTriggers: true);
		};
		Timer timer2 = Timers.Register(0.1f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	private void _003CParadoxFire_003Eb__18_0()
	{
		Fire(skipTriggers: true);
	}

	private void _003CParadoxFire_003Eb__18_1()
	{
		Fire(skipTriggers: true);
	}
}
