using UnityEngine;

namespace Jundroo.Common.Utils
{
	public static class InputUtility
	{
		public static bool AnyMouseButton()
		{
			if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
			{
				return Input.GetMouseButton(2);
			}
			return true;
		}
	}
}
