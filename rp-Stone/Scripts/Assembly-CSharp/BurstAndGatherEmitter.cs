using System;
using System.Collections.Generic;
using UnityEngine;

public class BurstAndGatherEmitter : AsciiParticleEmitter
{
	public Color colorOverride = Color.cyan;

	public float burstPowerX = 2f;

	public float burstPowerY = 1.1f;

	public Vector3 additionalBurstVelocity;

	public float gatherDelay = 1f;

	public Vector3 gatherDestination;

	public float gatherAccelerationX = 0.5f;

	public float gatherAccelerationY = 0.3f;

	private float angleBetween;

	private int index;

	private List<AsciiParticle> particlesEmitted = new List<AsciiParticle>();

	private float elapsedTime;

	public override void Emit()
	{
		angleBetween = MathF.PI * 2f / (float)minParticles;
		index = 0;
		particlesEmitted.Clear();
		elapsedTime = 0f;
		base.Emit();
	}

	public override AsciiParticle MakeParticle()
	{
		AsciiParticle asciiParticle = base.MakeParticle();
		if (asciiParticle == null)
		{
			return null;
		}
		for (int i = 0; i < asciiParticle.colorProgression.Length; i++)
		{
			asciiParticle.colorProgression[i] = colorOverride;
		}
		float f = angleBetween * (float)index;
		index++;
		float x = Mathf.Cos(f) * burstPowerX;
		float y = Mathf.Sin(f) * burstPowerY;
		asciiParticle.velocity = new Vector3(x, y, 0f) + additionalBurstVelocity;
		particlesEmitted.Add(asciiParticle);
		return asciiParticle;
	}

	private void Update()
	{
		elapsedTime += Time.deltaTime;
		if (!(elapsedTime >= gatherDelay))
		{
			return;
		}
		for (int num = particlesEmitted.Count - 1; num >= 0; num--)
		{
			AsciiParticle asciiParticle = particlesEmitted[num];
			if (asciiParticle == null)
			{
				particlesEmitted.RemoveAt(num);
			}
			else
			{
				Vector3 acceleration = gatherDestination - asciiParticle.transform.position;
				acceleration.Normalize();
				acceleration.x *= gatherAccelerationX;
				acceleration.y *= gatherAccelerationY;
				asciiParticle.acceleration = acceleration;
			}
		}
	}
}
