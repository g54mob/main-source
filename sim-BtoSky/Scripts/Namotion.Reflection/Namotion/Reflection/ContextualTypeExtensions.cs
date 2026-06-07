using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Namotion.Reflection
{
	public static class ContextualTypeExtensions
	{
		private readonly struct CacheKey
		{
			public string Prefix { get; init; }

			public string Key1 { get; init; }

			public string? Key2 { get; init; }

			public string? Key3 { get; init; }

			public string? Key4 { get; init; }

			public CacheKey(string Prefix, string Key1, string? Key2 = null, string? Key3 = null, string? Key4 = null)
			{
				this.Prefix = Prefix;
				this.Key1 = Key1;
				this.Key2 = Key2;
				this.Key3 = Key3;
				this.Key4 = Key4;
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
				builder.Append("Prefix = ");
				builder.Append((object)Prefix);
				builder.Append(", Key1 = ");
				builder.Append((object)Key1);
				builder.Append(", Key2 = ");
				builder.Append((object)Key2);
				builder.Append(", Key3 = ");
				builder.Append((object)Key3);
				builder.Append(", Key4 = ");
				builder.Append((object)Key4);
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
				return (((EqualityComparer<string>.Default.GetHashCode(Prefix) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Key1)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Key2)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Key3)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Key4);
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
				if (EqualityComparer<string>.Default.Equals(Prefix, other.Prefix) && EqualityComparer<string>.Default.Equals(Key1, other.Key1) && EqualityComparer<string>.Default.Equals(Key2, other.Key2) && EqualityComparer<string>.Default.Equals(Key3, other.Key3))
				{
					return EqualityComparer<string>.Default.Equals(Key4, other.Key4);
				}
				return false;
			}

			public void Deconstruct(out string Prefix, out string Key1, out string? Key2, out string? Key3, out string? Key4)
			{
				Prefix = this.Prefix;
				Key1 = this.Key1;
				Key2 = this.Key2;
				Key3 = this.Key3;
				Key4 = this.Key4;
			}
		}

		private static readonly ConcurrentDictionary<CacheKey, object> Cache = new ConcurrentDictionary<CacheKey, object>();

		internal static void ClearCache()
		{
			Cache.Clear();
		}

		public static ContextualType ToContextualType(this Type type)
		{
			if (type.FullName == null)
			{
				return ContextualType.ForType(type, ArrayExt.Empty<Attribute>());
			}
			CacheKey key = new CacheKey("Type:Context", type.FullName);
			return (ContextualType)Cache.GetOrAdd(key, (CacheKey k) => ContextualType.ForType(type, ArrayExt.Empty<Attribute>()));
		}

		public static CachedType ToCachedType(this Type type)
		{
			if (type.FullName == null)
			{
				return new CachedType(type);
			}
			CacheKey key = new CacheKey("Type", type.FullName);
			return (CachedType)Cache.GetOrAdd(key, (CacheKey k) => new CachedType(type));
		}

		public static IEnumerable<ContextualAccessorInfo> GetContextualAccessors(this Type type)
		{
			ContextualType contextualType = type.ToContextualType();
			return contextualType.Fields.OfType<ContextualAccessorInfo>().Concat(contextualType.Properties);
		}

		public static ContextualPropertyInfo[] GetContextualProperties(this Type type)
		{
			return type.ToContextualType().Properties;
		}

		public static ContextualFieldInfo[] GetContextualFields(this Type type)
		{
			return type.ToContextualType().Fields;
		}

		public static ContextualType ToContextualType(this Type type, IEnumerable<Attribute> attributes)
		{
			return ContextualType.ForType(type, attributes);
		}

		public static ContextualParameterInfo ToContextualParameter(this ParameterInfo parameterInfo)
		{
			CacheKey key = new CacheKey("Parameter", parameterInfo.Name, parameterInfo.ParameterType.FullName, parameterInfo.Member.Name, parameterInfo.Member.DeclaringType.FullName);
			return (ContextualParameterInfo)Cache.GetOrAdd(key, delegate
			{
				int nullableFlagsIndex = 0;
				return new ContextualParameterInfo(parameterInfo, ref nullableFlagsIndex, null);
			});
		}

		public static ContextualPropertyInfo ToContextualProperty(this PropertyInfo propertyInfo)
		{
			CacheKey key = new CacheKey("Property", propertyInfo.Name, propertyInfo.DeclaringType.FullName);
			return (ContextualPropertyInfo)Cache.GetOrAdd(key, delegate
			{
				int nullableFlagsIndex = 0;
				return new ContextualPropertyInfo(propertyInfo, ref nullableFlagsIndex, null);
			});
		}

		public static ContextualFieldInfo ToContextualField(this FieldInfo fieldInfo)
		{
			CacheKey key = new CacheKey("Field", fieldInfo.Name, fieldInfo.DeclaringType.FullName);
			return (ContextualFieldInfo)Cache.GetOrAdd(key, delegate
			{
				int nullableFlagsIndex = 0;
				return new ContextualFieldInfo(fieldInfo, ref nullableFlagsIndex, null);
			});
		}

		public static ContextualAccessorInfo ToContextualAccessor(this MemberInfo memberInfo)
		{
			if (memberInfo is PropertyInfo propertyInfo)
			{
				return propertyInfo.ToContextualProperty();
			}
			if (memberInfo is FieldInfo fieldInfo)
			{
				return fieldInfo.ToContextualField();
			}
			throw new NotSupportedException("The member info must be a field or property.");
		}
	}
}
