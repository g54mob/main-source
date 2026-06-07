using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class VirtualCursorVisual : MonoBehaviour
{
	[Header("References")]
	public RectTransform cursorRect;

	public Canvas canvas;

	public VirtualMouseInput virtualMouseInput;

	[Header("Smoothing")]
	[Range(0f, 0.2f)]
	public float smoothTime = 0.05f;

	private Vector2 velocity;

	private void LateUpdate()
	{
		if (!(cursorRect == null) && !(canvas == null) && !(virtualMouseInput == null))
		{
			Mouse virtualMouse = virtualMouseInput.virtualMouse;
			if (virtualMouse != null)
			{
				RectTransformUtility.ScreenPointToLocalPointInRectangle(screenPoint: (Mouse.current == null || !(Mouse.current.delta.ReadValue().sqrMagnitude > 0.01f)) ? virtualMouse.position.ReadValue() : Mouse.current.position.ReadValue(), rect: canvas.transform as RectTransform, cam: canvas.worldCamera, localPoint: out var localPoint);
				cursorRect.localPosition = Vector2.SmoothDamp(cursorRect.localPosition, localPoint, ref velocity, smoothTime);
				ClampCursorToCanvas();
			}
		}
	}

	private void ClampCursorToCanvas()
	{
		if (!(cursorRect == null) && !(canvas == null))
		{
			Vector3[] array = new Vector3[4];
			canvas.GetComponent<RectTransform>().GetWorldCorners(array);
			Vector3 position = cursorRect.position;
			float num = cursorRect.rect.width * 0.5f;
			float num2 = cursorRect.rect.height * 0.5f;
			position.x = Mathf.Clamp(position.x, array[0].x + num, array[2].x - num);
			position.y = Mathf.Clamp(position.y, array[0].y + num2, array[2].y - num2);
			cursorRect.position = position;
		}
	}
}
