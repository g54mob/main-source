using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Namotion.Reflection
{
	internal readonly struct NullableFlagsSource
	{
		private readonly struct CacheKey
		{
			public Type Type { get; init; }

			public Assembly? Assembly { get; init; }

			public CacheKey(Type Type, Assembly? Assembly)
			{
				this.Type = Type;
				this.Assembly = Assembly;
			}

			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("CacheKey");
				stringBuilder.Append(" { ");
				if (PrintMembers(stringBuilder))
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append('}');
				return stringBuilder.ToString();
			}

			private bool PrintMembers(StringBuilder builder)
			{
				builder.Append("Type = ");
				builder.Append(Type);
				builder.Append(", Assembly = ");
				builder.Append(Assembly);
				return true;
			}

			public static bool operator !=(CacheKey left, CacheKey right)
			{
				return !(left == right);
			}

			public static bool operator ==(CacheKey left, CacheKey right)
			{
				return left.Equals(right);
			}

			public override int GetHashCode()
			{
				return EqualityComparer<System.Type>.Default.GetHashCode(Type) * -1521134295 + EqualityComparer<System.Reflection.Assembly>.Default.GetHashCode(Assembly);
			}

			public override bool Equals(object obj)
			{
				if (obj is CacheKey)
				{
					return Equals((CacheKey)obj);
				}
				return false;
			}

			public bool Equals(CacheKey other)
			{
				if (EqualityComparer<System.Type>.Default.Equals(Type, other.Type))
				{
					return EqualityComparer<System.Reflection.Assembly>.Default.Equals(Assembly, other.Assembly);
				}
				return false;
			}

			public void Deconstruct(out Type Type, out Assembly? Assembly)
			{
				Type = this.Type;
				Assembly = this.Assembly;
			}
		}

		private static Dictionary<CacheKey, NullableFlagsSource> _nullableCache = new Dictionary<CacheKey, NullableFlagsSource>();

		public readonly byte[]? NullableFlags;

		public static NullableFlagsSource Create(Type type, Assembly? assembly = null)
		{
			Dictionary<CacheKey, NullableFlagsSource> nullableCache = _nullableCache;
			CacheKey cacheKey = new CacheKey(type, assembly);
			if (!nullableCache.TryGetValue(cacheKey, out var value))
			{
				value = new NullableFlagsSource(type, assembly);
				Interlocked.CompareExchange(ref _nullableCache, new Dictionary<CacheKey, NullableFlagsSource>(nullableCache) { [cacheKey] = value }, nullableCache);
			}
			return value;
		}

		public static NullableFlagsSource Create(MemberInfo member)
		{
			return new NullableFlagsSource(member);
		}

		private NullableFlagsSource(Type type, Assembly? assembly)
		{
			byte[] nullableFlags = GetNullableFlags(type);
			if (nullableFlags == null && (object)assembly != null)
			{
				nullableFlags = GetNullableFlags(assembly);
			}
			NullableFlags = nullableFlags;
		}

		private NullableFlagsSource(MemberInfo memberInfo)
		{
			NullableFlags = GetNullableFlags(memberInfo);
		}

		private static byte[]? GetNullableFlags<T>(T provider) where T : ICustomAttributeProvider
		{
			object[] customAttributes = provider.GetCustomAttributes(inherit: false);
			foreach (object obj in customAttributes)
			{
				Type type = obj.GetType();
				if (type.Name == "NullableContextAttribute" && type.Namespace == "System.Runtime.CompilerServices")
				{
					return new byte[1] { (byte)type.GetRuntimeField("Flag").GetValue(obj) };
				}
			}
			return null;
		}
	}
}
