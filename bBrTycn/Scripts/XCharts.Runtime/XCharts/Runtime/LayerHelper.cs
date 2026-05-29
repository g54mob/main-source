using UnityEngine;

namespace XCharts.Runtime
{
	public static class LayerHelper
	{
		private static Vector2 s_Vector0And0 = new Vector2(0f, 0f);

		private static Vector2 s_Vector0And0Dot5 = new Vector2(0f, 0.5f);

		private static Vector2 s_Vector0And1 = new Vector2(0f, 1f);

		private static Vector2 s_Vector0Dot5And1 = new Vector2(0.5f, 1f);

		private static Vector2 s_Vector0Dot5And0Dot5 = new Vector2(0.5f, 0.5f);

		private static Vector2 s_Vector0Dot5And0 = new Vector2(0.5f, 0f);

		private static Vector2 s_Vector1And1 = new Vector2(1f, 1f);

		private static Vector2 s_Vector1And0Dot5 = new Vector2(1f, 0.5f);

		private static Vector2 s_Vector1And0 = new Vector2(1f, 0f);

		internal static Vector2 ResetChartPositionAndPivot(Vector2 minAnchor, Vector2 maxAnchor, float width, float height, ref float chartX, ref float chartY)
		{
			if (IsLeftTop(minAnchor, maxAnchor))
			{
				chartX = 0f;
				chartY = 0f - height;
				return s_Vector0And1;
			}
			if (IsLeftCenter(minAnchor, maxAnchor))
			{
				chartX = 0f;
				chartY = (0f - height) / 2f;
				return s_Vector0And0Dot5;
			}
			if (IsLeftBottom(minAnchor, maxAnchor))
			{
				chartX = 0f;
				chartY = 0f;
				return s_Vector0And0;
			}
			if (IsCenterTop(minAnchor, maxAnchor))
			{
				chartX = (0f - width) / 2f;
				chartY = 0f - height;
				return s_Vector0Dot5And1;
			}
			if (IsCenterCenter(minAnchor, maxAnchor))
			{
				chartX = (0f - width) / 2f;
				chartY = (0f - height) / 2f;
				return s_Vector0Dot5And0Dot5;
			}
			if (IsCenterBottom(minAnchor, maxAnchor))
			{
				chartX = (0f - width) / 2f;
				chartY = 0f;
				return s_Vector0Dot5And0;
			}
			if (IsRightTop(minAnchor, maxAnchor))
			{
				chartX = 0f - width;
				chartY = 0f - height;
				return s_Vector1And1;
			}
			if (IsRightCenter(minAnchor, maxAnchor))
			{
				chartX = 0f - width;
				chartY = (0f - height) / 2f;
				return s_Vector1And0Dot5;
			}
			if (IsRightBottom(minAnchor, maxAnchor))
			{
				chartX = 0f - width;
				chartY = 0f;
				return s_Vector1And0;
			}
			if (IsStretchTop(minAnchor, maxAnchor))
			{
				chartX = (0f - width) / 2f;
				chartY = 0f - height;
				return s_Vector0Dot5And1;
			}
			if (IsStretchMiddle(minAnchor, maxAnchor))
			{
				chartX = (0f - width) / 2f;
				chartY = (0f - height) / 2f;
				return s_Vector0Dot5And0Dot5;
			}
			if (IsStretchBottom(minAnchor, maxAnchor))
			{
				chartX = (0f - width) / 2f;
				chartY = 0f;
				return s_Vector0Dot5And0;
			}
			if (IsStretchLeft(minAnchor, maxAnchor))
			{
				chartX = 0f;
				chartY = (0f - height) / 2f;
				return s_Vector0And0Dot5;
			}
			if (IsStretchCenter(minAnchor, maxAnchor))
			{
				chartX = (0f - width) / 2f;
				chartY = (0f - height) / 2f;
				return s_Vector0Dot5And0Dot5;
			}
			if (IsStretchRight(minAnchor, maxAnchor))
			{
				chartX = 0f - width;
				chartY = (0f - height) / 2f;
				return s_Vector1And0Dot5;
			}
			if (IsStretchStrech(minAnchor, maxAnchor))
			{
				chartX = (0f - width) / 2f;
				chartY = (0f - height) / 2f;
				return s_Vector0Dot5And0Dot5;
			}
			chartX = 0f;
			chartY = 0f;
			return Vector2.zero;
		}

