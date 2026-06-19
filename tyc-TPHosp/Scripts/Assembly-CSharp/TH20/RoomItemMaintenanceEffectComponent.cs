#define LOG_LEVEL_VERBOSE
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemMaintenanceEffectComponent : EntityComponent
	{
		[SerializeField]
		private readonly string _effectName = "Effect";

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

		private ParticleEffectControlComponent GetEffectComponent()
		{
			ParticleEffectControlComponent particleEffectControlComponent = null;
			if (_roomItem != null && _roomItem.Visual != null)
			{
				particleEffectControlComponent = _roomItem.Visual.GameObject.GetComponent<ParticleEffectControlComponent>();
			}
			if (particleEffectControlComponent == null)
			{
				Logging.Error(LogChannels.Gameplay, "ParticleEffectControlComponent missing in {0}", _roomItem);
			}
			return particleEffectControlComponent;
		}

		private void BindCallbacks()
		{
			if (_roomItem.FloorPlan != null && !(_roomItem.FloorPlan is BlueprintFloorPlan) && _roomItem.MaintenanceLevel != null)
			{
				_roomItem.MaintenanceLevel.GreaterThan(GameAlgorithms.Config.ItemMaintenanceThreshold, StartEffect, checkCallback: true);
				_roomItem.MaintenanceLevel.LessThan(GameAlgorithms.Config.ItemMaintenanceThreshold, StopEffect, checkCallback: true);
			}
		}

		private void StartEffect()
		{
			ParticleEffectControlComponent effectComponent = GetEffectComponent();
			if (effectComponent != null)
			{
				effectComponent.EnableEffect(_effectName, enable: true);
			}
		}

		private void StopEffect()
		{
			ParticleEffectControlComponent effectComponent = GetEffectComponent();
			if (effectComponent != null)
			{
				effectComponent.EnableEffect(_effectName, enable: false);
			}
		}
	}
}
