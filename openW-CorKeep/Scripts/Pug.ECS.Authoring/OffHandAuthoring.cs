using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
public class OffHandAuthoring : MonoBehaviour
{
	public OffHandMechanic mechanic;

	public float mechanicValue;

	public float mechanicMultiplier = 1f;

	[HideInInspector]
	public AreaLevelAuthoring level;

	[HideInInspector]
	public EntityMonoBehaviourData entityMono;

	[HideInInspector]
	public CooldownAuthoring cooldown;

	private void OnValidate()
	{
		if (!Application.isPlaying)
		{
			if (level == null || level.gameObject != base.gameObject)
			{
				level = GetComponent<AreaLevelAuthoring>();
			}
			if (entityMono == null || entityMono.gameObject != base.gameObject)
			{
				entityMono = GetComponent<EntityMonoBehaviourData>();
			}
			if (level != null)
			{
				int num = level.CalculateLevel();
				mechanicValue = LevelToMechanicValue(num, entityMono.objectInfo.objectID);
			}
		}
	}

	public float LevelToMechanicValue(int level, ObjectID objectID)
	{
		return mechanic switch
		{
			OffHandMechanic.Shield => 0.7f, 
			OffHandMechanic.Dash => (1.6f + math.max(1f, level) * 0.1f) * mechanicMultiplier, 
			OffHandMechanic.Teleport => 0f, 
			OffHandMechanic.Bait => 0f, 
			OffHandMechanic.MinionDetonation => 1f * mechanicMultiplier, 
			OffHandMechanic.RemoteDetonator => 1f * mechanicMultiplier, 
			_ => 0f, 
		};
	}
}
