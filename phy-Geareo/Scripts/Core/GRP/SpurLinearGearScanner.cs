namespace GRP
{
	public class SpurLinearGearScanner : GearScanner
	{
		public bool flipped;

		public SpurLinearGearScanner(bool flipped = false)
		{
		}

		public override GearContact CheckContact(IGear a, IGear b)
		{
			return default(GearContact);
		}

		public override GearJoint CreateJoint(IGear a, IGear b, GearContact contact)
		{
			return null;
		}
	}
}
