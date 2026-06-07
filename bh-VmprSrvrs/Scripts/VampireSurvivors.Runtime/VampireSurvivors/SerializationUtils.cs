using System;
using System.Collections.Generic;
using System.IO;
using VampireSurvivors.App.Data;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Framework;

namespace VampireSurvivors
{
	public static class SerializationUtils
	{
		public static byte[] SerializeEnum<T>(List<T> enumList) where T : Enum
		{
			return null;
		}

		public static List<T> DeserializeEnum<T>(byte[] buffer) where T : Enum
		{
			return null;
		}

		public static byte[] SerializeLimitBreaks(List<WeightedLimitBreak> limitBreaks)
		{
			return null;
		}

		public static List<WeightedLimitBreak> DeserializeLimitBreaks(byte[] buffer)
		{
			return null;
		}

		public static byte[] SerializePowerUps(List<PowerUpLevel> powerUps)
		{
			return null;
		}

		public static List<PowerUpLevel> DeserializePowerUps(byte[] buffer)
		{
			return null;
		}

		public static byte[] SerializeTreasurePrizePairs(List<TreasurePrizeTypePair> prizePairs)
		{
			return null;
		}

		public static List<TreasurePrizeTypePair> DeserializeTreasurePrizePairs(byte[] buffer)
		{
			return null;
		}

		public static byte[] SerializePickupCount(Dictionary<ItemType, int> pickupCount)
		{
			return null;
		}

		public static Dictionary<ItemType, int> DeserializePickupCount(byte[] buffer)
		{
			return null;
		}

		public static byte[] SerializeSelectedSkins(Dictionary<CharacterType, SkinType> selectedSkins)
		{
			return null;
		}

		public static Dictionary<CharacterType, SkinType> DeserializeSelectedSkins(byte[] buffer)
		{
			return null;
		}

		public static byte[] SerializeAscensionData(Dictionary<PowerUpType, int> ascensionData)
		{
			return null;
		}

		public static Dictionary<PowerUpType, int> DeserializeAscensionData(byte[] buffer)
		{
			return null;
		}

		public static List<byte[]> SerializeUnlockedSkins(Dictionary<CharacterType, List<SkinType>> unlockedSkins)
		{
			return null;
		}

		public static Dictionary<CharacterType, List<SkinType>> DeserializeUnlockedSkins(List<byte[]> chunks)
		{
			return null;
		}

		public static byte[] SerializeCustomMerchantData(CustomMerchantData adventureMerchantData)
		{
			return null;
		}

		public static CustomMerchantData DeserializeCustomMerchantData(byte[] buffer)
		{
			return null;
		}

		private static byte GetStringLength(string s)
		{
			return 0;
		}

		private static int GetSizeForSerializationType(SerializationType serializationType)
		{
			return 0;
		}

		private static void WriteEnumValue<T>(SerializationType serializationType, BinaryWriter bw, T value) where T : Enum
		{
		}

		private static T ReadEnumValue<T>(SerializationType serializationType, BinaryReader br) where T : Enum
		{
			return default(T);
		}

		public static List<byte[]> SplitByteArray(byte[] buffer)
		{
			return null;
		}

		public static byte[] JoinByteArrays(List<byte[]> chunks)
		{
			return null;
		}
	}
}
