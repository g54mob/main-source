using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Map;
using NSMedieval.RoomDetection;
using NSMedieval.View;
using NSMedieval.Village;
using UnityEngine;
using UnityEngine.Rendering;

namespace NSMedieval.Layers
{
	public class LayerObjectHide
	{
		private List<Collider> clickColliders = new List<Collider>();

		private List<MeshRenderer> activeMeshRenderers = new List<MeshRenderer>();

		private bool objectHidden;

		private bool objectShadowHidden;

		private float objectLevel;

		private float objectShadowLevel;

		private bool blockActivatingColliders;

		private LayerHideType layerHideType;

		private BaseBuildingInstance ownerBuilding;

		private WorldObject ownerWorldObject;

		private bool isCulled;

		public float ObjectLevel => objectLevel;

		public bool Visible => !objectHidden;

		public LayerHideType LayerHideType => layerHideType;

		public BaseBuildingInstance OwnerBuilding => ownerBuilding;

		public bool IsOcclusionCulled
		{
			get
			{
				return isCulled;
			}
			set
			{
				if (isCulled != value && MonoSingleton<World>.IsInstantiated())
				{
					isCulled = value;
					if (isCulled)
					{
						HideUsingShadowOffset();
						HideUsingObjectOffset();
					}
					else
					{
						RefreshVisibility(MonoSingleton<World>.Instance.LayerLevel);
					}
				}
			}
		}

		public event Action HideObjectEvent;

		public event Action ShowObjectEvent;

		public void Setup(float objectLevel, float objectOffset, float shadowOffset, LayerHideType layerHideType)
		{
			this.objectLevel = objectLevel + objectOffset;
			objectShadowLevel = objectLevel + shadowOffset;
			this.layerHideType = layerHideType;
		}

		public void SetOwnerBuilding(BaseBuildingInstance baseBuildingInstance)
		{
			ownerBuilding = baseBuildingInstance;
			ownerWorldObject = baseBuildingInstance;
			if (baseBuildingInstance == null)
			{
				this.ShowObjectEvent = null;
				this.HideObjectEvent = null;
			}
		}

		public void SetOwnerWorldObject(WorldObject worldObject)
		{
			ownerBuilding = null;
			ownerWorldObject = worldObject;
		}

		public void Reset()
		{
			isCulled = false;
			ShowUsingObjectOffset();
			ShowUsingShadowOffset();
			clickColliders.Clear();
			activeMeshRenderers.Clear();
			blockActivatingColliders = false;
		}

		public void SetBlockActivatingColliders(bool blockActivatingColliders)
		{
			this.blockActivatingColliders = blockActivatingColliders;
		}

		public void SetupColliders(IEnumerable<Collider> colliders)
		{
			clickColliders.Clear();
			clickColliders.AddRange(colliders);
		}

		public void SetupColliders(Collider collider)
		{
			clickColliders.Clear();
			clickColliders.Add(collider);
		}

		public void RemoveClickCollider(Collider collider)
		{
			clickColliders.Remove(collider);
		}

		public void SetupMeshRenderers(MeshRenderer activeMeshRenderer)
		{
			activeMeshRenderers.Clear();
			activeMeshRenderers.Add(activeMeshRenderer);
		}

		public void SetupMeshRenderers(IEnumerable<MeshRenderer> activeMeshRenderers)
		{
			this.activeMeshRenderers.Clear();
			this.activeMeshRenderers.AddRange(activeMeshRenderers);
		}

		public void AddComponentMeshRenderers(MeshRenderer[] meshRenderers)
		{
			for (int i = 0; i < meshRenderers.Length; i++)
			{
				activeMeshRenderers.Add(meshRenderers[i]);
			}
		}

		public void AddComponentMeshRenderer(MeshRenderer meshRenderer)
		{
			activeMeshRenderers.Add(meshRenderer);
		}

		public List<MeshRenderer> GetMeshRenderers(GameObject source, List<MeshRenderer> elementsToSkip = null)
		{
			List<MeshRenderer> list = new List<MeshRenderer>();
			MeshRenderer[] componentsInChildren = source.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				if (!(meshRenderer == null))
				{
					if (elementsToSkip == null || elementsToSkip.Count == 0)
					{
						list.Add(meshRenderer);
					}
					else if (!elementsToSkip.Contains(meshRenderer))
					{
						list.Add(meshRenderer);
					}
				}
			}
			return list;
		}

