using System;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomJobComponent : EntityComponent
	{
		public Job Job { get; set; }

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}
	}
}
