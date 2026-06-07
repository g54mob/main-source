using System;
using UnityEngine;

public class InteractableSlider : Interactable
{
	public enum Axis
	{
		X = 0,
		Y = 1
	}

	public Transform handleTransform;

	public PixelShape scrollPixelShape;

	[NonSerialized]
	[HideInInspector]
	public float value;

	public Vector2 origin;

	public float length;

	public Axis axis;

	public float rotation;

	private float scroolSpeed;

	private Vector3 handleZeroPosition;

	private Vector2 dragMouseOffest;

	private float dragStartValue;

	private void Awake()
	{
	}

	public override void OnInteractionDown()
	{
	}

	public void RefreshPosition()
	{
	}

	public override void Update()
	{
	}
}
