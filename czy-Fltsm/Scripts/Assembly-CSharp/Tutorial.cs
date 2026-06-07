using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
	[Serializable]
	private class PageCollection
	{
		public InputFlags InputFlags = InputFlags.All;

		public GameObject[] Pages;

		public void DeactivateAll()
		{
			GameObject[] pages = Pages;
			foreach (GameObject gameObject in pages)
			{
				if ((bool)gameObject)
				{
					gameObject.SetActive(value: false);
				}
			}
		}
	}

	public const string NO_PAGE_STRING = "0/0";

	[SerializeField]
	[GeneratedEnum]
	private TutorialID _id;

	[SerializeField]
	private LocalizedString _title;

	[SerializeField]
	private PageCollection[] _pageCollections;

	private PageCollection _activePageCollection;

	private int _pageIndex;

	private static List<Tutorial> s_tutorials = new List<Tutorial>();

	public TutorialID ID => _id;

	public LocalizedString Title => _title;

	private void Awake()
	{
		PageCollection[] pageCollections = _pageCollections;
		for (int i = 0; i < pageCollections.Length; i++)
		{
			pageCollections[i].DeactivateAll();
		}
	}

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
		OnActiveInputUpdated();
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
	}

	public void Initialize()
	{
		int count = s_tutorials.Count;
		while (0 < count--)
		{
			Tutorial tutorial = s_tutorials[count];
			if (tutorial == null)
			{
				s_tutorials.RemoveAt(count);
			}
			else if (tutorial.ID == ID)
			{
				return;
			}
		}
		s_tutorials.Add(this);
	}

	public bool NextPage()
	{
		if (HasNextPage())
		{
			_activePageCollection.Pages[_pageIndex].SetActive(value: false);
			_activePageCollection.Pages[++_pageIndex].SetActive(value: true);
			return true;
		}
		return false;
	}

	public bool PreviousPage()
	{
		if (HasPreviousPage())
		{
			_activePageCollection.Pages[_pageIndex].SetActive(value: false);
			_activePageCollection.Pages[--_pageIndex].SetActive(value: true);
			return true;
		}
		return false;
	}

	private void OnActiveInputUpdated(GameEvent gameEvent = null)
	{
		for (int i = 0; i < _pageCollections.Length; i++)
		{
			PageCollection pageCollection = _pageCollections[i];
			if (FlotsamInputManager.HasActiveInput(pageCollection.InputFlags))
			{
				if (_activePageCollection != null)
				{
					_activePageCollection.Pages[_pageIndex].SetActive(value: false);
				}
				_pageIndex = 0;
				_activePageCollection = pageCollection;
				if (_activePageCollection.Pages.Length != 0)
				{
					_activePageCollection.Pages[0].SetActive(value: true);
				}
				else
				{
					Debug.LogException(new NotSupportedException($"Tutorial '{ID}' has no pages set for InputFlags '{_activePageCollection.InputFlags}'!"));
				}
			}
		}
	}

	public bool HasNextPage()
	{
		if (_activePageCollection != null)
		{
			return _pageIndex < _activePageCollection.Pages.Length - 1;
		}
		return false;
	}

	public bool HasPreviousPage()
	{
		if (_activePageCollection != null)
		{
			return 0 < _pageIndex;
		}
		return false;
	}

	public string GetPageString()
	{
		if (_activePageCollection == null)
		{
			return "0/0";
		}
		return $"{_pageIndex + 1}/{_activePageCollection.Pages.Length}";
	}

	public static string GetTitle(TutorialID id)
	{
		foreach (Tutorial s_tutorial in s_tutorials)
		{
			if (s_tutorial.ID == id)
			{
				return s_tutorial.Title;
			}
		}
		return null;
	}
}
