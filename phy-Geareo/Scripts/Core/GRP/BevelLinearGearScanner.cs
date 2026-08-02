namespace GRP
{
	public class BevelLinearGearScanner : GearScanner
	{
		public bool flipped;

		public BevelLinearGearScanner(bool flipped = false)
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
