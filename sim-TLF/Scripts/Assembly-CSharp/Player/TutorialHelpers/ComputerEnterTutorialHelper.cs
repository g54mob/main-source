using Computer.World;
using UnityEngine;

namespace Player.TutorialHelpers
{
	public class ComputerEnterTutorialHelper : BaseTutorialHelper
	{
		[SerializeField]
		private WorldComputerEventSetter _eventSetter;

		private void OnEnable()
		{
			_eventSetter.OnEnter += TutorialEnterComputer;
		}

		private void TutorialEnterComputer()
		{
			EmitStep("useComputer");
		}
	}
}
