using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class TP_ADV_BOSS_Succubus : EnemyControllerBoss
{
	private float formShiftThresholdPercentage = 0.5f;

	private bool _showingBaseForm;

	private float _formShiftThresholdHp;

	private static readonly ProfilerMarker MarkerSetEnemySpriteAndAnimations;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		SetAsPlayerSpriteAndAnimations();
		float formShiftThresholdHp = formShiftThresholdPercentage * _maxHp;
		_showingBaseForm = false;
		_formShiftThresholdHp = formShiftThresholdHp;
	}

	protected override void OnUpdate()
	{
		OnUpdate();
		base.UpdateSpawnDamageZones();
		if (!(_formShiftThresholdHp > _hp))
		{
			float2 float5 = base.position;
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			float2 float6 = gameSessionData._activeCharacter.position;
			bool flag = (byte)(float5 < float6) != 0;
			object obj = float5 - float6;
			bool flag2 = obj == null;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flag5 = flag4 & flag3;
			ArcadeSprite arcadeSprite = setFlipX(flag5);
		}
		else if (!_showingBaseForm)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 123 Invalid \"Jump target not found in method: 0x1876D56E0\"");
		}
	}

	private void SetAsSuccubusSpriteAndAnimations()
	{
		//IL_0398: Expected I, but got O
		//IL_03b0: Expected I4, but got O
		//IL_03b4: Expected O, but got I4
		//IL_0307: Expected I, but got O
		//IL_0355->IL0363: Incompatible stack heights: 6 vs 5
		//IL_0234->IL0234: Incompatible stack heights: 6 vs 5
		if ((object)MarkerSetEnemySpriteAndAnimations != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerSetEnemySpriteAndAnimations);
		}
		EnemyData currentEnemyData = _currentEnemyData;
		bool flag = _currentEnemyData == null;
		TP_ADV_BOSS_Succubus tP_ADV_BOSS_Succubus = (TP_ADV_BOSS_Succubus)(object)currentEnemyData._003CframeNames_003Ek__BackingField;
		bool flag2 = currentEnemyData._003CframeNames_003Ek__BackingField == null;
		object obj = UnityEngine.Random.RandomRangeInt(0, (int)((MonoBehaviour)tP_ADV_BOSS_Succubus).m_CancellationTokenSource);
		EnemyData currentEnemyData2 = _currentEnemyData;
		bool flag3 = _currentEnemyData == null;
		List<string> list = currentEnemyData2._003CframeNames_003Ek__BackingField;
		bool flag4 = currentEnemyData2._003CframeNames_003Ek__BackingField == null;
		bool flag5 = (nint)obj >= list._size;
		string[] items = list._items;
		_defaultName = items[obj];
		EnemyData currentEnemyData3 = _currentEnemyData;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite = setFrame(sprite);
		_AlertSpriteRenderer.forceRenderingOff = true;
		_SpriteAnimation.CleanAnimations();
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
		EnemyData currentEnemyData4 = _currentEnemyData;
		List<string> list2 = currentEnemyData4._003CframeNames_003Ek__BackingField;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if (list2._size != 0)
		{
			bool shouldLoop = default(bool);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			if (currentEnemyData4._003CidleFrameCount_003Ek__BackingField > 0)
			{
				List<List<string>> internal_IdleAnimFrameNames = currentEnemyData4.Internal_IdleAnimFrameNames;
				bool flag6 = (nint)obj >= internal_IdleAnimFrameNames._size;
				List<string>[] items2 = internal_IdleAnimFrameNames._items;
				List<Sprite> frames = SpriteManager.GetAnimationFramesFast(textureName: _currentEnemyData._003CtextureName_003Ek__BackingField, frameNames: items2[obj]);
				_SpriteAnimation.AddAnimation("idle", frames, 8, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
			}
			EnemyData currentEnemyData5 = _currentEnemyData;
			List<List<string>> internal_DeathAnimFrameNames = currentEnemyData5.Internal_DeathAnimFrameNames;
			bool flag7 = (nint)obj >= internal_DeathAnimFrameNames._size;
			List<string>[] items3 = internal_DeathAnimFrameNames._items;
			List<Sprite> list3 = SpriteManager.GetAnimationFramesFast(textureName: _currentEnemyData._003CtextureName_003Ek__BackingField, frameNames: items3[obj]);
			if (list3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1876626E0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1605 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.TP_ADV_BOSS_Succubus>)+490]");
				Action action = new Action(this, (IntPtr)0);
				nint num = (nint)this;
				_SpriteAnimation.AddAnimation("die", list3, 24, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
			}
			_showingBaseForm = true;
			autoScope.Dispose();
		}
		else
		{
			autoScope.Dispose();
		}
	}

	protected override void Die()
	{
		if (!_showingBaseForm)
		{
			SetAsSuccubusSpriteAndAnimations();
		}
		base.Die();
	}

	private void SetAsPlayerSpriteAndAnimations()
	{
		//IL_0458: Expected I, but got O
		//IL_0069: Expected I, but got O
		//IL_00b5: Expected O, but got I
		//IL_0477: Expected O, but got I4
		//IL_0135: Expected O, but got I
		//IL_0362: Expected O, but got I4
		//IL_0362: Expected I4, but got O
		//IL_036a: Expected O, but got I4
		//IL_0327: Expected I4, but got O
		//IL_04b0: Expected I, but got O
		//IL_03c9: Expected I4, but got O
		//IL_0404: Expected O, but got I4
		//IL_0404: Expected I4, but got O
		if ((object)MarkerSetEnemySpriteAndAnimations != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerSetEnemySpriteAndAnimations);
		}
		GameManager core = GM.Core;
		bool flag = (object)GM.Core == null;
		bool flag2 = core._playerOptions == null;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag3 = config == null;
		List<CharacterType> list = config._003CBoughtCharacters_003Ek__BackingField;
		nint num = (nint)GM.Core;
		bool flag4 = (object)GM.Core == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rcx_v10 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+90]");
		bool flag5 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rcx_v10 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+90]");
		PlayerOptionsData config2 = ((PlayerOptions)0).Config;
		bool flag6 = config2 == null;
		List<CharacterType> list2 = config2._003CBoughtCharacters_003Ek__BackingField;
		bool flag7 = config2._003CBoughtCharacters_003Ek__BackingField == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		object obj = UnityEngine.Random.RandomRangeInt(0, 0);
		bool flag8 = config._003CBoughtCharacters_003Ek__BackingField == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rbx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		bool flag9 = (nint)obj >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rbx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj2 = 0;
		GameManager core2 = GM.Core;
		PlayerOptions playerOptions = core2._playerOptions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rcx_v14+20+v585 @ rax_v18*4]");
		SkinType skinTypeForCharacter = playerOptions.GetSkinTypeForCharacter(CharacterType.VOID);
		PlayerOptions playerOptions2 = core2._playerOptions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rcx_v14+20+v585 @ rax_v18*4]");
		Skin skinForCharacter = playerOptions2.GetSkinForCharacter(CharacterType.VOID, skinTypeForCharacter);
		GameManager core3 = GM.Core;
		string textureName = skinForCharacter._003CtextureName_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rcx_v14+20+v585 @ rax_v18*4]");
		CharacterLoader.LoadCharacterTexture(textureName, CharacterType.VOID, core3._dataManager);
		string animName = skinForCharacter._003CspriteName_003Ek__BackingField.Replace("1.png", "");
		Vector2 vector = default(Vector2);
		string text = default(string);
		int num2 = default(int);
		bool flag10 = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, skinForCharacter._003CwalkingFrames_003Ek__BackingField, vector, text, num2, flag10);
		_defaultName = skinForCharacter._003CspriteName_003Ek__BackingField;
		Vector2 vector2 = vector;
		bool flag11 = animationFrames._size <= 0;
		Sprite[] items = animationFrames._items;
		ArcadeSprite arcadeSprite = setFrame(items[0]);
		_AlertSpriteRenderer.forceRenderingOff = true;
		_SpriteAnimation.CleanAnimations();
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
		bool flag12 = skinForCharacter._003CwalkingFrames_003Ek__BackingField == 0;
		bool autoSetAnimation = default(bool);
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if (skinForCharacter._003CwalkingFrames_003Ek__BackingField > 0)
		{
			int num3 = (((object)skinForCharacter._003CwalkFrameRate_003Ek__BackingField == null) ? 8 : ((object?)skinForCharacter._003CwalkFrameRate_003Ek__BackingField >> 32));
			_SpriteAnimation.AddAnimation("idle", animationFrames, num3, (byte)(int)text != 0, (byte)num2 != 0, (Action)flag10, autoSetAnimation);
			vector2 = (Vector2)num3;
			List<Sprite> list3 = animationFrames;
		}
		else
		{
			List<Sprite> list3 = null;
			if (flag12)
			{
				autoScope.Dispose();
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1876626E0");
		int fps = (((object)skinForCharacter._003CwalkFrameRate_003Ek__BackingField == null) ? 8 : ((object?)skinForCharacter._003CwalkFrameRate_003Ek__BackingField >> 32));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1796 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.TP_ADV_BOSS_Succubus>)+490]");
		Action action = new Action(this, (IntPtr)0);
		nint num4 = (nint)this;
		_SpriteAnimation.AddAnimation("die", animationFrames, fps, (byte)(int)text != 0, (byte)num2 != 0, (Action)flag10, autoSetAnimation);
		autoScope.Dispose();
	}

	static TP_ADV_BOSS_Succubus()
	{
		//IL_002b: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("EnemyController.SetEnemySpriteAndAnimations", 1, MarkerFlags.Default, 0);
		MarkerSetEnemySpriteAndAnimations = (ProfilerMarker)(nint)intPtr;
	}
}
