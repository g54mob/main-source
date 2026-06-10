using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class DDSControls : MonoBehaviour
{
	[ReorderableList]
	[Header("Sprites")]
	public List<Sprite> backgroundSprites;

	[Header("Fonts")]
	public TMP_FontAsset defaultHandwritingFont;

	public TMP_FontAsset clearModeFont;

	[ReorderableList]
	public List<TMP_FontAsset> fonts;

	[Header("Elements")]
	public GameObject textComponent;

	public GameObject elementPrefab;

	[ReorderableList]
	public List<GameObject> elementPrefabs;

	[Header("Import")]
	public string sourcePath;

	private static DDSControls _instance;

	public static DDSControls Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ListUnusedDDSTrees()
	{
	}
}
