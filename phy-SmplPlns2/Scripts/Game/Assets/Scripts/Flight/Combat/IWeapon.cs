namespace Assets.Scripts.Flight.Combat
{
	public interface IWeapon
	{
		int CurrentAmmo { get; }

		TrackedTarget CurrentTarget { get; set; }

		string CustomName { get; }

		WeaponFunction Function { get; }

		bool IsArmed { get; }

		bool IsDestroyed { get; }

		TargetingStyle TargetingStyle { get; }

		int TotalAmmo { get; }

		WeaponType Type { get; }

		void Fire(TrackedTarget trackedTarget);
	}
}
