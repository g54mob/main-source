using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerOSole : CharacterControllerHalloween
{
	private float _amountBonus;

	private float _armorBonus;

	private float _maxHpBonus;

	private MorphVFX _morphVFX;

	private bool _isMorphed;

	private Weapon _evolvedWeapon;

	private PhaserSprite _sprCore;

	private PhaserSprite _sprFlower;

	private PhaserSprite _sprPond;

	private PhaserSprite _sprSplash;

	private PhaserSprite _sprGrass;

	public bool IsMorphed => _isMorphed;

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (_isMorphed)
		{
			ArcadeSprite arcadeSprite = setVisible(visible: false);
			int num = base.Depth;
			int num2 = num + 1;
			PhaserSprite phaserSprite = _sprCore.setDepth(num2);
			int num3 = base.Depth;
			int num4 = num3 + 2;
			PhaserSprite phaserSprite2 = _sprPond.setDepth(num4);
			int num5 = base.Depth;
			int num6 = num5 + 3;
			PhaserSprite phaserSprite3 = _sprGrass.setDepth(num6);
			int num7 = base.Depth;
			int num8 = num7 + 4;
			PhaserSprite phaserSprite4 = _sprSplash.setDepth(num8);
			int num9 = base.Depth;
			int num10 = num9 + 5;
			PhaserSprite phaserSprite5 = _sprFlower.setDepth(num10);
			base.angle = 0f;
		}
	}

	public override void LevelUp()
	{
		base.LevelUp();
		if (((CharacterController)this)._level < 80)
		{
			return;
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
		object obj2 = default(object);
		if (obj2 == null)
		{
			GameManager core3 = GM.Core;
			PlayerOptionsData config3 = core3._playerOptions.Config;
			if (config3.HasCollectedItem(ItemType.RELIC_ALTEMANNA))
			{
				Morph();
			}
		}
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne(false);
		_isMorphed = false;
		_armorBonus = 2f;
		_amountBonus = 1f;
		_maxHpBonus = 100f;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				MakeMorphVFX();
			}
		}
	}

	private void MorphedOnStop()
	{
		_wiggleTween.Pause();
		base.angle = 0f;
	}

	private void MakeMorphVFX()
	{
		if (_morphVFX == null)
		{
			MorphVFX morphVFX = new MorphVFX();
			_morphVFX = morphVFX;
			MorphVFX morphVFX2 = _morphVFX;
			morphVFX2._burstTint = new uint[4] { 65280u, 255u, 16776960u, 16711680u };
			MorphVFX morphVFX3 = _morphVFX;
			morphVFX3._sparkName = "blurredSharpStar.png";
			MorphVFX morphVFX4 = _morphVFX;
			morphVFX4._diskName = "disc.png";
			_morphVFX.Make();
		}
	}

	protected override void OnStop()
	{
		if (!_isMorphed)
		{
			base.OnStop();
			return;
		}
		_wiggleTween.Pause();
		base.angle = 0f;
	}

	private void Morph()
	{
		//IL_0051: Expected O, but got I4
		//IL_028d: Expected F4, but got O
		if (!_isMorphed)
		{
			MakeMorphVFX();
			_morphVFX.PlaySparkle(this);
			_isMorphed = true;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 0.5f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, time);
			GameManager core = GM.Core;
			Weapon weapon = core._weaponsFacade.RemoveWeapon(WeaponType.FLOWER, this);
			GameManager core2 = GM.Core;
			Weapon evolvedWeapon = core2._weaponsFacade.AddWeapon(WeaponType.FLOWER2, this);
			core2.SetSeenWeapon(WeaponType.FLOWER2);
			_evolvedWeapon = evolvedWeapon;
			Skin currentSkinData = _currentCharacterData.GetCurrentSkinData();
			List<Vector2> list = new List<Vector2>();
			Vector2 vector = default(Vector2);
			list.Add(vector);
			currentSkinData._003CheadOffsets_003Ek__BackingField = list;
			SpriteAnimation spriteAnimation = _spriteAnimation;
			((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
			MakeSprites();
			PlayerModifierStats playerStats = _playerStats;
			EggFloat eggFloat = playerStats._003CAmount_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + _amountBonus;
			playerStats._003CAmount_003Ek__BackingField = eggFloat2;
			PlayerModifierStats playerStats2 = _playerStats;
			EggFloat eggFloat3 = playerStats2._003CArmor_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
			value2 = eggFloat3._val + _armorBonus;
			playerStats2._003CArmor_003Ek__BackingField = eggFloat4;
			PlayerModifierStats playerStats3 = _playerStats;
			EggFloat eggFloat5 = playerStats3._003CMaxHp_003Ek__BackingField;
			float value3 = default(float);
			EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
			value3 = eggFloat5._val + _maxHpBonus;
			playerStats3._003CMaxHp_003Ek__BackingField = eggFloat6;
			float num = base.MaxHp();
			((CharacterController)this)._currentHp = (float)vector;
		}
	}

	private void MakeSprites()
	{
		//IL_033c: Expected O, but got I4
		//IL_035a: Expected O, but got I4
		//IL_0378: Expected O, but got I4
		//IL_0396: Expected O, but got I4
		//IL_03b4: Expected O, but got I4
		CheckRenderer();
		GameObject gameObject = ((ArcadeSprite)this)._spriteRenderer.gameObject;
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		PhaserSprite sprCore = RenderingExtensions.AddPhaserSprite(gameObject, pos, "anima", "Flex_01");
		_sprCore = sprCore;
		CheckRenderer();
		GameObject gameObject2 = ((ArcadeSprite)this)._spriteRenderer.gameObject;
		float2 float6 = base.position;
		PhaserSprite sprFlower = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "anima", "FlexFlower_01");
		_sprFlower = sprFlower;
		CheckRenderer();
		GameObject gameObject3 = ((ArcadeSprite)this)._spriteRenderer.gameObject;
		float2 float7 = base.position;
		PhaserSprite sprPond = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "anima", "FlexPond_01");
		_sprPond = sprPond;
		CheckRenderer();
		GameObject gameObject4 = ((ArcadeSprite)this)._spriteRenderer.gameObject;
		float2 float8 = base.position;
		PhaserSprite sprSplash = RenderingExtensions.AddPhaserSprite(gameObject4, pos, "anima", "FlexSplash_01");
		_sprSplash = sprSplash;
		CheckRenderer();
		GameObject gameObject5 = ((ArcadeSprite)this)._spriteRenderer.gameObject;
		float2 float9 = base.position;
		PhaserSprite sprGrass = RenderingExtensions.AddPhaserSprite(gameObject5, pos, "anima", "FlexGrass_01");
		_sprGrass = sprGrass;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Flex_", 1, 8, "anima", num);
		PhaserSprite sprCore2 = _sprCore;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		sprCore2._spriteAnimation.AddAnimation("idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("FlexFlower_", 1, 8, "anima", num);
		PhaserSprite sprFlower2 = _sprFlower;
		sprFlower2._spriteAnimation.AddAnimation("idle", animationFrames2, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("FlexPond_", 1, 8, "anima", num);
		PhaserSprite sprPond2 = _sprPond;
		sprPond2._spriteAnimation.AddAnimation("idle", animationFrames3, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("FlexSplash_", 1, 8, "anima", num);
		PhaserSprite sprSplash2 = _sprSplash;
		sprSplash2._spriteAnimation.AddAnimation("idle", animationFrames4, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite phaserSprite = _sprCore.setOrigin(0.5f, (float?)(object)1);
		PhaserSprite phaserSprite2 = _sprFlower.setOrigin(0.5f, (float?)(object)1);
		PhaserSprite phaserSprite3 = _sprPond.setOrigin(0.5f, (float?)(object)1);
		PhaserSprite phaserSprite4 = _sprSplash.setOrigin(0.5f, (float?)(object)1);
		PhaserSprite phaserSprite5 = _sprGrass.setOrigin(0.5f, (float?)(object)1);
		PhaserSprite sprCore3 = _sprCore;
		sprCore3._spriteAnimation.SetAnimation("idle");
		PhaserSprite sprFlower3 = _sprFlower;
		sprFlower3._spriteAnimation.SetAnimation("idle");
		PhaserSprite sprPond3 = _sprPond;
		sprPond3._spriteAnimation.SetAnimation("idle");
		PhaserSprite sprSplash3 = _sprSplash;
		sprSplash3._spriteAnimation.SetAnimation("idle");
		((CharacterController)this)._spriteTrail.Reset();
		SpriteTrail spriteTrail = ((CharacterController)this)._spriteTrail;
		spriteTrail._MaxHistory = 1;
		spriteTrail.InitialiseGhosts(expandExisting: true);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
	}

	private void UpdateSprites()
	{
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		int num = base.Depth;
		int num2 = num + 1;
		PhaserSprite phaserSprite = _sprCore.setDepth(num2);
		int num3 = base.Depth;
		int num4 = num3 + 2;
		PhaserSprite phaserSprite2 = _sprPond.setDepth(num4);
		int num5 = base.Depth;
		int num6 = num5 + 3;
		PhaserSprite phaserSprite3 = _sprGrass.setDepth(num6);
		int num7 = base.Depth;
		int num8 = num7 + 4;
		PhaserSprite phaserSprite4 = _sprSplash.setDepth(num8);
		int num9 = base.Depth;
		int num10 = num9 + 5;
		PhaserSprite phaserSprite5 = _sprFlower.setDepth(num10);
	}
}
