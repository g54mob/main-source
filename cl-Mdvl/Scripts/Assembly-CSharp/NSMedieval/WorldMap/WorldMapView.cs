using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.WorldMap
{
	public class WorldMapView : MonoBehaviour
	{
		[SerializeField]
		protected RectTransform viewRect;

		[NonSerialized]
		protected Camera WorldMapCamera;

		[NonSerialized]
		private List<WorldMapItemClickable> previousHovers;

		[NonSerialized]
		private List<WorldMapItemClickable> currentHovers;

		[NonSerialized]
		private WorldMapItemClickable itemClicked;

		private readonly RaycastHit[] mouseHoverRaycastHits = new RaycastHit[32];

		private int hoverObjectClickCount;

		protected virtual bool InputEnabled => true;

		protected void Awake()
		{
			previousHovers = new List<WorldMapItemClickable>();
			currentHovers = new List<WorldMapItemClickable>();
			WorldMapCamera = MonoSingleton<WorldMap>.Instance.HomeSceneWorldCamera;
		}

		private void OnDestroy()
		{
			WorldMapCamera = null;
			previousHovers = null;
			currentHovers = null;
		}

		protected virtual Vector3 GetMousePosition()
		{
			Vector3 result = Camera.main.ScreenToViewportPoint(Input.mousePosition);
			Vector3 vector = Camera.main.ScreenToViewportPoint(viewRect.position);
			Vector3 vector2 = Camera.main.ScreenToViewportPoint(viewRect.GetWorldSize()) - Camera.main.ScreenToViewportPoint(Vector3.zero);
			result -= vector;
			result.x /= vector2.x;
			result.y = 1f + result.y / vector2.y;
			return result;
		}

		protected virtual void Update()
		{
			if (WorldMapCamera == null || !MonoSingleton<WorldMapController>.IsInstantiated() || MonoSingleton<WorldMapController>.Instance.IsHoveringOverUI || !InputEnabled || MonoSingleton<UIController>.Instance.PopupsActive > 0 || MonoSingleton<UIController>.Instance.TradeWindowActive || viewRect == null)
			{
				return;
			}
			Vector3[] fourCornersArray = new Vector3[4];
			viewRect.GetLocalCorners(fourCornersArray);
			Vector3 mousePosition = GetMousePosition();
			if (mousePosition.x > 0f && mousePosition.y > 0f && mousePosition.x < 1f && mousePosition.y < 1f)
			{
				previousHovers.Clear();
				previousHovers.AddRange(currentHovers);
				currentHovers.Clear();
				int num = Physics.RaycastNonAlloc(WorldMapCamera.ViewportPointToRay(mousePosition), mouseHoverRaycastHits);
				if (num > 0)
				{
					for (int i = 0; i < num; i++)
					{
						RaycastHit raycastHit = mouseHoverRaycastHits[i];
						if (raycastHit.collider.transform != null)
						{
							WorldMapItemClickable component = raycastHit.collider.gameObject.GetComponent<WorldMapItemClickable>();
							if (component != null)
							{
								currentHovers.Insert(0, component);
							}
						}
					}
				}
				if (!currentHovers.EqualsItems(previousHovers))
				{
					hoverObjectClickCount = 0;
					foreach (WorldMapItemClickable previousHover in previousHovers)
					{
						if (!currentHovers.Contains(previousHover))
						{
							previousHover.OnPointerLeave();
						}
					}
					foreach (WorldMapItemClickable currentHover in currentHovers)
					{
						if (!previousHovers.Contains(currentHover))
						{
							currentHover.OnPointerEnter();
						}
					}
				}
			}
			if (Input.GetMouseButtonDown(0) && currentHovers.Count > 0)
			{
				itemClicked = currentHovers[hoverObjectClickCount];
				hoverObjectClickCount = (hoverObjectClickCount + 1) % currentHovers.Count;
			}
			if (Input.GetMouseButtonUp(0))
			{
				if (itemClicked != null)
				{
					itemClicked.OnClick();
					itemClicked = null;
				}
				else
				{
					MonoSingleton<WorldMapController>.Instance.PlaceDeselectClicked();
				}
			}
		}
	}
}
