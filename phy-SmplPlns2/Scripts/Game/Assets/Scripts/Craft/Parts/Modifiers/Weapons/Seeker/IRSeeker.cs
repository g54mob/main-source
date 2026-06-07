using Assets.Scripts.Flight.Combat;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons.Seeker
{
	public class IRSeeker : MissileSeeker
	{
		public override string FireMessage => "Fox Two";

		public override SignatureType SignatureType => SignatureType.Infrared;

		protected override float SeekerSensitivity => 5f;

		public IRSeeker(MissileScript missile)
			: base(missile)
		{
		}
	}
}
