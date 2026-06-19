using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class LarvaHiveEgg : EntityMonoBehaviour
{
	private EntityQuery hiveBossQuery;

	protected override bool hideDirectlyOnDeath => false;

	public override void OnOccupied()
	{
		base.OnOccupied();
		hiveBossQuery = Manager.ecs.GetClientEntityQuery(typeof(LarvaHiveBossHatchEggStateCD), typeof(BossCD));
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		bool flag = false;
		if (!hiveBossQuery.IsEmpty)
		{
			NativeArray<Entity> nativeArray = hiveBossQuery.ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				if (EntityUtility.HasComponentData<ObjectDataCD>(item, base.world) && EntityUtility.GetComponentData<ObjectDataCD>(item, base.world).objectID == ObjectID.LarvaHiveHalloweenBoss && !EntityUtility.IsComponentEnabled<EntityDestroyedCD>(item, base.world))
				{
					flag = true;
				}
			}
			nativeArray.Dispose();
		}
		UpdateSpriteSheetSkins(base.objectInfo, flag ? 1 : (-1));
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -1753203768 || animID == -528020642 || animID == 2039372516)
		{
			AudioManager.Sfx(SfxID.bubble, base.transform.position, 0.35f, 0.75f, 0.1f, reuse: true);
		}
		if (animID == 2053665356 && lastAnim != 2053665356)
		{
			Manager.effects.PlayPuff(PuffID.BloodSpurt, base.transform.position, 40);
			Manager.effects.PlayTempSprite(SpriteTempEffectID.BloodImpact, base.transform.position + new Vector3(0f, 0.0625f, 0f), 0.5f);
			Manager.effects.PlayTempSprite(SpriteTempEffectID.BloodSplat, base.transform.position + new Vector3(0f, 0.3125f, -0.3125f));
			AudioManager.Sfx(SfxID.cocoonHatch, base.transform.position, 1f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 25f);
		}
	}

	private void AE_Wobble()
	{
		AudioManager.Sfx(SfxID.bubble, base.transform.position, 0.35f, 0.75f, 0.1f, reuse: true);
	}
}
