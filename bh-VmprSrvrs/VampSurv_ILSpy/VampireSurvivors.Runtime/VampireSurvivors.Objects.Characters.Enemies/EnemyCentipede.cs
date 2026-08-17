using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyCentipede : EnemyFlag
{
	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		_EnemyRenderer.enabled = true;
	}

	protected unsafe override Vector2 MovementCal()
	{
		//IL_0051: Expected O, but got I4
		//IL_005b: Expected F4, but got O
		//IL_0064: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_00b4: Expected F4, but got I
		//IL_00bd: Expected O, but got I4
		//IL_036e: Expected O, but got F4
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Expected O, but got Unknown
		//IL_0132: Invalid comparison between F4 and O
		//IL_0159: Expected F4, but got O
		//IL_0164: Invalid comparison between O and F4
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected O, but got Unknown
		//IL_0297: Expected O, but got Ref
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Expected O, but got Unknown
		//IL_034f: Expected O, but got F4
		//IL_0360: Expected O, but got Ref
		//IL_0215->IL01ba: Incompatible stack heights: 1 vs 0
		//IL_029c->IL0108: Incompatible stack heights: 2 vs 0
		//IL_02f6->IL01ba: Incompatible stack heights: 1 vs 0
		//IL_0365->IL01b5: Incompatible stack heights: 2 vs 0
		RetargetIfNecessary();
		if (!((EnemyController)this)._fixedDirection)
		{
			goto IL_00cb;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018768D4ADh\"");
		bool flag = (object)_currentDirection != null;
		Vector2 vector = (Vector2)this;
		Vector2 vector2 = (Vector2)0;
		float num = (float)_currentDirection;
		object obj = 0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018768D4ADh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyCentipede)+1E4]");
			bool flag2 = (nint)0 != 0;
			vector = (Vector2)this;
			vector2 = (Vector2)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyCentipede)+1E4]");
			num = 0f;
			obj = 0;
			if (!flag2)
			{
				goto IL_00cb;
			}
		}
		goto IL_0108;
		IL_0365:
		object obj2 = Time.deltaTime;
		float num2 = num * 1000f;
		float num3 = ((EnemyController)this)._003CSpeed_003Ek__BackingField / 10416.25f;
		float num4 = num2 / 16.666f;
		float num5 = num4 * num3;
		float num6 = (_medusaElapsed = num5 + _medusaElapsed) * 57.29578f;
		float num7 = num6 / 90f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		float num8 = num7 * 90f;
		float num9 = num8 * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj3 = num9 ^ 0;
		Vector2 result = default(Vector2);
		return result;
		IL_0108:
		Vector3 ret;
		Vector3 ret2;
		if (((EnemyController)this)._fixedDirection)
		{
			Vector2 currentDirection = _currentDirection;
			bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f) < System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref currentDirection);
			num = 0.5f;
			if (!flag3)
			{
				num = (float)_currentDirection;
				if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref _currentDirection) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)(-0.5f)))
				{
					object targetTransform = ((EnemyController)this)._targetTransform;
					if ((object)((EnemyController)this)._targetTransform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdi_v14 (System.Object)+10]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdi_v14 (System.Object)+10]");
						Transform.get_position_Injected((IntPtr)0, out ret);
						Transform cachedTransform = _cachedTransform;
						if ((object)_cachedTransform != null)
						{
							bool flag5 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out ret2);
							vector = (Vector2)(this + 480);
							num = (float)ret - (float)ret2;
							_currentDirection = (Vector2)num;
							((Vector2*)vector)->Normalize();
							obj = (object)(&ret2);
							goto IL_0365;
						}
					}
					goto IL_01ba;
				}
			}
		}
		goto IL_0365;
		IL_00cb:
		Transform targetTransform2 = ((EnemyController)this)._targetTransform;
		if ((object)((EnemyController)this)._targetTransform != null)
		{
			bool flag6 = ((UnityEngine.Object)targetTransform2).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)targetTransform2).m_CachedPtr, out ret2);
			object cachedTransform2 = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v17 (System.Object)+10]");
				bool flag7 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v17 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret);
				vector2 = ret2 - ret;
				object obj4 = default(object);
				object obj5 = default(object);
				num = (float)obj4 - (float)obj5;
				vector = (Vector2)(this + 480);
				_currentDirection = vector2;
				((Vector2*)vector)->Normalize();
				obj = (object)(&ret);
				goto IL_0108;
			}
		}
		goto IL_01ba;
		IL_01ba:
		throw new NullReferenceException();
	}

	protected override void InitTrail()
	{
		base.InitTrail();
		_Trail.startWidth = 0.3f;
		_Trail.endWidth = 0.3f;
	}

	protected override void UpdateTrailFlip()
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_00a8: Expected F4, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5FFD]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Material material = ((Renderer)_Trail).GetMaterial();
		int num = Shader.PropertyToID("_FlipY");
		bool flag = 0 < (nint)_currentDirection;
		object obj = 0 - _currentDirection;
		bool flag2 = obj == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		float value = ((flag4 & flag3) ? 1 : 0);
		material.SetFloatImpl(num, value);
	}

	protected override void Die()
	{
		((EnemyController)this).Die();
		FadeTrailOut();
		_EnemyRenderer.enabled = false;
	}

	public override void Disappear()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6247]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		((EnemyController)this).Disappear();
		((EnemyController)this)._003CIsDead_003Ek__BackingField = true;
		_SpriteAnimation.SetAnimation("die");
		FadeTrailOut();
		_EnemyRenderer.enabled = false;
	}

	public EnemyCentipede()
	{
		_goingRight = true;
		((EnemyController)this)._002Ector();
	}
}
