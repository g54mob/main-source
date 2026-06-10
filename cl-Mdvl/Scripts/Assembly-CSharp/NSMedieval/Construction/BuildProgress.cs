using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Scripts.Pooler;
using UnityEngine;

namespace NSMedieval.Construction
{
	public class BuildProgress : MonoBehaviour
	{
		[SerializeField]
		private Transform finishedBuildingParentTransform;

		[SerializeField]
		private List<GameObject> finishedBuilding;

		private readonly List<Renderer> renderers = new List<Renderer>();

		[SerializeField]
		private string buildParticles = "build_particles";

		[SerializeField]
		private string buildFinishedParticles = "build_finished_particles";

		[SerializeField]
		private Shaker shaker;

		[SerializeField]
		private BaseBuildingViewComponent baseBuildingViewComponent;

		private float? startTime;

		private float currentTime;

		private bool renderersInitialized;

		private List<GameObject> particlesInstances;

		private GameObject particlesFinishInstance;

		private Vector3 emitterSize = Vector3.zero;

		private float emitterVolume;

		public event Action<GameObject> OnParticleFinishedEvent;

		public void SetStartTime(float startTime)
		{
			this.startTime = startTime;
		}

		public void UpdateDestroyProgress(float normalizedPercent)
		{
			float progress = 1f - Mathf.Pow(normalizedPercent, 3f);
			SetProgress(progress);
		}

		public void UpdateProgress(float t)
		{
			if (this == null || base.gameObject == null)
			{
				return;
			}
			currentTime = t;
			if (!startTime.HasValue)
			{
				if (t <= 0f)
				{
					currentTime = 0f;
					ParticlesOff();
					SetProgress(1f);
					return;
				}
				startTime = t;
			}
			if (1f - NormalizeProgressTime(t) >= 1f)
			{
				ParticlesOff();
			}
			float progress = Mathf.Clamp(1f - NormalizeProgressTime(t), 0f, 1f);
			SetProgress(progress);
		}

		public void TriggerParticles()
		{
			ParticlesOn();
		}

		public void SetToFullyBuilt()
		{
			SetProgress(1f);
		}

		public void ResetProgress()
		{
			startTime = null;
			ParticlesOff();
			SetProgress(0f);
		}

		public float GetBuildProgress()
		{
			if (startTime.HasValue)
			{
				return Mathf.Clamp(1f - NormalizeProgressTime(currentTime), 0f, 1f);
			}
			return 0f;
		}

		public void ParticlesOff()
		{
			if (!MonoSingleton<ParticleSystemPool>.IsInstantiated() || particlesInstances.Count == 0)
			{
				return;
			}
			for (int num = particlesInstances.Count - 1; num >= 0; num--)
			{
				if (num < particlesInstances.Count)
				{
					if (particlesInstances[num] == null)
					{
						particlesInstances.RemoveAt(num);
					}
					else
					{
						particlesInstances[num].transform.parent = null;
						MonoSingleton<ParticleSystemPool>.Instance.StopParticles(particlesInstances[num]);
						GameObject inst = particlesInstances[num];
						MonoSingleton<TaskController>.Instance.WaitFor(1.2f).Then(delegate
						{
							if (MonoSingleton<ParticleSystemPool>.IsInstantiated())
							{
								MonoSingleton<ParticleSystemPool>.Instance.ReturnToPool(inst);
								particlesInstances.Remove(inst);
							}
						});
					}
				}
			}
		}

		public void PlayParticlesOnBuildingFinished()
		{
			if (!(particlesFinishInstance != null))
			{
				particlesFinishInstance = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(buildFinishedParticles, base.transform.position);
				if (particlesFinishInstance != null)
				{
					particlesFinishInstance.transform.position = base.transform.position;
					particlesFinishInstance.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
					MonoSingleton<ParticleSystemPool>.Instance.SetEmitterSize(buildFinishedParticles, particlesFinishInstance, baseBuildingViewComponent.ClickCollider, 1f);
				}
			}
		}

