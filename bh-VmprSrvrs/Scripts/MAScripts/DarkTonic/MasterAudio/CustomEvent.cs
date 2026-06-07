using System;
using System.Collections.Generic;

namespace DarkTonic.MasterAudio
{
	[Serializable]
	public class CustomEvent
	{
		public string EventName;

		public string ProspectiveName;

		public bool IsEditing;

		public bool eventExpanded;

		public MasterAudio.CustomEventReceiveMode eventReceiveMode;

		public float distanceThreshold;

		public MasterAudio.EventReceiveFilter eventRcvFilterMode;

		public int filterModeQty;

		public bool isTemporary;

		public int frameLastFired;

		public string categoryName;

		private readonly List<int> _actorInstanceIds;

		public bool HasLiveActors => false;

		public CustomEvent(string eventName)
		{
		}

		public void AddActorInstanceId(int instanceId)
		{
		}

		public void RemoveActorInstanceId(int instanceId)
		{
		}
	}
}
