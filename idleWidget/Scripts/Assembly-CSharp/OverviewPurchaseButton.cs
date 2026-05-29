using Assets.Source.Player;
using Assets.Source.UI;
using Assets.Source.Util;
using Assets.Source.World;
using Assets.Source.World.Frames;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OverviewPurchaseButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, ITooltipTitleSource, ITooltipTextSource, ITooltipCustomSource, IBeginDragHandler, IDragHandler
{
	public static TechNode HighlightTech = "t4u_highlight_frames";

	[SerializeField]
	private Image _button;

	[SerializeField]
	private Image _icon;

	[SerializeField]
	private TMP_Text _frameCount;

	private FramePrefabSet _prefabSet;

	public WorldFrame Frame { get; private set; }

	public void SetFrame(FramePrefabSet prefab, WorldFrame frame)
	{
		Frame = frame;
		_prefabSet = prefab;
		_button.sprite = prefab.OverviewSprite;
		_icon.sprite = Frame.Icon;
	}

	public void SetFrameCount(int count)
	{
		_frameCount.text = GameMath.FormatNumber(count);
		_frameCount.gameObject.SetActive(value: true);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right && GamePlayer.Current.HasTech(HighlightTech))
		{
			PlayerControls.RightClickUtilized = true;
			WorldOverview.Instance.HighlightCell(Frame);
		}
		else
		{
			OverviewUI.Instance.ShowPurchaseGhost(_prefabSet, Frame);
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		OverviewUI.Instance.ShowPurchaseGhost(_prefabSet, Frame);
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public string GetTooltipTitle()
	{
		return Frame.DisplayName;
	}

	public string GetTooltipText()
	{
		string text = Frame.Description;
		if (Frame.PlacementTech != null && GamePlayer.Current.HasTech(Frame.PlacementTech))
		{
			text = text + "\n\n" + Frame.PlacementTech.Description;
		}
		if (GamePlayer.Current.HasTech(HighlightTech))
		{
			text = text + "\n\n" + UIHelper.HighlightText("Right-click") + " to highlight all frames of this type";
		}
		if (Frame.Identifier == "T1IronIngot" && WorldMap.Current.GetFrame<T1IronIngot>() == null)
		{
			text = text + "\n\n" + UIHelper.HighlightText("Requires an active source of Iron Ore to smelt.");
		}
		else if (Frame.Identifier == "T1IronOre" && WorldMap.Current.GetFrame<T1IronOre>() == null)
		{
			text = text + "\n\n" + UIHelper.HighlightText("Iron Ore can be harvested anywhere on the map; you don't need to worry about placement right now.");
		}
		return text;
	}

	public void AddTooltipCustomContent(UITooltip tooltip)
	{
		tooltip.AddCostLines(Frame.GetPurchaseCost());
	}
}
