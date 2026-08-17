using Cpp2ILInjected;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_BladeCrossbow2Projectile : FB_BladeCrossbowProjectile
{
	private SpriteTrail _Trail;

	protected override string _FrameName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A410B]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "BladeCB";
		}
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		SpriteTrail spriteTrail = _Trail.setVisible(b: true);
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		((Projectile)this).Despawn();
		SpriteTrail spriteTrail = _Trail.setVisible(b: false);
	}
}
