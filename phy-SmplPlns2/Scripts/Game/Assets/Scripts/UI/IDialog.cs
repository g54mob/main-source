namespace Assets.Scripts.UI
{
	public interface IDialog
	{
		bool IsModal { get; }

		event DialogDelegate Closed;

		void Close();
	}
}
