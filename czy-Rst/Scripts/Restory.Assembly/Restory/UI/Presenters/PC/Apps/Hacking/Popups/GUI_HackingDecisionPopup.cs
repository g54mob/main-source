using System;
using UnityEngine;

namespace Restory.UI.Presenters.PC.Apps.Hacking.Popups
{
	public class GUI_HackingDecisionPopup : MonoBehaviour
	{
		[SerializeField]
		private GUI_HackingDecisionButton firstOptionButton;

		[SerializeField]
		private GUI_HackingDecisionButton secondOptionButton;

		private HackingDecisionEvent decisionEvent;

		private GUI_HackingDecisionButton selectedButton;

		public float Bonus => decisionEvent.Bonus;

		public float Penalty => decisionEvent.Penalty;

		public event Action<bool> OnDecisionMade;

		public void Activate(HackingDecisionEvent decisionEvent)
		{
			base.gameObject.SetActive(value: true);
			this.decisionEvent = decisionEvent;
			ResolveButtonSelected(firstOptionButton);
		}

		private void OnEnable()
		{
			firstOptionButton.OnClick += ResolveButtonClick;
			firstOptionButton.OnSelected += ResolveButtonSelected;
			secondOptionButton.OnClick += ResolveButtonClick;
			secondOptionButton.OnSelected += ResolveButtonSelected;
		}

		private void OnDisable()
		{
			firstOptionButton.OnClick -= ResolveButtonClick;
			firstOptionButton.OnSelected -= ResolveButtonSelected;
			secondOptionButton.OnClick -= ResolveButtonClick;
			secondOptionButton.OnSelected -= ResolveButtonSelected;
		}

		public void SwitchButton()
		{
			ResolveButtonSelected((selectedButton == firstOptionButton) ? secondOptionButton : firstOptionButton);
		}

		public void MakeDecision()
		{
			ResolveButtonClick(selectedButton);
		}

		private void ResolveButtonSelected(GUI_HackingDecisionButton button)
		{
			if (button == firstOptionButton)
			{
				selectedButton = firstOptionButton;
				firstOptionButton.Select();
				secondOptionButton.Deselect();
			}
			else
			{
				selectedButton = secondOptionButton;
				secondOptionButton.Select();
				firstOptionButton.Deselect();
			}
		}

		private void ResolveButtonClick(GUI_HackingDecisionButton button)
		{
			bool obj = (button == firstOptionButton && decisionEvent.Decision < 0.5f) || (button == secondOptionButton && decisionEvent.Decision > 0.5f);
			this.OnDecisionMade?.Invoke(obj);
			base.gameObject.SetActive(value: false);
		}
	}
}
