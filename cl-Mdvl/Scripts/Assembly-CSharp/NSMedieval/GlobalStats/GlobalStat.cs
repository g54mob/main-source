using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.GlobalStats
{
	[Serializable]
	public class GlobalStat : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private float min;

		[SerializeField]
		private float max;

		[SerializeField]
		private float defaultValue;

		[SerializeField]
		private float dailyFalloff;

		[SerializeField]
		private float dailyFalloffThreshold;

		[SerializeField]
		private bool hideInUi;

		[SerializeField]
		private GlobalStatTrigger[] triggers;

		[SerializeField]
		private bool alwaysShowMessages;

		[NonSerialized]
		private Dictionary<string, GlobalStatTrigger> triggersByIdCache;

		public float DefaultValue => defaultValue;

		public LocKeys[] LocKeys => locKeys;

		public float Min => min;

		public float Max => max;

		public bool HideInUi => hideInUi;

		public GlobalStatTrigger[] Triggers => triggers;

		public float DailyFalloff => dailyFalloff;

		public float DailyFalloffThreshold => dailyFalloffThreshold;

		public bool AlwaysShowMessages => alwaysShowMessages;

		public GlobalStatTrigger GetTrigger(string triggerId)
		{
			if (triggersByIdCache == null)
			{
				triggersByIdCache = new Dictionary<string, GlobalStatTrigger>();
				GlobalStatTrigger[] array = triggers;
				foreach (GlobalStatTrigger globalStatTrigger in array)
				{
					triggersByIdCache.Add(globalStatTrigger.ID, globalStatTrigger);
				}
			}
			triggersByIdCache.TryGetValue(triggerId, out var value);
			return value;
		}

		public override string GetID()
		{
			return id;
		}

		public override string ToString()
		{
			return $"{id} - min: {min}, max: {max}, defaultValue: {defaultValue}, hideInUi: {hideInUi}";
		}
	}
}
