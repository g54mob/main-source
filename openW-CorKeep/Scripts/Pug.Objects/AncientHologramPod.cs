using System.Collections.Generic;
using UnityEngine;

public class AncientHologramPod : CraftingBuilding
{
	public List<SfxUnityInspectorFriendlyID> speechSounds;

	public override void OnOccupied()
	{
		base.OnOccupied();
		Manager.effects.PlayPuff(PuffID.AncientSparks, base.transform.position, 15);
		AudioManager.Sfx(SfxID.anicentDevicePowerUp, base.transform.position, 1f, 1f, 0.1f);
	}

	public override void Use()
	{
		base.Use();
		AudioManager.Sfx(SfxID.chestopen, base.transform.position, 0.7f);
		int index = Random.Range(0, speechSounds.Count);
		AudioManager.SfxFollowTransform(Manager.audio.InspectorFriendlySfxIDToSfxID(speechSounds[index]), base.transform, 0.55f, 1.25f, 0.05f);
	}

	protected override void OnTakeDamage()
	{
		AudioManager.SfxFollowTransform(soundOptions.takeDamageSfx.value, base.transform);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 vector = new Vector3(0f, 3f, -3f);
		Manager.effects.ExploDisc(base.transform.position + vector + Vector3.up * 0.25f, 0.33f);
		Manager.effects.PlayPuff(PuffID.SmallAncientEnergy, base.transform.position + Vector3.up * 0.25f);
		Manager.effects.PlayPuff(PuffID.SmallAncientSmoke, base.transform.position);
	}
}
