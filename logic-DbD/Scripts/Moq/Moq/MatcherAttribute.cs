using System;
using System.ComponentModel;

namespace Moq
{
	[AttributeUsage(AttributeTargets.Method, Inherited = true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("This feature has been deprecated in favor of `Match.Create`.")]
	public sealed class MatcherAttribute : Attribute
	{
	}
}
