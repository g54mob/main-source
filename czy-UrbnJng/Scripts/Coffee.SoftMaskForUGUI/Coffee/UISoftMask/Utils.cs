using Coffee.UISoftMaskInternal;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UISoftMask
{
	internal static class Utils
	{
		public static void UpdateAntiAlias(Graphic graphic, bool enabled, float threshold)
		{
			if (!graphic)
			{
				return;
			}
			CanvasRenderer canvasRenderer = graphic.canvasRenderer;
			Color color = canvasRenderer.GetColor();
			float num = 1f;
			if (enabled)
			{
				float num2 = graphic.color.a * canvasRenderer.GetInheritedAlpha();
				if (0f < num2)
				{
					threshold = Mathf.Clamp01(threshold);
					num = Mathf.Lerp(0.003921569f, 0.1f, threshold) / num2;
				}
			}
			if (!Mathf.Approximately(color.a, num))
			{
				color.a = Mathf.Clamp01(num);
				canvasRenderer.SetColor(color);
			}
		}

		public static int GetStencilBits(Transform transform, bool includeSelf, bool useStencil, out Mask nearestMask, out SoftMask nearestSoftMask)
		{
			nearestMask = null;
			nearestSoftMask = null;
			Transform transform2 = MaskUtilities.FindRootSortOverrideCanvas(transform);
			if (transform == transform2)
			{
				return 0;
			}
			int num = 0;
			int result = 0;
			Transform transform3 = (includeSelf ? transform : transform.parent);
			while ((bool)transform3)
			{
				if (transform3.TryGetComponent<Mask>(out var component) && component.MaskEnabled())
				{
					if (!nearestMask)
					{
						nearestMask = component;
						if (FrameCache.TryGet<int>(nearestMask, "GetStencilBits", out result))
						{
							FrameCache.TryGet<SoftMask>(nearestMask, "GetStencilBits", out nearestSoftMask);
							return result;
						}
					}
					result = ((0 < num++) ? (result << 1) : 0);
					if (component is SoftMask softMask && softMask.SoftMaskingEnabled())
					{
						if (!nearestSoftMask)
						{
							nearestSoftMask = softMask;
						}
						if (useStencil)
						{
							result++;
						}
					}
					else
					{
						result++;
					}
				}
				if (transform3 == transform2)
				{
					break;
				}
				transform3 = transform3.parent;
			}
			result = Mathf.Min(result, 255);
			if ((bool)nearestMask)
			{
				FrameCache.Set(nearestMask, "GetStencilBits", result);
				FrameCache.Set(nearestMask, "GetStencilBits", nearestSoftMask);
			}
			return result;
		}

		public static bool AlphaHitTestValid(Graphic src, Vector2 sp, Camera eventCamera, float threshold)
		{
			if (!src || !src.IsActive())
			{
				return false;
			}
			if (!(src is Image) && !(src is RawImage))
			{
				return true;
			}
			if (FrameCache.TryGet<bool>(src, "AlphaHitTestValid", out var result))
			{
				return result;
			}
			if (src is Image src2)
			{
				result = AlphaHitTestValid(src2, sp, eventCamera, threshold);
			}
			else if (src is RawImage src3)
			{
				result = AlphaHitTestValid(src3, sp, eventCamera, threshold);
			}
			FrameCache.Set(src, "AlphaHitTestValid", result);
			return result;
		}

		private static bool AlphaHitTestValid(Image src, Vector2 sp, Camera eventCamera, float threshold)
		{
			if (!src.overrideSprite || !src.overrideSprite.GetActualTexture().isReadable)
			{
				return true;
			}
			float alphaHitTestMinimumThreshold = src.alphaHitTestMinimumThreshold;
			if (0f < alphaHitTestMinimumThreshold && alphaHitTestMinimumThreshold <= 1f)
			{
				return true;
			}
			src.alphaHitTestMinimumThreshold = threshold;
			bool result = src.IsRaycastLocationValid(sp, eventCamera);
			src.alphaHitTestMinimumThreshold = alphaHitTestMinimumThreshold;
			return result;
		}

		private static bool AlphaHitTestValid(RawImage src, Vector2 sp, Camera eventCamera, float threshold)
		{
			Texture2D texture2D = src.texture as Texture2D;
			if (texture2D == null || !texture2D.isReadable)
			{
				return true;
			}
			RectTransform rectTransform = src.rectTransform;
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, sp, eventCamera, out var localPoint))
			{
				return false;
			}
			Rect pixelAdjustedRect = src.GetPixelAdjustedRect();
			float u = Mathf.Repeat((localPoint.x + rectTransform.pivot.x * pixelAdjustedRect.width) / pixelAdjustedRect.width * src.uvRect.width + src.uvRect.x, 1f);
			float v = Mathf.Repeat((localPoint.y + rectTransform.pivot.y * pixelAdjustedRect.height) / pixelAdjustedRect.height * src.uvRect.height + src.uvRect.y, 1f);
			try
			{
				return threshold < texture2D.GetPixelBilinear(u, v).a;
			}
			catch
			{
				return true;
			}
			finally
			{
			}
		}
	}
}
