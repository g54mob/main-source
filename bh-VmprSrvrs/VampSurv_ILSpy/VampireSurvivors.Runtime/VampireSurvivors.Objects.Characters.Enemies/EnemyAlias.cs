using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyAlias : EnemyController
{
	public const string ANIM_ALIAS_IDLE = "Alias_Idle";

	public const string ANIM_ALIAS_DEATH = "Alias_Death";

	protected EnemyData _alias;

	public EnemyData Alias => _alias;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_033f: Expected O, but got I4
		//IL_0208: Expected I, but got O
		//IL_01e8->IL023c: Incompatible stack heights: 1 vs 0
		//IL_023c->IL023c: Incompatible stack heights: 1 vs 0
		bool asRemote2 = default(bool);
		base.InitEnemy(enemyType, asRemote2);
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyAlias>)+490]");
				Action action = new Action(this, (IntPtr)0);
				nint num2 = (nint)this;
				_SpriteAnimation.AddAnimation("Alias_Death", animationFrames2, 24, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			}
		}
		GameManager gameManager = _gameManager;
		Stage stage = gameManager._stage;
		BackgroundManager fancyBg = stage._fancyBg;
		if ((object)stage._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
		{
			GameManager gameManager2 = _gameManager;
			Stage stage2 = gameManager2._stage;
			BackgroundManager fancyBg2 = stage2._fancyBg;
			if (fancyBg2._003CAlias_003Ek__BackingField)
			{
				_SpriteAnimation.SetAnimation("Alias_Idle");
			}
		}
	}

	public override void Disappear()
	{
		base.Disappear();
		GameManager gameManager = _gameManager;
		Stage stage = gameManager._stage;
		BackgroundManager fancyBg = stage._fancyBg;
		if ((object)stage._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
		{
			GameManager gameManager2 = _gameManager;
			Stage stage2 = gameManager2._stage;
			BackgroundManager fancyBg2 = stage2._fancyBg;
			if (fancyBg2._003CAlias_003Ek__BackingField)
			{
				_SpriteAnimation.SetAnimation("Alias_Death");
			}
		}
	}

	protected override void Die()
	{
		base.Die();
		GameManager gameManager = _gameManager;
		Stage stage = gameManager._stage;
		BackgroundManager fancyBg = stage._fancyBg;
		if ((object)stage._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
		{
			GameManager gameManager2 = _gameManager;
			Stage stage2 = gameManager2._stage;
			BackgroundManager fancyBg2 = stage2._fancyBg;
			if (fancyBg2._003CAlias_003Ek__BackingField)
			{
				_SpriteAnimation.SetAnimation("Alias_Death");
			}
		}
	}
}
