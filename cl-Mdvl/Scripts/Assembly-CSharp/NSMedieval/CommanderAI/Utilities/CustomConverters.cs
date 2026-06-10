using System;
using System.Collections.Generic;
using NSEipix;
using ParadoxNotion;
using UnityEngine;

namespace NSMedieval.CommanderAI.Utilities
{
	public static class CustomConverters
	{
		[RuntimeInitializeOnLoadMethod]
		private static void Init()
		{
			TypeConverter.customConverter -= OnConvert;
			TypeConverter.customConverter += OnConvert;
		}

		private static Func<object, object> OnConvert(Type sourceType, Type targetType)
		{
			if (sourceType == typeof(List<CommanderAIUnit>) && targetType == typeof(CommanderAIUnit))
			{
				return (object value) => (!(value is List<CommanderAIUnit>)) ? null : (value as List<CommanderAIUnit>).GetRandom();
			}
			return null;
		}
	}
}
