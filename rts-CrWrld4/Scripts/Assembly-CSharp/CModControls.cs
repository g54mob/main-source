using System;
using System.Collections.Generic;
using UnityEngine;

public class CModControls : MonoBehaviour
{
	public GameObject labelPrefab;

	public GameObject buttonPrefab;

	public GameObject flipPrefab;

	public GameObject choicePrefab;

	public Transform container;

	[NonSerialized]
	public bool dirtyText;

	[NonSerialized]
	public bool dirtyAll;

	private CModUnitControl[] controls;

	private CMod cmod;

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	public void Update()
	{
	}

	public void RefreshText()
	{
	}

	private bool IsSame(List<string> list1, List<string> list2)
	{
		return false;
	}

	private void Refresh()
	{
	}

	private void OnChange(int slot, int state)
	{
	}

	public static void DestroyChildren(Transform transform)
	{
	}
}
