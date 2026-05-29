using System.Windows.Forms.VisualStyles;

namespace Ookii.Dialogs
{
	public static class AdditionalVisualStyleElements
	{
		public static class TextStyle
		{
			private const string _className = "TEXTSTYLE";

			private static VisualStyleElement _mainInstruction;

			private static VisualStyleElement _bodyText;

			public static VisualStyleElement MainInstruction => null;

			public static VisualStyleElement BodyText => null;
		}

		public static class TaskDialog
		{
			private const string _className = "TASKDIALOG";

			private static VisualStyleElement _primaryPanel;

			private static VisualStyleElement _secondaryPanel;

			public static VisualStyleElement PrimaryPanel => null;

			public static VisualStyleElement SecondaryPanel => null;
		}
	}
}
