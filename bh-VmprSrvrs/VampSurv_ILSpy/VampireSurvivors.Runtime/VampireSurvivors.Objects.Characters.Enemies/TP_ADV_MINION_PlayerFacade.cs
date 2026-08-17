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
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class TP_ADV_MINION_PlayerFacade : EnemyController
{
	private static readonly ProfilerMarker MarkerSetEnemySpriteAndAnimations;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
	}

	protected override void SetEnemySpriteAndAnimations()
	{
		//IL_0361: Expected I, but got O
		//IL_037d: Expected O, but got I4
		//IL_01ee: Expected O, but got I4
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0208: Expected I4, but got O
		//IL_03b8: Expected I, but got O
		//IL_02d2: Expected I4, but got O
		//IL_030d: Expected O, but got I4
		//IL_030d: Expected I4, but got O
		//IL_0286: Expected O, but got I4
		//IL_0286: Expected I4, but got O
		//IL_024b: Expected I4, but got O
		if ((object)MarkerSetEnemySpriteAndAnimations != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerSetEnemySpriteAndAnimations);
		}
		GameManager core = GM.Core;
		bool flag = (object)GM.Core == null;
		List<CharacterController> mainCharacters = core._mainCharacters;
		bool flag2 = core._mainCharacters == null;
		object obj = UnityEngine.Random.RandomRangeInt(0, mainCharacters._size);
		bool flag3 = (nint)obj >= mainCharacters._size;
		CharacterController[] items = mainCharacters._items;
		CharacterController characterController = items[obj];
		Skin currentSkinData = characterController._currentCharacterData.GetCurrentSkinData();
		string animName = currentSkinData._003CspriteName_003Ek__BackingField.Replace("01.png", "");
		Vector2 vector = default(Vector2);
		string text = default(string);
		int num = default(int);
		bool flag4 = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, currentSkinData._003CwalkingFrames_003Ek__BackingField, vector, text, num, flag4);
		_defaultName = currentSkinData._003CspriteName_003Ek__BackingField;
		bool flag5 = animationFrames._size <= 0;
		Sprite[] items2 = animationFrames._items;
		_EnemyRenderer.sprite = items2[0];
		_AlertSpriteRenderer.forceRenderingOff = true;
		_SpriteAnimation.CleanAnimations();
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
		int num2 = currentSkinData._003CwalkingFrames_003Ek__BackingField ^ currentSkinData._003CwalkingFrames_003Ek__BackingField;
		int num3 = currentSkinData._003CwalkingFrames_003Ek__BackingField & num2;
		bool flag6 = num3 < 0;
		bool flag7 = currentSkinData._003CwalkingFrames_003Ek__BackingField < 0;
		bool flag8 = currentSkinData._003CwalkingFrames_003Ek__BackingField == 0;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if (!flag8)
		{
			bool flag9 = flag7 == flag6;
			object obj2 = !flag9;
			object obj3 = obj2 | flag8;
			List<Sprite> list = null;
			int num4 = (int)vector;
			bool autoSetAnimation = default(bool);
			if (obj3 == null)
			{
				num4 = (((object)currentSkinData._003CwalkFrameRate_003Ek__BackingField == null) ? 8 : ((object?)currentSkinData._003CwalkFrameRate_003Ek__BackingField >> 32));
				_SpriteAnimation.AddAnimation("idle", animationFrames, num4, (byte)(int)text != 0, (byte)num != 0, (Action)flag4, autoSetAnimation);
				list = animationFrames;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1876626E0");
			int fps = (((object)currentSkinData._003CwalkFrameRate_003Ek__BackingField == null) ? 8 : ((object?)currentSkinData._003CwalkFrameRate_003Ek__BackingField >> 32));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1485 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.TP_ADV_MINION_PlayerFacade>)+490]");
			Action action = new Action(this, (IntPtr)0);
			nint num5 = (nint)this;
			_SpriteAnimation.AddAnimation("die", animationFrames, fps, (byte)(int)text != 0, (byte)num != 0, (Action)flag4, autoSetAnimation);
			autoScope.Dispose();
		}
		else
		{
			autoScope.Dispose();
		}
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
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

	static TP_ADV_MINION_PlayerFacade()
	{
		//IL_002b: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("EnemyController.SetEnemySpriteAndAnimations", 1, MarkerFlags.Default, 0);
		MarkerSetEnemySpriteAndAnimations = (ProfilerMarker)(nint)intPtr;
	}
}
