using UnityEngine;

public class TabSwitcher : MonoBehaviour
{
	[SerializeField]
	private TabPage[] pages;

	[SerializeField]
	private int selectedPageIndex;

	private void Start()
	{
		for (int i = 0; i < pages.Length; i++)
		{
			pages[i].InitTabPage(this, i);
		}
		UpdatePageVisibility(0);
	}

	public void UpdatePageVisibility(int tab)
	{
		selectedPageIndex = tab;
		for (int i = 0; i < pages.Length; i++)
		{
			if (selectedPageIndex == i)
			{
				pages[i].ShowPage();
			}
			else
			{
				pages[i].HidePage();
			}
		}
	}
}
