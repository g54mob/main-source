using System;

namespace Cinemachine
{
	public sealed class DocumentationSortingAttribute : Attribute
	{
		public enum Level
		{
			Undoc = 0,
			API = 1,
			UserRef = 2
		}

		public Level Category { get; private set; }

		public DocumentationSortingAttribute(Level category)
		{
		}
	}
}
