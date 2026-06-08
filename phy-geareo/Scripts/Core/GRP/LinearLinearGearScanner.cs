namespace GRP
{
	public class LinearLinearGearScanner : GearScanner
	{
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
