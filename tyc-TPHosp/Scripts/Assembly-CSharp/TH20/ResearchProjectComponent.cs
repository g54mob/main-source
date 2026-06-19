using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class ResearchProjectComponent : EntityComponent
	{
		[DontSave]
		private List<Material> _newMaterials;

		[DontSave]
		private Dictionary<MeshRenderer, Material[]> _originalMaterials;

		public ResearchProject Project { get; private set; }

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		public override void Destroy()
		{
			ClearProject();
			base.Destroy();
		}

		public void AssignProject(ResearchProject project)
		{
			Project = project;
			RoomItem owner = GetOwner<RoomItem>();
			if (owner.Visual == null)
			{
				owner.OnVisualSet += OnRoomItemVisualSet;
			}
			else
			{
				SetMaterials();
				SetAnimatorProjectAssigned(assigned: true);
			}
			ShowResearchStatusIcon(show: true);
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			if (Project == null)
			{
				return;
			}
			Level level = base.Level;
			level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, (Action)delegate
			{
				if (Project != null)
				{
					if (Project.IsComplete())
					{
						ClearProject();
					}
					else
					{
						ShowResearchStatusIcon(show: true);
					}
				}
			});
		}

		public void ClearProject()
		{
			Project = null;
			GetOwner<RoomItem>().EndAllInteractions(immediately: true);
			RestoreMaterials();
			SetAnimatorProjectAssigned(assigned: false);
			ShowResearchStatusIcon(show: false);
		}

		private void OnRoomItemVisualSet()
		{
			GetOwner<RoomItem>().OnVisualSet -= OnRoomItemVisualSet;
			SetMaterials();
			SetAnimatorProjectAssigned(assigned: true);
		}

		private void SetAnimatorProjectAssigned(bool assigned)
		{
			RoomItemVisual visual = GetOwner<RoomItem>().Visual;
			if (visual != null)
			{
				Animator animator = visual.Animator;
				if (animator != null && animator.HasParameter("ProjectAssigned"))
				{
					animator.SetBool("ProjectAssigned", assigned);
				}
			}
		}

		private void SetMaterials()
		{
			RoomItem owner = GetOwner<RoomItem>();
			RestoreMaterials();
			if (owner.Visual == null || Project == null || !(Project.Definition.ResearchPodMaterial != null))
			{
				return;
			}
			_newMaterials = new List<Material>();
			_originalMaterials = new Dictionary<MeshRenderer, Material[]>();
			MeshRenderer[] componentsInChildren = owner.Visual.GameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				if (meshRenderer.sharedMaterials.Length == 2)
				{
					_originalMaterials.Add(meshRenderer, meshRenderer.sharedMaterials);
					meshRenderer.materials = new Material[2]
					{
						Project.Definition.ResearchPodMaterial,
						meshRenderer.sharedMaterials[1]
					};
					_newMaterials.Add(meshRenderer.materials[0]);
				}
			}
		}

		private void RestoreMaterials()
		{
			if (_originalMaterials == null || _newMaterials == null)
			{
				return;
			}
			_newMaterials.ClearAndDestroy();
			foreach (KeyValuePair<MeshRenderer, Material[]> originalMaterial in _originalMaterials)
			{
				originalMaterial.Key.materials = originalMaterial.Value;
			}
			_originalMaterials.Clear();
			_newMaterials = null;
			_originalMaterials = null;
		}

		private void ShowResearchStatusIcon(bool show)
		{
			RoomItem owner = GetOwner<RoomItem>();
			if (show)
			{
				base.Level.StatusIconManager.ShowStatusIcon(owner, StatusIcon.Type.ResearchProject);
			}
			else
			{
				base.Level.StatusIconManager.DestroyStatusIcon(owner);
			}
		}
	}
}
