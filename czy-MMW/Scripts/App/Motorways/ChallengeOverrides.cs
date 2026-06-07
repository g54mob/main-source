using System;
using System.Collections.Generic;
using System.Text;
using Factory;
using UnityEngine.Networking;

namespace Motorways
{
	public class ChallengeOverrides
	{
		private delegate MapChallenge ChallengeFactory(ChallengeSystem challengeSystem, MapDefinition mapDefinition, ChallengeData[] challenges, int timeStart, int timeEnd, ulong seed);

		public enum RefreshResult
		{
			Error = 0,
			NoChange = 1,
			Success = 2
		}

		public static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("ChallengeOverrides");

		public const string OverridesFilepath = "challengeOverrides.json";

		public const string OverridesVersionFilepath = "challengeOverrides_version.json";

		[Dependency]
		private IReachability _reachability;

		[Dependency]
		private IFileSystem _fileSystem;

		private ChallengeSystem _challengeSystem;

		private ChallengeDatabase _challengeDatabase;

		private MapDatabase _mapDatabase;

		private readonly List<ChallengeOverride> _dailyChallenges = new List<ChallengeOverride>();

		private readonly List<ChallengeOverride> _weeklyChallenges = new List<ChallengeOverride>();

		private ChallengeOverrideVersion _overrideVersion = new ChallengeOverrideVersion();

		private bool _isOpeningConnection;

		private DateTime _timeLastRefreshedOverrides;

		private static readonly TimeSpan MinRefreshTimespan = TimeSpan.FromMinutes(10.0);

		public void Initialize(ChallengeSystem challengeSystem, ChallengeDatabase challengeDatabase, MapDatabase mapDatabase)
		{
			_challengeSystem = challengeSystem;
			_challengeDatabase = challengeDatabase;
			_mapDatabase = mapDatabase;
			LoadLocalOverrides();
		}

		private void LoadLocalOverrides()
		{
			byte[] array = _fileSystem.ReadFile("challengeOverrides.json");
			if (array == null)
			{
				return;
			}
			string json = Encoding.UTF8.GetString(array);
			if (Deserialize(json))
			{
				byte[] array2 = _fileSystem.ReadFile("challengeOverrides_version.json");
				if (array2 != null)
				{
					string json2 = Encoding.UTF8.GetString(array2);
					if (_overrideVersion.Deserialize(json2))
					{
						Log.Info("Loaded challenge overrides version {0}.", _overrideVersion.Timestamp);
					}
				}
			}
			else
			{
				Log.Info("Failed to import challenge overrides from {0}. They will be fetched again from the server.", "challengeOverrides.json");
			}
		}

