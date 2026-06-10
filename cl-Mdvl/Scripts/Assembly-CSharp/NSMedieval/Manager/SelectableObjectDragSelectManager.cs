using NSEipix;
using NSEipix.Base;
using NSMedieval.Tools;
using UnityEngine;
using UnityEngine.UI.Extensions;

namespace NSMedieval.Manager
{
	public class SelectableObjectDragSelectManager : MonoSingleton<SelectableObjectDragSelectManager>, IObserver
	{
		private Camera cameraCache;

		private RectTransform dragBox;

		private RectTransform dragBoxCanvasTransform;

		private Vector3 dragStartPos;

		private int raycastLayerMask = -1;

		private Camera CameraCache
		{
			get
			{
				cameraCache = ((cameraCache == null) ? Camera.main : cameraCache);
				return cameraCache;
			}
		}

		public void Hook2DDragBox(RectTransform transform)
		{
			dragBox = transform;
			dragBoxCanvasTransform = dragBox.GetParentCanvas().GetComponent<RectTransform>();
		}

		public float GetDragBoxArea()
		{
			return dragBox.rect.Area();
		}

		public void DragSelectStart(Vector3 pos)
		{
			if (dragBox == null)
			{
				dragStartPos = Vector3.zero;
				return;
			}
			dragStartPos = pos;
			dragBox.gameObject.SetActive(value: true);
		}

		public void DragSelectTick(Vector3 pos)
		{
			if (!(dragBox == null) && !(CameraCache == null))
			{
				Get2dDragRectPositions(out var middle, out var scale, pos);
				dragBox.position = middle;
				dragBox.sizeDelta = scale;
			}
		}

		public void DragSelectEnd()
		{
			if (!(dragBox == null))
			{
				dragBox.gameObject.SetActive(value: false);
			}
		}

		public bool IsWithinSelection(Vector3 pos)
		{
			if (!RaycastUtils.WorldToCanvas(pos, dragBoxCanvasTransform, out var proportionalPosition))
			{
				return false;
			}
			if (Vector3.Distance(dragStartPos, proportionalPosition) <= 20f)
			{
				return true;
			}
			Vector2 vector = dragBox.sizeDelta / 2f;
			Vector3 position = dragBox.position;
			float num = position.x - vector.x;
			float num2 = position.y - vector.y;
			float num3 = position.x + vector.x;
			float num4 = position.y + vector.y;
			if (proportionalPosition.x >= num && proportionalPosition.x <= num3 && proportionalPosition.y >= num2)
			{
				return proportionalPosition.y <= num4;
			}
			return false;
		}

		private void Get2dDragRectPositions(out Vector3 middle, out Vector2 scale, Vector3 endPos)
		{
			middle = (dragStartPos + endPos) / 2f;
			scale.x = Mathf.Abs(dragStartPos.x - endPos.x);
			scale.y = Mathf.Abs(dragStartPos.y - endPos.y);
		}

		private void Start()
		{
			raycastLayerMask = 1 << LayerMask.NameToLayer("VoxelMap");
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			if (!hasFocus)
			{
				dragBox.gameObject.SetActive(value: false);
			}
		}
	}
}
