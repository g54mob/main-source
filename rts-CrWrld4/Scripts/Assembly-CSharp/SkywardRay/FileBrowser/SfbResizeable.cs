using UnityEngine;

namespace SkywardRay.FileBrowser
{
	public class SfbResizeable : MonoBehaviour
	{
		public Vector2 minimumSize;

		public Vector2 maximumSize;

		public bool maxSizeCanvasSize;

		public bool createResizeButtons;

		public GameObject resizeButtonsPrefab;

		private Vector2 sizeDelta;

		private SfbResizeSide resizeSide;

		private RectTransform panelRectTransform;

		private RectTransform canvasRectTransform;

		public void Start()
		{
		}

		public void ButtonResize(SfbResizeSide side)
		{
		}

		public void EndResize()
		{
		}

		public void Resize(Vector2 pos, Vector2 oldpos)
		{
		}
	}
}