		public void ActivateColliders()
		{
			if (objectHidden || blockActivatingColliders)
			{
				return;
			}
			foreach (Collider clickCollider in clickColliders)
			{
				clickCollider.enabled = true;
			}
		}

		public void ForceActivateColliders()
		{
			foreach (Collider clickCollider in clickColliders)
			{
				clickCollider.enabled = true;
			}
		}

		public void ForceDeactivateColliders()
		{
			foreach (Collider clickCollider in clickColliders)
			{
				clickCollider.enabled = false;
			}
		}

		private bool IsInMeshFusion()
		{
			SelectableObject selectableObject = ownerBuilding?.GetView();
			if (selectableObject != null && selectableObject.IsInMeshFusion())
			{
				return true;
			}
			return false;
		}

		public void RefreshVisibility(float realWorldLevel)
		{
			RefreshVisibility(realWorldLevel, forceHideOrShow: false);
		}

		public void RefreshVisibility(float realWorldLevel, bool forceHideOrShow)
		{
			if (isCulled)
			{
				return;
			}
			using (ProfilerSampleJanitor.Begin("LayerObjectHide.RefreshVisibility"))
			{
				Room room = ownerWorldObject?.GetRoom();
				if (room != null && room.IsContentRenderCulled && !room.WallNodes.Contains(ownerWorldObject.GetNode()))
				{
					if (!objectHidden)
					{
						HideUsingObjectOffset();
					}
					if (!objectShadowHidden)
					{
						HideUsingShadowOffset();
					}
					return;
				}
				if (objectHidden)
				{
					if (objectLevel < realWorldLevel - 0.5f)
					{
						ShowUsingObjectOffset();
					}
					else if (forceHideOrShow)
					{
						HideUsingObjectOffset();
					}
				}
				else if (objectLevel >= realWorldLevel - 0.5f)
				{
					HideUsingObjectOffset();
				}
				else if (forceHideOrShow)
				{
					ShowUsingObjectOffset();
				}
				if (objectShadowHidden)
				{
					if (objectShadowLevel < realWorldLevel - 0.5f)
					{
						ShowUsingShadowOffset();
					}
					else if (forceHideOrShow)
					{
						HideUsingShadowOffset();
					}
				}
				else if (objectShadowLevel >= realWorldLevel - 0.5f)
				{
					HideUsingShadowOffset();
				}
				else if (forceHideOrShow)
				{
					ShowUsingShadowOffset();
				}
			}
		}

		public void ForceHide()
		{
			using (ProfilerSampleJanitor.Begin("LayerObjectHide.ForceHide"))
			{
				if (!objectHidden || !objectShadowHidden)
				{
					HideUsingObjectOffset();
					HideUsingShadowOffset();
				}
			}
		}

		public void ResetAfterFailedConstruction(float realWorldLevel, List<MeshRenderer> allBuildingMeshRenderers)
		{
			if (objectLevel < realWorldLevel)
			{
				ShowUsingObjectOffset();
			}
			if (ownerBuilding == null)
			{
				for (int i = 0; i < allBuildingMeshRenderers.Count; i++)
				{
					if (!(allBuildingMeshRenderers[i] == null))
					{
						allBuildingMeshRenderers[i].shadowCastingMode = ShadowCastingMode.On;
					}
				}
				return;
			}
			if (ownerBuilding.ConstructionPhase != ConstructionPhase.Finished)
			{
				for (int j = 0; j < allBuildingMeshRenderers.Count; j++)
				{
					if (!(allBuildingMeshRenderers[j] == null))
					{
						allBuildingMeshRenderers[j].shadowCastingMode = ShadowCastingMode.On;
					}
				}
				return;
			}
			if (!ownerBuilding.Blueprint.UseShadowCasters)
			{
				for (int k = 0; k < allBuildingMeshRenderers.Count; k++)
				{
					if (!(allBuildingMeshRenderers[k] == null))
					{
						allBuildingMeshRenderers[k].shadowCastingMode = ShadowCastingMode.On;
					}
				}
				return;
			}
			for (int l = 0; l < activeMeshRenderers.Count; l++)
			{
				if (activeMeshRenderers[l] != null)
				{
					activeMeshRenderers[l].enabled = false;
				}
			}
		}

