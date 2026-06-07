public class GE_UnlockBuilding : GameplayEffect
{
	protected override void OnInitEffect()
	{
		GameplayObjectData[] buildingsToUnlock = (base.EffectData as GE_UnlockBuildingData).BuildingsToUnlock;
		foreach (GameplayObjectData gameplayObjectData in buildingsToUnlock)
		{
			if ((bool)gameplayObjectData)
			{
				LTFunctionLibrary.GetPlayerData().UnlockBuilding(gameplayObjectData);
			}
		}
	}
}
