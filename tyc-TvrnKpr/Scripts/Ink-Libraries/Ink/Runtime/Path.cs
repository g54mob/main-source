using System;
using System.Collections.Generic;

namespace Ink.Runtime
{
	public class Path : IEquatable<Path>
	{
		public class Component : IEquatable<Component>
		{
			public int index { get; private set; }

			public string name { get; private set; }

			public bool isIndex => false;

			public bool isParent => false;

			public Component(int index)
			{
			}

			public Component(string name)
			{
			}

			public static Component ToParent()
			{
				return null;
			}

			public override string ToString()
			{
				return null;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public bool Equals(Component otherComp)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		private static string parentId;

		private string _componentsString;

		private List<Component> _components;

		public bool isRelative { get; private set; }

		public Component head => null;

		public Path tail => null;

		public int length => 0;

		public Component lastComponent => null;

		public bool containsNamedComponent => false;

		public static Path self => null;

		public string componentsString
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public Component GetComponent(int index)
		{
			return null;
		}

		public Path()
		{
		}

		public Path(Component head, Path tail)
		{
		}

		public Path(IEnumerable<Component> components, bool relative = false)
		{
		}

		public Path(string componentsString)
		{
		}

		public Path PathByAppendingPath(Path pathToAppend)
		{
			return null;
		}

		public Path PathByAppendingComponent(Component c)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Path otherPath)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
