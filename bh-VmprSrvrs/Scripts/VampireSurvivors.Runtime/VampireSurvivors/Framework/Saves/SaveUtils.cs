using System;
using System.Collections.Generic;
using System.Reflection;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Saves
{
	public static class SaveUtils
	{
		private static Dictionary<string, MethodInfo> _cachedParsers;

		private static Dictionary<string, MethodInfo> _cachedSerializers;

		public const string ADVENTURE_PROPERTY_PREFIX = "ADV_";

		public const string SaveDataFolderName = "Vampire_Survivors_Standalone";

		public static Func<string> SaveFileNameSuffix;

		public const string SaveDataFolderDisplayName = "Vampire Survivors Data";

		public const string DLCSelectionFileName = "DLCSelection";

		public static Dictionary<string, MethodInfo> Serializers => null;

		public static string GetSaveFileName()
		{
			return null;
		}

		public static MethodInfo GetParser(string property)
		{
			return null;
		}

		public static MethodInfo GetSerializer(string property)
		{
			return null;
		}

		public static void PreCacheParsersAndSerializers()
		{
		}

		private static bool CheckExists(string[] segments)
		{
			return false;
		}

		private static string BuildPath(string[] segments)
		{
			return null;
		}

		private static string InitPath(string[] segments)
		{
			return null;
		}

		public static string GetSaveFolderPath(string basePath)
		{
			return null;
		}

		public static string GetSaveFilePath(string basePath)
		{
			return null;
		}

		public static bool SaveExists(string basePath)
		{
			return false;
		}

		public static void InitSavePath(string basePath)
		{
		}

		public static bool ChecksumIsValid(string rawData, string checksum)
		{
			return false;
		}

		public static string GenerateChecksum(string data)
		{
			return null;
		}

		public static string UpdateChecksum(string rawData)
		{
			return null;
		}

		private static string ComputeHash(string secretKey, string data)
		{
			return null;
		}

		private static string ByteArrayToString(byte[] ba)
		{
			return null;
		}

		public static byte[] JsonToBytes(string data)
		{
			return null;
		}

		public static string JsonFromBytes(byte[] data)
		{
			return null;
		}

		public static bool AreIdentical(PlayerOptionsData saveA, PlayerOptionsData saveB)
		{
			return false;
		}

		public static PlayerOptionsData TryParseData(byte[] data)
		{
			return null;
		}

		public static SaveSummary GetSaveSummary(PlayerOptionsData pod, byte[] data)
		{
			return null;
		}

		public static SaveSummary GetSaveSummary(PlayerOptionsData pod)
		{
			return null;
		}

		public static byte[] GetSerializedPlayerData(PlayerOptionsData data)
		{
			return null;
		}

		public static string GetSerializedPlayerDataAsString(PlayerOptionsData data)
		{
			return null;
		}
	}
}
