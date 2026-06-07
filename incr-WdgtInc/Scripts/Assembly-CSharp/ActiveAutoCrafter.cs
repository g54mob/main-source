using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item;
using Assets.Source.UI;
using Assets.Source.Util;
using Assets.Source.World;
using UnityEngine;

public class ActiveAutoCrafter : MonoBehaviour, IHasConstructionProgress, ITooltipCustomSource, ITooltipTextSource
{
	[SerializeField]
	protected FrameButton _purchaseButton;

	[SerializeField]
	protected SpriteRenderer _inactiveContent;

	[SerializeField]
	protected Transform _activeContent;

	[SerializeField]
	protected Transform _constructionContent;

	[SerializeField]
	protected string _tooltipActionVerb = "@AutoCrafterDescCrafts";

	[SerializeField]
	protected string _tooltipActionOverride;

	[SerializeField]
	protected bool _autoInactive = true;

	protected ActiveWorldFrame _frame;

	protected ActiveWorldAnchor _anchor;

	public AutoWorker Worker { get; private set; }

	protected virtual void Start()
	{
		_frame = GetComponentInParent<ActiveWorldFrame>();
		_anchor = GetComponent<ActiveWorldAnchor>();
		if (_autoInactive)
		{
			_inactiveContent.sprite = _activeContent.GetComponent<SpriteRenderer>().sprite;
		}
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
		if (Worker == null)
		{
			tooltip.AddCostLines(_frame.ActiveFrame.GetAutoWorkerCost());
		}
	}

	public string GetTooltipText()
	{
		if (_frame.ActiveFrame is CraftingFrame craftingFrame)
		{
			using (IEnumerator<KeyValuePair<ItemType, BigInteger>> enumerator = craftingFrame.GetResults().GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					KeyValuePair<ItemType, BigInteger> current = enumerator.Current;
					string text = ((!string.IsNullOrEmpty(_tooltipActionOverride)) ? _tooltipActionOverride : "@AutoCrafterGenericDesc");
					return Translation.Translate(text, _tooltipActionVerb, (current.Value == 1L) ? "@AutoCrafterCountSingular" : current.Value.ToString(), (current.Value == 1L) ? current.Key.DisplayNameLowercase : current.Key.DisplayNamePluralLowercase, craftingFrame.GetCraftingTime(handCraft: false).ToString("0.#"));
				}
			}
			if (!string.IsNullOrEmpty(_tooltipActionOverride))
			{
				return Translation.Translate(_tooltipActionOverride, craftingFrame.GetCraftingTime(handCraft: false).ToString("0.#"));
			}
		}
		return "";
	}
}
