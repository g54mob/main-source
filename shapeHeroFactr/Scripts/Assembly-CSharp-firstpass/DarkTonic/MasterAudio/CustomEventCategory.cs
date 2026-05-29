using System;
using System.Collections.Generic;

namespace DarkTonic.MasterAudio
{
	[Serializable]
	public class CustomEventCategory
	{
		public string CatName;

		public bool IsExpanded;

		public bool IsEditing;

		public bool IsTemporary;

		public string ProspectiveName;

		private readonly List<int> _actorInstanceIds;

		public bool HasLiveActors => false;

		public void AddActorInstanceId(int instanceId)
		{
		}

		public void RemoveActorInstanceId(int instanceId)
		{
		}
	}
}
