using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Saves;

public static class SaveUtils
{
	private static Dictionary<string, MethodInfo> _cachedParsers;

	private static Dictionary<string, MethodInfo> _cachedSerializers;

	public const string ADVENTURE_PROPERTY_PREFIX = "ADV_";

	public const string SaveDataFolderName = "Vampire_Survivors_Standalone";

	public static Func<string> SaveFileNameSuffix;

	public const string SaveDataFolderDisplayName = "Vampire Survivors Data";

	public const string DLCSelectionFileName = "DLCSelection";

	public static Dictionary<string, MethodInfo> Serializers => _cachedSerializers;

	public static string GetSaveFileName()
	{
		//IL_003f: Expected O, but got I
		//IL_004f: Expected O, but got I
		Func<string> saveFileNameSuffix = SaveFileNameSuffix;
		string text = default(string);
		if (SaveFileNameSuffix != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ rcx_v3 (System.Func`1<System.String>)+18] (should have been resolved before IL gen)");
			if (text != null)
			{
				goto IL_0061;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v8+B8]");
		object obj2 = 0;
		text = (string)obj2;
		goto IL_0061;
		IL_0061:
		return "SaveData" + text;
	}

	public static MethodInfo GetParser(string property)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		object obj4 = default(object);
		if (!((Dictionary<object, object>)(object)_cachedParsers).TryGetValue((object)property, out object _))
		{
			SaveParser saveParser = new SaveParser();
			object obj = saveParser + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			if (property == null)
			{
				ArgumentNullException ex = new ArgumentNullException("name");
				ex._002Ector("name");
				throw ex;
			}
			object obj3 = default(object);
			object obj2 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v295 @ rcx_v16+788] (should have been resolved before IL gen)");
			if (obj4 == null)
			{
				string message = "[SaveParser] -> Could not find parser for: " + property + ". Please add it to DefaultSaveData, SaveParser and SaveSerializer";
				Debug.LogWarning(message);
				return null;
			}
			bool flag = ((Dictionary<object, object>)(object)_cachedParsers).TryInsert((object)property, obj4, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			MethodInfo serializer = GetSerializer(property);
		}
		return (MethodInfo)obj4;
	}

	public static MethodInfo GetSerializer(string property)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		object obj4 = default(object);
		if (!((Dictionary<object, object>)(object)_cachedSerializers).TryGetValue((object)property, out object _))
		{
			SaveSerializer saveSerializer = new SaveSerializer();
			object obj = saveSerializer + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			if (property == null)
			{
				ArgumentNullException ex = new ArgumentNullException("name");
				ex._002Ector("name");
				throw ex;
			}
			object obj3 = default(object);
			object obj2 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v295 @ rcx_v17+788] (should have been resolved before IL gen)");
			if (obj4 == null)
			{
				string message = "[SaveSerializer] -> Could not find serializer for: " + property + ". Please add it to DefaultSaveData, SaveParser and SaveSerializer";
				Debug.LogWarning(message);
				return null;
			}
			bool flag = ((Dictionary<object, object>)(object)_cachedSerializers).TryInsert((object)property, obj4, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		return (MethodInfo)obj4;
	}

	public static void PreCacheParsersAndSerializers()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		string[] properties = DefaultSaveData.properties;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < properties.Length)
		{
			MethodInfo parser = GetParser(properties[obj]);
			obj++;
			obj2 = obj;
		}
	}

	private static bool CheckExists(string[] segments)
	{
		//IL_000e: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_00f8: Expected I4, but got O
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		object obj = 0;
		string path = "";
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < segments.Length)
			{
				if ((nint)obj >= segments.Length)
				{
					break;
				}
				string text = Path.Combine(path, segments[obj]);
				if (Directory.Exists(text) || File.Exists(text))
				{
					obj++;
					path = text;
					obj2 = obj;
					continue;
				}
				return false;
			}
			return true;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	private static string BuildPath(string[] segments)
	{
		//IL_0017: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		string text = "";
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < segments.Length)
			{
				if ((nint)obj >= segments.Length)
				{
					break;
				}
				string text2 = Path.Combine(text, segments[obj]);
				obj++;
				text = text2;
				obj2 = obj;
				continue;
			}
			return text;
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	private static string InitPath(string[] segments)
	{
		//IL_000e: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		object obj = 0;
		string text = "";
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < segments.Length)
			{
				if ((nint)obj >= segments.Length)
				{
					break;
				}
				string text2 = Path.Combine(text, segments[obj]);
				if (!Directory.Exists(text2) && !File.Exists(text2))
				{
					DirectoryInfo directoryInfo = Directory.CreateDirectory(text2);
				}
				obj++;
				text = text2;
				obj2 = obj;
				continue;
			}
			return text;
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	public static string GetSaveFolderPath(string basePath)
	{
		string[] array = new string[2];
		if (array != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			return BuildPath(array);
		}
		return (string)(object)new NullReferenceException();
	}

	public static string GetSaveFilePath(string basePath)
	{
		string[] array = new string[3];
		if (array != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string saveFileName = GetSaveFileName();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			return BuildPath(array);
		}
		return (string)(object)new NullReferenceException();
	}

	public static bool SaveExists(string basePath)
	{
		//IL_0122: Expected O, but got I4
		//IL_0135: Expected I4, but got O
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		string[] array = new string[3];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string saveFileName = GetSaveFileName();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string path = "";
		object obj = 0;
		while (true)
		{
			if ((nint)obj < array.Length)
			{
				if ((nint)obj >= array.Length)
				{
					break;
				}
				string text = Path.Combine(path, array[obj]);
				if (Directory.Exists(text) || File.Exists(text))
				{
					obj++;
					path = text;
					continue;
				}
				return false;
			}
			return true;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	public static void InitSavePath(string basePath)
	{
		//IL_00d5: Expected O, but got I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		string[] array = new string[2];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string path = "";
		object obj = 0;
		while ((nint)obj < array.Length)
		{
			string text = Path.Combine(path, array[obj]);
			if (!Directory.Exists(text) && !File.Exists(text))
			{
				DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			}
			obj++;
			path = text;
		}
	}

	public unsafe static bool ChecksumIsValid(string rawData, string checksum)
	{
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected Ref, but got Unknown
		//IL_0117: Expected I8, but got I4
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Ref, but got Unknown
		string data = Regex.Replace(rawData, "\"checksum\":\"[a-z0-9]*\"", "\"checksum\":\"\"");
		string text = GenerateChecksum(data);
		string message = "RawDataChecksum: " + text;
		Debug.Log(message);
		string message2 = "Checksum: " + checksum;
		Debug.Log(message2);
		if ((object)text != checksum)
		{
			if (text != null && checksum != null && text._stringLength == checksum._stringLength)
			{
				ref byte second = ref *(byte*)(checksum + 20);
				ulong length = (ulong)(text._stringLength + text._stringLength);
				return System.SpanHelpers.SequenceEqual(ref *(byte*)(text + 20), ref second, length);
			}
			return false;
		}
		return true;
	}

	public static string GenerateChecksum(string data)
	{
		return ComputeHash("DefinitelyNotSaveDataSecretKey", data);
	}

	public static string UpdateChecksum(string rawData)
	{
		string data = Regex.Replace(rawData, "\"checksum\":\"[a-z0-9]*\"", "\"checksum\":\"\"");
		string text = GenerateChecksum(data);
		string replacement = "\"checksum\":\"" + text + "\"";
		return Regex.Replace(rawData, "\"checksum\":\"[a-z0-9]*\"", replacement);
	}

	private unsafe static string ComputeHash(string secretKey, string data)
	{
		//IL_0219: Expected O, but got Ref
		//IL_00f3: Expected O, but got I4
		//IL_0105: Expected O, but got I4
		//IL_013a: Expected O, but got Ref
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_0159: Expected O, but got Ref
		//IL_0162: Expected I4, but got O
		SHA256Managed sHA256Managed = new SHA256Managed();
		HashAlgorithm hashAlgorithm = default(HashAlgorithm);
		object obj = (object)(&hashAlgorithm);
		Encoding uTF = Encoding.UTF8;
		if (uTF != null)
		{
			byte[] bytes = uTF.GetBytes(data);
			if (hashAlgorithm != null)
			{
				if (!hashAlgorithm._disposed)
				{
					if (bytes != null)
					{
						hashAlgorithm.HashCore(bytes, 0, bytes.Length);
						byte[] array = hashAlgorithm.CaptureHashCodeAndReinitialize();
						int capacity = default(int);
						StringBuilder stringBuilder = new StringBuilder(capacity, 2147483647);
						capacity = array.Length + array.Length;
						System.ParamsArray paramsArray = (System.ParamsArray)0;
						int num = 2147483647;
						object obj2 = 0;
						object arg = default(object);
						System.ParamsArray paramsArray3 = default(System.ParamsArray);
						while ((nint)obj2 < array.Length)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							System.ParamsArray paramsArray2 = new System.ParamsArray(arg);
							StringBuilder stringBuilder2 = stringBuilder.AppendFormatHelper((IFormatProvider)null, "{0:x2}", (System.ParamsArray)(&paramsArray3));
							obj2++;
							paramsArray = (System.ParamsArray)(&paramsArray3);
							num = (int)"{0:x2}";
						}
						string result = stringBuilder.ToString();
						if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						return result;
					}
					ArgumentNullException ex = new ArgumentNullException("buffer");
					throw ex;
				}
				ObjectDisposedException ex2 = new ObjectDisposedException(null);
				throw ex2;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	private unsafe static string ByteArrayToString(byte[] ba)
	{
		//IL_0037: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0052: Expected O, but got I4
		//IL_0118: Expected I, but got O
		//IL_0128: Expected O, but got I
		//IL_0138: Expected O, but got I
		//IL_00a7: Expected O, but got Ref
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00c7: Expected O, but got I4
		//IL_00d0: Expected O, but got I4
		//IL_00d9: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		//IL_00f2: Expected O, but got I
		//IL_00fb: Expected I4, but got O
		//IL_0103: Expected O, but got Ref
		int capacity = default(int);
		StringBuilder stringBuilder = new StringBuilder(capacity, 2147483647);
		capacity = ba.Length + ba.Length;
		object obj = 0;
		int num = 2147483647;
		System.ParamsArray paramsArray = (System.ParamsArray)0;
		object obj2 = 0;
		object arg = default(object);
		System.ParamsArray paramsArray3 = default(System.ParamsArray);
		while (true)
		{
			if ((nint)obj2 < ba.Length)
			{
				if ((nint)obj >= ba.Length)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				System.ParamsArray paramsArray2 = new System.ParamsArray(arg);
				StringBuilder stringBuilder2 = stringBuilder.AppendFormatHelper((IFormatProvider)null, "{0:x2}", (System.ParamsArray)(&paramsArray3));
				obj++;
				paramsArray3 = (System.ParamsArray)0;
				System.ParamsArray paramsArray4 = (System.ParamsArray)0;
				paramsArray2 = (System.ParamsArray)0;
				System.ParamsArray paramsArray5 = (System.ParamsArray)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rsi_v4+20+ba @ rcx (System.Byte[])]");
				object obj3 = 0;
				num = (int)"{0:x2}";
				paramsArray = (System.ParamsArray)(&paramsArray3);
				obj2 = obj;
				continue;
			}
			nint num2 = (nint)stringBuilder;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rdx_v6 (Il2CppClass<System.Text.StringBuilder>)+168]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rdx_v6 (Il2CppClass<System.Text.StringBuilder>)+170]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v233 @ rax_v10 (should have been resolved before IL gen)");
			break;
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	public static byte[] JsonToBytes(string data)
	{
		//IL_002e: Expected I, but got O
		//IL_003e: Expected O, but got I
		//IL_004e: Expected O, but got I
		Encoding uTF = Encoding.UTF8;
		if (uTF != null)
		{
			nint num = (nint)uTF;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ r8_v1 (Il2CppClass<System.Text.Encoding>)+268]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ r8_v1 (Il2CppClass<System.Text.Encoding>)+270]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v19 @ r9_v1 (should have been resolved before IL gen)");
		}
		return (byte[])(object)new NullReferenceException();
	}

	public static string JsonFromBytes(byte[] data)
	{
		//IL_002e: Expected I, but got O
		//IL_003e: Expected O, but got I
		//IL_004e: Expected O, but got I
		Encoding uTF = Encoding.UTF8;
		if (uTF != null)
		{
			nint num = (nint)uTF;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ r8_v1 (Il2CppClass<System.Text.Encoding>)+368]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ r8_v1 (Il2CppClass<System.Text.Encoding>)+370]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v19 @ r9_v1 (should have been resolved before IL gen)");
		}
		return (string)(object)new NullReferenceException();
	}

	public unsafe static bool AreIdentical(PlayerOptionsData saveA, PlayerOptionsData saveB)
	{
		//IL_0158: Expected I4, but got O
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected Ref, but got Unknown
		//IL_0111: Expected I8, but got I4
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected Ref, but got Unknown
		if (saveA != null && saveB != null)
		{
			string text = saveA._003Cchecksum_003Ek__BackingField;
			string text2 = saveB._003Cchecksum_003Ek__BackingField;
			if ((object)saveA._003Cchecksum_003Ek__BackingField != saveB._003Cchecksum_003Ek__BackingField)
			{
				if (saveA._003Cchecksum_003Ek__BackingField != null && saveB._003Cchecksum_003Ek__BackingField != null && text._stringLength == text2._stringLength)
				{
					ref byte second = ref *(byte*)(saveB._003Cchecksum_003Ek__BackingField + 20);
					ulong length = (ulong)(text._stringLength + text._stringLength);
					return System.SpanHelpers.SequenceEqual(ref *(byte*)(saveA._003Cchecksum_003Ek__BackingField + 20), ref second, length);
				}
				return false;
			}
			return true;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static PlayerOptionsData TryParseData(byte[] data)
	{
		Encoding uTF = Encoding.UTF8;
		if (uTF != null)
		{
			string text = uTF.GetString(data);
			SaveParser saveParser = new SaveParser();
			PlayerOptionsData playerOptionsData = saveParser.ParsePod(text);
			bool flag = ChecksumIsValid(text, playerOptionsData._003Cchecksum_003Ek__BackingField);
			bool flag2 = !flag;
			PlayerOptionsData result = null;
			if (!flag2)
			{
				result = playerOptionsData;
			}
			return result;
		}
		return (PlayerOptionsData)(object)new NullReferenceException();
	}

	public static SaveSummary GetSaveSummary(PlayerOptionsData pod, byte[] data)
	{
		SaveSummary saveSummary = new SaveSummary();
		int num = default(int);
		if (saveSummary != null)
		{
			saveSummary._003CPod_003Ek__BackingField = pod;
			saveSummary._003CData_003Ek__BackingField = data;
			if (pod != null)
			{
				saveSummary.Timestamp = pod._003CsaveDate_003Ek__BackingField;
				saveSummary._003C_selectedCharacter_003Ek__BackingField = pod._selectedChar;
				saveSummary._003C_selectedStage_003Ek__BackingField = pod._003CSelectedStage_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
				if (pod._003CCoins_003Ek__BackingField < 2.1474836E+09f && -2.1474836E+09f < pod._003CCoins_003Ek__BackingField)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
					if (num <= 9999999 && num >= 0)
					{
						goto IL_01bc;
					}
				}
				num = 9999999;
				goto IL_01bc;
			}
		}
		goto IL_0176;
		IL_0176:
		return (SaveSummary)(object)new NullReferenceException();
		IL_01bc:
		saveSummary._003C_totalGold_003Ek__BackingField = num;
		List<CharacterType> list = pod._003CUnlockedCharacters_003Ek__BackingField;
		if (pod._003CUnlockedCharacters_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			saveSummary._003C_unlockedCharacters_003Ek__BackingField = 0;
			List<AchievementType> list2 = pod._003CAchievements_003Ek__BackingField;
			if (pod._003CAchievements_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				saveSummary._003C_achievements_003Ek__BackingField = 0;
				return saveSummary;
			}
		}
		goto IL_0176;
	}

	public static SaveSummary GetSaveSummary(PlayerOptionsData pod)
	{
		SaveSummary saveSummary = new SaveSummary();
		if (pod == null || saveSummary == null)
		{
			goto IL_0164;
		}
		saveSummary.Timestamp = pod._003CsaveDate_003Ek__BackingField;
		saveSummary._003C_selectedCharacter_003Ek__BackingField = pod._selectedChar;
		saveSummary._003C_selectedStage_003Ek__BackingField = pod._003CSelectedStage_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		int num = default(int);
		if (pod._003CCoins_003Ek__BackingField < 2.1474836E+09f && -2.1474836E+09f < pod._003CCoins_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			if (num <= 9999999 && num >= 0)
			{
				goto IL_0198;
			}
		}
		num = 9999999;
		goto IL_0198;
		IL_0164:
		return (SaveSummary)(object)new NullReferenceException();
		IL_0198:
		saveSummary._003C_totalGold_003Ek__BackingField = num;
		List<CharacterType> list = pod._003CUnlockedCharacters_003Ek__BackingField;
		if (pod._003CUnlockedCharacters_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			saveSummary._003C_unlockedCharacters_003Ek__BackingField = 0;
			List<AchievementType> list2 = pod._003CAchievements_003Ek__BackingField;
			if (pod._003CAchievements_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
				saveSummary._003C_achievements_003Ek__BackingField = 0;
				return saveSummary;
			}
		}
		goto IL_0164;
	}

	public static byte[] GetSerializedPlayerData(PlayerOptionsData data)
	{
		//IL_0045: Expected I, but got O
		//IL_0055: Expected O, but got I
		//IL_0065: Expected O, but got I
		string rawData = SaveSerializer.Serialize(data);
		string text = UpdateChecksum(rawData);
		Encoding uTF = Encoding.UTF8;
		if (uTF != null)
		{
			nint num = (nint)uTF;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v1 (Il2CppClass<System.Text.Encoding>)+268]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v1 (Il2CppClass<System.Text.Encoding>)+270]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v67 @ r9_v1 (should have been resolved before IL gen)");
		}
		return (byte[])(object)new NullReferenceException();
	}

	public static string GetSerializedPlayerDataAsString(PlayerOptionsData data)
	{
		//IL_0045: Expected I, but got O
		//IL_0055: Expected O, but got I
		//IL_0065: Expected O, but got I
		byte[] serializedPlayerData = GetSerializedPlayerData(data);
		Encoding uTF = Encoding.UTF8;
		if (uTF != null)
		{
			nint num = (nint)uTF;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v1 (Il2CppClass<System.Text.Encoding>)+368]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v1 (Il2CppClass<System.Text.Encoding>)+370]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v63 @ r9_v1 (should have been resolved before IL gen)");
		}
		return (string)(object)new NullReferenceException();
	}

	static SaveUtils()
	{
		Dictionary<string, MethodInfo> cachedParsers = new Dictionary<string, MethodInfo>();
		_cachedParsers = cachedParsers;
		Dictionary<string, MethodInfo> cachedSerializers = new Dictionary<string, MethodInfo>();
		_cachedSerializers = cachedSerializers;
	}
}
