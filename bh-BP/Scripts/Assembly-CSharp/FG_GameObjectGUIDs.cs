using System;
using UnityEngine;

public class FG_GameObjectGUIDs : MonoBehaviour
{
	[NonSerialized]
	public static bool _dirty;

	[HideInInspector]
	public string[] guids;

	[HideInInspector]
	public UnityEngine.Object[] objects;

	private FG_GameObjectGUIDs()
	{
	}

	private void Awake()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}
}
