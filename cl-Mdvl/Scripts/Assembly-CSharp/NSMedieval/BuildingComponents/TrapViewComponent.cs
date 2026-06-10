using System;
using NSEipix.Base;
using NSMedieval.EnvironmentEffects;
using NSMedieval.Scripts.Pooler;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public class TrapViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private TrapComponent trapComponent;

		[SerializeField]
		private string activateParticles;

		[SerializeField]
		private Animator animator;

		public TrapComponentInstance ComponentInstance => trapComponent.ComponentInstance;

		private void Start()
		{
			animator.enabled = false;
		}

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			trapComponent = GetComponent<TrapComponent>();
		}

		private void OnTrigger()
		{
			if (!animator.enabled)
			{
				animator.enabled = true;
				VillageManager.ActiveVillage?.Map?.AnimatorDisableManager.Register(animator);
			}
			animator.SetTrigger("activate");
			VillageManager.ActiveVillage?.Map?.AnimatorDisableManager.OnAnimatorParamModified(animator);
			MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(activateParticles, base.transform.position);
			MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(base.transform.position, CameraShakeStrength.Weak);
		}

		private void OnReactivated()
		{
			if (!animator.enabled)
			{
				animator.enabled = true;
				VillageManager.ActiveVillage?.Map?.AnimatorDisableManager.Register(animator);
			}
			animator.SetTrigger("rearm");
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			base.OnComponentEnterFinishedState(afterLoading);
			trapComponent.ComponentInstance.TriggerEvent += OnTrigger;
			trapComponent.ComponentInstance.ReactivateEvent += OnReactivated;
			BaseBuildingViewComponent.BuildingOcclusionCullingChangedEvent += OnOcclussionCullingChanged;
			if (afterLoading && !ComponentInstance.Operational)
			{
				animator.SetTrigger("activate");
			}
		}

		private void OnOcclussionCullingChanged(bool isCulled)
		{
			if (!(animator == null))
			{
				animator.gameObject.SetActive(!isCulled);
			}
		}

		protected override void OnBuildingDisposed(IDisposable disposable)
		{
			base.BaseBuildingInstance?.Map?.AnimatorDisableManager?.Unregister(animator);
		}
	}
}