		private static bool IsLeftTop(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == s_Vector0And1)
			{
				return maxAnchor == s_Vector0And1;
			}
			return false;
		}

		private static bool IsLeftCenter(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == s_Vector0And0Dot5)
			{
				return maxAnchor == s_Vector0And0Dot5;
			}
			return false;
		}

		private static bool IsLeftBottom(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == Vector2.zero)
			{
				return maxAnchor == Vector2.zero;
			}
			return false;
		}

		private static bool IsCenterTop(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == s_Vector0Dot5And1)
			{
				return maxAnchor == s_Vector0Dot5And1;
			}
			return false;
		}

		private static bool IsCenterCenter(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == s_Vector0Dot5And0Dot5)
			{
				return maxAnchor == s_Vector0Dot5And0Dot5;
			}
			return false;
		}

		private static bool IsCenterBottom(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == s_Vector0Dot5And0)
			{
				return maxAnchor == s_Vector0Dot5And0;
			}
			return false;
		}

		private static bool IsRightTop(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == s_Vector1And1)
			{
				return maxAnchor == s_Vector1And1;
			}
			return false;
		}

		private static bool IsRightCenter(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == s_Vector1And0Dot5)
			{
				return maxAnchor == s_Vector1And0Dot5;
			}
			return false;
		}

		private static bool IsRightBottom(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == s_Vector1And0)
			{
				return maxAnchor == s_Vector1And0;
			}
			return false;
		}

		private static bool IsStretchTop(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == s_Vector0And1)
			{
				return maxAnchor == s_Vector1And1;
			}
			return false;
		}

		private static bool IsStretchMiddle(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == s_Vector0And0Dot5)
			{
				return maxAnchor == s_Vector1And0Dot5;
			}
			return false;
		}

		private static bool IsStretchBottom(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == s_Vector0And0)
			{
				return maxAnchor == s_Vector1And0;
			}
			return false;
		}

		private static bool IsStretchLeft(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == s_Vector0And0)
			{
				return maxAnchor == s_Vector0And1;
			}
			return false;
		}

		private static bool IsStretchCenter(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == s_Vector0Dot5And0)
			{
				return maxAnchor == s_Vector0Dot5And1;
			}
			return false;
		}

		private static bool IsStretchRight(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == s_Vector1And0)
			{
				return maxAnchor == s_Vector1And1;
			}
			return false;
		}

		private static bool IsStretchStrech(Vector2 minAnchor, Vector2 maxAnchor)
		{
			if (minAnchor == s_Vector0And0)
			{
				return maxAnchor == s_Vector1And1;
			}
			return false;
		}

		public static bool IsStretchPivot(RectTransform rt)
		{
			if (!IsStretchTop(rt.anchorMin, rt.anchorMax) && !IsStretchMiddle(rt.anchorMin, rt.anchorMax) && !IsStretchBottom(rt.anchorMin, rt.anchorMax) && !IsStretchLeft(rt.anchorMin, rt.anchorMax) && !IsStretchCenter(rt.anchorMin, rt.anchorMax) && !IsStretchRight(rt.anchorMin, rt.anchorMax))
			{
				return IsStretchStrech(rt.anchorMin, rt.anchorMax);
			}
			return true;
		}

		public static bool IsFixedWidthHeight(RectTransform rt)
		{
			if (!IsLeftTop(rt.anchorMin, rt.anchorMax) && !IsLeftCenter(rt.anchorMin, rt.anchorMax) && !IsLeftBottom(rt.anchorMin, rt.anchorMax) && !IsCenterTop(rt.anchorMin, rt.anchorMax) && !IsCenterCenter(rt.anchorMin, rt.anchorMax) && !IsCenterBottom(rt.anchorMin, rt.anchorMax) && !IsRightTop(rt.anchorMin, rt.anchorMax) && !IsRightCenter(rt.anchorMin, rt.anchorMax))
			{
				return IsRightBottom(rt.anchorMin, rt.anchorMax);
			}
			return true;
		}
	}
}
