using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffDatabase
	{
		public SharedInstance<StaffDefinition>[] Staff;

		public StaffDefinition GetDefinition(StaffDefinition.Type type)
		{
			SharedInstance<StaffDefinition>[] staff = Staff;
			foreach (SharedInstance<StaffDefinition> sharedInstance in staff)
			{
				if (sharedInstance.Instance._type == type)
				{
					return sharedInstance.Instance;
				}
			}
			return null;
		}
	}
}
