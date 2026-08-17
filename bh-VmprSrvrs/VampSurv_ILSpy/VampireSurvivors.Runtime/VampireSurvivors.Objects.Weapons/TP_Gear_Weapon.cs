using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Gear_Weapon : TP_Clockwork_Weapon
{
	public override float PArea()
	{
		//IL_004c: Invalid comparison between F4 and I4
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
			float num2 = num2 - 1f;
			if (num2 > 0f)
			{
				num2 *= 0.65f;
			}
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null)
			{
				float num3 = num2 + 1f;
				return num3 * currentWeaponData._003Carea_003Ek__BackingField;
			}
		}
		throw new NullReferenceException();
	}

	public override void FireProjectiles(Vector2 pos)
	{
		//IL_009a: Expected O, but got F4
		//IL_0079: Expected O, but got F4
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 * ((float)Math.PI * 2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num2 = num * renderer.width;
		float num3 = num2 * 0.35f;
		float num4 = num3 + (float)pos;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Projectile projectile = base.FireOneProjectile((Vector2)num4, 0, _targetTransform);
	}
}
