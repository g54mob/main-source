using System;
using UnityEngine;

public class TotemPane : MonoBehaviour
{
	public GameObject totemPaneRowPrefab;

	public GameObject rowContainer;

	[NonSerialized]
	public Camera cam;

	[NonSerialized]
	public UnitManager unit;

	private Vector3 totemPaneOffset;

	private Canvas canvas;

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	public void Refresh()
	{
	}
}
