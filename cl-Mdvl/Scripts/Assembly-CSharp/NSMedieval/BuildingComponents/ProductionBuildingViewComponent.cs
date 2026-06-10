using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Sound;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public class ProductionBuildingViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private ProductionComponent productionComponent;

		[SerializeField]
		private Animator animator;

		private IGoapAgentOwner reservationAgent;

		private GameObject productionActiveEffect;

		private bool isProductionActiveEffectEnabled;

		private Vector3 soundPosition;

		private string productionSoundId;

		private AudioEventsComponent audioEventsComponent;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			productionComponent = GetComponent<ProductionComponent>();
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			base.OnComponentEnterFinishedState(afterLoading);
			productionComponent.StartProductionProgressEffectEvent += StartProductionProgressEffect;
			productionComponent.FinishProductionProgressEffectEvent += FinishProductionProgressEffect;
			BaseBuildingViewComponent.BuildingOcclusionCullingChangedEvent += OnOcclusionCullingChanged;
			InitializeEffectObject();
			InitializeMeshRenderers();
			InitializeAudio();
		}

		private void SetProductionActiveEffect(bool enabled)
		{
			isProductionActiveEffectEnabled = enabled;
			if (!(productionActiveEffect == null))
			{
				if (BaseBuildingViewComponent.IsOcclusionCulled)
				{
					productionActiveEffect.SetActive(value: false);
				}
				else
				{
					productionActiveEffect.SetActive(enabled);
				}
			}
		}

		private void OnOcclusionCullingChanged(bool isCulled)
		{
			if (!(productionActiveEffect == null))
			{
				productionActiveEffect.SetActive(!isCulled && isProductionActiveEffectEnabled);
			}
		}

		private void InitializeEffectObject()
		{
			if (string.IsNullOrEmpty(productionComponent?.ProductionComponentBlueprint?.ProductionEffectPrefabId))
			{
				return;
			}
			GameObject byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(productionComponent.ProductionComponentBlueprint.ProductionEffectPrefabId);
			if (!(byAddress == null))
			{
				if (productionActiveEffect == null)
				{
					productionActiveEffect = UnityEngine.Object.Instantiate(byAddress, base.transform);
				}
				productionComponent?.ProductionComponentBlueprint?.EffectTransformSettings.ApplyToTransform(productionActiveEffect.transform);
			}
		}

		private void InitializeMeshRenderers()
		{
			if (!(productionActiveEffect == null))
			{
				MeshRenderer[] componentsInChildren = productionActiveEffect.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
				MeshRenderer[] array = componentsInChildren;
				foreach (MeshRenderer item in array)
				{
					BaseBuildingViewComponent.FinishedMeshRenderers.Add(item);
				}
				BaseBuildingViewComponent.LayerObjectHide.AddComponentMeshRenderers(componentsInChildren);
			}
		}

		private void InitializeAudio()
		{
			audioEventsComponent = GetComponent<AudioEventsComponent>();
			if (!(audioEventsComponent == null) && !(productionComponent == null) && !string.IsNullOrEmpty(productionComponent.ProductionComponentBlueprint.ProductionSound))
			{
				productionSoundId = productionComponent.ProductionComponentBlueprint.ProductionSound;
				soundPosition = (productionActiveEffect ? productionActiveEffect.transform.position : base.transform.position);
			}
		}

		protected override void OnBuildingDisposed(IDisposable disposable)
		{
			base.OnBuildingDisposed(disposable);
			productionComponent.StartProductionProgressEffectEvent -= StartProductionProgressEffect;
			productionComponent.FinishProductionProgressEffectEvent -= FinishProductionProgressEffect;
		}

		protected override void OnEnterPool()
		{
			base.OnEnterPool();
			SetProductionActiveEffect(enabled: false);
		}

		protected override void OnShowObject()
		{
			base.OnShowObject();
			if (!string.IsNullOrEmpty(productionSoundId))
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(8, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Production\\ProductionBuildingViewComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(productionSoundId);
					messageBuilder.AppendLiteral(" Unpause");
				}
				Log.Trace(messageBuilder);
				audioEventsComponent.SetEventParameter(productionSoundId, "PausedFader", 0f);
			}
		}

		protected override void OnHideObject()
		{
			base.OnHideObject();
			if (!string.IsNullOrEmpty(productionSoundId))
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(6, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Production\\ProductionBuildingViewComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(productionSoundId);
					messageBuilder.AppendLiteral(" Pause");
				}
				Log.Trace(messageBuilder);
				audioEventsComponent.SetEventParameter(productionSoundId, "PausedFader", 1f);
			}
		}

		private void StartProductionProgressEffect()
		{
			SetProductionActiveEffect(enabled: true);
			reservationAgent = GetAgent();
			MonoSingleton<AnimationController>.Instance.OnAnimationGoapEvent += TriggerAnimation;
			if (!string.IsNullOrEmpty(productionSoundId))
			{
				audioEventsComponent.PlayEventInstanceAtPosition(productionSoundId, soundPosition);
			}
		}

		private void FinishProductionProgressEffect(ActionCompletionStatus status = ActionCompletionStatus.None)
		{
			SetProductionActiveEffect(enabled: false);
			MonoSingleton<AnimationController>.Instance.OnAnimationGoapEvent -= TriggerAnimation;
			if (!string.IsNullOrEmpty(productionSoundId))
			{
				audioEventsComponent.StopEventInstance(productionSoundId);
			}
		}

		private IGoapAgentOwner GetAgent()
		{
			IGoapAgentOwner owner = null;
			MonoSingleton<ReservationManager>.Instance.ForEachReserver(productionComponent.BaseComponentInstance, delegate(IGoapAgentOwner agent)
			{
				owner = agent;
			});
			return owner;
		}

		private void TriggerAnimation(IGoapAgentOwner owner, string trigger)
		{
			if (!(animator == null) && owner == reservationAgent)
			{
				animator.SetTrigger("extra_anim_trigger");
			}
		}
	}
}
