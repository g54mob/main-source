using System.Collections.Generic;
using UnityEngine;

namespace Restory.UserInterface.CommonElements
{
	public static class GUI_NavigationFinderHelper
	{
		public static GUI_BaseNavigation FindSelectableFirstOrLast(GUI_BaseNavigation center, IEnumerable<GUI_BaseNavigation> navigations, Vector3 dir, bool wantsWrapAround = false)
		{
			return FindSelectableFirstOrLast(center.RectTransform, center.Validator, navigations, dir, wantsWrapAround);
		}

		public static GUI_BaseNavigation FindSelectableFirstOrLast(RectTransform center, INavigationValidator validator, IEnumerable<GUI_BaseNavigation> navigations, Vector3 dir, bool wantsWrapAround = false)
		{
			if (center == null)
			{
				return null;
			}
			dir = dir.normalized;
			Vector3 vector = Quaternion.Inverse(center.rotation) * dir;
			Vector3 vector2 = center.TransformPoint(GetPointOnRectEdge(center, vector));
			float num = float.NegativeInfinity;
			float num2 = float.NegativeInfinity;
			float num3 = 0f;
			GUI_BaseNavigation gUI_BaseNavigation = null;
			GUI_BaseNavigation result = null;
			foreach (GUI_BaseNavigation navigation in navigations)
			{
				if (navigation == null || navigation.RectTransform == center || (validator != null && validator.ValidateNavigation(navigation) == null))
				{
					continue;
				}
				RectTransform rectTransform = navigation.transform as RectTransform;
				Vector3 position = ((rectTransform != null) ? ((Vector3)rectTransform.rect.center) : Vector3.zero);
				Vector3 vector3 = navigation.transform.TransformPoint(position) - vector2;
				float num4 = Vector3.Dot(dir, vector3.normalized);
				if (wantsWrapAround && num4 < 0f)
				{
					num3 = (0f - num4) * Vector3.Project(vector3, dir).sqrMagnitude;
					if (num3 > num2)
					{
						num2 = num3;
						result = navigation;
					}
				}
				else if (!(num4 <= 0f))
				{
					num3 = num4 / vector3.sqrMagnitude;
					if (num3 > num)
					{
						num = num3;
						gUI_BaseNavigation = navigation;
					}
				}
			}
			if (wantsWrapAround && null == gUI_BaseNavigation)
			{
				return result;
			}
			return gUI_BaseNavigation;
		}

		public static Vector3 GetPointOnRectEdge(RectTransform rect, Vector2 dir)
		{
			if (rect == null)
			{
				return Vector3.zero;
			}
			if (dir != Vector2.zero)
			{
				dir /= Mathf.Max(Mathf.Abs(dir.x), Mathf.Abs(dir.y));
			}
			dir = rect.rect.center + Vector2.Scale(rect.rect.size, dir * 0.5f);
			return dir;
		}
	}
}
