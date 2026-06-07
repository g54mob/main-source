using Assets.Scripts.Flight.Combat;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons.Seeker
{
	public class RadarSeeker : MissileSeeker
	{
		public override string FireMessage
		{
			get
			{
				if (base.Missile.TargetingStyle == TargetingStyle.ContinuousLock)
				{
					return "Fox One";
				}
				if (base.Missile.TargetingStyle == TargetingStyle.StandardLock)
				{
					return "Fox Three";
				}
				return null;
			}
		}

		public override SignatureType SignatureType => SignatureType.Radar;

		protected override float SeekerSensitivity => 25f;

		public RadarSeeker(MissileScript missile)
			: base(missile)
		{
		}
	}
}
