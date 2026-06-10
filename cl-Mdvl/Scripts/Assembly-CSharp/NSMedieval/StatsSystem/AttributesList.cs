using System;
using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class AttributesList : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private Attribute[] attributes;

		private Dictionary<AttributeType, Attribute> cache;

		public IEnumerable<Attribute> Attributes => attributes;

		public AttributesList(string id, Attribute[] attributes)
		{
			this.id = id;
			this.attributes = attributes;
		}

		public override string GetID()
		{
			return id;
		}

		public Attribute GetOverride(AttributeType type)
		{
			if (cache == null)
			{
				cache = new Dictionary<AttributeType, Attribute>();
				Attribute[] array = attributes;
				foreach (Attribute attribute in array)
				{
					cache.Add(attribute.Type, attribute);
				}
			}
			if (!cache.ContainsKey(type))
			{
				return null;
			}
			return cache[type];
		}
	}
}
