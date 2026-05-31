using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.UI;
using Assets.Source.Util;
using Assets.Source.World;
using TMPro;
using UnityEngine;

public class WorldOverviewCell : MonoBehaviour, ITooltipTextSource, ITooltipTitleSource, ITooltipCustomSource, IHasConstructionProgress
{
	private static TechNode _warningTech = "t4_overview_upgrade_status";

	private static Color _highlightColor = Color.white;

	private static Color _fadedColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);

	[SerializeField]
	private SpriteRenderer _base;

	[SerializeField]
	private SpriteRenderer _icon;

	[SerializeField]
	private SpriteRenderer _constructionIcon;

	[SerializeField]
	private SpriteRenderer _warningIcon;

	private bool _underConstruction;

	private bool _clickStart;

	private bool _pickerStart;

	public WorldFrame Frame { get; private set; }

	private void Start()
	{
		UpdateWarningIcon();
	}

	private void OnEnable()
	{
		if (Frame != null)
		{
			UpdateWarningIcon();
		}
	}

	private void OnDisable()
	{
		_clickStart = false;
		_pickerStart = false;
	}

	private void OnMouseUpAsButton()
	{
		if (UIHelper.IsMouseOverUi || OverviewUI.HasGhost || OverviewUI.Instance.CopyActive || Frame.UnderConstruction)
		{
			return;
		}
		if (OverviewUI.Instance.DeconstructActive)
		{
			foreach (KeyValuePair<ItemType, int> item in Frame.getDeconstructRefund())
			{
				GamePlayer.Current.AddInventoryItem(item.Key, item.Value, addToStats: false);
			}
			UISounds.TurnPage();
			WorldMap.Current.RemoveFrame(Frame);
		}
		else if (PlayerControls.ModifierControl)
		{
			if (GamePlayer.Current.HasTech("t4_overview_upgrade") && Frame.PurchaseCheapestUpgrade())
			{
				UISounds.CraftStep();
				UITooltip.Refresh();
				UpdateWarningIcon();
			}
		}
		else
		{
			WorldManager.Instance.ShowFrame(Frame, showUI: true);
		}
	}

	public void SetRelocating(bool r)
	{
		Color color = new Color(1f, 1f, 1f, r ? 0.3f : 1f);
		_base.color = color;
		_icon.color = color;
	}

	private void OnMouseOver()
	{
		if (UIHelper.IsMouseOverUi)
		{
			return;
		}
		if (Input.GetMouseButtonDown(2))
		{
			_pickerStart = true;
		}
		else if (Input.GetMouseButtonUp(2))
		{
			if (_pickerStart && OverviewUI.Instance.Traversable.ScrollDistance < 1f)
			{
				OverviewUI.Instance.ShowPurchaseGhost(WorldManager.Instance.GetFramePrefabSet(Frame.PrefabName), Frame, GamePlayer.Current.HasTech("t5_copy_paste"));
			}
			_pickerStart = false;
		}
		if (PlayerControls.InteractPressed)
		{
			_clickStart = true;
		}
		else if (PlayerControls.InteractRelease)
		{
			_clickStart = false;
		}
		if (Frame.UnderConstruction && PlayerControls.InputCancel)
		{
			Frame.CancelConstruction();
		}
	}

	private void OnMouseExit()
	{
		if (_clickStart && Input.GetMouseButton(0) && GamePlayer.Current.HasTech("t3_move_frame"))
		{
			OverviewUI.Instance.ShowRelocateGhost(this);
		}
		_clickStart = false;
	}

	public void SetFrame(WorldFrame frame)
	{
		Frame = frame;
		FramePrefabSet framePrefabSet = WorldManager.Instance.GetFramePrefabSet(frame.Identifier);
		_base.sprite = framePrefabSet.OverviewSprite;
		_icon.sprite = frame.Icon;
		_underConstruction = frame.UnderConstruction;
		_constructionIcon.gameObject.SetActive(_underConstruction);
	}

	public void SetHighlight(WorldFrame cellType)
	{
		bool flag = cellType == null || cellType.Identifier == Frame.Identifier;
		_base.color = (flag ? _highlightColor : _fadedColor);
		_base.material = (flag ? Materials.Default : Materials.Grayscale);
		_icon.color = (flag ? _highlightColor : _fadedColor);
		_icon.material = (flag ? Materials.Default : Materials.Grayscale75);
		_constructionIcon.color = (flag ? _highlightColor : _fadedColor);
		_constructionIcon.material = (flag ? Materials.Default : Materials.Grayscale75);
	}

	private void Update()
	{
		if (_underConstruction && !Frame.UnderConstruction)
		{
			_constructionIcon.gameObject.SetActive(value: false);
			_underConstruction = false;
			UITooltip.Refresh();
		}
	}

	public string GetTooltipTitle()
	{
		return Frame.DisplayName;
	}

	public string GetTooltipText()
	{
		return Frame.Description;
	}

	public void AddTooltipCustomContent(UITooltip tooltip)
	{
		if (Frame.UnderConstruction)
		{
			_addConstructionTooltipContent(tooltip);
		}
		else if (OverviewUI.Instance.DeconstructActive)
		{
			_addDeconstructTooltipContent(tooltip);
		}
		else
		{
			_addDetailsTooltipContent(tooltip);
		}
	}

	private void _addConstructionTooltipContent(UITooltip tooltip)
	{
		tooltip.AddTextLine(UIHelper.HighlightText("Right-click") + " to cancel construction.");
		tooltip.AddConstructionLines(Frame.Construction);
	}

	private void _addDetailsTooltipContent(UITooltip tooltip)
	{
		int num = 0;
		int num2 = 0;
		foreach (FrameUpgrade availableUpgrade in Frame.GetAvailableUpgrades())
		{
			if (availableUpgrade.IsAvailable)
			{
				num2++;
			}
			if (Frame.HasUpgrade(availableUpgrade) || Frame.UpgradeUnderConstruction(availableUpgrade))
			{
				num++;
			}
		}
		int num3 = 0;
		int autoWorkerCount = Frame.AutoWorkerCount;
		for (int i = 0; i < autoWorkerCount; i++)
		{
			if (Frame.GetAutoWorker(i) != null)
			{
				num3++;
			}
		}
		Frame.AddCustomTooltipLines(tooltip);
		if (autoWorkerCount > 0)
		{
			tooltip.AddTextLine("Workers: " + UIHelper.HighlightText(num3 + "/" + autoWorkerCount));
		}
		if (num2 > 0)
		{
			tooltip.AddTextLine("Upgrades: " + UIHelper.HighlightText(num + "/" + num2));
		}
		if (GamePlayer.Current.HasTech("t4_overview_upgrade") && (num3 < autoWorkerCount || num < num2))
		{
			tooltip.AddTextLine("");
			tooltip.AddTextLine(UIHelper.HighlightText("Control-click") + " to buy cheapest worker or upgrade.");
		}
		if (Frame.PlacementTech != null && GamePlayer.Current.HasTech(Frame.PlacementTech))
		{
			string text = ((Frame.CurrentPlacementBonus > 1f) ? "green" : "red");
			tooltip.AddTextLine("");
			tooltip.AddTextLine("Placement bonus: <color=" + text + ">" + GameMath.FormatPercentage(Frame.CurrentPlacementBonus - 1f) + "</color>");
			tooltip.AddTextLine(Frame.PlacementTech.Description);
		}
	}

	private void _addDeconstructTooltipContent(UITooltip tooltip)
	{
		tooltip.AddTextLine(UIHelper.HighlightText("Click") + " to deconstruct.");
		tooltip.AddTextLine("Refund:").Text.alignment = TextAlignmentOptions.TopRight;
		tooltip.AddItemLines(Frame.getDeconstructRefund());
	}

	public void UpdateWarningIcon()
	{
		_warningIcon.gameObject.SetActive(GamePlayer.Current.HasTech(_warningTech) && !Frame.IsFullyUpgraded());
	}

	public ConstructionProgress GetConstructionProgress()
	{
		return Frame.Construction;
	}
}
