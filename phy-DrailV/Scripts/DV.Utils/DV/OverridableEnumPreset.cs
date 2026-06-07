using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DV
{
	public class OverridableEnumPreset<T, E> : BaseOverridablePreset<T> where T : class where E : Enum
	{
		private static HashSet<KeyValuePair<Type, Type>> validatedTypesComplete = new HashSet<KeyValuePair<Type, Type>>();

		private static HashSet<KeyValuePair<Type, Type>> validatedTypesIncomplete = new HashSet<KeyValuePair<Type, Type>>();

		protected virtual bool AllowIncompleteEnum => true;

		protected OverridableEnumPreset()
		{
			CheckValidation(AllowIncompleteEnum);
		}

		public OverridableEnumPreset(T sourceObject)
			: base(sourceObject)
		{
			CheckValidation(AllowIncompleteEnum);
		}

		public OverridableEnumPreset(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			CheckValidation(AllowIncompleteEnum);
		}

		protected void CheckValidation(bool allowIncompleteEnum)
		{
			HashSet<KeyValuePair<Type, Type>> hashSet = (allowIncompleteEnum ? validatedTypesIncomplete : validatedTypesComplete);
			KeyValuePair<Type, Type> item = new KeyValuePair<Type, Type>(typeof(T), typeof(E));
			if (!hashSet.Contains(item))
			{
				ValidateEnum(myProperties, allowIncompleteEnum);
				hashSet.Add(item);
			}
		}

		public static void Validate(bool allowIncompleteEnum)
		{
			HashSet<KeyValuePair<Type, Type>> hashSet = (allowIncompleteEnum ? validatedTypesIncomplete : validatedTypesComplete);
			KeyValuePair<Type, Type> item = new KeyValuePair<Type, Type>(typeof(T), typeof(E));
			if (!hashSet.Contains(item))
			{
				ValidateEnum(BaseOverridablePreset<T>.GetPropertiesInfo(typeof(T)), allowIncompleteEnum);
				hashSet.Add(item);
			}
		}

		private static void ValidateEnum(Dictionary<string, TrackedProperty> properties, bool allowIncomplete)
		{
			HashSet<string> enumValues = new HashSet<string>(new List<E>((E[])Enum.GetValues(typeof(E))).Select((E e) => e.ToString()));
			HashSet<string> props = new HashSet<string>(properties.Keys);
			if (allowIncomplete)
			{
				if (!enumValues.IsSubsetOf(props))
				{
					IEnumerable<string> values = enumValues.Where((string f) => !props.Contains(f));
					throw new ArgumentException(string.Format("Enum {0} values must be a subset of the properties, but it has values that don't have corresponding properties in {1}: {2}", typeof(E), typeof(T), string.Join(", ", values)));
				}
			}
			else if (!enumValues.SetEquals(props))
			{
				IEnumerable<string> values2 = enumValues.Where((string f) => !props.Contains(f));
				IEnumerable<string> values3 = props.Where((string f) => !enumValues.Contains(f));
				throw new ArgumentException($"The enum values of {typeof(E)} and the overridable properties of {typeof(T)} must match exactly, but there are differences.\n" + "Enum values that aren't properties in the class: " + string.Join(", ", values2) + "\nProperties in the class that don't have enum values: " + string.Join(", ", values3));
			}
		}

		public void SetOverride<V>(E propName, V value)
		{
			InternalSetOverride(propName.ToString(), value);
		}

		public void ClearOverride(E propName)
		{
			InternalClearOverride(propName.ToString());
		}

		public bool IsOverridden(E propName)
		{
			return InternalIsOverridden(propName.ToString());
		}

		public Type GetOverrideType(E propName)
		{
			return InternalGetOverrideType(propName.ToString());
		}

		public override object Clone()
		{
			return new OverridableEnumPreset<T, E>
			{
				overriddenValues = new Dictionary<string, object>(overriddenValues)
			};
		}

		public static V GetCurrentValueFrom<V>(T sourceObject, E propName)
		{
			return BaseOverridablePreset<T>.GetCurrentValueFrom<V>(sourceObject, propName.ToString());
		}

		public static bool IsOverriddenIn(T sourceObject, E propName)
		{
			return BaseOverridablePreset<T>.IsOverriddenIn(sourceObject, propName.ToString());
		}

		public static void EngageOverrideOn<V>(T sourceObject, E propName, V value)
		{
			BaseOverridablePreset<T>.EngageOverrideOn(sourceObject, propName.ToString(), value);
		}

		public static void ClearOverrideOn(T source, E propName)
		{
			BaseOverridablePreset<T>.ClearOverrideOn(source, propName.ToString());
		}
	}
}
