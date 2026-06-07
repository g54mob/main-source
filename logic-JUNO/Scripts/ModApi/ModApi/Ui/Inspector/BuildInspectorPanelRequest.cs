namespace ModApi.Ui.Inspector
{
	public class BuildInspectorPanelRequest
	{
		public InspectorPanelCreationInfo CreationInfo { get; }

		public InspectorModel Model { get; }

		public BuildInspectorPanelRequest(InspectorModel model, InspectorPanelCreationInfo creationInfo)
		{
			Model = model;
			CreationInfo = creationInfo;
		}
	}
}
