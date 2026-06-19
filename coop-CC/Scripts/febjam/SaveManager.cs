using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Aggro.Core;
using DevCmdLine;
using Newtonsoft.Json;
using Unity.Mathematics;
using UnityEngine;

public static class SaveManager
{
	private static int _saveIndex = -1;

	public const int BUILD_SAVE_INDEX = 0;

	public const int EDITOR_SAVE_INDEX = int.MaxValue;

	public static SaveData data { get; private set; }

	public static bool isSaveLoading { get; private set; }

	public static int saveIndex => _saveIndex;

	public static bool isInitialized => data != null;

	[RuntimeInitializeOnLoadMethod]
	private static void Initialize()
	{
		data = null;
		isSaveLoading = false;
	}

	public static void InitializeNewGame(int saveIndex)
	{
		data = new SaveData();
		_saveIndex = saveIndex;
	}

	public static async Task InitializeLoadGameAsync(int saveIndex)
	{
		isSaveLoading = true;
		data = new SaveData();
		_saveIndex = saveIndex;
		try
		{
			_saveIndex = saveIndex;
			byte[] bytes = await Platform.LoadSaveAsync(GetFilePath(_saveIndex));
			data = JsonConvert.DeserializeObject<SaveData>(Encoding.UTF8.GetString(bytes));
		}
		finally
		{
			isSaveLoading = false;
		}
	}

	public static void InitializeWithBlob(int saveIndex, string json)
	{
		data = JsonConvert.DeserializeObject<SaveData>(json);
		_saveIndex = saveIndex;
	}

	public static void Uninitialize()
	{
		data = null;
		_saveIndex = -1;
	}

	public static async Task DeleteGameAsync(int saveIndex)
	{
		try
		{
			isSaveLoading = true;
			await Platform.DeleteSaveAsync(GetFilePath(saveIndex));
		}
		finally
		{
			isSaveLoading = false;
		}
	}

	public static bool DoesGameExist(int saveIndex)
	{
		return Platform.DoesSaveExist(GetFilePath(saveIndex));
	}

	public static async void SaveGame()
	{
		await SaveGameAsync();
	}

	public static async Task SaveGameAsync()
	{
		isSaveLoading = true;
		try
		{
			string s = JsonConvert.SerializeObject(data, Debug.isDebugBuild ? Formatting.Indented : Formatting.None);
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			await Platform.SaveAsync(GetFilePath(_saveIndex), bytes);
		}
		finally
		{
			isSaveLoading = false;
		}
	}

	public static void SaveGameImmediate()
	{
		PlatformType platformType = Platform.GetPlatformType();
		if (platformType == PlatformType.Steam || platformType == PlatformType.PC || platformType == PlatformType.SteamDeck)
		{
			try
			{
				string s = JsonConvert.SerializeObject(data, Debug.isDebugBuild ? Formatting.Indented : Formatting.None);
				byte[] bytes = Encoding.UTF8.GetBytes(s);
				File.WriteAllBytes(GetFilePath(_saveIndex), bytes);
				return;
			}
			finally
			{
				isSaveLoading = false;
			}
		}
		Debug.LogWarning("Immediate saving not available!");
	}

	public static string GetSaveBlob()
	{
		return JsonConvert.SerializeObject(data, Formatting.Indented);
	}

	private static string GetFilePath(int saveIndex)
	{
		return $"{Application.persistentDataPath}/saves/{Platform.GetAccountId()}/save_{saveIndex}.sav";
	}

	[DevCmd("save", "\r\nUsage:\r\n    save\r\n        Immediately saves the game.\r\n\r\n    save -unlock\r\n        Unlock all progression for debug builds.\r\n\r\n    save -bells <bell_count>\r\n        Sets the save file's bell count to the supplied amount.\r\n\r\n    save -score <score>", new string[] { "unlock", "bells", "score" })]
	[DevCmdComplete("score", DevCmdCompleteFlags.ValueCaseInsensitive, typeof(ContractScore))]
	[DevCmdVerify("^$")]
	[DevCmdVerify("^-unlock$")]
	[DevCmdVerify("^-score [DCBASdcbas]$")]
	[DevCmdVerify("^-bells [0-9]+$")]
	private static void SaveDevCmd(DevCmdArg[] args)
	{
		if (args.Length != 0)
		{
			switch (args[0].name)
			{
			case "bells":
				if (GameUtil.isReady)
				{
					if (int.TryParse(args[0].value, out var result2))
					{
						data.ClearContracts();
						List<ContractObject> list = new List<ContractObject>();
						GameManager.GetAllContracts(list);
						int num = 0;
						for (int k = 0; k < list.Count; k++)
						{
							if (num >= result2)
							{
								break;
							}
							ContractObject contract = list[k];
							int num2 = math.min(result2 - num, 5);
							data.SetContractBellCount(contract, num2);
							num += num2;
						}
					}
					else
					{
						Debug.LogWarning($"Invalid bell number count! ({result2})");
					}
				}
				else
				{
					Debug.LogWarning("Can only set bell count during a run or lobby!");
				}
				break;
			case "score":
			{
				if (!isInitialized)
				{
					break;
				}
				if (!Enum.TryParse<ContractScore>(args[0].value, ignoreCase: true, out var result))
				{
					Debug.LogWarning("Invalid score: " + args[0].value);
					break;
				}
				ContractObject[] allContracts = GameManager.GetAllContracts();
				foreach (ContractObject contractObject in allContracts)
				{
					if (contractObject.type == ContractType.Explicit)
					{
						data.SetContractBellCount(contractObject, 5);
						data.SetContractScore(contractObject, result);
						for (int j = 0; j < contractObject.unlocks.Length; j++)
						{
							data.UnlockCostume(contractObject.unlocks[j].costume);
						}
					}
				}
				break;
			}
			default:
				Debug.LogWarning("Unknown argument " + args[0].name);
				break;
			}
		}
		else
		{
			SaveGameImmediate();
		}
	}
}
