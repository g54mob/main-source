using System;

namespace PlaceholderSoftware.WetStuff
{
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class NotifyPropertyChangedInvocatorAttribute : Attribute
	{
		[CanBeNull]
		public string ParameterName { get; private set; }

		public NotifyPropertyChangedInvocatorAttribute()
		{
		}

		public NotifyPropertyChangedInvocatorAttribute([NotNull] string parameterName)
		{
			ParameterName = parameterName;
		}
	}
}
