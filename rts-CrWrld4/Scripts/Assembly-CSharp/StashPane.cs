using System;
using UnityEngine;
using UnityEngine.UI;

public class StashPane : MonoBehaviour
{
	[NonSerialized]
	public Camera cam;

	[NonSerialized]
	public Stash stash;

	public Text amtText;

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

	private string GetCreeperString(long amt)
	{
		return null;
	}
}
