#define LOG_LEVEL_VERBOSE
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class RoomItemFireExtinguisherComponent : EntityComponent
	{
		public bool StaffAssigned { get; private set; }

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			StaffAssigned = false;
		}

		public void AssignStaff(Staff staff)
		{
			StaffAssigned = staff != null;
			if (staff != null)
			{
				Logging.Info(LogChannels.StaffWork, "RoomItemFireExtinguisherComponent: {0} assigned to {1}", staff, GetOwner());
			}
			else
			{
				Logging.Info(LogChannels.StaffWork, "RoomItemFireExtinguisherComponent: NULL assigned to {0}", GetOwner());
			}
		}
	}
}
