using System;

namespace Pathfinding
{
	[Serializable]
	public struct PathfindingTag
	{
		public uint value;

		public PathfindingTag(uint value)
		{
			this.value = value;
		}

		public static implicit operator uint(PathfindingTag tag)
		{
			return tag.value;
		}

		public static implicit operator PathfindingTag(uint tag)
		{
			return new PathfindingTag(tag);
		}

		public static PathfindingTag FromName(string tagName)
		{
			AstarPath.FindAstarPath();
			if (AstarPath.active == null)
			{
				throw new InvalidOperationException("There's no AstarPath component in the scene. Cannot get tag names.");
			}
			int num = Array.IndexOf(AstarPath.active.GetTagNames(), tagName);
			if (num == -1)
			{
				throw new ArgumentException("There's no pathfinding tag with the name '" + tagName + "'");
			}
			return new PathfindingTag((uint)num);
		}

		public override string ToString()
		{
			return value.ToString();
		}
	}
}
