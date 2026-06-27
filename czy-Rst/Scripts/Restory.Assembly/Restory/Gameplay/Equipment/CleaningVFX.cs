using System.Collections;
using System.Collections.Generic;
using Restory.Data.Effects;
using Restory.Data.Equipment;
using Restory.ObjectPools;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class CleaningVFX : MonoBehaviour
	{
		private class ActiveParticleSystem
		{
			public ParticleSystem Vfx;

			public float TimeLeft;
		}

		private class ResidueParticleSystem : ActiveParticleSystem
		{
			public Gradient Gradient;
		}

		private class ActiveParticleSystemWithPrefab : ActiveParticleSystem
		{
			public GameObject Prefab;
		}

		private ConcreteGameObjectPool residueParticleSystemsPool;

		private GameObjectPool cleaningToolApplicationParticleSystemsPool;

		private CleaningVfxSettings settings;

		private readonly List<ResidueParticleSystem> residueParticleSystems = new List<ResidueParticleSystem>();

		private readonly List<ResidueParticleSystem> residueParticleSystemsForDelayedActivation = new List<ResidueParticleSystem>();

		private readonly List<ActiveParticleSystemWithPrefab> currentCleaningToolCollisionParticleSystems = new List<ActiveParticleSystemWithPrefab>();

		private readonly List<ActiveParticleSystemWithPrefab> oldCleaningToolCollisionParticleSystems = new List<ActiveParticleSystemWithPrefab>();

		private CleaningToolInfo currentCleaningTool;

		private Coroutine delayedResidueActivationCoroutine;

		[Inject]
		private void Construct(CleaningVfxSettings settings, ConcreteGameObjectPool residueParticleSystemsPool, GameObjectPool cleaningToolApplicationParticleSystemsPool)
		{
			this.settings = settings;
			this.cleaningToolApplicationParticleSystemsPool = cleaningToolApplicationParticleSystemsPool;
			this.residueParticleSystemsPool = residueParticleSystemsPool;
		}

		private void OnDisable()
		{
			if (delayedResidueActivationCoroutine != null)
			{
				StopCoroutine(delayedResidueActivationCoroutine);
				delayedResidueActivationCoroutine = null;
			}
		}

		private void Update()
		{
			if (residueParticleSystems.Count != 0 || currentCleaningToolCollisionParticleSystems.Count != 0 || oldCleaningToolCollisionParticleSystems.Count != 0)
			{
				CheckAndCleanParticleSystems(residueParticleSystems);
				CheckAndCleanParticleSystems(currentCleaningToolCollisionParticleSystems);
				CheckAndCleanParticleSystems(oldCleaningToolCollisionParticleSystems);
			}
		}

		public void SetCleaningTool(CleaningToolInfo cleaningTool)
		{
			currentCleaningTool = cleaningTool;
		}

		public void ProcessCleaningAttempt(int raysHitsCount, IReadOnlyList<RaycastHit> raysHits, float redChannelCleanedAmount, float greenChannelCleanedAmount, float blueChannelCleanedAmount)
		{
			List<RaycastHit> value;
			using (CollectionPool<List<RaycastHit>, RaycastHit>.Get(out value))
			{
				FillRaycastHitsListFromRandomHits(raysHitsCount, raysHits, value, currentCleaningTool.MaxCleaningResidueVfxInstances);
				RefreshResidueParticles(value, redChannelCleanedAmount, greenChannelCleanedAmount, blueChannelCleanedAmount);
			}
			List<RaycastHit> value2;
			if ((bool)currentCleaningTool.CleaningCollisionVFX)
			{
				using (CollectionPool<List<RaycastHit>, RaycastHit>.Get(out value2))
				{
					FillRaycastHitsListFromRandomHits(raysHitsCount, raysHits, value2, currentCleaningTool.MaxCleaningCollisionVfxInstancesActive);
					RefreshCleaningToolCollisionParticles(value2);
				}
			}
		}

		private void CheckAndCleanParticleSystems<T>(List<T> particleSystemsCollection) where T : ActiveParticleSystem
		{
			for (int num = particleSystemsCollection.Count - 1; num >= 0; num--)
			{
				ActiveParticleSystem activeParticleSystem = particleSystemsCollection[num];
				if (activeParticleSystem.TimeLeft < 0f)
				{
					ParticleSystem.EmissionModule emission = activeParticleSystem.Vfx.emission;
					if (!emission.enabled)
					{
						if (activeParticleSystem is ActiveParticleSystemWithPrefab)
						{
							cleaningToolApplicationParticleSystemsPool.Release(activeParticleSystem.Vfx);
						}
						else
						{
							residueParticleSystemsPool.Release(activeParticleSystem.Vfx);
						}
						particleSystemsCollection.RemoveAt(num);
					}
					else
					{
						emission.enabled = false;
						ParticleSystem.MainModule main = activeParticleSystem.Vfx.main;
						activeParticleSystem.TimeLeft = main.duration + main.startLifetime.constantMax;
					}
				}
				else
				{
					activeParticleSystem.TimeLeft -= Time.deltaTime;
				}
			}
		}

		private void FillRaycastHitsListFromRandomHits(int originalRaysHitsCount, IReadOnlyList<RaycastHit> originalRaysHits, List<RaycastHit> listToFill, int maxVfxInstances)
		{
			int num = Mathf.Min(maxVfxInstances, originalRaysHitsCount);
			for (int i = 0; i < num; i++)
			{
				RaycastHit item = originalRaysHits[Random.Range(0, originalRaysHitsCount)];
				if (!listToFill.Contains(item))
				{
					listToFill.Add(item);
				}
			}
		}

		private void RefreshCleaningToolCollisionParticles(IList<RaycastHit> randomlySelectedRaycastHits)
		{
			for (int i = 0; i < randomlySelectedRaycastHits.Count; i++)
			{
				ActiveParticleSystemWithPrefab activeParticleSystemWithPrefab = ((currentCleaningToolCollisionParticleSystems.Count <= i) ? null : currentCleaningToolCollisionParticleSystems[i]);
				if (activeParticleSystemWithPrefab == null || !activeParticleSystemWithPrefab.Vfx)
				{
					activeParticleSystemWithPrefab = new ActiveParticleSystemWithPrefab
					{
						Vfx = cleaningToolApplicationParticleSystemsPool.Get(currentCleaningTool.CleaningCollisionVFX),
						Prefab = currentCleaningTool.CleaningCollisionVFX.gameObject
					};
					currentCleaningToolCollisionParticleSystems.Add(activeParticleSystemWithPrefab);
				}
				else if (activeParticleSystemWithPrefab.Prefab != currentCleaningTool.CleaningCollisionVFX.gameObject)
				{
					oldCleaningToolCollisionParticleSystems.Add(activeParticleSystemWithPrefab);
					currentCleaningToolCollisionParticleSystems.Remove(activeParticleSystemWithPrefab);
					activeParticleSystemWithPrefab = new ActiveParticleSystemWithPrefab
					{
						Vfx = cleaningToolApplicationParticleSystemsPool.Get(currentCleaningTool.CleaningCollisionVFX),
						Prefab = currentCleaningTool.CleaningCollisionVFX.gameObject
					};
					currentCleaningToolCollisionParticleSystems.Add(activeParticleSystemWithPrefab);
				}
				RaycastHit raycastHit = randomlySelectedRaycastHits[i];
				activeParticleSystemWithPrefab.Vfx.transform.position = raycastHit.point;
				if (!activeParticleSystemWithPrefab.Vfx.isPlaying)
				{
					activeParticleSystemWithPrefab.Vfx.Play();
				}
				ParticleSystem.EmissionModule emission = activeParticleSystemWithPrefab.Vfx.emission;
				emission.enabled = true;
				activeParticleSystemWithPrefab.TimeLeft = currentCleaningTool.CleaningCollisionVfxEmissionMinTime;
			}
		}

		private void RefreshResidueParticles(IList<RaycastHit> randomlySelectedRaycastHits, float redChannelCleanedAmount, float greenChannelCleanedAmount, float blueChannelCleanedAmount)
		{
			if (redChannelCleanedAmount < settings.MinCleanedColorAmountToTriggerResidueVfx && greenChannelCleanedAmount < settings.MinCleanedColorAmountToTriggerResidueVfx && blueChannelCleanedAmount < settings.MinCleanedColorAmountToTriggerResidueVfx)
			{
				return;
			}
			for (int i = 0; i < randomlySelectedRaycastHits.Count; i++)
			{
				ResidueParticleSystem residueParticleSystem = ((residueParticleSystemsForDelayedActivation.Count <= i) ? null : residueParticleSystemsForDelayedActivation[i]) ?? ((residueParticleSystems.Count <= i) ? null : residueParticleSystems[i]);
				if (residueParticleSystem == null || !residueParticleSystem.Vfx)
				{
					residueParticleSystem = new ResidueParticleSystem
					{
						Vfx = residueParticleSystemsPool.Get<ParticleSystem>(),
						Gradient = new Gradient()
					};
				}
				RaycastHit raycastHit = randomlySelectedRaycastHits[i];
				residueParticleSystem.Vfx.transform.position = raycastHit.point;
				residueParticleSystem.TimeLeft = float.MaxValue;
				SetResidueVfxColors(residueParticleSystem, redChannelCleanedAmount, greenChannelCleanedAmount, blueChannelCleanedAmount);
				if (!residueParticleSystemsForDelayedActivation.Contains(residueParticleSystem))
				{
					residueParticleSystemsForDelayedActivation.Add(residueParticleSystem);
				}
				if (delayedResidueActivationCoroutine == null)
				{
					delayedResidueActivationCoroutine = StartCoroutine(DelayedResidueActivationCoroutine());
				}
			}
		}

		private void SetResidueVfxColors(ResidueParticleSystem residueEffect, float redChannelCleanedAmount, float greenChannelCleanedAmount, float blueChannelCleanedAmount)
		{
			List<Color> value;
			using (CollectionPool<List<Color>, Color>.Get(out value))
			{
				if (redChannelCleanedAmount > 0f)
				{
					value.Add(settings.DustResidueFirstColor);
				}
				if (redChannelCleanedAmount > 0f)
				{
					value.Add(settings.DustResidueSecondColor);
				}
				if (greenChannelCleanedAmount > 0f)
				{
					value.Add(settings.DirtResidueFirstColor);
				}
				if (greenChannelCleanedAmount > 0f)
				{
					value.Add(settings.DirtResidueSecondColor);
				}
				if (blueChannelCleanedAmount > 0f)
				{
					value.Add(settings.RustResidueFirstColor);
				}
				if (blueChannelCleanedAmount > 0f)
				{
					value.Add(settings.RustResidueSecondColor);
				}
				GradientColorKey[] array = new GradientColorKey[value.Count];
				GradientAlphaKey[] array2 = new GradientAlphaKey[value.Count];
				float num = 1f / (float)(value.Count - 1);
				for (int i = 0; i < value.Count; i++)
				{
					float time = ((i == 0) ? 0f : ((i == value.Count - 1) ? 1f : (num * (float)i)));
					array[i] = new GradientColorKey(value[i], time);
					array2[i] = new GradientAlphaKey(value[i].a, time);
				}
				residueEffect.Gradient.SetKeys(array, array2);
				ParticleSystem.MinMaxGradient startColor = new ParticleSystem.MinMaxGradient
				{
					mode = ParticleSystemGradientMode.Gradient,
					gradient = residueEffect.Gradient
				};
				ParticleSystem.MainModule main = residueEffect.Vfx.main;
				main.startColor = startColor;
			}
		}

		private IEnumerator DelayedResidueActivationCoroutine()
		{
			yield return new WaitForSeconds(settings.DelayBeforeResidueEmissionStarts);
			foreach (ResidueParticleSystem item in residueParticleSystemsForDelayedActivation)
			{
				if (item != null && (bool)item.Vfx)
				{
					if (!item.Vfx.isPlaying)
					{
						item.Vfx.Play();
					}
					ParticleSystem.EmissionModule emission = item.Vfx.emission;
					emission.enabled = true;
					item.TimeLeft = settings.ResidueEmissionMinTime;
					if (!residueParticleSystems.Contains(item))
					{
						residueParticleSystems.Add(item);
					}
				}
			}
			residueParticleSystemsForDelayedActivation.Clear();
			delayedResidueActivationCoroutine = null;
		}
	}
}
