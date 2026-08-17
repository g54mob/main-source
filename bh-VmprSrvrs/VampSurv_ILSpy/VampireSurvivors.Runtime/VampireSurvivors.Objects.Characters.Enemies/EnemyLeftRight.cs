using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyLeftRight : EnemyController
{
	public const string ANIM_ALIAS_IDLE = "Alias_Idle";

	public const string ANIM_ALIAS_DEATH = "Alias_Death";

	protected EnemyData _alias;

	private bool _useAlias;

	public EnemyData Alias => _alias;

	private void CheckAlias()
	{
		//IL_027d: Expected O, but got I4
		//IL_0212: Expected I, but got O
		//IL_01f2->IL0265: Incompatible stack heights: 1 vs 0
		//IL_0246->IL0265: Incompatible stack heights: 1 vs 0
		if (_currentEnemyData != null)
		{
			EnemyData currentEnemyData = _currentEnemyData;
			_alias = currentEnemyData._003Calias_003Ek__BackingField;
		}
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
			bool flag2 = default(bool);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			if (alias2._003CidleFrameCount_003Ek__BackingField > 0)
			{
				string animName = text2 + "_i";
				EnemyData alias3 = _alias;
				List<Sprite> animation = SpriteManager.GetAnimation(animName, 1, alias3._003CidleFrameCount_003Ek__BackingField, alias3._003CtextureName_003Ek__BackingField, flag2);
				_SpriteAnimation.AddAnimation("Alias_Idle", animation, 8, flag2, startRandomFrame, onComplete, autoSetAnimation);
			}
			EnemyData alias4 = _alias;
			bool flag3 = alias4._003Cend_003Ek__BackingField == 0;
			int frameCount = 1;
			if (!flag3)
			{
				frameCount = alias4._003Cend_003Ek__BackingField;
			}
			string animName2 = text2 + "_";
			EnemyData alias5 = _alias;
			List<Sprite> animation2 = SpriteManager.GetAnimation(animName2, 0, frameCount, alias5._003CtextureName_003Ek__BackingField, flag2);
			if (animation2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v721 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyLeftRight>)+490]");
				Action action = new Action(this, (IntPtr)0);
				nint num = (nint)this;
				_SpriteAnimation.AddAnimation("Alias_Death", animation2, 24, flag2, startRandomFrame, onComplete, autoSetAnimation);
			}
		}
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		CheckAlias();
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		Vector3 vector = ret;
		float2 screenCenter = renderer.screenCenter;
		bool flag2 = System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref screenCenter);
		object obj = (object)ret - (object)renderer.screenCenter;
		bool flag3 = obj == null;
		bool flag4 = !flag2;
		bool flag5 = !flag3;
		if (_useAlias = flag5 & flag4)
		{
			_SpriteAnimation.SetAnimation("Alias_Idle");
		}
	}

	public override void Disappear()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A62B7]");
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

	protected override void Die()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A62B8]");
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
}