		public void RefreshOverridesFromServer(Action<RefreshResult> callback = null)
		{
			DateTime timeNow = GameDateTime.UtcNow;
			if (timeNow - _timeLastRefreshedOverrides < MinRefreshTimespan || _isOpeningConnection)
			{
				callback?.Invoke(RefreshResult.NoChange);
				return;
			}
			_isOpeningConnection = true;
			_reachability.OpenSilentConnection(delegate(InternetConnectionHandle handle)
			{
				_isOpeningConnection = false;
				if (_reachability.Connectivity == InternetConnectivity.Disconnected)
				{
					Log.Info("Not refreshing challenges because the internet connection is not available.");
					callback?.Invoke(RefreshResult.Error);
					handle.Close();
				}
				else
				{
					_timeLastRefreshedOverrides = timeNow;
					string uri = "https://api.dinopoloclub.com/1/minimotorways/challenges/version/";
					UnityWebRequest wwwVersion = UnityWebRequest.Get(uri);
					wwwVersion.SendWebRequest().completed += delegate
					{
						if (!Diagnostics.Verify(wwwVersion.result == UnityWebRequest.Result.Success, "Failed to download the new Versions file"))
						{
							callback?.Invoke(RefreshResult.Error);
							handle.Close();
						}
						else
						{
							string versionJson = wwwVersion.downloadHandler.text;
							ChallengeOverrideVersion serverVersion = new ChallengeOverrideVersion();
							if (!Diagnostics.Verify(serverVersion.Deserialize(versionJson), "Failed to deserialize ServerVersion. The json may be in an unexpected format."))
							{
								callback?.Invoke(RefreshResult.Error);
								handle.Close();
							}
							else if (serverVersion.Timestamp <= _overrideVersion.Timestamp)
							{
								callback?.Invoke(RefreshResult.NoChange);
								handle.Close();
							}
							else
							{
								Log.Info("The server's challenge override version ({0}) is NEWER than the local version ({1}).", serverVersion.Timestamp, _overrideVersion.Timestamp);
								string uri2 = $"https://api.dinopoloclub.com/1/minimotorways/challenges/{serverVersion.Timestamp}/";
								UnityWebRequest www = UnityWebRequest.Get(uri2);
								www.SendWebRequest().completed += delegate
								{
									if (!Diagnostics.Verify(www.result == UnityWebRequest.Result.Success, "Failed to download the new Overrides file"))
									{
										callback?.Invoke(RefreshResult.Error);
										handle.Close();
									}
									else
									{
										string text = www.downloadHandler.text;
										if (!Diagnostics.Verify(Deserialize(text), "Failed to deserialize Overrides. The json may be in an unexpected format."))
										{
											callback?.Invoke(RefreshResult.Error);
											handle.Close();
										}
										_overrideVersion = serverVersion;
										_fileSystem.WriteFile("challengeOverrides.json", Encoding.UTF8.GetBytes(text));
										_fileSystem.WriteFile("challengeOverrides_version.json", Encoding.UTF8.GetBytes(versionJson));
										Log.Info("Local challenge overrides have been updated to version {0}.", _overrideVersion.Timestamp);
										callback?.Invoke(RefreshResult.Success);
										handle.Close();
									}
								};
							}
						}
					};
				}
			});
		}

		public bool TryGetDailyChallenge(int startTime, int endTime, out MapChallenge result)
		{
			return TryGetChallenge(_dailyChallenges, startTime, endTime, MapChallenge.CreateDailyChallenge, out result);
		}

		public bool TryGetWeeklyChallenge(int startTime, int endTime, out MapChallenge result)
		{
			return TryGetChallenge(_weeklyChallenges, startTime, endTime, MapChallenge.CreateWeeklyChallenge, out result);
		}

		private bool TryGetChallenge(List<ChallengeOverride> overrides, int startTime, int endTime, ChallengeFactory createChallenge, out MapChallenge result)
		{
			result = null;
			ChallengeOverride challengeOverride = null;
			foreach (ChallengeOverride @override in overrides)
			{
				if (@override.timestamp == startTime)
				{
					challengeOverride = @override;
					break;
				}
			}
			if (challengeOverride == null)
			{
				return false;
			}
			MapDefinition mapByName = _mapDatabase.MapLibrary.GetMapByName(challengeOverride.cityName);
			if (mapByName == null)
			{
				Log.Error("Failed to map CityName: " + challengeOverride.cityName + " - Defaulting to excluding it from the Overrides");
				return false;
			}
			List<ChallengeData> list = new List<ChallengeData>(challengeOverride.challengeNames.Length);
			string[] challengeNames = challengeOverride.challengeNames;
			foreach (string text in challengeNames)
			{
				if (_challengeDatabase.TryGetChallenge(text, out var result2))
				{
					list.Add(result2);
				}
				else
				{
					Log.Error("Failed to map ChallengeData: " + text + " - Defaulting to excluding it from the ChallengeData container");
				}
			}
			if (list.Count == 0)
			{
				Log.Error($"MapChallenge ({startTime} - {endTime}) has no ChallengeData - Defaulting to excluding it from the Overrides");
				return false;
			}
			result = createChallenge(_challengeSystem, mapByName, list.ToArray(), startTime, endTime, (ulong)startTime);
			return result != null;
		}

