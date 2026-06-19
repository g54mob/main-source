using System;
using System.Diagnostics;

namespace PlayFab.Multiplayer.Interop
{
	[Conditional("DEBUG")]
	[AttributeUsage(AttributeTargets.All, Inherited = true)]
	internal sealed class NativeTypeNameAttribute : Attribute
	{
		public string Name { get; }

		public NativeTypeNameAttribute(string name)
		{
			Name = name;
		}
	}
}
