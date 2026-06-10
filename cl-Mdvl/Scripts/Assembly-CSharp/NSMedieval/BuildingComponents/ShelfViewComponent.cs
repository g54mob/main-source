using System;
using System.Collections.Generic;
using NSMedieval.Construction;
using NSMedieval.StorageUniversal;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(ShelfComponent))]
	public class ShelfViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private ShelfComponent shelfComponent;

		[SerializeField]
		private List<ShelfFillView> shelfFillViews;

		public ShelfComponentInstance ShelfComponentInstance => shelfComponent.ComponentInstance;

		public void SetupShelfItemsAfterLoad()
		{
			if (!base.BaseBuildingInstance.ConstructionPhase.Equals(ConstructionPhase.Finished))
			{
				return;
			}
			for (int i = 0; i < ShelfComponentInstance.AllStorage.Count; i++)
			{
				if (shelfFillViews.Count > i && shelfFillViews[i] != null)
				{
					for (int j = 0; j < ShelfComponentInstance.AllStorage[i].StorageSlots.Length; j++)
					{
						shelfFillViews[i].SpawnObject(j, ShelfComponentInstance.AllStorage[i].StorageSlots[j]);
					}
				}
			}
		}

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			shelfComponent = GetComponent<ShelfComponent>();
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			BindShelfViewWithInstance();
			base.OnComponentEnterFinishedState(afterLoading);
			SetupShelfItemsAfterLoad();
			BaseBuildingViewComponent.BuildingOcclusionCullingChangedEvent += OnOcclusionCullingChanged;
		}

		private void OnOcclusionCullingChanged(bool isCulled)
		{
			if (shelfFillViews == null)
			{
				return;
			}
			foreach (ShelfFillView shelfFillView in shelfFillViews)
			{
				if (!(shelfFillView == null))
				{
					shelfFillView.SetPilesOcclusionCulled(isCulled);
				}
			}
		}

		private void BindShelfViewWithInstance()
		{
			for (int i = 0; i < ShelfComponentInstance.AllStorage.Count; i++)
			{
				if (shelfFillViews.Count > i && shelfFillViews[i] != null)
				{
					if (ShelfComponentInstance.Blueprint.HasShelfTransformSettings(i, out var settings))
					{
						shelfFillViews[i].Initialize(settings);
					}
					ShelfComponentInstance.AllStorage[i].PileStoredEvent += shelfFillViews[i].SpawnObject;
					ShelfComponentInstance.AllStorage[i].PileTakenEvent += shelfFillViews[i].RemoveObject;
					ShelfComponentInstance.AllStorage[i].PileDurabilityDepletedEvent += shelfFillViews[i].OnPileDurabilityDepleted;
					for (int j = 0; j < ShelfComponentInstance.AllStorage[i].StorageSlots.Length; j++)
					{
						StorageSlot storageSlot = ShelfComponentInstance.AllStorage[i].StorageSlots[j];
						if (storageSlot == null)
						{
							Debug.LogWarning("Storage slot with index k = " + j + ", i = " + i + " is null @ " + ShelfComponentInstance.GridDataPosition.ToString());
						}
						else if (j >= shelfFillViews[i].GetNumberOfSlots())
						{
							storageSlot.SetHasVisuals(hasVisuals: false);
						}
						else
						{
							storageSlot.SetHasVisuals(hasVisuals: true);
						}
					}
				}
				else
				{
					for (int k = 0; k < ShelfComponentInstance.AllStorage[i].StorageSlots.Length; k++)
					{
						ShelfComponentInstance.AllStorage[i].StorageSlots[k].SetHasVisuals(hasVisuals: false);
					}
				}
			}
		}

		protected override void OnBuildingDisposed(IDisposable disposable)
		{
			base.OnBuildingDisposed(disposable);
			foreach (ShelfFillView shelfFillView in shelfFillViews)
			{
				shelfFillView.Dispose();
			}
		}
	}
}
