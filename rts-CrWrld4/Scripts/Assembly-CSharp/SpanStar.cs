using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpanStar : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public GameObject linePrefab;

	public Transform lineContainer;

	public TextMeshPro title;

	public Span span;

	public string starGUID;

	public string completionPlanet;

	public string[] connectedStarGUIDS;

	public bool showConnectedLines;

	private List<SpanNetworkPlanetLine> lines;

	public Color activeLineColor0;

	public Color activeLineColor1;

	public Color inactiveLineColor0;

	public Color inactiveLineColor1;

	private bool _unlocked;

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

	public void Awake()
	{
	}

	public void Start()
	{
	}

	public void Refresh()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}
}
