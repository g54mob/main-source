using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using PlayFab;
using PlayFab.EconomyModels;
using UnityEngine;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;

public class PlayFabUtils
{
	public static string GetLang()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2FAA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return "NEUTRAL";
	}

	public static Dictionary<string, string> GetCustomTags()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string version = Application.version;
		if (dictionary != null)
		{
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"VERSION", (object)version, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			string platformAsString = BackendFacade.GetPlatformAsString();
			bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"PLATFORM", (object)platformAsString, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			return dictionary;
		}
		return (Dictionary<string, string>)(object)new NullReferenceException();
	}

	public static EntityKey GetPlayerEntityKey()
	{
		PlayFabAuthenticationContext staticPlayer = PlayFabSettings.staticPlayer;
		if (PlayFabSettings.staticPlayer != null)
		{
			EntityKey entityKey = new EntityKey();
			if (entityKey != null)
			{
				entityKey.Type = "title_player_account";
				entityKey.Id = staticPlayer.EntityToken;
				return entityKey;
			}
		}
		return (EntityKey)(object)new NullReferenceException();
	}

	public static EntityKey GetTitleEntityKey()
	{
		EntityKey entityKey = new EntityKey();
		if (entityKey != null)
		{
			entityKey.Type = "title";
			if (PlayFabSettings.staticSettings != null)
			{
				string titleId = PlayFabSettings.staticSettings.TitleId;
				entityKey.Id = titleId;
				return entityKey;
			}
		}
		return (EntityKey)(object)new NullReferenceException();
	}
}
