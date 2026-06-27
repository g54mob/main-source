using System;
using System.Collections.Concurrent;
using Reflectify;

namespace FluentAssertions.Equivalency
{
	internal static class MemberVisibilityExtensions
	{
		private static readonly ConcurrentDictionary<MemberVisibility, MemberKind> Cache = new ConcurrentDictionary<MemberVisibility, MemberKind>();

		public static MemberKind ToMemberKind(this MemberVisibility visibility)
		{
			return Cache.GetOrAdd(visibility, delegate(MemberVisibility v)
			{
				MemberKind memberKind = MemberKind.None;
				MemberVisibility[] array = (MemberVisibility[])Enum.GetValues(typeof(MemberVisibility));
				foreach (MemberVisibility memberVisibility in array)
				{
					if (v.HasFlag(memberVisibility))
					{
						memberKind = (MemberKind)((int)memberKind | (memberVisibility switch
						{
							MemberVisibility.None => 0, 
							MemberVisibility.Internal => 2, 
							MemberVisibility.Public => 1, 
							MemberVisibility.ExplicitlyImplemented => 4, 
							MemberVisibility.DefaultInterfaceProperties => 8, 
							_ => throw new ArgumentOutOfRangeException("v", v, null), 
						}));
					}
				}
				return memberKind;
			});
		}
	}
}
