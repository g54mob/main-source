using System;
using UnityEngine;

namespace VampireSurvivors
{
	public class ParticleSystemCircleCollision : GameMonoBehaviour
	{
		[NonSerialized]
		public ParticleSystem _particleSystem;

		[NonSerialized]
		public float _radius;

		[NonSerialized]
		public float _bounce;

		private ParticleSystem.Particle[] _particles;

		protected override void OnUpdate()
		{
		}

		private void InitIfNeeded()
		{
		}
	}
}
