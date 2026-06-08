using System.Collections.Generic;
using UnityEngine;

public class WebHistory
{
	public class History
	{
		public string site;

		public float scrollPos;

		public History(string site)
			: this(site, 1f)
		{
		}

		public History(string site, float scrollPos)
		{
			this.site = site;
			this.scrollPos = scrollPos;
		}
	}

	private List<History> history;

	private int historySize;

	private int currentSite;

	public WebHistory()
	{
		history = new List<History>
		{
			new History("welcome")
		};
		historySize = 1;
		currentSite = 0;
	}

	public void AddSite(string newSite, float scrollPos)
	{
		currentSite++;
		historySize = currentSite + 1;
		history[currentSite - 1].scrollPos = scrollPos;
		history.Insert(currentSite, new History(newSite));
		Debug.Log($"current site index: {currentSite}, Scroll: {history[currentSite].scrollPos}");
	}

	public History Back()
	{
		currentSite--;
		Debug.Log($"current site index: {currentSite}, Scroll: {history[currentSite].scrollPos}");
		return history[currentSite];
	}

	public string GetPreviousSite()
	{
		if (currentSite <= 0)
		{
			return null;
		}
		return history[currentSite - 1].site;
	}

	public History Forward()
	{
		currentSite++;
		Debug.Log($"current site index: {currentSite}, Scroll: {history[currentSite].scrollPos}");
		return history[currentSite];
	}

	public void SaveCurrentScrollPos(float scrollPos)
	{
		history[currentSite].scrollPos = scrollPos;
	}

	public bool IsFirstSite()
	{
		return currentSite == 0;
	}

	public bool IsLastSite()
	{
		return historySize == currentSite + 1;
	}
}
