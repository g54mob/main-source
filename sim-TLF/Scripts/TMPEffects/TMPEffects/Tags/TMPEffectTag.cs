using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TMPEffects.Tags
{
	public sealed class TMPEffectTag : IEquatable<TMPEffectTag>
	{
		private readonly string name;

		private readonly char prefix;

		private readonly ReadOnlyDictionary<string, string> parameters;

		public string Name => name;

		public char Prefix => prefix;

		public ReadOnlyDictionary<string, string> Parameters => parameters;

		public TMPEffectTag(string name, char prefix, IDictionary<string, string> parameters)
		{
			this.name = name;
			this.prefix = prefix;
			if (parameters == null)
			{
				this.parameters = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>());
			}
			else
			{
				this.parameters = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>(parameters));
			}
		}

		public bool Equals(TMPEffectTag other)
		{
			if (name == other.name && prefix == other.prefix)
			{
				return parameters.SequenceEqual(other.parameters);
			}
			return false;
		}
	}
}
