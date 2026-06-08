using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AmbianceController : MonoBehaviour
{
	public float fadeOutDuration = 1f;

	public float fadeInDuration = 1f;

	public Music[] ambiantList;

	private Dictionary<string, Music> prefabDict = new Dictionary<string, Music>();

	private const int COUNT_LIMIT = 4;

	private List<Music> ambience = new List<Music>(4);

	private float _volume;

	private List<string> pendingAsync = new List<string>();

	private static AmbianceController _singleton;

	public float volume
	{
		get
		{
			return _volume;
		}
		set
		{
			_volume = value;
			for (int i = 0; i < ambience.Count; i++)
			{
				ambience[i].targetVolume = ambience[i].defaultVolume * _volume;
			}
		}
	}

	public static AmbianceController singleton => _singleton;

	public void AddAmbient(string id)
	{
		if (id == null)
		{
			return;
		}
		if (prefabDict.ContainsKey(id))
		{
			Music music = Object.Instantiate(prefabDict[id]);
			music.targetVolume = music.defaultVolume * _volume;
			ambience.Add(music);
			music.Play(fadeInDuration);
			if (ambience.Count > 4)
			{
				music = ambience[0];
				ambience.RemoveAt(0);
				music.Stop(0f);
			}
		}
		else
		{
			if (pendingAsync.Contains(id))
			{
				return;
			}
			pendingAsync.Add(id);
			AsyncOperationHandle<GameObject> loadHandler = Addressables.LoadAssetAsync<GameObject>("Ambient/" + id);
			loadHandler.Completed += delegate
			{
				if ((bool)loadHandler.Result)
				{
					Music component = loadHandler.Result.GetComponent<Music>();
					prefabDict.Add(id, component);
					AddAmbient(id);
				}
				pendingAsync.Remove(id);
			};
		}
	}

	public void StopAllAmbient(float fadeDurationOverride = -1f)
	{
		for (int i = 0; i < ambience.Count; i++)
		{
			if (fadeDurationOverride > 0f)
			{
				ambience[i].Stop(fadeDurationOverride);
			}
			else
			{
				ambience[i].Stop(fadeOutDuration);
			}
		}
		ambience.Clear();
	}

	public string GetCurrentAmbientIDs()
	{
		if (ambience.Count <= 0)
		{
			return "";
		}
		string text = ambience[0].id;
		for (int i = 1; i < ambience.Count; i++)
		{
			text = text + "," + ambience[i].id;
		}
		return text;
	}

	private void InitDictionary()
	{
		for (int i = 0; i < ambiantList.Length; i++)
		{
			Music music = ambiantList[i];
			if (!(music == null))
			{
				string id = music.id;
				if (prefabDict.ContainsKey(id))
				{
					Utils.LogError("Multiple music entries with the same id '" + id + "', please fix.");
				}
				else
				{
					prefabDict.Add(id, music);
				}
			}
		}
	}

	private void Awake()
	{
		_singleton = this;
		InitDictionary();
	}
}
