using System;
using TMPro;
using UnityEngine;

public class MouseOverPanePopup : MonoBehaviour
{
	[NonSerialized]
	public Camera cam;

	[NonSerialized]
	public UnitManager unit;

	[NonSerialized]
	public Transform fallbackTransform;

	public TMP_Text text0;

	public TMP_Text text1;

	protected Vector3 paneOffset;

	private Canvas canvas;

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	public virtual void Refresh()
	{
	}
}
