using System.IO;
using ModIO;
using PugMod;
using UnityEngine;

public class ModIOLoader : IModPlatform
{
	public const string MODIO_CATEGORY_ACCESS_TYPE = "Access Type";

	public const string MODIO_TAG_ACCESS_TYPE_ASSET = "Asset";

	public const string MODIO_TAG_ACCESS_TYPE_SCRIPT = "Script";

	public const string MODIO_TAG_ACCESS_TYPE_SCRIPT_ELEVATED = "Script (Elevated Access)";

	private readonly string _user;

	private long _idCount;

	public ModIOLoader(string userIdentifier)
	{
		_user = userIdentifier;
	}

	public bool Init()
	{
		Result result = ModIOUnity.InitializeForUser(_user);
		if (!result.Succeeded())
		{
			Debug.LogError($"failed to initialized modIO SDK {result.message} (code: {result.errorCode})");
			return false;
		}
		SubscribedMod[] subscribedMods = ModIOUnity.GetSubscribedMods(out result);
		if (!result.Succeeded())
		{
			Debug.Log($"no mod.io mods loaded {result.message} (code: {result.errorCode})");
			return false;
		}
		SubscribedMod[] array = subscribedMods;
		for (int i = 0; i < array.Length; i++)
		{
			SubscribedMod subscribedMod = array[i];
			if (!subscribedMod.enabled)
			{
				Debug.Log("skipping disabled mod " + subscribedMod.modProfile.name);
				continue;
			}
			if (subscribedMod.status != SubscribedModStatus.Installed)
			{
				Debug.Log("skipping mod " + subscribedMod.modProfile.name + ", not installed yet");
				continue;
			}
			string text = Path.Combine(subscribedMod.directory, "ModManifest.json");
			if (!File.Exists(text))
			{
				Debug.Log(subscribedMod.modProfile.name + " has no manifest at " + text);
				continue;
			}
			ModMetadata metadata = JsonUtility.FromJson<ModMetadata>(File.ReadAllText(text));
			bool flag = false;
			bool flag2 = ModVersion.IsCompatible(Application.version, subscribedMod.modProfile.tags);
			string[] tags = subscribedMod.modProfile.tags;
			foreach (string text2 in tags)
			{
				if (text2.Equals("Script (Elevated Access)"))
				{
					flag = true;
				}
				else if (text2.Equals("Asset"))
				{
					metadata.disableScripts = true;
				}
			}
			if (!flag2)
			{
				Debug.Log("mod " + subscribedMod.modProfile.name + " is not compatible with current version");
			}
			if (!flag)
			{
				metadata.skipSafetyChecks = false;
			}
			if (!Integration.Instance.AddMod(metadata, subscribedMod.directory, subscribedMod.modProfile.id, flag2))
			{
				Debug.Log("failed to load mod " + metadata.name + " from mod.io (" + subscribedMod.modProfile.name + ")");
			}
			else
			{
				Debug.Log("loaded mod " + metadata.name + " from mod.io (" + subscribedMod.modProfile.name + ")");
			}
		}
		return true;
	}

	public void Update()
	{
	}
}
