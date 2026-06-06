using System;

namespace Infrastructure.Services.PersistentProgress
{
	[Serializable]
	public class InfoForObjectsOnLevel
	{
		public int ID;

		public bool isUnlocked;

		public int quantity;

		public bool isSpawned;
	}
}
