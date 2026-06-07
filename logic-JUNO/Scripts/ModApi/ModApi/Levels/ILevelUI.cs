using ModApi.Ui;

namespace ModApi.Levels
{
	public interface ILevelUI : IXmlLayoutController
	{
		bool Visible { get; set; }

		void OnSceneLoaded();

		void OnSceneUnloading();

		void ShowMessage(string message, float duration = 5f);
	}
}
