using Cpp2ILInjected;
using Unity.Mathematics;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Guns3Projectile : Projectile
{
	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0022: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_007a: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(10f, (float?)(object)0, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		float num = weapon.PArea();
		float xScale = default(float);
		ArcadeSprite arcadeSprite3 = setScale(xScale, (float?)(object)0);
	}

	public void SetTarget(double ang)
	{
		//IL_0093: Expected I, but got O
		//IL_006b: Expected O, but got F4
		nint num = (nint)typeof(ArcadePhysics);
		BaseBody baseBody = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm7,xmm6\"");
		float num2 = GameManager.ProjectileSpeed * 10f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		float num3 = 0f * num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		float num4 = 0f * num2;
		baseBody._velocity = (float2)num3;
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && --_penetrating <= 0)
		{
			base.Despawn();
		}
	}
}
