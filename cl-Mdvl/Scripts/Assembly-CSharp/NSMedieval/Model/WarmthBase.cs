using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class WarmthBase : NSEipix.Base.Model
	{
		[SerializeField]
		private List<StatThresholdTrigger> hotTresholds = new List<StatThresholdTrigger>();

		[SerializeField]
		private List<StatThresholdTrigger> coldThresholds = new List<StatThresholdTrigger>();

		public List<StatThresholdTrigger> HotTresholds => hotTresholds;

		public List<StatThresholdTrigger> ColdThresholds => coldThresholds;

		public override string GetID()
		{
			return string.Empty;
		}
	}
}
