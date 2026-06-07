namespace Ink.Runtime
{
	public class Object
	{
		private DebugMetadata _debugMetadata;

		private Path _path;

		public Object parent { get; set; }

		public DebugMetadata debugMetadata
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DebugMetadata ownDebugMetadata => null;

		public Path path => null;

		public Container rootContentContainer => null;

		public int? DebugLineNumberOfPath(Path path)
		{
			return null;
		}

		public SearchResult ResolvePath(Path path)
		{
			return default(SearchResult);
		}

		public Path ConvertPathToRelative(Path globalPath)
		{
			return null;
		}

		public string CompactPathString(Path otherPath)
		{
			return null;
		}

		public virtual Object Copy()
		{
			return null;
		}

		public void SetChild<T>(ref T obj, T value) where T : Object
		{
		}

		public static implicit operator bool(Object obj)
		{
			return false;
		}

		public static bool operator ==(Object a, Object b)
		{
			return false;
		}

		public static bool operator !=(Object a, Object b)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
