using System;
using System.Runtime.CompilerServices;

namespace ParadoxNotion
{
	public static class TypeConverter
	{
		public delegate Func<object, object> CustomConverter(Type fromType, Type toType);

		public static event CustomConverter customConverter
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static Func<object, object> Get(Type fromType, Type toType)
		{
			return null;
		}

		public static bool CanConvert(Type fromType, Type toType)
		{
			return false;
		}
	}
}