		private void HideUsingObjectOffset()
		{
			objectHidden = true;
			this.HideObjectEvent?.Invoke();
			for (int i = 0; i < clickColliders.Count; i++)
			{
				if (clickColliders[i] != null)
				{
					clickColliders[i].enabled = false;
				}
			}
		}

		private void HideUsingShadowOffset()
		{
			objectShadowHidden = true;
			if (ownerBuilding == null)
			{
				for (int i = 0; i < activeMeshRenderers.Count; i++)
				{
					if (activeMeshRenderers[i] != null)
					{
						activeMeshRenderers[i].shadowCastingMode = ShadowCastingMode.ShadowsOnly;
					}
				}
				return;
			}
			if (ownerBuilding.ConstructionPhase != ConstructionPhase.Finished)
			{
				for (int j = 0; j < activeMeshRenderers.Count; j++)
				{
					if (activeMeshRenderers[j] != null)
					{
						activeMeshRenderers[j].shadowCastingMode = ShadowCastingMode.ShadowsOnly;
					}
				}
				return;
			}
			if (!ownerBuilding.Blueprint.UseShadowCasters)
			{
				for (int k = 0; k < activeMeshRenderers.Count; k++)
				{
					if (activeMeshRenderers[k] != null)
					{
						activeMeshRenderers[k].shadowCastingMode = ShadowCastingMode.ShadowsOnly;
					}
				}
				return;
			}
			for (int l = 0; l < activeMeshRenderers.Count; l++)
			{
				if (activeMeshRenderers[l] != null)
				{
					activeMeshRenderers[l].enabled = false;
				}
			}
		}

		private void ShowUsingObjectOffset()
		{
			if (isCulled)
			{
				return;
			}
			objectHidden = false;
			this.ShowObjectEvent?.Invoke();
			if (blockActivatingColliders || clickColliders == null)
			{
				return;
			}
			for (int i = 0; i < clickColliders.Count; i++)
			{
				if (clickColliders[i] != null)
				{
					clickColliders[i].enabled = true;
				}
			}
		}

		private void ShowUsingShadowOffset()
		{
			if (LoadingController.IsLeavingMainScene)
			{
				return;
			}
			objectShadowHidden = false;
			if (ownerBuilding == null)
			{
				for (int i = 0; i < activeMeshRenderers.Count; i++)
				{
					if (!(activeMeshRenderers[i] == null))
					{
						activeMeshRenderers[i].shadowCastingMode = ShadowCastingMode.On;
					}
				}
				return;
			}
			if (ownerBuilding.ConstructionPhase != ConstructionPhase.Finished)
			{
				for (int j = 0; j < activeMeshRenderers.Count; j++)
				{
					if (!(activeMeshRenderers[j] == null))
					{
						activeMeshRenderers[j].shadowCastingMode = ShadowCastingMode.On;
					}
				}
				return;
			}
			if (!ownerBuilding.Blueprint.UseShadowCasters)
			{
				for (int k = 0; k < activeMeshRenderers.Count; k++)
				{
					if (!(activeMeshRenderers[k] == null))
					{
						activeMeshRenderers[k].shadowCastingMode = ShadowCastingMode.On;
					}
				}
				return;
			}
			ShadowCastingMode shadowCastingMode = ((!ownerBuilding.Blueprint.UseShadowCasters) ? ShadowCastingMode.On : ShadowCastingMode.Off);
			for (int l = 0; l < activeMeshRenderers.Count; l++)
			{
				if (activeMeshRenderers[l] != null)
				{
					if (!IsInMeshFusion())
					{
						activeMeshRenderers[l].enabled = true;
					}
					activeMeshRenderers[l].shadowCastingMode = shadowCastingMode;
				}
			}
		}
	}
}
