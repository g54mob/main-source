using System;
using Data.SaveData;
using SaveData.FactoryFloor.SaveStates.Drones;
using UnityEngine;

namespace Data.FactoryFloor.Drones.Freighter.SaveStateDtos
{
	[Serializable]
	public class FreighterMovementBehaviourSaveStateDto : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public Vector3 Position;

		public BaseDroneSaveStateDto DroneSaveStateDto;

		public FreighterMovementBehaviourSaveStateDto()
			: base(0)
		{
		}
	}
}
