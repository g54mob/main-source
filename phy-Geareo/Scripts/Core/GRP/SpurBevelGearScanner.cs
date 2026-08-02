namespace GRP
{
	public class SpurBevelGearScanner : GearScanner
	{
		public bool flipped;

		public SpurBevelGearScanner(bool flipped = false)
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

		public bool HasContact(IGear a, IGear b, out bool inverted)
		{
			inverted = default(bool);
			return false;
		}
	}
}
