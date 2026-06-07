using System;
using UnityEngine;

public class TMProBillboard : MonoBehaviour
{
	private Camera cam;

	public float localOffsetZ;

	[NonSerialized]
	public bool anchor;

	[NonSerialized]
	public Vector3 anchorPos;

	private Vector3 startPos;

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}
}
