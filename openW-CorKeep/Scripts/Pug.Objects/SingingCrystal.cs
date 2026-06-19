using UnityEngine;

public class SingingCrystal : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.GlassBlockDebrisBox, particleSpawnLocation.position, 12);
		Manager.effects.PlayPuff(PuffID.GlassFloorTilesDebris, particleSpawnLocation.position, 4);
	}

	public void Use()
	{
		EntityUtility.PlayEffectEventClient(new EffectEventCD
		{
			effectID = EffectID.SingingCrystalInteract,
			position1 = base.RenderPosition + new Vector3(0f, 0.7f, -0.5f)
		});
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (EntityUtility.HasComponentData<MimicPlayerInstrumentNotesCD>(base.entity, base.world))
		{
			MimicPlayerInstrumentNotesCD componentData = EntityUtility.GetComponentData<MimicPlayerInstrumentNotesCD>(base.entity, base.world);
			if (componentData.playerHoldingInstrumentExists && componentData.isPlayingNotes)
			{
				AudioManager.Sfx(componentData.sfx.value, base.transform.position, 1f, componentData.pitch);
			}
		}
	}
}
