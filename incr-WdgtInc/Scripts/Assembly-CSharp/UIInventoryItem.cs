using System.Numerics;
using Assets.Behaviour.UI;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.Util;
using Assets.Source.World;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private TMP_Text _text;

	[SerializeField]
	private Image _statusIcon;

	[SerializeField]
	private Image _fill;

	private ItemType _item;

	private float _updateTimer;

	private double _theoreticalMax;

	private void Update()
	{
		_updateTimer -= Time.deltaTime;
		if (_updateTimer < 0f)
		{
			_updateTimer = 0.5f;
			BigInteger inventoryCount = GamePlayer.Current.GetInventoryCount(_item);
			_text.text = Translation.Highlight("{0} #{1}#", (inventoryCount == 0L) ? "red" : "#00bb00", _item.DisplayName, GameMath.FormatItemCount(_item, inventoryCount)) + "\n" + Translation.Translate("@InventoryProduction", GameMath.FormatNumber(GamePlayer.Current.GetProductionStats(_item), 1)) + "\n" + Translation.Translate("@InventoryConsumption", GameMath.FormatNumber(GamePlayer.Current.GetConsumptionStats(_item), 1)) + "\n" + ((_item == ItemType.HumanRemains) ? "" : Translation.Translate("@InventoryTheoreticalMax", GameMath.FormatNumber(_theoreticalMax, 1)));
			float num = GameMath.Clamp01(inventoryCount, GamePlayer.Current.GetInventoryCapacity(_item));
			_fill.rectTransform.localScale = new UnityEngine.Vector3(1f, num, 1f);
			_fill.color = Color.Lerp(Color.red, Color.green, num);
		}
	}

	public void SetItem(ItemType item)
	{
		_item = item;
		_icon.sprite = item.Icon;
		if (item == ItemType.GlitchedWidget)
		{
			GlitchedIcon glitchedIcon = _icon.gameObject.AddComponent<GlitchedIcon>();
			glitchedIcon.SetWidget(v: true);
			glitchedIcon.Setup(null, _icon);
		}
		_theoreticalMax = GamePlayer.Current.GetMaxProduction(_item);
		Update();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		CraftingFrame recipe = _item.Recipe;
		if (recipe == null)
		{
			return;
		}
		foreach (WorldFrame frame in WorldMap.Current.Frames)
		{
			if (recipe.Identifier == frame.Identifier)
			{
				UISounds.TurnPage();
				WorldManager.Instance.ShowFrame(frame, showUI: true);
				GameUI.Inventory.Hide();
				break;
			}
		}
	}
}
