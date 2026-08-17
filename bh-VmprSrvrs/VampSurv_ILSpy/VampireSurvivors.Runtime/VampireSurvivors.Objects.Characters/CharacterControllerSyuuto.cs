using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerSyuuto : CharacterController
{
	private bool _hasSecondAnim;

	private float _armorBonus;

	private float _areaBonus;

	private float _speedBonus;

	private float _moveSpeedBonus;

	private float _maxHpBonus;

	private SpriteRenderer _sparkSprite;

	private SpriteRenderer _ringSprite;

	private MultiTargetTween _ringTween;

	private MultiTargetTween _sparkTween;

	private SpriteRenderer _burstSprite;

	private SpriteRenderer _darkSprite;

	private MultiTargetTween _darkTween;

	private SpriteAnimation _burstAnim;

	private bool _isMorphed;

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		_isMorphed = false;
		_hasSecondAnim = false;
		_armorBonus = 2f;
		_areaBonus = 0.3f;
		_speedBonus = 0.3f;
		_moveSpeedBonus = 0.4f;
		_maxHpBonus = 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 19 Invalid \"Jump target not found in method: 0x1875C23F0\"");
	}

	private unsafe void MakeMorphVFX()
	{
		//IL_0155: Expected F4, but got I4
		//IL_02ab: Expected F4, but got I4
		//IL_04d7: Expected I4, but got O
		//IL_0534: Expected O, but got I4
		//IL_03f9: Expected O, but got I
		//IL_0486: Expected I4, but got O
		//IL_04b5: Expected F4, but got I4
		//IL_0647: Expected O, but got I4
		//IL_0647: Expected O, but got Ref
		//IL_0647: Expected O, but got Ref
		//IL_0647: Expected O, but got Ref
		//IL_0a37: Expected F4, but got I4
		//IL_0a3f: Expected F4, but got O
		//IL_07d0->IL07ff: Incompatible stack heights: 1 vs 0
		//IL_0a44->IL099f: Incompatible stack heights: 2 vs 0
		SpriteRenderer sparkSprite = _sparkSprite;
		if ((object)_sparkSprite != null && ((UnityEngine.Object)sparkSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_015b;
		}
		float2 float5 = base.cachedPosition;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, vector, "vfx", "blurredSharpStar");
		SpriteRenderer component = RenderingExtensions.SetAlpha(spriteRenderer, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(component, 0f);
		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
		if ((object)spriteRenderer2 != null)
		{
			((Renderer)spriteRenderer2).SetMaterial(material);
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					float num = renderer.height * 100f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
					int sortingOrder = default(int);
					spriteRenderer2.sortingOrder = sortingOrder;
					_sparkSprite = spriteRenderer2;
					float num2 = 0f;
					goto IL_015b;
				}
			}
		}
		goto IL_07ff;
		IL_02b1:
		SpriteRenderer darkSprite = _darkSprite;
		if ((object)_darkSprite != null && ((UnityEngine.Object)darkSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_04bb;
		}
		float2 float6 = base.cachedPosition;
		GameObject gameObject2 = base.gameObject;
		string text = default(string);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.AddSprite(gameObject2, vector, vector, "vfx", text);
		SpriteRenderer component2 = RenderingExtensions.SetAlpha(spriteRenderer3, 0f);
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null)
		{
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			if (s_scene2._renderer != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer3 = s_scene3._renderer;
					if (s_scene3._renderer != null)
					{
						float xScale = renderer2.width * 100f;
						float yScale = renderer3.height * 100f;
						SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(component2, xScale, yScale);
						SpriteRenderer s_scene4 = (SpriteRenderer)(object)ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v831 @ rcx_v105 (UnityEngine.SpriteRenderer)+28]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v831 @ rcx_v105 (UnityEngine.SpriteRenderer)+28]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1057 @ rax_v120+14]");
								float num3 = 0f - 2f;
								float num = num3 * 100f;
								SpriteRenderer spriteRenderer5 = RenderingExtensions.SetScale((SpriteRenderer)(object)ArcadePhysics.s_scene, xScale, yScale);
								if ((object)spriteRenderer4 != null)
								{
									spriteRenderer4.sortingOrder = (int)spriteRenderer5;
									SpriteRenderer darkSprite2 = RenderingExtensions.SetScrollFactor(spriteRenderer4, 0f);
									_darkSprite = darkSprite2;
									float num2 = 0f;
									goto IL_04bb;
								}
							}
						}
					}
				}
			}
		}
		goto IL_07ff;
		IL_015b:
		SpriteRenderer ringSprite = _ringSprite;
		if ((object)_ringSprite != null && ((UnityEngine.Object)ringSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_02b1;
		}
		float2 float7 = base.cachedPosition;
		GameObject gameObject3 = base.gameObject;
		SpriteRenderer spriteRenderer6 = RenderingExtensions.AddSprite(gameObject3, vector, "vfx", "disc");
		SpriteRenderer component3 = RenderingExtensions.SetAlpha(spriteRenderer6, 0f);
		SpriteRenderer spriteRenderer7 = RenderingExtensions.SetScale(component3, 0f);
		Material material2 = MaterialManager.GetMaterial(MaterialType.Vfx);
		if ((object)spriteRenderer7 != null)
		{
			((Renderer)spriteRenderer7).SetMaterial(material2);
			PhaserScene s_scene5 = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer4 = s_scene5._renderer;
				if (s_scene5._renderer != null)
				{
					float num = renderer4.height * 100f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
					int sortingOrder2 = default(int);
					spriteRenderer7.sortingOrder = sortingOrder2;
					_ringSprite = spriteRenderer7;
					float num2 = 0f;
					goto IL_02b1;
				}
			}
		}
		goto IL_07ff;
		IL_07ff:
		throw new NullReferenceException();
		IL_06b9:
		bool flag;
		List<Sprite> animation = SpriteManager.GetAnimation("Burst", 1, 6, "vfx", flag);
		bool flag3 = default(bool);
		if ((object)_burstSprite != null)
		{
			GameObject gameObject4 = _burstSprite.gameObject;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ rdi_v15 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			bool flag2 = (object)gameObject4 == null;
			SpriteAnimation burstAnim = ((!gameObject4.TryGetComponent<SpriteAnimation>(out var component4)) ? gameObject4.AddComponent<SpriteAnimation>() : component4);
			_burstAnim = burstAnim;
			if ((object)_burstAnim != null)
			{
				Action onComplete = default(Action);
				bool autoSetAnimation = default(bool);
				_burstAnim.AddAnimation("enter", animation, 30, flag, flag3, onComplete, autoSetAnimation);
				return;
			}
		}
		goto IL_07ff;
		IL_04bb:
		SpriteRenderer burstSprite = _burstSprite;
		flag = (byte)(int)text != 0;
		if ((object)_burstSprite == null || ((UnityEngine.Object)burstSprite).m_CachedPtr == (IntPtr)0)
		{
			float2 float8 = base.cachedPosition;
			GameObject gameObject5 = base.gameObject;
			SpriteRenderer spriteRenderer8 = RenderingExtensions.AddSprite(gameObject5, vector, vector, "vfx", (string)flag);
			SpriteRenderer component5 = RenderingExtensions.SetAlpha(spriteRenderer8, 0f);
			SpriteRenderer spriteRenderer9 = RenderingExtensions.SetScale(component5, 10f);
			Material material3 = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
			if ((object)spriteRenderer9 != null)
			{
				((Renderer)spriteRenderer9).SetMaterial(material3);
				PhaserScene s_scene6 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer5 = s_scene6._renderer;
					if (s_scene6._renderer != null)
					{
						float num5 = renderer5.height - 1f;
						float num6 = num5 * 100f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
						int sortingOrder3 = default(int);
						spriteRenderer9.sortingOrder = sortingOrder3;
						SpriteRenderer spriteRenderer10 = RenderingExtensions.SetScrollFactor(spriteRenderer9, 0f);
						object obj2 = default(object);
						object obj3 = default(object);
						float ret = default(float);
						SpriteRenderer burstSprite2 = RenderingExtensions.SetTint(spriteRenderer10, (Color)(&obj2), (Color)(&obj3), (Color)(&ret), (Color)flag, flag3 ? BlendMode.Add : BlendMode.Normal);
						_burstSprite = burstSprite2;
						if ((object)_burstSprite != null)
						{
							Transform transform = _burstSprite.transform;
							if ((object)transform != null)
							{
								bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
								flag = flag;
								bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								float value = default(float);
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
								float num2 = 0f;
								float num = (float)vector;
								goto IL_06b9;
							}
						}
					}
				}
			}
			goto IL_07ff;
		}
		goto IL_06b9;
	}

	public override void AfterFullInitialization()
	{
		//IL_0062: Expected I, but got O
		//IL_006a: Expected I, but got O
		//IL_007a: Expected O, but got I
		//IL_00b6: Expected O, but got I
		//IL_00f3: Expected O, but got I
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0175: Expected I, but got O
		//IL_017d: Expected I, but got O
		//IL_018d: Expected O, but got I
		//IL_01c9: Expected O, but got I
		//IL_0206: Expected O, but got I
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		base.AfterFullInitialization();
		Weapon weaponByType = base._weaponsManager.GetWeaponByType(WeaponType.NIGHTSWORD, searchHidden: true);
		if ((object)weaponByType == null || ((UnityEngine.Object)weaponByType).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		nint num = (nint)typeof(NightSwordWeapon);
		nint num2 = (nint)weaponByType;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.NightSwordWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.NightSwordWeapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v13+FFFFFFF8+v71 @ rax_v12*8]");
			if (0 == (nint)typeof(NightSwordWeapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.NightSwordWeapon>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v13+FFFFFFF8+v287 @ rcx_v12*8]");
				object obj4 = 0 - typeof(NightSwordWeapon);
				bool flag = obj4 == null;
				bool flag2 = !flag;
				Weapon weapon = null;
				if (!flag2)
				{
					weapon = weaponByType;
				}
				if (weapon._firingTimer != null)
				{
					weapon._firingTimer.Cancel();
				}
				_ = 1148846080;
				_ = 1;
				nint num4 = (nint)typeof(NightSwordWeapon);
				nint num5 = (nint)weaponByType;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.NightSwordWeapon>)+130]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.NightSwordWeapon>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v17+FFFFFFF8+v73 @ rax_v16*8]");
					if (0 == (nint)typeof(NightSwordWeapon))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.NightSwordWeapon>)+130]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v17+FFFFFFF8+v264 @ rcx_v15*8]");
						object obj8 = 0 - typeof(NightSwordWeapon);
						bool flag3 = obj8 == null;
						bool flag4 = !flag3;
						Weapon weapon2 = null;
						if (!flag4)
						{
							weapon2 = weaponByType;
						}
						weapon2._skipAddingEvolution = true;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void LevelUp()
	{
		base.LevelUp();
		float num = (float)base._level / 10f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		Weapon weaponByType = base._weaponsManager.GetWeaponByType(WeaponType.NIGHTSWORD, searchHidden: true);
		object obj = default(object);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0 && ((Equipment)weaponByType)._003CLevel_003Ek__BackingField < (nint)obj && ((Equipment)weaponByType)._003CLevel_003Ek__BackingField < 8)
		{
			bool flag = weaponByType.LevelUp();
		}
	}

	public override void OnWeaponMadeLevelOne(WeaponType type)
	{
		if (type == WeaponType.SUMMONNIGHT2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 13 Invalid \"Jump target not found in method: 0x1875C3640\"");
		}
	}

	private void Morph()
	{
		//IL_002a: Expected O, but got I4
		//IL_006b: Expected O, but got I4
		//IL_0176: Expected O, but got I
		//IL_018b: Expected O, but got I
		//IL_01ab: Expected O, but got I
		//IL_01ec: Expected O, but got F4
		//IL_0233: Expected O, but got I4
		//IL_0225: Expected O, but got I
		//IL_0246: Expected I4, but got O
		//IL_026e: Expected O, but got I4
		//IL_026e: Expected I4, but got F4
		if (_isMorphed)
		{
			return;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.5f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Bangu, soundConfig2, 2000f, 1, num);
		_isMorphed = true;
		PlaySparkle();
		ModifierStats onEveryLevelUp = base._onEveryLevelUp;
		float num2 = onEveryLevelUp._003CPower_003Ek__BackingField + 0.01f;
		onEveryLevelUp._003CPower_003Ek__BackingField = num2;
		if (!_hasSecondAnim)
		{
			GameManager core = GM.Core;
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
			object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)72);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ rax_v75 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ rax_v75 (System.Object)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ rbx_v19+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rbx_v20+48]");
				string animName = ((string)0).Replace("01.png", "");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rbx_v20+68]");
				int end = (int)(-1);
				Vector2 pivot = default(Vector2);
				int num3 = default(int);
				bool flag = default(bool);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, end, pivot, (string)num, num3, flag);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rbx_v20+80]");
				object obj4;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rbx_v20+80]");
					obj4 = 0;
				}
				else
				{
					obj4 = 1;
				}
				if (obj4 != null)
				{
					int fps = obj4 >> 32;
					bool autoSetAnimation = default(bool);
					_spriteAnimation.AddAnimation("walk2", animationFrames, fps, (byte)(int)num != 0, (byte)num3 != 0, (Action)flag, autoSetAnimation);
					_hasSecondAnim = true;
					goto IL_027e;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return;
		}
		goto IL_027e;
		IL_027e:
		_spriteAnimation.SetAnimation("walk2");
		base._003CCurrentWalkAnimName_003Ek__BackingField = "walk2";
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + _armorBonus;
		playerStats._003CArmor_003Ek__BackingField = eggFloat2;
		PlayerModifierStats playerStats2 = _playerStats;
		EggFloat eggFloat3 = playerStats2._003CArea_003Ek__BackingField;
		float value2 = default(float);
		EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
		value2 = eggFloat3._val + _areaBonus;
		playerStats2._003CArea_003Ek__BackingField = eggFloat4;
		PlayerModifierStats playerStats3 = _playerStats;
		EggFloat eggFloat5 = playerStats3._003CSpeed_003Ek__BackingField;
		float value3 = default(float);
		EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
		value3 = eggFloat5._val + _speedBonus;
		playerStats3._003CSpeed_003Ek__BackingField = eggFloat6;
		PlayerModifierStats playerStats4 = _playerStats;
		EggFloat eggFloat7 = playerStats4._003CMoveSpeed_003Ek__BackingField;
		float value4 = default(float);
		EggFloat eggFloat8 = new EggFloat(value4, eggFloat7._eggVal);
		value4 = eggFloat7._val + _moveSpeedBonus;
		playerStats4._003CMoveSpeed_003Ek__BackingField = eggFloat8;
		PlayerModifierStats playerStats5 = _playerStats;
		EggFloat eggFloat9 = playerStats5._003CMaxHp_003Ek__BackingField;
		float value5 = default(float);
		EggFloat eggFloat10 = new EggFloat(value5, eggFloat9._eggVal);
		value5 = eggFloat9._val + _maxHpBonus;
		playerStats5._003CMaxHp_003Ek__BackingField = eggFloat10;
		base.IsInvul = true;
		float invincibilityTimer = base._invincibilityTimer + 0.1f;
		base._invincibilityTimer = invincibilityTimer;
	}

	private unsafe void PlaySparkle()
	{
		//IL_00b8: Expected I, but got O
		//IL_0110: Expected I, but got O
		//IL_0174: Expected O, but got I4
		//IL_0182: Expected O, but got I4
		//IL_0190: Expected O, but got I4
		//IL_0251: Expected I, but got O
		//IL_02c3: Expected O, but got I4
		//IL_0396: Expected I, but got O
		//IL_03ee: Expected I, but got O
		//IL_0444: Expected O, but got I4
		//IL_0452: Expected O, but got I4
		//IL_0460: Expected O, but got I4
		//IL_047c: Expected O, but got I4
		_burstAnim.SetAnimation("enter");
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_burstSprite, 1f);
		if (_ringTween != null)
		{
			_ringTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		Transform transform = _ringSprite.transform;
		if ((object)transform != null)
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
		if ((object)_ringSprite != null)
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
		tweenConfig.duration = 200f;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.scaleY = (float?)(object)1;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_ringSprite, 0f);
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_ringSprite, 1f);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween ringTween = Tweens.Add(tweenConfig);
		_ringTween = ringTween;
		if (_darkTween != null)
		{
			_darkTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_darkSprite != null)
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
		tweenConfig2.duration = 100f;
		tweenConfig2.yoyo = true;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_darkSprite, 0f);
		};
		tweenConfig2.onStart = onStart2;
		MultiTargetTween darkTween = Tweens.Add(tweenConfig2);
		_darkTween = darkTween;
		if (_sparkTween != null)
		{
			_sparkTween.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[2];
		Transform transform2 = _sparkSprite.transform;
		if ((object)transform2 != null)
		{
			nint num4 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sparkSprite != null)
		{
			nint num5 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		tweenConfig3.scaleX = (float?)(object)1;
		tweenConfig3.scaleY = (float?)(object)1;
		tweenConfig3.alpha = (float?)(object)1;
		tweenConfig3.duration = 200f;
		tweenConfig3.angle = (float?)(object)1;
		TweenCallback onStart3 = delegate
		{
			//IL_0053: Expected O, but got Ref
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_sparkSprite, 0f);
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_sparkSprite, 1f);
			Transform transform3 = _sparkSprite.transform;
			object obj6 = default(object);
			transform3.localEulerAngles = (Vector3)(&obj6);
		};
		tweenConfig3.onStart = onStart3;
		TweenCallback onUpdate = delegate
		{
			Transform cachedTransform = base._cachedTransform;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			bool flag2 = (object)_sparkSprite == null;
			Transform transform3 = _sparkSprite.transform;
			bool flag3 = (object)transform3 == null;
			bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
			bool flag5 = (object)_ringSprite == null;
			Transform transform4 = _ringSprite.transform;
			bool flag6 = (object)transform4 == null;
			bool flag7 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
			Vector3 value2 = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value2);
		};
		tweenConfig3.onUpdate = onUpdate;
		TweenCallback onComplete = delegate
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ringSprite, 0f);
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_sparkSprite, 0f);
		};
		tweenConfig3.onComplete = onComplete;
		MultiTargetTween sparkTween = Tweens.Add(tweenConfig3);
		_sparkTween = sparkTween;
	}

	private void _003CPlaySparkle_003Eb__21_0()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ringSprite, 1f);
	}

	private void _003CPlaySparkle_003Eb__21_1()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_darkSprite, 0f);
	}

	private unsafe void _003CPlaySparkle_003Eb__21_2()
	{
		//IL_0053: Expected O, but got Ref
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_sparkSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_sparkSprite, 1f);
		Transform transform = _sparkSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private void _003CPlaySparkle_003Eb__21_3()
	{
		Transform cachedTransform = base._cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
		bool flag2 = (object)_sparkSprite == null;
		Transform transform = _sparkSprite.transform;
		bool flag3 = (object)transform == null;
		bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		bool flag5 = (object)_ringSprite == null;
		Transform transform2 = _ringSprite.transform;
		bool flag6 = (object)transform2 == null;
		bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
	}

	private void _003CPlaySparkle_003Eb__21_4()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ringSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_sparkSprite, 0f);
	}
}
