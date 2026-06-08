using SafeTypes;
using UnityEngine;

public class LostBoostPoints : MonoBehaviour
{
	public int amount;

	public int ifPoison;

	public int ifVigor;

	public int ifAEther;

	public int ifFire;

	public int ifIce;

	private SafeInt safeAmount;

	public int GetLostBoostPoints()
	{
		return safeAmount.GetValue();
	}

	private void Start()
	{
		Item component = GetComponent<Item>();
		if (component.element == ItemData.Element.Poison)
		{
			safeAmount = new SafeInt(ifPoison);
		}
		else if (component.element == ItemData.Element.Vigor)
		{
			safeAmount = new SafeInt(ifVigor);
		}
		else if (component.element == ItemData.Element.AEther)
		{
			safeAmount = new SafeInt(ifAEther);
		}
		else if (component.element == ItemData.Element.Fire)
		{
			safeAmount = new SafeInt(ifFire);
		}
		else if (component.element == ItemData.Element.Ice)
		{
			safeAmount = new SafeInt(ifIce);
		}
		else
		{
			safeAmount = new SafeInt(amount);
		}
	}
}
