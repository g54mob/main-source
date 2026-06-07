using System;
using System.Collections.Generic;

namespace Muna
{
	[Serializable]
	[Preserve]
	public class Parameter
	{
		public string name;

		public Dtype dtype;

		public string? description;

		public string? denotation;

		public bool? optional;

		public EnumerationMember[]? enumeration;

		public Dictionary<string, object>? schema;

		public float? min;

		public float? max;

		public int? sampleRate;
	}
}
