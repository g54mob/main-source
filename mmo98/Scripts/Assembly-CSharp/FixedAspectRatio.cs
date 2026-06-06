using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class FixedAspectRatio : MonoBehaviour
{
	[SerializeField]
	private float aspectRatio = 1.7777778f;

	private Camera _camera;

	private void Start()
	{
		_camera = GetComponent<Camera>();
		ApplyLetterbox();
	}

	private void LateUpdate()
	{
		ApplyLetterbox();
	}

	private void ApplyLetterbox()
	{
		if (_camera == null)
		{
			return;
		}
		int width = Screen.width;
		int height = Screen.height;
		if (height <= 0)
		{
			return;
		}
		int topOffsetPixels = WindowedHeaderController.TopOffsetPixels;
		int num = height - topOffsetPixels;
		if (num > 0)
		{
			float num2 = (float)topOffsetPixels / (float)height;
			float num3 = 1f - num2;
			float num4 = (float)width / (float)num / aspectRatio;
			Rect rect;
			if (num4 < 1f)
			{
				float num5 = num4 * num3;
				float y = (num3 - num5) * 0.5f;
				rect = new Rect(0f, y, 1f, num5);
			}
			else
			{
				float num6 = 1f / num4;
				float x = (1f - num6) * 0.5f;
				rect = new Rect(x, 0f, num6, num3);
			}
			_camera.rect = rect;
		}
	}
}
