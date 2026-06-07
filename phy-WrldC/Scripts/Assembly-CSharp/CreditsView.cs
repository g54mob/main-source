using UnityEngine.UI;

public class CreditsView : BaseGUIPanelView
{
	public const string BackEvent = "CreditsView.BackEvent";

	private Button winCloseButton;

	private Button closeButton;

	public CreditsView(MainMenuView mainMenuView)
	{
		base.MainPanel = mainMenuView.mainPanel.transform.Find("CreditsPanel").gameObject;
		winCloseButton = base.MainPanel.transform.FindComponent<Button>("WinCloseButton", isRecursively: true);
		closeButton = base.MainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		winCloseButton.onClick.AddListener(delegate
		{
			NotifyChange("CreditsView.BackEvent");
		});
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("CreditsView.BackEvent");
		});
	}
}
