public class GE_GiveResources : GameplayEffect
{
	protected override void OnInitEffect()
	{
		if (!LTFunctionLibrary.GetLTGameManager().IsLoadedGame)
		{
			Cost[] resourcesToGive = (base.EffectData as GE_GiveResourcesData).ResourcesToGive;
			foreach (Cost cost in resourcesToGive)
			{
				LTFunctionLibrary.GetPlayerInventory().StoreObject(cost.Resource, cost.Amount, Storage_ResourceData.EStoreSource.Effect);
			}
		}
	}
}
