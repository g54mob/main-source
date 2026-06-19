using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class CommandLineArgs
{
	public const string kPressDemo = "-pdemo";

	public const string kConsumerDemo = "-cdemo";

	public const string kMarketingBuild = "-marketing";

	public const string kAmbassadorPreview = "-ambassadorpreview";

	public const string kCsBackend = "-csbackend";

	public const string kSteamPlaytest = "-playtest";

	public const string kSteamDemo = "-steamdemo";

	public const string kAllowNoSteam = "-allownosteam";

	public const string kNonPlayable = "-nonplayable";

	public const string kNoRgb = "-norgb";

	public const string kExtraChecks = "-extrachecks";

	public const string kWindowScale = "-windowscale";

	public const string kSeason = "-season";

	public const string kActivateContentBundles = "-activatecontent";

	public const string kActivateAllContent = "-activateallcontent";

	public const string kDisableAutosave = "-disableautosave";

	public const string kVersionSuffix = "-versionsuffix";

	public const string kServerConfig = "-serverconfig";

	public const string kServerWorldId = "-world";

	public const string kServerWorldName = "-worldname";

	public const string kServerWorldSeed = "-worldseed";

	public const string kServerHashedWorldSeed = "-hashedworldseed";

	public const string kServerGameId = "-gameid";

	public const string kServerPassword = "-password";

	public const string kServerDataPath = "-datapath";

	public const string kServerMaxPlayers = "-maxplayers";

	public const string kServerWorldMode = "-worldmode";

	public const string kServerSeason = "-season";

	public const string kServerIp = "-ip";

	public const string kServerPort = "-port";

	public const string kExtraLog = "-extralog";

	public const string kNoNetwork = "-nonetwork";

	public const string kSafeMode = "-safemode";

	public const string kShowForcedSafeModeInfo = "-showforcedsafemodeinfo";

	public const string kConfDir = "-confdir";

	public const string kWaitFor = "-waitfor";

	public const string kScriptsOnly = "-scriptsonly";

	public const string kkScriptDebugging = "-scriptdebugging";

	public const string kPSRegion = "-psregion";

	public const string kPlayFabCustomId = "-playfabcustomid";

	public const string kPlayFabPartyId = "-playfabpartyid";

	public const string kBenchmark = "-benchmark";

	public const string kQuitAfterBenchmark = "-benchmark-quit";

	public const string kBenchmarkOutputBasePath = "-benchmark-output-base-path";

	public const string kForceBenchmarkOptionEnabled = "-forceBenchmarkOptionEnabled";

	public const string kEnableSwitchLinkTimeOptimization = "-enableSwitchLinkTimeOptimization";

	public const string kEnableSwitchRomCompression = "-enableSwitchRomCompression";

	public const string kUseIngameInviteMenu = "-useIngameInviteMenu";

	public const string kDisableSentry = "-disableSentry";

	public const string kDisableBurst = "-disableBurst";

	public const string kNetworkDebug = "-networkDebug";

	public const string kOnScreenDebug = "-onScreenDebug";

	public const string kCreatePatch = "-createPatch";

	public const string kPatchReferencePath1 = "-patchReferencePath1";

	public const string kPatchReferencePath2 = "-patchReferencePath2";

	public const string kBilibili = "-bilibili";

	public const string kServerPlatform = "-allowonlyplatform";

	private static string[] args = new string[0];

	public static void Init(string[] args)
	{
		CommandLineArgs.args = args;
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < CommandLineArgs.args.Length; i++)
		{
			stringBuilder.Append($"CommandLineArgs.args[{i}]: {CommandLineArgs.args[i]}\n");
		}
		Debug.Log(stringBuilder.ToString());
	}

	public static bool Has(string arg)
	{
		return Array.IndexOf(args, arg) >= 1;
	}

	public static int GetArgCount()
	{
		return args.Length;
	}

	public static string GetArg(int index)
	{
		if (args.Length > index)
		{
			return args[index];
		}
		return null;
	}

	public static string GetParam(string arg)
	{
		int num = Array.IndexOf(args, arg);
		if (num < 1 || num >= args.Length - 1)
		{
			return null;
		}
		return args[num + 1];
	}

	public static bool TryGetParam(string arg, out string param)
	{
		param = GetParam(arg);
		return param != null;
	}

	public static IEnumerable<string> EnumerateParams(string arg)
	{
		int i = 0;
		while (i < args.Length - 1)
		{
			if (string.Equals(arg, args[i]))
			{
				yield return args[i + 1];
			}
			int num = i + 1;
			i = num;
		}
	}

	public static int GetCustomWindowScale()
	{
		string param = GetParam("-windowscale");
		if (param == null)
		{
			return -1;
		}
		if (int.TryParse(param, out var result) && result >= 1 && result <= 16)
		{
			return result;
		}
		return -1;
	}
}
