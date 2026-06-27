using UnityEngine;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class SonicBathView : MonoBehaviour
	{
		[SerializeField]
		private SonicBathTriggerController triggerController;

		[SerializeField]
		private SonicBathElementFitter elementFitter;

		[SerializeField]
		private SonicBathOccupancyIndicator occupancyIndicator;

		[SerializeField]
		private SonicBathToggleButton toggleButton;

		[SerializeField]
		private SonicBathCover cover;

		[SerializeField]
		private SonicBathTimer timer;

		[SerializeField]
		private SonicBathCleaningEffectsPlayer cleaningEffectsPlayer;

		public SonicBathTriggerController TriggerController => triggerController;

		public SonicBathElementFitter ElementFitter => elementFitter;

		public SonicBathOccupancyIndicator OccupancyIndicator => occupancyIndicator;

		public SonicBathToggleButton ToggleButton => toggleButton;

		public SonicBathTimer Timer => timer;

		public SonicBathCover Cover => cover;

		public SonicBathCleaningEffectsPlayer CleaningEffectsPlayer => cleaningEffectsPlayer;
	}
}
