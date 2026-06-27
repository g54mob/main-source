using Restory.Constants;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class ToggleElementView : ElementView
	{
		[Header("Animation settings")]
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private string isActiveFlagName = "IsActive";

		private IPowerUpElement powerUpElement;

		protected override bool IsActivatable => true;

		private void Awake()
		{
			if (!(element is IPowerUpElement powerUpElement))
			{
				Debug.LogError("element " + element.Info.ID + " is not IPowerUpElement");
			}
			else
			{
				this.powerUpElement = powerUpElement;
			}
		}

		protected override void OnEnable()
		{
			if (powerUpElement != null)
			{
				powerUpElement.OnSwitched += ResolvePowerElementSwitched;
			}
			base.OnEnable();
		}

		protected override void OnDisable()
		{
			if (powerUpElement != null)
			{
				powerUpElement.OnSwitched -= ResolvePowerElementSwitched;
			}
			base.OnDisable();
		}

		public void OnAnimationComplete()
		{
			powerUpElement.CompleteSwitchInteraction();
		}

		private void ResolvePowerElementSwitched()
		{
			animator.SetBool(isActiveFlagName, powerUpElement.IsOn);
			animator.SetTrigger(ProjectConstants.Animations.ActivateTrigger);
		}
	}
}
