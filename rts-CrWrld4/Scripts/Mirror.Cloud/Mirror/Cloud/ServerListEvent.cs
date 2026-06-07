using System;
using Mirror.Cloud.ListServerService;
using UnityEngine.Events;

namespace Mirror.Cloud
{
	[Serializable]
	public class ServerListEvent : UnityEvent<ServerCollectionJson>
	{
	}
}
