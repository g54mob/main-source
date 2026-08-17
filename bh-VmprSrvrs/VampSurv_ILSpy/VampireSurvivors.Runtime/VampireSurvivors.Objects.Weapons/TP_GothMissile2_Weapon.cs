using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class TP_GothMissile2_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public TP_GothMissile2_Weapon _003C_003E4__this;

		public bool crit;

		internal void _003CFire_003Eb__0()
		{
			_003C_003E4__this.ShowCritSnipers(show: false);
		}

		internal void _003CFire_003Eb__1()
		{
			TP_GothMissile2_Weapon tP_GothMissile2_Weapon = _003C_003E4__this;
			float2 position = ((Equipment)tP_GothMissile2_Weapon)._003COwner_003Ek__BackingField.position;
			float2 pos = default(float2);
			Projectile projectile = tP_GothMissile2_Weapon._songProjectilePool.SpawnAt(pos, _003C_003E4__this);
		}
	}

	private sealed class _003C_003Ec__DisplayClass27_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals1;

		internal void _003CFire_003Eb__2()
		{
			//IL_0129: Expected O, but got I4
			//IL_00a8->IL00f2: Incompatible stack heights: 1 vs 0
			//IL_00ca->IL00f2: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass27_0 obj = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass27_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
					{
						obj3._003C_003E4__this.FireMissiles(localIndex, obj3.crit);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public PhaserSprite s;

		internal unsafe void _003CShowCritSnipers_003Eb__3()
		{
			//IL_0033: Expected O, but got I4
			//IL_0079: Expected O, but got Ref
			PhaserSprite phaserSprite = s.setAlpha(0.8f);
			PhaserSprite phaserSprite2 = s.setScale(0f, (float?)(object)1);
			Transform transform = s.transform;
			object obj = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform, (Vector3)(&obj), 0.1f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
		}
	}

	private Projectile _SongProjectilePrefab;

	private const float FireDelayMillis = 700f;

	private const float SniperAlpha = 0.8f;

	private const float SongDamageMultiplier = 2.5f;

	private BulletPool _songProjectilePool;

	private PhaserSprite _sniperSprite1;

	private PhaserSprite _sniperSprite2;

	private PhaserSprite _sniperSprite1A;

	private PhaserSprite _sniperSprite1B;

	private PhaserSprite _sniperSprite2A;

	private PhaserSprite _sniperSprite2B;

	private PhaserSprite _sniperSprite1_BG;

	private PhaserSprite _sniperSprite2_BG;

	private PhaserSprite _sniperSprite1A_BG;

	private PhaserSprite _sniperSprite1B_BG;

	private PhaserSprite _sniperSprite2A_BG;

	private PhaserSprite _sniperSprite2B_BG;

	private MultiTargetTween _sniperTween1;

	private MultiTargetTween _sniperTween2;

	private MultiTargetTween _critSniperTween;

	private Timer _critSniperTimer;

	private Timer _songFiringTimer;

	public override float HeartOfFirePower
	{
		get
		{
			WeaponData currentWeaponData = _currentWeaponData;
			return currentWeaponData._003Cpower_003Ek__BackingField * 2.5f;
		}
	}

	public override float PInterval()
	{
		float num = base.PInterval();
		bool flag = !(750f < num);
		float result = 750f;
		if (!flag)
		{
			result = num;
		}
		return result;
	}

	protected unsafe override void OnStart()
	{
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected Ref, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Ref, but got Unknown
		//IL_024b: Expected I, but got O
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected Ref, but got Unknown
		//IL_02c8: Expected I, but got O
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected Ref, but got Unknown
		//IL_0345: Expected I, but got O
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Expected Ref, but got Unknown
		//IL_03c2: Expected I, but got O
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Expected Ref, but got Unknown
		//IL_01a9: Expected I, but got O
		base.OnStart();
		_ = 0;
		ref PhaserSprite spriteBG = ref *(PhaserSprite*)(this + 408);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-20]");
		_ = 0;
		_ = 0;
		float2? float5 = default(float2?);
		PhaserSprite sniperSprite = CreateSniperSprite(ref spriteBG, mainSniper: true, flipped: false, float5);
		_sniperSprite1 = sniperSprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-20]");
		_ = 0;
		_ = 0;
		PhaserSprite sniperSprite2 = CreateSniperSprite(ref *(PhaserSprite*)(this + 416), mainSniper: true, flipped: true, float5);
		_sniperSprite2 = sniperSprite2;
		DoSniperTweens();
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rax_v11 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_ = 0;
		ref PhaserSprite spriteBG2 = ref *(PhaserSprite*)(this + 424);
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v9 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
		_ = 0;
		PhaserSprite sniperSprite1A = CreateSniperSprite(ref spriteBG2, mainSniper: false, flipped: false, float5);
		_sniperSprite1A = sniperSprite1A;
		nint num3 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v17 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num4 = 0;
		_ = 0;
		ref PhaserSprite spriteBG3 = ref *(PhaserSprite*)(this + 432);
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rcx_v13 (Il2CppStaticFields<UnityEngine.Vector2>)+1C]");
		_ = 0;
		PhaserSprite sniperSprite1B = CreateSniperSprite(ref spriteBG3, mainSniper: false, flipped: false, float5);
		_sniperSprite1B = sniperSprite1B;
		nint num5 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v23 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num6 = 0;
		_ = 0;
		ref PhaserSprite spriteBG4 = ref *(PhaserSprite*)(this + 440);
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ rcx_v17 (Il2CppStaticFields<UnityEngine.Vector2>)+24]");
		_ = 0;
		PhaserSprite sniperSprite2A = CreateSniperSprite(ref spriteBG4, mainSniper: false, flipped: true, float5);
		_sniperSprite2A = sniperSprite2A;
		nint num7 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rax_v29 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num8 = 0;
		_ = 0;
		ref PhaserSprite spriteBG5 = ref *(PhaserSprite*)(this + 448);
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ rcx_v20 (Il2CppStaticFields<UnityEngine.Vector2>)+1C]");
		_ = 0;
		PhaserSprite sniperSprite2B = CreateSniperSprite(ref spriteBG5, mainSniper: false, flipped: true, float5);
		_sniperSprite2B = sniperSprite2B;
		if (_songProjectilePool != null)
		{
			return;
		}
		BulletPool songProjectilePool = new BulletPool(_SongProjectilePrefab);
		_songProjectilePool = songProjectilePool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemy_Song;
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_songProjectilePool, core.Enemies, collideCallback, (ArcadePhysicsCallback)float5, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1020 @ r8_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_GothMissile2_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num9 = (nint)this;
				Collider collider2 = physics2.add.overlap(_songProjectilePool, physicsManager._destructiblesGroup, collideCallback2, (ArcadePhysicsCallback)float5, callbackContext);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				GameManager gameMan2 = _gameMan;
				float heartOfFirePower = HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan2._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
		CheckBeginningArcana();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0071: Expected O, but got I
		//IL_00d2: Invalid comparison between F4 and I
		//IL_00f8: Invalid comparison between F4 and I4
		//IL_02c4: Invalid comparison between F4 and I4
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Expected O, but got Unknown
		//IL_0488: Invalid comparison between O and F4
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_0324: Invalid comparison between F4 and I4
		//IL_043b: Invalid comparison between F4 and I4
		_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass27_0();
		CS_0024_003C_003E8__locals10._003C_003E4__this = this;
		List<float> critChancesArray = _critChancesArray;
		int critIndex = _critIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rcx_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)critIndex % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rcx_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rcx_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			int critIndex2 = _critIndex + 1;
			_critIndex = critIndex2;
			WeaponData currentWeaponData = _currentWeaponData;
			float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			object obj2 = default(object);
			float num3 = (float)obj2 * currentWeaponData._003CcritChance_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rcx_v9+20+v149 @ rdx_v6 (System.Int32)*4]");
			bool flag = num3 < 0f;
			float num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rcx_v9+20+v149 @ rdx_v6 (System.Int32)*4]");
			float num5 = num4 - 0f;
			bool flag2 = num5 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			if (CS_0024_003C_003E8__locals10.crit = flag4 & flag3)
			{
				ShowCritSnipers(show: true);
				if (_critSniperTimer != null)
				{
					_critSniperTimer.Cancel();
				}
				float num6 = base.PAmount();
				WeaponData currentWeaponData2 = _currentWeaponData;
				Action onComplete = delegate
				{
					CS_0024_003C_003E8__locals10._003C_003E4__this.ShowCritSnipers(show: false);
				};
				float num7 = currentWeaponData2._003CrepeatInterval_003Ek__BackingField * num3;
				float num8 = num7 + 1400f;
				float duration = num8 * 0.001f;
				Timer critSniperTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_critSniperTimer = critSniperTimer;
			}
			if (_songFiringTimer != null)
			{
				_songFiringTimer.Cancel();
			}
			Action onComplete2 = delegate
			{
				TP_GothMissile2_Weapon tP_GothMissile2_Weapon = CS_0024_003C_003E8__locals10._003C_003E4__this;
				float2 position = ((Equipment)tP_GothMissile2_Weapon)._003COwner_003Ek__BackingField.position;
				float2 pos = default(float2);
				Projectile projectile = tP_GothMissile2_Weapon._songProjectilePool.SpawnAt(pos, CS_0024_003C_003E8__locals10._003C_003E4__this);
			};
			Timer songFiringTimer = Timers.Register(0.70000005f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_songFiringTimer = songFiringTimer;
			float num9 = base.PAmount();
			bool flag5 = !(0.70000005f > 0f);
			float num10 = 0.70000005f;
			if (!flag5)
			{
				bool flag6 = false;
				do
				{
					WeaponData currentWeaponData3 = _currentWeaponData;
					object obj3 = flag6 * currentWeaponData3._003CrepeatInterval_003Ek__BackingField;
					num10 = (float)obj3 + 700f;
					if (!(num10 > 0f))
					{
						FireMissiles(flag6 ? 1 : 0, CS_0024_003C_003E8__locals10.crit);
					}
					else
					{
						_003C_003Ec__DisplayClass27_1 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass27_1();
						CS_0024_003C_003E8__locals15.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals10;
						CS_0024_003C_003E8__locals15.localIndex = (flag6 ? 1 : 0);
						WeaponData currentWeaponData4 = _currentWeaponData;
						Action onComplete3 = delegate
						{
							//IL_0129: Expected O, but got I4
							//IL_00a8->IL00f2: Incompatible stack heights: 1 vs 0
							//IL_00ca->IL00f2: Incompatible stack heights: 1 vs 0
							_003C_003Ec__DisplayClass27_0 obj5 = CS_0024_003C_003E8__locals15.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals15.CS_0024_003C_003E8__locals1 != null && (object)obj5._003C_003E4__this != null)
							{
								GameObject gameObject = obj5._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag7 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj6 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj6 == null)
									{
										return;
									}
									_003C_003Ec__DisplayClass27_0 obj7 = CS_0024_003C_003E8__locals15.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals15.CS_0024_003C_003E8__locals1 != null && (object)obj7._003C_003E4__this != null)
									{
										obj7._003C_003E4__this.FireMissiles(CS_0024_003C_003E8__locals15.localIndex, obj7.crit);
										return;
									}
								}
							}
							throw new NullReferenceException();
						};
						float num11 = (float)(flag6 ? 1 : 0) * currentWeaponData4._003CrepeatInterval_003Ek__BackingField;
						float num12 = num11 + 700f;
						num10 = num12 * 0.001f;
						Timer lastShotTimer = Timers.Register(num10, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
					}
					flag6 = (byte)((flag6 ? 1u : 0u) + 1u) != 0;
					float num13 = base.PAmount();
				}
				while (num10 > (float)(flag6 ? 1 : 0));
			}
			float num14 = PInterval();
			float num15 = _lastFiringInterval - num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj4 = num15 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
			{
				float num16 = PInterval();
				_lastFiringInterval = num10;
				base.ResetFiringTimer();
			}
			if (!skipTriggers)
			{
				((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void FireMissiles(int index, bool isCrit)
	{
		//IL_006e: Expected I, but got O
		//IL_007c: Expected I, but got O
		//IL_008c: Expected O, but got I
		//IL_010c: Expected O, but got I4
		//IL_00c8: Expected O, but got I
		//IL_0131: Expected I, but got O
		//IL_013f: Expected I, but got O
		//IL_014f: Expected O, but got I
		//IL_00fe: Expected O, but got I4
		//IL_01cf: Expected O, but got I4
		//IL_018b: Expected O, but got I
		//IL_01c1: Expected O, but got I4
		//IL_035d: Expected I, but got O
		//IL_036b: Expected I, but got O
		//IL_037b: Expected O, but got I
		//IL_03fb: Expected O, but got I4
		//IL_03b7: Expected O, but got I
		//IL_041f: Expected I, but got O
		//IL_042d: Expected I, but got O
		//IL_043d: Expected O, but got I
		//IL_03ed: Expected O, but got I4
		//IL_04bd: Expected O, but got I4
		//IL_0479: Expected O, but got I
		//IL_04e1: Expected I, but got O
		//IL_04ef: Expected I, but got O
		//IL_04ff: Expected O, but got I
		//IL_04af: Expected O, but got I4
		//IL_057f: Expected O, but got I4
		//IL_053b: Expected O, but got I
		//IL_0571: Expected O, but got I4
		//IL_0599: Expected I, but got O
		//IL_05a7: Expected I, but got O
		//IL_05b7: Expected O, but got I
		//IL_0637: Expected O, but got I4
		//IL_05f3: Expected O, but got I
		//IL_0629: Expected O, but got I4
		float2 position = _sniperSprite1.position;
		float2 position2 = _sniperSprite2.position;
		Vector2 pos = default(Vector2);
		Projectile projectile = base.FireOneProjectile(pos, index);
		TP_GothMissile2_Projectile tP_GothMissile2_Projectile;
		if ((object)projectile == null)
		{
			tP_GothMissile2_Projectile = null;
			goto IL_081d;
		}
		nint num = (nint)projectile;
		nint num2 = (nint)typeof(TP_GothMissile2_Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile2_Projectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ r8_v36 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile2_Projectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ r8_v36 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v142+FFFFFFF8+v352 @ rax_v138*8]");
			if (0 == (nint)typeof(TP_GothMissile2_Projectile))
			{
				obj3 = 1;
				goto IL_0851;
			}
		}
		obj3 = 0;
		goto IL_0851;
		IL_098b:
		Projectile projectile2 = base.FireOneProjectile(pos, index);
		bool flag = (object)projectile2 == null;
		TP_GothMissile2_Projectile tP_GothMissile2_Projectile2 = null;
		object obj6;
		if (!flag)
		{
			nint num4 = (nint)projectile2;
			nint num5 = (nint)typeof(TP_GothMissile2_Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1208 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile2_Projectile>)+130]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1207 @ r8_v28 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1208 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile2_Projectile>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1207 @ r8_v28 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1274 @ rax_v98+FFFFFFF8+v1209 @ rax_v94*8]");
				if (0 == (nint)typeof(TP_GothMissile2_Projectile))
				{
					obj6 = 1;
					goto IL_09e3;
				}
			}
			obj6 = 0;
			goto IL_09e3;
		}
		goto IL_0a0a;
		IL_08a0:
		if ((object)tP_GothMissile2_Projectile != null && ((UnityEngine.Object)tP_GothMissile2_Projectile).m_CachedPtr != (IntPtr)0)
		{
			float num7 = UnityEngine.Random.Range(-5f, 5f);
			float angle = num7 - 45f;
			tP_GothMissile2_Projectile.SetAngle(angle);
		}
		TP_GothMissile2_Projectile tP_GothMissile2_Projectile3;
		if ((object)tP_GothMissile2_Projectile3 != null && ((UnityEngine.Object)tP_GothMissile2_Projectile3).m_CachedPtr != (IntPtr)0)
		{
			float num8 = UnityEngine.Random.Range(-5f, 5f);
			float angle2 = num8 - 135f;
			tP_GothMissile2_Projectile3.SetAngle(angle2);
		}
		if (!isCrit)
		{
			return;
		}
		float2 position3 = _sniperSprite1A.position;
		float2 position4 = _sniperSprite1B.position;
		float2 position5 = _sniperSprite2A.position;
		float2 position6 = _sniperSprite2B.position;
		Projectile projectile3 = base.FireOneProjectile(pos, index);
		TP_GothMissile2_Projectile tP_GothMissile2_Projectile4;
		if ((object)projectile3 == null)
		{
			tP_GothMissile2_Projectile4 = null;
			goto IL_08df;
		}
		nint num9 = (nint)projectile3;
		nint num10 = (nint)typeof(TP_GothMissile2_Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile2_Projectile>)+130]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v888 @ r8_v31 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile2_Projectile>)+130]");
		object obj9;
		if (num11 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v888 @ r8_v31 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v960 @ rax_v116+FFFFFFF8+v890 @ rax_v112*8]");
			if (0 == (nint)typeof(TP_GothMissile2_Projectile))
			{
				obj9 = 1;
				goto IL_0913;
			}
		}
		obj9 = 0;
		goto IL_0913;
		IL_09c1:
		object obj10;
		bool flag2 = obj10 == null;
		TP_GothMissile2_Projectile tP_GothMissile2_Projectile5 = null;
		Projectile projectile4;
		if (!flag2)
		{
			tP_GothMissile2_Projectile5 = (TP_GothMissile2_Projectile)projectile4;
		}
		goto IL_098b;
		IL_09e3:
		bool flag3 = obj6 == null;
		tP_GothMissile2_Projectile2 = null;
		if (!flag3)
		{
			tP_GothMissile2_Projectile2 = (TP_GothMissile2_Projectile)projectile2;
		}
		goto IL_0a0a;
		IL_0851:
		bool flag4 = obj3 == null;
		tP_GothMissile2_Projectile = null;
		if (!flag4)
		{
			tP_GothMissile2_Projectile = (TP_GothMissile2_Projectile)projectile;
		}
		goto IL_081d;
		IL_0969:
		object obj11;
		bool flag5 = obj11 == null;
		TP_GothMissile2_Projectile tP_GothMissile2_Projectile6 = null;
		Projectile projectile5;
		if (!flag5)
		{
			tP_GothMissile2_Projectile6 = (TP_GothMissile2_Projectile)projectile5;
		}
		goto IL_0935;
		IL_0878:
		object obj12;
		bool flag6 = obj12 == null;
		tP_GothMissile2_Projectile3 = null;
		Projectile projectile6;
		if (!flag6)
		{
			tP_GothMissile2_Projectile3 = (TP_GothMissile2_Projectile)projectile6;
		}
		goto IL_08a0;
		IL_081d:
		projectile6 = base.FireOneProjectile(pos, index);
		if ((object)projectile6 == null)
		{
			tP_GothMissile2_Projectile3 = null;
			goto IL_08a0;
		}
		nint num12 = (nint)projectile6;
		nint num13 = (nint)typeof(TP_GothMissile2_Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile2_Projectile>)+130]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile2_Projectile>)+130]");
		if (num14 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v513 @ rax_v136+FFFFFFF8+v448 @ rax_v132*8]");
			if (0 == (nint)typeof(TP_GothMissile2_Projectile))
			{
				obj12 = 1;
				goto IL_0878;
			}
		}
		obj12 = 0;
		goto IL_0878;
		IL_0a0a:
		float num16;
		if ((object)tP_GothMissile2_Projectile4 != null && ((UnityEngine.Object)tP_GothMissile2_Projectile4).m_CachedPtr != (IntPtr)0)
		{
			float num15 = UnityEngine.Random.Range(-5f, 5f);
			float angle3 = num15 - 45f;
			tP_GothMissile2_Projectile4.SetAngle(angle3);
			num16 = 45f;
		}
		else
		{
			num16 = 45f;
		}
		if ((object)tP_GothMissile2_Projectile6 != null && ((UnityEngine.Object)tP_GothMissile2_Projectile6).m_CachedPtr != (IntPtr)0)
		{
			float num17 = UnityEngine.Random.Range(-5f, 5f);
			float angle4 = num17 - num16;
			tP_GothMissile2_Projectile6.SetAngle(angle4);
		}
		float num19;
		if ((object)tP_GothMissile2_Projectile5 != null && ((UnityEngine.Object)tP_GothMissile2_Projectile5).m_CachedPtr != (IntPtr)0)
		{
			float num18 = UnityEngine.Random.Range(-5f, 5f);
			float angle5 = num18 - 135f;
			tP_GothMissile2_Projectile5.SetAngle(angle5);
			num19 = 135f;
		}
		else
		{
			num19 = 135f;
		}
		if ((object)tP_GothMissile2_Projectile2 != null && ((UnityEngine.Object)tP_GothMissile2_Projectile2).m_CachedPtr != (IntPtr)0)
		{
			float num20 = UnityEngine.Random.Range(-5f, 5f);
			float angle6 = num20 - num19;
			tP_GothMissile2_Projectile2.SetAngle(angle6);
		}
		return;
		IL_0913:
		bool flag7 = obj9 == null;
		tP_GothMissile2_Projectile4 = null;
		if (!flag7)
		{
			tP_GothMissile2_Projectile4 = (TP_GothMissile2_Projectile)projectile3;
		}
		goto IL_08df;
		IL_0935:
		projectile4 = base.FireOneProjectile(pos, index);
		if ((object)projectile4 == null)
		{
			tP_GothMissile2_Projectile5 = null;
			goto IL_098b;
		}
		nint num21 = (nint)projectile4;
		nint num22 = (nint)typeof(TP_GothMissile2_Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1102 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile2_Projectile>)+130]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1101 @ r8_v29 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1102 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile2_Projectile>)+130]");
		if (num23 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1101 @ r8_v29 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1181 @ rax_v104+FFFFFFF8+v1103 @ rax_v100*8]");
			if (0 == (nint)typeof(TP_GothMissile2_Projectile))
			{
				obj10 = 1;
				goto IL_09c1;
			}
		}
		obj10 = 0;
		goto IL_09c1;
		IL_08df:
		projectile5 = base.FireOneProjectile(pos, index);
		if ((object)projectile5 == null)
		{
			tP_GothMissile2_Projectile6 = null;
			goto IL_0935;
		}
		nint num24 = (nint)projectile5;
		nint num25 = (nint)typeof(TP_GothMissile2_Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v988 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile2_Projectile>)+130]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ r8_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v988 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile2_Projectile>)+130]");
		if (num26 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ r8_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ rax_v110+FFFFFFF8+v989 @ rax_v106*8]");
			if (0 == (nint)typeof(TP_GothMissile2_Projectile))
			{
				obj11 = 1;
				goto IL_0969;
			}
		}
		obj11 = 0;
		goto IL_0969;
	}

	private unsafe PhaserSprite CreateSniperSprite(ref PhaserSprite spriteBG, bool mainSniper = false, bool flipped = false, float2? extraOffset = null)
	{
		//IL_0440: Expected O, but got I4
		//IL_0440: Expected I4, but got O
		//IL_0471: Expected O, but got I4
		//IL_0471: Expected I4, but got O
		SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
		if (SpriteTextures.Thosepeople != null && thosepeople.Thosepeople != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1690]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)this != null)
			{
				GameObject gameObject = base.gameObject;
				Vector2 vector = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_MagicMissile01");
				Camera main = Camera.main;
				if ((object)main != null)
				{
					Transform parent = main.transform;
					if ((object)phaserSprite != null)
					{
						Transform transform = phaserSprite.transform;
						if ((object)transform != null)
						{
							transform.SetParent(parent, worldPositionStays: true);
							PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
							if ((object)phaserSprite2 != null)
							{
								PhaserSprite phaserSprite3 = phaserSprite2.setDepth(0);
								if ((object)phaserSprite3 != null)
								{
									GameObject gameObject2 = phaserSprite3.gameObject;
									if ((object)gameObject2 != null)
									{
										((UnityEngine.Object)gameObject2).SetName("GothMissileSniperBG");
										ref PhaserSprite reference = ref *(PhaserSprite*)phaserSprite3;
										SpriteTextures.SpriteTexturesThosepeople thosepeople2 = SpriteTextures.Thosepeople;
										if (SpriteTextures.Thosepeople != null && thosepeople2.Thosepeople != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1780]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
											GameObject gameObject3 = base.gameObject;
											PhaserSprite phaserSprite4 = RenderingExtensions.AddPhaserSprite(gameObject3, vector, "ThosePeople", "TP_VFX_Sniper01");
											if ((object)spriteBG != null)
											{
												Transform parent2 = spriteBG.transform;
												if ((object)phaserSprite4 != null)
												{
													Transform transform2 = phaserSprite4.transform;
													if ((object)transform2 != null)
													{
														transform2.SetParent(parent2, worldPositionStays: true);
														PhaserSprite phaserSprite5 = phaserSprite4.setAlpha(0f);
														if ((object)phaserSprite5 != null)
														{
															PhaserSprite phaserSprite6 = phaserSprite5.setDepth(1);
															if ((object)phaserSprite6 != null)
															{
																PhaserSprite phaserSprite7 = phaserSprite6.setFlipX(flipped);
																if ((object)phaserSprite7 != null)
																{
																	GameObject gameObject4 = phaserSprite7.gameObject;
																	if ((object)gameObject4 != null)
																	{
																		((UnityEngine.Object)gameObject4).SetName("GothMissileSniper");
																		string text = default(string);
																		int num = default(int);
																		bool flag = default(bool);
																		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_MagicMissile", 1, 5, vector, text, num, flag);
																		PhaserSprite phaserSprite8 = spriteBG;
																		if ((object)spriteBG != null && (object)phaserSprite8._spriteAnimation != null)
																		{
																			bool autoSetAnimation = default(bool);
																			phaserSprite8._spriteAnimation.AddAnimation("appear", animationFrames, 24, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
																			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_Sniper", 1, 5, vector, text, num, flag);
																			if ((object)phaserSprite7._spriteAnimation != null)
																			{
																				phaserSprite7._spriteAnimation.AddAnimation("loop", animationFrames2, 12, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
																				if ((object)phaserSprite7._spriteAnimation != null)
																				{
																					phaserSprite7._spriteAnimation.SetAnimation("loop");
																					float width = phaserSprite7.Width;
																					float height = phaserSprite7.Height;
																					if ((object)GM.Core != null)
																					{
																						PhaserScene s_scene = ArcadePhysics.s_scene;
																						if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (flipped || (object)GM.Core != null))
																						{
																							PhaserScene s_scene2 = ArcadePhysics.s_scene;
																							if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
																							{
																								object obj = default(object);
																								bool flag2 = obj == null;
																								float2 localPosition = vector;
																								if (!flag2)
																								{
																									localPosition = vector;
																								}
																								if ((object)spriteBG != null)
																								{
																									PhaserSprite phaserSprite9 = spriteBG.setLocalPosition(localPosition);
																									if (mainSniper)
																									{
																										PhaserSprite phaserSprite10 = phaserSprite7.setAlpha(0.8f);
																										if ((object)spriteBG == null)
																										{
																											goto IL_05ef;
																										}
																										PhaserSprite phaserSprite11 = spriteBG.setVisible(visible: false);
																									}
																									return phaserSprite7;
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_05ef;
		IL_05ef:
		return (PhaserSprite)(object)new NullReferenceException();
	}

	private unsafe void ShowCritSnipers(bool show)
	{
		//IL_0081: Expected O, but got I4
		//IL_02d2: Expected I, but got O
		//IL_02e8: Expected O, but got I
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Expected O, but got Unknown
		//IL_035f: Expected I, but got O
		//IL_05da: Expected O, but got I4
		//IL_05f1: Expected I, but got I8
		//IL_0348: Expected I, but got I8
		//IL_03da: Expected I, but got O
		//IL_03f0: Expected O, but got I
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Expected O, but got Unknown
		//IL_0467: Expected I, but got O
		//IL_0647: Expected I, but got I8
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_0450: Expected I, but got I8
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		//IL_04e2: Expected I, but got O
		//IL_04f8: Expected O, but got I
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Expected O, but got Unknown
		//IL_0574: Expected I, but got O
		//IL_069d: Expected I, but got I8
		//IL_0547: Expected I, but got I8
		List<PhaserSprite> list = new List<PhaserSprite>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
		List<PhaserSprite> list2 = new List<PhaserSprite>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
		object obj = 0;
		while (true)
		{
			if ((nint)obj < list._size)
			{
				_003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass30_0();
				if ((nint)obj >= list._size)
				{
					break;
				}
				PhaserSprite[] items = list._items;
				CS_0024_003C_003E8__locals6.s = items[obj];
				if ((nint)obj >= list2._size)
				{
					break;
				}
				PhaserSprite[] items2 = list2._items;
				PhaserSprite s = CS_0024_003C_003E8__locals6.s;
				PhaserSprite phaserSprite = items2[obj];
				if (!show)
				{
					TweenerCore<Color, Color, ColorOptions> gameId = DOTweenModuleSprite.DOFade(s._spriteRenderer, 0f, 0.25f);
					Tween tween = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
					TweenerCore<Color, Color, ColorOptions> gameId2 = DOTweenModuleSprite.DOFade(phaserSprite._spriteRenderer, 0f, 0.25f);
					Tween tween2 = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId2);
					obj++;
					continue;
				}
				PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals6.s.setAlpha(0f);
				PhaserSprite phaserSprite3 = items2[obj].setAlpha(1f);
				phaserSprite._spriteAnimation.SetAnimation("appear");
				TweenCallback callback = delegate
				{
					//IL_0033: Expected O, but got I4
					//IL_0079: Expected O, but got Ref
					PhaserSprite phaserSprite4 = CS_0024_003C_003E8__locals6.s.setAlpha(0.8f);
					PhaserSprite phaserSprite5 = CS_0024_003C_003E8__locals6.s.setScale(0f, (float?)(object)1);
					Transform target = CS_0024_003C_003E8__locals6.s.transform;
					object obj9 = default(object);
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&obj9), 0.1f);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
				};
				Tween gameId3 = DOVirtual.DelayedCall(0.1f, callback);
				Tween tween3 = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId3);
				obj++;
				nint num = 1;
				continue;
			}
			if (!show)
			{
				return;
			}
			PlayCritSfx();
			TweenCallback tweenCallback = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r10_v5 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback).method = (nint)__ldftn(TP_GothMissile2_Weapon._003CShowCritSnipers_003Eb__30_0);
			((Delegate)tweenCallback).m_target = this;
			((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r10_v5 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num3;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r10_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num3 = unchecked((nint)6447293664L);
					goto IL_05d1;
				}
			}
			((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
			num3 = ((Delegate)tweenCallback).method_ptr;
			goto IL_05d1;
			IL_0686:
			TweenCallback tweenCallback2;
			((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
			Tween tween4 = DOVirtual.DelayedCall(0.15f, tweenCallback2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			tween4.stringId = "DefaultGameTweenId";
			return;
			IL_0630:
			TweenCallback tweenCallback3;
			((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
			Tween tween5 = DOVirtual.DelayedCall(0.1f, tweenCallback3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			tween5.stringId = "DefaultGameTweenId";
			tweenCallback2 = null;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v7 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback2).method = (nint)__ldftn(TP_GothMissile2_Weapon._003CShowCritSnipers_003Eb__30_2);
			((Delegate)tweenCallback2).m_target = this;
			((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v7 (Il2CppMethodInfo)+4C]");
			object obj4 = (nint)0 >> 4;
			object obj5 = obj4 & 1;
			nint num5;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v7 (Il2CppMethodInfo)+52]");
				bool flag = (nint)0 == 0;
				num5 = unchecked((nint)6447293664L);
				if (flag)
				{
					goto IL_0686;
				}
			}
			num5 = ((Delegate)tweenCallback2).method_ptr;
			((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
			goto IL_0686;
			IL_05d1:
			object obj6 = 24;
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			Tween tween6 = DOVirtual.DelayedCall(0.05f, tweenCallback);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			tween6.stringId = "DefaultGameTweenId";
			tweenCallback3 = null;
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v6 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback3).method = (nint)__ldftn(TP_GothMissile2_Weapon._003CShowCritSnipers_003Eb__30_1);
			((Delegate)tweenCallback3).m_target = this;
			((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v6 (Il2CppMethodInfo)+4C]");
			object obj7 = (nint)0 >> 4;
			object obj8 = obj7 & 1;
			nint num7;
			if (obj8 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r10_v6 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num7 = unchecked((nint)6447293664L);
					goto IL_0630;
				}
			}
			((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
			num7 = ((Delegate)tweenCallback3).method_ptr;
			goto IL_0630;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void PlayCritSfx(float detune = 0f)
	{
		//IL_0042: Expected F4, but got I4
		Debug.Log("PlayCritSfx");
		float? volume = default(float?);
		float rate = default(float);
		float detune2 = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_MagicCharge, 200f, 4, 0f, volume, rate, detune2, loop, 1f);
	}

	private void DoSniperTweens()
	{
		//IL_0076: Expected I, but got O
		//IL_035b: Expected I4, but got I8
		//IL_0369: Expected O, but got I4
		//IL_01d7: Expected I, but got O
		//IL_03e8: Expected I4, but got I8
		//IL_03f6: Expected O, but got I4
		//IL_01ab->IL02a5: Incompatible stack heights: 1 vs 0
		//IL_021c->IL02a5: Incompatible stack heights: 1 vs 0
		//IL_01fa->IL01fa: Incompatible stack heights: 2 vs 1
		//IL_024d->IL02a5: Incompatible stack heights: 1 vs 0
		//IL_0279->IL02a5: Incompatible stack heights: 1 vs 0
		if (_sniperTween1 != null)
		{
			_sniperTween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if (array != null)
		{
			if ((object)_sniperSprite1 != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if (tweenConfig != null)
			{
				tweenConfig.targets = array;
				if ((object)_sniperSprite1 != null)
				{
					Transform transform = _sniperSprite1.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						object obj2 = default(object);
						float num2 = (float)obj2 + 0.1f;
						tweenConfig.duration = 1000f;
						tweenConfig.ease = Ease.InOutSine;
						tweenConfig.yoyo = true;
						tweenConfig.repeat = -1;
						tweenConfig.localY = (float?)(object)1;
						MultiTargetTween sniperTween = Tweens.Add(tweenConfig);
						_sniperTween1 = sniperTween;
						if (_sniperTween2 != null)
						{
							_sniperTween2.Kill();
						}
						TweenConfig tweenConfig2 = new TweenConfig();
						object[] array2 = new object[1];
						if (array2 != null)
						{
							if ((object)_sniperSprite2 != null)
							{
								nint num3 = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj3 = default(object);
								bool flag2 = obj3 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig2 != null)
							{
								tweenConfig2.targets = array2;
								if ((object)_sniperSprite2 != null)
								{
									Transform transform2 = _sniperSprite2.transform;
									if ((object)transform2 != null)
									{
										bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
										Transform.get_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
										tweenConfig2.delay = 500f;
										tweenConfig2.duration = 1000f;
										tweenConfig2.ease = Ease.InOutSine;
										tweenConfig2.yoyo = true;
										tweenConfig2.repeat = -1;
										tweenConfig2.localY = (float?)(object)1;
										MultiTargetTween sniperTween2 = Tweens.Add(tweenConfig2);
										_sniperTween2 = sniperTween2;
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		PhaserSprite phaserSprite = _sniperSprite1.setVisible(visible);
		PhaserSprite phaserSprite2 = _sniperSprite2.setVisible(visible);
		PhaserSprite phaserSprite3 = _sniperSprite1A.setVisible(visible);
		PhaserSprite phaserSprite4 = _sniperSprite1B.setVisible(visible);
		PhaserSprite phaserSprite5 = _sniperSprite2A.setVisible(visible);
		PhaserSprite phaserSprite6 = _sniperSprite2B.setVisible(visible);
		PhaserSprite phaserSprite7 = _sniperSprite1_BG.setVisible(visible);
		PhaserSprite phaserSprite8 = _sniperSprite2_BG.setVisible(visible);
		PhaserSprite phaserSprite9 = _sniperSprite1A_BG.setVisible(visible);
		PhaserSprite phaserSprite10 = _sniperSprite1B_BG.setVisible(visible);
		PhaserSprite phaserSprite11 = _sniperSprite2A_BG.setVisible(visible);
		PhaserSprite phaserSprite12 = _sniperSprite2B_BG.setVisible(visible);
	}

	public override void Cleanup()
	{
		base.Cleanup();
		PhaserSprite sniperSprite1_BG = _sniperSprite1_BG;
		if ((object)_sniperSprite1_BG != null && ((UnityEngine.Object)sniperSprite1_BG).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _sniperSprite1_BG.gameObject;
			gameObject.SetActive(value: false);
		}
		PhaserSprite sniperSprite2_BG = _sniperSprite2_BG;
		if ((object)_sniperSprite2_BG != null && ((UnityEngine.Object)sniperSprite2_BG).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject2 = _sniperSprite2_BG.gameObject;
			gameObject2.SetActive(value: false);
		}
		PhaserSprite sniperSprite1A_BG = _sniperSprite1A_BG;
		if ((object)_sniperSprite1A_BG != null && ((UnityEngine.Object)sniperSprite1A_BG).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject3 = _sniperSprite1A_BG.gameObject;
			gameObject3.SetActive(value: false);
		}
		PhaserSprite sniperSprite1B_BG = _sniperSprite1B_BG;
		if ((object)_sniperSprite1B_BG != null && ((UnityEngine.Object)sniperSprite1B_BG).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject4 = _sniperSprite1B_BG.gameObject;
			gameObject4.SetActive(value: false);
		}
		PhaserSprite sniperSprite2A_BG = _sniperSprite2A_BG;
		if ((object)_sniperSprite2A_BG != null && ((UnityEngine.Object)sniperSprite2A_BG).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject5 = _sniperSprite2A_BG.gameObject;
			gameObject5.SetActive(value: false);
		}
		PhaserSprite sniperSprite2B_BG = _sniperSprite2B_BG;
		if ((object)_sniperSprite2B_BG != null && ((UnityEngine.Object)sniperSprite2B_BG).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject6 = _sniperSprite2B_BG.gameObject;
			gameObject6.SetActive(value: false);
		}
		if (_sniperTween1 != null)
		{
			_sniperTween1.Kill();
		}
		if (_sniperTween2 != null)
		{
			_sniperTween2.Kill();
		}
		if (_critSniperTween != null)
		{
			_critSniperTween.Kill();
		}
		if (_critSniperTimer != null)
		{
			_critSniperTimer.Cancel();
		}
		if (_songFiringTimer != null)
		{
			_songFiringTimer.Cancel();
		}
	}

	private bool OnBulletOverlapsEnemy_Song(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_015a: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0177;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = base.PPower();
									float num2 = base.CalcCritMul();
									object obj2 = default(object);
									object obj = obj2 * obj2;
									float damage = (float)obj * 2.5f;
									base.DealDamage(component, damage);
								}
								goto IL_0177;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0177:
		return false;
	}

	private void _003CShowCritSnipers_003Eb__30_0()
	{
		PlayCritSfx(100f);
	}

	private void _003CShowCritSnipers_003Eb__30_1()
	{
		PlayCritSfx(100f);
	}

	private void _003CShowCritSnipers_003Eb__30_2()
	{
		PlayCritSfx(100f);
	}
}
