using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Framework.Particles
{
	public class GravityWell : GameMonoBehaviour
	{
		private GravityWellConfig _config;

		private Transform _cachedTransform;

		private readonly List<ParticleSystem> _targets;

		private readonly List<ParticleSystem.Particle[]> _particlesCaches;

		private float _power;

		private float _epsilon;

		private float _gravity;

		private bool _requiresLateUpdate;

		public float Epsilon
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Power
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Gravity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		public void Init(GravityWellConfig config)
		{
		}

		public void AddParticleSystem(ParticleSystem ps)
		{
		}

		public void RemoveParticleSystem(ParticleSystem ps)
		{
		}

		public void Clear()
		{
		}

		private void UpdateSystem(ParticleSystem system, ref ParticleSystem.Particle[] cache)
		{
		}

		private void UpdateParticle(int index, ParticleSystem.Particle[] cache)
		{
		}
	}
}
