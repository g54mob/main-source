using ScheduleOne.Interaction;
using ScheduleOne.ObjectScripts;
using UnityEngine;

namespace ScheduleOne.Growing
{
	public class MushroomBedInteraction : GrowContainerInteraction
	{
		[SerializeField]
		private MushroomBed _bed;

		protected override void Awake()
		{
		}

		protected override bool TryGetFallbackInteractionMessage(out string message, out InteractableObject.EInteractableState state)
		{
			message = null;
			state = default(InteractableObject.EInteractableState);
			return false;
		}
	}
}
