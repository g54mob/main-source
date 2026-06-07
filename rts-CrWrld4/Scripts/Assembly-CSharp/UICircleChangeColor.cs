using UnityEngine;

public class UICircleChangeColor : MonoBehaviour
{
	public GameObject TargetUICircle;

	private Color baseColor;

	private Color progressColor;

	private float r;

	private float g;

	private float b;

	private float factor;

	private void Awake()
	{
	}

	public void UpdateBaseColor(float value)
	{
	}

	public void UpdateProgressColor(float value)
	{
	}

	private Color SetFixedColor(float value, float alpha)
	{
		return default(Color);
	}
}
