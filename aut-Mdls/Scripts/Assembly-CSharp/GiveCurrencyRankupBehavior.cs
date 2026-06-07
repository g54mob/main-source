using Data.FactoryFloor.Resources;
using Events.FactoryFloor;
using UnityEngine;

[CreateAssetMenu(fileName = "GiveExpansionPermitRankupBehavior", menuName = "Rank System/Behaviors/GiveExpansionPermitRankupBehavior")]
public class GiveCurrencyRankupBehavior : AbstractRankUpBehavior
{
	[SerializeField]
	private ResourceDataSO _currencyType;

	[SerializeField]
	private int _amount;

	[SerializeField]
	private AddCurrencyEvent _addCurrencyEvent;

	public ResourceDataSO CurrencyType => _currencyType;

	public int Amount => _amount;

	public override void Execute()
	{
		_addCurrencyEvent.Fire(new AddCurrencyEventDto(_currencyType, _amount));
	}
}
