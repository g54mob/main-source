using System;

namespace ProtoBuf
{
	[Flags]
	public enum MemberSerializationOptions
	{
		None = 0,
		Packed = 1,
		Required = 2,
		[Obsolete("Reference-tracking and dynamic-type are not currently implemented in this build; they may be reinstated later; this is partly due to doubts over whether the features are adviseable, and partly over confidence in testing all the scenarios (it takes time; that time hasn't get happened); feedback is invited", false)]
		AsReference = 4,
		[Obsolete("Reference-tracking and dynamic-type are not currently implemented in this build; they may be reinstated later; this is partly due to doubts over whether the features are adviseable, and partly over confidence in testing all the scenarios (it takes time; that time hasn't get happened); feedback is invited", false)]
		DynamicType = 8,
		OverwriteList = 0x10,
		[Obsolete("Reference-tracking and dynamic-type are not currently implemented in this build; they may be reinstated later; this is partly due to doubts over whether the features are adviseable, and partly over confidence in testing all the scenarios (it takes time; that time hasn't get happened); feedback is invited", false)]
		AsReferenceHasValue = 0x20
	}
}
