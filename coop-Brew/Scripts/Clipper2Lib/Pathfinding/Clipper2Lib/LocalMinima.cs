namespace Pathfinding.Clipper2Lib
{
	internal readonly struct LocalMinima
	{
		public readonly Vertex vertex;

		public readonly PathType polytype;

		public readonly bool isOpen;

		public LocalMinima(Vertex vertex, PathType polytype, bool isOpen = false)
		{
			this.vertex = null;
			this.polytype = default(PathType);
			this.isOpen = false;
		}

		public static bool operator ==(LocalMinima lm1, LocalMinima lm2)
		{
			return false;
		}

		public static bool operator !=(LocalMinima lm1, LocalMinima lm2)
		{
			return false;
		}

		public override bool Equals(object? obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
