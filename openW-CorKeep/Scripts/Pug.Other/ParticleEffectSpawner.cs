using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class ParticleEffectSpawner : MonoBehaviour
{
	[Serializable]
	public class Effect
	{
		[ParticleEffectIDDropdown]
		public int particleEffect;

		public bool clearParticlesWhenStopped;

		public PugParticleQuality minimumParticleQuality;

		[Tooltip("If omitted, the effect follows the GameObject this component is attached to.")]
		public Transform optionalTransformToFollow;
	}

	public List<Effect> particleEffects;

	private readonly List<int> _dictID = new List<int>();

	private void Awake()
	{
		_dictID.Resize(-1, particleEffects.Count);
	}

	private void OnEnable()
	{
		for (int i = 0; i < particleEffects.Count; i++)
		{
			Effect effect = particleEffects[i];
			GameObject followGameObject = ((effect.optionalTransformToFollow != null) ? effect.optionalTransformToFollow.gameObject : base.gameObject);
			List<int> dictID = _dictID;
			int index = i;
			EffectsManager effects = Manager.effects;
			int particleEffect = effect.particleEffect;
			PugParticleQuality minimumParticleQuality = effect.minimumParticleQuality;
			dictID[index] = effects.StartParticleEffect(particleEffect, followGameObject, float.PositiveInfinity, default(Vector3), minimumParticleQuality);
		}
	}

	private void OnDisable()
	{
		for (int i = 0; i < particleEffects.Count; i++)
		{
			Manager.effects.StopParticleEffect(_dictID[i], particleEffects[i].clearParticlesWhenStopped);
			_dictID[i] = -1;
		}
	}
}
