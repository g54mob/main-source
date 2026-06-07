using UnityEngine;
using UnityEngine.EventSystems;

namespace Jundroo.Common.Extensions
{
	public static class PointerEventDataExtensions
	{
		public static bool IsDoubleClick(this PointerEventData data)
		{
			if (data.clickCount >= 2)
			{
				return Time.unscaledTime - data.clickTime < 0.5f;
			}
			return false;
		}
	}
}
