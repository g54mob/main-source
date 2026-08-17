using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_DragonWater1Head_Projectile : Projectile
{
	private const float Radius = 24f;

	private TP_DragonWater1_Weapon _parentWeapon;

	private bool _isDespawning;

	private PhaserSprite _headSprite;

	private float _scaledAlpha;

	private float _cachedProjSpeed;

	private float _cachedWeaponArea;

	private float _cachedWeaponHitBoxDelayOverSpeed;

	private float _cachedWeaponSpeed;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private bool _cachedFlipX;

	private float _turnAngle;

	private float _turnSpeed;

	private bool _isRotating;

	private List<Vector3> _positions;

	private List<Quaternion> _rotations;

	private List<float> _rotationPath;

	private List<float> _forwardPath;

	private int _rotationCounter;

	private int _forwardCounter;

	private bool _movementTimerStarted;

	private float2 _rotationDurationRange;

	private float2 _forwardDurationRange;

	private int _repeatInterval;

	private float _cachedWeaponSpeedRepeatInterval;

	private int _rotationDirection;

	private float _scale;

	private Timer _expireTimer;

	private Timer _moveTimer;

	private List<TP_DragonWater1Tail_Projectile> _tails;

	private int _tailAmount;

	private float2 _tailSpawnPos;

	private float _tailSpawnTimer;

	public List<Vector3> Positions => _positions;

	public List<Quaternion> Rotations => _rotations;

	public float Scale => _scale;

	public float CachedWeaponHitBoxDelayOverSpeed => _cachedWeaponHitBoxDelayOverSpeed;

	public float ScaledAlpha => _scaledAlpha;

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite = setFrame(sprite);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_WaterDragon07");
		GameObject gameObject2 = phaserSprite.gameObject;
		((UnityEngine.Object)gameObject2).SetName("TP_DragonWater1Head_Sprite");
		_headSprite = phaserSprite;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_08d2: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected I4, but got Unknown
		//IL_0169: Expected F4, but got O
		//IL_0187: Expected F4, but got O
		//IL_01a5: Expected F4, but got O
		//IL_01cd: Expected F4, but got O
		//IL_01da: Expected I, but got O
		//IL_01f0: Invalid comparison between F4 and O
		//IL_0201: Expected F4, but got O
		//IL_091b: Expected O, but got I4
		//IL_092a: Invalid comparison between I4 and F4
		//IL_0230: Expected F4, but got I4
		//IL_034f: Expected O, but got I4
		//IL_034f: Expected O, but got I4
		//IL_03b6: Expected F4, but got I4
		//IL_03e5: Expected O, but got I4
		//IL_03ee: Expected O, but got I4
		//IL_03f7: Expected O, but got I4
		//IL_04b1: Expected O, but got I4
		//IL_04ba: Expected O, but got I4
		//IL_09c4: Expected O, but got F4
		//IL_0433: Expected O, but got I
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Expected O, but got Unknown
		//IL_045f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Expected O, but got Unknown
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Expected O, but got Unknown
		//IL_05a4: Expected I4, but got I8
		//IL_051d: Expected O, but got I
		//IL_0534: Unknown result type (might be due to invalid IL or missing references)
		//IL_0539: Expected O, but got Unknown
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Expected O, but got Unknown
		//IL_0580: Unknown result type (might be due to invalid IL or missing references)
		//IL_0585: Expected O, but got Unknown
		//IL_0602: Expected I, but got O
		//IL_0662: Expected O, but got I4
		//IL_06fd: Expected I, but got O
		//IL_0713: Expected O, but got I
		//IL_071c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0721: Expected O, but got Unknown
		//IL_0797: Expected I, but got O
		//IL_0a5d: Expected O, but got I4
		//IL_0a86: Expected I, but got I8
		//IL_06dd: Expected O, but got I4
		//IL_06eb: Expected O, but got I4
		//IL_0773: Expected I, but got I8
		//IL_0818: Expected O, but got I4
		//IL_0866: Expected F4, but got I4
		BulletPool pool2 = default(BulletPool);
		base.InitProjectile(pool2, weapon, index);
		float? parentWeapon;
		if ((object)weapon == null)
		{
			parentWeapon = (float?)(object)0;
			goto IL_089d;
		}
		nint num = (nint)typeof(TP_DragonWater1_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v78 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_DragonWater1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v68 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v78 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_DragonWater1_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v68 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v158+FFFFFFF8+v71 @ rax_v153*8]");
			if (0 == (nint)typeof(TP_DragonWater1_Weapon))
			{
				obj3 = 1;
				goto IL_08ac;
			}
		}
		obj3 = 0;
		goto IL_08ac;
		IL_08ac:
		bool flag = obj3 == null;
		pool2 = (BulletPool)(object)typeof(TP_DragonWater1_Weapon);
		parentWeapon = (float?)(object)0;
		if (!flag)
		{
			pool2 = (BulletPool)(object)typeof(TP_DragonWater1_Weapon);
			parentWeapon = (float?)weapon;
		}
		goto IL_089d;
		IL_089d:
		_parentWeapon = (TP_DragonWater1_Weapon)parentWeapon;
		Weapon weapon2 = _weapon;
		float2 float5 = (_tailSpawnPos = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position);
		float num4 = _weapon.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		_isCullable = false;
		_isDespawning = false;
		int tailAmount = (int)(num4 + 6);
		_tailAmount = tailAmount;
		float projectileSpeed = base.ProjectileSpeed;
		_cachedProjSpeed = (float)float5;
		float num5 = _weapon.PArea();
		_cachedWeaponArea = (float)float5;
		float num6 = _weapon.PHitBoxDelayOverSpeed();
		_cachedWeaponHitBoxDelayOverSpeed = (float)float5;
		float num7 = _weapon.PSpeed();
		Weapon weapon3 = _weapon;
		_cachedWeaponSpeed = (float)float5;
		nint num8 = (nint)weapon3;
		float num9 = weapon3.PSpeed();
		bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5);
		float num10 = (float)float5;
		if (!flag2)
		{
			num10 = 0.001f;
		}
		float num11 = 1f / num10;
		float cachedWeaponSpeedRepeatInterval = num11 * (float)_repeatInterval;
		_cachedWeaponSpeedRepeatInterval = cachedWeaponSpeedRepeatInterval;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		float num12;
		if (!(0f > _cachedWeaponArea))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm1\"");
			num12 = 0f;
		}
		else
		{
			num12 = _cachedWeaponArea;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		float num13 = (_scale = num12 * 0.8f);
		bool flag3 = !(1f < num13);
		float num14 = 1f;
		if (!flag3)
		{
			if (num13 < 2f)
			{
				float num15 = num13 - 1f;
				float num16 = num15 * 0.3f;
				num14 = 1f - num16;
			}
			else
			{
				num14 = 0.7f;
			}
		}
		_scaledAlpha = num14;
		PhaserSprite phaserSprite = _headSprite.setAlpha(num14);
		int num17 = _tailAmount + 1;
		PhaserSprite phaserSprite2 = _headSprite.setDepth(num17);
		BaseBody baseBody = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
		Weapon weapon4 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon4)._003COwner_003Ek__BackingField;
		_cachedFlipX = characterController._isFlipped;
		float turnAngle = ((~(characterController._isFlipped ? 1u : 0u) != 0) ? 0f : 180f);
		_turnAngle = turnAngle;
		float num18 = _cachedWeaponSpeed * 360f;
		_rotationCounter = 0;
		_movementTimerStarted = false;
		_turnSpeed = num18;
		List<float> rotationPath = Weapon.MakeChanceArray();
		List<float> forwardPath = Weapon.MakeChanceArray();
		float? num19 = (float?)(object)1;
		float? num20 = (float?)(object)0;
		float? num21 = (float?)(object)0;
		object obj9 = default(object);
		bool flag6 = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (true)
		{
			float? num22 = num21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ rax_v42 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)num22 < 0)
			{
				float? num23 = num20;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ rax_v42 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)num23 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ rax_v42 (System.Collections.Generic.List`1<System.Single>)+10]");
					num19 = (float?)(object)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_DragonWater1Head_Projectile)+150]");
					object obj4 = 0 - _rotationDurationRange;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ r8_v16 (System.Nullable`1<System.Single>)+20+v314 @ rdx_v29 (System.Nullable`1<System.Single>)*4]");
					object obj5 = obj4 * 0;
					num18 = (float)obj5 + (float)_rotationDurationRange;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ rax_v42 (System.Collections.Generic.List`1<System.Single>)+1C]");
					_ = (nint)0 + (nint)1;
					num20 = (float?)(object)((_003F?)num20 + 1);
					num21 = num20;
					continue;
				}
			}
			else
			{
				float? num24 = (float?)(object)0;
				float? num25 = (float?)(object)0;
				while (true)
				{
					float? num26 = num25;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1005 @ rax_v43 (System.Collections.Generic.List`1<System.Single>)+18]");
					if ((nint)num26 < 0)
					{
						float? num27 = num24;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1005 @ rax_v43 (System.Collections.Generic.List`1<System.Single>)+18]");
						if ((nint)num27 >= 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1005 @ rax_v43 (System.Collections.Generic.List`1<System.Single>)+10]");
						num19 = (float?)(object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_DragonWater1Head_Projectile)+158]");
						object obj6 = 0 - _forwardDurationRange;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ r8_v16 (System.Nullable`1<System.Single>)+20+v316 @ rdx_v31 (System.Nullable`1<System.Single>)*4]");
						object obj7 = obj6 * 0;
						num18 = (float)obj7 + (float)_forwardDurationRange;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1005 @ rax_v43 (System.Collections.Generic.List`1<System.Single>)+1C]");
						_ = (nint)0 + (nint)1;
						num24 = (float?)(object)((_003F?)num24 + 1);
						num25 = num24;
						continue;
					}
					object obj8 = UnityEngine.Random.value;
					bool flag4 = num18 > 0.5f;
					int rotationDirection = 1;
					if (!flag4)
					{
						rotationDirection = -1;
					}
					_rotationDirection = rotationDirection;
					_rotationPath = rotationPath;
					_forwardPath = forwardPath;
					if (_scaleTween != null)
					{
						_scaleTween.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					nint num28 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag5 = obj9 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig.targets = array;
					tweenConfig.duration = 250f;
					tweenConfig.scale = (float?)(object)1;
					MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
					_scaleTween = scaleTween;
					float num29 = _weapon.PDuration();
					Timer expireTimer = _expireTimer;
					if (_expireTimer != null && !_expireTimer.IsDone)
					{
						float timeElapsed = _expireTimer.GetTimeElapsed();
						expireTimer._timeElapsedBeforeCancel = (float?)(object)1;
						expireTimer._timeElapsedBeforePause = (float?)(object)0;
					}
					Action action = null;
					nint num30 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v905 @ r10_v1 (Il2CppMethodInfo)+8]");
					((Delegate)action).method_ptr = (IntPtr)0;
					((Delegate)action).method = (nint)__ldftn(TP_DragonWater1Head_Projectile.StartDespawn);
					((Delegate)action).m_target = this;
					((Delegate)action).method_code = (IntPtr)action;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v905 @ r10_v1 (Il2CppMethodInfo)+4C]");
					object obj10 = (nint)0 >> 4;
					object obj11 = obj10 & 1;
					nint num31;
					if (obj11 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v905 @ r10_v1 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num31 = unchecked((nint)6447293664L);
							goto IL_0a54;
						}
					}
					num31 = ((Delegate)action).method_ptr;
					((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
					goto IL_0a54;
					IL_0a54:
					object obj12 = 24;
					float duration = _scale * 0.001f;
					((Delegate)action).extra_arg = unchecked((nint)6447293568L);
					Timer expireTimer2 = Timers.Register(duration, action, null, isLooped: false, flag6, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_expireTimer = expireTimer2;
					_tailSpawnTimer = 0f;
					List<TP_DragonWater1Tail_Projectile> tails = new List<TP_DragonWater1Tail_Projectile>();
					_tails = tails;
					List<Vector3> positions = new List<Vector3>();
					_positions = positions;
					List<Quaternion> rotations = new List<Quaternion>();
					_rotations = rotations;
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
					{
						Volume = (float?)(object)1,
						Rate = 1f
					};
					float detune = (float)_indexInWeapon * 100f;
					soundConfig.Detune = detune;
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.FireExplosion, soundConfig, 200f, 5, flag6 ? 1 : 0);
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0743: Expected I, but got O
		//IL_0950: Expected O, but got Ref
		//IL_095e: Expected O, but got Ref
		//IL_096c: Expected F4, but got O
		//IL_079d: Expected O, but got Ref
		//IL_0818: Expected O, but got Ref
		//IL_0193: Expected O, but got I
		//IL_01d9: Expected O, but got I
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		//IL_014e: Expected O, but got Ref
		//IL_08a7: Expected O, but got Ref
		//IL_02c7: Expected O, but got I
		//IL_030d: Expected O, but got I
		//IL_0290: Expected O, but got Ref
		//IL_0427: Expected O, but got I4
		//IL_0482: Expected I4, but got O
		//IL_0482: Expected O, but got I
		//IL_04b0: Expected I, but got O
		//IL_04be: Expected I, but got O
		//IL_04ce: Expected O, but got I
		//IL_054e: Expected O, but got I4
		//IL_050a: Expected O, but got I
		//IL_0540: Expected O, but got I4
		//IL_0699: Unknown result type (might be due to invalid IL or missing references)
		//IL_069e: Expected O, but got Unknown
		//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ac: Expected I4, but got Unknown
		//IL_06c1: Expected O, but got I
		//IL_07db->IL06cb: Incompatible stack heights: 1 vs 0
		//IL_017d->IL0845: Incompatible stack heights: 4 vs 5
		//IL_02b1->IL08d7: Incompatible stack heights: 9 vs 10
		//IL_0372->IL06ca: Incompatible stack heights: 11 vs 10
		//IL_03d5->IL06ca: Incompatible stack heights: 11 vs 10
		//IL_093d->IL06ca: Incompatible stack heights: 14 vs 10
		//IL_058c->IL06ca: Incompatible stack heights: 14 vs 10
		//IL_06ca->IL06ca: Incompatible stack heights: 17 vs 10
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (_forwardPath != null && !_movementTimerStarted)
		{
			_movementTimerStarted = true;
			StartForwardTimer();
		}
		if (_isRotating)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = (float)_rotationDirection * _turnSpeed;
			float num2 = deltaTime * num;
			float turnAngle = _turnAngle - num2;
			_turnAngle = turnAngle;
		}
		float rotation = _turnAngle * ((float)Math.PI / 180f);
		Vector2 vector = SetVelocityFromRotation(rotation, _cachedProjSpeed);
		Transform transform = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
		_ = 0;
		_ = Vector3.forwardVector;
		_ = 0;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		Quaternion.AngleAxis_Injected((float)this, ref *(Vector3*)obj4, out *(Quaternion*)obj3);
		object obj14;
		Projectile projectile;
		Transform transform4;
		object obj17;
		if ((object)transform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
			_ = 0;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
			Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Quaternion*)obj5);
			Transform positions = (Transform)(object)_positions;
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				_ = 0;
				_ = 0;
				bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj6);
				bool flag3 = _positions == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rbx_v7 (UnityEngine.Transform)+1C]");
				_ = (nint)0 + (nint)1;
				IntPtr cachedPtr = ((UnityEngine.Object)positions).m_CachedPtr;
				bool flag4 = ((UnityEngine.Object)positions).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rbx_v7 (UnityEngine.Transform)+18]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ rcx_v22 (System.IntPtr)+18]");
				if (num5 >= 0)
				{
					Vector3 item = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-11]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
					_ = 0;
					_positions.AddWithResize(item);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rbx_v7 (UnityEngine.Transform)+18]");
					object obj7 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rbx_v7 (UnityEngine.Transform)+18]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ rcx_v22 (System.IntPtr)+18]");
					bool flag5 = num6 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rbx_v7 (UnityEngine.Transform)+18]");
					object obj8 = (nint)0 * (nint)2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rbx_v7 (UnityEngine.Transform)+18]");
					object obj9 = 0 + obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-11]");
					_ = 0;
				}
				Transform rotations = (Transform)(object)_rotations;
				Transform transform3 = base.transform;
				bool flag6 = (object)transform3 == null;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v712 @ rax_v32 (UnityEngine.Transform)+10]");
				bool flag7 = (nint)0 == 0;
				object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v712 @ rax_v32 (UnityEngine.Transform)+10]");
				Transform.get_rotation_Injected((IntPtr)0, out *(Quaternion*)obj10);
				bool flag8 = _rotations == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ rbx_v8 (UnityEngine.Transform)+1C]");
				_ = (nint)0 + (nint)1;
				IntPtr cachedPtr2 = ((UnityEngine.Object)rotations).m_CachedPtr;
				bool flag9 = ((UnityEngine.Object)rotations).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ rbx_v8 (UnityEngine.Transform)+18]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rdx_v18 (System.IntPtr)+18]");
				if (num7 >= 0)
				{
					Quaternion item2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
					_ = 0;
					_rotations.AddWithResize(item2);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ rbx_v8 (UnityEngine.Transform)+18]");
					object obj11 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ rbx_v8 (UnityEngine.Transform)+18]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rdx_v18 (System.IntPtr)+18]");
					bool flag10 = num8 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ rbx_v8 (UnityEngine.Transform)+18]");
					object obj12 = (nint)0 + (nint)2;
					object obj13 = obj12 + obj12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
					_ = 0;
				}
				if (_isDespawning)
				{
					return;
				}
				List<TP_DragonWater1Tail_Projectile> tails = _tails;
				bool flag11 = _tails == null;
				if (tails._size >= _tailAmount)
				{
					return;
				}
				float deltaTime2 = PauseSystem.DeltaTime;
				float num9 = deltaTime2 * 1000f;
				float num10 = _scale * _cachedWeaponSpeedRepeatInterval;
				if ((_tailSpawnTimer = num9 + _tailSpawnTimer) < num10)
				{
					return;
				}
				List<TP_DragonWater1Tail_Projectile> tails2 = _tails;
				_tailSpawnTimer = 0f;
				bool flag12 = _tails == null;
				Weapon parentWeapon = _parentWeapon;
				obj14 = tails2._size + 1;
				bool flag13 = (object)_parentWeapon == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ r8_v10 (VampireSurvivors.Objects.Weapons.Weapon)+180]");
				bool flag14 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ r8_v10 (VampireSurvivors.Objects.Weapons.Weapon)+180]");
				float2 pos = default(float2);
				projectile = ((BulletPool)0).SpawnAt(pos, _parentWeapon, (int)obj14);
				bool flag15 = (object)projectile == null;
				transform4 = null;
				if (!flag15)
				{
					nint num11 = (nint)projectile;
					nint num12 = (nint)typeof(TP_DragonWater1Tail_Projectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1147 @ rdx_v32 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_DragonWater1Tail_Projectile>)+130]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1146 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					nint num13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1147 @ rdx_v32 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_DragonWater1Tail_Projectile>)+130]");
					if (num13 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1146 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
						object obj16 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1201 @ rax_v68+FFFFFFF8+v1148 @ rax_v64*8]");
						if (0 == (nint)typeof(TP_DragonWater1Tail_Projectile))
						{
							obj17 = 1;
							goto IL_08fe;
						}
					}
					obj17 = 0;
					goto IL_08fe;
				}
				goto IL_0925;
			}
		}
		throw new NullReferenceException();
		IL_0925:
		if ((object)transform4 != null && ((UnityEngine.Object)transform4).m_CachedPtr != (IntPtr)0)
		{
			List<object> tails3 = (List<object>)(object)_tails;
			bool flag16 = _tails == null;
			int version = tails3._version + 1;
			tails3._version = version;
			object[] items = tails3._items;
			bool flag17 = tails3._items == null;
			if (tails3._size >= items.Length)
			{
				((List<object>)(object)_tails).AddWithResize((object)transform4);
			}
			else
			{
				int num14 = tails3._size + 1;
				tails3._size = num14;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rbx_v12 (UnityEngine.Transform)+E8]");
			bool flag18 = (nint)0 == 0;
			object obj18 = _tailAmount - obj14;
			int num15 = obj18 + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rbx_v12 (UnityEngine.Transform)+E8]");
			PhaserSprite phaserSprite = ((PhaserSprite)0).setDepth(num15);
		}
		return;
		IL_08fe:
		bool flag19 = obj17 == null;
		transform4 = null;
		if (!flag19)
		{
			transform4 = (Transform)(object)projectile;
		}
		goto IL_0925;
	}

	public void SetMovementPath(List<float> rotations, List<float> forwards, bool isMirrored = false)
	{
		_rotationPath = rotations;
		_forwardPath = forwards;
		if (isMirrored)
		{
			int rotationDirection = -_rotationDirection;
			_rotationDirection = rotationDirection;
		}
	}

	private void StartRotationTimer()
	{
		//IL_003e: Expected O, but got I
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		List<float> rotationPath = _rotationPath;
		int rotationCounter = _rotationCounter;
		_isRotating = true;
		int rotationCounter2 = _rotationCounter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)rotationCounter2 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			int rotationCounter3 = _rotationCounter + 1;
			_rotationCounter = rotationCounter3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4+20+v33 @ rcx_v2 (System.Int32)*4]");
			object obj2 = 0 / _cachedWeaponSpeed;
			if (_moveTimer != null)
			{
				_moveTimer.Cancel();
			}
			Action onComplete = delegate
			{
				int rotationDirection = -_rotationDirection;
				_rotationDirection = rotationDirection;
				StartForwardTimer();
			};
			float duration = (float)obj2 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer moveTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_moveTimer = moveTimer;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void StartForwardTimer()
	{
		//IL_008b: Expected O, but got I
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		List<float> forwardPath = _forwardPath;
		int forwardCounter = _forwardCounter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)forwardCounter >= (nint)0)
		{
			return;
		}
		List<float> forwardPath2 = _forwardPath;
		int forwardCounter2 = _forwardCounter;
		_isRotating = false;
		int forwardCounter3 = _forwardCounter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v11 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)forwardCounter3 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v11 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			int forwardCounter4 = _forwardCounter + 1;
			_forwardCounter = forwardCounter4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v5+20+v63 @ rcx_v7 (System.Int32)*4]");
			object obj2 = 0 / _cachedWeaponSpeed;
			if (_moveTimer != null)
			{
				_moveTimer.Cancel();
			}
			Action onComplete = delegate
			{
				//IL_003e: Expected O, but got I
				//IL_006f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0074: Expected O, but got Unknown
				List<float> rotationPath = _rotationPath;
				int rotationCounter = _rotationCounter;
				_isRotating = true;
				int rotationCounter2 = _rotationCounter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)rotationCounter2 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj3 = 0;
					int rotationCounter3 = _rotationCounter + 1;
					_rotationCounter = rotationCounter3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4+20+v33 @ rcx_v2 (System.Int32)*4]");
					object obj4 = 0 / _cachedWeaponSpeed;
					if (_moveTimer != null)
					{
						_moveTimer.Cancel();
					}
					Action onComplete2 = delegate
					{
						int rotationDirection = -_rotationDirection;
						_rotationDirection = rotationDirection;
						StartForwardTimer();
					};
					float duration2 = (float)obj4 * 0.001f;
					bool useRealTime2 = default(bool);
					MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
					int repeat2 = default(int);
					TimerType type2 = default(TimerType);
					Timer moveTimer2 = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
					_moveTimer = moveTimer2;
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
			};
			float duration = (float)obj2 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer moveTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_moveTimer = moveTimer;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void StartDespawn()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		//IL_00dd: Expected I, but got O
		//IL_0148: Expected O, but got I4
		//IL_0151: Expected O, but got I4
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		_isDespawning = true;
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_headSprite != null)
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
		tweenConfig.targets = array;
		tweenConfig.duration = 250f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_DragonWater1Head_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		if (_tails == null)
		{
			return;
		}
		List<TP_DragonWater1Tail_Projectile> tails = _tails;
		object obj2 = 0;
		object obj3 = 0;
		while (true)
		{
			if ((nint)obj3 < tails._size)
			{
				List<TP_DragonWater1Tail_Projectile> tails2 = _tails;
				if ((nint)obj2 >= tails2._size)
				{
					break;
				}
				TP_DragonWater1Tail_Projectile[] items = tails2._items;
				items[obj2].StartDespawn();
				tails = _tails;
				obj2++;
				obj3 = obj2;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void Despawn()
	{
		_isCullable = true;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_moveTimer != null)
		{
			_moveTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		List<TP_DragonWater1Tail_Projectile> tails = _tails;
		if (_tails != null)
		{
			int version = tails._version + 1;
			tails._version = version;
			tails._size = 0;
			if (tails._size > 0)
			{
				Array.Clear(tails._items, 0, tails._size);
			}
		}
		_tails = null;
		List<Vector3> positions = _positions;
		if (_positions != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdx_v7 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
		}
		_positions = null;
		List<Quaternion> rotations = _rotations;
		if (_rotations != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rdx_v9 (System.Collections.Generic.List`1<UnityEngine.Quaternion>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
		}
		_rotations = null;
		List<float> rotationPath = _rotationPath;
		if (_rotationPath != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rdx_v11 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
		}
		_rotationPath = null;
		List<float> forwardPath = _forwardPath;
		if (_forwardPath != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rdx_v13 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
		}
		_forwardPath = null;
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
		{
			bool flag = TryFreeze(other);
		}
	}

	public TP_DragonWater1Head_Projectile()
	{
		//IL_0017: Expected O, but got I4
		//IL_0028: Expected O, but got I4
		_rotationDurationRange = (float2)1112014848;
		_ = 1120403456;
		_forwardDurationRange = (float2)1133084672;
		_ = 1134723072;
		_repeatInterval = 100;
		base._002Ector();
	}

	private void _003CStartRotationTimer_003Eb__48_0()
	{
		int rotationDirection = -_rotationDirection;
		_rotationDirection = rotationDirection;
		StartForwardTimer();
	}

	private void _003CStartForwardTimer_003Eb__49_0()
	{
		//IL_003e: Expected O, but got I
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		List<float> rotationPath = _rotationPath;
		int rotationCounter = _rotationCounter;
		_isRotating = true;
		int rotationCounter2 = _rotationCounter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)rotationCounter2 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			int rotationCounter3 = _rotationCounter + 1;
			_rotationCounter = rotationCounter3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4+20+v33 @ rcx_v2 (System.Int32)*4]");
			object obj2 = 0 / _cachedWeaponSpeed;
			if (_moveTimer != null)
			{
				_moveTimer.Cancel();
			}
			Action onComplete = delegate
			{
				int rotationDirection = -_rotationDirection;
				_rotationDirection = rotationDirection;
				StartForwardTimer();
			};
			float duration = (float)obj2 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer moveTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_moveTimer = moveTimer;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}
}
