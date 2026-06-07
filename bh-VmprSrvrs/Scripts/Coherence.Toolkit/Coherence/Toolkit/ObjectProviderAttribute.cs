using System;
using System.Collections.Generic;
using UnityEngine;

namespace Coherence.Toolkit
{
	public class ObjectProviderAttribute : PropertyAttribute
	{
		private static readonly List<Type> allowedTypes;

		public Type Type { get; }

		public string PrefixLabel { get; }

		public string Tooltip { get; }

		public ObjectProviderAttribute(Type type, string prefixLabel, string tooltip)
		{
		}
	}
}
