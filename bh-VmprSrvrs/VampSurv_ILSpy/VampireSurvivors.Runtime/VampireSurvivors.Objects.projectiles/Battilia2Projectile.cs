using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;

namespace VampireSurvivors.Objects.Projectiles;

public class Battilia2Projectile : BattiliaProjectile
{
	private uint[] shadowTints = new uint[3] { 16711935u, 16711884u, 13369599u };

	protected override void SetColors()
	{
		//IL_004a: Expected O, but got I4
		uint[] array = shadowTints;
		object obj = Random.RandomRangeInt(0, array.Length);
		PhaserSprite phaserSprite = _shadowSprite.setTintFill(isEnabled: true, array[obj]);
	}

	protected override void SetAnims()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3F7F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = _indexInWeapon == 0;
		PhaserSprite batSprite = _batSprite;
		if (!flag)
		{
			if (_indexInWeapon >= 10)
			{
				if (_indexInWeapon >= 20)
				{
					batSprite._spriteAnimation.SetAnimation("idle3");
				}
				else
				{
					batSprite._spriteAnimation.SetAnimation("idle2");
				}
			}
			else
			{
				batSprite._spriteAnimation.SetAnimation("idle1");
			}
		}
		else
		{
			batSprite._spriteAnimation.SetAnimation("idle4");
		}
	}

	public Battilia2Projectile()
	{
		fixedDuration = 3000f;
		shadowTint = 16711680u;
		base.isFirstUpdate = true;
		((Projectile)this)._002Ector();
	}
}
