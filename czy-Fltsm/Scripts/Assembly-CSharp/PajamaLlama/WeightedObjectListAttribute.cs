using System;
using UnityEngine;

namespace PajamaLlama
{
	public class WeightedObjectListAttribute : PropertyAttribute
	{
		public Type ObjectType { get; private set; }

		public WeightedObjectListAttribute(Type type = null)
		{
			Type typeFromHandle = typeof(UnityEngine.Object);
			if (typeFromHandle.IsAssignableFrom(type))
			{
				ObjectType = type;
			}
			else
			{
				ObjectType = typeFromHandle;
			}
		}
	}
}
