using UnityEngine;

public class Mimite : EntityMonoBehaviour
{
	public ParticleSystem runParticles;

	public ParticleSystem collideParticles;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimOrientation => true;

	protected override void HandleAnimationTrigger(int animID)
	{
		switch (animID)
		{
		case -1634423587:
			runParticles.Stop(withChildren: true);
			break;
		case 1433117748:
			runParticles.Play(withChildren: true);
			break;
		case -1997722203:
			runParticles.Stop(withChildren: true);
			collideParticles.Play();
			break;
		case -601574123:
		case -281135240:
		case -210448114:
		case 1352515405:
			runParticles.Stop(withChildren: true);
			break;
		}
		base.HandleAnimationTrigger(animID);
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		if ((animID == -1997722203 && lastAnim == -1997722203) || (lastAnim == -1997722203 && animID == -601574123))
		{
			return false;
		}
		return base.ShouldPlayAnimTrigger(animID);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		runParticles.Stop(withChildren: true);
		Vector3 position = base.transform.position + new Vector3(0f, 0.5f, 0f);
		Manager.effects.PlayPuff(PuffID.MediumPurplePuff, position, 40);
	}
}
