using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Dracula_Character : TP_Character
{
	private float _armorBonus;

	private float _cooldownBonus;

	private float _moveSpeedBonus;

	private float _mightBonus;

	private MorphVFX _morphVFX;

	private bool _isMorphed;

	private List<PhaserSprite> _megaloSprites;

	public override bool DrainWeaponsImmunity => true;

	public override float PPower()
	{
		//IL_0059: Invalid comparison between I4 and F4
		//IL_006b: Expected F4, but got I4
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		if (_playerStats != null)
		{
			EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
			float num = base.PCurse();
			float num2 = num2 - 1f;
			bool flag = !(0f < num2);
			float num3 = 0f;
			if (!flag)
			{
				num3 = num2;
			}
			if (playerStats._003CPower_003Ek__BackingField != null)
			{
				float value = default(float);
				EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
				value = eggFloat._val + num3;
				if (eggFloat2 != null)
				{
					float num4 = eggFloat2._eggVal + eggFloat2._val;
					object obj = num4 & -2147483649L;
					if ((nint)obj != 2139095040)
					{
						object obj2 = num4 & -2147483649L;
						if ((nint)obj2 <= 2139095040)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018762C661h\"");
							if (num4 == -1f / 0f)
							{
								num4 = -3.4028235E+38f;
							}
							return num4;
						}
					}
					return 3.4028235E+38f;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		PlayerModifierStats playerStats = _playerStats;
		playerStats._003CShroud_003Ek__BackingField = 10f;
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		_isMorphed = false;
		_armorBonus = 2f;
		_cooldownBonus = -0.2f;
		_moveSpeedBonus = 0.5f;
		_mightBonus = 1.5f;
	}

	public override void LevelUp()
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		base.LevelUp();
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CSealedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag;
		if ((nint)0 == 0)
		{
			flag = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			object obj = obj2 - -1;
			bool flag2 = obj == null;
			flag = !flag2;
		}
		if (((CharacterController)this)._level < 80 || ((CharacterController)this)._isDead || base.IsDisconnectedFromOnlinePlay)
		{
			return;
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		List<ItemType> list2 = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1 && !flag)
			{
				Morph();
			}
		}
	}

	public void Morph(bool addBonusStats = true)
	{
		//IL_0027: Expected O, but got I4
		//IL_0085: Expected I4, but got F4
		//IL_011f: Expected O, but got I
		//IL_0134: Expected O, but got I
		//IL_015d: Expected O, but got I
		//IL_019a: Expected O, but got I
		//IL_01af: Expected O, but got I
		//IL_01c9: Expected O, but got I
		if (_isMorphed)
		{
			return;
		}
		_isMorphed = true;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 0.5f;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
		GameManager core = GM.Core;
		Weapon weapon = core._weaponsFacade.AddHiddenWeapon(WeaponType.TP_DRACULAHAND, this, removeFromStore: true, (byte)(int)num != 0);
		MakeMorphVFX();
		_morphVFX.PlaySparkle(this);
		CreateMegaloDraculaSprites();
		GameManager core2 = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core2._dataManager.GetConvertedCharacterData();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)278);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v19 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v19 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rax_v20+20]");
			object obj3 = 0;
			Skin currentSkinData = _currentCharacterData.GetCurrentSkinData();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rbx_v6+78]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rcx_v22+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rcx_v22+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v13+20]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v22+68]");
				currentSkinData._003CheadOffsets_003Ek__BackingField = (List<Vector2>)0;
				if (addBonusStats)
				{
					PlayerModifierStats playerStats = _playerStats;
					EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
					float value = default(float);
					EggFloat armor = new EggFloat(value, eggFloat._eggVal);
					value = eggFloat._val + _armorBonus;
					playerStats.Armor = armor;
					PlayerModifierStats playerStats2 = _playerStats;
					EggFloat eggFloat2 = playerStats2._003CCooldown_003Ek__BackingField;
					float value2 = default(float);
					EggFloat cooldown = new EggFloat(value2, eggFloat2._eggVal);
					value2 = eggFloat2._val + _cooldownBonus;
					playerStats2.Cooldown = cooldown;
					PlayerModifierStats playerStats3 = _playerStats;
					EggFloat eggFloat3 = playerStats3._003CMoveSpeed_003Ek__BackingField;
					float value3 = default(float);
					EggFloat moveSpeed = new EggFloat(value3, eggFloat3._eggVal);
					value3 = eggFloat3._val + _moveSpeedBonus;
					playerStats3.MoveSpeed = moveSpeed;
					PlayerModifierStats playerStats4 = _playerStats;
					EggFloat eggFloat4 = playerStats4._003CPower_003Ek__BackingField;
					float value4 = default(float);
					EggFloat power = new EggFloat(value4, eggFloat4._eggVal);
					value4 = eggFloat4._val + _mightBonus;
					playerStats4.Power = power;
				}
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void CleanupMegaloSprites()
	{
		//IL_0039->IL0125: Incompatible stack heights: 1 vs 0
		if (_megaloSprites != null)
		{
			List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v7 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v7 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				UnityEngine.Object.Destroy(obj2, 0f);
			}
			List<PhaserSprite> megaloSprites = _megaloSprites;
			if (_megaloSprites != null)
			{
				int version = megaloSprites._version + 1;
				megaloSprites._version = version;
				megaloSprites._size = 0;
				if (megaloSprites._size > 0)
				{
					Array.Clear(megaloSprites._items, 0, megaloSprites._size);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
	}

	private void LateUpdate()
	{
		UpdateMegaloDraculaSprites();
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

	private unsafe void CreateMegaloDraculaSprites()
	{
		//IL_00b9: Expected O, but got Ref
		//IL_0b84: Expected O, but got I
		//IL_0b94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b99: Expected O, but got Unknown
		//IL_0bab: Expected O, but got Ref
		//IL_0bbe: Expected O, but got I4
		//IL_04c2: Expected O, but got I
		//IL_05dc: Expected O, but got I
		//IL_06f6: Expected O, but got I
		//IL_0810: Expected O, but got I
		//IL_0820: Expected O, but got I
		//IL_0830: Expected O, but got I
		//IL_0c89: Expected O, but got I
		//IL_0d93: Expected I, but got O
		//IL_09fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a00: Expected I4, but got Unknown
		//IL_0a1a: Expected O, but got I
		//IL_0a70: Expected I4, but got O
		//IL_0b09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0e: Expected O, but got Unknown
		//IL_0c3e->IL0b67: Incompatible stack heights: 1 vs 0
		//IL_0ca9->IL0b67: Incompatible stack heights: 2 vs 0
		//IL_0d09->IL0b67: Incompatible stack heights: 3 vs 0
		//IL_0d5e->IL0b67: Incompatible stack heights: 4 vs 0
		//IL_08a2->IL0b67: Incompatible stack heights: 4 vs 0
		//IL_0dd4->IL0b67: Incompatible stack heights: 4 vs 0
		//IL_0954->IL0b67: Incompatible stack heights: 5 vs 0
		//IL_0904->IL0b67: Incompatible stack heights: 5 vs 0
		//IL_099c->IL0b67: Incompatible stack heights: 5 vs 0
		//IL_09ed->IL0b67: Incompatible stack heights: 5 vs 0
		//IL_0a3e->IL0b67: Incompatible stack heights: 5 vs 0
		//IL_0a8d->IL0b67: Incompatible stack heights: 5 vs 0
		//IL_0b27->IL0db2: Incompatible stack heights: 5 vs 4
		//IL_0b3b->IL0b67: Incompatible stack heights: 5 vs 0
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		ArcadeSprite arcadeSprite2 = setAlpha(0f);
		List<PhaserSprite> list = new List<PhaserSprite>();
		list._002Ector();
		_megaloSprites = list;
		CheckRenderer();
		if ((object)((ArcadeSprite)this)._spriteRenderer != null)
		{
			GameObject gameObject = ((ArcadeSprite)this)._spriteRenderer.gameObject;
			CheckRenderer();
			if ((object)((ArcadeSprite)this)._spriteRenderer != null)
			{
				Transform transform = ((ArcadeSprite)this)._spriteRenderer.transform;
				if ((object)transform != null)
				{
					float2 ret = default(float2);
					transform.localEulerAngles = (Vector3)(&ret);
					float2 float5 = base.position;
					Vector2 vector = default(Vector2);
					PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "character_tp_dracula", "TP_MDR_Main_i01");
					if ((object)phaserSprite != null)
					{
						int num = default(int);
						List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_MDR_Main_i0", 1, 2, "character_tp_dracula", num);
						if ((object)phaserSprite._spriteAnimation != null)
						{
							bool startRandomFrame = default(bool);
							Action onComplete = default(Action);
							bool autoSetAnimation = default(bool);
							phaserSprite._spriteAnimation.AddAnimation("idle", animationFrames, 2, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
							if ((object)phaserSprite._spriteAnimation != null)
							{
								phaserSprite._spriteAnimation.SetAnimation("idle");
								if ((object)phaserSprite._spriteRenderer != null)
								{
									GameObject gameObject2 = phaserSprite._spriteRenderer.gameObject;
									if ((object)gameObject2 != null)
									{
										SpriteTrail spriteTrail = gameObject2.AddComponent<SpriteTrail>();
										if ((object)spriteTrail != null)
										{
											spriteTrail._MainSprite = phaserSprite._spriteRenderer;
											_ = 1059481190;
											_ = 1028443341;
											_ = 1;
											_ = 10;
											spriteTrail.InitialiseGhosts(expandExisting: true);
											Vector2 ret2 = default(Vector2);
											bool flag;
											do
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rax_v47 (VampireSurvivors.Graphics.SpriteTrail)+44]");
												object obj = (nint)0 * (nint)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rax_v47 (VampireSurvivors.Graphics.SpriteTrail)+40]");
												object obj2 = 0 - obj;
												SpriteTrail spriteTrail2 = spriteTrail.SetTint(0, (Color)(&ret2));
												SpriteAnimation spriteAnimation = (SpriteAnimation)(0 + 1);
												flag = (nint)spriteAnimation < 10;
												ret2 = vector;
											}
											while (flag);
											CheckRenderer();
											if ((object)((ArcadeSprite)this)._spriteRenderer != null)
											{
												SpriteTrail component = ((ArcadeSprite)this)._spriteRenderer.GetComponent<SpriteTrail>();
												if ((object)component != null)
												{
													SpriteTrail spriteTrail3 = component.setVisible(b: false);
													if (_megaloSprites != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
														float2 float6 = base.position;
														PhaserSprite phaserSprite2 = RenderingExtensions.AddPhaserSprite(gameObject, vector, "character_tp_dracula", "TP_MDR_Wing");
														if (_megaloSprites != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
															float2 float7 = base.position;
															PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject, vector, "character_tp_dracula", "TP_MDR_Wing");
															if ((object)phaserSprite3 != null)
															{
																PhaserSprite phaserSprite4 = phaserSprite3.setFlipX(flipX: true);
																if (_megaloSprites != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
																	float2 float8 = base.position;
																	PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject, vector, "character_tp_dracula", "TP_MDR_Body_i01");
																	if ((object)phaserSprite5 != null)
																	{
																		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_MDR_Body_i0", 1, 2, "character_tp_dracula", num);
																		if ((object)phaserSprite5._spriteAnimation != null)
																		{
																			phaserSprite5._spriteAnimation.AddAnimation("idle", animationFrames2, 3, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ rax_v65 (VampireSurvivors.Framework.Phaser.PhaserSprite)+30]");
																			if ((nint)0 != 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ rax_v65 (VampireSurvivors.Framework.Phaser.PhaserSprite)+30]");
																				((BaseSpriteAnimation)0).SetAnimation("idle");
																				if (_megaloSprites != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
																					float2 float9 = base.position;
																					PhaserSprite phaserSprite6 = RenderingExtensions.AddPhaserSprite(gameObject, vector, "character_tp_dracula", "TP_MDR_HeadLeft_i01");
																					if ((object)phaserSprite6 != null)
																					{
																						List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("TP_MDR_HeadLeft_i0", 1, 2, "character_tp_dracula", num);
																						if ((object)phaserSprite6._spriteAnimation != null)
																						{
																							phaserSprite6._spriteAnimation.AddAnimation("idle", animationFrames3, 4, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rax_v72 (VampireSurvivors.Framework.Phaser.PhaserSprite)+30]");
																							if ((nint)0 != 0)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rax_v72 (VampireSurvivors.Framework.Phaser.PhaserSprite)+30]");
																								((BaseSpriteAnimation)0).SetAnimation("idle");
																								if (_megaloSprites != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
																									float2 float10 = base.position;
																									PhaserSprite phaserSprite7 = RenderingExtensions.AddPhaserSprite(gameObject, vector, "character_tp_dracula", "TP_MDR_ArmDeco_i01");
																									if ((object)phaserSprite7 != null)
																									{
																										List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("TP_MDR_ArmDeco_i0", 1, 2, "character_tp_dracula", num);
																										if ((object)phaserSprite7._spriteAnimation != null)
																										{
																											phaserSprite7._spriteAnimation.AddAnimation("idle", animationFrames4, 3, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v78 (VampireSurvivors.Framework.Phaser.PhaserSprite)+30]");
																											if ((nint)0 != 0)
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v78 (VampireSurvivors.Framework.Phaser.PhaserSprite)+30]");
																												((BaseSpriteAnimation)0).SetAnimation("idle");
																												if (_megaloSprites != null)
																												{
																													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
																													float2 float11 = base.position;
																													PhaserSprite phaserSprite8 = RenderingExtensions.AddPhaserSprite(gameObject, vector, "character_tp_dracula", "TP_MDR_Bat_i01");
																													if ((object)phaserSprite8 != null)
																													{
																														List<Sprite> animationFrames5 = SpriteManager.GetAnimationFrames("TP_MDR_Bat_i0", 1, 3, "character_tp_dracula", num);
																														if ((object)phaserSprite8._spriteAnimation != null)
																														{
																															phaserSprite8._spriteAnimation.AddAnimation("idle", animationFrames5, 2, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v84 (VampireSurvivors.Framework.Phaser.PhaserSprite)+30]");
																															if ((nint)0 != 0)
																															{
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v84 (VampireSurvivors.Framework.Phaser.PhaserSprite)+30]");
																																((BaseSpriteAnimation)0).SetAnimation("idle");
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v84 (VampireSurvivors.Framework.Phaser.PhaserSprite)+28]");
																																object obj3 = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v84 (VampireSurvivors.Framework.Phaser.PhaserSprite)+30]");
																																object obj4 = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v84 (VampireSurvivors.Framework.Phaser.PhaserSprite)+28]");
																																if ((nint)0 != 0)
																																{
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rsi_v20 (System.Object)+10]");
																																	bool flag2 = (nint)0 == 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rsi_v20 (System.Object)+10]");
																																	IntPtr gcHandlePtr = SpriteRenderer.get_sprite_Injected((IntPtr)0);
																																	Sprite sprite = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Sprite>(gcHandlePtr);
																																	if ((object)sprite != null)
																																	{
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ rax_v92 (UnityEngine.Sprite)+10]");
																																		bool flag3 = (nint)0 == 0;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ rax_v92 (UnityEngine.Sprite)+10]");
																																		Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&ret));
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v84 (VampireSurvivors.Framework.Phaser.PhaserSprite)+28]");
																																		object obj5 = 0;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v84 (VampireSurvivors.Framework.Phaser.PhaserSprite)+28]");
																																		if ((nint)0 != 0)
																																		{
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rsi_v22 (System.Object)+10]");
																																			bool flag4 = (nint)0 == 0;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rsi_v22 (System.Object)+10]");
																																			IntPtr gcHandlePtr2 = SpriteRenderer.get_sprite_Injected((IntPtr)0);
																																			Sprite sprite2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Sprite>(gcHandlePtr2);
																																			if ((object)sprite2 != null)
																																			{
																																				bool flag5 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
																																				Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out *(Rect*)(&ret2));
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v84 (VampireSurvivors.Framework.Phaser.PhaserSprite)+30]");
																																				if ((nint)0 != 0)
																																				{
																																					_ = 1065353216;
																																					if (_megaloSprites != null)
																																					{
																																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
																																						int num2 = 2;
																																						SpriteAnimation spriteAnimation2 = null;
																																						while (true)
																																						{
																																							Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
																																							if ((object)cachedTrans == null)
																																							{
																																								break;
																																							}
																																							bool flag6 = ((List<PhaserSprite>)(object)cachedTrans)._items == null;
																																							Transform.get_position_Injected((IntPtr)((List<PhaserSprite>)(object)cachedTrans)._items, out *(Vector3*)(&ret));
																																							if (body != null)
																																							{
																																								BaseBody baseBody = body;
																																								ArcadeTransform arcadeTransform = baseBody._transform;
																																								if (baseBody._transform == null)
																																								{
																																									break;
																																								}
																																								arcadeTransform.position = ret;
																																								_ = 1054925025;
																																							}
																																							PhaserSprite phaserSprite9 = RenderingExtensions.AddPhaserSprite(gameObject, vector, "character_tp_dracula", "TP_MDR_HeadCenter_i01");
																																							if ((object)phaserSprite9 == null)
																																							{
																																								break;
																																							}
																																							List<Sprite> animationFrames6 = SpriteManager.GetAnimationFrames("TP_MDR_HeadCenter_i0", 1, 5, "character_tp_dracula", num);
																																							if ((object)phaserSprite9._spriteAnimation == null)
																																							{
																																								break;
																																							}
																																							phaserSprite9._spriteAnimation.AddAnimation("idle", animationFrames6, 5, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rax_v116 (VampireSurvivors.Framework.Phaser.PhaserSprite)+30]");
																																							if ((nint)0 == 0)
																																							{
																																								break;
																																							}
																																							int frameRate = spriteAnimation2 + 3;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rax_v116 (VampireSurvivors.Framework.Phaser.PhaserSprite)+30]");
																																							((BaseSpriteAnimation)0).Play("idle", frameRate);
																																							List<object> megaloSprites = (List<object>)(object)_megaloSprites;
																																							if (_megaloSprites == null)
																																							{
																																								break;
																																							}
																																							int version = megaloSprites._version + 1;
																																							megaloSprites._version = version;
																																							num2 = (int)megaloSprites._items;
																																							if (megaloSprites._items == null)
																																							{
																																								break;
																																							}
																																							int num3 = megaloSprites._size;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r9_v31 (System.Int32)+18]");
																																							if ((nint)num3 >= (nint)0)
																																							{
																																								((List<object>)(object)_megaloSprites).AddWithResize((object)phaserSprite9);
																																							}
																																							else
																																							{
																																								int num4 = megaloSprites._size + 1;
																																								megaloSprites._size = num4;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																							}
																																							spriteAnimation2 = (SpriteAnimation)(spriteAnimation2 + 1);
																																							if ((nint)spriteAnimation2 >= 3)
																																							{
																																								Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1540 Invalid \"Jump target not found in method: 0x18762E2F0\"");
																																								break;
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

	private void UpdateMegaloDraculaSprites()
	{
		if (_megaloSprites == null)
		{
			return;
		}
		List<PhaserSprite> megaloSprites = _megaloSprites;
		if (megaloSprites._size <= 0)
		{
			return;
		}
		int num = base.depth;
		List<PhaserSprite> megaloSprites2 = _megaloSprites;
		if (megaloSprites2._size > 0)
		{
			PhaserSprite[] items = megaloSprites2._items;
			float2 localPosition = default(float2);
			PhaserSprite phaserSprite = items[0].setLocalPosition(localPosition);
			List<PhaserSprite> megaloSprites3 = _megaloSprites;
			if (megaloSprites3._size > 0)
			{
				PhaserSprite[] items2 = megaloSprites3._items;
				int num2 = num + 10;
				PhaserSprite phaserSprite2 = items2[0].setDepth(num2);
				List<PhaserSprite> megaloSprites4 = _megaloSprites;
				if (megaloSprites4._size > 1)
				{
					PhaserSprite[] items3 = megaloSprites4._items;
					int num3 = num + 8;
					PhaserSprite phaserSprite3 = items3[1].setDepth(num3);
					List<PhaserSprite> megaloSprites5 = _megaloSprites;
					if (megaloSprites5._size > 1)
					{
						PhaserSprite[] items4 = megaloSprites5._items;
						PhaserSprite phaserSprite4 = items4[1].setLocalPosition(localPosition);
						List<PhaserSprite> megaloSprites6 = _megaloSprites;
						if (megaloSprites6._size > 2)
						{
							PhaserSprite[] items5 = megaloSprites6._items;
							int num4 = num + 8;
							PhaserSprite phaserSprite5 = items5[2].setDepth(num4);
							List<PhaserSprite> megaloSprites7 = _megaloSprites;
							if (megaloSprites7._size > 2)
							{
								PhaserSprite[] items6 = megaloSprites7._items;
								PhaserSprite phaserSprite6 = items6[2].setLocalPosition(localPosition);
								List<PhaserSprite> megaloSprites8 = _megaloSprites;
								if (megaloSprites8._size > 3)
								{
									PhaserSprite[] items7 = megaloSprites8._items;
									PhaserSprite phaserSprite7 = items7[3].setLocalPosition(localPosition);
									List<PhaserSprite> megaloSprites9 = _megaloSprites;
									if (megaloSprites9._size > 3)
									{
										PhaserSprite[] items8 = megaloSprites9._items;
										int num5 = num + 9;
										PhaserSprite phaserSprite8 = items8[3].setDepth(num5);
										List<PhaserSprite> megaloSprites10 = _megaloSprites;
										if (megaloSprites10._size > 4)
										{
											PhaserSprite[] items9 = megaloSprites10._items;
											PhaserSprite phaserSprite9 = items9[4].setLocalPosition(localPosition);
											List<PhaserSprite> megaloSprites11 = _megaloSprites;
											if (megaloSprites11._size > 4)
											{
												PhaserSprite[] items10 = megaloSprites11._items;
												int num6 = num + 11;
												PhaserSprite phaserSprite10 = items10[4].setDepth(num6);
												List<PhaserSprite> megaloSprites12 = _megaloSprites;
												if (megaloSprites12._size > 5)
												{
													PhaserSprite[] items11 = megaloSprites12._items;
													PhaserSprite phaserSprite11 = items11[5].setLocalPosition(localPosition);
													List<PhaserSprite> megaloSprites13 = _megaloSprites;
													if (megaloSprites13._size > 5)
													{
														PhaserSprite[] items12 = megaloSprites13._items;
														int num7 = num + 11;
														PhaserSprite phaserSprite12 = items12[5].setDepth(num7);
														List<PhaserSprite> megaloSprites14 = _megaloSprites;
														if (megaloSprites14._size > 6)
														{
															PhaserSprite[] items13 = megaloSprites14._items;
															PhaserSprite phaserSprite13 = items13[6].setLocalPosition(localPosition);
															List<PhaserSprite> megaloSprites15 = _megaloSprites;
															if (megaloSprites15._size > 6)
															{
																PhaserSprite[] items14 = megaloSprites15._items;
																int num8 = num + 11;
																PhaserSprite phaserSprite14 = items14[6].setDepth(num8);
																List<PhaserSprite> megaloSprites16 = _megaloSprites;
																if (megaloSprites16._size > 7)
																{
																	PhaserSprite[] items15 = megaloSprites16._items;
																	PhaserSprite phaserSprite15 = items15[7].setLocalPosition(localPosition);
																	List<PhaserSprite> megaloSprites17 = _megaloSprites;
																	if (megaloSprites17._size > 7)
																	{
																		PhaserSprite[] items16 = megaloSprites17._items;
																		int num9 = num + 12;
																		PhaserSprite phaserSprite16 = items16[7].setDepth(num9);
																		List<PhaserSprite> megaloSprites18 = _megaloSprites;
																		if (megaloSprites18._size > 8)
																		{
																			PhaserSprite[] items17 = megaloSprites18._items;
																			PhaserSprite phaserSprite17 = items17[8].setLocalPosition(localPosition);
																			List<PhaserSprite> megaloSprites19 = _megaloSprites;
																			if (megaloSprites19._size > 8)
																			{
																				PhaserSprite[] items18 = megaloSprites19._items;
																				int num10 = num + 13;
																				PhaserSprite phaserSprite18 = items18[8].setDepth(num10);
																				List<PhaserSprite> megaloSprites20 = _megaloSprites;
																				if (megaloSprites20._size > 9)
																				{
																					PhaserSprite[] items19 = megaloSprites20._items;
																					PhaserSprite phaserSprite19 = items19[9].setLocalPosition(localPosition);
																					List<PhaserSprite> megaloSprites21 = _megaloSprites;
																					if (megaloSprites21._size > 9)
																					{
																						PhaserSprite[] items20 = megaloSprites21._items;
																						int num11 = num + 13;
																						PhaserSprite phaserSprite20 = items20[9].setDepth(num11);
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
							}
						}
					}
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void SetExtraVisualsVisible(bool show)
	{
		List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	public TP_Dracula_Character()
	{
		List<PhaserSprite> megaloSprites = new List<PhaserSprite>();
		_megaloSprites = megaloSprites;
		((CharacterController)this)._002Ector();
	}
}
