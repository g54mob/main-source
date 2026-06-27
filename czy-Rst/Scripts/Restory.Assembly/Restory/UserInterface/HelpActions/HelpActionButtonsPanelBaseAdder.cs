using Restory.UserInterface.GameplayMenu;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.HelpActions
{
	public class HelpActionButtonsPanelBaseAdder : MonoBehaviour
	{
		[SerializeField]
		private GUI_PanelBase panelBase;

		[SerializeField]
		private HelpActionButtonsHolder helpActionButtonsHolder;

		private HelpActionButtonsService helpActionButtonsService;

		[Inject]
		private void Construct(HelpActionButtonsService helpActionButtonsService)
		{
			this.helpActionButtonsService = helpActionButtonsService;
			if (base.isActiveAndEnabled && panelBase.IsActive)
			{
				helpActionButtonsService.AddButtons(base.gameObject, helpActionButtonsHolder.ActionButtons);
			}
		}

		private void OnEnable()
		{
			panelBase.OnShown.AddListener(ResolvedOnShown);
			panelBase.OnHidden.AddListener(ResolvedOnHidden);
			helpActionButtonsHolder.ActionButtonAdded += ResolvedHelpActionButtonsHolder_ActionButtonAdded;
			helpActionButtonsHolder.ActionButtonRemoved += ResolvedHelpActionButtonsHolder_ActionButtonRemoved;
			if (helpActionButtonsService != null && panelBase.IsActive)
			{
				helpActionButtonsService.AddButtons(base.gameObject, helpActionButtonsHolder.ActionButtons);
			}
		}

		private void OnDisable()
		{
			panelBase.OnShown.RemoveListener(ResolvedOnShown);
			panelBase.OnHidden.RemoveListener(ResolvedOnHidden);
			helpActionButtonsHolder.ActionButtonAdded -= ResolvedHelpActionButtonsHolder_ActionButtonAdded;
			helpActionButtonsHolder.ActionButtonRemoved -= ResolvedHelpActionButtonsHolder_ActionButtonRemoved;
			if (helpActionButtonsService != null)
			{
				helpActionButtonsService.RemoveButtons(helpActionButtonsHolder.ActionButtons);
			}
		}

		private void ResolvedOnShown()
		{
			if (!(helpActionButtonsService == null))
			{
				helpActionButtonsService.AddButtons(base.gameObject, helpActionButtonsHolder.ActionButtons);
			}
		}

		private void ResolvedOnHidden()
		{
			if (!(helpActionButtonsService == null))
			{
				helpActionButtonsService.RemoveButtons(helpActionButtonsHolder.ActionButtons);
			}
		}

		private void ResolvedHelpActionButtonsHolder_ActionButtonAdded(HelpAction helpActionButton)
		{
			if (helpActionButtonsService != null && panelBase.IsActive)
			{
				helpActionButtonsService.AddButton(base.gameObject, helpActionButton);
			}
		}

		private void ResolvedHelpActionButtonsHolder_ActionButtonRemoved(HelpAction helpActionButton)
		{
			if (helpActionButtonsService != null && panelBase.IsActive)
			{
				helpActionButtonsService.RemoveButton(helpActionButton);
			}
		}
	}
}
