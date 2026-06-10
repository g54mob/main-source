using System;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class StatAttributeElement
	{
		[SerializeField]
		private float baseValue;

		[SerializeField]
		private AttributeType[] attributes;

		public float BaseValue => baseValue;

		public AttributeType[] Attributes => attributes;

		public StatAttributeElement(float baseValue, AttributeType[] attributes = null)
		{
			this.baseValue = baseValue;
			this.attributes = attributes;
		}
	}
}
