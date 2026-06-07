using System;
using Mirror.Cloud.ListServerService;
using UnityEngine.Events;

namespace Mirror.Cloud
{
	[Serializable]
	public class MatchFoundEvent : UnityEvent<ServerJson>
	{
	}
}
