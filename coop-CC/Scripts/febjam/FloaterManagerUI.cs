using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Unity.Mathematics;
using UnityEngine;

public class FloaterManagerUI : AggroManagerBase<FloaterManagerUI>
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct EvFloaterAddedOrRemoved : IEntityEvent, IEntityTyped
	{
	}

	public RectTransform container;

	public List<FloaterUI> floaters = new List<FloaterUI>();

	public Vector3 targetOffset = Vector3.zero;

	public Vector2 edgeOffset = Vector2.zero;

	public float arrowOffset;

	public FloaterUI AddFloater(GameObject floaterUIPrefab)
	{
		FloaterUI component = Object.Instantiate(floaterUIPrefab, container).GetComponent<FloaterUI>();
		floaters.Add(component);
		return component;
	}

	public void RemoveFloater(FloaterUI floaterToRemove)
	{
		floaters.Remove(floaterToRemove);
		Object.Destroy(floaterToRemove.gameObject);
	}

	protected override void OnUpdatePresentation()
	{
		UpdateFloaters();
	}

	public void UpdateFloaters()
	{
		for (int i = 0; i < floaters.Count; i++)
		{
			FloaterUI floaterUI = floaters[i];
			if (!(floaterUI == null))
			{
				Vector3 vector = GameUtil.mainCamera.WorldToScreenPoint(floaterUI.targetWorldPosition + targetOffset + floaterUI.offset);
				vector *= math.sign(vector.z) / Options.renderScale;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(container, vector, GameUtil.uiCamera, out var localPoint);
				Ray ray = new Ray(localPoint, -localPoint.normalized);
				Rect rect = container.rect;
				Bounds bounds = new Bounds(rect.center, rect.size);
				floaterUI.onScreen = bounds.Contains(localPoint);
				Vector3 localPosition;
				float distance;
				if (floaterUI.onScreen)
				{
					localPosition = localPoint;
				}
				else if (!bounds.IntersectRay(ray, out distance))
				{
					Debug.LogWarning("Did not intersect bounds?");
					localPosition = Vector3.zero;
				}
				else
				{
					localPosition = ray.origin + ray.direction * distance;
				}
				floaterUI.transform.localPosition = localPosition;
				if ((object)floaterUI.arrow != null)
				{
					floaterUI.arrow.localPosition = -ray.direction * arrowOffset;
					floaterUI.arrow.transform.up = -ray.direction;
					floaterUI.arrow.gameObject.SetActive(!floaterUI.onScreen);
				}
			}
		}
	}
}
