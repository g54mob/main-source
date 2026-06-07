using System;

namespace Mirror.Cloud.ListServerService
{
	[Serializable]
	public struct ServerCollectionJson : ICanBeJson
	{
		public ServerJson[] servers;
	}
}
