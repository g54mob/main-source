using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Simulator
{
	public class NavButton : InteractableNavElement, ITooltipDisplayer, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[Header("Button")]
		[SerializeField]
		private Button m_button;

		[Header("Text")]
		[SerializeField]
		private bool m_hasText;

		[SerializeField]
		private SimulatorText m_text;

		public Button Button => m_button;

		public SimulatorText Text => m_text;

		public event Action<bool> InteractabilityChanged;

		protected override void OnEnable()
		{
			base.OnEnable();
			DoStateTransition(SelectionState.Normal, instant: true);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			PointerEventData eventData = new PointerEventData(EventSystem.current)
			{
				button = PointerEventData.InputButton.Left
			};
			OnPointerUp(eventData);
			OnPointerExit(eventData);
			OnDeselect(eventData);
		}

		public override bool IsInteractable()
		{
			if (base.IsInteractable())
			{
				return m_button.IsInteractable();
			}
			return false;
		}

		public void SetInteractable(bool value)
		{
			if (base.interactable != value)
			{
				this.InteractabilityChanged?.Invoke(value);
			}
			base.interactable = value;
			m_button.interactable = value;
			OverrideTransition((!value) ? Transitioner.ESelectionState.Disabled : Transitioner.ESelectionState.Normal, instant: false);
		}

		protected override IEnumerable<Selectable> GetChildSelectables()
		{
			if (m_button != null)
			{
				yield return m_button;
			}
			foreach (Selectable childSelectable in base.GetChildSelectables())
			{
				yield return childSelectable;
			}
		}
	}
}
