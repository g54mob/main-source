using System;

namespace GameCreator.Runtime.Common
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface)]
	public class TitleAttribute : Attribute, ISearchable
	{
		public string Title { get; }

		public string SearchText => Title;

		public int SearchPriority => 10;

		public TitleAttribute(string title)
		{
			Title = title.Trim();
		}

		public override string ToString()
		{
			return Title;
		}
	}
}
