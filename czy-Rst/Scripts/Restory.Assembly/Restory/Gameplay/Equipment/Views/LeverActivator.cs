using Restory.Constants;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Views
{
	public class LeverActivator : EquipmentActivatorBase
	{
		[SerializeField]
		private Animator LeverAnimator;

		[SerializeField]
		private GameObject keyModel;

		public override void RestoreState(bool isActivated)
		{
			ToggleLeverObjects(isActivated);
		}

		public override void Activate()
		{
			ToggleLeverObjects(isActivated: true);
			LeverAnimator.SetTrigger(ProjectConstants.Animations.ActivateTrigger);
		}

		private void ToggleLeverObjects(bool isActivated)
		{
			base.IsActivated = isActivated;
			keyModel.gameObject.SetActive(isActivated);
		}
	}
}
