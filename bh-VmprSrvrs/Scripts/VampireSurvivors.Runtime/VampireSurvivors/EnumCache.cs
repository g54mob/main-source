using System;
using System.Collections.Generic;

namespace VampireSurvivors
{
	public static class EnumCache
	{
		private static Dictionary<Type, SerializationType> enumSerializationTypeCache;

		public static SerializationType GetSerializationTypeForEnum(Type enumType)
		{
			return default(SerializationType);
		}
	}
}
