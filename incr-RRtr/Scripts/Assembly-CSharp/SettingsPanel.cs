using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
	[SerializeField]
	private GameObject mainPanel;

	[SerializeField]
	private GameObject graphicsPanel;

	[SerializeField]
	private GameObject audioPanel;

	[SerializeField]
	private GameObject twitchPanel;

	[SerializeField]
	private GameObject titleScreenPanel;

	[Space]
	[SerializeField]
	private GameObject sidePanel;

	private void Awake()
	{
		OpenMainPanel();
	}

	public void OpenMainPanel()
	{
		CloseAllPanels();
		OpenPanel(mainPanel);
	}

	public void OpenGraphicsPanel()
	{
		CloseAllPanels();
		OpenPanel(graphicsPanel);
	}

	public void OpenAudioPanel()
	{
		CloseAllPanels();
		OpenPanel(audioPanel);
	}

	public void OpenMainMenuPanel()
	{
		titleScreenPanel.SetActive(value: true);
	}

	public void OpenTwitchPanel()
	{
		CloseAllPanels();
		OpenPanel(twitchPanel);
		sidePanel.SetActive(value: false);
	}

	private void CloseAllPanels()
	{
		mainPanel.SetActive(value: false);
		graphicsPanel.SetActive(value: false);
		audioPanel.SetActive(value: false);
		twitchPanel.SetActive(value: false);
		sidePanel.SetActive(value: true);
	}

	private void OpenPanel(GameObject panel)
	{
		panel.SetActive(value: true);
	}
}
