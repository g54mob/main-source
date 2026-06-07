using UnityEngine;

namespace Febucci.UI.Core.Parsing
{
	public abstract class RegionBase
	{
		public readonly string tagId;

		public TagRange[] ranges;

		public RegionBase(string tagId)
		{
		}

		public RegionBase(string tagId, params TagRange[] ranges)
		{
		}

		public RegionBase(string tagId, params Vector2Int[] ranges)
		{
		}
	}
}
