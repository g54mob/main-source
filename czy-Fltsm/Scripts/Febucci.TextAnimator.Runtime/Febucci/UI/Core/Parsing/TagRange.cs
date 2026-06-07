using System.Text;
using UnityEngine;

namespace Febucci.UI.Core.Parsing
{
	public struct TagRange
	{
		public Vector2Int indexes;

		public ModifierInfo[] modifiers;

		public TagRange(Vector2Int indexes, params ModifierInfo[] modifiers)
		{
			this.indexes = indexes;
			this.modifiers = modifiers;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("indexes: ");
			stringBuilder.Append(indexes);
			if (modifiers == null || modifiers.Length == 0)
			{
				stringBuilder.Append("\n no modifiers");
			}
			else
			{
				for (int i = 0; i < modifiers.Length; i++)
				{
					stringBuilder.Append('\n');
					stringBuilder.Append('-');
					stringBuilder.Append(modifiers[i]);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
