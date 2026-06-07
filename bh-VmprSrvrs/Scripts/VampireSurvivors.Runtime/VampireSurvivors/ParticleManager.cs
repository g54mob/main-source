using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace VampireSurvivors
{
	public class ParticleManager : IInitializable, IDisposable, ITickable
	{
		[Inject]
		private SignalBus _signalBus;

		private List<ParticleSystem> _registeredParticleSystems;

		private List<ParticleSystem> _pausedParticleSystems;

		private bool _wasPaused;

		private float _time;

		private int _shaderParam;

		private void UnpauseGame()
		{
		}

		private void PauseGame()
		{
		}

		public void RegisterParticleSystem(ParticleSystem particleSystem)
		{
		}

		public void RegisterParticleSystem(ParticleSystem[] particleSystems)
		{
		}

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void Tick()
		{
		}
	}
}
