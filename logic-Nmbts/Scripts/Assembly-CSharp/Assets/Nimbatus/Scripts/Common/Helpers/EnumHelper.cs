using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Components;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public static class EnumHelper
	{
		public static T GetRandomEnumValue<T>(System.Random randomGenerator, int minValue = 0, int maxValue = -1)
		{
			Array values = Enum.GetValues(typeof(T));
			if (maxValue < minValue)
			{
				maxValue = values.Length;
			}
			return (T)values.GetValue(randomGenerator.Next(minValue, maxValue));
		}

		public static IEnumerable<T> GetValues<T>()
		{
			return Enum.GetValues(typeof(T)).Cast<T>();
		}

		public static bool Contains(this LayerMask mask, int layer)
		{
			return (int)mask == ((int)mask | (1 << layer));
		}

		public static bool Contains(this Enum keys, Enum flag)
		{
			uint num = Convert.ToUInt32(keys);
			uint num2 = Convert.ToUInt32(flag);
			if (num2 == 0)
			{
				return num == num2;
			}
			return (num & num2) == num2;
		}

		public static EResourceType ConvertEnum(ETerrainMaterial material)
		{
			switch (material)
			{
			case ETerrainMaterial.CommonOre:
				return EResourceType.CommonOre;
			case ETerrainMaterial.RareOre:
				return EResourceType.RareOre;
			default:
				return EResourceType.None;
			}
		}

		public static ETerrainMaterial ConvertEnum(EResourceType material)
		{
			switch (material)
			{
			case EResourceType.CommonOre:
				return ETerrainMaterial.CommonOre;
			case EResourceType.RareOre:
				return ETerrainMaterial.RareOre;
			default:
				return ETerrainMaterial.None;
			}
		}

		public static string ToLocalizationString(this Enum enumValue)
		{
			string translation = LocalizationManager.GetTranslation(enumValue.GetType().Name + "/" + enumValue);
			if (string.IsNullOrEmpty(translation))
			{
				return enumValue.ToString();
			}
			return translation;
		}

		public static object SetFlag(this Enum value, Enum flag, bool set)
		{
			Enum.GetUnderlyingType(value.GetType());
			int num = Convert.ToInt32(value);
			int num2 = Convert.ToInt32(flag);
			num = ((!set) ? (num & ~num2) : (num | num2));
			return num;
		}

		public static IEnumerable<Enum> GetUniqueFlags(this Enum flags)
		{
			ulong flag = 1uL;
			foreach (Enum item in Enum.GetValues(flags.GetType()).Cast<Enum>())
			{
				ulong num = Convert.ToUInt64(item);
				while (flag < num)
				{
					flag <<= 1;
				}
				if (flag == num && flags.HasFlag(item))
				{
					yield return item;
				}
			}
		}

		public static float GetAngle(ERotation rotation)
		{
			return (float)rotation * -45f;
		}

		public static int Popcount(int value)
		{
			value -= (value >> 1) & 0x55555555;
			value = (value & 0x33333333) + ((value >> 2) & 0x33333333);
			return ((value + (value >> 4)) & 0xF0F0F0F) * 16843009 >> 24;
		}

		public static int Popcount(ulong value)
		{
			value -= (value >> 1) & 0x5555555555555555L;
			value = (value & 0x3333333333333333L) + ((value >> 2) & 0x3333333333333333L);
			value = (value + (value >> 4)) & 0xF0F0F0F0F0F0F0FL;
			return (int)(value * 72340172838076673L >> 56);
		}
	}
}
