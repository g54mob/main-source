using System;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
[ExecuteInEditMode]
public class CustomCanvasResolution : MonoBehaviour
{
	public bool size800x450;

	private Canvas canvas;

	private RectTransform rectTransform;

	private Vector2 baseSize = new Vector2(640f, 360f);

	private bool wantUpdate;

	private void OnEnable()
	{
		if (size800x450)
		{
			baseSize = new Vector2(Resolution.bufferW, Resolution.bufferH);
		}
		canvas = GetComponent<Canvas>();
		canvas.renderMode = RenderMode.WorldSpace;
		rectTransform = GetComponent<RectTransform>();
		wantUpdate = true;
	}

	private void Update()
	{
		if (wantUpdate)
		{
			Camera worldCamera = canvas.worldCamera;
			float num = 0f;
			num = ((!worldCamera.orthographic) ? (0.5f / Mathf.Tan((float)Math.PI / 180f * worldCamera.fieldOfView * 0.5f)) : ((worldCamera.nearClipPlane + worldCamera.farClipPlane) * 0.5f));
			rectTransform.position = worldCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, num));
			rectTransform.sizeDelta = baseSize;
			float num2 = 1f / (float)Resolution.bufferH;
			rectTransform.localScale = num2 * Vector3.one;
			wantUpdate = false;
		}
	}
}
