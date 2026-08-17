using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Mace1CritLinger_Projectile : Projectile
{
	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0033: Expected O, but got I4
		//IL_0066: Expected O, but got I4
		//IL_0066: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		float num = weapon.PArea();
		float xScale = default(float);
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setAlpha(0f);
		BaseBody baseBody = body.setCircle(12f, (float?)(object)0, (float?)(object)0);
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj2 = default(object);
			if (obj2 == null)
			{
			}
		}
	}
}
