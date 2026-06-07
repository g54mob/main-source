using System.Collections.Generic;

public class Perk_InfernoShard_Cannon : APerkBase
{
	private class TowerPriceIncreaseRecord
	{
		public eItemType type;

		public float priceModifier;
	}

	private List<ABaseTower> list_TowerBuiltInRound;

	private List<TowerPriceIncreaseRecord> list_PriceIncreaseRecords;

	private int shardLevel;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnTowerSold(ABaseTower tower)
	{
	}

	private void OnTowerPlaced(ABaseTower tower)
	{
	}

	private void OnRoundEnd()
	{
	}
}
