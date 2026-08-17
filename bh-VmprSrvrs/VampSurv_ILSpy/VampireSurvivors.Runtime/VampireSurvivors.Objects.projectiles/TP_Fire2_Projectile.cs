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

public class TP_Fire2_Projectile : Projectile
{
	private const float Radius = 24f;

	private TP_Fire2_Weapon _parentWeapon;

	private bool _isDespawning;

	private PhaserSprite _headSprite;

	private float _scaledAlpha;

	private float _cachedProjSpeed;

	private float _cachedWeaponArea;

	private float _cachedWeaponHitBoxDelayOverSpeed;

	private float _cachedWeaponSpeed;

	private float _cachedWeaponSpeedRepeatInterval;

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

	private bool _rotationTimerStarted;

	private float _scale;

	private Timer _expireTimer;

	private Timer _hitboxTimer;

	private Timer _moveTimer;

	private List<TP_Fire2Tail_Projectile> _tails;

	private float2 _tailSpawnPos;

	private float _tailSpawnTimer;

	public List<Vector3> Positions => _positions;

	public List<Quaternion> Rotations => _rotations;

	public float Scale => _scale;

	public float CachedWeaponArea => _cachedWeaponArea;

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
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Salame07");
		GameObject gameObject2 = phaserSprite.gameObject;
		((UnityEngine.Object)gameObject2).SetName("TP_Fire2Head_Sprite");
		_headSprite = phaserSprite;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_06a9: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0133: Expected F4, but got O
		//IL_0151: Expected F4, but got O
		//IL_016f: Expected F4, but got O
		//IL_018d: Expected F4, but got O
		//IL_01ab: Expected F4, but got O
		//IL_01bb: Expected O, but got I4
		//IL_02d5: Expected O, but got I4
		//IL_02d5: Expected O, but got I4
		//IL_039f: Expected I, but got O
		//IL_0403: Expected O, but got I4
		//IL_05ef: Expected O, but got I4
		//IL_063d: Expected F4, but got I4
		BulletPool pool2 = default(BulletPool);
		base.InitProjectile(pool2, weapon, index);
		float? parentWeapon;
		if ((object)weapon == null)
		{
			parentWeapon = (float?)(object)0;
			goto IL_0674;
		}
		nint num = (nint)typeof(TP_Fire2_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v68 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Fire2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v55 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v68 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Fire2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v55 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v111+FFFFFFF8+v69 @ rax_v106*8]");
			if (0 == (nint)typeof(TP_Fire2_Weapon))
			{
				obj3 = 1;
				goto IL_0683;
			}
		}
		obj3 = 0;
		goto IL_0683;
		IL_0683:
		bool flag = obj3 == null;
		pool2 = (BulletPool)(object)typeof(TP_Fire2_Weapon);
		parentWeapon = (float?)(object)0;
		if (!flag)
		{
			pool2 = (BulletPool)(object)typeof(TP_Fire2_Weapon);
			parentWeapon = (float?)weapon;
		}
		goto IL_0674;
		IL_0674:
		_parentWeapon = (TP_Fire2_Weapon)parentWeapon;
		TP_Fire2_Weapon parentWeapon2 = _parentWeapon;
		float2 float5 = (_tailSpawnPos = parentWeapon2._cursor.position);
		_isCullable = false;
		_isDespawning = false;
		float projectileSpeed = base.ProjectileSpeed;
		_cachedProjSpeed = (float)float5;
		float num4 = _weapon.PArea();
		_cachedWeaponArea = (float)float5;
		float num5 = _weapon.PHitBoxDelayOverSpeed();
		_cachedWeaponHitBoxDelayOverSpeed = (float)float5;
		float num6 = _weapon.PSpeed();
		_cachedWeaponSpeed = (float)float5;
		float num7 = _weapon.PSpeedRepeatInterval();
		_cachedWeaponSpeedRepeatInterval = (float)float5;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		_scale = _cachedWeaponArea;
		bool flag2 = !(1f < _cachedWeaponArea);
		float num8 = 1f;
		if (!flag2)
		{
			if (_cachedWeaponArea < 2.5f)
			{
				float num9 = _cachedWeaponArea - 1f;
				float num10 = num9 * 0.3f;
				float num11 = num10 / 1.5f;
				num8 = 1f - num11;
			}
			else
			{
				num8 = 0.7f;
			}
		}
		_scaledAlpha = num8;
		PhaserSprite phaserSprite = _headSprite.setAlpha(num8);
		TP_Fire2_Weapon parentWeapon3 = _parentWeapon;
		int num12 = parentWeapon3._003CTailAmount_003Ek__BackingField + 1;
		PhaserSprite phaserSprite2 = _headSprite.setDepth(num12);
		BaseBody baseBody = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		float turnSpeed = _cachedWeaponSpeed * 180f;
		_cachedFlipX = characterController._isFlipped;
		_turnAngle = 90f;
		_turnSpeed = turnSpeed;
		_rotationCounter = 0;
		_rotationTimerStarted = false;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num13 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj4 = default(object);
		if (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 250f;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			float num14 = weapon.PDuration();
			float num15 = _weapon.PHitBoxDelayOverSpeed();
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			Action onComplete = StartDespawn;
			float duration = _scale * 0.001f;
			bool flag3 = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
			if (_hitboxTimer != null)
			{
				_hitboxTimer.Cancel();
			}
			Action onComplete2 = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			};
			float duration2 = _scale * 0.001f;
			Timer hitboxTimer = Timers.Register(duration2, onComplete2, null, isLooped: true, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_hitboxTimer = hitboxTimer;
			_tailSpawnTimer = 0f;
			List<TP_Fire2Tail_Projectile> tails = new List<TP_Fire2Tail_Projectile>();
			_tails = tails;
			List<Vector3> positions = new List<Vector3>();
			_positions = positions;
			List<Quaternion> rotations = new List<Quaternion>();
			_rotations = rotations;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float detune = (float)_indexInWeapon * 100f;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.FireExplosion, soundConfig, 200f, 5, flag3 ? 1 : 0);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0070: Expected O, but got I8
		//IL_0087: Expected O, but got I4
		//IL_00c8: Expected O, but got F4
		//IL_07ec: Expected I, but got O
		//IL_0a64: Expected O, but got Ref
		//IL_0a72: Expected O, but got Ref
		//IL_0a80: Expected F4, but got O
		//IL_0846: Expected O, but got Ref
		//IL_08ac: Expected O, but got Ref
		//IL_01ce: Expected O, but got I
		//IL_0214: Expected O, but got I
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		//IL_0189: Expected O, but got Ref
		//IL_0946: Expected O, but got Ref
		//IL_0306: Expected O, but got I
		//IL_034c: Expected O, but got I
		//IL_02cf: Expected O, but got Ref
		//IL_04f0: Expected I, but got O
		//IL_04fe: Expected I, but got O
		//IL_050e: Expected O, but got I
		//IL_058e: Expected O, but got I4
		//IL_054a: Expected O, but got I
		//IL_0580: Expected O, but got I4
		//IL_0719: Expected O, but got I4
		//IL_0722: Unknown result type (might be due to invalid IL or missing references)
		//IL_0727: Expected I4, but got Unknown
		//IL_073c: Expected O, but got I
		//IL_08db->IL0746: Incompatible stack heights: 2 vs 0
		//IL_014a->IL0746: Incompatible stack heights: 2 vs 0
		//IL_01b8->IL08e0: Incompatible stack heights: 2 vs 3
		//IL_090c->IL0746: Incompatible stack heights: 3 vs 0
		//IL_0975->IL0746: Incompatible stack heights: 4 vs 0
		//IL_0290->IL0746: Incompatible stack heights: 4 vs 0
		//IL_02f0->IL097a: Incompatible stack heights: 4 vs 5
		//IL_038f->IL0746: Incompatible stack heights: 5 vs 0
		//IL_03b8->IL0746: Incompatible stack heights: 5 vs 0
		//IL_0478->IL0746: Incompatible stack heights: 5 vs 0
		//IL_04aa->IL0746: Incompatible stack heights: 5 vs 0
		//IL_05ff->IL0746: Incompatible stack heights: 5 vs 0
		//IL_064e->IL0746: Incompatible stack heights: 5 vs 0
		//IL_06dd->IL0746: Incompatible stack heights: 5 vs 0
		//IL_0702->IL0746: Incompatible stack heights: 5 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		bool flag = _rotationPath == null;
		TP_Fire2_Projectile tP_Fire2_Projectile = this;
		if (!flag)
		{
			bool flag2 = _rotationTimerStarted;
			tP_Fire2_Projectile = this;
			if (!flag2)
			{
				StartRotationTimer();
				_rotationTimerStarted = true;
				tP_Fire2_Projectile = this;
			}
		}
		if (_isRotating)
		{
			bool flag3 = _cachedFlipX;
			Transform transform = (Transform)4294967295L;
			if (!flag3)
			{
				transform = (Transform)1;
			}
			float deltaTime = PauseSystem.DeltaTime;
			float num = (float)transform * _turnSpeed;
			float num2 = deltaTime * num;
			float turnAngle = _turnAngle - num2;
			_turnAngle = turnAngle;
			tP_Fire2_Projectile = null;
		}
		float num3 = _turnAngle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num4 = num3 * _cachedProjSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		ArcadeSprite sprite = _sprite;
		float num5 = num3 * _cachedProjSpeed;
		int num14;
		Projectile projectile;
		object obj14;
		object obj17;
		if ((object)_sprite != null)
		{
			BaseBody baseBody = sprite.body;
			if (sprite.body != null)
			{
				baseBody._velocity = (float2)num4;
				Transform transform2 = base.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				nint num6 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rax_v35 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rax_v36 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
				_ = 0;
				_ = Vector3.forwardVector;
				_ = 0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Quaternion.AngleAxis_Injected((float)this, ref *(Vector3*)obj4, out *(Quaternion*)obj3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
				_ = 0;
				bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
				Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Quaternion*)obj5);
				Transform positions = (Transform)(object)_positions;
				Transform transform3 = base.transform;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ rax_v45 (UnityEngine.Transform)+10]");
				bool flag5 = (nint)0 == 0;
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ rax_v45 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj6);
				if (_positions != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rbx_v13 (UnityEngine.Transform)+1C]");
					_ = (nint)0 + (nint)1;
					IntPtr cachedPtr = ((UnityEngine.Object)positions).m_CachedPtr;
					if (((UnityEngine.Object)positions).m_CachedPtr != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rbx_v13 (UnityEngine.Transform)+18]");
						nint num8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rcx_v35 (System.IntPtr)+18]");
						if (num8 >= 0)
						{
							Vector3 item = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-11]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
							_ = 0;
							_positions.AddWithResize(item);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rbx_v13 (UnityEngine.Transform)+18]");
							object obj7 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rbx_v13 (UnityEngine.Transform)+18]");
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rcx_v35 (System.IntPtr)+18]");
							bool flag6 = num9 >= 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rbx_v13 (UnityEngine.Transform)+18]");
							object obj8 = (nint)0 * (nint)2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rbx_v13 (UnityEngine.Transform)+18]");
							object obj9 = 0 + obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-11]");
							_ = 0;
						}
						Transform rotations = (Transform)(object)_rotations;
						Transform transform4 = base.transform;
						if ((object)transform4 != null)
						{
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v52 (UnityEngine.Transform)+10]");
							bool flag7 = (nint)0 == 0;
							object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v52 (UnityEngine.Transform)+10]");
							Transform.get_rotation_Injected((IntPtr)0, out *(Quaternion*)obj10);
							if (_rotations != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rbx_v14 (UnityEngine.Transform)+1C]");
								_ = (nint)0 + (nint)1;
								IntPtr cachedPtr2 = ((UnityEngine.Object)rotations).m_CachedPtr;
								if (((UnityEngine.Object)rotations).m_CachedPtr != (IntPtr)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rbx_v14 (UnityEngine.Transform)+18]");
									nint num10 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v28 (System.IntPtr)+18]");
									if (num10 >= 0)
									{
										Quaternion item2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
										_ = 0;
										_rotations.AddWithResize(item2);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rbx_v14 (UnityEngine.Transform)+18]");
										object obj11 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rbx_v14 (UnityEngine.Transform)+18]");
										nint num11 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v28 (System.IntPtr)+18]");
										bool flag8 = num11 >= 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rbx_v14 (UnityEngine.Transform)+18]");
										object obj12 = (nint)0 + (nint)2;
										object obj13 = obj12 + obj12;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
										_ = 0;
									}
									if (_isDespawning)
									{
										return;
									}
									List<TP_Fire2Tail_Projectile> tails = _tails;
									if (_tails != null)
									{
										TP_Fire2_Weapon parentWeapon = _parentWeapon;
										if ((object)_parentWeapon != null)
										{
											if (tails._size >= parentWeapon._003CTailAmount_003Ek__BackingField)
											{
												return;
											}
											float deltaTime2 = PauseSystem.DeltaTime;
											float num12 = deltaTime2 * 1000f;
											float num13 = _scale * _cachedWeaponSpeedRepeatInterval;
											if ((_tailSpawnTimer = num12 + _tailSpawnTimer) < num13)
											{
												return;
											}
											List<TP_Fire2Tail_Projectile> tails2 = _tails;
											_tailSpawnTimer = 0f;
											if (_tails != null)
											{
												num14 = tails2._size + 1;
												if ((object)_parentWeapon != null)
												{
													float2 pos = default(float2);
													projectile = _parentWeapon.SpawnTailProjectile(pos, num14);
													bool flag9 = (object)projectile == null;
													obj14 = null;
													if (!flag9)
													{
														nint num15 = (nint)projectile;
														nint num16 = (nint)typeof(TP_Fire2Tail_Projectile);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1246 @ rdx_v43 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Fire2Tail_Projectile>)+130]");
														object obj15 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1245 @ r8_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
														nint num17 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1246 @ rdx_v43 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Fire2Tail_Projectile>)+130]");
														if (num17 >= 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1245 @ r8_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
															object obj16 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1300 @ rax_v89+FFFFFFF8+v1247 @ rax_v85*8]");
															if (0 == (nint)typeof(TP_Fire2Tail_Projectile))
															{
																obj17 = 1;
																goto IL_09a1;
															}
														}
														obj17 = 0;
														goto IL_09a1;
													}
													goto IL_09c8;
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
		goto IL_0746;
		IL_09c8:
		if (obj14 == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rbx_v18 (System.Object)+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		List<object> tails3 = (List<object>)(object)_tails;
		if (_tails != null)
		{
			int version = tails3._version + 1;
			tails3._version = version;
			object[] items = tails3._items;
			if (tails3._items != null)
			{
				if (tails3._size >= items.Length)
				{
					((List<object>)(object)_tails).AddWithResize(obj14);
				}
				else
				{
					int num18 = tails3._size + 1;
					tails3._size = num18;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				TP_Fire2_Weapon parentWeapon2 = _parentWeapon;
				if ((object)_parentWeapon != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rbx_v18 (System.Object)+E8]");
					if ((nint)0 != 0)
					{
						object obj18 = parentWeapon2._003CTailAmount_003Ek__BackingField - num14;
						int num19 = obj18 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rbx_v18 (System.Object)+E8]");
						PhaserSprite phaserSprite = ((PhaserSprite)0).setDepth(num19);
						return;
					}
				}
			}
		}
		goto IL_0746;
		IL_09a1:
		bool flag10 = obj17 == null;
		obj14 = null;
		if (!flag10)
		{
			obj14 = projectile;
		}
		goto IL_09c8;
		IL_0746:
		throw new NullReferenceException();
	}

	public void SetMovementPath(List<float> rotations, List<float> forwards, bool isMirrored = false)
	{
		_rotationPath = rotations;
		_forwardPath = forwards;
		if (isMirrored)
		{
			bool cachedFlipX = !_cachedFlipX;
			_cachedFlipX = cachedFlipX;
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
				//IL_0059: Expected O, but got I
				//IL_008a: Unknown result type (might be due to invalid IL or missing references)
				//IL_008f: Expected O, but got Unknown
				bool cachedFlipX = !_cachedFlipX;
				_cachedFlipX = cachedFlipX;
				List<float> forwardPath = _forwardPath;
				int forwardCounter = _forwardCounter;
				_isRotating = false;
				int forwardCounter2 = _forwardCounter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v3 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)forwardCounter2 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v3 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj3 = 0;
					int forwardCounter3 = _forwardCounter + 1;
					_forwardCounter = forwardCounter3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v4+20+v43 @ rcx_v2 (System.Int32)*4]");
					object obj4 = 0 / _cachedWeaponSpeed;
					if (_moveTimer != null)
					{
						_moveTimer.Cancel();
					}
					Action onComplete2 = delegate
					{
						StartRotationTimer();
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

	private void StartForwardTimer()
	{
		//IL_003e: Expected O, but got I
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		List<float> forwardPath = _forwardPath;
		int forwardCounter = _forwardCounter;
		_isRotating = false;
		int forwardCounter2 = _forwardCounter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)forwardCounter2 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			int forwardCounter3 = _forwardCounter + 1;
			_forwardCounter = forwardCounter3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4+20+v33 @ rcx_v2 (System.Int32)*4]");
			object obj2 = 0 / _cachedWeaponSpeed;
			if (_moveTimer != null)
			{
				_moveTimer.Cancel();
			}
			Action onComplete = delegate
			{
				StartRotationTimer();
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Fire2_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		if (_tails == null)
		{
			return;
		}
		List<TP_Fire2Tail_Projectile> tails = _tails;
		object obj2 = 0;
		object obj3 = 0;
		while (true)
		{
			if ((nint)obj3 < tails._size)
			{
				List<TP_Fire2Tail_Projectile> tails2 = _tails;
				if ((nint)obj2 >= tails2._size)
				{
					break;
				}
				TP_Fire2Tail_Projectile[] items = tails2._items;
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
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
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
		List<TP_Fire2Tail_Projectile> tails = _tails;
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v8 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
		}
		_positions = null;
		List<Quaternion> rotations = _rotations;
		if (_rotations != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rdx_v10 (System.Collections.Generic.List`1<UnityEngine.Quaternion>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
		}
		_rotations = null;
		List<float> rotationPath = _rotationPath;
		if (_rotationPath != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdx_v12 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
		}
		_rotationPath = null;
		List<float> forwardPath = _forwardPath;
		if (_forwardPath != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rdx_v14 (System.Collections.Generic.List`1<System.Single>)+1C]");
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
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}

	private void _003CInitProjectile_003Eb__43_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CStartRotationTimer_003Eb__46_0()
	{
		//IL_0059: Expected O, but got I
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		bool cachedFlipX = !_cachedFlipX;
		_cachedFlipX = cachedFlipX;
		List<float> forwardPath = _forwardPath;
		int forwardCounter = _forwardCounter;
		_isRotating = false;
		int forwardCounter2 = _forwardCounter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v3 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)forwardCounter2 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v3 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			int forwardCounter3 = _forwardCounter + 1;
			_forwardCounter = forwardCounter3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v4+20+v43 @ rcx_v2 (System.Int32)*4]");
			object obj2 = 0 / _cachedWeaponSpeed;
			if (_moveTimer != null)
			{
				_moveTimer.Cancel();
			}
			Action onComplete = delegate
			{
				StartRotationTimer();
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

	private void _003CStartForwardTimer_003Eb__47_0()
	{
		StartRotationTimer();
	}
}
