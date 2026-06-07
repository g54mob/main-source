using System.Collections.Generic;
using UnityEngine;

public class LTAssetsReferences : MonoBehaviour
{
	public static LTAssetsReferences instance;

	[SerializeField]
	private List<GameplayObjectData> buildingsReferences;

	[SerializeField]
	private List<ResourceData> resourceDatasReferences;

	[SerializeField]
	private List<GemData> gemDatasReferences;

	[SerializeField]
	private List<GameplayEffectData> gameplayEffectsDatasReferences;

	[SerializeField]
	private List<EnemyData> enemyDatasReference;

	private void Awake()
	{
		if (!instance)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public GameplayObjectData GetBuildingDataById(string buildingId)
	{
		for (int i = 0; i < buildingsReferences.Count; i++)
		{
			if (buildingsReferences[i].Id == buildingId)
			{
				return buildingsReferences[i];
			}
		}
		return null;
	}

	public ResourceData GetResourceDataById(string resourceId)
	{
		for (int i = 0; i < resourceDatasReferences.Count; i++)
		{
			if (resourceDatasReferences[i].Id == resourceId)
			{
				return resourceDatasReferences[i];
			}
		}
		return null;
	}

	public GemData GetGemDataById(string gemId)
	{
		for (int i = 0; i < gemDatasReferences.Count; i++)
		{
			if (gemDatasReferences[i].Id == gemId)
			{
				return gemDatasReferences[i];
			}
		}
		return null;
	}

	public GameplayEffectData GetGameplayEffectDataById(string geID)
	{
		for (int i = 0; i < gameplayEffectsDatasReferences.Count; i++)
		{
			if (gameplayEffectsDatasReferences[i].Id == geID)
			{
				return gameplayEffectsDatasReferences[i];
			}
		}
		return null;
	}

	public EnemyData GetEnemyDataById(string enemyDataId)
	{
		for (int i = 0; i < enemyDatasReference.Count; i++)
		{
			if (enemyDatasReference[i].Id == enemyDataId)
			{
				return enemyDatasReference[i];
			}
		}
		return null;
	}
}
