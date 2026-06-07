using System;

namespace ParadoxNotion.Design
{
	public class ListInspectorOptionAttribute : Attribute
	{
		public readonly bool allowAdd;

		public readonly bool allowRemove;

		public readonly bool showFoldout;

		public ListInspectorOptionAttribute(bool allowAdd, bool allowRemove, bool alwaysExpanded)
		{
		}
	}
}
