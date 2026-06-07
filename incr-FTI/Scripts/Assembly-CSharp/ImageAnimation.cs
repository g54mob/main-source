using System;
using UnityEngine;

public class ImageAnimation : MonoBehaviour
{
	private RectTransform rectTransform;

	private Vector3 startPosition;

	private float elapsedTime;

	public float animationDuration = 4f;

	public Vector2 animationVector;

	public Vector3 rotationVector;

	public float scaleFactor;

	private void Start()
	{
		rectTransform = (RectTransform)base.transform;
		startPosition = rectTransform.anchoredPosition;
	}

	private void Update()
	{
		elapsedTime += Time.deltaTime;
		float num = Mathf.Sin(MathF.PI * 2f * (elapsedTime / animationDuration));
		float num2 = Mathf.Lerp(-1f, 1f, (num + 1f) * 0.5f);
		rectTransform.anchoredPosition = startPosition + new Vector3(animationVector.x * num2, animationVector.y * num2, 0f);
		rectTransform.localRotation = Quaternion.Euler(new Vector3(rotationVector.x * num2, rotationVector.y * num2, rotationVector.z * num2));
		if (scaleFactor > 0f)
		{
			float t = (num + 1f) * 0.5f;
			float num3 = Mathf.Lerp(1f, scaleFactor, t);
			rectTransform.localScale = new Vector3(num3, num3, num3);
		}
	}
}
