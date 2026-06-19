using System.Collections;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class FireworkBig : Firework
{
	public ParticleSystem trail;

	public ParticleSystem takeOffEffects;

	public override void AE_bounceAudio()
	{
		AudioManager.Sfx(SfxTableID.bigFireworkCountDown, ExplosionPosition.position);
	}

	public override void AE_disableParticlesystems()
	{
		if ((bool)fire)
		{
			fire.Stop();
		}
		if ((bool)sparks)
		{
			sparks.Stop();
		}
	}

	public override void AE_takeOff()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		if ((bool)sparks)
		{
			sparks.Stop();
		}
		if ((bool)trail)
		{
			trail.Play(withChildren: true);
		}
		if ((bool)takeOffEffects)
		{
			takeOffEffects.Play(withChildren: true);
		}
		AudioManager.Sfx(SfxTableID.bigFireworkTakeOff, ExplosionPosition.position);
	}

	public override void AE_Explosion()
	{
		if (!(Manager.memory.GetFreeComponent<FireworkExplosion>(deferOnOccupied: true) == null))
		{
			StartCoroutine(ExplosionSequence(ExplosionPosition));
			HandleAnimationTrigger(-414722770);
		}
	}

	private IEnumerator ExplosionSequence(Transform anchor)
	{
		FireworkExplosion explosion = Manager.memory.GetFreeComponent<FireworkExplosion>(deferOnOccupied: true);
		explosion.transform.position = anchor.position;
		Color gold = new Color(1f, 0.5f, 0f);
		explosion.Play(gold, Color.white, Color.clear, Color.clear, 0.5f, 5f, 50);
		yield return new WaitForSeconds(0.5f);
		AudioManager.Sfx(SfxTableID.bigFireworkExplode, base.transform.position);
		Manager.camera.ShakeCameraNow(1.5f, 2f, 2f);
		yield return new WaitForSeconds(0.5f);
		int count = 30;
		float interval = 0.15f;
		for (int i = 0; i < count; i++)
		{
			explosion = Manager.memory.GetFreeComponent<FireworkExplosion>(deferOnOccupied: true);
			Vector3 position = Vector3.Scale(Random.insideUnitSphere, explosion.transform.localScale) * 6f;
			position += anchor.position;
			position.y = 5f;
			explosion.transform.position = position;
			explosion.Play(gold, Color.white, Color.white, ((float)i > (float)count * 0.66f) ? Color.white : Color.clear, 0.1f);
			AudioManager.Sfx(SfxTableID.fireworkExplodeSparkles, explosion.transform.position);
			yield return new WaitForSeconds(interval);
		}
		AudioManager.Sfx(SfxTableID.fireworkLingeringSparkles, explosion.transform.position);
	}
}
