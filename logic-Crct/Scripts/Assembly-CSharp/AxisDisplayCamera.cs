using UnityEngine;

[ExecuteInEditMode]
public class AxisDisplayCamera : MonoBehaviour
{
	private static AxisDisplayCamera inst;

	public bool desktop;

	public RectTransform refRect;

	public Vector2 pixelSize;

	public Vector2 position;

	private Camera cam;

	public float refHeight;

	public float refWidth;

	private float refScale;

	private Vector2 actualPxSize;

	private float aspect;

	public float aspectThreshold;

	public static float ScalingFactor;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
