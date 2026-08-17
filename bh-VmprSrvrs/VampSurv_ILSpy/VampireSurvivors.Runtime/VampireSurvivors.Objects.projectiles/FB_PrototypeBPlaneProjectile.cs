using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_PrototypeBPlaneProjectile : FB_RapidFireProjectile
{
	protected override Vector2 calDirection()
	{
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
				Vector2 result = default(Vector2);
				return result;
			}
		}
		return (Vector2)new NullReferenceException();
	}
}
