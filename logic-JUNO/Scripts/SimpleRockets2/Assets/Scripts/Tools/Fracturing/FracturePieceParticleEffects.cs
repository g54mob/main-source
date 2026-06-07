using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.Tools.Fracturing
{
	public class FracturePieceParticleEffects : IFracturePieceProcessor
	{
		private string _particleSystemName;

		public float ParticleEffectFrequency { get; private set; }

		public float ParticleEffectLightFrequency { get; private set; }

		public void ProcessPiece(GameObject fracturePiece, Vector3? colliderWorldCenter)
		{
			if (!(Random.Range(0f, 1f) < ParticleEffectFrequency))
			{
				return;
			}
			GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab(_particleSystemName);
			gameObject.transform.parent = fracturePiece.transform;
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localPosition = Vector3.zero;
			GameObject gameObject2 = gameObject.GetComponentInChildren<Light>().gameObject;
			if (Random.Range(0f, 1f) < ParticleEffectLightFrequency)
			{
				if (colliderWorldCenter.HasValue)
				{
					gameObject2.transform.position = colliderWorldCenter.Value;
				}
			}
			else
			{
				Object.Destroy(gameObject2);
			}
		}

		public void SetQuality(ExplosionsQualitySettings explosionQuality)
		{
			switch (explosionQuality.ParticleEffect.Value)
			{
			case ExplosionsQualitySettings.ParticleEffectQuality.Medium:
				_particleSystemName = "Flight/Common/Explosions/MedQualFractureExplosionAndTrail";
				break;
			case ExplosionsQualitySettings.ParticleEffectQuality.High:
				_particleSystemName = "Flight/Common/Explosions/FractureExplosionAndTrail";
				break;
			}
			ParticleEffectFrequency = explosionQuality.ParticleEffectFrequency;
			ParticleEffectLightFrequency = explosionQuality.ParticleEffectLightFrequency;
		}
	}
}
