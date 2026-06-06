using System;
using UnityEngine;

namespace PajamaLlama
{
	public class TypesDerivedFromAttribute : PropertyAttribute
	{
		public Type Type { get; private set; }

		public TypesDerivedFromAttribute(Type type)
		{
			Type = type;
		}
	}
}
