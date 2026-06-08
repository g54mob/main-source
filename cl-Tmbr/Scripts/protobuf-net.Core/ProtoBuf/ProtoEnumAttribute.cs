using System;
using ProtoBuf.Internal;

namespace ProtoBuf
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public sealed class ProtoEnumAttribute : Attribute
	{
		internal const string EnumValueDeprecated = "Enum value maps have been deprecated and are no longer supported; all enums are now effectively pass-thru; custom maps should be applied via shadow properties; in C#, lambda-based 'switch expressions' make for very convenient shadow properties";

		public int Value
		{
			[Obsolete("Enum value maps have been deprecated and are no longer supported; all enums are now effectively pass-thru; custom maps should be applied via shadow properties; in C#, lambda-based 'switch expressions' make for very convenient shadow properties", false)]
			get
			{
				return 0;
			}
			[Obsolete("Enum value maps have been deprecated and are no longer supported; all enums are now effectively pass-thru; custom maps should be applied via shadow properties; in C#, lambda-based 'switch expressions' make for very convenient shadow properties", true)]
			set
			{
				ThrowHelper.ThrowNotSupportedException();
			}
		}

		public string Name { get; set; }

		[Obsolete("Enum value maps have been deprecated and are no longer supported; all enums are now effectively pass-thru; custom maps should be applied via shadow properties; in C#, lambda-based 'switch expressions' make for very convenient shadow properties", false)]
		public bool HasValue()
		{
			return false;
		}
	}
}