		public void SetEmitterSize(List<Vec3Int> positions, Vec3Int size, BuildingType type)
		{
			if (positions.Count == 0)
			{
				return;
			}
			emitterSize.x = size.x;
			emitterSize.y = size.y;
			emitterSize.z = size.z;
			if (type == BuildingType.Roof)
			{
				if (positions[positions.Count - 1].x != positions[0].x)
				{
					emitterSize.x = Mathf.Abs(positions[positions.Count - 1].x - positions[0].x);
				}
				else if (positions[positions.Count - 1].z != positions[0].z)
				{
					emitterSize.x = Mathf.Abs(positions[positions.Count - 1].z - positions[0].z);
				}
			}
			emitterVolume = emitterSize.x * emitterSize.y * emitterSize.z;
		}

		public void ParticlesOn()
		{
			if (!(baseBuildingViewComponent == null))
			{
				particlesInstances = baseBuildingViewComponent.OnPlayParticlesFromColliderVolume(buildParticles, autoStop: true, unscaledTime: false, this.OnParticleFinishedEvent);
				if (shaker != null && baseBuildingViewComponent != null)
				{
					shaker.Shake(finishedBuildingParentTransform);
				}
			}
		}

		public void ReturnParticleOnEmitterFinished(GameObject particle)
		{
			particlesInstances.Remove(particle);
			MonoSingleton<ParticleSystemPool>.Instance.ReturnToPool(particle);
		}

		private float NormalizeProgressTime(float t)
		{
			return t / startTime.Value;
		}

		private void OnDestroy()
		{
			ParticlesOff();
			if (renderers != null && renderers.Count > 0)
			{
				SetProgress(0f);
			}
		}

		private void SetProgressOnMaterial(Renderer renderer, float progress)
		{
			if (!(renderer == null) && MonoSingleton<MaterialPropertyBlockManager>.IsInstantiated() && !MonoSingleton<MaterialPropertyBlockManager>.IsApplicationIsQuitting() && !MonoSingleton<GlobalSaveController>.IsApplicationIsQuitting())
			{
				MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(renderer);
				materialPropertyBlock.SetFloat("_BuildProgress", progress);
				renderer.SetPropertyBlock(materialPropertyBlock);
			}
		}

		private void TryInitRenderers()
		{
			if (renderersInitialized)
			{
				return;
			}
			renderers.Clear();
			foreach (GameObject item in finishedBuilding)
			{
				if (!(item == null))
				{
					renderers.Add(item.GetComponent<Renderer>());
				}
			}
			renderersInitialized = true;
		}

		private void SetProgress(float progress)
		{
			bool flag = base.enabled;
			base.enabled = true;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(42, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Effects\\BuildProgress.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("SetProgress ");
				messageBuilder.AppendFormatted(progress);
				messageBuilder.AppendLiteral(" for '");
				messageBuilder.AppendFormatted(baseBuildingViewComponent?.BaseBuildingInstance);
				messageBuilder.AppendLiteral("' (view '");
				messageBuilder.AppendFormatted(baseBuildingViewComponent?.GetHashCode());
				messageBuilder.AppendLiteral("', instance '");
				messageBuilder.AppendFormatted(baseBuildingViewComponent?.BaseBuildingInstance?.GetHashCode());
				messageBuilder.AppendLiteral("')");
			}
			Log.Trace(messageBuilder);
			TryInitRenderers();
			foreach (Renderer renderer in renderers)
			{
				if (!(renderer == null))
				{
					SetProgressOnMaterial(renderer, progress);
				}
			}
			base.enabled = flag;
		}

		private void OnEnable()
		{
			if (particlesInstances == null)
			{
				particlesInstances = new List<GameObject>();
			}
			OnParticleFinishedEvent += ReturnParticleOnEmitterFinished;
		}

		private void OnDisable()
		{
			OnParticleFinishedEvent -= ReturnParticleOnEmitterFinished;
		}
	}
}
