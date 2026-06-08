using UnityEngine;

namespace GRP
{
	public class KitPart
	{
		public Id id;

		public Module module;

		public int count;

		public Texture2D image;

		public KitPartData Serialize()
		{
			return null;
		}

		public static KitPart FromData(KitPartData data, EntityManagerConfig parts)
		{
			return null;
		}
	}
}
