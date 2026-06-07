using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UISoftMaskInternal
{
	internal static class GraphicExtensions
	{
		private static readonly Vector3[] s_WorldCorners = new Vector3[4];

		private static readonly Bounds s_ScreenBounds = new Bounds(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(1f, 1f, 1f));

		public static void GetMaterialsForRendering(this Graphic self, List<Material> result)
		{
			result.Clear();
			if ((bool)self)
			{
				CanvasRenderer canvasRenderer = self.canvasRenderer;
				int materialCount = canvasRenderer.materialCount;
				int popMaterialCount = canvasRenderer.popMaterialCount;
				if (result.Capacity < materialCount + popMaterialCount)
				{
					result.Capacity = materialCount + popMaterialCount;
				}
				for (int i = 0; i < materialCount; i++)
				{
					result.Add(canvasRenderer.GetMaterial(i));
				}
				for (int j = 0; j < popMaterialCount; j++)
				{
					result.Add(canvasRenderer.GetPopMaterial(j));
				}
			}
		}

		public static bool IsInScreen(this Graphic self)
		{
			if (!self || !self.canvas)
			{
				return false;
			}
			if (FrameCache.TryGet<bool>(self, "IsInScreen", out var result))
			{
				return result;
			}
			Camera camera = ((self.canvas.renderMode != RenderMode.ScreenSpaceOverlay) ? self.canvas.worldCamera : null);
			Vector3 vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			Vector3 vector2 = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			self.rectTransform.GetWorldCorners(s_WorldCorners);
			Vector2Int screenSize = GetScreenSize();
			for (int i = 0; i < 4; i++)
			{
				if ((bool)camera)
				{
					s_WorldCorners[i] = camera.WorldToViewportPoint(s_WorldCorners[i]);
				}
				else
				{
					s_WorldCorners[i] = RectTransformUtility.WorldToScreenPoint(null, s_WorldCorners[i]);
					s_WorldCorners[i].x /= screenSize.x;
					s_WorldCorners[i].y /= screenSize.y;
				}
				s_WorldCorners[i].z = 0f;
				vector = Vector3.Min(s_WorldCorners[i], vector);
				vector2 = Vector3.Max(s_WorldCorners[i], vector2);
			}
			Bounds bounds = new Bounds(vector, Vector3.zero);
			bounds.Encapsulate(vector2);
			result = bounds.Intersects(s_ScreenBounds);
			FrameCache.Set(self, "IsInScreen", result);
			return result;
		}

		public static Texture GetActualMainTexture(this Graphic self)
		{
			Image image = self as Image;
			if (image == null)
			{
				return self.mainTexture;
			}
			Sprite overrideSprite = image.overrideSprite;
			if (!overrideSprite)
			{
				return self.mainTexture;
			}
			return overrideSprite.GetActualTexture();
		}

		private static Vector2Int GetScreenSize()
		{
			return new Vector2Int(Screen.width, Screen.height);
		}

		public static float GetParentGroupAlpha(this Graphic self)
		{
			float alpha = self.canvasRenderer.GetAlpha();
			if (Mathf.Approximately(alpha, 0f))
			{
				return 1f;
			}
			return Mathf.Clamp01(self.canvasRenderer.GetInheritedAlpha() / alpha);
		}
	}
}
