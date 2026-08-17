using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyCake : EnemyHealByFlower
{
	public override void SetOwner(GameObject owner)
	{
		//IL_009f: Expected O, but got F4
		//IL_00ad: Expected O, but got F4
		//IL_00b6: Invalid comparison between O and F4
		//IL_00fe: Expected O, but got F4
		_owner = owner;
		object obj = UnityEngine.Random.value;
		object obj2 = UnityEngine.Random.value;
		object obj3 = default(object);
		float num;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f))
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			num = renderer.width * -0.55f;
		}
		else
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			num = renderer2.width * 0.55f;
		}
		float2 float5 = default(float2);
		base.position = float5;
		object obj4 = UnityEngine.Random.value;
		float num2 = num + 1f;
		float num3 = num2 * ((EnemyController)this)._003CSpeed_003Ek__BackingField;
		((EnemyController)this)._003CSpeed_003Ek__BackingField = num3;
	}

	protected override void Die()
	{
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected O, but got Unknown
		//IL_0086: Expected O, but got I4
		if (!((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			if ((object)_deathRng == null)
			{
				int num = (int)(_deathSeed << 13);
				int num2 = (int)_deathSeed ^ num;
				int num3 = num2 >> 17;
				int num4 = num2 ^ num3;
				int num5 = num4 << 5;
				int num6 = num5 ^ num4;
				_deathRng = (Unity.Mathematics.Random)num6;
			}
			object obj = (object)_deathRng << 13;
			object obj2 = obj ^ (object)_deathRng;
			object obj3 = (object)_deathRng >> 9;
			object obj4 = obj3 | 0x3F800000;
			object obj5 = obj2 >> 17;
			object obj6 = obj2 ^ obj5;
			object obj7 = obj6 << 5;
			Unity.Mathematics.Random deathRng = (Unity.Mathematics.Random)(obj7 ^ obj6);
			_deathRng = deathRng;
			float2 float5 = base.position;
			bool includeFollowers = default(bool);
			CharacterController closestPlayer = GM.Core.GetClosestPlayer(float5, PlayerInclusionMode.AliveOrDead, 3.4028235E+38f, includeFollowers);
			float num7 = (float)obj4 - 1f;
			float num8 = closestPlayer.PLuck();
			object obj8 = default(object);
			float num9 = (float)obj8 * 0.21f;
			if (num9 > num7)
			{
				float2 float6 = base.position;
				Vector2 pos = default(Vector2);
				Pickup pickup = PickupManager.CreatePickup(pos, ItemType.ROAST, onlineSynchronization: false);
				if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
				{
					Sprite sprite = SpriteManager.GetSprite("pie", "items");
					ArcadeSprite arcadeSprite = pickup.setFrame(sprite);
					pickup.TargetPlayer = closestPlayer;
					pickup.GoToPlayer = true;
					pickup.Time = 1f;
				}
			}
		}
		base.Die();
		BaseBody baseBody = body;
		baseBody._enable = false;
	}

	protected unsafe override void OnUpdate()
	{
		//IL_01d1: Expected I, but got O
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0190: Expected O, but got F4
		//IL_0276->IL0108: Incompatible stack heights: 1 vs 0
		if (((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		nint num = (nint)typeof(Math);
		int num3 = default(int);
		int num2 = -num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rcx_v5 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 < (nint)0)
		{
			num2 = num3;
		}
		ArcadeSprite arcadeSprite = setDepth(num2);
		if (((EnemyController)this)._003CIsTimeStopped_003Ek__BackingField)
		{
			return;
		}
		if (!((EnemyController)this)._fixedDirection)
		{
			goto IL_00cf;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001876E1D0Dh\"");
		if ((object)_currentDirection == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001876E1D0Dh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyCake)+1E4]");
			if ((nint)0 == 0)
			{
				goto IL_00cf;
			}
		}
		goto IL_0108;
		IL_00cf:
		RetargetIfNecessary();
		Transform targetTransform = ((EnemyController)this)._targetTransform;
		if ((object)((EnemyController)this)._targetTransform != null)
		{
			bool flag = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 ret);
			float2 float5 = base.position;
			Vector2 vector = (Vector2)(this + 480);
			Vector2 currentDirection = (Vector2)((object)ret - (object)float5);
			_currentDirection = currentDirection;
			_ = 0;
			((Vector2*)vector)->Normalize();
			goto IL_0108;
		}
		goto IL_019a;
		IL_0108:
		if (_medusa)
		{
			float medusaElapsed = _medusaElapsed + 0.05f;
			_medusaElapsed = medusaElapsed;
		}
		bool flag2 = !_receivingDamage;
		_ = 0;
		float num5;
		if (!flag2)
		{
			float num4 = ((EnemyController)this)._003CKnockBack_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = num4 ^ 0;
			num5 = (float)obj * _damageKb;
		}
		else
		{
			num5 = 1f;
		}
		bool flag3 = (nint)_currentDirection < 0;
		bool flag4 = (object)_currentDirection == null;
		bool flag5 = !flag3;
		bool flag6 = !flag4;
		bool flag7 = flag6 & flag5;
		ArcadeSprite arcadeSprite2 = setFlipX(flag7);
		float num6 = GameManager.EnemySpeed * ((EnemyController)this)._003CSpeed_003Ek__BackingField;
		float num7 = num6 / 100f;
		float num8 = num7 * num5;
		float num9 = num8 * ((EnemyController)this)._003CSlow_003Ek__BackingField;
		float num10 = (float)_currentDirection * num9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyCake)+1E4]");
		float num11 = 0f * num9;
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._velocity = (float2)num10;
			return;
		}
		goto IL_019a;
		IL_019a:
		throw new NullReferenceException();
	}
}
