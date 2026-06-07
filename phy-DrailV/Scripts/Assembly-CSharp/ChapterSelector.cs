using System;
using System.Collections.Generic;
using DV.CabControls;
using UnityEngine;

public class ChapterSelector : MonoBehaviour
{
	[Serializable]
	public struct PageBookChapter
	{
		public int startingPage;

		public int endingPage;

		public bool allowChapterSelector;

		public PageBookChapter(int startingPage, int endingPage, bool allowChapterSelector)
		{
			this.startingPage = startingPage;
			this.endingPage = endingPage;
			this.allowChapterSelector = allowChapterSelector;
		}
	}

	[SerializeField]
	private List<PageBookChapter> allChapters = new List<PageBookChapter>();

	private List<PageBookChapter> selectableChapters = new List<PageBookChapter>();

	private PageBook pageBook;

	private TouchscreenBase touchscreen;

	public TouchscreenBase BookmarksTouchscreen => touchscreen;

	private void Start()
	{
		pageBook = GetComponent<PageBook>();
		if (pageBook == null)
		{
			Debug.LogError("Missing PageBook component. ChapterSelector destroying self.", base.gameObject);
			UnityEngine.Object.Destroy(this);
			return;
		}
		touchscreen = GetComponentInChildren<TouchscreenBase>(includeInactive: true);
		if (touchscreen == null)
		{
			Debug.LogError("Missing TouchscreenBase component. ChapterSelector destroying self.", base.gameObject);
			UnityEngine.Object.Destroy(this);
			return;
		}
		if (allChapters.Count <= 0)
		{
			Debug.LogError("ChapterSelector must have at least one chapter. Destroying self.", base.gameObject);
			UnityEngine.Object.Destroy(this);
			return;
		}
		for (int i = 0; i < allChapters.Count - 1; i++)
		{
			int num = i + 1;
			PageBookChapter pageBookChapter = allChapters[i];
			if (allChapters[num].startingPage - pageBookChapter.endingPage != 1)
			{
				Debug.LogError($"Chapter continuity broken between chapters {i} and {num}. This should not happen.", this);
			}
		}
		SetupListeners(on: true);
	}

	private void OnDestroy()
	{
		SetupListeners(on: false);
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			touchscreen.Initialized += OnTouchscreenInitialized;
			touchscreen.SectionPressed += OnChapterSelected;
			pageBook.PageFlipped += OnPageFlipped;
			return;
		}
		if (touchscreen != null)
		{
			touchscreen.Initialized -= OnTouchscreenInitialized;
			touchscreen.SectionPressed -= OnChapterSelected;
		}
		if (pageBook != null)
		{
			pageBook.PageFlipped -= OnPageFlipped;
		}
	}

	private void OnTouchscreenInitialized()
	{
		for (int i = 0; i < allChapters.Count; i++)
		{
			PageBookChapter item = allChapters[i];
			if (item.allowChapterSelector)
			{
				selectableChapters.Add(item);
			}
		}
		if (touchscreen.gridSize.x != selectableChapters.Count)
		{
			Debug.LogWarning("Chapter count mismatch.", this);
		}
		PageBookChapter pageBookChapter = FindBelongingChapter(pageBook.currentPage);
		touchscreen.gameObject.SetActive(pageBookChapter.allowChapterSelector);
	}

	public int GetBookmarkIndexFor(int pageNumber)
	{
		int num = FindChapterIndex(pageNumber);
		if (num < 0)
		{
			return -1;
		}
		for (int num2 = num; num2 >= 0; num2--)
		{
			if (!allChapters[num2].allowChapterSelector)
			{
				num--;
			}
		}
		return num;
	}

	private void OnPageFlipped(int currentPage)
	{
		PageBookChapter pageBookChapter = FindBelongingChapter(currentPage);
		touchscreen.gameObject.SetActive(pageBookChapter.allowChapterSelector);
	}

	private void OnChapterSelected(Vector2Int chapter)
	{
		int x = chapter.x;
		if (x < 0 || x >= selectableChapters.Count)
		{
			Debug.LogError($"Missing or non-selectable chapter at index '{x}', skipping.", this);
		}
		else
		{
			pageBook.FlipTo(selectableChapters[x].startingPage);
		}
	}

	private int FindChapterIndex(int pageNumber)
	{
		int num = 0;
		int num2 = allChapters.Count - 1;
		if (pageNumber < allChapters[num].startingPage || pageNumber > allChapters[num2].endingPage)
		{
			Debug.LogError(string.Format("{0} encountered a page outside of scope (page number {1}).", "ChapterSelector", pageNumber), this);
			return -1;
		}
		int num3 = num2 / 2;
		int num4 = num2;
		while (--num4 > 0)
		{
			if (pageNumber < allChapters[num3].startingPage)
			{
				num2 = num3 - 1;
				num3 = (num + num2) / 2;
				continue;
			}
			if (pageNumber <= allChapters[num3].endingPage)
			{
				break;
			}
			num = num3 + 1;
			num3 = (num + num2) / 2;
		}
		if (num4 <= 0)
		{
			return -1;
		}
		return num3;
	}

	private PageBookChapter FindBelongingChapter(int pageNumber)
	{
		int num = FindChapterIndex(pageNumber);
		if (num < 0)
		{
			Debug.LogError(string.Format("{0} could not find a chapter to which page {1} belongs).", "ChapterSelector", pageNumber), this);
			return default(PageBookChapter);
		}
		return allChapters[num];
	}
}
