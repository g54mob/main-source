using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_DeathHand_Weapon : Weapon
{
	private TP_DeathHand_Projectile[] _hands;

	private int _nextHandToMove;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_nextHandToMove = 0;
		((Equipment)this)._003CShowInRecap_003Ek__BackingField = false;
	}

	public override void Fire()
	{
	}

	protected unsafe override void OnUpdate()
	{
		//IL_015f: Expected I, but got O
		//IL_016d: Expected I, but got O
		//IL_017d: Expected O, but got I
		//IL_01fd: Expected O, but got I4
		//IL_01b9: Expected O, but got I
		//IL_04c7: Expected I, but got O
		//IL_03d2: Expected I4, but got O
		//IL_03e2: Expected O, but got I
		//IL_01ef: Expected O, but got I4
		//IL_029b: Expected O, but got I4
		//IL_0217: Expected I, but got O
		//IL_025d: Expected O, but got I
		//IL_0248: Expected I, but got O
		//IL_028d: Expected O, but got I4
		//IL_04a5->IL030e: Incompatible stack heights: 1 vs 0
		//IL_0109->IL030e: Incompatible stack heights: 1 vs 0
		//IL_02fb->IL030e: Incompatible stack heights: 2 vs 0
		//IL_024d->IL03ca: Incompatible stack heights: 2 vs 1
		//IL_030d->IL0430: Incompatible stack heights: 2 vs 0
		bool flag = _hands == null;
		TP_DeathHand_Weapon tP_DeathHand_Weapon = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 39 Invalid \"Jump target not found in method: 0x1874100F0\"");
			TP_DeathHand_Weapon tP_DeathHand_Weapon2 = default(TP_DeathHand_Weapon);
			tP_DeathHand_Weapon = tP_DeathHand_Weapon2;
		}
		TP_DeathHand_Projectile[] hands = new TP_DeathHand_Projectile[2];
		tP_DeathHand_Weapon._hands = hands;
		TP_DeathHand_Projectile[] hands2 = tP_DeathHand_Weapon._hands;
		bool flag2 = tP_DeathHand_Weapon._hands == null;
		int num = 0;
		int num2 = 0;
		if (!flag2)
		{
			Vector2 pos = default(Vector2);
			object obj4 = default(object);
			while (true)
			{
				if (num2 >= hands2.Length)
				{
					return;
				}
				ArcadeSprite arcadeSprite = ((Equipment)tP_DeathHand_Weapon)._003COwner_003Ek__BackingField;
				TP_DeathHand_Projectile[] hands3 = tP_DeathHand_Weapon._hands;
				if ((object)((Equipment)tP_DeathHand_Weapon)._003COwner_003Ek__BackingField == null)
				{
					break;
				}
				Transform cachedTrans = ((ArcadeSprite)((Equipment)tP_DeathHand_Weapon)._003COwner_003Ek__BackingField).CachedTrans;
				if ((object)cachedTrans == null)
				{
					break;
				}
				bool flag3 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
				float2 ret;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
				if (arcadeSprite.body != null)
				{
					BaseBody body = arcadeSprite.body;
					ArcadeTransform arcadeTransform = body._transform;
					if (body._transform == null)
					{
						break;
					}
					arcadeTransform.position = ret;
				}
				Projectile projectile = tP_DeathHand_Weapon.FireOneProjectile(pos, num);
				if (tP_DeathHand_Weapon._hands == null)
				{
					break;
				}
				Projectile projectile2;
				int num3;
				if ((object)projectile == null)
				{
					num3 = num;
					projectile2 = null;
					goto IL_038b;
				}
				nint num4 = (nint)projectile;
				nint num5 = (nint)typeof(TP_DeathHand_Projectile);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_DeathHand_Projectile>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_DeathHand_Projectile>)+130]");
				object obj3;
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v40+FFFFFFF8+v647 @ rax_v27*8]");
					if (0 == (nint)typeof(TP_DeathHand_Projectile))
					{
						obj3 = 1;
						goto IL_03a8;
					}
				}
				obj3 = 0;
				goto IL_03a8;
				IL_038b:
				bool flag4 = num >= hands3.Length;
				hands3[num] = (TP_DeathHand_Projectile)projectile2;
				hands2 = tP_DeathHand_Weapon._hands;
				num++;
				if (tP_DeathHand_Weapon._hands == null)
				{
					break;
				}
				num2 = num;
				continue;
				IL_03a8:
				bool flag5 = obj3 == null;
				Projectile projectile3 = null;
				if (!flag5)
				{
					projectile3 = projectile;
				}
				bool flag6 = (object)projectile3 == null;
				nint num7 = (nint)typeof(TP_DeathHand_Projectile);
				if (!flag6)
				{
					nint num8 = (nint)hands3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag7 = obj4 == null;
					num7 = (nint)typeof(TP_DeathHand_Projectile);
				}
				num3 = (int)projectile;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_DeathHand_Projectile>)+130]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ r8_v4 (System.Int32)+130]");
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_DeathHand_Projectile>)+130]");
				object obj7;
				if (num9 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ r8_v4 (System.Int32)+C8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v840 @ rax_v35+FFFFFFF8+v825 @ rax_v30*8]");
					if (0 == num7)
					{
						obj7 = 1;
						goto IL_040e;
					}
				}
				obj7 = 0;
				goto IL_040e;
				IL_040e:
				bool flag8 = obj7 == null;
				projectile2 = null;
				if (!flag8)
				{
					projectile2 = projectile;
				}
				goto IL_038b;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void UpdateHands()
	{
		//IL_000f: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_008f: Expected O, but got I4
		//IL_00a0: Expected O, but got I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_0145: Expected O, but got Ref
		//IL_016a: Invalid comparison between O and F4
		//IL_0180: Expected O, but got I
		//IL_018a: Expected O, but got I4
		TP_DeathHand_Projectile[] hands = _hands;
		object obj = hands.Length;
		TP_DeathHand_Projectile[] hands2 = _hands;
		float2 float5 = (float2)0;
		float2 float6 = (float2)0;
		object obj2 = default(object);
		object obj3 = default(object);
		while (true)
		{
			if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float6) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				TP_DeathHand_Projectile tP_DeathHand_Projectile = hands2[(object)float5];
				if (!tP_DeathHand_Projectile._isMoving)
				{
					float5++;
					float6 = float5;
					continue;
				}
				break;
			}
			float2 float7 = (float2)0;
			TP_DeathHand_Projectile[] array = hands2;
			float2 float8 = (float2)0;
			while ((nint)float8 < array.Length)
			{
				TP_DeathHand_Projectile[] hands3 = _hands;
				if ((nint)float7 == _nextHandToMove)
				{
					TP_DeathHand_Projectile tP_DeathHand_Projectile2 = hands3[(object)float7];
					if (!tP_DeathHand_Projectile2._isMoving)
					{
						float2 float9 = tP_DeathHand_Projectile2.CalculateTargetPos();
						float2 position = tP_DeathHand_Projectile2.position;
						VSDebug.DrawDebugLine(position, float9, (Color)(&obj2));
						float2 position2 = tP_DeathHand_Projectile2.position;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003D90");
						bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.25f);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FC0]");
						obj2 = 0;
						obj = 0;
						if (flag)
						{
							tP_DeathHand_Projectile2.DoStep(float9);
							int nextHandToMove = 1 - _nextHandToMove;
							_nextHandToMove = nextHandToMove;
							break;
						}
					}
				}
				array = _hands;
				float7++;
				float8 = float7;
			}
			break;
		}
	}

	public override void SetVisible(bool visible)
	{
		//IL_003c: Expected O, but got I4
		//IL_0045: Expected O, but got I4
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		bool flag = _hands == null;
		_isVisible = visible;
		if (!flag)
		{
			TP_DeathHand_Projectile[] hands = _hands;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj < hands.Length)
			{
				TP_DeathHand_Projectile[] hands2 = _hands;
				TP_DeathHand_Projectile tP_DeathHand_Projectile = hands2[obj2];
				BaseBody body = tP_DeathHand_Projectile.body;
				obj2++;
				body._enable = visible;
				hands = _hands;
				obj = obj2;
			}
		}
	}
}
