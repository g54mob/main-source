using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class newhampshire_search : Website
{
	[SerializeField]
	protected TMP_InputField searchInput;

	[SerializeField]
	protected GameObject notificationPrefab;

	[SerializeField]
	protected Button searchButton;

	private GameObject failPopup;

	protected override void Start()
	{
		base.Start();
		GetComponent<PlayerInput>().actions["Enter"].performed += delegate
		{
			if (searchInput.isFocused && searchInput.text.Length > 0)
			{
				SearchPlayer();
			}
		};
	}

	public void SearchPlayer()
	{
		string text = searchInput.text;
		if (!newhampshire_player.HasCharacter(text))
		{
			SearchFailPopup();
		}
		else
		{
			LaunchInnerSite("legendsofnewhampshire.com/player/" + text);
		}
	}

	public void SetButtonInteractability()
	{
		searchButton.interactable = searchInput.text.Length > 0;
	}

	private void SearchFailPopup()
	{
		PlayWarning();
		if (failPopup == null)
		{
			failPopup = UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), "Error", "Player not found.", NotificationHandler.Icon.ERROR);
		}
		PanelManager.OpenWindow(failPopup);
	}
}
