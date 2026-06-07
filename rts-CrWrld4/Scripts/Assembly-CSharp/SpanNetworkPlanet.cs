using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpanNetworkPlanet : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public GameObject spanNetworkPlanetObjectivePrefab;

	public Color completionBronzeColor;

	public Color completionSilverColor;

	public Color completionGoldColor;

	public Color activeLineColor0;

	public Color activeLineColor1;

	public Color inactiveLineColor0;

	public Color inactiveLineColor1;

	public Material incompleteMaterial;

	public Material completeMaterial;

	public GameObject linePrefab;

	public GameObject selectedIndicator;

	public Transform lineContainer;

	public Transform planet;

	public Transform lockedPlanet;

	public TextMeshPro title;

	public GameObject completionIndicator;

	public Span span;

	public string planetGUID;

	public int textureID;

	public string[] connectedPlanetGUIDS;

	public bool[] forceObjectives;

	public bool showConnectedLines;

	public Transform objectiveContainer;

	public bool forceUnlocked;

	private List<SpanNetworkPlanetLine> lines;

	private float rotationRate;

	private float selectedIndicatorRotationRate;

	[NonSerialized]
	public int map_width;

	[NonSerialized]
	public int map_height;

	[NonSerialized]
	public string map_version;

	[NonSerialized]
	public string map_title;

	[NonSerialized]
	public string map_desc;

	[NonSerialized]
	public string map_guid;

	[NonSerialized]
	public byte map_objectives;

	private bool unlockedSet;

	private bool _unlocked;

	private bool _selected;

	public bool unlocked
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public void Reset()
	{
	}

	public void Awake()
	{
	}

	public void Start()
	{
	}

	public void Refresh()
	{
	}

	private bool FakeIsMissionObjectiveComplete(string guid, int obj)
	{
		return false;
	}

	public static float GetRadiusFromArea(int area)
	{
		return 0f;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	private void Update()
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}
}
