using System;

namespace Gh
{
	[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	internal sealed class MigrateSaveFileAttribute : Attribute
	{
		public int From { get; private set; }

		public int To { get; private set; }

		public MigrateSaveFileAttribute(int from, int to)
		{
		}
	}
}
