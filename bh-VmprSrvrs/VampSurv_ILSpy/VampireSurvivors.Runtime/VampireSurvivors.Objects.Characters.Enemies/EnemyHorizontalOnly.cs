using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyHorizontalOnly : EnemyController
{
	protected override void OnRecycleEnemy()
	{
		//IL_0026: Expected O, but got F4
		//IL_002f: Invalid comparison between O and F4
		//IL_003e: Expected O, but got I4
		//IL_0018: Expected O, but got I8
		base.OnRecycleEnemy();
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
		Vector2 currentDirection = (Vector2)1;
		if (!flag)
		{
			currentDirection = (Vector2)4294967295L;
		}
		_currentDirection = currentDirection;
		_ = 0;
	}

	protected override void OnUpdate()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0094: Expected O, but got F4
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		base.UpdateDepth();
		if (!base._003CIsTimeStopped_003Ek__BackingField)
		{
			float num2;
			if (_receivingDamage)
			{
				float num = base._003CKnockBack_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj = num ^ 0;
				num2 = (float)obj * _damageKb;
			}
			else
			{
				num2 = 1f;
			}
			bool flag = (nint)_currentDirection < 0;
			bool flag2 = (object)_currentDirection == null;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flag5 = flag4 & flag3;
			base.SetFlipX(flag5);
			float num3 = GameManager.EnemySpeed * base._003CSpeed_003Ek__BackingField;
			float num4 = num3 / 100f;
			float num5 = num4 * num2;
			float num6 = num5 * base._003CSlow_003Ek__BackingField;
			float num7 = (float)_currentDirection * num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyHorizontalOnly)+1E4]");
			float num8 = 0f * num6;
			BaseBody baseBody = body;
			baseBody._velocity = (float2)num7;
		}
	}
}
