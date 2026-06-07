using ScheduleOne.Growing;
using ScheduleOne.PlayerTasks;
using UnityEngine;

namespace ScheduleOne.Equipping
{
	public class Equippable_Pourable : Equippable_Viewmodel
	{
		private const float InteractionRange = 2.5f;

		[SerializeField]
		public Pourable PourablePrefab;

		[field: SerializeField]
		public string InteractionLabel { get; set; }

		protected virtual void Awake()
		{
		}

		protected override void Update()
		{
		}

		protected virtual void StartPourTask(GrowContainer growContainer)
		{
		}

		protected virtual bool CanPour(GrowContainer growContainer, out string reason)
		{
			reason = null;
			return false;
		}
	}
}
