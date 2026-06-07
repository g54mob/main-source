using UnityEngine;

namespace Febucci.UI.Core.Parsing
{
	public struct TagRange
	{
		public Vector2Int indexes;

		public ModifierInfo[] modifiers;

		public TagRange(Vector2Int indexes, params ModifierInfo[] modifiers)
		{
			this.indexes = default(Vector2Int);
			this.modifiers = null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
