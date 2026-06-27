using UnityEngine;
using Zenject;

namespace Restory.UserInterface.HelpActions
{
	public class HelpActionButtonsScreenObjectBaseAdder : MonoBehaviour
	{
		[SerializeField]
		private GUI_ScreenObjectBase screenObjectBase;

		[SerializeField]
		private HelpActionButtonsHolder helpActionButtonsHolder;

		private HelpActionButtonsService helpActionButtonsService;

		[Inject]
		private void Construct(HelpActionButtonsService helpActionButtonsService)
		{
			this.helpActionButtonsService = helpActionButtonsService;
			if (base.isActiveAndEnabled && screenObjectBase.IsOpen)
			{
				helpActionButtonsService.AddButtons(base.gameObject, helpActionButtonsHolder.ActionButtons);
			}
		}

		private void OnEnable()
		{
			screenObjectBase.OnShown.AddListener(ResolvedOnShown);
			screenObjectBase.OnHidden.AddListener(ResolvedOnHidden);
			helpActionButtonsHolder.ActionButtonAdded += ResolvedHelpActionButtonsHolder_ActionButtonAdded;
			helpActionButtonsHolder.ActionButtonRemoved += ResolvedHelpActionButtonsHolder_ActionButtonRemoved;
			if (helpActionButtonsService != null && screenObjectBase.IsOpen)
			{
				helpActionButtonsService.AddButtons(base.gameObject, helpActionButtonsHolder.ActionButtons);
			}
		}

		private void OnDisable()
		{
			screenObjectBase.OnShown.RemoveListener(ResolvedOnShown);
			screenObjectBase.OnHidden.RemoveListener(ResolvedOnHidden);
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
			if (helpActionButtonsService != null && screenObjectBase.IsOpen)
			{
				helpActionButtonsService.AddButton(base.gameObject, helpActionButton);
			}
		}

		private void ResolvedHelpActionButtonsHolder_ActionButtonRemoved(HelpAction helpActionButton)
		{
			if (helpActionButtonsService != null && screenObjectBase.IsOpen)
			{
				helpActionButtonsService.RemoveButton(helpActionButton);
			}
		}
	}
}
