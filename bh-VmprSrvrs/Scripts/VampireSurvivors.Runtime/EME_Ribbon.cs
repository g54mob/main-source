using Dreamteck.Splines;
using UnityEngine;

[ExecuteAlways]
public class EME_Ribbon : MonoBehaviour
{
	[SerializeField]
	private SplineRenderer _SplineRenderer;

	[SerializeField]
	private SplineComputer _SplineComputer;

	[SerializeField]
	private Vector2 LerpDistanceMinMax;

	[SerializeField]
	private float _SpineRendererMinSize;

	[SerializeField]
	private float _SpineRendererMaxSize;

	[Header("Target Settings")]
	public Transform Target;

	[Header("Transform References")]
	[SerializeField]
	private Transform ChildTransform;

	[SerializeField]
	private Transform MidpointTransform;

	[Header("Midpoint Settings")]
	public float AdditionalHeight;

	public float LerpDistance;

	[Header("Fade Settings")]
	[SerializeField]
	[Range(0f, 1f)]
	private float FadeIn;

	[SerializeField]
	[Range(0f, 1f)]
	private float FadeOut;

	private ColorModifier _colorModifier;

	public void SetStartPosition(Vector3 position)
	{
	}

	public void SetEndPosition(Vector3 position)
	{
	}

	public void SetFadeIn(float value)
	{
	}

	public void SetFadeOut(float value)
	{
	}

	private void Start()
	{
	}

	private void LateUpdate()
	{
	}

	private void UpdateMidpointPosition()
	{
	}
}
