using UnityEngine;

public class PugPlush : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.WhiteFur, particleSpawnLocation.position, 12);
	}

	public void OnInteract()
	{
		EntityUtility.PlayEffectEventClient(new EffectEventCD
		{
			effectID = EffectID.SqueakyToyInteract,
			entity = base.entity,
			position1 = particleSpawnLocation.position
		});
	}
}
