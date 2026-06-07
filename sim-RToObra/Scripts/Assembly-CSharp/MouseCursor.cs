using UnityEngine;
using UnityEngine.UI;

public class MouseCursor : MonoBehaviour
{
	private class PendingPosInTransform
	{
		public Transform transform;

		public Vector2 pos;
	}

	private Image image;

	private RectTransform rt;

	private Canvas canvas;

	private static MouseCursor it;

	public static bool debugHide;

	private static int hideUntilFrame = -1;

	private static PendingPosInTransform pendingPosInTransform;

	private void Awake()
	{
		image = GetComponent<Image>();
		rt = base.transform as RectTransform;
		canvas = GetComponentInParent<Canvas>();
	}

	private void OnEnable()
	{
		it = this;
		rt.sizeDelta = new Vector2(16f, 16f);
	}

	private void OnDisable()
	{
		it = null;
	}

	private void Update()
	{
		if (pendingPosInTransform != null)
		{
			SetPosInTransform(pendingPosInTransform.transform, pendingPosInTransform.pos);
		}
		image.enabled = hideUntilFrame < Time.frameCount && !debugHide && RInput.mouseIsActive;
		Vector2 posInCanvas = GetPosInCanvas();
		posInCanvas.x = Mathf.Round(posInCanvas.x * 1.25f) / 1.25f;
		posInCanvas.y = Mathf.Round(posInCanvas.y * 1.25f) / 1.25f;
		rt.localPosition = posInCanvas;
	}

	public static void HideForOneFrame()
	{
		hideUntilFrame = Time.frameCount + 2;
		if (it != null)
		{
			it.image.enabled = false;
		}
	}

	public static Vector2 GetPosInCanvas()
	{
		Vector3 vector = new Vector3((RInput.mousePosition.x / (float)Resolution.screenW - 0.5f) * (float)Resolution.bufferW, (RInput.mousePosition.y / (float)Resolution.screenH - 0.5f) * (float)Resolution.bufferH, 0f);
		return vector;
	}

	public static void SetPosInCanvas(Vector2 pos)
	{
		Vector2 vector = pos;
		Vector2 mousePosition = new Vector2((vector.x / (float)Resolution.bufferW + 0.5f) * (float)Resolution.screenW, (vector.y / (float)Resolution.bufferH + 0.5f) * (float)Resolution.screenH);
		RInput.mousePosition = mousePosition;
		it.Update();
	}

	public static Vector2 GetPosInTransform(Transform transform)
	{
		if (it == null)
		{
			return Vector2.zero;
		}
		Vector3 point = new Vector3((RInput.mousePosition.x / (float)Resolution.screenW - 0.5f) * (float)Resolution.bufferW, (RInput.mousePosition.y / (float)Resolution.screenH - 0.5f) * (float)Resolution.bufferH, 0f);
		Vector3 point2 = it.canvas.transform.localToWorldMatrix.MultiplyPoint(point);
		return transform.worldToLocalMatrix.MultiplyPoint(point2).ToVector2XY();
	}

	public static void SetPosInTransform(Transform transform, Vector2 pos)
	{
		if (it == null)
		{
			pendingPosInTransform = new PendingPosInTransform();
			pendingPosInTransform.transform = transform;
			pendingPosInTransform.pos = pos;
			return;
		}
		pendingPosInTransform = null;
		Vector3 point = transform.localToWorldMatrix.MultiplyPoint(pos);
		Vector3 vector = it.canvas.transform.worldToLocalMatrix.MultiplyPoint(point);
		Vector2 mousePosition = new Vector2((vector.x / (float)Resolution.bufferW + 0.5f) * (float)Resolution.screenW, (vector.y / (float)Resolution.bufferH + 0.5f) * (float)Resolution.screenH);
		RInput.mousePosition = mousePosition;
		it.Update();
	}
}
