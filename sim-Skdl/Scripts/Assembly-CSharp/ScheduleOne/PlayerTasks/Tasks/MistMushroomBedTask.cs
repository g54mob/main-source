using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using UnityEngine;

namespace ScheduleOne.PlayerTasks.Tasks
{
	public class MistMushroomBedTask : Task
	{
		private const float TARGET_SPRAY_RADIUS = 0.15f;

		private const float TARGET_SPRAY_DISTANCE = 0.35f;

		private MushroomBed _mushroomBed;

		private Sprayable _sprayable;

		private GameObject _sprayableObj;

		private WaterContainerInstance _waterContainerInstance;

		public override string TaskName { get; protected set; }

		public MistMushroomBedTask(MushroomBed mushroomBed, ItemInstance item, GameObject sprayablePrefab)
		{
		}

		private void OnSuccessfulSpray()
		{
		}

		private void OnSpray()
		{
		}

		public override void StopTask()
		{
		}
	}
}
