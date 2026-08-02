using TMPro;
using UnityEngine;

public class InGameUIManager : UIPanelBase
{
	public GameObject grabArea;

	public GameObject interactArea;

	public TextMeshProUGUI interactPanelKeyText;

	public TextMeshProUGUI interactPanelMessageText;

	[SerializeField]
	private CanvasGroup userInfoCanvasGroup;

	private void OnEnable()
	{
		Singleton<MainUIManager>.Instance.OnInGamePanelOpened.AddListener(delegate
		{
			ChangeUserInfoPanelVisible(visible: false);
		});
		Singleton<MainUIManager>.Instance.OnInGamePanelClosed.AddListener(delegate
		{
			ChangeUserInfoPanelVisible(visible: true);
		});
	}

	private void OnDisable()
	{
		Singleton<MainUIManager>.Instance.OnInGamePanelOpened.RemoveListener(delegate
		{
			ChangeUserInfoPanelVisible(visible: false);
		});
		Singleton<MainUIManager>.Instance.OnInGamePanelClosed.RemoveListener(delegate
		{
			ChangeUserInfoPanelVisible(visible: true);
		});
	}

	private void ChangeUserInfoPanelVisible(bool visible)
	{
		userInfoCanvasGroup.alpha = (visible ? 1 : 0);
		userInfoCanvasGroup.interactable = visible;
		userInfoCanvasGroup.blocksRaycasts = visible;
	}

	public void CloseUserInteractPanel()
	{
		interactArea.gameObject.SetActive(value: false);
	}

	public void OpenUserInformative(string info)
	{
		grabArea.GetComponentInChildren<TextMeshProUGUI>().text = info;
		grabArea.gameObject.SetActive(value: true);
	}

	public void CloseUserInformative()
	{
		grabArea.gameObject.SetActive(value: false);
	}
}
