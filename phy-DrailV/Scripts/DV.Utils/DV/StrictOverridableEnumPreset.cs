using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DV
{
	public class StrictOverridableEnumPreset<T, E> : OverridableEnumPreset<T, E> where T : class where E : Enum
	{
		protected override bool AllowIncompleteEnum => false;

		protected StrictOverridableEnumPreset()
		{
		}

		public StrictOverridableEnumPreset(T sourceObject)
			: base(sourceObject)
		{
		}

		public StrictOverridableEnumPreset(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public override object Clone()
		{
			return new StrictOverridableEnumPreset<T, E>
			{
				overriddenValues = new Dictionary<string, object>(overriddenValues)
			};
		}
	}
}
