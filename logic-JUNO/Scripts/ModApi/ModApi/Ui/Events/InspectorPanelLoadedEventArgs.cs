using System;
using ModApi.Ui.Inspector;

namespace ModApi.Ui.Events
{
	public class InspectorPanelLoadedEventArgs : EventArgs
	{
		public InspectorModel Model { get; }

		public IInspectorPanel Panel { get; }

		public InspectorPanelLoadedEventArgs(IInspectorPanel panel, InspectorModel model)
		{
			Panel = panel;
			Model = model;
		}
	}
}
