using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class MadMoonProjectile : Projectile
{
	private Camera _camera;

	private float bounceBack = 0.1f;

	private float scaleUp = 1f;

	private bool bigWin;

	private int reel;

	public SpriteTrail trail;

	public MadMoonSymbol madMoonSymbol;

	public MadMoonSymbolType type;

	private Tween _positionTween;

	private Tween _scaleTween;

	private Vector3 initialCamPos;

	private MadMoonWeapon _parentWeapon;

	private PhaserSprite _003C_GroundFx_003Ek__BackingField;

	private PhaserSprite _003C_GroundFxRing_003Ek__BackingField;

	private MultiTargetTween _groundTween;

	public float Duration_ScaleAnimation = 0.25f;

	public float Duration_FadeOut = 0.2f;

	public float Duration_Starting = 0.25f;

	public float Duration_Landing = 0.25f;

	public float Duration_Spinning = 0.1f;

	private PhaserSprite _GroundFx
	{
		get
		{
			return _003C_GroundFx_003Ek__BackingField;
		}
		set
		{
			_003C_GroundFx_003Ek__BackingField = value;
		}
	}

	private PhaserSprite _GroundFxRing
	{
		get
		{
			return _003C_GroundFxRing_003Ek__BackingField;
		}
		set
		{
			_003C_GroundFxRing_003Ek__BackingField = value;
		}
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_04df: Expected O, but got I4
		//IL_011d: Expected O, but got I4
		//IL_0190: Expected I, but got O
		//IL_01c6: Expected I, but got O
		//IL_01d6: Expected O, but got I
		//IL_020e: Expected O, but got I
		//IL_0251: Expected I, but got O
		//IL_0259: Expected I, but got O
		//IL_0269: Expected O, but got I
		//IL_02a1: Expected O, but got I
		//IL_0577->IL04b6: Incompatible stack heights: 1 vs 0
		//IL_010a->IL04b6: Incompatible stack heights: 1 vs 0
		//IL_02ca->IL02ca: Incompatible stack heights: 5 vs 1
		//IL_031d->IL04b6: Incompatible stack heights: 1 vs 0
		//IL_0349->IL04b6: Incompatible stack heights: 1 vs 0
		//IL_0376->IL04b6: Incompatible stack heights: 1 vs 0
		//IL_03f6->IL04b6: Incompatible stack heights: 4 vs 0
		//IL_0422->IL04b6: Incompatible stack heights: 4 vs 0
		//IL_044f->IL04b6: Incompatible stack heights: 4 vs 0
		base.InitProjectile(pool, weapon, index);
		setVelocity(0f, (float?)(object)0);
		_isCullable = false;
		SpriteTrail componentInChildren = GetComponentInChildren<SpriteTrail>();
		trail = componentInChildren;
		Camera camera = _camera;
		if ((object)_camera == null || ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0)
		{
			Camera main = Camera.main;
			_camera = main;
		}
		if ((object)trail != null)
		{
			trail.enabled = false;
			SpriteRenderer renderer = _renderer;
			if ((object)_renderer != null)
			{
				bool flag = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
				SpriteRenderer.set_maskInteraction_Injected(((UnityEngine.Object)renderer).m_CachedPtr, SpriteMaskInteraction.VisibleInsideMask);
				if ((object)trail != null)
				{
					trail.SetMaskInteraction(SpriteMaskInteraction.VisibleInsideMask);
					ArcadeSprite arcadeSprite = setAlpha(0.65f);
					BaseBody baseBody = body;
					if (body != null)
					{
						baseBody._checkCollision = (ArcadeBodyCollision)0;
						Bounds bounds = CameraExtensions.OrthographicBounds(_camera);
						initialCamPos = bounds.m_Center;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
						_ = bounds.m_Center;
						DG.Tweening.TweenExtensions.Kill(_positionTween);
						ArcadeSprite arcadeSprite2 = setDepth(10001);
						Weapon weapon2 = _weapon;
						nint num = (nint)typeof(MadMoonWeapon);
						if ((object)_weapon == null)
						{
							_parentWeapon = null;
						}
						else
						{
							nint num2 = (nint)weapon2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v992 @ rdx_v28 (Il2CppClass<VampireSurvivors.Objects.Weapons.MadMoonWeapon>)+130]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1071 @ r9_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v992 @ rdx_v28 (Il2CppClass<VampireSurvivors.Objects.Weapons.MadMoonWeapon>)+130]");
							bool flag2 = num3 < 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1071 @ r9_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1126 @ rax_v117+FFFFFFF8+v1072 @ rax_v116*8]");
							bool flag3 = 0 != (nint)typeof(MadMoonWeapon);
							_parentWeapon = (MadMoonWeapon)_weapon;
							nint num4 = (nint)typeof(MadMoonWeapon);
							nint num5 = (nint)weapon2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ rdx_v56 (Il2CppClass<VampireSurvivors.Objects.Weapons.MadMoonWeapon>)+130]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1088 @ r9_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1086 @ rdx_v56 (Il2CppClass<VampireSurvivors.Objects.Weapons.MadMoonWeapon>)+130]");
							bool flag4 = num6 < 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1088 @ r9_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1090 @ rax_v119+FFFFFFF8+v1268 @ rax_v118*8]");
							bool flag5 = 0 != (nint)typeof(MadMoonWeapon);
						}
						GameObject gameObject = base.gameObject;
						Vector2 pos = default(Vector2);
						PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "round");
						_003C_GroundFx_003Ek__BackingField = phaserSprite;
						if ((object)_003C_GroundFx_003Ek__BackingField != null)
						{
							GameObject gameObject2 = _003C_GroundFx_003Ek__BackingField.gameObject;
							if ((object)gameObject2 != null)
							{
								((UnityEngine.Object)gameObject2).SetName("MMRound");
								if ((object)_003C_GroundFx_003Ek__BackingField != null)
								{
									Transform transform = _003C_GroundFx_003Ek__BackingField.transform;
									bool flag6 = (object)transform == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1493 @ rax_v61 (UnityEngine.Transform)+10]");
									bool flag7 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1493 @ rax_v61 (UnityEngine.Transform)+10]");
									Vector3 value = default(Vector3);
									Transform.set_localPosition_Injected((IntPtr)0, ref value);
									PhaserSprite phaserSprite2 = RenderingExtensions.SetScale(_003C_GroundFx_003Ek__BackingField, 0f);
									bool flag8 = (object)_003C_GroundFx_003Ek__BackingField == null;
									PhaserSprite phaserSprite3 = _003C_GroundFx_003Ek__BackingField.setDepth(1996);
									GameObject gameObject3 = base.gameObject;
									PhaserSprite phaserSprite4 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "vfx", "sPFX_ring_64");
									_003C_GroundFxRing_003Ek__BackingField = phaserSprite4;
									if ((object)_003C_GroundFxRing_003Ek__BackingField != null)
									{
										GameObject gameObject4 = _003C_GroundFxRing_003Ek__BackingField.gameObject;
										if ((object)gameObject4 != null)
										{
											((UnityEngine.Object)gameObject4).SetName("MMRing");
											if ((object)_003C_GroundFxRing_003Ek__BackingField != null)
											{
												Transform transform2 = _003C_GroundFxRing_003Ek__BackingField.transform;
												bool flag9 = (object)transform2 == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v80 (UnityEngine.Transform)+10]");
												bool flag10 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1671 @ rax_v80 (UnityEngine.Transform)+10]");
												Transform.set_localPosition_Injected((IntPtr)0, ref value);
												PhaserSprite phaserSprite5 = RenderingExtensions.SetScale(_003C_GroundFxRing_003Ek__BackingField, 0f);
												bool flag11 = (object)_003C_GroundFxRing_003Ek__BackingField == null;
												PhaserSprite phaserSprite6 = _003C_GroundFxRing_003Ek__BackingField.setDepth(1996);
												bool flag12 = (object)_003C_GroundFxRing_003Ek__BackingField == null;
												PhaserSprite phaserSprite7 = _003C_GroundFxRing_003Ek__BackingField.setBlendMode(BlendMode.Add);
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
		throw new NullReferenceException();
	}

	public void PlayGroundFX()
	{
		//IL_01d5: Expected I, but got O
		//IL_022d: Expected I, but got O
		//IL_0094: Expected I, but got O
		//IL_0291: Expected O, but got I4
		//IL_029f: Expected O, but got I4
		//IL_00f8: Expected O, but got I4
		//IL_0106: Expected O, but got I4
		if (_groundTween != null)
		{
			_groundTween.Kill();
		}
		if (!bigWin)
		{
			PhaserSprite phaserSprite = _003C_GroundFx_003Ek__BackingField.setBlendMode(BlendMode.Normal);
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_003C_GroundFx_003Ek__BackingField != null)
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
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				//IL_002e: Expected O, but got I4
				//IL_0065: Expected O, but got I4
				PhaserSprite phaserSprite3 = _003C_GroundFx_003Ek__BackingField.setAlpha(0f);
				PhaserSprite phaserSprite4 = _003C_GroundFx_003Ek__BackingField.setScale(0f, (float?)(object)0);
				PhaserSprite phaserSprite5 = _003C_GroundFxRing_003Ek__BackingField.setAlpha(0f);
				PhaserSprite phaserSprite6 = _003C_GroundFxRing_003Ek__BackingField.setScale(0f, (float?)(object)0);
			};
			tweenConfig.onComplete = onComplete;
			TweenCallback onStart = delegate
			{
				//IL_002e: Expected O, but got I4
				//IL_0065: Expected O, but got I4
				PhaserSprite phaserSprite3 = _003C_GroundFx_003Ek__BackingField.setAlpha(1f);
				PhaserSprite phaserSprite4 = _003C_GroundFx_003Ek__BackingField.setScale(0f, (float?)(object)0);
				PhaserSprite phaserSprite5 = _003C_GroundFxRing_003Ek__BackingField.setAlpha(0f);
				PhaserSprite phaserSprite6 = _003C_GroundFxRing_003Ek__BackingField.setScale(0f, (float?)(object)0);
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween groundTween = Tweens.Add(tweenConfig);
			_groundTween = groundTween;
			return;
		}
		PhaserSprite phaserSprite2 = _003C_GroundFx_003Ek__BackingField.setBlendMode(BlendMode.Add);
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[2];
		if ((object)_003C_GroundFx_003Ek__BackingField != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_003C_GroundFxRing_003Ek__BackingField != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 200f;
		tweenConfig2.scale = (float?)(object)1;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onComplete2 = delegate
		{
			//IL_002e: Expected O, but got I4
			//IL_0065: Expected O, but got I4
			PhaserSprite phaserSprite3 = _003C_GroundFx_003Ek__BackingField.setAlpha(0f);
			PhaserSprite phaserSprite4 = _003C_GroundFx_003Ek__BackingField.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite5 = _003C_GroundFxRing_003Ek__BackingField.setAlpha(0f);
			PhaserSprite phaserSprite6 = _003C_GroundFxRing_003Ek__BackingField.setScale(0f, (float?)(object)0);
		};
		tweenConfig2.onComplete = onComplete2;
		TweenCallback onStart2 = delegate
		{
			//IL_002e: Expected O, but got I4
			//IL_0065: Expected O, but got I4
			PhaserSprite phaserSprite3 = _003C_GroundFx_003Ek__BackingField.setAlpha(1f);
			PhaserSprite phaserSprite4 = _003C_GroundFx_003Ek__BackingField.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite5 = _003C_GroundFxRing_003Ek__BackingField.setAlpha(1f);
			PhaserSprite phaserSprite6 = _003C_GroundFxRing_003Ek__BackingField.setScale(0f, (float?)(object)0);
		};
		tweenConfig2.onStart = onStart2;
		MultiTargetTween groundTween2 = Tweens.Add(tweenConfig2);
		_groundTween = groundTween2;
	}

	public void SetBigWin(bool _bigWin)
	{
		bigWin = _bigWin;
	}

	public void AfterInit(MadMoonSymbolType type, MadMoonSymbol madMoonSymbol, int reel, Vector2 pos)
	{
		//IL_0337: Expected O, but got I4
		//IL_0351: Expected O, but got I4
		//IL_0197: Expected O, but got I4
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_02a1->IL02bb: Incompatible stack heights: 1 vs 0
		//IL_020a->IL02bb: Incompatible stack heights: 1 vs 0
		//IL_024a->IL02bb: Incompatible stack heights: 1 vs 0
		this.type = type;
		int num = default(int);
		this.reel = num;
		setSprite(madMoonSymbol);
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Transform parent = transform.parent;
			if ((object)_weapon != null)
			{
				Transform transform2 = _weapon.transform;
				bool flag = (object)transform2 == null;
				bool flag2 = (object)parent == null;
				object obj = flag2 & flag;
				bool flag3 = obj == null;
				object obj2 = !flag3;
				if (obj2 == null)
				{
					bool flag4;
					if ((object)transform2 != null)
					{
						if ((object)parent != null)
						{
							object obj3 = (object)parent - (object)transform2;
							flag4 = obj3 == null;
						}
						else
						{
							flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						}
					}
					else
					{
						if ((object)parent == null)
						{
							goto IL_02bb;
						}
						flag4 = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
					}
					if (!flag4)
					{
						Transform transform3 = base.transform;
						if ((object)_weapon != null)
						{
							Transform parent2 = _weapon.transform;
							if ((object)transform3 != null)
							{
								transform3.SetParent(parent2, worldPositionStays: false);
								goto IL_0170;
							}
						}
						goto IL_02bb;
					}
				}
				goto IL_0170;
			}
		}
		goto IL_02bb;
		IL_02bb:
		throw new NullReferenceException();
		IL_0224:
		startMoving();
		return;
		IL_0170:
		Transform transform4 = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rax_v21 (UnityEngine.Transform)+10]");
		bool flag5 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rax_v21 (UnityEngine.Transform)+10]");
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value);
		bool flag6 = type == MadMoonSymbolType.Starting;
		if (!flag6)
		{
			object obj4 = type - 1;
			if (!flag6)
			{
				object obj5 = obj4 - 1;
				if (flag6)
				{
					if ((object)trail != null)
					{
						trail.enabled = true;
						ArcadeSprite arcadeSprite = setAlpha(0.65f);
						goto IL_0224;
					}
					goto IL_02bb;
				}
				if ((nint)obj5 != 1)
				{
					return;
				}
			}
			ArcadeSprite arcadeSprite2 = setAlpha(0.65f);
			if ((object)trail != null)
			{
				trail.enabled = false;
				goto IL_0224;
			}
		}
		else
		{
			ArcadeSprite arcadeSprite3 = setAlpha(0f);
			if ((object)trail != null)
			{
				trail.enabled = false;
				return;
			}
		}
		goto IL_02bb;
	}

	public override void InternalUpdate()
	{
		//IL_0082: Expected O, but got I
		//IL_009a: Invalid comparison between F4 and O
		//IL_0117->IL00bc: Incompatible stack heights: 1 vs 0
		if ((object)trail != null)
		{
			trail.SetMaskInteraction(SpriteMaskInteraction.VisibleInsideMask);
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				MadMoonWeapon parentWeapon = _parentWeapon;
				if ((object)_parentWeapon != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v15 (VampireSurvivors.Objects.Weapons.MadMoonWeapon)+1A4]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
					object obj = num ^ 0;
					float num2 = (float)obj * 0.5f;
					object obj2 = default(object);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
					{
						base.Despawn();
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void setSprite(MadMoonSymbol madMoonSymbol)
	{
		//IL_01f6: Expected O, but got Ref
		//IL_004d: Expected O, but got I4
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_00bf: Expected O, but got I4
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		this.madMoonSymbol = madMoonSymbol;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite = setFrame(sprite);
		bool flag = madMoonSymbol == MadMoonSymbol.Curse;
		PhaserSprite phaserSprite2;
		uint tint;
		if (!flag)
		{
			object obj2 = madMoonSymbol - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					if ((nint)obj3 != 1)
					{
						bool flag2 = madMoonSymbol == MadMoonSymbol.Curse;
						if (flag2)
						{
							goto IL_01c5;
						}
						object obj4 = madMoonSymbol - 1;
						if (flag2)
						{
							goto IL_018e;
						}
						object obj5 = obj4 - 1;
						if (flag2)
						{
							goto IL_0157;
						}
						if ((nint)obj5 != 1)
						{
							return;
						}
					}
					else
					{
						PhaserSprite phaserSprite = _003C_GroundFx_003Ek__BackingField.setTint(16776960u);
					}
					phaserSprite2 = _003C_GroundFxRing_003Ek__BackingField;
					tint = 16776960u;
					goto IL_01ff;
				}
				PhaserSprite phaserSprite3 = _003C_GroundFx_003Ek__BackingField.setTint(65280u);
				goto IL_0157;
			}
			PhaserSprite phaserSprite4 = _003C_GroundFx_003Ek__BackingField.setTint(65535u);
			goto IL_018e;
		}
		PhaserSprite phaserSprite5 = _003C_GroundFx_003Ek__BackingField.setTint(16711935u);
		goto IL_01c5;
		IL_01c5:
		phaserSprite2 = _003C_GroundFxRing_003Ek__BackingField;
		tint = 16711935u;
		goto IL_01ff;
		IL_01ff:
		PhaserSprite phaserSprite6 = phaserSprite2.setTint(tint);
		return;
		IL_018e:
		phaserSprite2 = _003C_GroundFxRing_003Ek__BackingField;
		tint = 65535u;
		goto IL_01ff;
		IL_0157:
		phaserSprite2 = _003C_GroundFxRing_003Ek__BackingField;
		tint = 65280u;
		goto IL_01ff;
	}

	private static float map(float value, float fromLow, float fromHigh, float toLow, float toHigh)
	{
		float num = value - fromLow;
		object obj = default(object);
		float num2 = (float)obj - toLow;
		float num3 = fromHigh - fromLow;
		float num4 = num * num2;
		float num5 = num4 / num3;
		return num5 + toLow;
	}

	private void DoScaleEffect()
	{
	}

	public void startMoving()
	{
		//IL_0066: Expected O, but got I4
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Expected O, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_064b: Expected I, but got O
		//IL_018d: Expected I, but got O
		Bounds bounds = CameraExtensions.OrthographicBounds(_camera);
		initialCamPos = bounds.m_Center;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
		_ = bounds.m_Center;
		bool flag = type == MadMoonSymbolType.Starting;
		object obj3 = default(object);
		Sequence sequence3;
		if (!flag)
		{
			object obj = type - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (flag)
				{
					Sequence sequence = DOTween.Sequence();
					float2 float5 = base.position;
					MadMoonWeapon parentWeapon = _parentWeapon;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rax_v82 (VampireSurvivors.Objects.Weapons.MadMoonWeapon)+1A4]");
					float num = 0f * 1.5f;
					float endValue = (float)obj3 - num;
					TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOMoveY(_cachedTransform, endValue, Duration_Spinning);
					if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
					{
						Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, ((Tween)sequence).duration);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v680 @ r8_v31 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MadMoonProjectile>)+370]");
					TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
					nint num2 = (nint)this;
					if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
					{
						sequence.onComplete = onComplete;
					}
					Sequence positionTween = VampireSurvivors.Tools.TweenExtensions.SetGameId(sequence);
					_positionTween = positionTween;
					return;
				}
				if ((nint)obj2 != 1)
				{
					return;
				}
			}
			sequence3 = DOTween.Sequence();
			float2 float6 = base.position;
			float2 float7 = base.position;
			MadMoonWeapon parentWeapon2 = _parentWeapon;
			TweenCallback<float> tweenCallback = null;
			float f = default(float);
			((MadMoonProjectile)(object)tweenCallback).KeepUpWithCameraMovement(f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v38 (VampireSurvivors.Objects.Weapons.MadMoonWeapon)+1A4]");
			object obj4 = obj3 - 0;
			float num3 = (float)obj4 - bounceBack;
			float num4 = default(float);
			Tweener tweener = DOVirtual.Float(num4, num3, Duration_Landing, tweenCallback);
			((MadMoonProjectile)(object)tweener).KeepUpWithCameraMovement(num3);
			Tween t2 = default(Tween);
			if (TweenSettingsExtensions.ValidateAddToSequence(sequence3, t2, false))
			{
				Sequence sequence4 = Sequence.DoInsert(sequence3, t2, ((Tween)sequence3).duration);
			}
			float2 float8 = base.position;
			MadMoonWeapon parentWeapon3 = _parentWeapon;
			float2 float9 = base.position;
			MadMoonWeapon parentWeapon4 = _parentWeapon;
			TweenCallback<float> tweenCallback2 = null;
			((MadMoonProjectile)(object)tweenCallback2).KeepUpWithCameraMovement(num3);
			float num5 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v46 (VampireSurvivors.Objects.Weapons.MadMoonWeapon)+1A4]");
			float num6 = num5 - 0f;
			float num7 = (float)obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ rax_v48 (VampireSurvivors.Objects.Weapons.MadMoonWeapon)+1A4]");
			float num8 = num7 - 0f;
			float num9 = num6 - bounceBack;
			Tweener tweener2 = DOVirtual.Float(num9, num8, Duration_Landing, tweenCallback2);
			((MadMoonProjectile)(object)tweener2).KeepUpWithCameraMovement(num8);
			Tween t3 = default(Tween);
			TweenCallback onComplete2;
			if (TweenSettingsExtensions.ValidateAddToSequence(sequence3, t3, false))
			{
				Sequence sequence5 = Sequence.DoInsert(sequence3, t3, ((Tween)sequence3).duration);
				TweenCallback tweenCallback3 = LandingFinished;
				onComplete2 = tweenCallback3;
			}
			else
			{
				TweenCallback tweenCallback4 = LandingFinished;
				bool flag2 = sequence3 == null;
				onComplete2 = tweenCallback4;
				if (flag2)
				{
					goto IL_0480;
				}
			}
			if (((Tween)sequence3)._003Cactive_003Ek__BackingField)
			{
				sequence3.onComplete = onComplete2;
			}
			goto IL_0480;
		}
		Sequence sequence6 = DOTween.Sequence();
		float2 float10 = base.position;
		float endValue2 = (float)obj3 + bounceBack;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMoveY(_cachedTransform, endValue2, Duration_Starting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
		Tween t4 = default(Tween);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence6, t4, false))
		{
			Sequence sequence7 = Sequence.DoInsert(sequence6, t4, ((Tween)sequence6).duration);
		}
		float2 float11 = base.position;
		MadMoonWeapon parentWeapon5 = _parentWeapon;
		object obj5 = obj3 + bounceBack;
		float num10 = (float)obj5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rax_v14 (VampireSurvivors.Objects.Weapons.MadMoonWeapon)+1A4]");
		float endValue3 = num10 - 0f;
		TweenerCore<Vector3, Vector3, VectorOptions> t5 = ShortcutExtensions.DOMoveY(_cachedTransform, endValue3, Duration_Starting);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence6, (Tween)t5, false))
		{
			Sequence sequence8 = Sequence.DoInsert(sequence6, (Tween)t5, ((Tween)sequence6).duration);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v802 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MadMoonProjectile>)+370]");
		TweenCallback onComplete3 = new TweenCallback(this, (IntPtr)0);
		nint num11 = (nint)this;
		if (sequence6 != null && ((Tween)sequence6)._003Cactive_003Ek__BackingField)
		{
			sequence6.onComplete = onComplete3;
		}
		Sequence positionTween2 = VampireSurvivors.Tools.TweenExtensions.SetGameId(sequence6);
		_positionTween = positionTween2;
		return;
		IL_0480:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		sequence3.stringId = "DefaultGameTweenId";
		_positionTween = sequence3;
	}

	private void GetComponents()
	{
		SpriteTrail componentInChildren = GetComponentInChildren<SpriteTrail>();
		trail = componentInChildren;
		Camera camera = _camera;
		if ((object)_camera == null || ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0)
		{
			Camera main = Camera.main;
			_camera = main;
		}
	}

	private void KeepUpWithCameraMovement(float f)
	{
		Bounds bounds = CameraExtensions.OrthographicBounds(_camera);
		float2 float5 = base.position;
		float2 float6 = default(float2);
		base.position = float6;
	}

	private unsafe void LandingFinished()
	{
		//IL_00a2: Expected O, but got Ref
		//IL_00ff->IL00ae: Incompatible stack heights: 1 vs 0
		if (type != MadMoonSymbolType.Winning)
		{
			Tween tween = FadeOut();
			return;
		}
		if ((object)_parentWeapon != null)
		{
			_parentWeapon.SpawnZone(reel);
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
				if ((object)_parentWeapon != null)
				{
					object obj = default(object);
					_parentWeapon.PlayParticleVFXAt((Vector3)(&obj), madMoonSymbol);
					PlayGroundFX();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void ScaleAnimation()
	{
		Tween scaleTween = _scaleTween;
		if (_scaleTween != null && scaleTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_scaleTween);
		}
		float num = base.scale;
		float endValue = num + scaleUp;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, endValue, Duration_ScaleAnimation);
		TweenCallback tweenCallback = delegate
		{
			float num2 = base.scale;
			float endValue2 = num2 - scaleUp;
			TweenerCore<Vector3, Vector3, VectorOptions> scaleTween2 = ShortcutExtensions.DOScale(_cachedTransform, endValue2, Duration_ScaleAnimation);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			_scaleTween = scaleTween2;
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = tweenerCore;
	}

	public Tween FadeOut()
	{
		//IL_0076: Expected I, but got O
		Tween positionTween = _positionTween;
		if (_positionTween != null && positionTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_positionTween);
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_renderer, 0f, Duration_FadeOut);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MadMoonProjectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tweenerCore != null)
		{
			return tweenerCore;
		}
		return (Tween)(object)new NullReferenceException();
	}

	public Tween FadeOn()
	{
		Tween positionTween = _positionTween;
		if (_positionTween != null && positionTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_positionTween);
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_renderer, 0.65f, Duration_FadeOut);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tweenerCore != null)
		{
			return tweenerCore;
		}
		return (Tween)(object)new NullReferenceException();
	}

	private void _003CPlayGroundFX_003Eb__22_0()
	{
		//IL_002e: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		PhaserSprite phaserSprite = _003C_GroundFx_003Ek__BackingField.setAlpha(0f);
		PhaserSprite phaserSprite2 = _003C_GroundFx_003Ek__BackingField.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite3 = _003C_GroundFxRing_003Ek__BackingField.setAlpha(0f);
		PhaserSprite phaserSprite4 = _003C_GroundFxRing_003Ek__BackingField.setScale(0f, (float?)(object)0);
	}

	private void _003CPlayGroundFX_003Eb__22_1()
	{
		//IL_002e: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		PhaserSprite phaserSprite = _003C_GroundFx_003Ek__BackingField.setAlpha(1f);
		PhaserSprite phaserSprite2 = _003C_GroundFx_003Ek__BackingField.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite3 = _003C_GroundFxRing_003Ek__BackingField.setAlpha(1f);
		PhaserSprite phaserSprite4 = _003C_GroundFxRing_003Ek__BackingField.setScale(0f, (float?)(object)0);
	}

	private void _003CPlayGroundFX_003Eb__22_2()
	{
		//IL_002e: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		PhaserSprite phaserSprite = _003C_GroundFx_003Ek__BackingField.setAlpha(0f);
		PhaserSprite phaserSprite2 = _003C_GroundFx_003Ek__BackingField.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite3 = _003C_GroundFxRing_003Ek__BackingField.setAlpha(0f);
		PhaserSprite phaserSprite4 = _003C_GroundFxRing_003Ek__BackingField.setScale(0f, (float?)(object)0);
	}

	private void _003CPlayGroundFX_003Eb__22_3()
	{
		//IL_002e: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		PhaserSprite phaserSprite = _003C_GroundFx_003Ek__BackingField.setAlpha(1f);
		PhaserSprite phaserSprite2 = _003C_GroundFx_003Ek__BackingField.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite3 = _003C_GroundFxRing_003Ek__BackingField.setAlpha(0f);
		PhaserSprite phaserSprite4 = _003C_GroundFxRing_003Ek__BackingField.setScale(0f, (float?)(object)0);
	}

	private void _003CScaleAnimation_003Eb__38_0()
	{
		float num = base.scale;
		float endValue = num - scaleUp;
		TweenerCore<Vector3, Vector3, VectorOptions> scaleTween = ShortcutExtensions.DOScale(_cachedTransform, endValue, Duration_ScaleAnimation);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = scaleTween;
	}
}
