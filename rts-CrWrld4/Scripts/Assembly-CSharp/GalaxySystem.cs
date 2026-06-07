using System;
using TMPro;
using UnityEngine;

public class GalaxySystem : MonoBehaviour
{
	public GameObject galaxySystemLinePrefab;

	public GalaxySector galaxySector;

	public string[] worlds;

	public GameObject planetContainer;

	public Light light;

	public GameObject indicator;

	public GameObject currentIndicator;

	public TextMeshPro titleText;

	public GameObject[] connections;

	[NonSerialized]
	public bool procedural;

	[NonSerialized]
	public bool currentSystem;

	private GalaxyPlanet[] galaxyPlanets;

	private float startD;

	private float planetD;

	private float planetSpeed;

	private float viewDistance;

	private float zoomSpeed;

	private bool zoomingIn;

	private bool zoomingOut;

	public GameObject lineContainer;

	private LineRenderer[] lines;

	private Camera mainCam;

	private float _zoomPos;

	private int hilightCount;

	private bool _hilight;

	private bool _zoomed;

	private string _title;

	private float zoomPos
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool hilight
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool zoomed
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool titleVisible
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public string title
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void Awake()
	{
	}

	public void Start()
	{
	}

	public void SetName(string val)
	{
	}

	public void CreateConnections()
	{
	}

	private void CreatePlanets()
	{
	}

	private GameObject GetObjectUnderMouse()
	{
		return null;
	}

	public void Update()
	{
	}
}
