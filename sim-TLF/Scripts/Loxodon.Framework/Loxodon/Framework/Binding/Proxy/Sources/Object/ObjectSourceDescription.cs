using System;
using Loxodon.Framework.Binding.Paths;

namespace Loxodon.Framework.Binding.Proxy.Sources.Object
{
	[Serializable]
	public class ObjectSourceDescription : SourceDescription
	{
		private Path path;

		public virtual Path Path
		{
			get
			{
				return path;
			}
			set
			{
				path = value;
				if (path != null)
				{
					IsStatic = path.IsStatic;
				}
			}
		}

		public ObjectSourceDescription()
		{
			IsStatic = false;
		}

		public ObjectSourceDescription(Path path)
		{
			Path = path;
		}

		public override string ToString()
		{
			if (path != null)
			{
				return "Path:" + path.ToString();
			}
			return "Path:null";
		}
	}
}
