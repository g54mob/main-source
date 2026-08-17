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
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Dominus1_Projectile : Projectile
{
	private float _radius;

	private PhaserSprite _animatedSprite;

	private Tween _radiusTween;

	private bool _isDespawning;

	private List<uint> _tints;

	private MultiTargetTween _scaleTween;

	private Timer _expireTimer;

	private bool _canMove;

	private MultiTargetTween _speedTween;

	private bool _isMoving;

	private string start;

	private string loop;

	private string startInverse;

	private string loopInverse;

	private TP_Dominus1_Weapon _trueWeapon;

	private bool inverted;

	private Vector2 _initialVelocity;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private float _amount;

	private List<InvisibleProjectile> _damageBoxes;

	private float _targetRadius;

	private ParticleSystem _pfxInverse;

	private List<string> _normalPFXFrames;

	private List<string> _inversePFXFrames;

	private Tween speedTween;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0092: Expected O, but got I4
		//IL_01e3: Expected O, but got I4
		//IL_01e3: Expected I4, but got O
		//IL_02c6: Expected O, but got I4
		//IL_02c6: Expected I4, but got O
		//IL_03a9: Expected O, but got I4
		//IL_03a9: Expected I4, but got O
		//IL_0421: Expected O, but got I4
		//IL_0421: Expected I4, but got O
		//IL_0886: Expected I, but got O
		//IL_08db: Expected O, but got Ref
		//IL_04de: Expected O, but got Ref
		//IL_04f8: Expected native int or pointer, but got O
		//IL_056e: Expected O, but got Ref
		//IL_0588: Expected native int or pointer, but got O
		//IL_05c0: Expected O, but got Ref
		//IL_05da: Expected native int or pointer, but got O
		//IL_06a5: Expected O, but got Ref
		//IL_06bf: Expected native int or pointer, but got O
		//IL_0735: Expected O, but got Ref
		//IL_074f: Expected native int or pointer, but got O
		//IL_0787: Expected O, but got Ref
		//IL_07a1: Expected native int or pointer, but got O
		//IL_062e->IL0822: Incompatible stack heights: 5 vs 0
		//IL_0686->IL0822: Incompatible stack heights: 5 vs 0
		//IL_07f5->IL0822: Incompatible stack heights: 5 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				_initialVelocity = (Vector2)0;
				GameObject gameObject = base.gameObject;
				Vector2 vector = default(Vector2);
				PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Dom01");
				_animatedSprite = animatedSprite;
				string text = default(string);
				int num = default(int);
				bool flag = default(bool);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Dom", 1, 5, vector, text, num, flag);
				List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_Dom", 6, 9, vector, text, num, flag);
				List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("TP_VFX_DomInv", 1, 5, vector, text, num, flag);
				List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("TP_VFX_DomInv", 6, 9, vector, text, num, flag);
				PhaserSprite animatedSprite2 = _animatedSprite;
				if ((object)_animatedSprite != null && (object)animatedSprite2._spriteAnimation != null)
				{
					bool autoSetAnimation = default(bool);
					animatedSprite2._spriteAnimation.AddAnimation(start, animationFrames, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
					PhaserSprite animatedSprite3 = _animatedSprite;
					if ((object)_animatedSprite != null)
					{
						Action action = LoopAnim;
						if ((object)animatedSprite3._spriteAnimation != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186DD0180");
							PhaserSprite animatedSprite4 = _animatedSprite;
							if ((object)_animatedSprite != null && (object)animatedSprite4._spriteAnimation != null)
							{
								animatedSprite4._spriteAnimation.AddAnimation(startInverse, animationFrames3, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
								PhaserSprite animatedSprite5 = _animatedSprite;
								if ((object)_animatedSprite != null)
								{
									Action action2 = LoopAnim;
									if ((object)animatedSprite5._spriteAnimation != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186DD0180");
										PhaserSprite animatedSprite6 = _animatedSprite;
										if ((object)_animatedSprite != null && (object)animatedSprite6._spriteAnimation != null)
										{
											animatedSprite6._spriteAnimation.AddAnimation(loop, animationFrames2, 30, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
											PhaserSprite animatedSprite7 = _animatedSprite;
											if ((object)_animatedSprite != null && (object)animatedSprite7._spriteAnimation != null)
											{
												animatedSprite7._spriteAnimation.AddAnimation(loopInverse, animationFrames4, 30, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
												if ((object)_animatedSprite != null)
												{
													Transform transform = _animatedSprite.transform;
													bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
													Vector3 value = default(Vector3);
													Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
													Transform transform2 = base.transform;
													nint num2 = (nint)typeof(Vector3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rdx_v35 (Il2CppClass<UnityEngine.Vector3>)+B8]");
													nint num3 = 0;
													bool flag3 = (object)transform2 == null;
													_ = Vector3.zeroVector;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v856 @ rax_v61 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
													_ = 0;
													bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
													object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
													Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj3);
													GameObject gameObject2 = base.gameObject;
													bool flag5 = (object)gameObject2 == null;
													ParticleEmitterManager pfxManager = gameObject2.AddComponent<ParticleEmitterManager>();
													_pfxManager = pfxManager;
													ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
													bool flag6 = particleSystemConfig == null;
													_ = _normalPFXFrames;
													ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
													_ = 0;
													_ = 0;
													_ = 1;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+190]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(300f);
													_ = 0;
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 1f));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-10]");
													_ = 0;
													_ = 0;
													Transform parent = base.transform;
													if ((object)_pfxManager != null)
													{
														ParticleSystem pfx = _pfxManager.CreateEmitter(particleSystemConfig, parent);
														_pfx = pfx;
														ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("ThosePeople");
														if (particleSystemConfig2 != null)
														{
															_ = _inversePFXFrames;
															ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
															_ = 0;
															_ = 0;
															System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
															_ = 0;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
															_ = 0;
															_ = 0;
															_ = 1;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+190]");
															_ = 0;
															minMaxCurve2 = new ParticleSystem.MinMaxCurve(300f);
															_ = 0;
															_ = 0;
															ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
															_ = 0;
															_ = 0;
															System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
															_ = 0;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
															_ = 0;
															ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
															_ = 0;
															_ = 0;
															System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(1f, 1f));
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+120]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
															_ = 0;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
															_ = 0;
															_ = 0;
															Transform parent2 = base.transform;
															if ((object)_pfxManager != null)
															{
																ParticleSystem pfxInverse = _pfxManager.CreateEmitter(particleSystemConfig2, parent2);
																_pfxInverse = pfxInverse;
																return;
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
		throw new NullReferenceException();
	}

	public void OverrideVelocity(Vector2 velocity)
	{
		_initialVelocity = velocity;
	}

	public void SetDamageBoxes(List<InvisibleProjectile> invis)
	{
		//IL_0037: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		//IL_0134: Expected O, but got I
		//IL_00b1: Expected O, but got I
		//IL_00c1: Expected O, but got F4
		//IL_0142: Expected O, but got F4
		//IL_021d: Expected O, but got F4
		//IL_0173: Expected I, but got O
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Expected O, but got Unknown
		//IL_01eb->IL010e: Incompatible stack heights: 3 vs 0
		//IL_010d->IL01f0: Incompatible stack heights: 3 vs 0
		_damageBoxes = invis;
		List<InvisibleProjectile> damageBoxes = _damageBoxes;
		if (_damageBoxes != null)
		{
			object obj = 0;
			object obj2 = 0;
			Vector3 value = default(Vector3);
			while (true)
			{
				if ((nint)obj2 < damageBoxes._size)
				{
					List<InvisibleProjectile> damageBoxes2 = _damageBoxes;
					bool flag = (nint)obj >= damageBoxes2._size;
					InvisibleProjectile[] items = damageBoxes2._items;
					List<InvisibleProjectile> list = (List<InvisibleProjectile>)(object)items[obj];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rbx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Projectiles.InvisibleProjectile>)+B8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rax_v32+28]");
					object obj4 = 0;
					object obj5 = _targetRadius ^ -0f;
					object obj6 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v321 @ rdx_v19+218] (should have been resolved before IL gen)");
					object obj7 = UnityEngine.Random.value;
					object obj8 = UnityEngine.Random.value;
					bool flag2 = list._items == null;
					IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)list._items);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					transform.SetParent(_cachedTransform, worldPositionStays: true);
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					damageBoxes = _damageBoxes;
					obj++;
					if (_damageBoxes == null)
					{
						break;
					}
					obj2 = obj;
					continue;
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void LoopAnim()
	{
		BaseBody baseBody = body;
		baseBody._enable = true;
		PhaserSprite animatedSprite = _animatedSprite;
		_canMove = true;
		string animation = ((!inverted) ? loop : loopInverse);
		animatedSprite._spriteAnimation.SetAnimation(animation);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I4, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_0454: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0179: Expected O, but got I4
		//IL_019e: Expected O, but got I4
		//IL_019e: Expected O, but got I4
		//IL_01bb: Expected O, but got I4
		//IL_02f7: Expected O, but got I4
		//IL_03db: Expected I4, but got F4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_042d;
		}
		nint num = (nint)typeof(TP_Dominus1_Weapon);
		int num2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v36 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r9_v16 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v36 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Dominus1_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r9_v16 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v62+FFFFFFF8+v72 @ rax_v57*8]");
			if (0 == (nint)typeof(TP_Dominus1_Weapon))
			{
				obj3 = 1;
				goto IL_043c;
			}
		}
		obj3 = 0;
		goto IL_043c;
		IL_043c:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_042d;
		IL_042d:
		_trueWeapon = (TP_Dominus1_Weapon)trueWeapon;
		TP_Dominus1_Weapon trueWeapon2 = _trueWeapon;
		if (trueWeapon2._003CInverted_003Ek__BackingField)
		{
			inverted = true;
		}
		BaseBody baseBody = body;
		_isCullable = false;
		_isDespawning = false;
		_canMove = false;
		_isMoving = false;
		_speed = 0f;
		baseBody._enable = false;
		float num4 = _weapon.PAmount();
		float num5 = default(float);
		_amount = num5;
		float num6 = _weapon.PArea();
		float targetRadius = num5 * _radius;
		_targetRadius = targetRadius;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody2 = body.setCircle(_targetRadius, (float?)(object)1, (float?)(object)1);
		PhaserSprite phaserSprite = _animatedSprite.setScale(num5, (float?)(object)0);
		PhaserSprite animatedSprite = _animatedSprite;
		string animation = ((!inverted) ? start : startInverse);
		animatedSprite._spriteAnimation.SetAnimation(animation);
		PhaserSprite phaserSprite2 = _animatedSprite.setVisible(visible: true);
		Circle circle = new Circle();
		circle._radius = _targetRadius;
		circle._x = 0f;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = circle;
		RenderingExtensions.SetEmitZone(_pfx, emitZone);
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = circle;
		RenderingExtensions.SetEmitZone(_pfxInverse, emitZone2);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * 100f;
		soundConfig.Detune = detune;
		float num7 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_DominusAnger, soundConfig, 200f, 3, num7);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num8 = _weapon.PDuration();
		Action onComplete = StartDespawn;
		float duration = 0f * 0.001f;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num7 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	private void LateUpdate()
	{
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_038c: Expected O, but got I
		//IL_00e1: Expected I, but got O
		//IL_02f9: Expected O, but got I
		//IL_034c: Expected O, but got I
		//IL_0202: Expected O, but got I
		//IL_021e->IL021e: Incompatible stack heights: 1 vs 0
		//IL_032f->IL032f: Incompatible stack heights: 2 vs 0
		if (PauseSystem._paused)
		{
			return;
		}
		if (!_canMove)
		{
			goto IL_021e;
		}
		if (!_isMoving)
		{
			_isMoving = true;
			if (speedTween != null)
			{
				DG.Tweening.TweenExtensions.Kill(speedTween);
			}
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			float x = default(float);
			((TP_Dominus1_Projectile)(object)dOSetter)._003CLateUpdate_003Eb__31_1(x);
			Weapon weapon = _weapon;
			if ((object)_weapon == null)
			{
				goto IL_032f;
			}
			nint num = (nint)weapon;
			float num2 = _weapon.PDuration();
			Vector2 vector = default(Vector2);
			float duration = (float)vector / 2000f;
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 2f, duration);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
			Tween gameId = default(Tween);
			Tween tween = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
			speedTween = tween;
		}
		int num3 = base.depth;
		int num4 = num3 - 1;
		RenderingExtensions.SetDepth(_pfx, num4);
		int num5 = base.depth;
		int num6 = num5 - 1;
		RenderingExtensions.SetDepth(_pfxInverse, num6);
		object cachedTransform = _cachedTransform;
		ParticleSystem system;
		bool num7;
		if (!inverted)
		{
			system = _pfx;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rbx_v12 (System.Object)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rbx_v12 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				num7 = flag;
				object obj2 = 0;
				goto IL_036d;
			}
		}
		else
		{
			system = _pfxInverse;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rbx_v12 (System.Object)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rbx_v12 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				num7 = flag2;
				object obj2 = 0;
				if ((nint)0 != 0)
				{
					goto IL_036d;
				}
				bool flag3 = (nint)0 == 0;
			}
		}
		goto IL_032f;
		IL_021e:
		float projectileSpeed = base.ProjectileSpeed;
		float projectileSpeed2 = base.ProjectileSpeed;
		ArcadeSprite sprite = _sprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Dominus1_Projectile)+150]");
		Vector2 vector2 = default(Vector2);
		object obj3 = vector2 * 0;
		float2 velocity = _initialVelocity * vector2;
		if ((object)_sprite != null)
		{
			BaseBody baseBody = sprite.body;
			if (sprite.body != null)
			{
				baseBody._velocity = velocity;
				return;
			}
		}
		goto IL_032f;
		IL_036d:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v750 @ rax_v30 (should have been resolved before IL gen)");
		RenderingExtensions.EmitParticleAt(system, vector2, 1);
		goto IL_021e;
		IL_032f:
		throw new NullReferenceException();
	}

	private void StartDespawn()
	{
		//IL_00b7: Expected I, but got O
		//IL_011b: Expected O, but got I4
		//IL_0136: Expected I, but got O
		if (_isDespawning)
		{
			return;
		}
		_isDespawning = true;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_animatedSprite != null)
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
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Dominus1_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
	}

	public override void Despawn()
	{
		//IL_0032: Expected O, but got I4
		//IL_003b: Expected O, but got I4
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_020b: Expected O, but got I4
		//IL_0219: Expected O, but got I4
		if (speedTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(speedTween);
		}
		List<InvisibleProjectile> damageBoxes = _damageBoxes;
		object obj = 0;
		object obj2 = 0;
		List<InvisibleProjectile> damageBoxes2 = _damageBoxes;
		while (true)
		{
			if ((nint)obj2 < damageBoxes._size)
			{
				if ((nint)obj >= damageBoxes2._size)
				{
					break;
				}
				InvisibleProjectile[] items = damageBoxes2._items;
				items[obj].Despawn();
				damageBoxes2 = _damageBoxes;
				obj++;
				obj2 = obj;
				damageBoxes = _damageBoxes;
				continue;
			}
			List<InvisibleProjectile> damageBoxes3 = _damageBoxes;
			int version = damageBoxes3._version + 1;
			damageBoxes3._version = version;
			damageBoxes3._size = 0;
			if (damageBoxes3._size > 0)
			{
				Array.Clear(damageBoxes3._items, 0, damageBoxes3._size);
			}
			PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
			if (_radiusTween != null)
			{
				DG.Tweening.TweenExtensions.Kill(_radiusTween);
			}
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			Timer expireTimer = _expireTimer;
			if (_expireTimer != null && !_expireTimer.IsDone)
			{
				float timeElapsed = _expireTimer.GetTimeElapsed();
				expireTimer._timeElapsedBeforeCancel = (float?)(object)1;
				expireTimer._timeElapsedBeforePause = (float?)(object)0;
			}
			base.Despawn();
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public TP_Dominus1_Projectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0ec4: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0eec: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0f14: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_0f3c: Expected O, but got I
		//IL_022a: Expected O, but got I
		_radius = 16f;
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(16777215u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 16777215;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(13421772u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 13421772;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(14540253u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 14540253;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(14548957u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 14548957;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(16777181u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 16777181;
		}
		_tints = list;
		start = "start";
		loop = "loop";
		startInverse = "startInverse";
		loopInverse = "loopInverse";
		_amount = 1f;
		_damageBoxes = new List<InvisibleProjectile>();
		_targetRadius = 10f;
		List<string> list2 = new List<string>();
		list2._version++;
		string[] items = list2._items;
		if (list2._size >= items.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Dom10.png");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items2 = list2._items;
		if (list2._size >= items2.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Dom11.png");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Dom12.png");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Dom13.png");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items5 = list2._items;
		if (list2._size >= items5.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Dom14.png");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items6 = list2._items;
		if (list2._size >= items6.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Dom15.png");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items7 = list2._items;
		if (list2._size >= items7.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Dom16.png");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items8 = list2._items;
		if (list2._size >= items8.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Dom17.png");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items9 = list2._items;
		if (list2._size >= items9.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Dom18.png");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items10 = list2._items;
		if (list2._size >= items10.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Dom19.png");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_normalPFXFrames = list2;
		List<string> list3 = new List<string>();
		list3._version++;
		string[] items11 = list3._items;
		if (list3._size >= items11.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"TP_VFX_DomInv10.png");
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list3._version++;
		string[] items12 = list3._items;
		if (list3._size >= items12.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"TP_VFX_DomInv11.png");
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list3._version++;
		string[] items13 = list3._items;
		if (list3._size >= items13.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"TP_VFX_DomInv12.png");
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list3._version++;
		string[] items14 = list3._items;
		if (list3._size >= items14.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"TP_VFX_DomInv13.png");
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list3._version++;
		string[] items15 = list3._items;
		if (list3._size >= items15.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"TP_VFX_DomInv14.png");
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list3._version++;
		string[] items16 = list3._items;
		if (list3._size >= items16.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"TP_VFX_DomInv15.png");
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list3._version++;
		string[] items17 = list3._items;
		if (list3._size >= items17.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"TP_VFX_DomInv16.png");
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list3._version++;
		string[] items18 = list3._items;
		if (list3._size >= items18.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"TP_VFX_DomInv17.png");
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list3._version++;
		string[] items19 = list3._items;
		if (list3._size >= items19.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"TP_VFX_DomInv18.png");
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list3._version++;
		string[] items20 = list3._items;
		if (list3._size >= items20.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"TP_VFX_DomInv19.png");
		}
		else
		{
			list3._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_inversePFXFrames = list3;
		base._002Ector();
	}

	private float _003CLateUpdate_003Eb__31_0()
	{
		return _speed;
	}

	private void _003CLateUpdate_003Eb__31_1(float x)
	{
		_speed = x;
	}
}
