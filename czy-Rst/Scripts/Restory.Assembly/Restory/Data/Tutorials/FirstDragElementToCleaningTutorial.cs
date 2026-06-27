using Restory.Gameplay.Tutorials.Settings;
using UnityEngine;

namespace Restory.Data.Tutorials
{
	[CreateAssetMenu(menuName = "Restory/Tutorials/FirstDragElementToCleaning", fileName = "Tutorial - 00 - FirstDragElementToCleaning", order = 0)]
	public class FirstDragElementToCleaningTutorial : TutorialBase
	{
		[SerializeField]
		private FirstDragElementToCleaningTutorialSettings settings;

		public FirstDragElementToCleaningTutorialSettings Settings => settings;
	}
}
