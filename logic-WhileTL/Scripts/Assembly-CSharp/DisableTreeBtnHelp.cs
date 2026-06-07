using UnityEngine;
using UnityEngine.UI;

public class DisableTreeBtnHelp : ActiveComponent
{
	private Image img;

	private void Start()
	{
		img = base.gameObject.GetComponent<Image>();
	}

	private void FixedUpdate()
	{
		if (ActiveComponent.Model != null && ActiveComponent.Model.P != null)
		{
			if (ActiveComponent.Model.P.treeBtnTutorial)
			{
				Object.Destroy(base.gameObject);
			}
			img.enabled = !ActiveComponent._controller.computerBuildingController.gameObject.activeSelf && !ActiveComponent._controller.construction.gameObject.activeSelf && !ActiveComponent._controller.buy.gameObject.activeSelf && !ActiveComponent._controller.newspaper.gameObject.activeSelf && !ActiveComponent._controller._gameOverView.gameObject.activeSelf && !ActiveComponent._controller.GainMoneyWindow.gameObject.activeSelf && !ActiveComponent._controller.GainMoneyStartup.gameObject.activeSelf && !ActiveComponent._controller.nicknameController.gameObject.activeSelf && !ActiveComponent._controller.Inbox.gameObject.activeSelf && !ActiveComponent._controller._startupView.AttentionDelete.gameObject.activeSelf && !ActiveComponent._controller.MenuView.OverrideSaveView.gameObject.activeSelf && !ActiveComponent._controller.Tree.gameObject.activeSelf && !ActiveComponent._controller.credit.gameObject.activeSelf && !ActiveComponent._controller.payDay.gameObject.activeSelf && !Logic.GoogleController.gameObject.activeSelf;
		}
	}
}
