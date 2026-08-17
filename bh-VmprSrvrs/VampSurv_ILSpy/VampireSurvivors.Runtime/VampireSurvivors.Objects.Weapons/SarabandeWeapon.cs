namespace VampireSurvivors.Objects.Weapons;

public class SarabandeWeapon : Weapon
{
	public bool UseJuliaAttack;

	public float _healAmount;

	public override float PAmount()
	{
		return 1f;
	}

	public override float PPower()
	{
		return _healAmount;
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}
}
