using System;
using UnityEngine;

public class MapIndicatorLine : MonoBehaviour
{
	public GameObject quad;

	public GameObject source;

	[NonSerialized]
	public Vector3 targetPosition;

	private LineRenderer lr;

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}
}
