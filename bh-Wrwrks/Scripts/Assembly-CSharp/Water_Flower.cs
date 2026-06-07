using UnityEngine;

public class Water_Flower : Projectile
{
	public int index;

	public void Explode()
	{
		string colorBorder = "";
		string colorBG = "";
		switch (index)
		{
		case 0:
		case 5:
			colorBorder = "C42430";
			colorBG = "EA323C";
			break;
		case 3:
		case 4:
			colorBorder = "F389F5";
			colorBG = "FDD2ED";
			break;
		case 1:
			colorBorder = "0098DC";
			colorBG = "00CDF9";
			break;
		case 2:
			colorBorder = "FFC825";
			colorBG = "FFEB57";
			break;
		}
		Projectile projectile = Dungeon.Instance.animationManager.CreateExplosion(colorBG, colorBorder, 10, insta: true, ticks: false, spin: true, shake: false);
		Dungeon.Instance.audioManager.PlaySoundRandomized(AudioManager.Sound.Explosion_Plant, 0.9f, 1.1f, 1f);
		projectile.forceDamage = forceDamage;
		projectile.source = source;
		projectile.transform.position = base.transform.position;
		projectile.transform.localScale = Vector3.one * 0.75f;
	}

	public override void HitTrigger(Monster monster)
	{
		Explode();
		base.HitTrigger(monster);
	}
}
