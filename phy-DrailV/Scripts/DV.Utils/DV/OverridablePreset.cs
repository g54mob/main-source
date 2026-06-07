using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DV
{
	[Serializable]
	public class OverridablePreset<T> : BaseOverridablePreset<T> where T : class
	{
		public OverridablePreset()
		{
		}

		public OverridablePreset(T sourceObject)
			: base(sourceObject)
		{
		}

		public OverridablePreset(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public void SetOverride<V>(string propName, V value)
		{
			InternalSetOverride(propName, value);
		}

		public void ClearOverride(string propName)
		{
			InternalClearOverride(propName);
		}

		public bool IsOverridden(string propName)
		{
			return InternalIsOverridden(propName);
		}

		public Type GetOverrideType(string propName)
		{
			return InternalGetOverrideType(propName);
		}

		public override object Clone()
		{
			return new OverridablePreset<T>
			{
				overriddenValues = new Dictionary<string, object>(overriddenValues)
			};
		}

		public new static V GetCurrentValueFrom<V>(T sourceObject, string propName)
		{
			return BaseOverridablePreset<T>.GetCurrentValueFrom<V>(sourceObject, propName);
		}

		public new static bool IsOverriddenIn(T sourceObject, string propName)
		{
			return BaseOverridablePreset<T>.IsOverriddenIn(sourceObject, propName);
		}

		public new static void EngageOverrideOn<V>(T sourceObject, string propName, V value)
		{
			BaseOverridablePreset<T>.EngageOverrideOn(sourceObject, propName, value);
		}

		public new static void ClearOverrideOn(T sourceObject, string propName)
		{
			BaseOverridablePreset<T>.ClearOverrideOn(sourceObject, propName);
		}
	}
}
