using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.ObjectScripts;
using UnityEngine;

namespace ScheduleOne.Equipping
{
	public class Equippable_SprayBottle : Equippable_Viewmodel
	{
		private const float InteractionRange = 2.5f;

		[SerializeField]
		private GameObject _sprayablePrefab;

		private WaterContainerInstance _waterContainerInstance;

		[SerializeField]
		private string InteractionLabel { get; set; }

		protected override void Update()
		{
		}

		protected virtual bool CanSpray(GrowContainer growContainer, out string reason)
		{
			reason = null;
			return false;
		}

		protected void StartSprayTask(MushroomBed growContainer)
		{
		}
	}
}
