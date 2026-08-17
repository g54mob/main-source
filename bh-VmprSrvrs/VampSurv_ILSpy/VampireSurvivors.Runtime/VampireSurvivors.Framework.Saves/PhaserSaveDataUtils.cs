using System;
using System.IO;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Framework.Saves;

public class PhaserSaveDataUtils
{
	private const string ElectronDataFolderName = "Vampire_Survivors";

	private const string SaveDataFolderName = "Vampire_Survivors_Data";

	private const string SavesFolderName = "saves";

	private const string BackupsFolderName = "backups";

	private const string SaveFileName = "SaveData.sav";

	private const string SaveBackupFileName = "SaveDataBackup.sav";

	private const string LastRunBackupFileName = "LastRunBackup.sav";

	private const string LastRunBackupBakFileName = "LastRunBackup.bak.sav";

	private const string DeletedSaveFileName = "deleted_SaveData";

	private const bool IPCRENDERER = true;

	private static PlayerOptions _playerOptions;

	private void Construct(PlayerOptions playerOptions)
	{
		_playerOptions = playerOptions;
	}

	private static bool UsesLocalSaves()
	{
		return true;
	}

	private static bool CheckExists(string[] segments)
	{
		//IL_0016: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_0106: Expected I4, but got O
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7E2C0");
		string text = default(string);
		string path = text;
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
				string text2 = Path.Combine(path, segments[obj]);
				if (Directory.Exists(text2) || File.Exists(text2))
				{
					obj++;
					path = text2;
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
		//IL_0016: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7E2C0");
		string text2 = default(string);
		string text = text2;
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
				string text3 = Path.Combine(text, segments[obj]);
				obj++;
				text = text3;
				obj2 = obj;
				continue;
			}
			return text;
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	private static string InitPath(string[] segments)
	{
		//IL_0016: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7E2C0");
		string text2 = default(string);
		string text = text2;
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
				string text3 = Path.Combine(text, segments[obj]);
				if (!Directory.Exists(text3) && !File.Exists(text3))
				{
					DirectoryInfo directoryInfo = Directory.CreateDirectory(text3);
				}
				obj++;
				text = text3;
				obj2 = obj;
				continue;
			}
			return text;
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	private static string GetSaveDataPath()
	{
		string[] array = new string[1];
		if (array != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			return BuildPath(array);
		}
		return (string)(object)new NullReferenceException();
	}

	private static string GetSaveDataPathWithSave()
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

	private static string InitSaveDataPath()
	{
		//IL_00e7: Expected O, but got I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		string[] array = new string[1];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7E2C0");
		object obj = 0;
		string text2 = default(string);
		string text = text2;
		while (true)
		{
			if ((nint)obj < array.Length)
			{
				if ((nint)obj >= array.Length)
				{
					break;
				}
				string text3 = Path.Combine(text, array[obj]);
				if (!Directory.Exists(text3) && !File.Exists(text3))
				{
					DirectoryInfo directoryInfo = Directory.CreateDirectory(text3);
				}
				obj++;
				text = text3;
				continue;
			}
			return text;
		}
		return (string)(object)new IndexOutOfRangeException();
	}

	private static bool SaveDataHasSave()
	{
		//IL_003e: Expected I4, but got O
		string[] array = new string[2];
		if (array != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			return CheckExists(array);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private static bool SaveDataPathExists()
	{
		//IL_0034: Expected I4, but got O
		string[] array = new string[1];
		if (array != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			return CheckExists(array);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private static string GetElectronDataPath()
	{
		string[] array = new string[1];
		if (array != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			return BuildPath(array);
		}
		return (string)(object)new NullReferenceException();
	}

	private static string GetElectronDataSavesPath()
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

	private static bool ElectronDataHasSave()
	{
		//IL_004d: Expected I4, but got O
		string[] array = new string[3];
		if (array != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			return CheckExists(array);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private static string GetTempDataPath(string tempFolderName)
	{
		string[] array = new string[1];
		if (array != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			return BuildPath(array);
		}
		return (string)(object)new NullReferenceException();
	}

	private static string GetTempDataPathWithSavesFolder(string tempFolderName)
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

	private static string GetBackupsPath()
	{
		string saveDataPath = GetSaveDataPath();
		return Path.Combine(saveDataPath, "backups");
	}

	private static bool LastRunBackupExists()
	{
		return false;
	}

	private static string GetLastRunBackupPath()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2975]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return "";
	}

	private static string GetLastRunBackupBakPath()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2976]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return "";
	}

	private static string GetBaseDataPath()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7E2C0");
		string result = default(string);
		return result;
	}

	private static string[] GetTempFolders()
	{
		return Array.Empty<string>();
	}

	public static object[] GetLocalBackupsList()
	{
		return Array.Empty<object>();
	}

	public static void RestoreLocalBackup(string filename)
	{
		string saveDataPath = GetSaveDataPath();
		string text = Path.Combine(saveDataPath, "backups");
		string text3;
		string text4;
		if (Directory.Exists(text))
		{
			string text2 = Path.Combine(text, filename);
			if (File.Exists(text2))
			{
				string saveDataPathWithSave = GetSaveDataPathWithSave();
				if (File.Exists(saveDataPathWithSave))
				{
					string saveDataPath2 = GetSaveDataPath();
					string destFileName = Path.Combine(saveDataPath2, "deleted_SaveData");
					File.Move(saveDataPathWithSave, destFileName);
				}
				File.Copy(text2, saveDataPathWithSave, overwrite: true);
				return;
			}
			text3 = text2;
			text4 = "no file ";
		}
		else
		{
			text3 = text;
			text4 = "no dir ";
		}
		string message = text4 + text3;
		Debug.Log(message);
	}

	public static bool HasBackup()
	{
		return false;
	}

	public static void RestoreLastRunBackup(bool bypassReload = false)
	{
		Debug.Log("SaveData Backup not found");
	}

	private static bool HasNewSaveFiles()
	{
		return SaveDataHasSave();
	}

	public static PlayerOptionsData LoadSaveFiles()
	{
		if (!SaveDataHasSave())
		{
			return null;
		}
		string data;
		if (SaveDataHasSave())
		{
			string saveDataPathWithSave = GetSaveDataPathWithSave();
			string text = File.ReadAllText(saveDataPathWithSave);
			data = text;
		}
		else
		{
			Debug.Log("SaveData not found");
			data = null;
		}
		SaveParser saveParser = new SaveParser();
		if (saveParser != null)
		{
			return saveParser.ParsePod(data);
		}
		return (PlayerOptionsData)(object)new NullReferenceException();
	}

	private static bool MakeNewSaveFiles()
	{
		return false;
	}

	private static string LoadNewSaves()
	{
		if (SaveDataHasSave())
		{
			string saveDataPathWithSave = GetSaveDataPathWithSave();
			return File.ReadAllText(saveDataPathWithSave);
		}
		Debug.Log("SaveData not found");
		return null;
	}
}
