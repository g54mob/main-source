using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyVerticalOnly : EnemyController
{
	protected unsafe override void OnUpdate()
	{
		//IL_000a: Expected I, but got O
		//IL_001a: Expected O, but got I
		//IL_013c: Expected O, but got F4
		//IL_02b3: Invalid comparison between F4 and I4
		//IL_02c2: Invalid comparison between F4 and I4
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_01a3: Expected O, but got F4
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_02a5: Expected O, but got Ref
		//IL_022b->IL01ad: Incompatible stack heights: 1 vs 0
		//IL_02aa->IL010c: Incompatible stack heights: 2 vs 0
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v3 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyVerticalOnly>)+480]");
		object obj = 0;
		base.UpdateDepth();
		if (base._003CIsTimeStopped_003Ek__BackingField)
		{
			return;
		}
		if (!base._fixedDirection)
		{
			goto IL_00c9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000187785314h\"");
		bool flag = (object)_currentDirection != null;
		Vector2 vector = (Vector2)this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000187785314h\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyVerticalOnly)+1E4]");
			bool flag2 = (nint)0 != 0;
			vector = (Vector2)this;
			if (!flag2)
			{
				goto IL_00c9;
			}
		}
		goto IL_010c;
		IL_01ad:
		throw new NullReferenceException();
		IL_00c9:
		RetargetIfNecessary();
		Transform targetTransform = base._targetTransform;
		if ((object)base._targetTransform != null)
		{
			bool flag3 = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 ret);
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag4 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret2);
				Vector2 currentDirection = ret - ret2;
				object obj3 = default(object);
				object obj4 = default(object);
				object obj2 = obj3 - obj4;
				vector = (Vector2)(this + 480);
				_currentDirection = currentDirection;
				((Vector2*)vector)->Normalize();
				obj = (object)(&ret2);
				goto IL_010c;
			}
		}
		goto IL_01ad;
		IL_010c:
		float num2 = (_medusaElapsed += 0.05f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		_currentDirection = (Vector2)num2;
		float num4;
		if (_receivingDamage)
		{
			float num3 = base._003CKnockBack_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj5 = num3 ^ 0;
			num4 = (float)obj5 * _damageKb;
		}
		else
		{
			num4 = 1f;
		}
		bool flag5 = num2 < 0f;
		bool flag6 = num2 == 0f;
		bool flag7 = !flag5;
		bool flag8 = !flag6;
		bool flag9 = flag8 & flag7;
		base.SetFlipX(flag9);
		float num5 = GameManager.EnemySpeed * base._003CSpeed_003Ek__BackingField;
		float num6 = num5 / 100f;
		float num7 = num6 * num4;
		float num8 = num7 * base._003CSlow_003Ek__BackingField;
		float num9 = (float)_currentDirection * num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyVerticalOnly)+1E4]");
		float num10 = 0f * num8;
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._velocity = (float2)num9;
			return;
		}
		goto IL_01ad;
	}
}
