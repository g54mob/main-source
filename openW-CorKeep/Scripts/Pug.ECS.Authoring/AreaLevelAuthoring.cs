using UnityEngine;

[DisallowMultipleComponent]
public class AreaLevelAuthoring : MonoBehaviour
{
	public AreaLevel areaLevel;

	[HideInInspector]
	public int level;

	[HideInInspector]
	public EntityMonoBehaviourData entityMono;

	public bool forceGenerateLevelEntities;

	private void OnValidate()
	{
		if (!Application.isPlaying)
		{
			level = CalculateLevel();
		}
	}

	public int CalculateLevel()
	{
		int result = 0;
		if (entityMono == null || entityMono.gameObject != base.gameObject)
		{
			entityMono = GetComponent<EntityMonoBehaviourData>();
		}
		if (entityMono != null)
		{
			result = LevelScaling.GetLevelFromAreaLevelAndRarity(areaLevel, entityMono.objectInfo.rarity);
		}
		else
		{
			ObjectAuthoring component = GetComponent<ObjectAuthoring>();
			if (component != null)
			{
				result = LevelScaling.GetLevelFromAreaLevelAndRarity(areaLevel, component.rarity);
			}
			else
			{
				Debug.LogWarning("Missing EntityMonobehaviourData/ObjectAuthoring on " + base.gameObject);
			}
		}
		return result;
	}
}
