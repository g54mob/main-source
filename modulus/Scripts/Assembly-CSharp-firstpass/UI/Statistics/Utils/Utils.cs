using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Statistics.Utils
{
	public static class Utils
	{
		public static void DrawHighlight(List<Vector2> positions, Color color, Image lineHighlightPrefab, Transform container, UnityAction<RectTransform> onHighlightPartCreated = null)
		{
			Material material = Object.Instantiate(lineHighlightPrefab.material);
			for (ushort num = 0; num < positions.Count - 1; num++)
			{
				Image image = Object.Instantiate(lineHighlightPrefab, container);
				image.color = color;
				RectTransform rectTransform = (RectTransform)image.transform;
				rectTransform.anchorMin = Vector2.zero;
				rectTransform.anchorMax = Vector2.one;
				Vector2 offsetMax = (rectTransform.offsetMin = Vector2.zero);
				rectTransform.offsetMax = offsetMax;
				onHighlightPartCreated?.Invoke(rectTransform);
				Sprite sprite = (image.sprite = Object.Instantiate(lineHighlightPrefab.sprite));
				Sprite sprite3 = sprite;
				image.material = material;
				Rect textureRect = sprite3.textureRect;
				Vector2[] vertices = new Vector2[4]
				{
					new Vector2(positions[num].x * textureRect.width, 0f),
					positions[num] * textureRect.size,
					positions[num + 1] * textureRect.size,
					new Vector2(positions[num + 1].x * textureRect.width, 0f)
				};
				sprite3.OverrideGeometry(vertices, new ushort[6] { 0, 1, 2, 0, 2, 3 });
			}
		}
	}
}
