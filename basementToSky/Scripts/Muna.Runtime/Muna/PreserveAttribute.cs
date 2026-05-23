using System;

namespace Muna
{
	[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
	internal sealed class PreserveAttribute : Attribute
	{
	}
}
