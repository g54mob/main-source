using System;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryPadPane : MonoBehaviour
{
	[NonSerialized]
	public Camera cam;

	[NonSerialized]
	public DeliveryPad deliveryPad;

	public Text valueText;

	private Vector3 deliveryPadPaneOffset;

	private void LateUpdate()
	{
	}

	public void Refresh()
	{
	}
}
