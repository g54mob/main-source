using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_DraculaHand_Weapon : Weapon
{
	private TP_DraculaHand_Projectile[] _hands;

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

	public unsafe override void InternalUpdate()
	{
		//IL_0037: Expected F4, but got I4
		//IL_0040: Expected F4, but got I4
		//IL_0440: Invalid comparison between F4 and I4
		//IL_026c: Expected I, but got O
		//IL_027a: Expected I, but got O
		//IL_028a: Expected O, but got I
		//IL_030a: Expected O, but got I4
		//IL_02c6: Expected O, but got I
		//IL_057d: Expected I, but got O
		//IL_04e9: Expected I4, but got O
		//IL_04f9: Expected O, but got I
		//IL_02fc: Expected O, but got I4
		//IL_03f5: Expected O, but got I4
		//IL_03a8: Expected O, but got I4
		//IL_0324: Expected I, but got O
		//IL_036a: Expected O, but got I
		//IL_0355: Expected I, but got O
		//IL_039a: Expected O, but got I4
		//IL_035a->IL04e1: Incompatible stack heights: 1 vs 0
		base.InternalUpdate();
		if (_hands != null)
		{
			if (!_isVisible)
			{
				return;
			}
			TP_DraculaHand_Projectile[] hands = _hands;
			float num = 0f;
			float num2 = 0f;
			while (true)
			{
				if (num < (float)hands.Length)
				{
					TP_DraculaHand_Projectile tP_DraculaHand_Projectile = hands[num2];
					if (!tP_DraculaHand_Projectile._isMoving)
					{
						num2++;
						num = num2;
						continue;
					}
					break;
				}
				int nextHandToMove = _nextHandToMove;
				TP_DraculaHand_Projectile tP_DraculaHand_Projectile2 = hands[nextHandToMove];
				BaseBody body = tP_DraculaHand_Projectile2.body;
				body._enable = true;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
				tP_DraculaHand_Projectile2._isMoving = true;
				tP_DraculaHand_Projectile2._armProgress = 0f;
				tP_DraculaHand_Projectile2.SetArmFrame(1);
				((ArcadeSprite)tP_DraculaHand_Projectile2).CheckRenderer();
				SpriteAnimation component = ((ArcadeSprite)tP_DraculaHand_Projectile2)._spriteRenderer.GetComponent<SpriteAnimation>();
				component.Play("swipe", 0);
				int nextHandToMove2 = 1 - _nextHandToMove;
				_nextHandToMove = nextHandToMove2;
				break;
			}
			return;
		}
		TP_DraculaHand_Projectile[] hands2 = new TP_DraculaHand_Projectile[2];
		_hands = hands2;
		TP_DraculaHand_Projectile[] hands3 = _hands;
		int i = 0;
		TP_DraculaHand_Projectile[] hands4;
		Projectile projectile3;
		Vector2 pos = default(Vector2);
		object obj4 = default(object);
		for (Projectile projectile = null; (nint)projectile < hands3.Length; hands4[i] = (TP_DraculaHand_Projectile)projectile3, hands3 = _hands, i++, projectile = (Projectile)i)
		{
			ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
			hands4 = _hands;
			Transform cachedTrans = ((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CachedTrans;
			if (((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTrans);
				throw new NullReferenceException();
			}
			float2 ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
			if (arcadeSprite.body != null)
			{
				BaseBody body2 = arcadeSprite.body;
				ArcadeTransform arcadeTransform = body2._transform;
				arcadeTransform.position = ret;
			}
			Projectile projectile2 = base.FireOneProjectile(pos, i);
			int num3;
			if ((object)projectile2 == null)
			{
				num3 = i;
				projectile3 = null;
				continue;
			}
			nint num4 = (nint)projectile2;
			nint num5 = (nint)typeof(TP_DraculaHand_Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_DraculaHand_Projectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v744 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_DraculaHand_Projectile>)+130]");
			object obj3;
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v744 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v876 @ rax_v49+FFFFFFF8+v834 @ rax_v36*8]");
				if (0 == (nint)typeof(TP_DraculaHand_Projectile))
				{
					obj3 = 1;
					goto IL_04bf;
				}
			}
			obj3 = 0;
			goto IL_04bf;
			IL_04bf:
			bool flag = obj3 == null;
			Projectile projectile4 = null;
			if (!flag)
			{
				projectile4 = projectile2;
			}
			bool flag2 = (object)projectile4 == null;
			nint num7 = (nint)typeof(TP_DraculaHand_Projectile);
			if (!flag2)
			{
				nint num8 = (nint)hands4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				bool flag3 = obj4 == null;
				num7 = (nint)typeof(TP_DraculaHand_Projectile);
			}
			num3 = (int)projectile2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v848 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_DraculaHand_Projectile>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r8_v7 (System.Int32)+130]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v848 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_DraculaHand_Projectile>)+130]");
			object obj7;
			if (num9 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r8_v7 (System.Int32)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1027 @ rax_v44+FFFFFFF8+v1012 @ rax_v39*8]");
				if (0 == num7)
				{
					obj7 = 1;
					goto IL_0525;
				}
			}
			obj7 = 0;
			goto IL_0525;
			IL_0525:
			bool flag4 = obj7 == null;
			projectile3 = null;
			if (!flag4)
			{
				projectile3 = projectile2;
			}
		}
	}

	private void UpdateHands()
	{
		//IL_0041: Expected O, but got I4
		//IL_004a: Expected O, but got I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		if (!_isVisible)
		{
			return;
		}
		TP_DraculaHand_Projectile[] hands = _hands;
		TP_DraculaHand_Projectile[] hands2 = _hands;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj < hands.Length)
			{
				TP_DraculaHand_Projectile tP_DraculaHand_Projectile = hands2[obj2];
				if (!tP_DraculaHand_Projectile._isMoving)
				{
					obj2++;
					obj = obj2;
					continue;
				}
				break;
			}
			int nextHandToMove = _nextHandToMove;
			TP_DraculaHand_Projectile tP_DraculaHand_Projectile2 = hands2[nextHandToMove];
			BaseBody body = tP_DraculaHand_Projectile2.body;
			body._enable = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			tP_DraculaHand_Projectile2._isMoving = true;
			tP_DraculaHand_Projectile2._armProgress = 0f;
			tP_DraculaHand_Projectile2.SetArmFrame(1);
			((ArcadeSprite)tP_DraculaHand_Projectile2).CheckRenderer();
			SpriteAnimation component = ((ArcadeSprite)tP_DraculaHand_Projectile2)._spriteRenderer.GetComponent<SpriteAnimation>();
			component.Play("swipe", 0);
			int nextHandToMove2 = 1 - _nextHandToMove;
			_nextHandToMove = nextHandToMove2;
			break;
		}
	}

	public override void SetVisible(bool visible)
	{
		//IL_003c: Expected O, but got I4
		//IL_0045: Expected O, but got I4
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		bool flag = _hands == null;
		_isVisible = visible;
		if (flag)
		{
			return;
		}
		TP_DraculaHand_Projectile[] hands = _hands;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < hands.Length)
		{
			TP_DraculaHand_Projectile[] hands2 = _hands;
			TP_DraculaHand_Projectile tP_DraculaHand_Projectile = hands2[obj2];
			BaseBody body = tP_DraculaHand_Projectile.body;
			body._enable = visible;
			if (!visible)
			{
				TP_DraculaHand_Projectile[] hands3 = _hands;
				TP_DraculaHand_Projectile tP_DraculaHand_Projectile2 = hands3[obj2];
				tP_DraculaHand_Projectile2._isMoving = visible;
			}
			hands = _hands;
			obj2++;
			obj = obj2;
		}
	}
}
