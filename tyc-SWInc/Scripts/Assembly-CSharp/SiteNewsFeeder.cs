using System;
using System.Collections.Generic;
using System.Text;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SiteNewsFeeder : MonoBehaviour
{
	public Button TitlePrefab;

	public NewsContentItem[] ContentPrefabs;

	public GameObject SplitterPrefab;

	public Transform ContentPanel;

	private Dictionary<int, List<NewsContentItem>> _contentPool = new Dictionary<int, List<NewsContentItem>>();

	private List<NewsContentItem> _activeItems = new List<NewsContentItem>();

	private int _activeHeader = -1;

	[NonSerialized]
	private string[] _lines;

	[NonSerialized]
	private int _newsPos;

	private bool _noPri = true;

	private NewsContentItem GetContent(int type)
	{
		List<NewsContentItem> orNull = _contentPool.GetOrNull(type);
		if (orNull != null && orNull.Count > 0)
		{
			NewsContentItem newsContentItem = orNull[orNull.Count - 1];
			orNull.RemoveAt(orNull.Count - 1);
			newsContentItem.gameObject.SetActive(true);
			_activeItems.Add(newsContentItem);
			return newsContentItem;
		}
		NewsContentItem newsContentItem2 = UnityEngine.Object.Instantiate(ContentPrefabs[type]);
		newsContentItem2.transform.SetParent(ContentPanel, false);
		_activeItems.Add(newsContentItem2);
		return newsContentItem2;
	}

	public void OnScroll(Vector2 vel)
	{
		if (vel.y == 0f)
		{
			FetchNext();
		}
	}

	private void RetireContent(NewsContentItem content)
	{
		content.transform.SetAsLastSibling();
		content.gameObject.SetActive(false);
		_contentPool.Append(content.Type, content);
	}

	private void FetchNext()
	{
		List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
		StringBuilder stringBuilder = new StringBuilder();
		Versioning.Version version = Versioning.DisectVersionString(Options.LastVersion);
		float num = 0f;
		int i = _newsPos;
		int num2 = 0;
		for (; i < _lines.Length; i++)
		{
			list.Clear();
			UnityEngine.Object.Instantiate(SplitterPrefab).transform.SetParent(ContentPanel, false);
			Button title = UnityEngine.Object.Instantiate(TitlePrefab);
			title.transform.SetParent(ContentPanel, false);
			Text[] componentsInChildren = title.GetComponentsInChildren<Text>();
			bool flag = false;
			string v;
			if (_lines[i][1] == '>')
			{
				v = _lines[i].Substring(2);
				flag = _noPri;
				_noPri = false;
			}
			else
			{
				v = _lines[i].Substring(1, _lines[i].Length - 1);
			}
			componentsInChildren[0].text = v;
			title.GetComponentsInChildren<Image>()[1].gameObject.SetActive(version < Versioning.DisectVersionString(v));
			componentsInChildren[1].text = _lines[i + 1];
			int j;
			for (j = i + 2; j < _lines.Length && _lines[j][0] != '>'; j++)
			{
				bool flag2 = false;
				if (_lines[j][0] == '*')
				{
					stringBuilder.AppendLine("• " + _lines[j].Substring(1, _lines[j].Length - 1));
					flag2 = true;
					num2++;
				}
				else if (stringBuilder.Length > 0)
				{
					list.Add(new KeyValuePair<int, string>(1, stringBuilder.ToString()));
					stringBuilder.Clear();
				}
				if (_lines[j][0] == '-')
				{
					list.Add(new KeyValuePair<int, string>(0, _lines[j].Substring(1, _lines[j].Length - 1)));
					flag2 = true;
				}
				if (!flag2)
				{
					list.Add(new KeyValuePair<int, string>(2, _lines[j]));
				}
			}
			if (stringBuilder.Length > 0)
			{
				list.Add(new KeyValuePair<int, string>(1, stringBuilder.ToString()));
				stringBuilder.Clear();
			}
			KeyValuePair<int, string>[] final = list.ToArray();
			int i2 = i;
			title.onClick.AddListener(delegate
			{
				CopySteam("Patch notes for " + v, final, Input.GetKey(KeyCode.LeftControl));
				PopulateItem(title.transform, final, i2);
			});
			if (flag)
			{
				num += (float)((num2 + final.Length) * 24);
				PopulateItem(title.transform, final, i);
			}
			num2 = 0;
			i = j - 1;
			num += 23f;
			if (num > (float)(Screen.height - 191))
			{
				break;
			}
		}
		_newsPos = i + 1;
	}

	private void Start()
	{
		_lines = GameData.LoadTextAsset("PatchNotes");
		FetchNext();
		CanvasGroup cg = GetComponent<CanvasGroup>();
		DOTween.To(() => cg.alpha, delegate(float x)
		{
			cg.alpha = x;
		}, 1f, 0.5f);
	}

	private void CopySteam(string title, KeyValuePair<int, string>[] content, bool discord)
	{
	}

	private void PopulateItem(Transform item, KeyValuePair<int, string>[] content, int header)
	{
		_activeItems.ForEach(RetireContent);
		_activeItems.Clear();
		if (header == _activeHeader)
		{
			_activeHeader = -1;
			return;
		}
		_activeHeader = header;
		int siblingIndex = item.GetSiblingIndex() + 1;
		for (int num = content.Length - 1; num >= 0; num--)
		{
			NewsContentItem content2 = GetContent(content[num].Key);
			content2.Label.text = content[num].Value;
			content2.transform.SetSiblingIndex(siblingIndex);
		}
	}

	public static void AbortIfActive()
	{
	}
}
