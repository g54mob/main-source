namespace GRP
{
	public class SpurSpurGearScanner : GearScanner
	{
		public override GearContact CheckContact(IGear a, IGear b)
		{
			return default(GearContact);
		}

		public override GearJoint CreateJoint(IGear a, IGear b, GearContact contact)
		{
			return null;
		}

		public static GearContact HasContact(IGear a, IGear b)
		{
			return default(GearContact);
		}
	}
}
