using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerYattaCavallo : CharacterControllerHalloween
{
	private float _amountBonus;

	private float _armorBonus;

	private float _maxHpBonus;

	private float _luckBonus;

	private MorphVFX _morphVFX;

	private bool _isMorphed;

	private CherryWeapon _cherryWeapon;

	public bool IsMorphed => _isMorphed;

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
			if (config3.HasCollectedItem(ItemType.RELIC_ROSALIA))
			{
				Morph();
			}
		}
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (_isMorphed)
		{
			base.angle = 0f;
		}
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne(false);
		_isMorphed = false;
		_armorBonus = 2f;
		_amountBonus = 1f;
		_maxHpBonus = 100f;
		_luckBonus = 0.25f;
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
		//IL_0117: Expected I, but got O
		//IL_011f: Expected I, but got O
		//IL_012f: Expected O, but got I
		//IL_01af: Expected O, but got I4
		//IL_016b: Expected O, but got I
		//IL_01a1: Expected O, but got I4
		//IL_0730: Expected O, but got F4
		//IL_03cf: Expected O, but got I4
		//IL_01fb: Expected O, but got F4
		//IL_0220: Expected O, but got F4
		//IL_0238: Expected O, but got I4
		//IL_0489: Expected O, but got I4
		//IL_0489: Expected I4, but got O
		//IL_02a0: Expected I, but got O
		//IL_02a8: Expected I, but got O
		//IL_02b8: Expected O, but got I
		//IL_02f4: Expected O, but got I
		//IL_0331: Expected O, but got I
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Expected O, but got Unknown
		//IL_0796: Unknown result type (might be due to invalid IL or missing references)
		//IL_079b: Expected O, but got Unknown
		//IL_06ae: Expected F4, but got O
		if (_isMorphed)
		{
			return;
		}
		MakeMorphVFX();
		_morphVFX.PlaySparkle(this);
		_isMorphed = true;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.5f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
		GameManager core = GM.Core;
		Weapon weapon = core._weaponsFacade.RemoveWeapon(WeaponType.CHERRY, this);
		GameManager core2 = GM.Core;
		Weapon weapon2 = core2._weaponsFacade.AddWeapon(WeaponType.CHERRY2, this);
		core2.SetSeenWeapon(WeaponType.CHERRY2);
		Weapon cherryWeapon;
		if ((object)weapon2 == null)
		{
			cherryWeapon = null;
			goto IL_06e1;
		}
		nint num2 = (nint)typeof(CherryWeapon);
		nint num3 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v930 @ rdx_v51 (Il2CppClass<VampireSurvivors.Objects.Weapons.CherryWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v931 @ r8_v61 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v930 @ rdx_v51 (Il2CppClass<VampireSurvivors.Objects.Weapons.CherryWeapon>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v931 @ r8_v61 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v985 @ rax_v125+FFFFFFF8+v932 @ rax_v120*8]");
			if (0 == (nint)typeof(CherryWeapon))
			{
				obj3 = 1;
				goto IL_06f0;
			}
		}
		obj3 = 0;
		goto IL_06f0;
		IL_06e1:
		_cherryWeapon = (CherryWeapon)cherryWeapon;
		CherryWeapon cherryWeapon2 = _cherryWeapon;
		bool flag = (object)_cherryWeapon == null;
		string text = (string)num;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)cherryWeapon2).m_CachedPtr == (IntPtr)0;
			text = (string)num;
			if (!flag2)
			{
				CherryWeapon cherryWeapon3 = _cherryWeapon;
				text = (string)num;
				List<Projectile> spawnedProjectiles = ((Weapon)cherryWeapon3)._spawnedProjectiles;
				cherryWeapon3.isStars = true;
				bool flag3 = (nint)((Weapon)cherryWeapon3)._spawnedProjectiles < 0;
				object obj4 = spawnedProjectiles._size - 1;
				if (!flag3)
				{
					while (true)
					{
						List<Projectile> spawnedProjectiles2 = ((Weapon)cherryWeapon3)._spawnedProjectiles;
						if ((nint)obj4 < spawnedProjectiles2._size)
						{
							Projectile[] items = spawnedProjectiles2._items;
							CherryProjectile cherryProjectile = (CherryProjectile)items[obj4];
							nint num5 = (nint)typeof(CherryProjectile);
							nint num6 = (nint)cherryProjectile;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rdx_v46 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryProjectile>)+130]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ r9_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryProjectile>)+130]");
							nint num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rdx_v46 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryProjectile>)+130]");
							if (num7 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ r9_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryProjectile>)+C8]");
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v103+FFFFFFF8+v411 @ rax_v102*8]");
								if (0 == (nint)typeof(CherryProjectile))
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rdx_v46 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CherryProjectile>)+130]");
									object obj7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v103+FFFFFFF8+v1394 @ rcx_v87*8]");
									object obj8 = 0 - typeof(CherryProjectile);
									bool flag4 = obj8 == null;
									bool flag5 = !flag4;
									CherryProjectile cherryProjectile2 = null;
									if (!flag5)
									{
										cherryProjectile2 = cherryProjectile;
									}
									cherryProjectile2.SetIsStar();
									obj4--;
									if ((flag4 ? 1 : 0) < (false ? 1 : 0))
									{
										break;
									}
									continue;
								}
							}
							throw new NullReferenceException();
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						return;
					}
				}
				CherryWeapon cherryWeapon4 = _cherryWeapon;
				WeaponData currentWeaponData = ((Weapon)cherryWeapon4)._currentWeaponData;
				currentWeaponData._003Cchance_003Ek__BackingField = 1f;
			}
		}
		BaseBody baseBody = body.setOffset(30f, (float?)(object)1);
		Skin currentSkinData = _currentCharacterData.GetCurrentSkinData();
		List<Vector2> list = new List<Vector2>();
		Vector2 vector = default(Vector2);
		list.Add(vector);
		currentSkinData._003CheadOffsets_003Ek__BackingField = list;
		SpriteAnimation spriteAnimation = _spriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		int num8 = default(int);
		bool flag6 = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("yattaCowi0", 1, 4, vector, text, num8, flag6);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("walk2", animationFrames, 8, (byte)(int)text != 0, (byte)num8 != 0, (Action)flag6, autoSetAnimation);
		_spriteAnimation.SetAnimation("walk2");
		((CharacterController)this)._003CCurrentWalkAnimName_003Ek__BackingField = "walk2";
		SpriteAnimation spriteAnimation2 = _spriteAnimation;
		((BaseSpriteAnimation)spriteAnimation2)._003CIsPaused_003Ek__BackingField = false;
		((CharacterController)this)._spriteTrail.Reset();
		SpriteTrail spriteTrail = ((CharacterController)this)._spriteTrail;
		spriteTrail._MaxHistory = 1;
		spriteTrail.InitialiseGhosts(expandExisting: true);
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
		PlayerModifierStats playerStats4 = _playerStats;
		EggFloat eggFloat7 = playerStats4._003CLuck_003Ek__BackingField;
		float value4 = default(float);
		EggFloat eggFloat8 = new EggFloat(value4, eggFloat7._eggVal);
		value4 = eggFloat7._val + _luckBonus;
		playerStats4._003CLuck_003Ek__BackingField = eggFloat8;
		float num9 = base.MaxHp();
		((CharacterController)this)._currentHp = (float)vector;
		return;
		IL_06f0:
		bool flag7 = obj3 == null;
		cherryWeapon = null;
		if (!flag7)
		{
			cherryWeapon = weapon2;
		}
		goto IL_06e1;
	}
}
