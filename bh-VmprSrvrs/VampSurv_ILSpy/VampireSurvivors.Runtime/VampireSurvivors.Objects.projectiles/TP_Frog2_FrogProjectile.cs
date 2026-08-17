using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Frog2_FrogProjectile : TP_Frog_Projectile
{
	public TP_Frog2_FrogProjectile()
	{
		//IL_001c: Expected O, but got I4
		base.SquashedScale = (Vector2)0;
		_ = 1092616192;
		List<Vector3> frogSpritePositions = new List<Vector3>();
		base._frogSpritePositions = frogSpritePositions;
		((Projectile)this)._002Ector();
	}
}
