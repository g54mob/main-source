using PajamaLlama.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PajamaLlama.UI
{
	public class RadialMenuOption : MonoBehaviour
	{
		[SerializeField]
		private Image _background;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private Transition _transition;

		[SerializeField]
		private string _interactableParameter = "Interactable";

		[SerializeField]
		[MinMaxRangeFloat(0f, 360f)]
		private RangedFloat _range = new RangedFloat(0f, 360f);

		public ActionBase Action { get; private set; }

		public bool IsActive { get; private set; }

		public RangedFloat Range => _range;

		private void OnEnable()
		{
			Enable(Action);
		}

		public void Enable(ActionBase action)
		{
			if ((bool)action && action.IsEnabled)
			{
				Action = action;
				IsActive = true;
				_icon.sprite = action.GetIcon();
				_transition.SetAnimatorBool(_interactableParameter, action.IsInteractable);
				_transition.SetNormal();
			}
			else
			{
				Disable();
			}
		}

		public void Disable()
		{
			Action = null;
			IsActive = false;
			_transition.SetDisabled();
		}

		public void Select(RadialMenu radialMenu)
		{
			if (IsActive)
			{
				Action.RadialMenuSelect(radialMenu);
				_transition.SetSelected();
			}
		}

		public void Deselect(RadialMenu radialMenu)
		{
			if (IsActive)
			{
				Action.RadialMenuDeselect(radialMenu);
				_transition.SetNormal();
			}
		}
	}
}
