using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VRTK
{
	public class VRTK_UIGraphicRaycaster : GraphicRaycaster
	{
		protected Canvas currentCanvas;

		protected Vector2 lastKnownPosition;

		protected const float UI_CONTROL_OFFSET = 1E-05f;

		[NonSerialized]
		private static List<RaycastResult> s_RaycastResults = new List<RaycastResult>();

		protected virtual Canvas canvas
		{
			get
			{
				if (currentCanvas != null)
				{
					return currentCanvas;
				}
				currentCanvas = base.gameObject.GetComponent<Canvas>();
				return currentCanvas;
			}
		}

		public event Action Hit;

		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
			if (!(canvas == null) && !(eventCamera == null))
			{
				Raycast(ray: new Ray(eventData.pointerCurrentRaycast.worldPosition, eventData.pointerCurrentRaycast.worldNormal), canvas: canvas, eventCamera: eventCamera, eventData: eventData, results: ref s_RaycastResults);
				SetNearestRaycast(ref eventData, ref resultAppendList, ref s_RaycastResults);
				if (s_RaycastResults.Count > 0)
				{
					this.Hit?.Invoke();
				}
				s_RaycastResults.Clear();
			}
		}

		protected virtual void SetNearestRaycast(ref PointerEventData eventData, ref List<RaycastResult> resultAppendList, ref List<RaycastResult> raycastResults)
		{
			RaycastResult? raycastResult = null;
			for (int i = 0; i < raycastResults.Count; i++)
			{
				RaycastResult value = raycastResults[i];
				value.index = resultAppendList.Count;
				if (!raycastResult.HasValue || value.distance < raycastResult.Value.distance)
				{
					raycastResult = value;
				}
				VRTK_SharedMethods.AddListValue(resultAppendList, value);
			}
			if (raycastResult.HasValue)
			{
				eventData.position = raycastResult.Value.screenPosition;
				eventData.delta = eventData.position - lastKnownPosition;
				lastKnownPosition = eventData.position;
				eventData.pointerCurrentRaycast = raycastResult.Value;
			}
		}

		protected virtual float GetHitDistance(Ray ray, float hitDistance)
		{
			if (canvas.renderMode != RenderMode.ScreenSpaceOverlay && base.blockingObjects != BlockingObjects.None)
			{
				float num = Vector3.Distance(ray.origin, canvas.transform.position);
				if (base.blockingObjects == BlockingObjects.ThreeD || base.blockingObjects == BlockingObjects.All)
				{
					Physics.Raycast(ray, out var hitInfo, num, m_BlockingMask);
					if (hitInfo.collider != null && !VRTK_PlayerObject.IsPlayerObject(hitInfo.collider.gameObject))
					{
						hitDistance = hitInfo.distance;
					}
				}
				if (base.blockingObjects == BlockingObjects.TwoD || base.blockingObjects == BlockingObjects.All)
				{
					RaycastHit2D raycastHit2D = Physics2D.Raycast(ray.origin, ray.direction, num);
					if (raycastHit2D.collider != null && !VRTK_PlayerObject.IsPlayerObject(raycastHit2D.collider.gameObject))
					{
						hitDistance = raycastHit2D.fraction * num;
					}
				}
			}
			return hitDistance;
		}

		protected virtual void Raycast(Canvas canvas, Camera eventCamera, PointerEventData eventData, Ray ray, ref List<RaycastResult> results)
		{
			float hitDistance = GetHitDistance(ray, VRTK_UIPointer.GetPointerLength(eventData.pointerId));
			IList<Graphic> graphicsForCanvas = GraphicRegistry.GetGraphicsForCanvas(canvas);
			for (int i = 0; i < graphicsForCanvas.Count; i++)
			{
				Graphic graphic = graphicsForCanvas[i];
				if (graphic.depth == -1 || !graphic.raycastTarget)
				{
					continue;
				}
				Transform transform = graphic.transform;
				Vector3 forward = transform.forward;
				float num = Vector3.Dot(forward, transform.position - ray.origin) / Vector3.Dot(forward, ray.direction);
				if (!(num < 0f) && !(num - 1E-05f > hitDistance))
				{
					Vector3 point = ray.GetPoint(num);
					Vector2 vector = eventCamera.WorldToScreenPoint(point);
					if (RectTransformUtility.RectangleContainsScreenPoint(graphic.rectTransform, vector, eventCamera) && graphic.Raycast(vector, eventCamera))
					{
						RaycastResult value = new RaycastResult
						{
							gameObject = graphic.gameObject,
							module = this,
							distance = num,
							screenPosition = vector,
							worldPosition = point,
							depth = graphic.depth,
							sortingLayer = canvas.sortingLayerID,
							sortingOrder = canvas.sortingOrder
						};
						VRTK_SharedMethods.AddListValue(results, value);
					}
				}
			}
			results.Sort((RaycastResult g1, RaycastResult g2) => g2.depth.CompareTo(g1.depth));
		}
	}
}
