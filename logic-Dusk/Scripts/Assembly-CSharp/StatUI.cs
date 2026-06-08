using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
	public static StatUI Instance;

	public StatPage[] pages;

	public Text pageLabel;

	public Color emptyValueColor = Color.gray;

	public Color filledValueColor = Color.white;

	public Color noStatsColor = Color.gray;

	public Color highlightRowBackgroundColor = Color.gray;

	public Color currentIsBestColor = Color.yellow;

	private int currentPageIndex;

	private int pageCount;

	private bool refreshOnNextFrame;

	private void Awake()
	{
		Instance = this;
		pageCount = pages.Length;
		Hide();
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	public void Show()
	{
		refreshOnNextFrame = true;
		for (int i = 0; i < pageCount; i++)
		{
			if (i == 0)
			{
				pages[i].gameObject.SetActive(true);
			}
			else
			{
				pages[i].gameObject.SetActive(false);
			}
			pages[i].Refresh();
		}
		RefreshPageCounter();
		base.gameObject.SetActive(true);
	}

	public void Hide()
	{
		base.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (refreshOnNextFrame)
		{
			for (int i = 0; i < pageCount; i++)
			{
				pages[i].gameObject.SetActive(true);
				pages[i].Refresh();
			}
			for (int j = 1; j < pageCount; j++)
			{
				pages[j].gameObject.SetActive(false);
			}
			refreshOnNextFrame = false;
		}
		if (Input.GetButtonDown("Left"))
		{
			pages[currentPageIndex].gameObject.SetActive(false);
			currentPageIndex--;
			if (currentPageIndex < 0)
			{
				currentPageIndex = pages.Length - 1;
			}
			pages[currentPageIndex].gameObject.SetActive(true);
			RefreshPageCounter();
		}
		else if (Input.GetButtonDown("Right"))
		{
			pages[currentPageIndex].gameObject.SetActive(false);
			currentPageIndex++;
			if (currentPageIndex >= pages.Length)
			{
				currentPageIndex = 0;
			}
			pages[currentPageIndex].gameObject.SetActive(true);
			RefreshPageCounter();
		}
		else if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (MainMenu.Instance != null)
			{
				MainMenu.Instance.HideStats();
			}
			else if (PauseMenu.Instance != null)
			{
				PauseMenu.Instance.HideStats();
			}
		}
	}

	private void RefreshPageCounter()
	{
		pageLabel.text = string.Format("Pages {0}/{1}", currentPageIndex + 1, pageCount);
	}
}
