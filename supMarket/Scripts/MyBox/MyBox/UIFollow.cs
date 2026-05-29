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
		private bool _editTime;

		private RectTransform _transform;

		public bool IsOffscreen => false;

		private RectTransform Transform => null;

		public Vector2 OffscreenOffset => default(Vector2);

		private void LateUpdate()
		{
		}

		private void ToggleCanvasOffscreen()
		{
		}
	}
}
