using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Framework.Particles
{
	public class ParticleEmitterManager : GameMonoBehaviour
	{
		[SerializeField]
		public string _GlobalClockKey;

		private readonly List<ParticleSystem> _particleSystems;

		private List<GravityWell> _gravityWells;

		private float _defaultDepth;

		private bool UsePauseSystem => false;

		protected void Start()
		{
		}

		public ParticleSystem CreateEmitter(ParticleSystemConfig config, Transform parent = null, string psName = null)
		{
			return null;
		}

		public ParticleSystem CreateUIEmitter(ParticleSystemConfig config, string layer, int order, Transform parent = null, string psName = null, bool isAdditive = true, bool requiresMasking = false)
		{
			return null;
		}

		public GravityWell CreateGravityWell(GravityWellConfig config, Transform parent = null, string gravityWellName = null)
		{
			return null;
		}

		public void AddGravityWellParticleSystems(GravityWell gravityWell)
		{
		}

		public void RemoveGravityWell(GravityWell gc)
		{
		}

		public void UpdateGravityWellConfig(GravityWellConfig gc)
		{
		}

		public float GetRemainingLifetime()
		{
			return 0f;
		}

		public ParticleEmitterManager SetDepth(int depth)
		{
			return null;
		}

		public void SetDepthMultiplied(float depth, float mul = 100f)
		{
		}

		public void EmitParticleAt(Vector2 pos, int count = 1)
		{
		}

		public void EmitParticleTowards(Vector2 pos, Vector3 direction, int count = 1)
		{
		}

		public void RemoveEmitter(ParticleSystem sys)
		{
		}

		public void StartAllEmitters()
		{
		}

		public void StopAllEmitters()
		{
		}

		public void DestroyAllOwnedSystems()
		{
		}
	}
}
