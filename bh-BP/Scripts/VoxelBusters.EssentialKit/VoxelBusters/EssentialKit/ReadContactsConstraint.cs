using System;

namespace VoxelBusters.EssentialKit
{
	[Flags]
	public enum ReadContactsConstraint
	{
		None = 0,
		MustIncludeName = 1,
		MustIncludePhoneNumber = 2,
		MustIncludeEmail = 4
	}
}
