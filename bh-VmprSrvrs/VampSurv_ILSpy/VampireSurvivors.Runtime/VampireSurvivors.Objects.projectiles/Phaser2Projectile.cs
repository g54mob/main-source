using UnityEngine;

namespace VampireSurvivors.Objects.Projectiles;

public class Phaser2Projectile : PhaserProjectile
{
	protected override void Setuppo()
	{
		_screenScale = 100f;
		_scaleDuration = 200f;
		_projectileScale = 36f;
		heigthScale = 0.45f;
		whiteScale = 0.35f;
		_colors = new uint[11]
		{
			8912896u, 11206638u, 13386956u, 52309u, 170u, 15658615u, 14518357u, 6702080u, 16742263u, 11206502u,
			35071u
		};
	}

	public override void SetSelfColor()
	{
		//IL_0040: Expected O, but got I4
		uint[] colors = _colors;
		object obj = Random.RandomRangeInt(0, colors.Length);
		ArcadeSprite arcadeSprite = setTint(colors[obj]);
	}

	public override void SetSelfScale()
	{
		//IL_002f: Expected O, but got I4
		float num = _weapon.PArea();
		object obj = default(object);
		float xScale = (float)obj * heigthScale;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
	}

	public Phaser2Projectile()
	{
		_screenScale = 100f;
		_scaleDuration = 200f;
		_projectileScale = 36f;
		heigthScale = 0.35f;
		whiteScale = 0.65f;
		_colors = new uint[4] { 16711680u, 16776960u, 255u, 16711935u };
		((Projectile)this)._002Ector();
	}
}
