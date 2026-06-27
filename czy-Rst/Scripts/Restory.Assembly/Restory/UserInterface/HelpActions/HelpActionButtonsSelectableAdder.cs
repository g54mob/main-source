using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Restory.UserInterface.HelpActions
{
	public sealed class HelpActionButtonsSelectableAdder : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler
	{
		[SerializeField]
		private HelpActionButtonsHolder helpActionButtonsHolder;

		private HelpActionButtonsService helpActionButtonsService;

		private bool isSelected;

		[Inject]
		private void Construct(HelpActionButtonsService helpActionButtonsService)
		{
			this.helpActionButtonsService = helpActionButtonsService;
			if (base.isActiveAndEnabled && isSelected)
			{
				helpActionButtonsService.AddButtons(base.gameObject, helpActionButtonsHolder.ActionButtons);
			}
		}

		private void OnEnable()
		{
			helpActionButtonsHolder.ActionButtonAdded += ResolvedHelpActionButtonsHolder_ActionButtonAdded;
			helpActionButtonsHolder.ActionButtonRemoved += ResolvedHelpActionButtonsHolder_ActionButtonRemoved;
			if (helpActionButtonsService != null && isSelected)
			{
				helpActionButtonsService.AddButtons(base.gameObject, helpActionButtonsHolder.ActionButtons);
			}
		}

		private void OnDisable()
		{
			helpActionButtonsHolder.ActionButtonAdded -= ResolvedHelpActionButtonsHolder_ActionButtonAdded;
			helpActionButtonsHolder.ActionButtonRemoved -= ResolvedHelpActionButtonsHolder_ActionButtonRemoved;
			if (helpActionButtonsService != null)
			{
				helpActionButtonsService.RemoveButtons(helpActionButtonsHolder.ActionButtons);
			}
		}

		private void ResolvedHelpActionButtonsHolder_ActionButtonAdded(HelpAction helpActionButton)
		{
			if (!(helpActionButtonsService == null) && isSelected)
			{
				helpActionButtonsService.AddButton(base.gameObject, helpActionButton);
			}
		}

		private void ResolvedHelpActionButtonsHolder_ActionButtonRemoved(HelpAction helpActionButton)
		{
			if (!(helpActionButtonsService == null) && isSelected)
			{
				helpActionButtonsService.RemoveButton(helpActionButton);
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			isSelected = true;
			if (base.isActiveAndEnabled && !(helpActionButtonsService == null))
			{
				helpActionButtonsService.AddButtons(base.gameObject, helpActionButtonsHolder.ActionButtons);
			}
		}

		public void OnDeselect(BaseEventData eventData)
		{
			isSelected = false;
			if (base.isActiveAndEnabled && !(helpActionButtonsService == null))
			{
				helpActionButtonsService.RemoveButtons(helpActionButtonsHolder.ActionButtons);
			}
		}
	}
}
