using Mirror.Cloud.ListServerService;

namespace Mirror.Cloud
{
	public interface IApiConnector
	{
		ListServer ListServer { get; }
	}
}
