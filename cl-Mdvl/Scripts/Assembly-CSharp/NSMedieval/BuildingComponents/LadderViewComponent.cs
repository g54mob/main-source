using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(LadderComponent))]
	public class LadderViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private LadderComponent ladderComponent;

		[SerializeField]
		private GameObject ladderTopElement;

		[SerializeField]
		private GameObject ladderSupportElement;

		[SerializeField]
		private GameObject ladderFloorElement;

		private LadderComponentInstance LadderComponentInstance => ladderComponent.ComponentInstance;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			ladderComponent = GetComponent<LadderComponent>();
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			base.OnComponentEnterFinishedState(afterLoading);
			LadderComponentInstance.ShowTopEvent += SetActiveTop;
			LadderComponentInstance.ShowFloorEvent += SetActiveFloor;
			LadderComponentInstance.ShowSupportEvent += SetActiveSupport;
			LadderComponentInstance.Map.LadderComponentManager.RefreshLadderVisuals(LadderComponentInstance.GridDataPosition);
			BaseBuildingViewComponent.BuildingOcclusionCullingChangedEvent += OnOcclusionCullingChanged;
			if (afterLoading)
			{
				SetActiveFloor(LadderComponentInstance.FloorActive);
				SetActiveSupport(LadderComponentInstance.SupportActive);
				SetActiveTop(LadderComponentInstance.TopActive);
			}
		}

		private void OnOcclusionCullingChanged(bool isOccluded)
		{
			if (isOccluded)
			{
				SetActiveFloor(active: false);
				SetActiveSupport(active: false);
				SetActiveTop(active: false);
			}
			else
			{
				SetActiveFloor(LadderComponentInstance.FloorActive);
				SetActiveSupport(LadderComponentInstance.SupportActive);
				SetActiveTop(LadderComponentInstance.TopActive);
			}
		}

		private void SetActiveTop(bool active)
		{
			if (ladderTopElement != null)
			{
				ladderTopElement.SetActive(active);
			}
		}

		private void SetActiveSupport(bool active)
		{
			if (ladderSupportElement != null)
			{
				ladderSupportElement.SetActive(active);
			}
		}

		private void SetActiveFloor(bool active)
		{
			if (ladderFloorElement != null)
			{
				ladderFloorElement.SetActive(active);
			}
		}
	}
}
