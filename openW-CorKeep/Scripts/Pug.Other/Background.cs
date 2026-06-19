using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
	public List<BackgroundType> BackgroundTypes;

	public Color StarGradientColor = Constants.RADICAL_PURPLE_G;

	public Color ClearingColorBehindBackground = Color.black;

	private BackgroundInfoBank backgroundInfoBank;

	private Dictionary<BackgroundType, GameObject> backgrounds;

	private Dictionary<BackgroundType, BackgroundInfo> backgroundInfosDict;

	private List<GameObject> currentBackgrounds;

	public void Awake()
	{
		backgrounds = new Dictionary<BackgroundType, GameObject>();
		backgroundInfosDict = new Dictionary<BackgroundType, BackgroundInfo>();
		currentBackgrounds = new List<GameObject>();
		backgroundInfoBank = Resources.Load<BackgroundInfoBank>("BackgroundInfoBank");
		if (backgroundInfoBank == null)
		{
			Debug.LogWarning("no background bank");
			return;
		}
		List<BackgroundInfo> backgroundInfos = backgroundInfoBank.BackgroundInfos;
		for (int i = 0; i < backgroundInfos.Count; i++)
		{
			backgroundInfosDict.Add(backgroundInfos[i].type, backgroundInfos[i]);
			if (backgroundInfos[i].initializeOnLoad)
			{
				InitializeBackground(backgroundInfos[i], backgroundInfos[i].layer);
			}
		}
	}

	public void Start()
	{
		SetBackgrounds(BackgroundTypes, StarGradientColor);
	}

	private void SetBackgrounds(List<BackgroundType> backgroundTypes, Color starGradientColor)
	{
		for (int i = 0; i < backgroundTypes.Count; i++)
		{
			BackgroundType backgroundType = backgroundTypes[i];
			GameObject gameObject = ((currentBackgrounds.Count > i) ? currentBackgrounds[i] : null);
			if (gameObject != null)
			{
				gameObject.SetActive(value: false);
			}
			if (backgroundType == BackgroundType.NONE)
			{
				if (gameObject != null)
				{
					currentBackgrounds[i] = null;
				}
				continue;
			}
			if (!backgrounds.TryGetValue(backgroundType, out var value))
			{
				if (!backgroundInfosDict.TryGetValue(backgroundType, out var value2))
				{
					Debug.LogError(backgroundTypes?.ToString() + " did not exist in the background infos dictionary.");
				}
				else
				{
					InitializeBackground(value2, i);
				}
			}
			if (backgrounds.TryGetValue(backgroundType, out value))
			{
				if (currentBackgrounds.Count <= i)
				{
					currentBackgrounds.Add(value);
				}
				else
				{
					currentBackgrounds[i] = value;
				}
				currentBackgrounds[i].SetActive(value: true);
				if (backgroundTypes[i] == BackgroundType.DARK_STARS)
				{
					currentBackgrounds[i].GetComponent<BackgroundDarkStars>().gradientRenderer.color = starGradientColor;
				}
			}
			else
			{
				Debug.LogError("Failed to load and/or initialize a background with type " + backgroundTypes);
			}
		}
	}

	private void InitializeBackground(BackgroundInfo backgroundInfo, int index)
	{
		GameObject gameObject = Object.Instantiate(backgroundInfo.prefab, Vector3.zero, Quaternion.identity, base.transform);
		backgrounds[backgroundInfo.type] = gameObject;
		gameObject.SetActive(value: false);
	}
}
