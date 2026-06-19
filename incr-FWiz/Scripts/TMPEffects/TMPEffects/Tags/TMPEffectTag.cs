using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TMPEffects.Tags
{
	public sealed class TMPEffectTag : IEquatable<TMPEffectTag>
	{
		private readonly string name;

		private readonly char prefix;

		private readonly ReadOnlyDictionary<string, string> parameters;

		public string Name => null;

		public char Prefix => '\0';

		public ReadOnlyDictionary<string, string> Parameters => null;

		public TMPEffectTag(string name, char prefix, IDictionary<string, string> parameters)
		{
		}

		public bool Equals(TMPEffectTag other)
		{
			return false;
		}
	}
}
