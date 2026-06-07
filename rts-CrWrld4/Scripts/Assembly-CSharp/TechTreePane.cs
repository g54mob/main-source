using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TechTreePane : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerDownHandler
{
	public TechItemDisplay bluite;

	public TechItemDisplay spark;

	public TechItemDisplay redon;

	public TechItemDisplay antiCreeper;

	public TechItemDisplay liftic;

	public TechItemDisplay arg;

	public TechItemDisplay resistium;

	public TechItemDisplay fluxygen;

	public TechItemDisplay tuffium;

	public Text packetAmtBluite;

	public Text packetAmtSpark;

	public Text packetAmtRedon;

	public Text packetAmtACResistium;

	public Text packetAmtACSprayer;

	public Text packetAmtArgFluxygen;

	public Text packetAmtArgMissileLauncher;

	public Text packetAmtLifticResistium;

	public Text packetAmtLifticFluxygen;

	public Text packetAmtLifticSprayer;

	public Text packetAmtLifticMissileLauncher;

	public Text packetAmtResistiumTuffium;

	public Text packetAmtFluxygenTuffium;

	public Text packetAmtFluxygenMicrorift;

	public Text packetAmtTuffiumFatMan;

	private int[,] planTotals;

	private Dictionary<string, int> packetWareTotals;

	private Vector2 pointerOffset;

	private RectTransform canvasRectTransform;

	private RectTransform panelRectTransform;

	private void Awake()
	{
	}

	public void OnPointerDown(PointerEventData data)
	{
	}

	public void OnDrag(PointerEventData data)
	{
	}

	private Vector2 ClampToWindow(PointerEventData data)
	{
		return default(Vector2);
	}

	private void Update()
	{
	}

	private void GetPacketWareTotals()
	{
	}

	private void GetPlanTotals()
	{
	}
}
