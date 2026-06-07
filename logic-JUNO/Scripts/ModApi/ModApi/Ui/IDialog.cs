namespace ModApi.Ui
{
	public interface IDialog
	{
		bool AllowCameraZoom { get; }

		event DialogDelegate Closed;

		void Close();
	}
}
