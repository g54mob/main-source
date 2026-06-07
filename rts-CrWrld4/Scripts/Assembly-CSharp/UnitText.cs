using System;
using UnityEngine;
using UnityEngine.UI;

public class UnitText : MonoBehaviour
{
	public Text text;

	[NonSerialized]
	public Vector3 offset;

	[NonSerialized]
	public GameObject unit;

	private Vector3 unitHeightOffset;

	private bool _visible;

	private Canvas canvas;

	private bool visible
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void LateUpdate()
	{
	}

	public void Init(GameObject unit)
	{
	}

	public void SetText(string val)
	{
	}

	public string GetText()
	{
		return null;
	}
}
