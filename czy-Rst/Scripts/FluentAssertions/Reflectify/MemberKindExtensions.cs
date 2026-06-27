using System.Reflection;

namespace Reflectify
{
	internal static class MemberKindExtensions
	{
		public static BindingFlags ToBindingFlags(this MemberKind kind)
		{
			BindingFlags bindingFlags = BindingFlags.Default;
			if (kind.HasFlag(MemberKind.Public))
			{
				bindingFlags |= BindingFlags.Public;
			}
			if (kind.HasFlag(MemberKind.Internal))
			{
				bindingFlags |= BindingFlags.NonPublic;
			}
			return bindingFlags;
		}
	}
}
