using System;
using MessagePack;
using MessagePack.Formatters;
using Unity.Collections;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	[MessagePackFormatter(typeof(SeedFormatter))]
	public struct Seed : IEquatable<Seed>
	{
		private class SeedFormatter : IMessagePackFormatter<Seed>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, Seed value, MessagePackSerializerOptions options)
			{
				options.Resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.StrValue, options);
			}

			public Seed Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return new Seed(options.Resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options));
			}
		}

		public const int MaxLength = 8;

		public const string Characters = "abcdefghijklmnopqrstuvwxyz123456789";

		public const string FriendlyCharacters = "bdghjmqrtvwxy346789";

		[Key(0)]
		public FixedString32 Value;

		[IgnoreMember]
		public bool IsSet => Value.Length > 0;

		[IgnoreMember]
		public int IntValue => Value.GetHashCode();

		[IgnoreMember]
		public string StrValue => Value.Value;

		public Seed(string s)
		{
			if (s.Length > 8)
			{
				s = s.Substring(0, 8);
			}
			Value = s;
		}

		public static Seed Generate(int source_random)
		{
			FixedString32 value = default(FixedString32);
			UnityEngine.Random.State state = UnityEngine.Random.state;
			UnityEngine.Random.InitState(source_random);
			for (int i = 0; i < 8; i++)
			{
				char value2 = "bdghjmqrtvwxy346789"[UnityEngine.Random.Range(0, "bdghjmqrtvwxy346789".Length)];
				value.Add(Convert.ToByte(value2));
			}
			UnityEngine.Random.state = state;
			return new Seed
			{
				Value = value
			};
		}

		public bool Equals(Seed other)
		{
			return Value.Equals(other.Value);
		}

		public override bool Equals(object obj)
		{
			if (obj is Seed other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public static bool operator ==(Seed left, Seed right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Seed left, Seed right)
		{
			return !left.Equals(right);
		}
	}
}
