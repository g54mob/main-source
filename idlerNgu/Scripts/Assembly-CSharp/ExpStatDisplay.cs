using UnityEngine;

public class ExpStatDisplay : MonoBehaviour
{
	public Character character;

	public EnergyPurchases energyPurchases;

	public AdventurePurchases adventurePurchases;

	public StatBoostPurchases statBoostPurchases;

	public MagicPurchases magicPurchases;

	public MiscPurchases miscPurchases;

	private void Start()
	{
	}

	public void refreshMenu()
	{
		energyPurchases.refresh();
		adventurePurchases.refresh();
		statBoostPurchases.refresh();
		magicPurchases.refresh();
		miscPurchases.refresh();
	}
}
