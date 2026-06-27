using Restory.Gameplay.Tutorials.Settings;
using UnityEngine;

namespace Restory.Data.Tutorials
{
	[CreateAssetMenu(menuName = "Restory/Tutorials/FirstDeviceInteraction", fileName = "Tutorial - 00 - FirstDeviceInteraction", order = 0)]
	public class FirstDeviceInteractionTutorial : TutorialBase
	{
		[SerializeField]
		private FirstDeviceInteractionTutorialSettings settings;

		public FirstDeviceInteractionTutorialSettings Settings => settings;
	}
}
