using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV
{
	public static class CommsRadioModesEnumExtensions
	{
		private static Dictionary<CommsRadioModesEnum, Type> enumToType;

		private static Dictionary<Type, CommsRadioModesEnum> typeToEnum;

		private static void CheckInit()
		{
			if (enumToType != null && typeToEnum != null)
			{
				return;
			}
			enumToType = new Dictionary<CommsRadioModesEnum, Type>();
			typeToEnum = new Dictionary<Type, CommsRadioModesEnum>();
			CommsRadioModesEnum[] array = (CommsRadioModesEnum[])Enum.GetValues(typeof(CommsRadioModesEnum));
			for (int i = 0; i < array.Length; i++)
			{
				CommsRadioModesEnum commsRadioModesEnum = array[i];
				Type type = Type.GetType("DV." + commsRadioModesEnum);
				if (type == null)
				{
					Debug.LogError(string.Concat("Type not found for CommsRadioModesEnum value ", commsRadioModesEnum, ", code is probably out of date."));
					continue;
				}
				enumToType[commsRadioModesEnum] = type;
				typeToEnum[type] = commsRadioModesEnum;
			}
		}

		public static Type ToType(this CommsRadioModesEnum value)
		{
			CheckInit();
			return enumToType[value];
		}

		public static CommsRadioModesEnum ToEnum(this ICommsRadioMode mode)
		{
			CheckInit();
			return typeToEnum[mode.GetType()];
		}
	}
}
