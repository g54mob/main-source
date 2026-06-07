using System;

namespace Gh.Tk
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	internal sealed class RelatedSkillsAttribute : Attribute
	{
		public Type[] Types { get; private set; }

		public RelatedSkillsAttribute(params Type[] types)
		{
		}
	}
}
