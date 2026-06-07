using UnityEngine.Events;

public class ProductionConfig
{
	public ProductionLimitType type;

	public float targetRate;

	public float targetDemandPercent;

	public bool restrictOptions;

	public StateManager linkedState;

	public BuildingState parentBuilding;

	public UnityAction onChangedDelegate;

	public void Reset()
	{
		type = ProductionLimitType.DefaultNone;
		targetRate = 0f;
		targetDemandPercent = 0f;
	}

	public void OnChanged()
	{
		onChangedDelegate?.Invoke();
		linkedState?.CalcAppliedProductionLimit();
		if (parentBuilding != null)
		{
			parentBuilding.parentTown.CalcAllProductionLimits();
			if (parentBuilding.type == BuildingType.School)
			{
				MenuManager.Instance.combinedProductionPanel.isProductionLimitStale = true;
			}
			if (parentBuilding.type == BuildingType.TradingPost)
			{
				MenuManager.Instance.combinedProductionPanel.isProductionLimitStale = true;
			}
			if (parentBuilding.type == BuildingType.Market)
			{
				MenuManager.Instance.combinedProductionPanel.isProductionLimitStale = true;
			}
		}
	}
}
