using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Slash1_Weapon : Weapon
{
	protected override void OnStart()
	{
		//IL_0032: Expected I, but got O
		base.OnStart();
		base._003CCanCrit_003Ek__BackingField = true;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Slash1_Weapon>)+5C0]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_projectilePool, ((Equipment)this)._003COwner_003Ek__BackingField, collideCallback, processCallback, callbackContext);
		Collider collider2 = collider.setName("Projectiles>Owner");
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
		CheckBeginningArcana();
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	protected virtual bool OnBulletOverlapsOwner(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0152: Expected I4, but got O
		//IL_0064: Expected I, but got O
		//IL_006c: Expected I, but got O
		//IL_007c: Expected O, but got I
		//IL_00fc: Expected O, but got I4
		//IL_00b8: Expected O, but got I
		//IL_00ee: Expected O, but got I4
		Projectile component;
		object obj3;
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				component = gameObject.GetComponent<Projectile>();
				if ((object)component == null)
				{
					goto IL_013e;
				}
				nint num = (nint)typeof(TP_Slash1Projectile);
				nint num2 = (nint)component;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Slash1Projectile>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Slash1Projectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v12+FFFFFFF8+v127 @ rcx_v6*8]");
					if (0 == (nint)typeof(TP_Slash1Projectile))
					{
						obj3 = 1;
						goto IL_016f;
					}
				}
				obj3 = 0;
				goto IL_016f;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_013e:
		return false;
		IL_016f:
		bool flag = obj3 == null;
		TP_Slash1Projectile tP_Slash1Projectile = null;
		if (!flag)
		{
			tP_Slash1Projectile = (TP_Slash1Projectile)component;
		}
		if ((object)tP_Slash1Projectile != null && tP_Slash1Projectile._isGoingBack)
		{
			tP_Slash1Projectile.StartDespawn();
		}
		goto IL_013e;
	}
}
