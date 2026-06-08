using System.Collections.Generic;
using UnityEngine;

public class AsciiParticleLayer : MonoBehaviour
{
	private List<AsciiParticle> _particles = new List<AsciiParticle>();

	private List<AsciiParticle> deadParticles = new List<AsciiParticle>();

	public List<AsciiParticle> particles => _particles;

	public virtual void AddParticle(AsciiParticle particle)
	{
		_particles.Add(particle);
	}

	public virtual void UpdateTic()
	{
		for (int i = 0; i < _particles.Count; i++)
		{
			AsciiParticle asciiParticle = _particles[i];
			asciiParticle.UpdateTic();
			if (asciiParticle.isDead)
			{
				deadParticles.Add(asciiParticle);
			}
		}
		if (deadParticles.Count > 0)
		{
			for (int j = 0; j < deadParticles.Count; j++)
			{
				AsciiParticle asciiParticle2 = deadParticles[j];
				_particles.Remove(asciiParticle2);
				AsciiParticle.RecycleParticle(asciiParticle2);
			}
			deadParticles.Clear();
		}
	}

	public virtual void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		for (int i = 0; i < _particles.Count; i++)
		{
			_particles[i].Draw(r, offsetX, offsetY);
		}
	}

	public virtual void MoveParticles(int translateX, int translateY)
	{
		float num = translateX;
		float num2 = translateY;
		for (int i = 0; i < _particles.Count; i++)
		{
			AsciiParticle asciiParticle = _particles[i];
			Vector3 position = asciiParticle.transform.position;
			position.x += num * asciiParticle.cameraMoveScale;
			position.y += num2 * asciiParticle.cameraMoveScale;
			asciiParticle.transform.position = position;
		}
	}

	public virtual void RecycleAllParticles()
	{
		for (int i = 0; i < _particles.Count; i++)
		{
			AsciiParticle.RecycleParticle(_particles[i]);
		}
		_particles.Clear();
	}
}
