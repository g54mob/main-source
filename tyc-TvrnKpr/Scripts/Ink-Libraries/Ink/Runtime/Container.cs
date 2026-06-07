using System;
using System.Collections.Generic;
using System.Text;

namespace Ink.Runtime
{
	public class Container : Object, INamedContent
	{
		[Flags]
		public enum CountFlags
		{
			Visits = 1,
			Turns = 2,
			CountStartOnly = 4
		}

		private List<Object> _content;

		private Path _pathToFirstLeafContent;

		public string name { get; set; }

		public List<Object> content
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Dictionary<string, INamedContent> namedContent { get; set; }

		public Dictionary<string, Object> namedOnlyContent
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool visitsShouldBeCounted { get; set; }

		public bool turnIndexShouldBeCounted { get; set; }

		public bool countingAtStartOnly { get; set; }

		public int countFlags
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool hasValidName => false;

		public Path pathToFirstLeafContent => null;

		private Path internalPathToFirstLeafContent => null;

		public void AddContent(Object contentObj)
		{
		}

		public void AddContent(IList<Object> contentList)
		{
		}

		public void InsertContent(Object contentObj, int index)
		{
		}

		public void TryAddNamedContent(Object contentObj)
		{
		}

		public void AddToNamedContentOnly(INamedContent namedContentObj)
		{
		}

		public void AddContentsOfContainer(Container otherContainer)
		{
		}

		protected Object ContentWithPathComponent(Path.Component component)
		{
			return null;
		}

		public SearchResult ContentAtPath(Path path, int partialPathStart = 0, int partialPathLength = -1)
		{
			return default(SearchResult);
		}

		public void BuildStringOfHierarchy(StringBuilder sb, int indentation, Object pointedObj)
		{
		}

		public virtual string BuildStringOfHierarchy()
		{
			return null;
		}
	}
}
