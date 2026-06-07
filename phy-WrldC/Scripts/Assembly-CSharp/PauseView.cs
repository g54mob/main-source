using UnityEngine.UI;

public class PauseView : BaseGUIView
{
	public const string RetryButtonEvent = "PauseView.RetryButtonEvent";

	public const string MenuButtonEvent = "PauseView.MenuButtonEvent";

	public const string BuildButtonEvent = "PauseView.BuildButtonEvent";

	public const string ReplayButtonEvent = "PauseView.ReplayButtonEvent";

	public const string BackButtonEvent = "PauseView.BackButtonEvent";

	public const string EditorButtonEvent = "PauseView.EditorButtonEvent";

	private Button retryButton;

	private Button menuButton;

	private Button buildButton;

	private Button replayButton;

	private Button backButton;

	private Button editorButton;

	public override void Initialize()
	{
		retryButton = mainPanel.transform.FindComponent<Button>("RetryButton", isRecursively: true);
		menuButton = mainPanel.transform.FindComponent<Button>("MenuButton", isRecursively: true);
		buildButton = mainPanel.transform.FindComponent<Button>("BuildButton", isRecursively: true);
		replayButton = mainPanel.transform.FindComponent<Button>("ReplayButton", isRecursively: true);
		backButton = mainPanel.transform.FindComponent<Button>("BackButton", isRecursively: true);
		editorButton = mainPanel.transform.FindComponent<Button>("EditorButton", isRecursively: true);
		retryButton.onClick.AddListener(delegate
		{
			NotifyChange("PauseView.RetryButtonEvent");
		});
		menuButton.onClick.AddListener(delegate
		{
			NotifyChange("PauseView.MenuButtonEvent");
		});
		buildButton.onClick.AddListener(delegate
		{
			NotifyChange("PauseView.BuildButtonEvent");
		});
		replayButton.onClick.AddListener(delegate
		{
			NotifyChange("PauseView.ReplayButtonEvent");
		});
		backButton.onClick.AddListener(delegate
		{
			NotifyChange("PauseView.BackButtonEvent");
		});
		editorButton.onClick.AddListener(delegate
		{
			NotifyChange("PauseView.EditorButtonEvent");
		});
	}

	public void SetReplayButtonInteractive(bool isInteractable)
	{
		replayButton.interactable = isInteractable;
	}

	public void SetEditorButtonVisibility(bool isVisible)
	{
		editorButton.gameObject.SetActive(isVisible);
	}
}
