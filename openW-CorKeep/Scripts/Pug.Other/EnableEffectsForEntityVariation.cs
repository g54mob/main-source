using Pug.ECS.Hybrid;
using Unity.Entities;
using UnityEngine;

public class EnableEffectsForEntityVariation : MonoBehaviour, IGraphicalSpawn, IEntityMonoBehaviourDataPreview
{
	public int variationToEnableEffectsFor;

	public GameObject effects;

	public void Spawn(Entity entity, EntityManager entityManager)
	{
		if (!entityManager.HasComponent<ObjectDataCD>(entity))
		{
			Debug.LogError($"{base.name} has {typeof(EnableEffectsForEntityVariation)}, but the entity has no {typeof(ObjectDataCD)}");
		}
		else if (!(effects == null))
		{
			int variation = entityManager.GetComponentData<ObjectDataCD>(entity).variation;
			SetEffectStatus(variation);
		}
	}

	public void UpdateGraphicsFromObjectInfo(ObjectInfo objectInfo)
	{
		if (effects != null)
		{
			SetEffectStatus(objectInfo.variation);
		}
	}

	private void SetEffectStatus(int variation)
	{
		effects.SetActive(variation == variationToEnableEffectsFor);
	}
}
