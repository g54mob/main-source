using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Scripts.Pooler;
using NSMedieval.Sound;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Views.Resources
{
	public class TreeView : PlantMapResourceView
	{
		[SerializeField]
		private GameObject dustParticlesHolder;

		[SerializeField]
		private BoxCollider canopyCollider;

		private Animator anim;

		private GameObject parentedTreeFallParticles;

		public override void Setup(PlantMapResourceInstance instance)
		{
			base.Setup(instance);
			instance.EnterBurntPhaseEvent += OnEnterBurntPhase;
		}

		public void FireTreeParticles()
		{
			Transform transform = (dustParticlesHolder ? dustParticlesHolder.transform : base.transform);
			MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("DustParticles", transform.position);
		}

		public void FireTreeFallParticles()
		{
			Transform parent = (dustParticlesHolder ? dustParticlesHolder.transform : base.transform);
			parentedTreeFallParticles = MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("tree_fall_birch", parent);
		}

		public void RemoveParentTreeFallParticles()
		{
			if ((object)parentedTreeFallParticles != null)
			{
				parentedTreeFallParticles.transform.parent = null;
			}
		}

		public override void Dispose()
		{
			if (base.HasDisposed)
			{
				return;
			}
			if (this == null || base.transform == null)
			{
				Log.Warning((this == null) ? "TreeView.OnDestroyObject: TreeView is null." : "TreeView.OnDestroyObject: transform is null.", "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\TreeView.cs");
				return;
			}
			if ((object)anim == null)
			{
				Log.Warning("OnDestroyObject: anim is null.", "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\TreeView.cs");
			}
			if (!LoadingController.IsSceneTransition && !LoadingController.IsLeavingMainScene)
			{
				if (base.transform != null && MonoSingleton<AudioManager>.IsInstantiated())
				{
					MonoSingleton<AudioManager>.Instance.PlaySoundAtPosition("TreeFall", base.transform.position);
				}
				if ((object)anim != null && base.gameObject != null && MonoSingleton<AudioManager>.IsInstantiated())
				{
					anim.enabled = true;
					anim.Play("Tree Fall");
					Dispose(destroyGameObject: false);
					return;
				}
			}
			base.Dispose();
		}

		internal override void Select()
		{
			if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.LeftControl))
			{
				ClickedJumpToLowerLayer();
			}
			else
			{
				base.Select();
			}
		}

		public override string GetMultiselectName()
		{
			return "tree_resource";
		}

		protected override void Start()
		{
			base.Start();
			anim = GetComponentInChildren<Animator>();
			if (!GlobalSaveController.CurrentVillageData.TreesVisible)
			{
				base.LayerObjectHide.SetBlockActivatingColliders(blockActivatingColliders: true);
				base.LayerObjectHide.ForceDeactivateColliders();
			}
			if (base.ResourceInstance != null)
			{
				int currentPhase = base.ResourceInstance.CurrentPhase;
				if (currentPhase >= 0 && currentPhase < ((PlantMapResource)blueprint).LifePhases.Count && base.ResourceInstance.Blueprint.LifePhases[currentPhase].DisableCanopyCollider)
				{
					DisableCanopyCollider();
				}
			}
		}

		private void OnEnterBurntPhase()
		{
			DisableCanopyCollider();
		}

		private void DisableCanopyCollider()
		{
			if (!(canopyCollider == null))
			{
				canopyCollider.enabled = false;
				base.LayerObjectHide.RemoveClickCollider(canopyCollider);
			}
		}
	}
}
