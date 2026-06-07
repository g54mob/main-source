using System;
using UnityEngine;

public class TutorialPageFlipWrapper : MonoBehaviour
{
	private bool shouldCheckForBookletOpen;

	private bool shouldCheckForPageFlipping;

	private PageBook book;

	private InventoryItemSpec specs;

	public int CurrentPage { get; private set; }

	public PageBook Book
	{
		get
		{
			if (book == null)
			{
				book = GetComponent<PageBook>();
			}
			return book;
		}
		set
		{
			book = value;
		}
	}

	public event Action<InventoryItemSpec> BookletOpen;

	public event Action<int> PageFlipped;

	private void Start()
	{
		if (book == null)
		{
			book = GetComponent<PageBook>();
		}
		specs = GetComponent<InventoryItemSpec>();
	}

	public void CheckForBookletOpen(bool on)
	{
		shouldCheckForBookletOpen = on;
	}

	public void CheckForPageFlip(bool on)
	{
		shouldCheckForPageFlipping = on;
		CurrentPage = Book.currentPage;
	}

	private void Update()
	{
		if (shouldCheckForBookletOpen && Book.currentPage != 0)
		{
			shouldCheckForBookletOpen = false;
			this.BookletOpen?.Invoke(specs);
		}
		if (shouldCheckForPageFlipping && CurrentPage != Book.currentPage)
		{
			CurrentPage = Book.currentPage;
			this.PageFlipped?.Invoke(CurrentPage);
		}
	}
}
