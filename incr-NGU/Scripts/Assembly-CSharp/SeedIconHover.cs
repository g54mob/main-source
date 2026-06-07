using UnityEngine;

public class SeedIconHover : MonoBehaviour
{
	public HoverTooltip tooltip;

	public void seedInfo()
	{
		tooltip.showTooltip("This is your Seed count. All fruits can be eaten or harvested, which give you seeds. Seeds can be used to upgrade the length of time (Tier) that fruits can grow, upgrade a fruit's effects, and more, once 4G stops being lazy and adds more fun stuff to do!");
	}

	public void poopInfo()
	{
		tooltip.showTooltip("This is your Poop count. Each poop allows one fruit to be harvested or eaten for a +50% bonus to the results!");
	}

	public void ConsumeAllInfo()
	{
		tooltip.showTooltip("This will harvest or eat all fruits that have reached their max tier and use your poop, depending on each fruit's settings.");
	}

	public void devourAllInfo()
	{
		tooltip.showTooltip("This will harvest or eat all fruits above tier 1 and use your poop, depending on each fruit's settings.");
	}

	public void exitTooltip()
	{
		tooltip.hideTooltip();
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
