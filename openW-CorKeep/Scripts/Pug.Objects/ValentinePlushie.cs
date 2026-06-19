using UnityEngine;

public class ValentinePlushie : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.BigBlueFur, particleSpawnLocation.position, 12);
		Manager.effects.PlayPuff(PuffID.WhiteFur, particleSpawnLocation.position, 4);
	}

	public void OnInteract()
	{
		EntityUtility.PlayEffectEventClient(new EffectEventCD
		{
			effectID = EffectID.PlushieInteract,
			entity = base.entity,
			position1 = particleSpawnLocation.position
		});
	}
}
