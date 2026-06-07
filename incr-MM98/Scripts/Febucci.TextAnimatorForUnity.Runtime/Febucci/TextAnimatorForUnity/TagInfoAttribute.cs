using System;

namespace Febucci.TextAnimatorForUnity
{
	[AttributeUsage(AttributeTargets.Class)]
	public class TagInfoAttribute : Attribute
	{
		public readonly string tagID;

		public TagInfoAttribute(string tagID)
		{
			this.tagID = tagID;
		}
	}
}
