using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GlobalSearchPanel : MonoBehaviour
{
	public class SearchItem
	{
		public string Title;

		public string Query;

		public Action<RenderTexture> Render;

		private Action _find;

		private Action _executeOnce;

		public Sprite SpriteTh;

		public bool SpriteWhite;

		public bool? BuildMode;

		public Texture ImageTh;

		public Rect UVRect;

		public bool Enabled = true;

		public SearchItem(string title, Action find, bool? buildMode, Action executeOnce)
		{
			Title = title;
			Query = Normalize(title);
			_find = find;
			BuildMode = buildMode;
			_executeOnce = executeOnce;
		}

		public SearchItem(string title, Action find, Action<RenderTexture> render, bool? buildMode)
		{
			Title = title;
			Query = Normalize(title);
			_find = find;
			Render = render;
			BuildMode = buildMode;
		}

		public SearchItem(string title, Action find, Sprite spriteTh, bool spriteWhite, bool? buildMode)
		{
			Title = title;
			Query = Normalize(title);
			_find = find;
			SpriteTh = spriteTh;
			SpriteWhite = spriteWhite;
			BuildMode = buildMode;
		}

		public SearchItem(string title, Action find, Texture imageTh, Rect uvRect, bool? buildMode)
		{
			Title = title;
			Query = Normalize(title);
			_find = find;
			ImageTh = imageTh;
			UVRect = uvRect;
			BuildMode = buildMode;
		}

		public void SetThumbnail(Sprite spr, bool spriteWhite)
		{
			ImageTh = null;
			SpriteTh = spr;
			SpriteWhite = spriteWhite;
		}

		public void SetThumbnail(Texture image, Rect uvRect)
		{
			SpriteTh = null;
			ImageTh = image;
			UVRect = uvRect;
		}

		public void WasVisible()
		{
			if (_executeOnce != null)
			{
				_executeOnce();
				_executeOnce = null;
			}
		}

		public void FindAction()
		{
			if (BuildMode.HasValue)
			{
				if (HUD.Instance.CheckBuildMode(BuildMode.Value))
				{
					_find();
				}
			}
			else
			{
				_find();
			}
		}
	}

	public InputField SearchField;

	public List<GlobalSearchResult> Results;

	public int SearchItems = 5;

	public Text FooterLabel;

	[NonSerialized]
	private int _activeElement;

	[NonSerialized]
	private DictionaryList<object, SearchItem> _search = new DictionaryList<object, SearchItem>();

	private static List<ValueTuple<SearchItem, double>> _filtered = new List<ValueTuple<SearchItem, double>>();

	private bool _init = true;

	public static GlobalSearchPanel Instance
	{
		get
		{
			return HUD.Instance.SearchPanel;
		}
	}

	public void AddSearchItem(object item, string query, Action find, bool? inBuildMode = null, Action executeOnce = null)
	{
		_search[item] = new SearchItem(query, find, inBuildMode, executeOnce);
	}

	public void AddSearchItem(object item, string query, Action find, string icon, bool? inBuildMode = null)
	{
		_search[item] = new SearchItem(query, find, ObjectDatabase.GetIcon(icon), false, inBuildMode);
	}

	public void AddSearchItem(object item, string query, Action find, Sprite thumbnail, bool? inBuildMode = null, bool spriteWhite = true)
	{
		_search[item] = new SearchItem(query, find, thumbnail, spriteWhite, inBuildMode);
	}

	public void AddSearchItem(object item, string query, Action find, Texture thumbnail, Rect uvRect, bool? inBuildMode = null)
	{
		_search[item] = new SearchItem(query, find, thumbnail, uvRect, inBuildMode);
	}

	public void AddSearchItem(object item, string query, Action find, Action<RenderTexture> render, bool? inBuildMode = null)
	{
		_search[item] = new SearchItem(query, find, render, inBuildMode);
	}

	public SearchItem GetSearchItem(object item)
	{
		return _search.GetOrNull(item);
	}

	public bool TryGetSearchItem(object item, out SearchItem searchItem)
	{
		return _search.TryGetValue(item, out searchItem);
	}

	public void SetEnabled(object item, bool enabled)
	{
		SearchItem value;
		if (_search.TryGetValue(item, out value))
		{
			value.Enabled = enabled;
		}
	}

	public void RefreshQuery(object item, string title)
	{
		SearchItem value;
		if (_search.TryGetValue(item, out value))
		{
			value.Title = title;
			value.Query = Normalize(title);
		}
	}

	public void RemoveSearchItem(object item)
	{
		_search.Remove(item);
	}

	public void OnSearchChange()
	{
		if (!string.IsNullOrWhiteSpace(SearchField.text))
		{
			string query = Normalize(SearchField.text);
			_filtered.Clear();
			for (int i = 0; i < _search.Count; i++)
			{
				SearchItem searchItem = _search[i];
				if (searchItem.Enabled)
				{
					double similarityNormalized = GetSimilarityNormalized(query, searchItem.Query);
					if (similarityNormalized >= 0.5)
					{
						_filtered.Add(new ValueTuple<SearchItem, double>(searchItem, similarityNormalized));
					}
				}
			}
			_filtered.Sort((ValueTuple<SearchItem, double> x, ValueTuple<SearchItem, double> y) => y.Item2.CompareTo(x.Item2));
			SetResult(_filtered.Select((ValueTuple<SearchItem, double> x) => x.Item1));
			_filtered.Clear();
		}
		else
		{
			Clear();
		}
	}

	private void SetResult(IEnumerable<SearchItem> items)
	{
		int num = 0;
		foreach (SearchItem item in items)
		{
			if (num < Results.Count)
			{
				Results[num].Set(item);
			}
			num++;
		}
		if (num > Results.Count)
		{
			FooterLabel.text = "+" + (num - Results.Count);
		}
		else
		{
			FooterLabel.text = "";
			for (int i = num; i < Results.Count; i++)
			{
				Results[i].Clear();
			}
		}
		SetActive(0);
	}

	private void Clear()
	{
		FooterLabel.text = "";
		for (int i = 0; i < Results.Count; i++)
		{
			Results[i].Clear();
		}
	}

	private void SetActive(int index)
	{
		for (int i = 0; i < Results.Count; i++)
		{
			Results[i].Highlight(i == index);
		}
		_activeElement = index;
	}

	public void Show()
	{
		Init();
		base.gameObject.SetActive(true);
		SearchField.Select();
		SearchField.ActivateInputField();
		OnSearchChange();
	}

	private void Init()
	{
		if (_init)
		{
			_init = false;
			for (int i = 1; i < SearchItems; i++)
			{
				GlobalSearchResult globalSearchResult = UnityEngine.Object.Instantiate(Results[0]);
				globalSearchResult.transform.SetParent(Results[0].transform.parent, false);
				globalSearchResult.transform.SetSiblingIndex(Results[0].transform.GetSiblingIndex() + i);
				Results.Add(globalSearchResult);
			}
		}
	}

	private IEnumerator ForceFocus(int frames)
	{
		for (int i = 0; i < frames; i++)
		{
			yield return new WaitForEndOfFrame();
		}
		SearchField.Select();
		SearchField.ActivateInputField();
		yield return new WaitForEndOfFrame();
		SearchField.caretPosition = SearchField.text.Length;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			EventSystem.current.SetSelectedGameObject(null);
			SearchField.text = "";
		}
		if (Input.GetKeyUp(KeyCode.UpArrow) && _activeElement > 0)
		{
			SetActive(_activeElement - 1);
		}
		if (Input.GetKeyUp(KeyCode.DownArrow) && _activeElement < Results.Count((GlobalSearchResult x) => x.gameObject.activeSelf) - 1)
		{
			SetActive(_activeElement + 1);
		}
		if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
		{
			SearchItem item = Results[_activeElement].Item;
			if (item != null)
			{
				item.FindAction();
				EventSystem.current.SetSelectedGameObject(null);
				base.gameObject.SetActive(false);
			}
			else
			{
				StartCoroutine(ForceFocus(2));
			}
		}
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			base.gameObject.SetActive(false);
		}
	}

	public static double GetSimilarity(string query, string target)
	{
		if (query == null || target == null)
		{
			throw new ArgumentNullException();
		}
		string query2 = Normalize(query);
		string target2 = Normalize(target);
		return GetSimilarityNormalized(query2, target2);
	}

	public static double GetSimilarityNormalized(string query, string target)
	{
		int length = query.Length;
		int length2 = target.Length;
		if (length == 0 && length2 == 0)
		{
			return 1.0;
		}
		if (length == 0 || length2 == 0)
		{
			return 0.0;
		}
		if (query == target)
		{
			return 1.0;
		}
		if (length2 >= length && target.StartsWith(query))
		{
			return 0.95;
		}
		if (target.Contains(query))
		{
			return 0.9;
		}
		if (Math.Abs(length - length2) > Math.Max(length, length2) / 2)
		{
			return 0.0;
		}
		int num = DamerauLevenshtein(query, target);
		int num2 = Math.Max(length, length2);
		double num3 = 1.0 - (double)num / (double)num2;
		if (num3 < 0.0)
		{
			num3 = 0.0;
		}
		if (num3 > 1.0)
		{
			num3 = 1.0;
		}
		return num3;
	}

	public static string Normalize(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			return string.Empty;
		}
		string text = s.Normalize(NormalizationForm.FormD);
		StringBuilder stringBuilder = new StringBuilder(text.Length);
		string text2 = text;
		foreach (char c in text2)
		{
			UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
			if (unicodeCategory != UnicodeCategory.NonSpacingMark && unicodeCategory != UnicodeCategory.SpacingCombiningMark && unicodeCategory != UnicodeCategory.EnclosingMark)
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString().Normalize(NormalizationForm.FormC).ToLowerInvariant();
	}

	private static int DamerauLevenshtein(string s, string t)
	{
		int num = s.Length;
		int num2 = t.Length;
		if (num == 0)
		{
			return num2;
		}
		if (num2 == 0)
		{
			return num;
		}
		if (num > num2)
		{
			string text = s;
			s = t;
			t = text;
			int num3 = num;
			num = num2;
			num2 = num3;
		}
		int[] array = new int[num2 + 1];
		int[] array2 = new int[num2 + 1];
		int[] array3 = new int[num2 + 1];
		for (int i = 0; i <= num2; i++)
		{
			array2[i] = i;
		}
		for (int j = 1; j <= num; j++)
		{
			array3[0] = j;
			for (int k = 1; k <= num2; k++)
			{
				int num4 = ((s[j - 1] != t[k - 1]) ? 1 : 0);
				int num5 = array2[k] + 1;
				int num6 = array3[k - 1] + 1;
				int num7 = array2[k - 1] + num4;
				int num8 = num5;
				if (num6 < num8)
				{
					num8 = num6;
				}
				if (num7 < num8)
				{
					num8 = num7;
				}
				if (j > 1 && k > 1 && s[j - 1] == t[k - 2] && s[j - 2] == t[k - 1])
				{
					int num9 = array[k - 2] + num4;
					if (num9 < num8)
					{
						num8 = num9;
					}
				}
				array3[k] = num8;
			}
			int[] array4 = array;
			array = array2;
			array2 = array3;
			array3 = array4;
		}
		return array2[num2];
	}
}
