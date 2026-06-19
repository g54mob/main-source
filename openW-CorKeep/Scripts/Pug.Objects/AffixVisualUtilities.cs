using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public static class AffixVisualUtilities
{
	public static void TryTriggerInitialZap(ParticleSystem zapSystem, Entity entity, World world, AffixID affixID)
	{
		if (TryUpdateZapPosition(zapSystem, entity, world, affixID))
		{
			zapSystem.Clear(withChildren: true);
			zapSystem.Play();
		}
	}

	public static void TryUpdateZap(ParticleSystem zapSystem, Entity entity, World world, AffixID affixID)
	{
		if (zapSystem.isPlaying)
		{
			TryUpdateZapPosition(zapSystem, entity, world, affixID);
		}
	}

	private static bool TryUpdateZapPosition(ParticleSystem zapSystem, Entity entity, World world, AffixID affixID)
	{
		if (!EntityUtility.TryGetComponentData<OwnerReferenceCD>(entity, world, out var value) || !EntityUtility.TryGetComponentData<LocalTransform>(value.owner, world, out var value2))
		{
			return false;
		}
		EntityMonoBehaviour entityMono = Manager.memory.GetEntityMono(value.owner);
		if (entityMono == null)
		{
			return false;
		}
		Vector3 zero = Vector3.zero;
		zero = ((!entityMono.conditionEffectsHandler.TryGetAffixRenderPos(affixID, out var affixRenderPos)) ? (EntityMonoBehaviour.ToRenderFromWorld(value2.Position) + new Vector3(0f, 0.5f, 0f)) : affixRenderPos);
		float z = Vector3.Distance(zapSystem.transform.position, zero);
		zapSystem.transform.localScale = new Vector3(1f, 1f, z);
		zapSystem.transform.LookAt(zero);
		return true;
	}
}
