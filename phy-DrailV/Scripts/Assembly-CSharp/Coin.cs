using UnityEngine;

public class Coin : Money
{
	private const string PREFAB_NAME = "Coin";

	protected override double DefaultAmount => 1.0;

	public override double Amount
	{
		get
		{
			return amount;
		}
		set
		{
			amount = value;
		}
	}

	public static Coin MakeCoin(double value = 1.0)
	{
		Coin component = Object.Instantiate(Resources.Load<GameObject>("Coin")).GetComponent<Coin>();
		component.amount = value;
		return component;
	}
}
