using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.UI;
using Assets.Source.World;
using UnityEngine;

public class ActiveAutoCrafter : MonoBehaviour, IHasConstructionProgress, ITooltipCustomSource, ITooltipTextSource
{
	[SerializeField]
	private FrameButton _purchaseButton;

	[SerializeField]
	private SpriteRenderer _inactiveContent;

	[SerializeField]
	private Transform _activeContent;

	[SerializeField]
	private Transform _constructionContent;

	[SerializeField]
	private string _tooltipActionName = "Crafts";

	private ActiveWorldFrame _frame;

	private ActiveWorldAnchor _anchor;

	public AutoWorker Worker { get; private set; }

	private void Start()
	{
		_frame = GetComponentInParent<ActiveWorldFrame>();
		_anchor = GetComponent<ActiveWorldAnchor>();
		_inactiveContent.sprite = _activeContent.GetComponent<SpriteRenderer>().sprite;
		SetupWorker();
	}

	public void SetupWorker()
	{
		Worker = _frame.ActiveFrame.GetAutoWorker(_anchor.Slot);
		_constructionContent.gameObject.SetActive(Worker?.UnderConstruction ?? false);
		_purchaseButton.gameObject.SetActive(Worker == null);
		bool flag = Worker != null && !Worker.UnderConstruction;
		_inactiveContent.gameObject.SetActive(!flag);
		_activeContent.gameObject.SetActive(flag);
	}

	public ConstructionProgress GetConstructionProgress()
	{
		return Worker.Construction;
	}

	public void AddTooltipCustomContent(UITooltip tooltip)
	{
		tooltip.AddCostLines(_frame.ActiveFrame.GetAutoWorkerCost());
	}

	public string GetTooltipText()
	{
		if (_frame.ActiveFrame is CraftingFrame craftingFrame)
		{
			using IEnumerator<KeyValuePair<ItemType, int>> enumerator = craftingFrame.GetRecipeResults().GetEnumerator();
			if (enumerator.MoveNext())
			{
				KeyValuePair<ItemType, int> current = enumerator.Current;
				string text = UIHelper.HighlightText(craftingFrame.GetCraftingTime(handCraft: false).ToString("0.#") + " seconds");
				if (_tooltipActionName.Contains("{0}"))
				{
					return string.Format(_tooltipActionName, text);
				}
				return _tooltipActionName + " " + ((current.Value == 1) ? ("one " + current.Key.DisplayName.ToLower()) : (current.Value + " " + current.Key.DisplayName.ToLower() + "s")) + " every " + text + ".";
			}
		}
		return "";
	}
}
