using System;
using System.Collections.Generic;
using System.Reflection;
using ThirdParty.RuntimeBackports;

namespace Amazon.Runtime
{
	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)]
	[ConstantClassComparer(ConstantClassComparerKind.OrdinalIgnoreCase)]
	public class ConstantClass
	{
		private static readonly object staticFieldsLock = new object();

		private static Dictionary<Type, Dictionary<string, ConstantClass>> staticFields = new Dictionary<Type, Dictionary<string, ConstantClass>>();

		public string Value { get; private set; }

		protected ConstantClass(string value)
		{
			Value = value;
		}

		public override string ToString()
		{
			return Intern().Value;
		}

		public string ToString(IFormatProvider provider)
		{
			return Intern().Value;
		}

		public static implicit operator string(ConstantClass value)
		{
			if (value == null)
			{
				return null;
			}
			return value.Intern().Value;
		}

		internal ConstantClass Intern()
		{
			if (!staticFields.ContainsKey(GetType()))
			{
				LoadFields(GetType());
			}
			if (!staticFields[GetType()].TryGetValue(Value, out var value))
			{
				return this;
			}
			return value;
		}

		protected static T FindValue<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicFields)] T>(string value) where T : ConstantClass
		{
			if (value == null)
			{
				return null;
			}
			if (!staticFields.ContainsKey(typeof(T)))
			{
				LoadFields(typeof(T));
			}
			if (!staticFields[typeof(T)].TryGetValue(value, out var value2))
			{
				return typeof(T).GetConstructor(new Type[1] { typeof(string) }).Invoke(new object[1] { value }) as T;
			}
			return value2 as T;
		}

		private static void LoadFields([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] Type type)
		{
			if (staticFields.ContainsKey(type))
			{
				return;
			}
			lock (staticFieldsLock)
			{
				if (staticFields.ContainsKey(type))
				{
					return;
				}
				StringComparer comparer = StringComparer.OrdinalIgnoreCase;
				ConstantClassComparerAttribute customAttribute = type.GetCustomAttribute<ConstantClassComparerAttribute>();
				if (customAttribute != null)
				{
					comparer = GetStringComparerFromKind(customAttribute.ComparerKind);
				}
				Dictionary<string, ConstantClass> dictionary = new Dictionary<string, ConstantClass>(comparer);
				FieldInfo[] fields = type.GetFields();
				foreach (FieldInfo fieldInfo in fields)
				{
					if (fieldInfo.IsStatic && fieldInfo.FieldType == type)
					{
						ConstantClass constantClass = fieldInfo.GetValue(null) as ConstantClass;
						dictionary[constantClass.Value] = constantClass;
					}
				}
				staticFields = new Dictionary<Type, Dictionary<string, ConstantClass>>(staticFields) { [type] = dictionary };
			}
		}

		private static StringComparer GetStringComparerFromKind(ConstantClassComparerKind comparerKind)
		{
			return comparerKind switch
			{
				ConstantClassComparerKind.Ordinal => StringComparer.Ordinal, 
				ConstantClassComparerKind.OrdinalIgnoreCase => StringComparer.OrdinalIgnoreCase, 
				_ => StringComparer.OrdinalIgnoreCase, 
			};
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			ConstantClass obj2 = obj as ConstantClass;
			if (Equals(obj2))
			{
				return true;
			}
			if (obj is string value)
			{
				return Equals(value);
			}
			return false;
		}

		public virtual bool Equals(ConstantClass obj)
		{
			if ((object)obj == null)
			{
				return false;
			}
			return StringComparer.OrdinalIgnoreCase.Equals(Value, obj.Value);
		}

		protected virtual bool Equals(string value)
		{
			return StringComparer.OrdinalIgnoreCase.Equals(Value, value);
		}

		public static bool operator ==(ConstantClass a, ConstantClass b)
		{
			if ((object)a == b)
			{
				return true;
			}
			return a?.Equals(b) ?? false;
		}

		public static bool operator !=(ConstantClass a, ConstantClass b)
		{
			return !(a == b);
		}

		public static bool operator ==(ConstantClass a, string b)
		{
			if ((object)a == null && b == null)
			{
				return true;
			}
			return a?.Equals(b) ?? false;
		}

		public static bool operator ==(string a, ConstantClass b)
		{
			return b == a;
		}

		public static bool operator !=(ConstantClass a, string b)
		{
			return !(a == b);
		}

		public static bool operator !=(string a, ConstantClass b)
		{
			return !(a == b);
		}
	}
}
