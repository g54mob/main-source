namespace Assets.Scripts.Flight.Combat
{
	public interface IMissile : IWeapon
	{
		float MaxRange { get; }

		float MaxTargetingAngle { get; }

		float MinRange { get; }
	}
}
