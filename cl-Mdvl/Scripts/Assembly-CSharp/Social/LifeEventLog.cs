using System;
using NSEipix.Base;
using NSMedieval.Enums;
using NSMedieval.Model;
using UnityEngine;

namespace Social
{
	[Serializable]
	public class LifeEventLog : Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private LifeEventType lifeEventType;

		[SerializeField]
		private string icon;

		[SerializeField]
		private LocKeys[] locKeys;

		public LifeEventType LifeEventType => lifeEventType;

		public LocKeys[] LocKeys => locKeys;

		public string Icon => icon;

		public override string GetID()
		{
			return id;
		}
	}
}
