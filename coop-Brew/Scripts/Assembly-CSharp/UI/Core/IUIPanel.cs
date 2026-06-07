namespace UI.Core
{
	public interface IUIPanel
	{
		string PanelId { get; }

		int Priority { get; }

		bool IsOpen { get; }

		void Close();
	}
}
