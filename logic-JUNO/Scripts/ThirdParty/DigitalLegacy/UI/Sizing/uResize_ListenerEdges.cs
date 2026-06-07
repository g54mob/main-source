using System.Collections.Generic;
using UnityEngine;

namespace DigitalLegacy.UI.Sizing
{
	internal class uResize_ListenerEdges
	{
		public bool isCorner;

		public Vector2 pivot;

		public RectTransform.Edge edgeA;

		public RectTransform.Edge? edgeB;

		private static Dictionary<eResizeListenerType, uResize_ListenerEdges> listenerEdgesCache = new Dictionary<eResizeListenerType, uResize_ListenerEdges>();

		public uResize_ListenerEdges(bool c, Vector2 p, RectTransform.Edge a, RectTransform.Edge? b = null)
		{
			isCorner = c;
			pivot = p;
			edgeA = a;
			edgeB = b;
		}

		internal static uResize_ListenerEdges GetEdgesForListenerType(eResizeListenerType type)
		{
			if (listenerEdgesCache.ContainsKey(type))
			{
				return listenerEdgesCache[type];
			}
			uResize_ListenerEdges edgesForListenerTypeUncached = GetEdgesForListenerTypeUncached(type);
			listenerEdgesCache.Add(type, edgesForListenerTypeUncached);
			return edgesForListenerTypeUncached;
		}

		private static uResize_ListenerEdges GetEdgesForListenerTypeUncached(eResizeListenerType type)
		{
			return type switch
			{
				eResizeListenerType.Left => new uResize_ListenerEdges(c: false, new Vector2(0f, 0.5f), RectTransform.Edge.Left), 
				eResizeListenerType.Right => new uResize_ListenerEdges(c: false, new Vector2(1f, 0.5f), RectTransform.Edge.Right), 
				eResizeListenerType.Top => new uResize_ListenerEdges(c: false, new Vector2(0.5f, 1f), RectTransform.Edge.Top), 
				eResizeListenerType.Bottom => new uResize_ListenerEdges(c: false, new Vector2(0.5f, 0f), RectTransform.Edge.Bottom), 
				eResizeListenerType.TopLeft => new uResize_ListenerEdges(c: true, new Vector2(0f, 1f), RectTransform.Edge.Top, RectTransform.Edge.Left), 
				eResizeListenerType.TopRight => new uResize_ListenerEdges(c: true, new Vector2(1f, 1f), RectTransform.Edge.Top, RectTransform.Edge.Right), 
				eResizeListenerType.BottomLeft => new uResize_ListenerEdges(c: true, new Vector2(0f, 0f), RectTransform.Edge.Bottom, RectTransform.Edge.Left), 
				eResizeListenerType.BottomRight => new uResize_ListenerEdges(c: true, new Vector2(1f, 0f), RectTransform.Edge.Bottom, RectTransform.Edge.Right), 
				_ => null, 
			};
		}
	}
}
