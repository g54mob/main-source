using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;
using Assets.Behaviour.Overview;
using Assets.Behaviour.UI.Frame;
using Assets.Source.Buff;
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
	protected SpriteRenderer _base;

	[SerializeField]
	protected SpriteRenderer _icon;

	[SerializeField]
	private SpriteRenderer _constructionIcon;

	[SerializeField]
	private SpriteRenderer _warningIcon;

	[SerializeField]
	private WorldOverviewCellBuff _buffPrefab;

	private bool _underConstruction;

	private bool _clickStart;

	private bool _pickerStart;

	private UITooltip _tooltip;

	private bool _tooltipExtraInfo;

	public static WorldOverviewCell Highlighted { get; private set; }

	public WorldFrame Frame { get; private set; }

	protected virtual void Start()
	{
		UpdateWarningIcon();
		UpdateBuffs();
	}

	private void OnEnable()
	{
		if (Frame != null)
		{
			UpdateWarningIcon();
			UpdateBuffs();
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
			if (Frame.Deconstructable)
			{
				foreach (KeyValuePair<ItemType, BigInteger> item in Frame.getDeconstructRefund())
				{
					GamePlayer.Current.AddInventoryItem(item.Key, item.Value, addToStats: false);
				}
				UISounds.TurnPage();
				WorldMap.Current.RemoveFrame(Frame);
			}
			else
			{
				OverviewUI.Instance.ShowWarning(base.transform, "@WarningCantRemove");
			}
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
		else if (!OverviewUI.Instance.AbilityActive)
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
		Highlighted = this;
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
		if (Highlighted == this)
		{
			Highlighted = null;
		}
		if (_clickStart && Input.GetMouseButton(0) && GamePlayer.Current.HasTech("t3_move_frame"))
		{
			if (Frame.Movable)
			{
				OverviewUI.Instance.ShowRelocateGhost(this);
			}
			else
			{
				OverviewUI.Instance.ShowWarning(base.transform, "@WarningCantMove");
			}
		}
		_clickStart = false;
	}

	public void TogglePicker()
	{
		OverviewUI.Instance.ShowPurchaseGhost(WorldManager.Instance.GetFramePrefabSet(Frame.PrefabName), Frame, GamePlayer.Current.HasTech("t5_copy_paste"));
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

	protected virtual void Update()
	{
		if (_underConstruction && !Frame.UnderConstruction)
		{
			_constructionIcon.gameObject.SetActive(value: false);
			_underConstruction = false;
			UITooltip.Refresh();
		}
		if ((bool)_tooltip && _tooltip.gameObject.activeInHierarchy && PlayerControls.ModifierShift != _tooltipExtraInfo)
		{
			_tooltip.SetContent(GetComponent<TooltipSource>());
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
		_tooltip = tooltip;
		_tooltipExtraInfo = PlayerControls.ModifierShift;
		if (Frame.UnderConstruction)
		{
			_addConstructionTooltipContent(tooltip);
		}
		else if (OverviewUI.Instance.DeconstructActive)
		{
			_addDeconstructTooltipContent(tooltip);
		}
		else if (_tooltipExtraInfo)
		{
			FrameInfoTooltip.AddTooltipInfoContent(Frame, tooltip);
		}
		else
		{
			_addDetailsTooltipContent(tooltip);
		}
	}

	public void AddBuff(FrameBuff buff)
	{
		float num = -0.65f;
		WorldOverviewCellBuff[] componentsInChildren = GetComponentsInChildren<WorldOverviewCellBuff>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (Mathf.Abs(componentsInChildren[i].transform.localPosition.y - num) < 0.05f)
			{
				num += 0.15f;
			}
		}
		WorldOverviewCellBuff worldOverviewCellBuff = Object.Instantiate(_buffPrefab, base.transform);
		worldOverviewCellBuff.SetBuff(buff);
		worldOverviewCellBuff.transform.localPosition = new UnityEngine.Vector3(-0.75f, num, -1f);
	}

	private void _addConstructionTooltipContent(UITooltip tooltip)
	{
		tooltip.AddTextLine("@TooltipConstructionCancel");
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
		int autoWorkerMax = Frame.AutoWorkerMax;
		for (int i = 0; i < autoWorkerMax; i++)
		{
			if (Frame.GetAutoWorker(i) != null)
			{
				num3++;
			}
		}
		Frame.AddCustomTooltipLines(tooltip);
		if (autoWorkerMax > 0)
		{
			tooltip.AddTextLine(Translation.Translate("@TooltipWorkerCount", num3, autoWorkerMax));
		}
		if (num2 > 0)
		{
			tooltip.AddTextLine(Translation.Translate("@TooltipUpgradeCount", num, num2));
		}
		if (GamePlayer.Current.HasTech("t4_overview_upgrade") && (num3 < autoWorkerMax || num < num2))
		{
			tooltip.AddTextLine("");
			tooltip.AddTextLine("@TooltipBuyCheapestUpgrade");
		}
		if (Frame.PlacementTech != null && GamePlayer.Current.HasTech(Frame.PlacementTech))
		{
			tooltip.AddTextLine("");
			string text = ((Frame.CurrentPlacementBonus > 1.0) ? "green" : "red");
			string input = Translation.TranslateOnly("@TooltipPlacementBonus", GameMath.FormatPercentage(Frame.CurrentPlacementBonus - 1.0));
			tooltip.AddTextLine(Regex.Replace(input, "#(.*?)#", "<color=" + text + ">$1</color>"));
			tooltip.AddTextLine(Frame.PlacementTech.Description);
		}
		tooltip.AddTextLine("");
		tooltip.AddTextLine("@FrameDetailsExpand");
	}

	private void _addDeconstructTooltipContent(UITooltip tooltip)
	{
		if (Frame.Deconstructable)
		{
			tooltip.AddTextLine("@TooltipDeconstruct");
			tooltip.AddTextLine("@TooltipRefundHeader").Text.alignment = TextAlignmentOptions.TopRight;
			tooltip.AddItemLines(Frame.getDeconstructRefund());
		}
		else
		{
			tooltip.AddTextLine("@TooltipCantDeconstruct");
		}
	}

	public void UpdateWarningIcon()
	{
		_warningIcon.gameObject.SetActive(GamePlayer.Current.HasTech(_warningTech) && !Frame.IsFullyUpgrading());
	}

	public void UpdateBuffs()
	{
		List<FrameBuff> list = new List<FrameBuff>();
		WorldOverviewCellBuff[] componentsInChildren = GetComponentsInChildren<WorldOverviewCellBuff>();
		foreach (WorldOverviewCellBuff worldOverviewCellBuff in componentsInChildren)
		{
			list.Add(worldOverviewCellBuff.Buff);
		}
		foreach (FrameBuff buff in Frame.Buffs)
		{
			if (!list.Contains(buff))
			{
				AddBuff(buff);
			}
		}
	}

	public ConstructionProgress GetConstructionProgress()
	{
		return Frame.Construction;
	}
}
