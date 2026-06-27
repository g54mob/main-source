using UnityEngine;
using Zenject;

namespace Restory.UserInterface.HelpActions
{
	public class HelpActionButtonsAdder : MonoBehaviour
	{
		[SerializeField]
		private HelpActionButtonsHolder helpActionButtonsHolder;

		private HelpActionButtonsService helpActionButtonsService;

		[Inject]
		private void Construct(HelpActionButtonsService helpActionButtonsService)
		{
			this.helpActionButtonsService = helpActionButtonsService;
			if (base.isActiveAndEnabled)
			{
				helpActionButtonsService.AddButtons(base.gameObject, helpActionButtonsHolder.ActionButtons);
			}
		}

		private void OnEnable()
		{
			helpActionButtonsHolder.ActionButtonAdded += ResolvedHelpActionButtonsHolder_ActionButtonAdded;
			helpActionButtonsHolder.ActionButtonRemoved += ResolvedHelpActionButtonsHolder_ActionButtonRemoved;
			if (helpActionButtonsService != null)
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
			if (helpActionButtonsService != null)
			{
				helpActionButtonsService.AddButton(base.gameObject, helpActionButton);
			}
		}

		private void ResolvedHelpActionButtonsHolder_ActionButtonRemoved(HelpAction helpActionButton)
		{
			if (helpActionButtonsService != null)
			{
				helpActionButtonsService.RemoveButton(helpActionButton);
			}
		}
	}
}
