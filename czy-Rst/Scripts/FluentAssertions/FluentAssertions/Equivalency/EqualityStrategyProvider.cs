using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency
{
	internal sealed class EqualityStrategyProvider
	{
		private readonly List<Type> referenceTypes = new List<Type>();

		private readonly List<Type> valueTypes = new List<Type>();

		private readonly ConcurrentDictionary<Type, EqualityStrategy> typeCache = new ConcurrentDictionary<Type, EqualityStrategy>();

		private readonly Func<Type, EqualityStrategy> defaultStrategy;

		private bool? compareRecordsByValue;

		public bool? CompareRecordsByValue
		{
			get
			{
				return compareRecordsByValue;
			}
			set
			{
				compareRecordsByValue = value;
				typeCache.Clear();
			}
		}

		public EqualityStrategyProvider()
		{
		}

		public EqualityStrategyProvider(Func<Type, EqualityStrategy> defaultStrategy)
		{
			this.defaultStrategy = defaultStrategy;
		}

		public EqualityStrategy GetEqualityStrategy(Type type)
		{
			return typeCache.GetOrAdd(type, delegate(Type typeKey)
			{
				if (!typeKey.IsPrimitive && referenceTypes.Count > 0 && referenceTypes.Exists((Type t) => typeKey.IsSameOrInherits(t)))
				{
					return EqualityStrategy.ForceMembers;
				}
				if (valueTypes.Count > 0 && valueTypes.Exists((Type t) => typeKey.IsSameOrInherits(t)))
				{
					return EqualityStrategy.ForceEquals;
				}
				if (!typeKey.IsPrimitive && referenceTypes.Count > 0 && referenceTypes.Exists((Type t) => typeKey.IsAssignableToOpenGeneric(t)))
				{
					return EqualityStrategy.ForceMembers;
				}
				if (valueTypes.Count > 0 && valueTypes.Exists((Type t) => typeKey.IsAssignableToOpenGeneric(t)))
				{
					return EqualityStrategy.ForceEquals;
				}
				if ((compareRecordsByValue.HasValue || defaultStrategy == null) && typeKey.IsRecord())
				{
					if ((!compareRecordsByValue) ?? true)
					{
						return EqualityStrategy.ForceMembers;
					}
					return EqualityStrategy.ForceEquals;
				}
				if (defaultStrategy != null)
				{
					return defaultStrategy(typeKey);
				}
				return (!typeKey.HasValueSemantics()) ? EqualityStrategy.Members : EqualityStrategy.Equals;
			});
		}

		public bool AddReferenceType(Type type)
		{
			if (valueTypes.Exists((Type t) => type.IsSameOrInherits(t)))
			{
				return false;
			}
			referenceTypes.Add(type);
			typeCache.Clear();
			return true;
		}

		public bool AddValueType(Type type)
		{
			if (referenceTypes.Exists((Type t) => type.IsSameOrInherits(t)))
			{
				return false;
			}
			valueTypes.Add(type);
			typeCache.Clear();
			return true;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (compareRecordsByValue ?? false)
			{
				stringBuilder.AppendLine("- Compare records by value");
			}
			else
			{
				stringBuilder.AppendLine("- Compare records by their members");
			}
			foreach (Type valueType in valueTypes)
			{
				stringBuilder.AppendLine(CultureInfo.InvariantCulture, $"- Compare {valueType} by value");
			}
			foreach (Type referenceType in referenceTypes)
			{
				stringBuilder.AppendLine(CultureInfo.InvariantCulture, $"- Compare {referenceType} by its members");
			}
			return stringBuilder.ToString();
		}
	}
}
