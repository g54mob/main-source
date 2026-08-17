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
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Mace1_Projectile : Projectile
{
	private TrailRenderer _afterImageTrail;

	private float _angleTime;

	private Timer _swingTimer;

	private MultiTargetTween _alphaTween;

	private float _multiplier;

	private List<List<Projectile>> _swipeBodies;

	private float2 _playerOffset;

	private int _flipNum;

	private float _extraDistTotal;

	private float _extraDistSpacing;

	private bool _isMoving;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_Mace_Projectile", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		_afterImageTrail.emitting = false;
		Material material = ((Renderer)_afterImageTrail).GetMaterial();
		RenderingExtensions.SetAlpha(material, 0f);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_00a2: Expected O, but got I4
		//IL_00e2: Expected I4, but got I8
		//IL_070c: Expected I, but got O
		//IL_0714: Expected I, but got O
		//IL_0724: Expected O, but got I
		//IL_010e: Expected O, but got I
		//IL_014b: Expected O, but got I
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01ba: Invalid comparison between I4 and F4
		//IL_048d: Expected O, but got I4
		//IL_04d2: Expected O, but got I4
		//IL_0226: Invalid comparison between F4 and I4
		//IL_0240: Expected O, but got I4
		//IL_026e: Expected I, but got O
		//IL_0277: Expected O, but got I4
		//IL_086b: Expected I, but got O
		//IL_087b: Expected O, but got I
		//IL_028c: Expected O, but got I
		//IL_02c3: Expected O, but got I
		//IL_02d8: Expected O, but got I
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Expected O, but got Unknown
		//IL_0459: Invalid comparison between F4 and O
		//IL_0467: Expected F4, but got O
		//IL_046f: Expected F4, but got O
		//IL_035f: Expected O, but got I
		//IL_036f: Expected O, but got I
		//IL_0823: Expected O, but got F4
		//IL_0851: Expected O, but got I4
		//IL_03a6: Expected O, but got I
		//IL_03bb: Expected O, but got I
		//IL_07bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c2: Expected O, but got Unknown
		//IL_06aa: Expected F4, but got I4
		//IL_07d4: Expected I4, but got O
		//IL_07e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e7: Expected O, but got Unknown
		//IL_0428: Expected F4, but got O
		//IL_0430: Expected I4, but got F4
		//IL_043e: Expected I, but got O
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body.setCircle(0f, (float?)(object)0, (float?)(object)0);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		Weapon weapon2 = _weapon;
		ArcadeSprite arcadeSprite = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		((ArcadeSprite)((Equipment)weapon2)._003COwner_003Ek__BackingField).CheckRenderer();
		Vector2 vector = arcadeSprite._spriteRenderer.size;
		object obj = default(object);
		float num = (float)obj * 0.5f;
		_playerOffset = (float2)0;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		bool flag = characterController._isFlipped;
		int flipNum = -1;
		if (!flag)
		{
			flipNum = 1;
		}
		_flipNum = flipNum;
		float num2 = weapon.PArea();
		float num3 = (_extraDistTotal = num * 0.39999998f);
		nint num4 = (nint)typeof(TP_Mace1_Weapon);
		nint num5 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace1_Weapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace1_Weapon>)+130]");
		float num9;
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v18+FFFFFFF8+v209 @ rax_v17*8]");
			if (0 == (nint)typeof(TP_Mace1_Weapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace1_Weapon>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v18+FFFFFFF8+v690 @ rcx_v13*8]");
				object obj5 = 0 - typeof(TP_Mace1_Weapon);
				bool flag2 = obj5 == null;
				bool flag3 = !flag2;
				Weapon weapon3 = null;
				if (!flag3)
				{
					weapon3 = weapon;
				}
				List<List<Projectile>> swipeBodies = _swipeBodies;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v714 @ rcx_v15 (VampireSurvivors.Objects.Weapons.Weapon)+168]");
				float num7 = 0f + 1f;
				float extraDistSpacing = num3 / num7;
				_extraDistSpacing = extraDistSpacing;
				float num8 = weapon.PAmount();
				bool flag4 = (float)swipeBodies._size == num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187136C17h\"");
				num9 = num7;
				if (!flag4)
				{
					float num10 = weapon.PAmount();
					List<List<Projectile>> swipeBodies2 = _swipeBodies;
					int num11 = swipeBodies2._size;
					float num12 = num7 - (float)swipeBodies2._size;
					bool flag5 = !(num12 > 0f);
					num9 = num7;
					float? num13 = (float?)(object)0;
					float num14 = num7;
					if (!flag5)
					{
						float2 float5 = default(float2);
						while (true)
						{
							List<Projectile> list = new List<Projectile>();
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AABF00");
							nint num15 = (nint)typeof(TP_Mace1_Weapon);
							float? num16 = (float?)(object)0;
							while (true)
							{
								num5 = (nint)weapon;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace1_Weapon>)+130]");
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
								nint num17 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace1_Weapon>)+130]");
								if (num17 < 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
								object obj7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v74+FFFFFFF8+v197 @ rax_v73*8]");
								if (0 != num15)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace1_Weapon>)+130]");
								object obj8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v74+FFFFFFF8+v874 @ rcx_v56*8]");
								object obj9 = -num15;
								bool flag6 = obj9 == null;
								bool flag7 = !flag6;
								Weapon weapon4 = null;
								if (!flag7)
								{
									weapon4 = weapon;
								}
								float? num18 = num16;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v747 @ rcx_v58 (VampireSurvivors.Objects.Weapons.Weapon)+168]");
								if ((nint)num18 <= 0)
								{
									if ((object)num13 == null || (object)num16 == null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace1_Weapon>)+130]");
										object obj10 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r8_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
										object obj11 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rax_v77+FFFFFFF8+v219 @ rcx_v60*8]");
										if (0 != num15)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rdx_v42 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Mace1_Weapon>)+130]");
										object obj12 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rax_v77+FFFFFFF8+v953 @ rcx_v61*8]");
										object obj13 = -num15;
										bool flag8 = obj13 == null;
										bool flag9 = !flag8;
										TP_Mace1_Weapon tP_Mace1_Weapon = null;
										if (!flag9)
										{
											tP_Mace1_Weapon = (TP_Mace1_Weapon)weapon;
										}
										Projectile projectile = tP_Mace1_Weapon.CreateLingerProjectile((int)num16);
										object obj14 = index * _extraDistSpacing;
										float num19 = _extraDistTotal - (float)obj14;
										projectile.position = float5;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6A10");
										num14 = (float)float5;
										num11 = (int)num19;
										num15 = (nint)typeof(TP_Mace1_Weapon);
									}
									num16 = (float?)(object)((_003F?)num16 + 1);
									continue;
								}
								goto IL_0443;
							}
							break;
							IL_0443:
							num13 = (float?)(object)((_003F?)num13 + 1);
							bool flag10 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num12) > System.Runtime.CompilerServices.Unsafe.As<float?, UIntPtr>(ref num13);
							num9 = (float)num13;
							num14 = (float)num13;
							if (flag10)
							{
								continue;
							}
							goto IL_047d;
						}
						goto IL_06af;
					}
				}
				goto IL_047d;
			}
		}
		goto IL_06af;
		IL_047d:
		ArcadeSprite arcadeSprite2 = setOrigin(0.5f, (float?)(object)1);
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		ArcadeSprite arcadeSprite3 = setFlipX(characterController2._isFlipped);
		float num20 = weapon.PArea();
		ArcadeSprite arcadeSprite4 = setScale(num9, (float?)(object)0);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			int num21 = renderer.pixelHeight - 1;
			ArcadeSprite arcadeSprite5 = setDepth(num21);
			_multiplier = 0f;
			updateAttackAngle(_angleTime = (float)_flipNum * ((float)Math.PI / 2f));
			SetupTrails(_afterImageTrail);
			_afterImageTrail.emitting = true;
			Material material = ((Renderer)_afterImageTrail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 1f);
			if (_swingTimer != null)
			{
				_swingTimer.Cancel();
			}
			float num22 = _weapon.PDuration();
			Action onComplete = LandHit;
			float num23 = num9 * 0.001f;
			bool flag11 = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer swingTimer = Timers.Register(num23, onComplete, null, isLooped: false, flag11, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_swingTimer = swingTimer;
			ArcadeSprite arcadeSprite6 = setAlpha(1f);
			_isMoving = true;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 0.5f;
			object obj15 = UnityEngine.Random.value;
			float num24 = num23 - 0.5f;
			float detune = num24 * 300f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Macir, soundConfig, 0f, 10, flag11 ? 1 : 0);
			return;
		}
		goto IL_06af;
		IL_06af:
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		if (_isMoving)
		{
			float num = _weapon.PSpeed();
			object obj = default(object);
			float num2 = (float)obj + _multiplier;
			bool flag = !(5f > num2);
			float multiplier = 5f;
			if (!flag)
			{
				multiplier = num2;
			}
			_multiplier = multiplier;
			float deltaTime = PauseSystem.DeltaTime;
			float num3 = _weapon.PSpeed();
			float num4 = deltaTime * deltaTime;
			float num5 = num4 * _multiplier;
			updateAttackAngle(_angleTime = num5 + _angleTime);
		}
	}

	private unsafe void updateAttackAngle(float attackAngle)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0040: Expected O, but got F4
		//IL_0073: Expected O, but got I4
		//IL_007b: Expected O, but got F4
		//IL_0084: Expected O, but got I4
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected O, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_01df: Expected O, but got F4
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_023a->IL0320: Incompatible stack heights: 5 vs 2
		//IL_01fa->IL0305: Incompatible stack heights: 7 vs 2
		float num = attackAngle * -57.29578f;
		Transform cachedTransform = _cachedTransform;
		float num2 = num * (float)_flipNum;
		float num3 = num2 + 90f;
		float num4 = num3 * ((float)Math.PI / 180f);
		float euler = default(float);
		Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&euler), out Quaternion _);
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Mace1_Projectile)+104]");
		object obj2 = default(object);
		object obj = obj2 + 0;
		float num5 = default(float);
		base.position = (float2)num5;
		List<List<Projectile>> swipeBodies = _swipeBodies;
		bool flag2 = _swipeBodies == null;
		object obj3 = 0;
		float2 float6 = (float2)num5;
		object obj4 = 0;
		object obj6 = default(object);
		object obj9 = default(object);
		ArcadeSprite arcadeSprite = default(ArcadeSprite);
		while ((nint)obj4 < swipeBodies._size)
		{
			object obj5 = null;
			while (true)
			{
				bool flag3 = _swipeBodies == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				bool flag4 = obj6 == null;
				object obj7 = obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ rax_v17+18]");
				if ((nint)obj7 >= 0)
				{
					break;
				}
				float num6 = (float)obj3 * -0.17453292f;
				float num7 = (float)_flipNum * ((float)Math.PI / 2f);
				float num8 = num6 + attackAngle;
				if (!(num7 > num8))
				{
					num7 = num8;
				}
				object obj8 = obj5 * _extraDistSpacing;
				float num9 = _extraDistTotal - (float)obj8;
				bool flag5 = _swipeBodies == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				bool flag6 = obj9 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				float2 float7 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num10 = num7 * num9;
				float6 = (float2)(num10 * _flipNum);
				obj = obj2 + (object)float6;
				bool flag7 = (object)arcadeSprite == null;
				arcadeSprite.position = (float2)num5;
				obj5++;
				num4 = num5;
			}
			swipeBodies = _swipeBodies;
			obj3++;
			bool flag8 = _swipeBodies == null;
			obj4 = obj3;
		}
	}

	private void LandHit()
	{
		//IL_005e: Expected I, but got O
		//IL_00c8: Expected I, but got O
		//IL_013a: Expected O, but got I4
		bool flag = _alphaTween == null;
		_isMoving = false;
		if (!flag)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_renderer != null)
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
		Material material = ((Renderer)_afterImageTrail).GetMaterial();
		if ((object)material != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 100f;
		tweenConfig.delay = 250f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	public override void Despawn()
	{
		//IL_0057: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		if (_swingTimer != null)
		{
			_swingTimer.Cancel();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		List<List<Projectile>> swipeBodies = _swipeBodies;
		object obj = 0;
		object obj2 = 0;
		object obj6 = default(object);
		while ((nint)obj2 < swipeBodies._size)
		{
			object obj3 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				swipeBodies = _swipeBodies;
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v12+18]");
				if ((nint)obj4 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				object obj5 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v93 @ r8_v4+368] (should have been resolved before IL gen)");
				obj3++;
			}
			obj++;
			obj2 = obj;
		}
		List<List<Projectile>> swipeBodies2 = _swipeBodies;
		int version = swipeBodies2._version + 1;
		swipeBodies2._version = version;
		swipeBodies2._size = 0;
		if (swipeBodies2._size > 0)
		{
			Array.Clear(swipeBodies2._items, 0, swipeBodies2._size);
		}
		_afterImageTrail.Clear();
		_afterImageTrail.emitting = false;
		base.Despawn();
	}

	private void SetupTrails(TrailRenderer _trail)
	{
		//IL_0128: Expected I4, but got F4
		//IL_0189->IL020d: Incompatible stack heights: 4 vs 0
		if ((object)_weapon != null)
		{
			float num = _weapon.PAmount();
			object obj = default(object);
			float time = (float)obj * 0.5f;
			float saturationMax = default(float);
			float valueMin = default(float);
			float valueMax = default(float);
			float alphaMin = default(float);
			Color color = UnityEngine.Random.ColorHSV(0f, 1f, 0.35f, saturationMax, valueMin, valueMax, alphaMin, 0.35f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			Weapon weapon = _weapon;
			float num2 = weapon.PArea();
			float num3 = 0.8f * 0.13f;
			Transform transform = _trail.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			_trail.time = time;
			_trail.endWidth = num3;
			_trail.startWidth = num3;
			Sprite sprite = default(Sprite);
			RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_trail, sprite, true);
			Material material = ((Renderer)_trail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 0f);
			bool flag2 = ((UnityEngine.Object)_trail).m_CachedPtr == (IntPtr)0;
			TrailRenderer.Clear_Injected(((UnityEngine.Object)_trail).m_CachedPtr);
			Gradient gradient = new Gradient();
			IntPtr ptr = Gradient.Init();
			gradient.m_Ptr = ptr;
			gradient.m_RequiresNativeCleanup = true;
			GradientColorKey[] array = new GradientColorKey[2];
			bool flag3 = (nint)((MonoBehaviour)(object)array).m_CancellationTokenSource <= 0;
			((GameMonoBehaviour)(object)array)._onPauseSent = (byte)(int)color.r != 0;
			((PhaserGameObject)(object)array)._scene = null;
			bool flag4 = (nint)((MonoBehaviour)(object)array).m_CancellationTokenSource <= 1;
			_ = color.r;
			_ = 0.25f;
			GradientAlphaKey[] array2 = new GradientAlphaKey[2];
			if (array2 != null)
			{
				bool flag5 = array2.Length <= 0;
				_ = 1048576000;
				bool flag6 = array2.Length <= 1;
				_ = 0;
				_ = 1056964608;
				gradient.SetKeys(array, array2);
				_trail.colorGradient = gradient;
				TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_trail);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public TP_Mace1_Projectile()
	{
		List<List<Projectile>> swipeBodies = new List<List<Projectile>>();
		_swipeBodies = swipeBodies;
		base._002Ector();
	}

	private void _003CLandHit_003Eb__15_0()
	{
		Despawn();
	}
}
