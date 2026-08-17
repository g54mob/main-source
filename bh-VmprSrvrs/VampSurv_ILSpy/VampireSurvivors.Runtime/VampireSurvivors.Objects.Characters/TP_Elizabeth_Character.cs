using System;
using System.Collections.Generic;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters;

public class TP_Elizabeth_Character : TP_Character
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

	private List<Vector2> _cachedHeadOffsets;

	public override bool DrainWeaponsImmunity => true;

	private void CalculateThreshold()
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
		//IL_006f: Expected O, but got I
		base.OnUpdate();
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v17 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v17 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v17 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		if (!canMorph || ((CharacterController)this)._isDead || base.IsDisconnectedFromOnlinePlay)
		{
			return;
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CRunEnemies_003Ek__BackingField > _enemiesTs)
		{
			canMorph = false;
			GameManager core2 = GM.Core;
			if (!core2._multiplayer.IsOnlineMultiplayer)
			{
				Morph();
				return;
			}
			Action action = Morph;
			bool flag3 = _coherenceSync.SendCommand(action, MessageTarget.All);
		}
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_01b3: Expected I, but got O
		base.MakeLevelOne();
		_finalMorphedTimes = 2;
		_morphedTimes = 0;
		_isMorphed = false;
		_mightBonus = 0f;
		CalculateThreshold();
		MakeMorphVFX();
		Skin currentSkinData = _currentCharacterData.GetCurrentSkinData();
		bool flag = currentSkinData._003CheadOffsets_003Ek__BackingField != null;
		List<Vector2> cachedHeadOffsets = currentSkinData._003CheadOffsets_003Ek__BackingField;
		if (!flag)
		{
			List<Vector2> list = new List<Vector2>();
			nint num = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v25 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num2 = 0;
			Vector2 item = default(Vector2);
			list.Add(item);
			cachedHeadOffsets = list;
		}
		_cachedHeadOffsets = cachedHeadOffsets;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list2 = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
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

	public unsafe void Morph()
	{
		//IL_0031: Expected O, but got Ref
		//IL_005b: Expected O, but got I4
		//IL_0164: Expected O, but got F4
		//IL_0196: Expected O, but got I4
		//IL_0196: Expected I4, but got F4
		//IL_0264: Expected O, but got I
		//IL_0279: Expected O, but got I
		//IL_02a2: Expected O, but got I
		//IL_02df: Expected O, but got I
		//IL_02f4: Expected O, but got I
		//IL_030e: Expected O, but got I
		//IL_032f: Expected I4, but got F4
		//IL_0469: Expected O, but got I4
		//IL_03d6: Expected I4, but got F4
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
		int morphedTimes = _morphedTimes;
		int[] thresholds = _thresholds;
		_isMorphed = true;
		int enemiesTs;
		if (++_morphedTimes < thresholds.Length)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rcx_v17 (System.Int32[])+24+v381 @ rdx_v11 (System.Int32)*4]");
			enemiesTs = 0;
		}
		else
		{
			int finalMorphedTimes = _finalMorphedTimes + 1;
			_finalMorphedTimes = finalMorphedTimes;
			enemiesTs = _finalMorphedTimes * _finalThreshold;
		}
		_enemiesTs = enemiesTs;
		int num2 = default(int);
		bool flag = default(bool);
		bool flag2 = default(bool);
		if (!_hasSecondAnim)
		{
			Vector2 pivot = default(Vector2);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_Elizabeth_Medusa_i0", 1, 5, pivot, (string)num, num2, flag);
			_spriteAnimation.AddAnimation("walk2", animationFrames, 8, (byte)(int)num != 0, (byte)num2 != 0, (Action)flag, flag2);
			_spriteAnimation.SetAnimation("walk2");
			_hasSecondAnim = true;
		}
		_spriteAnimation.SetAnimation("walk2");
		_spriteAnimation.SetAnimation("walk2");
		((CharacterController)this)._003CCurrentWalkAnimName_003Ek__BackingField = "walk2";
		GameManager core = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
		object obj2 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)275);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rax_v27 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rax_v27 (System.Object)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rax_v28+20]");
			object obj4 = 0;
			Skin currentSkinData = _currentCharacterData.GetCurrentSkinData();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rbx_v7+78]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rcx_v27+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rcx_v27+10]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rdx_v19+20]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v30+68]");
				currentSkinData._003CheadOffsets_003Ek__BackingField = (List<Vector2>)0;
				bool flag3 = hasBonusesApplied;
				bool useRealTime = (byte)(int)num != 0;
				if (!flag3)
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
				float num3 = _morphDuration * 0.001f;
				float invincibilityTimer = num3 + ((CharacterController)this)._invincibilityTimer;
				((CharacterController)this)._invincibilityTimer = invincibilityTimer;
				base.RestoreTint();
				Action onComplete = Unmorph;
				float duration = _morphDuration * 0.001f;
				Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, (MonoBehaviour)num2, flag ? 1 : 0, flag2 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void Unmorph()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5E17]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
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
		_spriteAnimation.SetAnimation("walk");
		((CharacterController)this)._003CCurrentWalkAnimName_003Ek__BackingField = "walk";
		Skin currentSkinData = _currentCharacterData.GetCurrentSkinData();
		currentSkinData._003CheadOffsets_003Ek__BackingField = _cachedHeadOffsets;
		_isMorphed = false;
		canMorph = true;
	}

	public void MakeMorphVFX()
	{
		if (_morphVFX == null)
		{
			MorphVFX morphVFX = new MorphVFX();
			_morphVFX = morphVFX;
			MorphVFX morphVFX2 = _morphVFX;
			morphVFX2._burstTint = new uint[4] { 16711680u, 16711935u, 13369548u, 8913032u };
			MorphVFX morphVFX3 = _morphVFX;
			morphVFX3._sparkName = "blurredSharpStar.png";
			MorphVFX morphVFX4 = _morphVFX;
			morphVFX4._diskName = "disc.png";
			_morphVFX.Make();
		}
	}
}