		public string Serialize()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			List<object> value = SerializeChallenges(_dailyChallenges);
			dictionary.Add("Days", value);
			List<object> value2 = SerializeChallenges(_weeklyChallenges);
			dictionary.Add("Weeks", value2);
			return Json.Serialize(dictionary);
		}

		private List<object> SerializeChallenges(List<ChallengeOverride> challenges)
		{
			List<object> list = new List<object>(challenges.Count);
			foreach (ChallengeOverride challenge in challenges)
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("Timestamp", challenge.timestamp);
				dictionary.Add("CityName", challenge.cityName);
				dictionary.Add("ChallengeNames", challenge.challengeNames);
				list.Add(dictionary);
			}
			return list;
		}

		private bool Deserialize(string json)
		{
			JSON.Dictionary dictionary = JSON.ToDictionary(JSON.LoadFromString(json));
			if (dictionary == null)
			{
				Log.Error("Failed to parse JSON string to Dictionary.\n" + json);
				return false;
			}
			JSON.Array array = dictionary.GetArray("Days");
			JSON.Array array2 = dictionary.GetArray("Weeks");
			if (array == null || array2 == null)
			{
				Log.Error("Failed to extract both Days and Weeks Arrays from Dictionary.\nDays Node:\n" + Json.Serialize(array) + "\n\nWeeks Node:\n" + Json.Serialize(array2) + "\n" + json + "\n\nSource:\n" + json);
				return false;
			}
			List<ChallengeOverride> list = DeserializeChallenges(array);
			List<ChallengeOverride> list2 = DeserializeChallenges(array2);
			if (list == null || list2 == null)
			{
				Log.Error($"Failed to Deserialize Daily or Weekly Challenges.\nDailyChallenges: {list}\nWeekly Challenges: {list2}\n\nSource:\n{json}");
				return false;
			}
			_dailyChallenges.Clear();
			_dailyChallenges.AddRange(list);
			_weeklyChallenges.Clear();
			_weeklyChallenges.AddRange(list2);
			return true;
		}

		private List<ChallengeOverride> DeserializeChallenges(JSON.Array challenges)
		{
			List<ChallengeOverride> list = new List<ChallengeOverride>(challenges.Count);
			for (int i = 0; i < challenges.Count; i++)
			{
				JSON.Dictionary dictionary = JSON.ToDictionary(challenges[i]);
				if (dictionary == null)
				{
					Log.Error("Failed to convert to Dictionary.\n" + Json.Serialize(challenges[i]));
					return null;
				}
				int num = dictionary.GetInt("Timestamp", -1);
				string text = dictionary.GetString("CityName");
				JSON.Array array = dictionary.GetArray("ChallengeNames");
				if (num == -1 || text == null || array == null)
				{
					Log.Error($"Failed to Deserialize ChallengeOverride.\nIndex: {i}\nTimestamp: {num}\nCityName: {text}\nChallengeNames:\n{Json.Serialize(array)}\n\nSource:\n{Json.Serialize(challenges)}");
					return null;
				}
				string[] array2 = new string[array.Count];
				for (int j = 0; j < array2.Length; j++)
				{
					string text2 = array.GetString(j);
					if (text2 == null)
					{
						Log.Error($"Invalid string entry in ChallengesArray.\nIndex: {j}\nElement: {array[0]}\n\nSource:\n{Json.Serialize(array)}");
						return null;
					}
					array2[j] = text2;
				}
				ChallengeOverride item = new ChallengeOverride(num, text, array2);
				list.Add(item);
			}
			return list;
		}

		public static ChallengeOverrides EDITOR_CreateFromOverrides(List<ChallengeOverride> dailyChallenges, List<ChallengeOverride> weeklyChallenges)
		{
			ChallengeOverrides challengeOverrides = new ChallengeOverrides();
			challengeOverrides._dailyChallenges.AddRange(dailyChallenges);
			challengeOverrides._weeklyChallenges.AddRange(weeklyChallenges);
			return challengeOverrides;
		}
	}
}
