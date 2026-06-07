using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.Util;
using Assets.Source.World;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UITooltip : MonoBehaviour
{
	public static bool TooltipEnabled = true;

	private static UITooltip _current;

	private static UITooltip _prefab;

	private static RectTransform _parent;

	[SerializeField]
	private RectTransform _contentParent;

	[SerializeField]
	private UITooltipText _textPrefab;

	[SerializeField]
	private UITooltipItemText _itemPrefab;

	[SerializeField]
	private UITooltipConstructionText _constructionPrefab;

	[SerializeField]
	private UITooltipStatsText _statsPrefab;

	private List<UITooltipContent> _contentList;

	public TooltipSource Source { get; private set; }

	public RectTransform Content => _contentParent;

	public static void SetupTooltipContext(UITooltip prefab, RectTransform parent)
	{
		_prefab = prefab;
		_parent = parent;
	}

	public UITooltipText AddTextLine(string text, int size = 16, float margin = 8f)
	{
		UITooltipText uITooltipText = Object.Instantiate(_textPrefab, _contentParent);
		uITooltipText.SetText(text, size, margin);
		_contentList.Add(uITooltipText);
		return uITooltipText;
	}

	public void AddCostLines(IEnumerable<KeyValuePair<ItemType, BigInteger>> cost, int size = 16, float margin = 4f)
	{
		AddTextLine("@ConstructionCostLabel", size, margin).Text.alignment = TextAlignmentOptions.TopRight;
		if (AddItemLines(cost) == 0)
		{
			AddTextLine("@ConstructionCostFree", size, margin).Text.alignment = TextAlignmentOptions.TopRight;
		}
	}

	public int AddItemLines(IEnumerable<KeyValuePair<ItemType, BigInteger>> items, int size = 16, float margin = 4f)
	{
		int num = 0;
		foreach (KeyValuePair<ItemType, BigInteger> item in items)
		{
			AddItemLine(item.Key, item.Value, size, margin);
			num++;
		}
		return num;
	}

	public UITooltipItemText AddItemLine(ItemType item, BigInteger amt, int size = 16, float margin = 4f)
	{
		return AddItemLine(item, Translation.Translate("@ConstructionCostLine", amt, item.DisplayName), size, margin);
	}

	public UITooltipItemText AddItemLine(ItemType item, string text, int size = 16, float margin = 4f)
	{
		UITooltipItemText uITooltipItemText = Object.Instantiate(_itemPrefab, _contentParent);
		uITooltipItemText.SetText(text, size, margin);
		uITooltipItemText.SetItem(item);
		_contentList.Add(uITooltipItemText);
		return uITooltipItemText;
	}

	public void AddConstructionLine(ConstructionProgress construction, ItemType type, int size = 16, float margin = 4f)
	{
		UITooltipConstructionText uITooltipConstructionText = Object.Instantiate(_constructionPrefab, _contentParent);
		uITooltipConstructionText.SetText("", size, margin);
		uITooltipConstructionText.SetItem(type);
		uITooltipConstructionText.setConstruction(construction);
		uITooltipConstructionText.Update();
		_contentList.Add(uITooltipConstructionText);
	}

	public void AddConstructionLines(ConstructionProgress construction)
	{
		foreach (KeyValuePair<ItemType, BigInteger> requiredMaterial in construction.RequiredMaterials)
		{
			AddConstructionLine(construction, requiredMaterial.Key);
		}
	}

	public void AddItemTooltip(ItemType item, int size = 16, float margin = 4f)
	{
		AddTextLine(item.Description);
		AddStatsLine(item, UITooltipStatsType.Total);
		AddStatsLine(item, UITooltipStatsType.Production);
		AddStatsLine(item, UITooltipStatsType.Consumption);
		if (item != ItemType.HumanRemains)
		{
			AddTextLine(Translation.Translate("@InventoryTheoreticalMax", GameMath.FormatNumber(GamePlayer.Current.GetMaxProduction(item), 1)));
		}
	}

	public void AddStatsLine(ItemType item, UITooltipStatsType type, int size = 16, float margin = 4f)
	{
		UITooltipStatsText uITooltipStatsText = Object.Instantiate(_statsPrefab, _contentParent);
		uITooltipStatsText.SetText("", size, margin);
		uITooltipStatsText.SetItem(item, type);
		uITooltipStatsText.Update();
		_contentList.Add(uITooltipStatsText);
	}

	public void SetContent(TooltipSource tt)
	{
		_contentParent.DestroyChildren();
		_contentList = new List<UITooltipContent>();
		Source = tt;
		string title = tt.GetTitle();
		if (!string.IsNullOrEmpty(title))
		{
			AddTextLine(title, 24, 10f);
		}
		string bodyText = tt.GetBodyText();
		if (!string.IsNullOrEmpty(bodyText))
		{
			AddTextLine(bodyText);
		}
		tt.AddCustomContent(this);
		RectTransform rectTransform = base.transform as RectTransform;
		float num = 0f;
		float num2 = 0f;
		foreach (UITooltipContent content in _contentList)
		{
			RectTransform obj = content.transform as RectTransform;
			obj.anchoredPosition = new UnityEngine.Vector2(obj.anchoredPosition.x, 0f - num);
			num += content.Height;
			num2 = content.Spacing;
		}
		rectTransform.sizeDelta = new UnityEngine.Vector2(rectTransform.sizeDelta.x, num - num2 + 20f);
		Update();
	}

	public void RefreshContent()
	{
		SetContent(Source);
	}

	private void Update()
	{
		UnityEngine.Vector2 value = Mouse.current.position.value;
		RectTransform obj = base.transform as RectTransform;
		UnityEngine.Vector2 sizeDelta = obj.sizeDelta;
		UnityEngine.Vector2 anchoredPosition = new UnityEngine.Vector2(value.x + 10f, value.y);
		UnityEngine.Vector2 pivot = new UnityEngine.Vector2(0f, 0f);
		if (anchoredPosition.x + sizeDelta.x > (float)Screen.width)
		{
			anchoredPosition = new UnityEngine.Vector2(value.x - 10f, value.y);
			pivot = new UnityEngine.Vector2(1f, 0f);
		}
		if (anchoredPosition.y + sizeDelta.y > (float)Screen.height)
		{
			pivot = new UnityEngine.Vector2(pivot.x, 1f);
		}
		obj.anchoredPosition = anchoredPosition;
		obj.pivot = pivot;
	}

	public static void Show(TooltipSource tt)
	{
		if ((bool)_current)
		{
			Object.Destroy(_current.gameObject);
		}
		if (TooltipEnabled)
		{
			_current = Object.Instantiate(_prefab, _parent);
			_current.SetContent(tt);
		}
	}

	public static void Refresh()
	{
		if ((bool)_current)
		{
			_current.RefreshContent();
		}
	}

	public static void Hide(TooltipSource tt)
	{
		if ((bool)_current && _current.Source == tt)
		{
			Object.Destroy(_current.gameObject);
		}
	}
}
