using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class RoomItemMaintenanceComponent : EntityTickComponent
	{
		public JobMaintenance Job { get; set; }

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		public override void Tick()
		{
			base.Tick();
			if (Job == null)
			{
				return;
			}
			Staff staff = Job.GetStaff();
			if (staff != null)
			{
				RoomItem owner = GetOwner<RoomItem>();
				ObjectInteraction interaction = staff.Interaction;
				if (interaction != null && interaction.Name == "Maintenance" && interaction.ParentRoomItem == owner)
				{
					float maintenanceMultiplier = staff.GetMaintenanceMultiplier(owner.OwningRoom);
					maintenanceMultiplier *= owner.Definition.JanitorRepairRate;
					maintenanceMultiplier *= Time.deltaTime;
					owner.MaintenanceLevel.Modify(0f - maintenanceMultiplier, 1f);
				}
			}
		}
	}
}
