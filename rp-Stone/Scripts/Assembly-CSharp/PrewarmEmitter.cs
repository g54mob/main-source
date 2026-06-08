using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AsciiParticleEmitter))]
public class PrewarmEmitter : MonoBehaviour
{
	public int prewarmTics = 30;

	public float secondsPerTic = 0.033333f;

	private AsciiParticleEmitter myEmitter;

	private PeriodicParticleEmitter periodicEmitter;

	private SpriteEmitter spriteEmitter;

	private AsciiAnimation asciiAnimation;

	private List<AsciiParticle> _particles = new List<AsciiParticle>();

	public void DoPrewarm(int offsetX, int offsetY)
	{
		myEmitter.OnParticlesEmitted += HandleOnParticlesEmitted;
		List<AsciiParticle> list = new List<AsciiParticle>();
		for (int i = 0; i < prewarmTics; i++)
		{
			if (periodicEmitter != null)
			{
				periodicEmitter.UpdateWithDeltaTime(Mathf.Clamp01(secondsPerTic));
			}
			if (spriteEmitter != null && asciiAnimation != null)
			{
				asciiAnimation.UpdateWithDeltaTime(Mathf.Clamp01(secondsPerTic));
				spriteEmitter.TryToEmit(offsetX, offsetY);
			}
			for (int j = 0; j < _particles.Count; j++)
			{
				AsciiParticle asciiParticle = _particles[j];
				asciiParticle.UpdateTic();
				if (asciiParticle.isDead)
				{
					list.Add(asciiParticle);
				}
			}
			if (list.Count > 0)
			{
				for (int k = 0; k < list.Count; k++)
				{
					_particles.Remove(list[k]);
				}
				list.Clear();
			}
		}
		_particles.Clear();
		myEmitter.OnParticlesEmitted -= HandleOnParticlesEmitted;
	}

	private void Awake()
	{
		myEmitter = GetComponent<AsciiParticleEmitter>();
		periodicEmitter = GetComponent<PeriodicParticleEmitter>();
		spriteEmitter = GetComponent<SpriteEmitter>();
		asciiAnimation = GetComponent<AsciiAnimation>();
	}

	private void OnDestroy()
	{
		myEmitter = null;
		periodicEmitter = null;
		spriteEmitter = null;
		asciiAnimation = null;
	}

	private void HandleOnParticlesEmitted(AsciiParticle[] particles)
	{
		for (int i = 0; i < particles.Length; i++)
		{
			if ((bool)particles[i])
			{
				_particles.Add(particles[i]);
			}
		}
	}
}
