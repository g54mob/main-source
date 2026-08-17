using System;
using System.Collections.Generic;
using Coherence;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Olrox_Character : TP_Character
{
	private MorphVFX _morphVFX;

	private bool _isMorphed;

	private bool _hasSecondAnim;

	private float _mightBonus;

	private float _cooldownBonus;

	private float _morphDuration = 30000f;

	private int _morphedTimes;

	private int _finalMorphedTimes;

	private int _finalThreshold = 15000;

	private int _enemiesTs;

	private bool hasBonusesApplied;

	private int[] _thresholds = new int[8] { 1000, 3000, 5000, 7000, 9000, 11000, 13000, 15000 };

	private bool canMorph;

	private NdujaWeapon addedHiddenWeapon;

	private List<Vector2> _cachedHeadOffsets;

	public override bool DrainWeaponsImmunity => true;

	private void CalculateTreshold()
	{
		int[] thresholds = _thresholds;
		if (_morphedTimes < thresholds.Length)
		{
			int[] thresholds2 = _thresholds;
			int morphedTimes = _morphedTimes;
			_enemiesTs = thresholds2[morphedTimes];
		}
		else
		{
			int enemiesTs = _finalThreshold * _finalMorphedTimes;
			int finalMorphedTimes = _finalMorphedTimes + 1;
			_finalMorphedTimes = finalMorphedTimes;
			_enemiesTs = enemiesTs;
		}
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (!_isMorphed)
		{
			if (_coherenceSync.HasStateAuthority && canMorph && !((CharacterController)this)._isDead && !base.IsDisconnectedFromOnlinePlay)
			{
				GameManager core = GM.Core;
				PlayerOptionsData config = core._playerOptions.Config;
				if (config._003CRunEnemies_003Ek__BackingField > _enemiesTs)
				{
					GameManager core2 = GM.Core;
					if (!core2._multiplayer.IsOnlineMultiplayer)
					{
						Morph();
					}
					else
					{
						Action action = Morph;
						bool flag = _coherenceSync.SendCommand(action, MessageTarget.All);
					}
				}
			}
			if (!_isMorphed)
			{
				return;
			}
		}
		NdujaWeapon ndujaWeapon = addedHiddenWeapon;
		if ((object)addedHiddenWeapon != null && ((UnityEngine.Object)ndujaWeapon).m_CachedPtr != (IntPtr)0)
		{
			if (base.flipX)
			{
			}
			NdujaWeapon ndujaWeapon2 = addedHiddenWeapon;
			Vector3 firingOffset = default(Vector3);
			ndujaWeapon2.FiringOffset = firingOffset;
			_ = 0;
		}
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_01ae: Expected I, but got O
		base.MakeLevelOne();
		_finalMorphedTimes = 2;
		_morphedTimes = 0;
		_isMorphed = false;
		_mightBonus = 0f;
		CalculateTreshold();
		MakeMorphVFX();
		CharacterData currentCharacterData = _currentCharacterData;
		List<Vector2> cachedHeadOffsets = currentCharacterData._003CheadOffsets_003Ek__BackingField;
		if (currentCharacterData._003CheadOffsets_003Ek__BackingField == null)
		{
			List<Vector2> list = new List<Vector2>();
			nint num = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rcx_v24 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num2 = 0;
			Vector2 item = default(Vector2);
			list.Add(item);
			cachedHeadOffsets = list;
		}
		_cachedHeadOffsets = cachedHeadOffsets;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list2 = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj != -1)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			object obj2 = default(object);
			if (obj2 == null)
			{
				canMorph = true;
			}
		}
	}

	public unsafe void PermanentMorph()
	{
		//IL_0031: Expected O, but got Ref
		//IL_005b: Expected O, but got I4
		//IL_00ed: Expected O, but got F4
		//IL_011f: Expected O, but got I4
		//IL_011f: Expected I4, but got F4
		//IL_01d8: Expected O, but got I
		//IL_01ed: Expected O, but got I
		//IL_020c: Expected O, but got I
		//IL_0249: Expected O, but got I
		//IL_025e: Expected O, but got I
		//IL_0278: Expected O, but got I
		if (_isMorphed)
		{
			return;
		}
		CheckRenderer();
		Transform transform = ((ArcadeSprite)this)._spriteRenderer.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.5f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
		MakeMorphVFX();
		_morphVFX.PlaySparkle(this);
		_isMorphed = true;
		if (!_hasSecondAnim)
		{
			Vector2 pivot = default(Vector2);
			int num2 = default(int);
			bool flag = default(bool);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_OlroxMonster_i0", 1, 4, pivot, (string)num, num2, flag);
			bool autoSetAnimation = default(bool);
			_spriteAnimation.AddAnimation("walk2", animationFrames, 8, (byte)(int)num != 0, (byte)num2 != 0, (Action)flag, autoSetAnimation);
			_spriteAnimation.SetAnimation("walk2");
			_hasSecondAnim = true;
		}
		_spriteAnimation.SetAnimation("walk2");
		((CharacterController)this)._003CCurrentWalkAnimName_003Ek__BackingField = "walk2";
		GameManager core = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
		object obj2 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)279);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v25 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v25 (System.Object)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rax_v26+20]");
			object obj4 = 0;
			CharacterData currentCharacterData = _currentCharacterData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v27+78]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rax_v28+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rax_v28+10]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rcx_v23+20]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rax_v29+68]");
				currentCharacterData._003CheadOffsets_003Ek__BackingField = (List<Vector2>)0;
				_isMorphed = true;
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe void Morph()
	{
		//IL_0031: Expected O, but got Ref
		//IL_005b: Expected O, but got I4
		//IL_00c2: Expected I4, but got F4
		//IL_00fc: Expected I, but got O
		//IL_010a: Expected I, but got O
		//IL_011a: Expected O, but got I
		//IL_019a: Expected O, but got I4
		//IL_0156: Expected O, but got I
		//IL_05ce: Expected O, but got I4
		//IL_01a7: Expected I4, but got O
		//IL_018c: Expected O, but got I4
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected O, but got Unknown
		//IL_021f: Expected F4, but got O
		//IL_02b3: Expected O, but got F4
		//IL_02e5: Expected O, but got I4
		//IL_02e5: Expected I4, but got F4
		//IL_039e: Expected O, but got I
		//IL_03b3: Expected O, but got I
		//IL_03d2: Expected O, but got I
		//IL_040f: Expected O, but got I
		//IL_0424: Expected O, but got I
		//IL_043e: Expected O, but got I
		//IL_045f: Expected I4, but got F4
		//IL_0599: Expected O, but got I4
		//IL_0506: Expected I4, but got F4
		if (_isMorphed)
		{
			return;
		}
		CheckRenderer();
		Transform transform = ((ArcadeSprite)this)._spriteRenderer.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.5f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
		MakeMorphVFX();
		_morphVFX.PlaySparkle(this);
		GameManager core = GM.Core;
		Weapon weapon = core._weaponsFacade.AddHiddenWeapon(WeaponType.NDUJA, this, removeFromStore: true, (byte)(int)num != 0);
		bool flag;
		if ((object)weapon == null)
		{
			flag = false;
			goto IL_05c4;
		}
		nint num2 = (nint)weapon;
		nint num3 = (nint)typeof(NdujaWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ rdx_v37 (Il2CppClass<VampireSurvivors.Objects.Weapons.NdujaWeapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ rdx_v37 (Il2CppClass<VampireSurvivors.Objects.Weapons.NdujaWeapon>)+130]");
		object obj4;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v920 @ rax_v89+FFFFFFF8+v868 @ rax_v84*8]");
			if (0 == (nint)typeof(NdujaWeapon))
			{
				obj4 = 1;
				goto IL_05d3;
			}
		}
		obj4 = 0;
		goto IL_05d3;
		IL_05c4:
		addedHiddenWeapon = (NdujaWeapon)flag;
		NdujaWeapon ndujaWeapon = addedHiddenWeapon;
		if ((object)addedHiddenWeapon != null && ((UnityEngine.Object)ndujaWeapon).m_CachedPtr != (IntPtr)0)
		{
			NdujaWeapon ndujaWeapon2 = addedHiddenWeapon;
			float morphDuration = _morphDuration;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			Vector2 vector = (Vector2)(morphDuration ^ 0);
			((Weapon)ndujaWeapon2)._003CTotalTime_003Ek__BackingField = (float)vector;
		}
		int morphedTimes = _morphedTimes;
		int[] thresholds = _thresholds;
		_isMorphed = true;
		int enemiesTs;
		if (++_morphedTimes < thresholds.Length)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rcx_v27 (System.Int32[])+24+v395 @ rdx_v14 (System.Int32)*4]");
			enemiesTs = 0;
		}
		else
		{
			int finalMorphedTimes = _finalMorphedTimes + 1;
			_finalMorphedTimes = finalMorphedTimes;
			enemiesTs = _finalMorphedTimes * _finalThreshold;
		}
		_enemiesTs = enemiesTs;
		int num5 = default(int);
		bool flag2 = default(bool);
		bool flag3 = default(bool);
		if (!_hasSecondAnim)
		{
			Vector2 pivot = default(Vector2);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_OlroxMonster_i0", 1, 4, pivot, (string)num, num5, flag2);
			_spriteAnimation.AddAnimation("walk2", animationFrames, 8, (byte)(int)num != 0, (byte)num5 != 0, (Action)flag2, flag3);
			_spriteAnimation.SetAnimation("walk2");
			_hasSecondAnim = true;
		}
		_spriteAnimation.SetAnimation("walk2");
		((CharacterController)this)._003CCurrentWalkAnimName_003Ek__BackingField = "walk2";
		GameManager core2 = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core2._dataManager.GetConvertedCharacterData();
		object obj5 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)279);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rax_v35 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rax_v35 (System.Object)+10]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rax_v36+20]");
			object obj7 = 0;
			CharacterData currentCharacterData = _currentCharacterData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v37+78]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v38+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rax_v38+10]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rcx_v35+20]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v39+68]");
				currentCharacterData._003CheadOffsets_003Ek__BackingField = (List<Vector2>)0;
				bool flag4 = hasBonusesApplied;
				bool useRealTime = (byte)(int)num != 0;
				if (!flag4)
				{
					PlayerModifierStats playerStats = _playerStats;
					_cooldownBonus = -0.5f;
					_mightBonus = 2f;
					EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
					float value = default(float);
					EggFloat cooldown = new EggFloat(value, eggFloat._eggVal);
					value = eggFloat._val - 0.5f;
					playerStats.Cooldown = cooldown;
					PlayerModifierStats playerStats2 = _playerStats;
					EggFloat eggFloat2 = playerStats2._003CPower_003Ek__BackingField;
					useRealTime = (byte)(int)num != 0;
					float value2 = default(float);
					EggFloat power = new EggFloat(value2, eggFloat2._eggVal);
					value2 = eggFloat2._val + _mightBonus;
					playerStats2.Power = power;
					hasBonusesApplied = true;
				}
				base.IsInvul = true;
				float num6 = _morphDuration * 0.001f;
				float invincibilityTimer = num6 + ((CharacterController)this)._invincibilityTimer;
				((CharacterController)this)._invincibilityTimer = invincibilityTimer;
				base.RestoreTint();
				Action onComplete = Unmorph;
				float duration = _morphDuration * 0.001f;
				Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, (MonoBehaviour)num5, flag2 ? 1 : 0, flag3 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_05d3:
		bool flag5 = obj4 == null;
		flag = false;
		if (!flag5)
		{
			flag = (byte)(int)weapon != 0;
		}
		goto IL_05c4;
	}

	private void Unmorph()
	{
		if (hasBonusesApplied)
		{
			PlayerModifierStats playerStats = _playerStats;
			EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val - _cooldownBonus;
			playerStats._003CCooldown_003Ek__BackingField = eggFloat2;
			PlayerModifierStats playerStats2 = _playerStats;
			EggFloat eggFloat3 = playerStats2._003CPower_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
			value2 = eggFloat3._val - _mightBonus;
			playerStats2._003CPower_003Ek__BackingField = eggFloat4;
			hasBonusesApplied = false;
		}
		NdujaWeapon ndujaWeapon = addedHiddenWeapon;
		if ((object)addedHiddenWeapon != null && ((UnityEngine.Object)ndujaWeapon).m_CachedPtr != (IntPtr)0)
		{
			GameManager core = GM.Core;
			core._weaponsFacade.RemoveThisHiddenWeapon(addedHiddenWeapon, this);
		}
		_spriteAnimation.SetAnimation("walk");
		((CharacterController)this)._003CCurrentWalkAnimName_003Ek__BackingField = "walk";
		CharacterData currentCharacterData = _currentCharacterData;
		currentCharacterData._003CheadOffsets_003Ek__BackingField = _cachedHeadOffsets;
		_isMorphed = false;
	}

	public void MakeMorphVFX()
	{
		if (_morphVFX == null)
		{
			MorphVFX morphVFX = new MorphVFX();
			_morphVFX = morphVFX;
			MorphVFX morphVFX2 = _morphVFX;
			morphVFX2._burstTint = new uint[4] { 16711680u, 65280u, 13421568u, 8947712u };
			MorphVFX morphVFX3 = _morphVFX;
			morphVFX3._sparkName = "blurredSharpStar.png";
			MorphVFX morphVFX4 = _morphVFX;
			morphVFX4._diskName = "disc.png";
			_morphVFX.Make();
		}
	}
}
