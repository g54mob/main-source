namespace Assets.Scripts.Flight.Combat.Bullets
{
	public interface IBulletImpact
	{
		bool OnBulletImpact(in Bullet bullet, BulletData bulletData);
	}
}
