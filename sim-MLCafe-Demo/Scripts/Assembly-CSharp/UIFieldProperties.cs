using System;
using UnityEngine;

[Serializable]
public class UIFieldProperties
{
	public string sound = "";

	public Color color = Color.white;

	public Color borderColor = Color.white;

	public bool useCanvasGroupOpacity;

	public float opacity = 1f;

	public bool usePosition;

	public Vector3 position = Vector3.zero;

	public bool useSize;

	public Vector3 size = Vector3.one;

	public bool overideLabelColor;

	public Color labelColor = Color.white;

	public bool overideIconColor;

	public Color iconColor = Color.white;

	public UIFieldInvokePoint[] invokePoints;

	[Tooltip("Only for UIContentAnimator / AnimateContent() usage")]
	public bool useCustomCurve;

	public AnimationCurve animationCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));

	public void ResetInvokePoints()
	{
		UIFieldInvokePoint[] array = invokePoints;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].fired = false;
		}
	}
}
