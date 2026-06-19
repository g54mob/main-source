using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PugMod;
using Steamworks;
using Steamworks.Ugc;
using UnityEngine;

public class SteamWorkshopLoader : IModPlatform
{
	public const string STEAM_CATEGORY_ACCESS_TYPE = "Access Type";

	public const string STEAM_TAG_ACCESS_TYPE_ASSET = "Asset";

	public const string STEAM_TAG_ACCESS_TYPE_SCRIPT = "Script";

	public const string STEAM_TAG_ACCESS_TYPE_SCRIPT_ELEVATED = "Script (Elevated Access)";

	private readonly string _user;

	private long _idCount;

	private Task _initTask;

	public SteamWorkshopLoader(string userIdentifier)
	{
		_user = userIdentifier;
	}

	public bool Init()
	{
		_initTask = InitAsync();
		while (!_initTask.IsCompleted)
		{
			SteamClient.RunCallbacks();
			Thread.Sleep(1);
		}
		if (_initTask.Status == TaskStatus.RanToCompletion)
		{
			Debug.Log("steamworkshop loader has been initialized and async mod fetching query task completed");
			return true;
		}
		return false;
	}

	public async Task InitAsync()
	{
		try
		{
			if (!SteamClient.IsValid)
			{
				Debug.LogError("failed to initialize steam.");
				return;
			}
			Debug.Log("steam initialized successfully.");
			ResultPage? resultPage = await Query.All.WhereUserSubscribed(SteamClient.SteamId).GetPageAsync(1);
			if (!resultPage.HasValue || resultPage.Value.Entries.Count() == 0)
			{
				Debug.Log("no subscribed workshop items found.");
				return;
			}
			foreach (Item entry in resultPage.Value.Entries)
			{
				if (entry.IsBanned)
				{
					Debug.Log(entry.Title + " is prohibited.");
					continue;
				}
				if (!entry.IsInstalled)
				{
					Debug.Log("skipping mod " + entry.Title + ", not installed yet");
					continue;
				}
				string text = Path.Combine(entry.Directory, "ModManifest.json");
				if (!File.Exists(text))
				{
					Debug.Log(entry.Title + " has no manifest at " + text);
					continue;
				}
				ModMetadata metadata = JsonUtility.FromJson<ModMetadata>(File.ReadAllText(text));
				bool flag = false;
				bool flag2 = ModVersion.IsCompatible(Application.version, entry.Tags);
				string[] tags = entry.Tags;
				foreach (string text2 in tags)
				{
					if (text2.Equals("Script (Elevated Access)", StringComparison.OrdinalIgnoreCase))
					{
						flag = true;
					}
					else if (text2.Equals("Asset", StringComparison.OrdinalIgnoreCase))
					{
						metadata.disableScripts = true;
					}
				}
				if (!flag2)
				{
					Debug.Log("mod " + entry.Title + " is not compatible with current version");
				}
				if (!flag)
				{
					metadata.skipSafetyChecks = false;
				}
				if (!Integration.Instance.AddMod(metadata, entry.Directory, (long)entry.Id.Value, flag2))
				{
					Debug.Log("failed to load mod " + metadata.name + " from steam workshop (" + entry.Title + ")");
				}
				else
				{
					Debug.Log("loaded mod " + metadata.name + " from steam workshop (" + entry.Title + ")");
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("SteamWorkshopLoader failed to initialize: " + ex.Message);
		}
	}

	public void Update()
	{
		SteamClient.RunCallbacks();
	}
}
