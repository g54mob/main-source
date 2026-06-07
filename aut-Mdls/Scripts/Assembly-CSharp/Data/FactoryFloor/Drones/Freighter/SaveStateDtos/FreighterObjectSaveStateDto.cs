using System;
using Data.SaveData;
using UnityEngine;

namespace Data.FactoryFloor.Drones.Freighter.SaveStateDtos
{
	[Serializable]
	public class FreighterObjectSaveStateDto : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public string Name;

		public Color Color;

		public bool IsPaused;

		public bool IsMoving;

		public FreighterSlotsBehaviourSaveStateDto SlotsBehaviourSaveStateDto;

		public FreighterMovementBehaviourSaveStateDto MovementBehaviourSaveStateDto;

		public FreighterPathBehaviourSaveStateDto PathBehaviourSaveStateDto;

		public FreighterObjectSaveStateDto()
			: base(0)
		{
		}
	}
}
