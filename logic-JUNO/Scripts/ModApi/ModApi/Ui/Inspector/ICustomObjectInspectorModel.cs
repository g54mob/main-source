namespace ModApi.Ui.Inspector
{
	public interface ICustomObjectInspectorModel
	{
		bool CreateGroup { get; }

		void CreateModel(GroupModel model, IObjectInspector objectInspector);
	}
}
