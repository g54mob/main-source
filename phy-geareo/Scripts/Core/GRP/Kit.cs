using System.Collections.Generic;
using Rhizomatic;

namespace GRP
{
	public class Kit
	{
		public string key;

		public Exhibit exhibit;

		public List<KitPart> parts;

		public List<KitStep> steps;

		public KitData Serialize()
		{
			return null;
		}

		public static Kit FromData(KitData data, Context context)
		{
			return null;
		}

		public static Kit FromData(KitData data, EntityManagerConfig parts)
		{
			return null;
		}
	}
}
