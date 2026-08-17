using System;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

[Serializable]
public class ProCamera2DParallaxLayer
{
	public Camera ParallaxCamera;

	public float Speed = 1f;

	public float SpeedX = 1f;

	public float SpeedY = 1f;

	public LayerMask LayerMask;

	[NonSerialized]
	public Transform CameraTransform;
}
