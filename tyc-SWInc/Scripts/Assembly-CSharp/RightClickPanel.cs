using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RightClickPanel : MonoBehaviour
{
	public GameObject ButtonPrefab;

	public RectTransform CenterRing;

	public RectTransform SelfRect;

	public RectTransform CounterPanel;

	public Text CounterLabel;

	public int CounterAmount = 1;

	public Vector2 CounterDistance = new Vector2(180f, 160f);

	public Text Description;

	[NonSerialized]
	public Dictionary<RightClickButton, SelectorController.ACTCAT> Buttons = new Dictionary<RightClickButton, SelectorController.ACTCAT>();

	[NonSerialized]
	public Tweener ActiveRingTween;

	[NonSerialized]
	private SelectorController.CounterButton _lastCounter;

	private bool DisableClose;

	public void KillRingTween()
	{
		if (ActiveRingTween != null)
		{
			ActiveRingTween.Kill();
			ActiveRingTween = null;
		}
	}

	public void HandleCounter(SelectorController.CounterButton counter, float dir)
	{
		if (_lastCounter != counter)
		{
			CounterAmount = ((counter == null) ? 1 : counter.DefaultCount);
		}
		_lastCounter = counter;
		if (_lastCounter != null)
		{
			CounterPanel.gameObject.SetActive(true);
			CounterPanel.anchoredPosition = new Vector2(0f - Mathf.Sin(dir), Mathf.Cos(dir)) * CounterDistance;
			UpdateCounterLabel();
		}
		else
		{
			CounterPanel.gameObject.SetActive(false);
		}
	}

	private void UpdateCounterLabel()
	{
		if (_lastCounter != null)
		{
			CounterLabel.text = _lastCounter.Countable(CounterAmount);
		}
	}

	public void Activate(string[] cats)
	{
		if (Buttons.Count == 0)
		{
			return;
		}
		UISoundFX.PlaySFX("ContextMenu");
		CenterRing.gameObject.SetActive(true);
		KillRingTween();
		CenterRing.GetComponent<Image>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		List<RightClickButton> list = null;
		if (cats.Length > 1)
		{
			list = new List<RightClickButton>();
			list.AddRange(from x in Buttons
				where (x.Value & SelectorController.ACTCAT.NULL) == SelectorController.ACTCAT.NULL
				select x.Key);
			foreach (string text in cats)
			{
				SelectorController.ACTCAT localItem = (SelectorController.ACTCAT)(1 << Array.IndexOf(SelectorController.Categories, text));
				RightClickButton rightClickButton = CreateButton(text, SelectorController.CategoryIcons[text], delegate
				{
					SetCategory(localItem);
				}, null, SelectorController.ContextButtonGroup.Group);
				Buttons[rightClickButton] = SelectorController.ACTCAT.NULL;
				list.Add(rightClickButton);
			}
		}
		else
		{
			list = Buttons.Keys.ToList();
		}
		list = list.OrderBy((RightClickButton x) => (int)x.Order).ToList();
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			list[num2].gameObject.SetActive(true);
			list[num2].DegWidth = 360f / (float)list.Count;
			list[num2].Pos = ((float)(-num2) + 0.5f) * (360f / (float)list.Count);
			list[num2].ActualPos = (float)(-num2) * (360f / (float)list.Count);
			list[num2].Init();
		}
	}

	public void Activate(Vector2 pos)
	{
		if (Buttons.Count != 0)
		{
			SelfRect.anchoredPosition = new Vector2(Mathf.Clamp(pos.x, 128f, (float)Screen.width / Options.UISize - 128f), Mathf.Clamp(0f - ((float)Screen.height / Options.UISize - pos.y), (float)(-Screen.height) / Options.UISize + 128f, -128f));
			CenterRing.sizeDelta = new Vector2(0f, 0f);
			CenterRing.DOSizeDelta(new Vector2(126f, 126f), 0.6f, true).SetEase(Ease.OutBounce);
			Activate(CategoryFromSelected().ToArray());
		}
	}

	private IEnumerable<string> CategoryFromSelected()
	{
		if (SelectorController.Instance.Selected.OfType<Actor>().Any((Actor x) => x.IsEmployee()))
		{
			yield return "Employee";
		}
		if (SelectorController.Instance.Selected.OfType<Actor>().Any((Actor x) => AI.IsStaff(x.AItype)))
		{
			yield return "Staff";
		}
		if (SelectorController.Instance.Selected.OfType<Room>().Any())
		{
			yield return "Room";
		}
		if (SelectorController.Instance.Selected.OfType<RoomSegment>().Any())
		{
			yield return "Segment";
		}
		if (SelectorController.Instance.Selected.OfType<Furniture>().Any())
		{
			yield return "Furniture";
		}
		if (SelectorController.Instance.Selected.OfType<RoadNode>().Any())
		{
			yield return "Parking";
		}
		if (SelectorController.Instance.Selected.OfType<Roof>().Any())
		{
			yield return "Roof";
		}
		if (SelectorController.Instance.Selected.OfType<PathObject>().Any())
		{
			yield return "Path";
		}
	}

	private string CatToString(SelectorController.ACTCAT cat)
	{
		switch (cat)
		{
		case SelectorController.ACTCAT.NULL:
			return null;
		case SelectorController.ACTCAT.FURN:
			return "Furniture";
		case SelectorController.ACTCAT.ROOM:
			return "Room";
		case SelectorController.ACTCAT.EMP:
			return "Employee";
		case SelectorController.ACTCAT.STAFF:
			return "Staff";
		case SelectorController.ACTCAT.SEG:
			return "Segment";
		case SelectorController.ACTCAT.ROOF:
			return "Roof";
		case SelectorController.ACTCAT.PATH:
			return "Path";
		default:
			return null;
		}
	}

	private void SetCategory(SelectorController.ACTCAT cat)
	{
		List<RightClickButton> list = new List<RightClickButton>();
		foreach (KeyValuePair<RightClickButton, SelectorController.ACTCAT> button in Buttons)
		{
			if ((button.Value & cat) == cat)
			{
				list.Add(button.Key);
			}
			else
			{
				UnityEngine.Object.Destroy(button.Key.gameObject);
			}
		}
		Buttons.Clear();
		foreach (RightClickButton item in list)
		{
			Buttons[item] = cat;
		}
		Activate(new string[1] { CatToString(cat) });
		DisableClose = true;
	}

	private RightClickButton CreateButton(string description, string icon, Action action, SelectorController.CounterButton counter, SelectorController.ContextButtonGroup order, bool? checkmark = null)
	{
		GameObject obj = UnityEngine.Object.Instantiate(ButtonPrefab);
		obj.name = description;
		RightClickButton component = obj.GetComponent<RightClickButton>();
		component.MainPanel = this;
		component.Order = order;
		component.Description = description.Loc();
		component.Icon.sprite = ObjectDatabase.GetIcon(icon);
		component.Counter = counter;
		if (checkmark.HasValue)
		{
			component.CheckMark.gameObject.SetActive(true);
			component.CheckMark.sprite = ObjectDatabase.GetIcon(checkmark.Value ? "Checkmark" : "Cross");
			component.CheckMark.color = (checkmark.Value ? component.CheckYes : component.CheckNo);
		}
		component.OnClick = delegate
		{
			try
			{
				action();
			}
			catch (Exception ex)
			{
				throw new Exception("Got error when performing action " + description + ":\n" + ex.ToString());
			}
		};
		obj.transform.SetParent(base.transform, false);
		return component;
	}

	public void AddButton(string description, string icon, Action action, SelectorController.CounterButton counter, SelectorController.ACTCAT category, SelectorController.ContextButtonGroup order, bool? checkmark = null)
	{
		if (CenterRing.gameObject.activeSelf)
		{
			Deactivate();
		}
		Buttons.Add(CreateButton(description, icon, action, counter, order, checkmark), category);
	}

	public void Deactivate()
	{
		if (CenterRing == null || CenterRing.gameObject == null)
		{
			return;
		}
		Description.text = "";
		CenterRing.gameObject.SetActive(false);
		foreach (KeyValuePair<RightClickButton, SelectorController.ACTCAT> button in Buttons)
		{
			UnityEngine.Object.Destroy(button.Key.gameObject);
		}
		Buttons.Clear();
		HandleCounter(null, 0f);
	}

	public bool IsCounting()
	{
		return _lastCounter != null;
	}

	private void Update()
	{
		if (_lastCounter != null)
		{
			int num = Mathf.RoundToInt(Input.mouseScrollDelta.y);
			if (num != 0)
			{
				CounterAmount = Mathf.Clamp(CounterAmount + num, _lastCounter.Min, _lastCounter.Max());
				UpdateCounterLabel();
			}
		}
	}

	private void LateUpdate()
	{
		if (Input.GetMouseButtonUp(0))
		{
			if (DisableClose)
			{
				DisableClose = false;
			}
			else
			{
				Deactivate();
			}
		}
		else if (HUD.Instance.pauseWindow.Panel.activeSelf)
		{
			DisableClose = false;
			Deactivate();
		}
	}
}
