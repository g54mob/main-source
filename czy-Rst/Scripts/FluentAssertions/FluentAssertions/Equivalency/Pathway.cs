using FluentAssertions.Common;

namespace FluentAssertions.Equivalency
{
	public record Pathway
	{
		public delegate string GetDescription(string pathAndName);

		public string Path
		{
			get
			{
				return path;
			}
			private init
			{
				path = value;
				pathAndName = null;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
			internal set
			{
				name = value;
				pathAndName = null;
			}
		}

		public string PathAndName => pathAndName ?? (pathAndName = path.Combine(name));

		public string Description => getDescription(PathAndName);

		private readonly string path = string.Empty;

		private string name = string.Empty;

		private string pathAndName;

		private readonly GetDescription getDescription;

		public Pathway(string path, string name, GetDescription getDescription)
		{
			Path = path;
			Name = name;
			this.getDescription = getDescription;
		}

		public Pathway(Pathway parent, string name, GetDescription getDescription)
		{
			Path = parent.PathAndName;
			Name = name;
			this.getDescription = getDescription;
		}

		public override string ToString()
		{
			return Description;
		}
	}
}
