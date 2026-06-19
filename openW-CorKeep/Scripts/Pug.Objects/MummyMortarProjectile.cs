using UnityEngine;

public class MummyMortarProjectile : EntityMonoBehaviour
{
	public ParticleSystem hit;

	public GameObject buildup;

	public ParticleSystem hitSpikes;

	public ParticleSystem buildupSpikes;

	public int spikeSpawnRotation;

	protected override bool hideDirectlyOnDeath => false;

	private new void Awake()
	{
		base.Awake();
		spikeSpawnRotation = Random.Range(0, 60);
		ParticleSystem.ShapeModule shape = hitSpikes.shape;
		ParticleSystem.ShapeModule shape2 = buildupSpikes.shape;
		if ((bool)hitSpikes && (bool)buildupSpikes)
		{
			shape.rotation += new Vector3(0f, 0f, spikeSpawnRotation);
			shape2.rotation += new Vector3(0f, 0f, spikeSpawnRotation);
		}
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		buildup.SetActive(lastAnim == -225098472 || lastAnim == 584621764);
		if (currentHealth > 0)
		{
			buildup.SetActive(value: true);
			buildup.GetComponent<ParticleSystem>().Play();
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == 1416834189)
		{
			Explode();
			AudioManager.Sfx(SfxTableID.mummyMortarProjectileImpact, base.transform.position);
		}
	}

	protected void Explode()
	{
		if ((bool)hit)
		{
			buildup.SetActive(value: false);
			hit.Play();
		}
		base.OnDeath();
	}

	public void AE_PlayParticles()
	{
	}

	public void AE_StopParticles()
	{
	}

	protected override void OnDeath()
	{
		AudioManager.SfxFollowTransform(soundOptions.deathSfx.value, base.transform);
	}
}
