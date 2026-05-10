using System;
using NaisuPorter.CommonScripts;
using UnityEngine;

namespace __Project__.Scripts.FloorPaintSystem
{
	[Serializable]
	public class FloorBoxSaveData
	{
		public int floorId;

		public int floorCount;

		public SerializableVector3 floorPosition;

		public bool isOpen;

		public FloorBoxSaveData(int floorId, int floorCount, Vector3 position, bool isOpen)
		{
		}

		public FloorBoxSaveData()
		{
		}
	}
}
