using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabletAppInstagram : MonoBehaviour
{
	[Header("Window Components")]
	public TabletAppAnimationWindow tabletAppAnimationWindow;

	private int heartClickCount;

	[Header("Statystyka serdueszek")]
	public TextMeshProUGUI hearts_counter;

	public Sprite[] hearts;

	public Image currentHeart;

	private bool statsRequested;

	[Header("Story")]
	public GameObject storyView;

	public Transform[] objStoryMainView;

	public GameObject[] storiesViews;

	public bool dawid_isRead;

	public bool jacek_isRead;

	public bool daniel_isRead;

	public bool freemind_isRead;

	public bool pixelteamred_isRead;

	public Image dawid_bgIsRead;

	public Image jacek_bgIsRead;

	public Image daniel_bgIsRead;

	public Image freemind_bgIsRead;

	public Image pixelteamred_bgIsRead;

	[Header("Color Def Story")]
	public string hexColorLightGray;

	public string hexColorGray;

	public string hexColorPink;

	public Color newColorLightGray;

	public Color newColorGray;

	public Color newColorPink;

	[Header("StoryDaniel")]
	private int idCurrentStory;

	public Image secoundWhiteBar;

	public GameObject[] storyIdObject;

	public int HeartClickCount { get; set; }

	public void SetPaletteCollor()
	{
	}

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void OnHearClick()
	{
	}

	private void VerifyStory()
	{
	}

	public void MoveOnEnd(int id)
	{
	}

	public void ShowStory(int id)
	{
	}

	public void DanielLeft()
	{
	}

	public void DanielRight()
	{
	}

	private void ResetStoryViews()
	{
	}

	public void CloseStory()
	{
	}
}
