using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSMedieval.Construction;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(RoofComponent))]
	public class RoofViewComponent : ComponentBaseView
	{
		[SerializeField]
		private GameObject scalableElement;

		[SerializeField]
		private GameObject blueprint;

		[SerializeField]
		private GameObject foundation;

		[SerializeField]
		private GameObject finished;

		[SerializeField]
		private GameObject dripIce;

		[SerializeField]
		private MeshRenderer standingPointA;

		[SerializeField]
		private MeshRenderer standingPointB;

		[SerializeField]
		private MeshRenderer decorationMesh;

		[SerializeField]
		private List<MeshRenderer> dripIceMesh;

		[SerializeField]
		private GameObject roofDeco;

		[SerializeField]
		private GameObject combatCover;

		[NonSerialized]
		private RoofComponent roofComponent;

		[NonSerialized]
		private MaterialPropertyBlock materialPropertyBlock;

		private Animator roofTopAnimator;

		private List<Vec3Int> positions = new List<Vec3Int>();

		public List<Vec3Int> Positions => positions;

		public RoofComponentInstance RoofComponentInstance => roofComponent.ComponentInstance;

		public BaseBuildingInstance OwnerBuilding => RoofComponentInstance.OwnerBuilding;

		public Vector3 GetScale => scalableElement.transform.localScale;

		public void ResetScale()
		{
			scalableElement.transform.localScale = Vector3.one;
		}

		public void Scale(Vec3Int scale)
		{
			if (scale.x != 0 && scale.y != 0 && scale.z != 0)
			{
				scalableElement.transform.localScale = (Vector3)scale;
				BaseBuildingViewComponent.UpdateOcclusionBoundingBox();
			}
		}

		public void AddPosition(Vec3Int pos)
		{
			positions.AddUnique(pos);
		}

		public void AddPositions(List<Vec3Int> positions)
		{
			this.positions.AddRangeUnique(positions);
		}

		public void ClearPositions()
		{
			positions.Clear();
		}

		public void UpdateRoofPlacementPreviewVisuals(bool canPlace)
		{
			Vec3Int gridPos = Positions.FirstOrDefault();
			standingPointA.transform.position = GridUtils.GetWorldPosition(gridPos);
			Vec3Int gridPos2 = Positions.LastOrDefault();
			standingPointB.transform.position = GridUtils.GetWorldPosition(gridPos2);
			ColorStandingPoints(standingPointA, canPlace);
			ColorStandingPoints(standingPointB, canPlace);
		}

		private void ColorStandingPoints(MeshRenderer meshRenderer, bool canPlace)
		{
			if (materialPropertyBlock == null)
			{
				materialPropertyBlock = new MaterialPropertyBlock();
			}
			if (canPlace)
			{
				materialPropertyBlock.SetFloat("_roofStandingPoint", 0f);
				meshRenderer.SetPropertyBlock(materialPropertyBlock);
				BaseBuildingViewComponent.ColorBlueprint(2f);
			}
			else
			{
				materialPropertyBlock.SetFloat("_roofStandingPoint", 1f);
				meshRenderer.SetPropertyBlock(materialPropertyBlock);
				BaseBuildingViewComponent.ColorBlueprint(1f);
			}
		}

		private void SetRoofDeco()
		{
			if ((bool)roofDeco)
			{
				roofTopAnimator.enabled = true;
				int num = RoofComponentInstance.Start.x - RoofComponentInstance.End.x;
				int num2 = RoofComponentInstance.Start.y - RoofComponentInstance.End.y;
				int num3 = RoofComponentInstance.Start.z - RoofComponentInstance.End.z;
				if (num != 0)
				{
					roofDeco.transform.localPosition = new Vector3((float)Mathf.Abs(num) / 2f, num2, 0f);
				}
				else if (num3 != 0)
				{
					roofDeco.transform.localPosition = new Vector3((float)Mathf.Abs(num3) / 2f, num2, 0f);
				}
				Vector3 localPosition = roofDeco.transform.localPosition;
				localPosition = new Vector3(localPosition.x, scalableElement.transform.localScale.y * 0.64f, localPosition.z);
				roofDeco.transform.localPosition = localPosition;
				roofDeco.SetActive(value: true);
			}
		}

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			roofComponent = GetComponent<RoofComponent>();
			roofComponent.OnAfterComponentInstantiatedEvent += OnAfterComponentInstantiated;
			BaseBuildingViewComponent.FinishedMeshRenderers.Add(decorationMesh);
			BaseBuildingViewComponent.FinishedMeshRenderers.AddRange(dripIceMesh);
			if ((bool)roofDeco)
			{
				roofTopAnimator = roofDeco.GetComponent<RoofTopView>().RoofTopAnimator;
			}
		}

		private void OnAfterComponentInstantiated()
		{
			SetActiveStandingPoint(standingPointA, active: false);
			SetActiveStandingPoint(standingPointB, active: false);
			if (BaseBuildingViewComponent?.Foundation != null)
			{
				BaseBuildingViewComponent.Foundation.transform.localRotation = Quaternion.identity;
			}
			if (roofComponent.ComponentInstance != null)
			{
				Scale(roofComponent.ComponentInstance.Scale);
			}
			combatCover.SetActive(value: true);
		}

		private void SetActiveStandingPoint(MeshRenderer standingPointMeshRenderer, bool active)
		{
			if (!(standingPointMeshRenderer == null))
			{
				standingPointMeshRenderer.gameObject.SetActive(active);
			}
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			SetRoofDeco();
			dripIce.SetActive(value: true);
			base.OnComponentEnterFinishedState(afterLoading);
		}

		protected override void OnBuildingDisposed(IDisposable disposable)
		{
			base.OnBuildingDisposed(disposable);
			if (combatCover != null)
			{
				combatCover.SetActive(value: false);
			}
			if (roofDeco != null)
			{
				roofDeco.SetActive(value: false);
			}
		}

		protected override void OnEnterPool()
		{
			base.OnEnterPool();
			SetActiveStandingPoint(standingPointA, active: true);
			SetActiveStandingPoint(standingPointB, active: true);
		}
	}
}
