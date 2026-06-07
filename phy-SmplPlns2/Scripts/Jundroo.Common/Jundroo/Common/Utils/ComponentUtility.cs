using System;
using UnityEngine;

namespace Jundroo.Common.Utils
{
	public static class ComponentUtility
	{
		public static bool MoveComponentDown(Component component)
		{
			Debug.LogError("Attempted to call ComponentUtility.MoveComponentDown but unable to do so because the code is not executing in the Unity editor.");
			return false;
		}

		public static bool MoveComponentUp(Component component)
		{
			Debug.LogError("Attempted to call ComponentUtility.MoveComponentUp but unable to do so because the code is not executing in the Unity editor.");
			return false;
		}

		public static void SetComponentIndex(Component component, int index)
		{
			SetComponentIndex(component, index, clampToValidRange: true);
		}

		public static void SetComponentIndex(Component component, int index, bool clampToValidRange)
		{
			int componentCount = component.gameObject.GetComponentCount();
			if (componentCount < 2)
			{
				throw new Exception("Cannot set the component index because the component count is less than 2");
			}
			if (clampToValidRange)
			{
				index = Mathf.Clamp(index, 1, componentCount - 1);
			}
			if (index < 1 || index >= componentCount)
			{
				throw new Exception($"Cannot set the component index because the requested index '{index}' is out of range ('1' to '{componentCount - 1}')");
			}
			int num = component.GetComponentIndex() - index;
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					MoveComponentUp(component);
				}
			}
			else if (num < 0)
			{
				num = -num;
				for (int j = 0; j < num; j++)
				{
					MoveComponentDown(component);
				}
			}
		}
	}
}
