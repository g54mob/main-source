using System;
using ModApi.Ui.Inspector;

namespace ModApi.Ui.Events
{
	public class InspectorPanelLoadingEventArgs : EventArgs
	{
		public InspectorPanelCreationInfo CreationInfo { get; }

		public InspectorModel Model { get; }

		public InspectorPanelLoadingEventArgs(InspectorModel model, InspectorPanelCreationInfo creationInfo)
		{
			Model = model;
			CreationInfo = creationInfo;
		}
	}
}
