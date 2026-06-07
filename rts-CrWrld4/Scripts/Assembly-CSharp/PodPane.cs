using System;
using TMPro;
using UnityEngine;

public class PodPane : MonoBehaviour
{
	[NonSerialized]
	public Camera cam;

	[NonSerialized]
	public Pod pod;

	public TMP_Text typeText;

	public TMP_Text amtText;

	private Vector3 podPaneOffset;

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
