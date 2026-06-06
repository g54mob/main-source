using System;
using UnityEngine;

[Serializable]
public class DrifterLookParticleSystem
{
	[Serializable]
	private struct CameraParticleSystem
	{
		public DrifterLookCamera Camera;

		public ParticleSystem ParticleSystem;
	}

	[SerializeField]
	private string _parent;

	[SerializeField]
	private CameraParticleSystem[] _particleSystems;

	public string Parent => _parent;

	public bool TryReturnParticleSystemPrefab(DrifterLookCamera camera, out ParticleSystem particleSystem)
	{
		particleSystem = null;
		if (_particleSystems.IsNullOrEmpty())
		{
			return false;
		}
		CameraParticleSystem[] particleSystems = _particleSystems;
		for (int i = 0; i < particleSystems.Length; i++)
		{
			CameraParticleSystem cameraParticleSystem = particleSystems[i];
			if (cameraParticleSystem.Camera == camera)
			{
				particleSystem = cameraParticleSystem.ParticleSystem;
				break;
			}
		}
		return particleSystem != null;
	}
}
