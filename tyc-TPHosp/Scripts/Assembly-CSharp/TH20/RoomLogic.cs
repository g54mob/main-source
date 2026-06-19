using System;

namespace TH20
{
	public abstract class RoomLogic : EntityTickComponent
	{
		protected Room _room;

		protected override Type ValidEntityType()
		{
			return typeof(Room);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_room = GetOwner<Room>();
		}

		public virtual Job CreateJob(StaffRequired staffRequired)
		{
			return new JobRoom(staffRequired, _room);
		}

		public virtual string GetStaffDropResult(Staff staff)
		{
			return null;
		}

		public abstract bool IsProjectAssigned();

		public virtual bool ShouldIdleWhenDroppedInRoom(Staff staff)
		{
			return true;
		}
	}
}
