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

public class EnemySuspicio : EnemyController
{
	private bool _isActivated;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_00af: Expected O, but got I
		//IL_00bf: Expected O, but got I
		base.InitEnemy(enemyType, asRemote);
		BaseBody baseBody = body;
		_isActivated = false;
		_allowAnimationPauseResume = false;
		base._003CIsCullable_003Ek__BackingField = true;
		baseBody._enable = false;
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = true;
		EnemyData currentEnemyData = _currentEnemyData;
		List<string> list = currentEnemyData._003CframeNames_003Ek__BackingField;
		if (list._size > 0)
		{
			string[] items = list._items;
			string text = items[0].ToLowerInvariant();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v9+B8]");
			object newValue = 0;
			string text2 = text.Replace(".png", (string)newValue);
			string text3 = text2.Replace("_0", "_i00");
			EnemyData currentEnemyData2 = _currentEnemyData;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			Sprite sprite = default(Sprite);
			ArcadeSprite arcadeSprite = setFrame(sprite);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	protected override void OnUpdate()
	{
		//IL_0152: Invalid comparison between F4 and O
		//IL_0174->IL00c7: Incompatible stack heights: 1 vs 0
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		if (_isActivated)
		{
			base.OnUpdate();
			return;
		}
		RetargetIfNecessary();
		object targetTransform = base._targetTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdi_v2 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdi_v2 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
		float2 float5 = base.position;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		object obj4 = (object)float5 - (object)ret;
		object obj5 = obj * obj;
		object obj6 = obj4 * obj4;
		object obj7 = obj6 + obj5;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
		{
			BaseBody baseBody = body;
			_isActivated = true;
			_allowAnimationPauseResume = true;
			base._003CIsCullable_003Ek__BackingField = false;
			baseBody._enable = true;
			SpriteAnimation spriteAnimation = _SpriteAnimation;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
		}
		base.UpdateDepth();
	}

	private void Activate()
	{
		BaseBody baseBody = body;
		_isActivated = true;
		_allowAnimationPauseResume = true;
		base._003CIsCullable_003Ek__BackingField = false;
		baseBody._enable = true;
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
	}
}
