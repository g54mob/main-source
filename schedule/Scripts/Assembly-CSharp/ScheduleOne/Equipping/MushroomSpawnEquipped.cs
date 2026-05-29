using ScheduleOne.ObjectScripts;
using UnityEngine;

namespace ScheduleOne.Equipping
{
	public class MushroomSpawnEquipped : Equippable_Viewmodel
	{
		private const float InteractionRange = 2.5f;

		[SerializeField]
		private GameObject _taskPrefab;

		[SerializeField]
		private string InteractionLabel { get; set; }

		protected override void Update()
		{
		}

		protected virtual bool CanApplyToMushroomBed(MushroomBed bed, out string reason)
		{
			reason = null;
			return false;
		}

		protected void StartTask(MushroomBed growContainer)
		{
		}
	}
}
