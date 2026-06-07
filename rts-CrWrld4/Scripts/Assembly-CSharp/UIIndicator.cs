using System;
using UnityEngine;

public class UIIndicator : MonoBehaviour
{
	public float maxSize;

	public float minSize;

	public float time;

	private float counter;

	private string indicatorName;

	[NonSerialized]
	public int deathCounter;

	private int hideUIOverrideInitialVal;

	public static UIIndicator CreateUIIndicator(string indicatorName, string control)
	{
		return null;
	}

	public static UIIndicator CreateUIIndicator(string indicatorName, Vector2 pos)
	{
		return null;
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	public void SetPosition(Vector2 pos)
	{
	}

	private void Update()
	{
	}

	public void DestroyUIIndicator()
	{
	}
}
