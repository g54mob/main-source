using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class BattiliaWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public Circle circ;

		public BattiliaWeapon _003C_003E4__this;

		public BulletPool pool;
	}

	private sealed class _003C_003Ec__DisplayClass24_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireInternal_003Eb__0()
		{
			_003C_003Ec__DisplayClass24_0 obj = CS_0024_003C_003E8__locals1;
			Vector2 randomPoint = obj.circ.GetRandomPoint();
			_003C_003Ec__DisplayClass24_0 obj2 = CS_0024_003C_003E8__locals1;
			Vector2 pos = default(Vector2);
			Projectile projectile = obj2._003C_003E4__this.FireOneProjectile(pos, localIndex);
		}
	}

	private bool canRetaliate;

	private Timer _retaliationTimer;

	private float _retaliationDelay = 1500f;

	private bool soundToPlay;

	protected Circle _damageZone;

	protected List<float> firingAngles;

	public float batAlpha = 1f;

	public float shadowAlpha = 0.35f;

	public float physScale = 1f;

	public float maxPhysScale = 5f;

	private BulletPool _retaliationPool;

	protected virtual BulletPool GetBulletPool()
	{
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.BATTILIA);
			return new BulletPool(projectilePrefab);
		}
		return (BulletPool)(object)new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}

	protected override void OnStart()
	{
		//IL_0070: Expected I, but got O
		//IL_0101: Expected I, but got O
		base.OnStart();
		if (_retaliationPool == null)
		{
			BulletPool bulletPool = GetBulletPool();
			_retaliationPool = bulletPool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			PhysicsManager physicsManager = core._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.BattiliaWeapon>)+3A0]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_retaliationPool, physicsManager._destructiblesGroup, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.BattiliaWeapon>)+390]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_retaliationPool, core2.Enemies, collideCallback2, processCallback, callbackContext);
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_00ca: Expected O, but got I4
		//IL_00f2: Expected O, but got I
		//IL_0102: Expected O, but got I
		//IL_016b: Expected O, but got I
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		base.InitWeapon(characterController, weaponType);
		maxPhysScale = 5f;
		Action<GameplaySignals.CharacterReceivedDamageSignal> action = null;
		((BattiliaWeapon)(object)action).OnPlayerHit((GameplaySignals.CharacterReceivedDamageSignal)this);
		((BattiliaWeapon)(object)_signalBus).OnPlayerHit((GameplaySignals.CharacterReceivedDamageSignal)action);
		Action<GameplaySignals.CharacterLostShieldSignal> action2 = null;
		((BattiliaWeapon)(object)action2).OnPlayerShieldHit((GameplaySignals.CharacterLostShieldSignal)this);
		((BattiliaWeapon)(object)_signalBus).OnPlayerShieldHit((GameplaySignals.CharacterLostShieldSignal)action2);
		canRetaliate = true;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		ArcadePhysicsCallback collideCallback = OnBulletOverlapsBullet;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.collider(_projectilePool, _projectilePool, collideCallback, processCallback, callbackContext);
		List<float> list = new List<float>();
		firingAngles = list;
		object obj = 0;
		do
		{
			List<float> list2 = firingAngles;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v22 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v22 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v22 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj3 = 0;
			float item = (float)obj * ((float)Math.PI / 6f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v22 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ r8_v10+18]");
			if (num >= 0)
			{
				list2.AddWithResize(item);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v22 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj4 = (nint)0 + (nint)1;
			}
			obj++;
		}
		while ((nint)obj < 12);
		Extensions.Shuffle(firingAngles);
	}

	private bool OnBulletOverlapsBullet(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_030a: Expected I, but got O
		//IL_001c: Expected I, but got O
		//IL_002c: Expected O, but got I
		//IL_00ac: Expected O, but got I4
		//IL_0068: Expected O, but got I
		//IL_009e: Expected O, but got I4
		//IL_00cb: Expected I, but got O
		//IL_00db: Expected O, but got I
		//IL_015b: Expected O, but got I4
		//IL_0117: Expected O, but got I
		//IL_014d: Expected O, but got I4
		//IL_01ea: Expected O, but got I
		//IL_02fc: Expected I4, but got O
		//IL_021f: Expected O, but got I
		//IL_026e: Expected O, but got I
		//IL_02a3: Expected O, but got I
		nint num = (nint)typeof(BattiliaProjectile);
		ArcadeColliderType arcadeColliderType;
		ArcadeColliderType arcadeColliderType2;
		if (first == null)
		{
			arcadeColliderType = null;
			arcadeColliderType2 = null;
			goto IL_032a;
		}
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BattiliaProjectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BattiliaProjectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v44+FFFFFFF8+v55 @ rax_v40*8]");
			if (0 == (nint)typeof(BattiliaProjectile))
			{
				obj3 = 1;
				goto IL_0347;
			}
		}
		obj3 = 0;
		goto IL_0347;
		IL_036e:
		object obj4;
		if (obj4 != null)
		{
			arcadeColliderType2 = second;
		}
		goto IL_0390;
		IL_032a:
		if (second != null)
		{
			nint num4 = (nint)second;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BattiliaProjectile>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ r8_v3 (Il2CppClass<ArcadeColliderType>)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BattiliaProjectile>)+130]");
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ r8_v3 (Il2CppClass<ArcadeColliderType>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rax_v38+FFFFFFF8+v139 @ rax_v34*8]");
				if (0 == (nint)typeof(BattiliaProjectile))
				{
					obj4 = 1;
					goto IL_036e;
				}
			}
			obj4 = 0;
			goto IL_036e;
		}
		goto IL_0390;
		IL_0347:
		bool flag = obj3 == null;
		arcadeColliderType = null;
		arcadeColliderType2 = null;
		if (!flag)
		{
			arcadeColliderType = first;
			arcadeColliderType2 = null;
		}
		goto IL_032a;
		IL_0390:
		if (arcadeColliderType2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rbx_v2 (ArcadeColliderType)+10]");
			if ((nint)0 != 0 && arcadeColliderType != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v1 (ArcadeColliderType)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v1 (ArcadeColliderType)+B8]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v1 (ArcadeColliderType)+B8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rax_v16+28]");
						object obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rax_v16+28]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v1 (ArcadeColliderType)+D8]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v1 (ArcadeColliderType)+DC]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rbx_v2 (ArcadeColliderType)+B8]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rbx_v2 (ArcadeColliderType)+B8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ rax_v20+28]");
								object obj10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ rax_v20+28]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rbx_v2 (ArcadeColliderType)+D8]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rbx_v2 (ArcadeColliderType)+DC]");
									_ = 0;
									return true;
								}
							}
						}
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
			}
		}
		return false;
	}

	private void OnPlayerHit(GameplaySignals.CharacterReceivedDamageSignal signal)
	{
		//IL_00fa: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		bool flag2 = (object)signal == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				if ((object)signal != null)
				{
					object obj3 = (object)signal - (object)((Equipment)this)._003COwner_003Ek__BackingField;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [signal @ rdx (VampireSurvivors.Signals.GameplaySignals+CharacterReceivedDamageSignal)+10]");
				flag4 = (nint)0 == 0;
			}
			if (!flag4)
			{
				return;
			}
		}
		FireRetaliation();
	}

	private void OnPlayerShieldHit(GameplaySignals.CharacterLostShieldSignal signal)
	{
		//IL_0113: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController character = signal.Character;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		bool flag2 = (object)signal.Character == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				if ((object)signal.Character != null)
				{
					object obj3 = (object)signal.Character - (object)((Equipment)this)._003COwner_003Ek__BackingField;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)character).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		FireRetaliation();
	}

	public void FireRetaliation()
	{
		if (!canRetaliate)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (characterController._coherenceSync.HasStateAuthority)
		{
			canRetaliate = false;
			if (_retaliationTimer != null)
			{
				_retaliationTimer.Cancel();
			}
			Action onComplete = delegate
			{
				canRetaliate = true;
			};
			float duration = _retaliationDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer retaliationTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_retaliationTimer = retaliationTimer;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				FireInternal(isRetaliatory: true);
				return;
			}
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			Action action = ((Equipment)this)._003COwner_003Ek__BackingField.FireBattiliaWeapon;
			bool flag = characterController2._coherenceSync.SendCommand(action, MessageTarget.All);
		}
	}

	public void TriggerOnlineRetaliation()
	{
		FireInternal(isRetaliatory: true);
	}

	public override void Cleanup()
	{
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterReceivedDamageSignal> action = null;
			((BattiliaWeapon)(object)action).OnPlayerHit((GameplaySignals.CharacterReceivedDamageSignal)this);
			((BattiliaWeapon)(object)_signalBus).OnPlayerHit((GameplaySignals.CharacterReceivedDamageSignal)action);
		}
		if (_signalBus != null)
		{
			Action<GameplaySignals.CharacterLostShieldSignal> action2 = null;
			((BattiliaWeapon)(object)action2).OnPlayerShieldHit((GameplaySignals.CharacterLostShieldSignal)this);
			((BattiliaWeapon)(object)_signalBus).OnPlayerShieldHit((GameplaySignals.CharacterLostShieldSignal)action2);
		}
		base.Cleanup();
	}

	public float2 PickPosition()
	{
		//IL_007d: Expected O, but got F4
		//IL_0066: Expected O, but got F4
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 * ((float)Math.PI * 2f);
		object obj3 = UnityEngine.Random.value;
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 result = default(float2);
		return result;
	}

	private void CheckMaxScale()
	{
		//IL_010c: Expected F4, but got I4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		float num = base.PArea();
		float num2 = default(float);
		float num3;
		float num4;
		if (!(num2 > maxPhysScale))
		{
			num3 = 1f;
			num4 = 0.35f;
			goto IL_00e2;
		}
		float num5 = num2 / maxPhysScale;
		float num6 = num5 * 0.05f;
		num3 = (batAlpha = 1f - num6);
		if (!(0.35f > num3))
		{
			object obj = 0.35f & -2147483649L;
			if ((nint)obj <= 2139095040)
			{
				goto IL_0103;
			}
		}
		num3 = 0.35f;
		goto IL_0103;
		IL_0103:
		num4 = 0f;
		goto IL_00e2;
		IL_00e2:
		batAlpha = num3;
		shadowAlpha = num4;
		physScale = maxPhysScale;
	}

	public override void Fire(bool skipTriggers = false)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 3 Invalid \"Jump target not found in method: 0x187390010\"");
	}

	private void FireInternal(bool isRetaliatory = false, bool skipTriggers = false)
	{
		//IL_0451: Expected F4, but got I4
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_013a: Expected O, but got I4
		//IL_0471: Expected O, but got F4
		//IL_019f: Expected F4, but got O
		//IL_0207: Invalid comparison between O and F4
		//IL_038b: Invalid comparison between F4 and O
		//IL_03bd: Expected F4, but got O
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected O, but got Unknown
		//IL_032d: Expected I4, but got F4
		//IL_0369: Expected O, but got I4
		_003C_003Ec__DisplayClass24_0 obj = new _003C_003Ec__DisplayClass24_0();
		obj._003C_003E4__this = this;
		float num = base.PArea();
		float num2 = default(float);
		float num3;
		float num4;
		if (!(num2 > maxPhysScale))
		{
			num3 = 1f;
			num4 = 0.35f;
			goto IL_040f;
		}
		float num5 = num2 / maxPhysScale;
		float num6 = num5 * 0.05f;
		num3 = (batAlpha = 1f - num6);
		if (!(0.35f > num3))
		{
			object obj2 = 0.35f & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				goto IL_0448;
			}
		}
		num3 = 0.35f;
		goto IL_0448;
		IL_0448:
		num4 = 0f;
		goto IL_040f;
		IL_040f:
		batAlpha = num3;
		shadowAlpha = num4;
		physScale = maxPhysScale;
		BulletPool pool = ((!isRetaliatory) ? _projectilePool : _retaliationPool);
		obj.pool = pool;
		bool flag = !soundToPlay;
		soundToPlay = flag;
		bool flag2 = !soundToPlay;
		bool flag3 = !flag2;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj3 = UnityEngine.Random.value;
		float detune = maxPhysScale * -1000f;
		soundConfig.Detune = detune;
		SfxType sfxType = (SfxType)((flag3 ? 1 : 0) + 209);
		float num7 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 200f, 4, num7);
		float2 float5 = PickPosition();
		Circle circle = new Circle();
		circle._x = (float)float5;
		circle._y = 1f;
		circle._radius = 0.32f;
		obj.circ = circle;
		Vector2 randomPoint = obj.circ.GetRandomPoint();
		Vector2 vector = default(Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0);
		float num8 = base.PAmount();
		bool flag4 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
		Vector2 vector2 = vector;
		if (!flag4)
		{
			bool flag5 = true;
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			bool flag6;
			do
			{
				WeaponData currentWeaponData = _currentWeaponData;
				object obj4 = flag5 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				if ((nint)obj4 <= 0)
				{
					Vector2 randomPoint2 = obj.circ.GetRandomPoint();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				}
				else
				{
					_003C_003Ec__DisplayClass24_1 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass24_1();
					CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1 = obj;
					CS_0024_003C_003E8__locals5.localIndex = (flag5 ? 1 : 0);
					WeaponData currentWeaponData2 = _currentWeaponData;
					Action onComplete = delegate
					{
						_003C_003Ec__DisplayClass24_0 obj5 = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1;
						Vector2 randomPoint3 = obj5.circ.GetRandomPoint();
						_003C_003Ec__DisplayClass24_0 obj6 = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1;
						Vector2 pos = default(Vector2);
						Projectile projectile2 = obj6._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals5.localIndex);
					};
					float num9 = (float)(flag5 ? 1 : 0) * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					float duration = num9 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num7 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
				}
				flag5 = (byte)((flag5 ? 1u : 0u) + 1u) != 0;
				flag6 = (nint)vector > (flag5 ? 1 : 0);
				vector2 = (Vector2)flag5;
			}
			while (flag6);
		}
		float num10 = base.PInterval();
		bool flag7 = (object)_lastFiringInterval == (object)vector2;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873905E4h\"");
		if (!flag7)
		{
			float num11 = base.PInterval();
			_lastFiringInterval = (float)vector2;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	private void _003CFireRetaliation_003Eb__18_0()
	{
		canRetaliate = true;
	}
}
