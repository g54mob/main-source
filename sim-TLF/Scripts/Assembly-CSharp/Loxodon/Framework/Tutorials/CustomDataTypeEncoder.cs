using System;
using Loxodon.Framework.Prefs;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class CustomDataTypeEncoder : ITypeEncoder
	{
		private int priority;

		public int Priority
		{
			get
			{
				return priority;
			}
			set
			{
				priority = value;
			}
		}

		public bool IsSupport(Type type)
		{
			return typeof(CustomData).Equals(type);
		}

		public object Decode(Type type, string value)
		{
			return JsonUtility.FromJson(value, type);
		}

		public string Encode(object value)
		{
			return JsonUtility.ToJson(value);
		}
	}
}
