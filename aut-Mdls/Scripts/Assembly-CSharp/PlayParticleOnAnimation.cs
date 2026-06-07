using System.Collections.Generic;
using UnityEngine;

public class PlayParticleOnAnimation : MonoBehaviour
{
	[SerializeField]
	private List<ParticleSystem> _particleSystems = new List<ParticleSystem>();

	private const float CULL_DISTANCE_TO_CAMERA = 35f;

	public void PlayParticleSystem(int index)
	{
		if (!((base.transform.position - Camera.main.transform.position).magnitude > 35f))
		{
			_particleSystems[index].Play();
		}
	}

	public void PlayAllParticleSystems()
	{
		if (!(Camera.main == null) && !((base.transform.position - Camera.main.transform.position).magnitude > 35f))
		{
			for (int i = 0; i < _particleSystems.Count; i++)
			{
				_particleSystems[i].Play();
			}
		}
	}
}
