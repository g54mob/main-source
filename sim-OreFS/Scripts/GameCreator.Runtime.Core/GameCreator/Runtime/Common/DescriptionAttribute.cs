using System;

namespace GameCreator.Runtime.Common
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class DescriptionAttribute : Attribute, ISearchable
	{
		public string Description { get; }

		public string SearchText => Description;

		public int SearchPriority => 2;

		public DescriptionAttribute(string description)
		{
			Description = description.Trim();
		}
	}
}
