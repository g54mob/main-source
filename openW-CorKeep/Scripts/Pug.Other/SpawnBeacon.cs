using System;
using UnityEngine;

public class SpawnBeacon : MonoBehaviour
{
	private SpriteRenderer[] spriteRenderers;

	private ParticleSystem[] particleSystems;

	[NonSerialized]
	[HideInInspector]
	public PlayerController owner;

	public void Awake()
	{
		spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
		particleSystems = GetComponentsInChildren<ParticleSystem>();
		TuckAway();
	}

	private void TuckAway()
	{
		base.transform.position = new Vector2(-30f, 0f);
		ParticleSystem[] array = particleSystems;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
	}

	public void SetColor(Color color)
	{
		SpriteRenderer[] array = spriteRenderers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].color = color;
		}
		ParticleSystem[] array2 = particleSystems;
		for (int i = 0; i < array2.Length; i++)
		{
			ParticleSystem.MainModule main = array2[i].main;
			main.startColor = color;
		}
	}

	public void Appear(Vector2 targetPos)
	{
		base.transform.position = targetPos;
		ParticleSystem[] array = particleSystems;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Play();
		}
		GetComponent<Animator>().SetTrigger("appear");
	}

	public void Disappear()
	{
		TuckAway();
		Vector3 position = base.transform.position;
		if (owner != null)
		{
			position = owner.center;
		}
		Manager.effects.PlayPuff(PuffID.DustGeyser, position, 30);
		Manager.effects.PlayTempSprite(SpriteTempEffectID.Flash, position);
	}

	public void AE_TouchGround()
	{
		AudioManager.SfxFollowTransform(SfxID.spawnbeacon, base.transform, 0.5f, 1f, 0.1f, reuse: true);
	}
}
