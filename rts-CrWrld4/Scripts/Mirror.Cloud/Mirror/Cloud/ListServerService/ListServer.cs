namespace Mirror.Cloud.ListServerService
{
	public sealed class ListServer
	{
		public readonly IListServerServerApi ServerApi;

		public readonly IListServerClientApi ClientApi;

		public ListServer(IListServerServerApi serverApi, IListServerClientApi clientApi)
		{
		}
	}
}
