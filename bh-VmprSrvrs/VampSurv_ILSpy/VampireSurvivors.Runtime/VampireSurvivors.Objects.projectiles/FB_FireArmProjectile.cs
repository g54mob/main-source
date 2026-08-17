using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_FireArmProjectile : Projectile
{
	private ParticleSystem _pfx;

	private Tween _scaleTween;

	private Tween _radiusTweenX;

	private float _deltaTime;

	private const float Percentage = 0.0625f;

	private const float Radius = 0.25f;

	private const float SpeedModifier = 35f;

	private Vector3 _centralPos;

	private Vector3 _movement;

	private SpriteAnimation _anim;

	private PhaserSprite _coronaSprite;

	private MultiTargetTween _coronaTween;

	private bool _isDespawning;

	private float coronaRatio = 1.36f;

	protected override void Awake()
	{
		base.Awake();
		GenerateParticleSystem();
		Sprite sprite = SpriteManager.GetSprite("Firearm-Firewall-F1", "firstBlood");
		float2 float5 = default(float2);
		ArcadeSprite arcadeSprite = setFrameIncludingOriginalSize(sprite, float5);
		CheckRenderer();
		GameObject gameObject = ((ArcadeSprite)this)._spriteRenderer.gameObject;
		SpriteAnimation anim = gameObject.AddComponent<SpriteAnimation>();
		_anim = anim;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Firearm-Firewall-F", 1, 4, "firstBlood", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_anim.AddAnimation("idle", animationFrames, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		_anim.SetAnimation("play");
		float2 float6 = base.position;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite coronaSprite = RenderingExtensions.AddPhaserSprite(gameObject2, float5, "firstBlood", "Spread Corona-F1");
		_coronaSprite = coronaSprite;
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("Spread Corona-F", 1, 12, "firstBlood", num);
		PhaserSprite coronaSprite2 = _coronaSprite;
		coronaSprite2._spriteAnimation.AddAnimation("idle", animationFrames2, 12, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite coronaSprite3 = _coronaSprite;
		coronaSprite3._spriteAnimation.SetAnimation("idle");
		PhaserSprite phaserSprite = _coronaSprite.setBlendMode(BlendMode.Add);
		PhaserSprite phaserSprite2 = _coronaSprite.setAlpha(0f);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0036: Expected O, but got I
		//IL_0036: Expected O, but got I
		//IL_0044: Expected I4, but got O
		//IL_0620: Expected I, but got O
		//IL_0664: Expected O, but got Ref
		//IL_0949: Expected I, but got O
		//IL_00c1: Expected O, but got Ref
		//IL_01cd: Expected I4, but got O
		//IL_06d6: Expected O, but got Ref
		//IL_06f5: Expected I4, but got O
		//IL_0707: Expected O, but got I
		//IL_075e: Expected O, but got Ref
		//IL_024f: Expected I4, but got O
		//IL_07d1: Expected O, but got Ref
		//IL_0282: Expected O, but got Ref
		//IL_0865: Expected O, but got Ref
		//IL_0897: Expected O, but got I
		//IL_08b1: Expected O, but got Ref
		//IL_08c9: Invalid comparison between O and F4
		//IL_08eb: Expected I, but got O
		//IL_0914: Expected O, but got I
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Expected O, but got Unknown
		//IL_0973->IL060b: Incompatible stack heights: 1 vs 0
		//IL_0696->IL060b: Incompatible stack heights: 1 vs 0
		//IL_01af->IL060b: Incompatible stack heights: 1 vs 0
		//IL_0212->IL060b: Incompatible stack heights: 1 vs 0
		//IL_0803->IL060b: Incompatible stack heights: 7 vs 0
		//IL_0368->IL060b: Incompatible stack heights: 7 vs 0
		//IL_038a->IL060b: Incompatible stack heights: 7 vs 0
		//IL_031a->IL060b: Incompatible stack heights: 7 vs 0
		//IL_03c6->IL060b: Incompatible stack heights: 7 vs 0
		//IL_03f9->IL060b: Incompatible stack heights: 7 vs 0
		//IL_098c->IL0919: Incompatible stack heights: 8 vs 7
		//IL_0476->IL060b: Incompatible stack heights: 7 vs 0
		//IL_04e7->IL060b: Incompatible stack heights: 7 vs 0
		//IL_04c5->IL04c5: Incompatible stack heights: 8 vs 7
		//IL_0510->IL060b: Incompatible stack heights: 7 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		_ = 0;
		_ = 0;
		_isCullable = true;
		_isDespawning = false;
		_ = 3238002688L;
		_ = 1;
		_ = 3238002688L;
		_ = 1;
		Vector3 vector2;
		if (body != null)
		{
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
			BaseBody baseBody2 = baseBody.setCircle(8f, (float?)(object)num, (float?)(object)0);
			int num2 = (int)_cachedTransform;
			nint num3 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rax_v38 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num4 = 0;
			_ = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v39 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v15 (System.Int32)+10]");
			bool flag = (nint)0 == 0;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v15 (System.Int32)+10]");
			Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj3);
			nint num5 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rax_v47 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num6 = 0;
			if ((object)_weapon != null)
			{
				float num7 = _weapon.PArea();
				float num8 = (float)Vector3.zeroVector * 0.3f;
				float num9 = num8 + 1f;
				_ = Vector3.oneVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rbx_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
				float num10 = 0f * num9;
				Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, endValue, 0.5f);
				TweenCallback tweenCallback = delegate
				{
					_pfx.Play(withChildren: true);
				};
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v50 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
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
					_scaleTween = tweenerCore;
					if ((object)_weapon != null)
					{
						float num11 = _weapon.PAmount();
						int num12 = (int)_cachedTransform;
						float num13 = (float)Math.PI * 2f / num9;
						float deltaTime = num13 * (float)_indexInWeapon;
						_deltaTime = deltaTime;
						if ((object)_cachedTransform != null)
						{
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rbx_v19 (System.Int32)+10]");
							bool flag2 = (nint)0 == 0;
							object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rbx_v19 (System.Int32)+10]");
							Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj4);
							int num14 = (int)_cachedTransform;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
							_centralPos = (Vector3)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
							_ = 0;
							bool flag3 = (object)_cachedTransform == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rbx_v20 (System.Int32)+10]");
							bool flag4 = (nint)0 == 0;
							object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rbx_v20 (System.Int32)+10]");
							Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj5);
							GameManager core = GM.Core;
							bool flag5 = (object)GM.Core == null;
							int num15 = (int)_cachedTransform;
							bool flag6 = (object)_cachedTransform == null;
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rbx_v21 (System.Int32)+10]");
							bool flag7 = (nint)0 == 0;
							object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rbx_v21 (System.Int32)+10]");
							Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj6);
							if ((object)core._stage != null)
							{
								Vector3 queryPos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
								_ = 0;
								EnemyController enemyController = core._stage.FindClosestEnemy(queryPos, excludeDead: true);
								Vector3 vector = default(Vector3);
								if ((object)enemyController != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1581 @ rax_v78 (VampireSurvivors.Objects.Characters.EnemyController)+10]");
									if ((nint)0 != 0)
									{
										Transform transform = enemyController.transform;
										if ((object)transform == null)
										{
											goto IL_060b;
										}
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v114 (UnityEngine.Transform)+10]");
										bool flag8 = (nint)0 == 0;
										object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v114 (UnityEngine.Transform)+10]");
										Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj7);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
										nint num16 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_FireArmProjectile)+F4]");
										object obj8 = num16 - 0;
										_ = _centralPos;
										object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C6C6E0");
										if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
										{
											object obj10 = obj8 / (object)vector;
											vector2 = vector;
											object obj11 = obj10;
										}
										else
										{
											nint num17 = (nint)typeof(Vector3);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1899 @ rax_v124 (Il2CppClass<UnityEngine.Vector3>)+B8]");
											nint num18 = 0;
											vector2 = Vector3.zeroVector;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1900 @ rcx_v93 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
											object obj11 = 0;
										}
										_movement = vector2;
										goto IL_0919;
									}
								}
								if ((object)weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
								{
									_movement = vector;
									_ = 0;
									vector2 = vector;
									goto IL_0919;
								}
							}
						}
					}
				}
			}
		}
		goto IL_060b;
		IL_060b:
		throw new NullReferenceException();
		IL_0919:
		if (_indexInWeapon != 0)
		{
			return;
		}
		if ((object)_coronaSprite != null)
		{
			PhaserSprite phaserSprite = _coronaSprite.setAlpha(0f);
			if ((object)_coronaSprite != null)
			{
				PhaserSprite phaserSprite2 = _coronaSprite.setVisible(visible: true);
				if (_coronaTween != null)
				{
					_coronaTween.Kill();
				}
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				if (array != null)
				{
					if ((object)_coronaSprite != null)
					{
						object obj12 = array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj13 = default(object);
						bool flag9 = obj13 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null && (object)_weapon != null)
					{
						float num19 = _weapon.PArea();
						object obj14 = vector2 / coronaRatio;
						_ = 0;
						_ = 1;
						_ = 1128792064;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
						_ = 0;
						_ = 1051931443;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
						_ = 0;
						MultiTargetTween coronaTween = Tweens.Add(tweenConfig);
						_coronaTween = coronaTween;
						return;
					}
				}
			}
		}
		goto IL_060b;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0163: Expected I, but got O
		//IL_0179: Invalid comparison between F4 and O
		//IL_028a->IL01d3: Incompatible stack heights: 2 vs 0
		if ((object)_weapon != null)
		{
			float num = _weapon.PSpeed();
			float deltaTime = PauseSystem.DeltaTime;
			object obj = default(object);
			float num2 = (float)obj * 35f;
			float num3 = deltaTime * num2;
			float num4 = num3 * 0.0625f;
			float deltaTime2 = num4 + _deltaTime;
			_deltaTime = deltaTime2;
			float deltaTime3 = PauseSystem.DeltaTime;
			if ((object)_weapon != null)
			{
				float num5 = _weapon.PSpeed();
				float num6 = deltaTime3 * deltaTime3;
				float num7 = (float)_movement * num6;
				object obj2 = default(object);
				float num8 = (float)obj2 * num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_FireArmProjectile)+100]");
				float num9 = 0f * num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_FireArmProjectile)+F4]");
				float num10 = 0f + num9;
				Weapon weapon = _weapon;
				float2 float5 = default(float2);
				_centralPos = (Vector3)float5;
				nint num11 = (nint)weapon;
				float num12 = weapon.PArea();
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)4.5f) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5))
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				Transform transform = _pfx.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rax_v24 (UnityEngine.Transform)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rax_v24 (UnityEngine.Transform)+10]");
				float2 value = default(float2);
				Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
				object cachedTransform = _cachedTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v9 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdi_v9 (System.Object)+10]");
				float2 value2 = default(float2);
				Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value2));
				if ((object)_coronaSprite != null)
				{
					PhaserSprite phaserSprite = _coronaSprite.setPosition(float5);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void StartDespawn()
	{
		//IL_00ae: Expected I, but got O
		//IL_0112: Expected O, but got I4
		//IL_0120: Expected O, but got I4
		//IL_013b: Expected I, but got O
		if (_isDespawning)
		{
			return;
		}
		if (_indexInWeapon != 0)
		{
			Despawn();
			return;
		}
		_isDespawning = true;
		if (_coronaTween != null)
		{
			_coronaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_coronaSprite != null)
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_FireArmProjectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween coronaTween = Tweens.Add(tweenConfig);
		_coronaTween = coronaTween;
	}

	public override void Despawn()
	{
		Tween scaleTween = _scaleTween;
		if (_scaleTween != null && scaleTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		Tween radiusTweenX = _radiusTweenX;
		if (_radiusTweenX != null && radiusTweenX._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_radiusTweenX);
		}
		_pfx.Stop();
		base.Despawn();
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00d2: Expected O, but got Ref
		//IL_00e7: Expected native int or pointer, but got O
		//IL_026f: Expected O, but got I
		//IL_011f: Expected O, but got Ref
		//IL_0146: Expected O, but got I
		//IL_015b: Expected native int or pointer, but got O
		//IL_0175: Expected O, but got I
		//IL_0195: Expected O, but got Ref
		//IL_01af: Expected native int or pointer, but got O
		//IL_02a9: Expected O, but got I
		//IL_020e: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"flame000");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(50f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0.7f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+27]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+37]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1F]");
		_ = 0;
		_ = 0;
		particleSystemConfig._on = true;
		_ = 1128792064;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._frequency = (float?)(object)0;
		ParticleSystem pfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform);
		_pfx = pfx;
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			StartDespawn();
		}
		Weapon weapon = _weapon;
		GameManager gameMan = weapon._gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				Weapon weapon2 = _weapon;
				GameManager gameMan2 = weapon2._gameMan;
				float2 float5 = base.position;
				Vector2 pos = default(Vector2);
				gameMan2._arcanaManager.TriggerFireExplosion(pos);
			}
		}
	}

	private void _003CInitProjectile_003Eb__15_0()
	{
		_pfx.Play(withChildren: true);
	}
}
