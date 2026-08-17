using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyUpDown : EnemyController
{
	public const string ANIM_ALIAS_IDLE = "Alias_Idle";

	public const string ANIM_ALIAS_DEATH = "Alias_Death";

	private bool _useAlias;

	private EnemyData _alias;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0335: Expected O, but got I4
		//IL_020a: Expected I, but got O
		//IL_01ea->IL023f: Incompatible stack heights: 1 vs 0
		//IL_023f->IL023f: Incompatible stack heights: 1 vs 0
		EnemyType enemyType2 = default(EnemyType);
		bool asRemote2 = default(bool);
		base.InitEnemy(enemyType2, asRemote2);
		EnemyData currentEnemyData = _currentEnemyData;
		_alias = currentEnemyData._003Calias_003Ek__BackingField;
		if (_alias != null)
		{
			EnemyData alias = _alias;
			List<string> list = alias._003CframeNames_003Ek__BackingField;
			object obj = UnityEngine.Random.RandomRangeInt(0, list._size);
			bool flag = (nint)obj >= list._size;
			string[] items = list._items;
			string text = items[obj].Replace("_0.png", "");
			string text2 = text.Replace(".png", "");
			EnemyData alias2 = _alias;
			int num = default(int);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			if (alias2._003CidleFrameCount_003Ek__BackingField > 0)
			{
				string animName = text2 + "_i";
				EnemyData alias3 = _alias;
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, alias3._003CidleFrameCount_003Ek__BackingField, alias3._003CtextureName_003Ek__BackingField, num);
				_SpriteAnimation.AddAnimation("Alias_Idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			}
			EnemyData alias4 = _alias;
			bool flag2 = alias4._003Cend_003Ek__BackingField == 0;
			int end = 1;
			if (!flag2)
			{
				end = alias4._003Cend_003Ek__BackingField;
			}
			string animName2 = text2 + "_";
			EnemyData alias5 = _alias;
			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames(animName2, 0, end, alias5._003CtextureName_003Ek__BackingField, num);
			if (animationFrames2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v803 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyUpDown>)+490]");
				Action action = new Action(this, (IntPtr)0);
				nint num2 = (nint)this;
				_SpriteAnimation.AddAnimation("Alias_Death", animationFrames2, 24, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			}
		}
		float2 float5 = base.position;
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 float6 = gameSessionData._activeCharacter.position;
		object obj2 = default(object);
		object obj3 = default(object);
		bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
		object obj4 = obj2 - obj3;
		bool flag4 = obj4 == null;
		bool flag5 = !flag3;
		bool flag6 = !flag4;
		if (_useAlias = flag6 & flag5)
		{
			_SpriteAnimation.SetAnimation("Alias_Idle");
		}
	}

	protected override void Die()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6464]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base.Die();
		if (_useAlias)
		{
			_SpriteAnimation.SetAnimation("Alias_Death");
		}
	}

	public override void Disappear()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6465]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base.Disappear();
		if (_useAlias)
		{
			_SpriteAnimation.SetAnimation("Alias_Death");
		}
	}
}
