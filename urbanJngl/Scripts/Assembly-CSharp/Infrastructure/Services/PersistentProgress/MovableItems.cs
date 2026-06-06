using System;

namespace Infrastructure.Services.PersistentProgress
{
	[Serializable]
	public class MovableItems
	{
		public string ID;

		public float worldPositionX;

		public float worldPositionY;

		public float worldPositionZ;

		public float rotation;

		public bool isWorkingItem;

		public bool isWorking;

		public bool secondProjectorOn;

		public int levelNumber;

		public string ItemGUID;

		public MovableItems(string id, float x, float y, float z, float rotation, bool isWorkingItem, bool isWorking, bool secondProjectorOn, int levelNumber, string itemGuid)
		{
			ID = id;
			worldPositionX = x;
			worldPositionY = y;
			worldPositionZ = z;
			this.rotation = rotation;
			this.isWorkingItem = isWorkingItem;
			this.isWorking = isWorking;
			this.secondProjectorOn = secondProjectorOn;
			this.levelNumber = levelNumber;
			ItemGUID = itemGuid;
		}

		public MovableItems()
		{
		}
	}
}
