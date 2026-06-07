using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegionNav : MonoBehaviour
{
	public enum REGION_TYPE
	{
		STORY = 0,
		ALPHA = 1,
		GENERATED = 2,
		ONLINE = 3
	}

	public delegate void CloseCallback();

	public class MapEntry
	{
		public enum ENTRY_TYPE
		{
			BUILTIN = 0,
			ONLINE = 1
		}

		public ENTRY_TYPE entryType;

		public string specifier;

		public string mapName;

		public Vector3 regionCoords;

		public float starSize;

		public MapEntry(ENTRY_TYPE entryType, string specifier, string mapName, Vector3 regionCoords, float starSize)
		{
		}
	}

	public TextMeshProUGUI titleText;

	public GameObject listRowPrefab;

	public GameObject starPrefab;

	public GameObject listContainer;

	public SaveListBox saveListBox;

	public RawImage mapPreview;

	public TextMeshProUGUI mapTitle;

	public TextMeshProUGUI mapDesc;

	public GameObject planetContainer;

	public Transform eclipticRawImage;

	public GameObject eclipticStarContainer;

	[NonSerialized]
	public GameSpace.CATEGORY category;

	private List<MapEntry> mapEntries;

	public GameObject launchButton;

	public GameObject loadButton;

	public CloseCallback closeCallback;

	public const float MINSTARSIZE = 0.5f;

	public const float MAXSTARSIZE = 1.5f;

	private const float MAX_X_POS = 1f;

	private const float MAX_Y_POS = 0.5f;

	private const float MAX_Z_POS = 1f;

	private MapEntry _selectedMapEntry;

	private Color32[] spectrumColors;

	private RegionStar lastRegionStarOver;

	private MapEntry selectedMapEntry
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void Show(GameSpace.CATEGORY category, CloseCallback closeCallback = null)
	{
	}

	public void Hide()
	{
	}

	private RegionStar RaycastStars()
	{
		return null;
	}

	public void LateUpdate()
	{
	}

	public void OnClose()
	{
	}

	public void SetMapEntries(string title, List<MapEntry> mapEntries)
	{
	}

	private void RefreshStarMap()
	{
	}

	private void RefreshList()
	{
	}

	public void SelectMapEntryFromSpecifier(string specifier)
	{
	}

	public void SelectMapEntry(MapEntry me)
	{
	}

	public void OnLaunchMission()
	{
	}

	public void OnOpenSavedGamesList()
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}

	public static float RandomSize(int seed)
	{
		return 0f;
	}

	private Color32 ColorFromSize(float size)
	{
		return default(Color32);
	}
}
