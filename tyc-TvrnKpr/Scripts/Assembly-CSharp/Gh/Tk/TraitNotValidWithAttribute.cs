using System;

namespace Gh.Tk
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
	internal sealed class TraitNotValidWithAttribute : Attribute
	{
		public Type[] TraitTypes { get; private set; }

		public TraitNotValidWithAttribute(params Type[] traitsTypes)
		{
		}
	}
}
