public class ClownBall : Projectile
{
	public bool blue;

	public override void HitTrigger(Monster monster)
	{
		string color;
		string color2;
		if (blue)
		{
			color = "0098DC";
			color2 = "99E65F";
		}
		else
		{
			color = "EA323C";
			color2 = "FFC825";
		}
		Dungeon.Instance.animationManager.CreateGibs(color, base.transform.position, 2f);
		Dungeon.Instance.animationManager.CreateGibs(color2, base.transform.position, 2f);
		base.HitTrigger(monster);
	}

	private void OnDestroy()
	{
	}
}
