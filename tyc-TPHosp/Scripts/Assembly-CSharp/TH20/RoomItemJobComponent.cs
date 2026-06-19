using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemJobComponent : EntityComponent
	{
		[SerializeField]
		private StaffRequired _staffRequired;

		public JobService Job { get; set; }

		public StaffRequired StaffRequired => _staffRequired;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		public bool IsStaffed()
		{
			if (Job != null)
			{
				Staff staff = Job.GetStaff();
				if (staff != null && staff.Interaction != null && staff.Interaction.ParentRoomItem == GetOwner<RoomItem>())
				{
					return true;
				}
			}
			return false;
		}
	}
}
