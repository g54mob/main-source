using UnityEngine;

namespace MyBox
{
	[ExecuteInEditMode]
	public class UIFollow : MonoBehaviour
	{
		public Transform ToFollow;

		public Vector2 Offset;

		public Camera GameCamera;

		[SerializeField]
		[Tooltip("Hide Canvas when Following Panel is offscreen")]
		private bool _hideOffscreen;

		[SerializeField]
		[ConditionalField(new string[] { "_hideOffscreen" })]
		private Canvas _canvas;

		[SerializeField]
		private bool _editTime = true;

		private RectTransform _transform;

		public bool IsOffscreen => OffscreenOffset != Vector2.zero;

		private RectTransform Transform
		{
			get
			{
				if (!_transform)
				{
					return _transform = base.transform as RectTransform;
				}
				return _transform;
			}
		}

		public Vector2 OffscreenOffset
		{
			get
			{
				Rect rect = Transform.rect;
				float num = rect.width / 2f;
				float x = 0f;
				Vector2 anchoredPosition = Transform.anchoredPosition;
				float num2 = anchoredPosition.x + num;
				float num3 = anchoredPosition.x - num - (float)Screen.width;
				if (num2 < 0f)
				{
					x = num2;
				}
				else if (num3 > 0f)
				{
					x = num3;
				}
				float num4 = rect.height / 2f;
				float y = 0f;
				float num5 = anchoredPosition.y + num4;
				float num6 = anchoredPosition.y - num4 - (float)Screen.height;
				if (num5 < 0f)
				{
					y = num5;
				}
				else if (num6 > 0f)
				{
					y = num6;
				}
				return new Vector2(x, y);
			}
		}

		private void LateUpdate()
		{
			if ((!_editTime && !Application.isPlaying) || ToFollow == null)
			{
				return;
			}
			if (GameCamera == null)
			{
				GameCamera = Camera.main;
				if (GameCamera == null)
				{
					WarningsPool.LogWarning(base.name + ".UIFollow Caused: Main Camera not found. Assign Camera manually", this);
					return;
				}
			}
			Transform.anchorMax = Vector2.zero;
			Transform.anchorMin = Vector2.zero;
			Vector3 position = ToFollow.position.Offset(Offset);
			Vector3 vector = GameCamera.WorldToScreenPoint(position);
			Transform.anchoredPosition = vector;
			ToggleCanvasOffscreen();
		}

		private void ToggleCanvasOffscreen()
		{
			if (_hideOffscreen)
			{
				_canvas.enabled = !IsOffscreen;
			}
		}
	}
}
