using Assets.Scripts.Flight.Combat;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons.Seeker
{
	public class AntiRadiationSeeker : MissileSeeker
	{
		public override SignatureType SignatureType => SignatureType.Radiation;

		protected override float SeekerSensitivity => 5f;

		public AntiRadiationSeeker(MissileScript missile)
			: base(missile)
		{
		}
	}
}
