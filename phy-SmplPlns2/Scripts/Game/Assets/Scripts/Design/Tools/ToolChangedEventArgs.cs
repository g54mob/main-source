using System;

namespace Assets.Scripts.Design.Tools
{
	public class ToolChangedEventArgs : EventArgs
	{
		public DesignerTool NewTool { get; }

		public DesignerTool OldTool { get; }

		public ToolChangedEventArgs(DesignerTool oldTool, DesignerTool newTool)
		{
			OldTool = oldTool;
			NewTool = newTool;
		}
	}
}
