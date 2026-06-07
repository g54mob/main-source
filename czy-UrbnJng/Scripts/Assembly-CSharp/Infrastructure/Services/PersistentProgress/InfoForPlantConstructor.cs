using System;
using UnityEngine;

namespace Infrastructure.Services.PersistentProgress
{
	[Serializable]
	public class InfoForPlantConstructor
	{
		public float worldPositionX;

		public float worldPositionY;

		public float worldPositionZ;

		public float rotation;

		public int objectSOID;

		public Vector2Int size;

		public bool hasVariant;

		public int variantIndex;

		public int score;

		public int floorPotIndex;

		public int wallPotIndex;

		public int levelNumber;

		public string itemGUID;

		public InfoForPlantConstructor(InfoForPlantConstructor info)
		{
			worldPositionX = info.worldPositionX;
			worldPositionY = info.worldPositionY;
			worldPositionZ = info.worldPositionZ;
			rotation = info.rotation;
			objectSOID = info.objectSOID;
			size = info.size;
			hasVariant = info.hasVariant;
			variantIndex = info.variantIndex;
			score = info.score;
			floorPotIndex = info.floorPotIndex;
			wallPotIndex = info.wallPotIndex;
			levelNumber = info.levelNumber;
			itemGUID = info.itemGUID;
		}

		public InfoForPlantConstructor()
		{
			worldPositionX = 0f;
			worldPositionY = 0f;
			worldPositionZ = 0f;
			objectSOID = -1;
			size = Vector2Int.zero;
			hasVariant = false;
			rotation = 0f;
			variantIndex = 0;
			score = 0;
			floorPotIndex = 0;
			wallPotIndex = 0;
			levelNumber = 0;
			itemGUID = "";
		}
	}
}
