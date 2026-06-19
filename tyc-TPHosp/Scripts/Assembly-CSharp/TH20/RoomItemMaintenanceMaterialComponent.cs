using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemMaintenanceMaterialComponent : EntityComponent
	{
		[Serializable]
		private class Config
		{
			public Material[] _materialRepaired;

			public Material[] _materialBroken;
		}

		[SerializeField]
		private Config _config;

		private RoomItem _roomItem;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_roomItem = GetOwner<RoomItem>();
			SetupVisualData();
		}

		private void SetupVisualData()
		{
			if (_roomItem.Visual == null)
			{
				_roomItem.OnVisualSet += OnRoomItemVisualSet;
			}
			else
			{
				BindCallbacks();
			}
		}

		private void OnRoomItemVisualSet()
		{
			_roomItem.OnVisualSet -= OnRoomItemVisualSet;
			BindCallbacks();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			SetupVisualData();
		}

		private void BindCallbacks()
		{
			if (_roomItem.FloorPlan != null && !(_roomItem.FloorPlan is BlueprintFloorPlan) && _roomItem.MaintenanceLevel != null)
			{
				_roomItem.MaintenanceLevel.GreaterThan(GameAlgorithms.Config.ItemMaintenanceThreshold, SetMaterialBroken, checkCallback: true);
				_roomItem.MaintenanceLevel.LessThan(GameAlgorithms.Config.ItemMaintenanceThreshold, SetMaterialsRepaired, checkCallback: true);
			}
		}

		private void SetMaterialsRepaired()
		{
			_roomItem.Visual.SetMaintenanceMaterials(_config._materialRepaired);
		}

		private void SetMaterialBroken()
		{
			_roomItem.Visual.SetMaintenanceMaterials(_config._materialBroken);
		}
	}
}
