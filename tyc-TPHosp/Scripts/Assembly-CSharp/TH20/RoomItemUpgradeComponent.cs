using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemUpgradeComponent : EntityTickComponent
	{
		private RoomItem _roomItem;

		public JobUpgrade Job { get; set; }

		public float Progress { get; set; }

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			Progress = 0f;
			_roomItem = GetOwner<RoomItem>();
		}

		public override void Tick()
		{
			base.Tick();
			if (!(_roomItem.FloorPlan is BlueprintFloorPlan))
			{
				base.Level.StatusIconManager.ShowStatusIcon(_roomItem, StatusIcon.Type.MachineUpgrade);
			}
			if (Job == null)
			{
				return;
			}
			Staff staff = Job.GetStaff();
			if (staff != null)
			{
				ObjectInteraction interaction = staff.Interaction;
				if (interaction != null && interaction.Name == "Upgrade" && interaction.ParentRoomItem == _roomItem)
				{
					RepairItem(_roomItem, staff);
					UpgradeItem(_roomItem, staff);
				}
			}
		}

		private void UpgradeItem(RoomItem item, Staff staff)
		{
			float num = item.Definition.GetNextUpgrade(item.UpgradeLevel)?.Points ?? 1f;
			float num2 = staff.GetUpgradeItemMultiplier(item.OwningRoom) / num;
			Progress += num2 * Time.deltaTime;
			if (Progress >= 1f)
			{
				item.Upgrade(staff);
				TriggerUpgradeEffect();
				Destroy();
			}
		}

		private float RepairItem(RoomItem item, Staff staff)
		{
			float maintenanceMultiplier = staff.GetMaintenanceMultiplier(item.OwningRoom);
			maintenanceMultiplier *= item.Definition.JanitorRepairRate;
			maintenanceMultiplier *= Time.deltaTime;
			item.MaintenanceLevel.Modify(0f - maintenanceMultiplier, 1f);
			return maintenanceMultiplier;
		}

		private void TriggerUpgradeEffect()
		{
			if (_roomItem.Visual != null)
			{
				ParticleEffectControlComponent component = _roomItem.Visual.GameObject.GetComponent<ParticleEffectControlComponent>();
				if (component != null)
				{
					component.EnableEffect("Upgrade", enable: true);
				}
				AudioManager.Instance.Play("UpgradeComplete", _roomItem.Visual.GameObject);
			}
		}
	}
}
