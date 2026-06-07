namespace Client
{
	public interface IViewClientObserver
	{
		void OnViewAdded(IClient client, IView view);

		void OnViewRemoved(IClient client, IView view);
	}
}
