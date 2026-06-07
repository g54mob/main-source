using System;
using TMPro;
using UnityEngine;

public class UnitPopupInfoPane : MonoBehaviour
{
	public TextMeshProUGUI messageText;

	[NonSerialized]
	public Camera cam;

	[NonSerialized]
	public GameObject unit;

	[NonSerialized]
	private Vector3 paneOffset;

	private string _message;

	private Canvas canvas;

	public string message
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public static UnitPopupInfoPane Show(GameObject unit, string message)
	{
		return null;
	}

	private void Awake()
	{
	}

	public void LateUpdate()
	{
	}

	public void DestroyPane()
	{
	}
}
