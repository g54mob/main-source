using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class InlineEditorAttribute : Attribute
	{
		private bool expanded;

		public bool DrawHeader;

		public bool DrawGUI;

		public bool DrawPreview;

		public float MaxHeight;

		public float PreviewWidth;

		public float PreviewHeight;

		[LabelWidth(220f)]
		public bool IncrementInlineEditorDrawerDepth;

		[LabelWidth(220f)]
		public bool DisableGUIForVCSLockedAssets;

		public InlineEditorObjectFieldModes ObjectFieldMode;

		public PreviewAlignment PreviewAlignment;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "expanded", "ExpandedHasValue" })]
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
