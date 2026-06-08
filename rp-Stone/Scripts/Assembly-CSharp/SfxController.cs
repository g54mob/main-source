using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SfxController : MonoBehaviour
{
	private readonly bool PRINT_ALL_SOUND_IDS;

	public Sfx[] sfxList;

	private Dictionary<string, Sfx> prefabDict = new Dictionary<string, Sfx>();

	private Dictionary<string, Sfx> nextPooled = new Dictionary<string, Sfx>();

	private List<string> sfxThisFrame = new List<string>();

	private List<string> pendingAsync = new List<string>();

	private static SfxController _singleton;

	public float muteDuration { get; set; }

	public float volume { get; set; }

	public static SfxController singleton => _singleton;

	private void Update()
	{
		sfxThisFrame.Clear();
		muteDuration = Mathf.Max(0f, muteDuration - Time.deltaTime);
	}

	public Sfx Play(string sfxId, bool ignoreDuplicateSfxInSameFrame = true, float delay = 0f)
	{
		if (muteDuration > 0f)
		{
			return null;
		}
		Sfx sfx = null;
		if (!string.IsNullOrEmpty(sfxId) && (!ignoreDuplicateSfxInSameFrame || !sfxThisFrame.Contains(sfxId)))
		{
			if (prefabDict.ContainsKey(sfxId))
			{
				if (ignoreDuplicateSfxInSameFrame)
				{
					sfxThisFrame.Add(sfxId);
				}
				Sfx sfx2 = prefabDict[sfxId];
				float num = volume;
				if (!AdditionalSettings.isBackgroundSfx && !Application.isFocused)
				{
					num = 0f;
				}
				if (nextPooled.ContainsKey(sfxId) && nextPooled[sfxId] != null)
				{
					sfx = nextPooled[sfxId];
					nextPooled[sfxId] = null;
					sfx.Play(delay, num);
				}
				else
				{
					sfx = Object.Instantiate(sfx2);
					sfx.Play(delay, num);
				}
				Preload(sfx2);
			}
			else
			{
				if (pendingAsync.Contains(sfxId))
				{
					return null;
				}
				pendingAsync.Add(sfxId);
				AsyncOperationHandle<GameObject> loadHandler = Addressables.LoadAssetAsync<GameObject>("sfx_" + sfxId);
				loadHandler.Completed += delegate
				{
					if ((bool)loadHandler.Result)
					{
						Sfx component = loadHandler.Result.GetComponent<Sfx>();
						prefabDict.Add(sfxId, component);
						float num2 = volume;
						if (!AdditionalSettings.isBackgroundSfx && !Application.isFocused)
						{
							num2 = 0f;
						}
						sfx = Object.Instantiate(component);
						sfx.Play(delay, num2);
						Preload(component);
					}
					pendingAsync.Remove(sfxId);
				};
			}
		}
		return sfx;
	}

	public void Preload(Sfx sfxPrefab)
	{
		string id = sfxPrefab.id;
		if (!nextPooled.ContainsKey(id) || !(nextPooled[id] != null))
		{
			Sfx value = Object.Instantiate(sfxPrefab);
			if (nextPooled.ContainsKey(id))
			{
				nextPooled[id] = value;
			}
			else
			{
				nextPooled.Add(id, value);
			}
		}
	}

	public void Preload(string sfxId)
	{
		if (prefabDict.ContainsKey(sfxId))
		{
			Preload(prefabDict[sfxId]);
			return;
		}
		AsyncOperationHandle<GameObject> loadHandler = Addressables.LoadAssetAsync<GameObject>("sfx_" + sfxId);
		LoadingAccountant.Add(loadHandler);
		loadHandler.Completed += delegate
		{
			if ((bool)loadHandler.Result)
			{
				Sfx component = loadHandler.Result.GetComponent<Sfx>();
				if (!prefabDict.ContainsKey(sfxId))
				{
					prefabDict.Add(sfxId, component);
				}
				Preload(sfxId);
			}
		};
	}

	public bool HasPreloaded(string sfxId)
	{
		return nextPooled.ContainsKey(sfxId);
	}

	public void StopAllSfx()
	{
		Sfx[] array = Object.FindObjectsOfType<Sfx>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
	}

	private void Start()
	{
		string text = "";
		for (int i = 0; i < sfxList.Length; i++)
		{
			Sfx sfx = sfxList[i];
			if (!(sfx == null))
			{
				string id = sfx.id;
				if (PRINT_ALL_SOUND_IDS)
				{
					text = text + "\n" + id;
				}
				if (prefabDict.ContainsKey(id))
				{
					Utils.LogError("Multiple SFX entries with the same id '" + id + "', please fix.");
				}
				else
				{
					prefabDict.Add(id, sfx);
				}
			}
		}
		if (PRINT_ALL_SOUND_IDS)
		{
			Debug.LogError(text);
		}
	}

	private void Awake()
	{
		_singleton = this;
		volume = 1f;
	}
}
