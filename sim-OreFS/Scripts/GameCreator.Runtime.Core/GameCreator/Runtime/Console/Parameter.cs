using System;

namespace GameCreator.Runtime.Console
{
	public readonly struct Parameter
	{
		public const char QUOTES = '"';

		[field: NonSerialized]
		public string Name { get; }

		[field: NonSerialized]
		public string Value { get; }

		public Parameter(string name, string value)
		{
			Name = name.ToLowerInvariant();
			Value = value;
		}

		public override string ToString()
		{
			string obj = (Name.Contains(" ") ? $"{'"'}{Name}{'"'}" : Name);
			string text = (Value.Contains(" ") ? $"{'"'}{Value}{'"'}" : Value);
			return obj + " " + text;
		}
	}
}
