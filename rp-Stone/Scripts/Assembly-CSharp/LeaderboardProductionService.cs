using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderboardProductionService : MonoBehaviour, LeaderboardController.ILeaderboardService
{
	private const string BASE_URL = "https://stonestoryrpg.com/lb/";

	public string inputSalt;

	public int staleTimeSeconds;

	private Dictionary<int, LeaderboardEntry> rankTable = new Dictionary<int, LeaderboardEntry>();

	private Dictionary<string, LeaderboardEntry> playerIdTable = new Dictionary<string, LeaderboardEntry>();

	private string myPlayerId;

	private Dictionary<string, LeaderboardEventPlayerResponseData> cachedPlayerResults = new Dictionary<string, LeaderboardEventPlayerResponseData>();

	public void EventGet(string leaderboardId, int startRank, int count, int? lastScore, string lastPlayerId, Action<LeaderboardEventGetResponseData> callback)
	{
		if (HeroSettings.isNameSet)
		{
			StartCoroutine(_EventGet(leaderboardId, startRank, count, lastScore, lastPlayerId, callback));
		}
	}

	private IEnumerator _EventGet(string leaderboardId, int startRank, int count, int? lastScore, string lastPlayerId, Action<LeaderboardEventGetResponseData> callback)
	{
		string uri = "https://stonestoryrpg.com/lb/event_get.php";
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("leaderboard_id", leaderboardId);
		wWWForm.AddField("count", count);
		if (lastScore.HasValue)
		{
			wWWForm.AddField("last_score", lastScore.Value);
		}
		if (lastPlayerId != null)
		{
			wWWForm.AddField("last_player_id", lastPlayerId);
		}
		using UnityWebRequest webRequest = UnityWebRequest.Post(uri, wWWForm);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Utils.LogIfEditor("Request failed.");
			Utils.LogErrorIfEditor(webRequest.error);
			callback(null);
			yield break;
		}
		Utils.LogIfEditor("Request succeeded.");
		string text = webRequest.downloadHandler.text;
		Utils.LogIfEditor(text);
		LeaderboardEventGetResponseData leaderboardEventGetResponseData = LeaderboardEventGetResponseData.FromJson(text);
		int num = startRank;
		if (lastScore.HasValue)
		{
			num += leaderboardEventGetResponseData.entries.Length;
		}
		AdjustLocalPlayerRank(leaderboardId, leaderboardEventGetResponseData.entries, num);
		callback(leaderboardEventGetResponseData);
	}

	public void LocationGet(string leaderboardId, int startRank, int count, int? lastScore, string lastPlayerId, Action<LeaderboardEventGetResponseData> callback)
	{
		if (HeroSettings.isNameSet)
		{
			StartCoroutine(_LocationGet(leaderboardId, startRank, count, lastScore, lastPlayerId, callback));
		}
	}

	private IEnumerator _LocationGet(string leaderboardId, int startRank, int count, int? lastScore, string lastPlayerId, Action<LeaderboardEventGetResponseData> callback)
	{
		string uri = "https://stonestoryrpg.com/lb/location_get.php";
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("leaderboard_id", leaderboardId);
		wWWForm.AddField("count", count);
		if (lastScore.HasValue)
		{
			wWWForm.AddField("last_score", lastScore.Value);
		}
		if (lastPlayerId != null)
		{
			wWWForm.AddField("last_player_id", lastPlayerId);
		}
		using UnityWebRequest webRequest = UnityWebRequest.Post(uri, wWWForm);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Utils.LogIfEditor("Request failed.");
			Utils.LogErrorIfEditor(webRequest.error);
			callback(null);
			yield break;
		}
		Utils.LogIfEditor("Request succeeded.");
		string text = webRequest.downloadHandler.text;
		Utils.LogIfEditor(text);
		LeaderboardEventGetResponseData leaderboardEventGetResponseData = LeaderboardEventGetResponseData.FromJson(text);
		int num = startRank;
		if (lastScore.HasValue)
		{
			num += leaderboardEventGetResponseData.entries.Length;
		}
		AdjustLocalPlayerRank(leaderboardId, leaderboardEventGetResponseData.entries, num);
		callback(leaderboardEventGetResponseData);
	}

	public void EventPlayer(string leaderboardId, string playerId, Action<LeaderboardEventPlayerResponseData> callback)
	{
		StartCoroutine(_EventPlayer(leaderboardId, playerId, callback));
	}

	private IEnumerator _EventPlayer(string leaderboardId, string playerId, Action<LeaderboardEventPlayerResponseData> callback)
	{
		string uri = "https://stonestoryrpg.com/lb/event_player.php";
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("leaderboard_id", leaderboardId);
		wWWForm.AddField("player_id", playerId);
		using UnityWebRequest webRequest = UnityWebRequest.Post(uri, wWWForm);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Utils.LogErrorIfEditor(webRequest.error);
			Utils.LogIfEditor("Request failed.");
			callback(null);
			yield break;
		}
		string text = webRequest.downloadHandler.text;
		Utils.LogIfEditor(text);
		if (SlimJson.ParseBool(text, "success"))
		{
			LeaderboardEventPlayerResponseData leaderboardEventPlayerResponseData = LeaderboardEventPlayerResponseData.FromJson(text);
			leaderboardEventPlayerResponseData.entry.isLocalPlayer = true;
			CachePlayer(leaderboardEventPlayerResponseData);
			callback(leaderboardEventPlayerResponseData);
		}
		else
		{
			Utils.LogErrorIfEditor("EventPlayer request failed");
			LeaderboardEventPlayerResponseData obj = new LeaderboardEventPlayerResponseData(leaderboardId, success: false, null);
			callback(obj);
		}
	}

	public void LocationPlayer(string leaderboardId, string playerId, Action<LeaderboardEventPlayerResponseData> callback)
	{
		StartCoroutine(_LocationPlayer(leaderboardId, playerId, callback));
	}

	private IEnumerator _LocationPlayer(string leaderboardId, string playerId, Action<LeaderboardEventPlayerResponseData> callback)
	{
		string uri = "https://stonestoryrpg.com/lb/location_player.php";
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("leaderboard_id", leaderboardId);
		wWWForm.AddField("player_id", playerId);
		using UnityWebRequest webRequest = UnityWebRequest.Post(uri, wWWForm);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Utils.LogErrorIfEditor(webRequest.error);
			Utils.LogIfEditor("Request failed.");
			callback(null);
			yield break;
		}
		string text = webRequest.downloadHandler.text;
		Utils.LogIfEditor(text);
		if (SlimJson.ParseBool(text, "success"))
		{
			LeaderboardEventPlayerResponseData leaderboardEventPlayerResponseData = LeaderboardEventPlayerResponseData.FromJson(text);
			leaderboardEventPlayerResponseData.entry.isLocalPlayer = true;
			CachePlayer(leaderboardEventPlayerResponseData);
			callback(leaderboardEventPlayerResponseData);
		}
		else
		{
			Utils.LogErrorIfEditor("LocationPlayer request failed");
			LeaderboardEventPlayerResponseData obj = new LeaderboardEventPlayerResponseData(leaderboardId, success: false, null);
			callback(obj);
		}
	}

	private void CachePlayer(LeaderboardEventPlayerResponseData responseData)
	{
		string key = responseData.leaderboardId + responseData.entry.playerId;
		cachedPlayerResults[key] = responseData;
	}

	private LeaderboardEventPlayerResponseData GetCachedPlayer(string leaderboardId, string playerId)
	{
		string key = leaderboardId + playerId;
		if (cachedPlayerResults.ContainsKey(key))
		{
			return cachedPlayerResults[key];
		}
		return null;
	}

	private void AdjustLocalPlayerRank(string leaderboardId, LeaderboardEntry[] entries, int firstEntryRank)
	{
		for (int i = 0; i < entries.Length; i++)
		{
			LeaderboardEntry leaderboardEntry = entries[i];
			LeaderboardEventPlayerResponseData cachedPlayer = GetCachedPlayer(leaderboardId, leaderboardEntry.playerId);
			if (cachedPlayer != null)
			{
				cachedPlayer.entry.rank = i + firstEntryRank;
				leaderboardEntry.isLocalPlayer = true;
			}
		}
	}

	public void SubmitScoreUpdate(string leaderboardId, int score)
	{
		if (HasSubmitted())
		{
			string playerId = GetPlayerId();
			string saveFileId = GetSaveFileId();
			string heroName = GetHeroName();
			StartCoroutine(_EventSubmit(leaderboardId, playerId, saveFileId, heroName, score, null));
		}
	}

	public void SubmitLocationScore(string leaderboardId, int score)
	{
		if (HasSubmitted())
		{
			string playerId = GetPlayerId();
			string saveFileId = GetSaveFileId();
			string heroName = GetHeroName();
			StartCoroutine(_LocationSubmit(leaderboardId, playerId, saveFileId, heroName, score, null));
		}
	}

	public void LocationSubmit(string leaderboardId, Action<LeaderboardEventSubmitResponseData> callback)
	{
		if (HeroSettings.isNameSet)
		{
			string playerId = GetPlayerId();
			string saveFileId = GetSaveFileId();
			string heroName = GetHeroName();
			int score = -1;
			StartCoroutine(_LocationSubmit(leaderboardId, playerId, saveFileId, heroName, score, callback));
		}
	}

	public void EventSubmit(BaseEventController2 eventController, string leaderboardId, Action<LeaderboardEventSubmitResponseData> callback)
	{
		if (HeroSettings.isNameSet)
		{
			string playerId = GetPlayerId();
			string saveFileId = GetSaveFileId();
			string heroName = GetHeroName();
			int rewardPoints = eventController.rewards.rewardPoints;
			StartCoroutine(_EventSubmit(leaderboardId, playerId, saveFileId, heroName, rewardPoints, callback));
		}
	}

	private IEnumerator _EventSubmit(string leaderboardId, string? playerId, string saveId, string name, int score, Action<LeaderboardEventSubmitResponseData> callback)
	{
		string uri = "https://stonestoryrpg.com/lb/event_submit.php";
		string value = Utils.MD5(leaderboardId + saveId + name + inputSalt);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("leaderboard_id", leaderboardId);
		if (playerId != null)
		{
			wWWForm.AddField("player_id", playerId);
		}
		wWWForm.AddField("save_id", saveId);
		wWWForm.AddField("name", name);
		wWWForm.AddField("score", score);
		wWWForm.AddField("valid", value);
		using UnityWebRequest webRequest = UnityWebRequest.Post(uri, wWWForm);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Utils.LogErrorIfEditor(webRequest.error);
			Utils.LogIfEditor("Request failed.");
			callback?.Invoke(null);
			yield break;
		}
		string text = webRequest.downloadHandler.text;
		Utils.LogIfEditor(text);
		LeaderboardEventSubmitResponseData leaderboardEventSubmitResponseData = LeaderboardEventSubmitResponseData.FromJson(text);
		if (leaderboardEventSubmitResponseData.success)
		{
			if (string.IsNullOrEmpty(myPlayerId) && leaderboardEventSubmitResponseData.entry.playerId != null)
			{
				myPlayerId = leaderboardEventSubmitResponseData.entry.playerId;
				GameStates.Singleton.TryToSaveProgress();
			}
			LeaderboardEventPlayerResponseData cachedPlayer = GetCachedPlayer(leaderboardId, myPlayerId);
			if (cachedPlayer != null)
			{
				cachedPlayer.entry.rank = leaderboardEventSubmitResponseData.entry.rank;
				cachedPlayer.entry.score = leaderboardEventSubmitResponseData.entry.score;
				cachedPlayer.entry.time = leaderboardEventSubmitResponseData.entry.time;
				cachedPlayer.entry.health = leaderboardEventSubmitResponseData.entry.health;
				cachedPlayer.entry.damage = leaderboardEventSubmitResponseData.entry.damage;
			}
			if (callback != null)
			{
				Utils.LogIfEditor("SUBMIT SUCCESS");
				callback(leaderboardEventSubmitResponseData);
			}
		}
		else
		{
			Utils.LogErrorIfEditor("Submit request failed. Response:\n" + text);
			callback?.Invoke(null);
		}
	}

	private IEnumerator _LocationSubmit(string leaderboardId, string? playerId, string saveId, string name, int score, Action<LeaderboardEventSubmitResponseData> callback)
	{
		string uri = "https://stonestoryrpg.com/lb/location_submit.php";
		string value = Utils.MD5(leaderboardId + saveId + name + inputSalt);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("leaderboard_id", leaderboardId);
		if (playerId != null)
		{
			wWWForm.AddField("player_id", playerId);
		}
		wWWForm.AddField("save_id", saveId);
		wWWForm.AddField("name", name);
		wWWForm.AddField("score", score);
		wWWForm.AddField("valid", value);
		wWWForm.AddField("version", Features.VERSION.ToString());
		using UnityWebRequest webRequest = UnityWebRequest.Post(uri, wWWForm);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Utils.LogErrorIfEditor(webRequest.error);
			Utils.LogIfEditor("Request failed.");
			callback?.Invoke(null);
			yield break;
		}
		string text = webRequest.downloadHandler.text;
		Utils.LogIfEditor(text);
		LeaderboardEventSubmitResponseData leaderboardEventSubmitResponseData = LeaderboardEventSubmitResponseData.FromJson(text);
		if (leaderboardEventSubmitResponseData.success)
		{
			if (string.IsNullOrEmpty(myPlayerId) && leaderboardEventSubmitResponseData.entry.playerId != null)
			{
				myPlayerId = leaderboardEventSubmitResponseData.entry.playerId;
				GameStates.Singleton.TryToSaveProgress();
			}
			if (leaderboardEventSubmitResponseData.entry.score > 0)
			{
				LeaderboardEventPlayerResponseData cachedPlayer = GetCachedPlayer(leaderboardId, myPlayerId);
				if (cachedPlayer != null)
				{
					cachedPlayer.entry.rank = leaderboardEventSubmitResponseData.entry.rank;
					cachedPlayer.entry.score = leaderboardEventSubmitResponseData.entry.score;
					cachedPlayer.entry.time = leaderboardEventSubmitResponseData.entry.time;
					cachedPlayer.entry.health = leaderboardEventSubmitResponseData.entry.health;
					cachedPlayer.entry.damage = leaderboardEventSubmitResponseData.entry.damage;
				}
			}
			if (callback != null)
			{
				Utils.LogIfEditor("SUBMIT SUCCESS");
				callback(leaderboardEventSubmitResponseData);
			}
		}
		else
		{
			Utils.LogErrorIfEditor("Submit request failed. Response:\n" + text);
			callback?.Invoke(null);
		}
	}

	public void Create(string leaderboardId, string type, string endDate)
	{
		StartCoroutine(_Create(leaderboardId, type, endDate));
	}

	private IEnumerator _Create(string leaderboardId, string type, string endDate)
	{
		string text = "https://stonestoryrpg.com/lb/create.php";
		Utils.LogIfEditor("Calling remote: " + text);
		string value = "";
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("leaderboard_id", leaderboardId);
		wWWForm.AddField("type", type);
		wWWForm.AddField("end_date", endDate);
		wWWForm.AddField("valid", value);
		using UnityWebRequest webRequest = UnityWebRequest.Post(text, wWWForm);
		yield return webRequest.SendWebRequest();
		if (webRequest.result != UnityWebRequest.Result.Success)
		{
			Utils.LogErrorIfEditor(webRequest.error);
		}
		else
		{
			Utils.LogIfEditor(webRequest.downloadHandler.text);
		}
	}

	public bool CanSubmit(BaseEventController2 eventController, string leaderboardId)
	{
		if (HeroSettings.isNameSet)
		{
			return eventController.rewards.rewardPoints > 0;
		}
		return false;
	}

	public bool CanSubmit(string leaderboardId)
	{
		return HeroSettings.isNameSet;
	}

	public bool HasSubmitted()
	{
		return !string.IsNullOrEmpty(myPlayerId);
	}

	private string GetHeroName()
	{
		return HeroSettings.name;
	}

	private string GetSaveFileId()
	{
		if (GameSave.activeSaveFile == null)
		{
			return null;
		}
		return GameSave.activeSaveFile.uniqueId;
	}

	public string? GetPlayerId()
	{
		return myPlayerId;
	}

	public void ClearProgress()
	{
		myPlayerId = null;
	}

	public void Parse(string sjson)
	{
		if (sjson != null)
		{
			myPlayerId = SlimJson.Parse(sjson, "pId");
		}
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("pId", myPlayerId);
		return SlimJson.EndSerialization();
	}
}
