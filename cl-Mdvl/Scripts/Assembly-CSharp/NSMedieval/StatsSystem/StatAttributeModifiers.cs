using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class StatAttributeModifiers
	{
		[SerializeField]
		private List<StatAttributeElement> min;

		[SerializeField]
		private List<StatAttributeElement> max;

		[SerializeField]
		private List<StatAttributeElement> step;

		[SerializeField]
		private List<StatAttributeElement> threshold;

		[SerializeField]
		private List<StatAttributeElement> target;

		public List<StatAttributeElement> Min => min;

		public List<StatAttributeElement> Max => max;

		public List<StatAttributeElement> Step => step;

		public List<StatAttributeElement> Threshold => threshold;

		public List<StatAttributeElement> Target => target;

		public StatAttributeModifiers(List<StatAttributeElement> min, List<StatAttributeElement> max, List<StatAttributeElement> step, List<StatAttributeElement> threshold)
		{
			this.min = min;
			this.max = max;
			this.step = step;
			this.threshold = threshold;
		}
	}
}
