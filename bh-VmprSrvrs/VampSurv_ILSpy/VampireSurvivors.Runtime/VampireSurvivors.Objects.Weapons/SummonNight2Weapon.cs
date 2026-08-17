using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
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

public class SummonNight2Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__3_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnStart_003Eb__3_0()
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			config._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Night2;
			GM.Core.SetupMusicBanger();
		}
	}

	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public SummonNight2Weapon _003C_003E4__this;

		public float x;

		public float incrementUnit;

		public float y;

		public float y2;
	}

	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public int index;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals1;

		internal void _003CFire_003Eb__0()
		{
			_003C_003Ec__DisplayClass4_0 obj = CS_0024_003C_003E8__locals1;
			SummonNight2Weapon summonNight2Weapon = obj._003C_003E4__this;
			float2 position = default(float2);
			Projectile projectile = obj._003C_003E4__this.FireOneBullet_RedPool(position, index, summonNight2Weapon._targetTransform);
		}
	}

	private sealed class _003C_003Ec__DisplayClass4_2
	{
		public int index;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals2;

		internal void _003CFire_003Eb__1()
		{
			_003C_003Ec__DisplayClass4_0 obj = CS_0024_003C_003E8__locals2;
			SummonNight2Weapon summonNight2Weapon = obj._003C_003E4__this;
			Vector2 pos = default(Vector2);
			Projectile projectile = obj._003C_003E4__this.FireOneProjectile(pos, index, summonNight2Weapon._targetTransform);
		}
	}

	private BulletPool _redPool;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_skipAddingEvolution = true;
		base.InitWeapon(characterController, weaponType);
	}

	protected Projectile FireOneBullet_RedPool(float2 position, int index, Transform target)
	{
		Projectile projectile;
		if (_redPool != null)
		{
			projectile = _redPool.SpawnAt(position, this, index);
			if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
			{
				goto IL_009b;
			}
			if ((object)projectile != null)
			{
				if (((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0)
				{
					goto IL_009b;
				}
				projectile.SetTarget(target);
			}
			goto IL_0137;
		}
		return (Projectile)(object)new NullReferenceException();
		IL_009b:
		projectile?.SetNullTarget();
		goto IL_0137;
		IL_0137:
		return projectile;
	}

	protected override void OnStart()
	{
		//IL_0080: Expected I, but got O
		//IL_0123: Expected I, but got O
		//IL_01ba: Expected I4, but got O
		base.OnStart();
		Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.SUMMONNIGHT);
		BulletPool redPool = new BulletPool(projectilePrefab);
		_redPool = redPool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.SummonNight2Weapon>)+350]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback arcadePhysicsCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_redPool, core.Enemies, collideCallback, arcadePhysicsCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.SummonNight2Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_redPool, physicsManager._destructiblesGroup, collideCallback2, arcadePhysicsCallback, callbackContext);
			if (SoundManager._003CCurrentBgm_003Ek__BackingField != BgmType.BGM_Night1)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
			BgmType bgmType = default(BgmType);
			SoundManager.FadeMusic(bgmType, 0f, 100f);
			Action onComplete = _003C_003Ec._003C_003E9__3_0;
			if (_003C_003Ec._003C_003E9__3_0 == null)
			{
				onComplete = (_003C_003Ec._003C_003E9__3_0 = delegate
				{
					GameManager core3 = GM.Core;
					PlayerOptionsData config = core3._playerOptions.Config;
					config._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Night2;
					GM.Core.SetupMusicBanger();
				});
			}
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, (byte)(int)arcadePhysicsCallback != 0, (MonoBehaviour)(object)callbackContext, repeat, type, isOnlineTimer: false, canPause: false);
			return;
		}
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0161: Expected O, but got I4
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_02af: Expected I4, but got F4
		//IL_0216: Expected O, but got F4
		//IL_05bd: Invalid comparison between F4 and I4
		//IL_04ec: Invalid comparison between F4 and I4
		//IL_0523: Expected F4, but got I4
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Expected O, but got Unknown
		//IL_049b: Expected I4, but got F4
		//IL_0403: Expected O, but got F4
		_003C_003Ec__DisplayClass4_0 obj = new _003C_003Ec__DisplayClass4_0();
		obj._003C_003E4__this = this;
		float num = base.PAmount();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		object obj2 = default(object);
		float num2 = (float)obj2 + 1f;
		float incrementUnit = renderer.width / num2;
		obj.incrementUnit = incrementUnit;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num3 = renderer2.width * 0.5f;
		float x = (float)position - num3;
		obj.x = x;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		float num4 = renderer3.height * 0.5f;
		object obj3 = default(object);
		float y = num4 + (float)obj3;
		obj.y = y;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = 300f;
		soundConfig.Volume = (float?)(object)1;
		float num5 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ExploNight, soundConfig, 100f, 8, num5);
		_003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals25 = new _003C_003Ec__DisplayClass4_1();
		CS_0024_003C_003E8__locals25.CS_0024_003C_003E8__locals1 = obj;
		CS_0024_003C_003E8__locals25.index = 0;
		float num6 = default(float);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while ((nint)obj2 > CS_0024_003C_003E8__locals25.index)
		{
			WeaponData currentWeaponData = _currentWeaponData;
			object obj4 = CS_0024_003C_003E8__locals25.index * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			if ((nint)obj4 <= 0)
			{
				Projectile projectile = FireOneBullet_RedPool((float2)num6, CS_0024_003C_003E8__locals25.index, _targetTransform);
				int index = CS_0024_003C_003E8__locals25.index + 1;
				CS_0024_003C_003E8__locals25.index = index;
				continue;
			}
			Action onComplete = delegate
			{
				_003C_003Ec__DisplayClass4_0 obj6 = CS_0024_003C_003E8__locals25.CS_0024_003C_003E8__locals1;
				SummonNight2Weapon summonNight2Weapon = obj6._003C_003E4__this;
				float2 position4 = default(float2);
				Projectile projectile3 = obj6._003C_003E4__this.FireOneBullet_RedPool(position4, CS_0024_003C_003E8__locals25.index, summonNight2Weapon._targetTransform);
			};
			float num7 = (float)CS_0024_003C_003E8__locals25.index * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			float duration = num7 * 0.001f;
			Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num5 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_lastShotTimer = lastShotTimer;
			int index2 = CS_0024_003C_003E8__locals25.index + 1;
			CS_0024_003C_003E8__locals25.index = index2;
		}
		float num8 = (float)obj2 - 1f;
		float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene4 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer4 = s_scene4._renderer;
			float num9 = renderer4.height * 0.5f;
			float y2 = 1.0636755E+09f - num9;
			obj.y2 = y2;
			_003C_003Ec__DisplayClass4_2 CS_0024_003C_003E8__locals27 = new _003C_003Ec__DisplayClass4_2();
			CS_0024_003C_003E8__locals27.CS_0024_003C_003E8__locals2 = obj;
			CS_0024_003C_003E8__locals27.index = 0;
			while (num8 > (float)CS_0024_003C_003E8__locals27.index)
			{
				WeaponData currentWeaponData2 = _currentWeaponData;
				object obj5 = CS_0024_003C_003E8__locals27.index * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
				if ((nint)obj5 <= 0)
				{
					Projectile projectile2 = base.FireOneProjectile((Vector2)num6, CS_0024_003C_003E8__locals27.index, _targetTransform);
					int index3 = CS_0024_003C_003E8__locals27.index + 1;
					CS_0024_003C_003E8__locals27.index = index3;
					continue;
				}
				Action onComplete2 = delegate
				{
					_003C_003Ec__DisplayClass4_0 obj6 = CS_0024_003C_003E8__locals27.CS_0024_003C_003E8__locals2;
					SummonNight2Weapon summonNight2Weapon = obj6._003C_003E4__this;
					Vector2 pos = default(Vector2);
					Projectile projectile3 = obj6._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals27.index, summonNight2Weapon._targetTransform);
				};
				float num10 = (float)CS_0024_003C_003E8__locals27.index * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
				float duration2 = num10 * 0.001f;
				Timer lastShotTimer2 = Timers.Register(duration2, onComplete2, null, isLooped: false, (byte)(int)num5 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_lastShotTimer = lastShotTimer2;
				int index4 = CS_0024_003C_003E8__locals27.index + 1;
				CS_0024_003C_003E8__locals27.index = index4;
			}
			float num11 = base.PInterval();
			bool flag = _lastFiringInterval == (float)CS_0024_003C_003E8__locals27.index;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187555B33h\"");
			if (!flag)
			{
				float num12 = base.PInterval();
				_lastFiringInterval = CS_0024_003C_003E8__locals27.index;
				base.ResetFiringTimer();
			}
			if (!skipTriggers)
			{
				((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
			}
			return;
		}
		throw new NullReferenceException();
	}
}
