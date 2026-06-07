using System;

namespace Gh
{
	[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	internal sealed class PostLoadMigrateSaveFileAttribute : Attribute
	{
		public int From { get; private set; }

		public int To { get; private set; }

		public PostLoadMigrateSaveFileAttribute(int from, int to)
		{
		}
	}
}
