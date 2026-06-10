using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	public class StartingEventSchedule : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private List<string> predefinedEvents;

		public List<string> PredefinedEvents => predefinedEvents;

		public LocKeys[] LocKeys => locKeys;

		public override string GetID()
		{
			return id;
		}
	}
}
