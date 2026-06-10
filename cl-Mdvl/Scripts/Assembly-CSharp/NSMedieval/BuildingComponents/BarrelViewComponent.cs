using System;
using System.Collections.Generic;
using NSMedieval.StorageUniversal;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(ShelfComponent))]
	public class BarrelViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private ShelfComponent shelfComponent;

		[SerializeField]
		private List<MeshRenderer> waterLevels;

		[SerializeField]
		private GameObject water;

		private MaterialPropertyBlock waterMaterialPropertyBlock;

		private MaterialPropertyBlock WaterMaterialPropertyBlock
		{
			get
			{
				if (waterMaterialPropertyBlock == null)
				{
					waterMaterialPropertyBlock = new MaterialPropertyBlock();
				}
				return waterMaterialPropertyBlock;
			}
		}

		private ShelfComponentInstance ShelfComponentInstance => shelfComponent.ComponentInstance;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			shelfComponent = GetComponent<ShelfComponent>();
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			base.OnComponentEnterFinishedState(afterLoading);
			InitializeWaterLevels();
			if (!afterLoading)
			{
				SetMaterialPropertyBlock(0f);
				UpdateFrozenVisuals(frozen: false);
			}
			else
			{
				SetupWaterVisualsAfterLoading();
				UpdateFrozenVisuals(ShelfComponentInstance.Frozen);
			}
			ShelfComponentInstance.ShelfFrozenEvent += OnFrozen;
			BaseBuildingViewComponent.BuildingOcclusionCullingChangedEvent += OnOcclusionCullingChanged;
		}

		private void OnOcclusionCullingChanged(bool isCulled)
		{
			water.gameObject.SetActive(!isCulled);
		}

		private void SetupWaterVisualsAfterLoading()
		{
			foreach (UniversalStorage item in ShelfComponentInstance.AllStorage)
			{
				for (int i = 0; i < item.StorageSlots.Length; i++)
				{
					OnUpdateWaterLevel(i, item.StorageSlots[i]);
				}
			}
		}

		private void InitializeWaterLevels()
		{
			for (int i = 0; i < ShelfComponentInstance.AllStorage.Count; i++)
			{
				ShelfComponentInstance.AllStorage[i].PileStoredEvent += OnUpdateWaterLevel;
				ShelfComponentInstance.AllStorage[i].PileTakenEvent += OnUpdateWaterLevel;
				ShelfComponentInstance.AllStorage[i].PileStoredNoViewUpdateEvent += OnUpdateWaterLevel;
				StorageSlot[] storageSlots = ShelfComponentInstance.AllStorage[i].StorageSlots;
				for (int j = 0; j < storageSlots.Length; j++)
				{
					storageSlots[j].SetHasVisuals(hasVisuals: false);
				}
			}
		}

		private void OnUpdateWaterLevel(int index, StorageSlot storageSlot)
		{
			if (index >= 0 && index <= waterLevels.Count - 1)
			{
				SetMaterialPropertyBlock((storageSlot?.GetFillPercentage() ?? 0f) / 100f);
			}
		}

		private void SetMaterialPropertyBlock(float fillPercentage)
		{
			water.SetActive(fillPercentage != 0f);
			WaterMaterialPropertyBlock.SetFloat("_FullLevel", fillPercentage);
			foreach (MeshRenderer waterLevel in waterLevels)
			{
				waterLevel.SetPropertyBlock(WaterMaterialPropertyBlock);
			}
		}

		private void OnFrozen(bool frozen)
		{
			UpdateFrozenVisuals(frozen);
		}

		private void UpdateFrozenVisuals(bool frozen)
		{
			WaterMaterialPropertyBlock.SetFloat("_Frozen", frozen ? 1f : 0f);
			foreach (MeshRenderer waterLevel in waterLevels)
			{
				waterLevel.SetPropertyBlock(WaterMaterialPropertyBlock);
			}
		}
	}
}
