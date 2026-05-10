using System.Collections.Generic;

public class TooltipComponent_playerUpgrade_building : TooltipComponent
{
	protected override Dictionary<string, object> GetData()
	{
		GameplayObjectData value = (GetComponent<PlayerUpgradeUI>().PlayerUpgrade.GrantedGameplayEffects[0] as GE_UnlockBuildingData).BuildingsToUnlock[0];
		return new Dictionary<string, object> { { "buildingData", value } };
	}
}
