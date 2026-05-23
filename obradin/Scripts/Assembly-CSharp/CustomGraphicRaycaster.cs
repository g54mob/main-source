using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class CustomGraphicRaycaster : BaseRaycaster, ISerializationCallbackReceiver
{
	public enum BlockingObjects
	{
		None = 0,
		TwoD = 1,
		ThreeD = 2,
		All = 3
	}

	protected const int kNoEventMaskSet = -1;

	public bool ignoreReversedGraphics = true;

	public BlockingObjects blockingObjects;

	[SerializeField]
	protected LayerMask m_BlockingMask = -1;

	private Canvas m_Canvas;

	[NonSerialized]
	private List<Graphic> m_RaycastResults = new List<Graphic>();

	[NonSerialized]
	private static readonly List<Graphic> s_SortedGraphics = new List<Graphic>();

	private Canvas canvas
	{
		get
		{
			if (m_Canvas != null)
			{
				return m_Canvas;
			}
			m_Canvas = GetComponent<Canvas>();
			return m_Canvas;
		}
	}

	public override Camera eventCamera
	{
		get
		{
			if (canvas.worldCamera == null)
			{
				return null;
			}
			return (!(canvas.worldCamera != null)) ? Camera.main : canvas.worldCamera;
		}
	}

	protected CustomGraphicRaycaster()
	{
	}

	public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
	{
		if (canvas == null)
		{
			return;
		}
		Vector2 vector = Resolution.ToBuffer(eventData.position);
		if (!Resolution.IsInBuffer(vector))
		{
			return;
		}
		float num = float.MaxValue;
		if (blockingObjects != BlockingObjects.None)
		{
			Ray ray = eventCamera.ScreenPointToRay(eventData.position);
			float num2 = eventCamera.farClipPlane - eventCamera.nearClipPlane;
			if (blockingObjects == BlockingObjects.ThreeD || blockingObjects == BlockingObjects.All)
			{
				RaycastHit[] array = Physics.RaycastAll(ray, num2, m_BlockingMask);
				if (array.Length > 0 && array[0].distance < num)
				{
					num = array[0].distance;
				}
			}
			if (blockingObjects == BlockingObjects.TwoD || blockingObjects == BlockingObjects.All)
			{
				RaycastHit2D[] rayIntersectionAll = Physics2D.GetRayIntersectionAll(ray, num2, m_BlockingMask);
				if (rayIntersectionAll.Length > 0 && rayIntersectionAll[0].fraction * num2 < num)
				{
					num = rayIntersectionAll[0].fraction * num2;
				}
			}
		}
		m_RaycastResults.Clear();
		Raycast(canvas, eventCamera, vector, m_RaycastResults);
		for (int i = 0; i < m_RaycastResults.Count; i++)
		{
			GameObject gameObject = m_RaycastResults[i].gameObject;
			bool flag = true;
			if (ignoreReversedGraphics)
			{
				if (eventCamera == null)
				{
					Vector3 rhs = gameObject.transform.rotation * Vector3.forward;
					flag = Vector3.Dot(Vector3.forward, rhs) > 0f;
				}
				else
				{
					Vector3 lhs = eventCamera.transform.rotation * Vector3.forward;
					Vector3 rhs2 = gameObject.transform.rotation * Vector3.forward;
					flag = Vector3.Dot(lhs, rhs2) > 0f;
				}
			}
			if (flag)
			{
				float num3 = Vector3.Distance(eventCamera.transform.position, canvas.transform.position);
				if (!(num3 >= num))
				{
					RaycastResult item = new RaycastResult
					{
						gameObject = gameObject,
						module = this,
						distance = num3,
						screenPosition = eventData.position,
						index = resultAppendList.Count,
						depth = m_RaycastResults[i].depth,
						sortingLayer = canvas.sortingLayerID,
						sortingOrder = canvas.sortingOrder
					};
					resultAppendList.Add(item);
				}
			}
		}
	}

	private static void Raycast(Canvas canvas, Camera eventCamera, Vector2 pointerPosition, List<Graphic> results)
	{
		pointerPosition -= 0.5f * new Vector2(Resolution.bufferW, Resolution.bufferH);
		IList<Graphic> graphicsForCanvas = GraphicRegistry.GetGraphicsForCanvas(canvas);
		s_SortedGraphics.Clear();
		for (int i = 0; i < graphicsForCanvas.Count; i++)
		{
			Graphic graphic = graphicsForCanvas[i];
			if (graphic.isActiveAndEnabled && graphic.depth != -1 && graphic.raycastTarget)
			{
				RectTransform component = graphic.canvas.GetComponent<RectTransform>();
				Vector2 point = (component.worldToLocalMatrix * graphic.rectTransform.localToWorldMatrix).inverse.MultiplyPoint(pointerPosition);
				if (graphic.rectTransform.rect.Contains(point))
				{
					s_SortedGraphics.Add(graphic);
				}
			}
		}
		s_SortedGraphics.Sort((Graphic g1, Graphic g2) => g2.depth.CompareTo(g1.depth));
		for (int num = 0; num < s_SortedGraphics.Count; num++)
		{
			results.Add(s_SortedGraphics[num]);
		}
	}

	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
	}

	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{
	}
}
