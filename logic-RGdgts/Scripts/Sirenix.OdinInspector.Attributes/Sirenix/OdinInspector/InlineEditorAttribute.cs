using System;

namespace Sirenix.OdinInspector
{
	public class InlineEditorAttribute : Attribute
	{
		private bool expanded;

		public bool DrawHeader;

		public bool DrawGUI;

		public bool DrawPreview;

		public float MaxHeight;

		public float PreviewWidth;

		public float PreviewHeight;

		public bool IncrementInlineEditorDrawerDepth;

		public InlineEditorObjectFieldModes ObjectFieldMode;

		public bool DisableGUIForVCSLockedAssets;

		public bool Expanded
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ExpandedHasValue { get; private set; }

		public InlineEditorAttribute(InlineEditorModes inlineEditorMode = InlineEditorModes.GUIOnly, InlineEditorObjectFieldModes objectFieldMode = InlineEditorObjectFieldModes.Boxed)
		{
		}

		public InlineEditorAttribute(InlineEditorObjectFieldModes objectFieldMode)
		{
		}
	}
}
