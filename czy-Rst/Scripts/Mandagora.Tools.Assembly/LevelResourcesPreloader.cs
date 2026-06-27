using System.Collections.Generic;
using Mandragora.AnimationTools;
using Mandragora.ResourceUtils;
using UnityEngine;

public class LevelResourcesPreloader : MonoBehaviour
{
	public string[] preloadObjectsList;

	public List<GameObjectLinkBank> gameObjectLinkBanks;

	public List<AudioClipLinkBank> soundLinkBanks;

	public List<SpriteLinkBank> spriteLinkBanks;

	public List<AnimationDataLinkBank> animationDataLinkBanks;

	public Dictionary<string, Object> objectsStorage = new Dictionary<string, Object>();

	public Dictionary<string, Sprite> spritesStorage = new Dictionary<string, Sprite>();

	public Dictionary<string, AudioClip> soundStorage = new Dictionary<string, AudioClip>();

	public Dictionary<string, AnimationDataAsset> animationDataStorage = new Dictionary<string, AnimationDataAsset>();

	private static LevelResourcesPreloader _instance;

	public static LevelResourcesPreloader getInstance()
	{
		if (_instance == null)
		{
			GameObject gameObject = GameObject.Find("LevelResourcesPreloader");
			if (gameObject != null)
			{
				_instance = gameObject.GetComponent<LevelResourcesPreloader>();
			}
			else
			{
				gameObject = new GameObject("LevelResourcesPreloader");
				_instance = gameObject.AddComponent<LevelResourcesPreloader>();
			}
		}
		return _instance;
	}

	private void Awake()
	{
		if (preloadObjectsList != null && preloadObjectsList.Length != 0)
		{
			string[] array = preloadObjectsList;
			foreach (string objectPath in array)
			{
				preloadResourceObject(objectPath);
			}
		}
		preloadLinkBanks();
		Resources.UnloadUnusedAssets();
	}

	private void clean()
	{
		objectsStorage.Clear();
		spritesStorage.Clear();
		soundStorage.Clear();
		animationDataStorage.Clear();
		Resources.UnloadUnusedAssets();
	}

	public void preloadLinkBanks()
	{
		_ = Time.realtimeSinceStartup;
		if (gameObjectLinkBanks != null && gameObjectLinkBanks.Count > 0)
		{
			for (int i = 0; i < gameObjectLinkBanks.Count; i++)
			{
				foreach (ResourceData item in gameObjectLinkBanks[i].list)
				{
					string key = item.Path.Replace("Resources/gameplay", "gameplay");
					if (!objectsStorage.ContainsKey(key))
					{
						objectsStorage.Add(key, item.Resource as GameObject);
					}
				}
			}
		}
		if (soundLinkBanks != null && soundLinkBanks.Count > 0)
		{
			for (int j = 0; j < soundLinkBanks.Count; j++)
			{
				foreach (ResourceData item2 in soundLinkBanks[j].list)
				{
					string key2 = item2.Path.Replace("Resources/sound", "sound");
					if (!soundStorage.ContainsKey(key2))
					{
						soundStorage.Add(key2, item2.Resource as AudioClip);
					}
				}
			}
		}
		if (spriteLinkBanks != null && spriteLinkBanks.Count > 0)
		{
			for (int k = 0; k < spriteLinkBanks.Count; k++)
			{
				foreach (ResourceData item3 in spriteLinkBanks[k].list)
				{
					string path = item3.Path;
					if (!spritesStorage.ContainsKey(path))
					{
						spritesStorage.Add(path, item3.Resource as Sprite);
					}
				}
			}
		}
		if (animationDataLinkBanks == null || animationDataLinkBanks.Count <= 0)
		{
			return;
		}
		for (int l = 0; l < animationDataLinkBanks.Count; l++)
		{
			foreach (ResourceData item4 in animationDataLinkBanks[l].list)
			{
				string path2 = item4.Path;
				if (!animationDataStorage.ContainsKey(path2))
				{
					animationDataStorage.Add(path2, item4.Resource as AnimationDataAsset);
				}
			}
		}
	}

	public static Object getObject(string objectPath)
	{
		getInstance().preloadResourceObject(objectPath);
		return getInstance().objectsStorage[objectPath];
	}

	public static AudioClip getSound(string soundPath)
	{
		getInstance().preloadSound(soundPath);
		if (!getInstance().soundStorage.ContainsKey(soundPath))
		{
			Debug.LogError("can't load sound with path: " + soundPath);
			return null;
		}
		return getInstance().soundStorage[soundPath];
	}

	public static Sprite getSprite(string spritePath)
	{
		getInstance().preloadLinkBanks();
		if (!getInstance().spritesStorage.ContainsKey(spritePath))
		{
			Debug.LogError("can't load sprite with path: " + spritePath);
			return null;
		}
		return getInstance().spritesStorage[spritePath];
	}

	public static AnimationDataAsset getAnimationData(string dataPath)
	{
		getInstance().preloadLinkBanks();
		return getInstance().animationDataStorage[dataPath];
	}

	public void preloadResourceObject(string objectPath)
	{
		if (!objectsStorage.ContainsKey(objectPath))
		{
			objectsStorage.Add(objectPath, Resources.Load(objectPath));
		}
	}

	public void preloadSprite(string objectPath)
	{
		if (!spritesStorage.ContainsKey(objectPath))
		{
			Debug.Log(objectPath);
			spritesStorage.Add(objectPath, Resources.Load<Sprite>(objectPath));
		}
	}

	private void preloadSound(string soundPath)
	{
		if (!soundStorage.ContainsKey(soundPath))
		{
			soundStorage.Add(soundPath, Resources.Load<AudioClip>(soundPath));
		}
	}

	public static GameObject GenerateObject(Vector3 _pos, Vector3 _eulerAngles, string _prefabPath, Transform _parent = null)
	{
		if (string.IsNullOrEmpty(_prefabPath))
		{
			return null;
		}
		getObject(_prefabPath);
		return null;
	}

	private void OnDestroy()
	{
		clean();
		_instance = null;
	}
}
