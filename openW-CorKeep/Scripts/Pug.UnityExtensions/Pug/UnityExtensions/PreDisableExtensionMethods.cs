using System.Collections.Generic;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public static class PreDisableExtensionMethods
	{
		private static readonly int PREALLOC_STACK_HEIGHT;

		private static readonly int PREALLOC_STACK_WIDTH;

		private static readonly Stack<List<IPreDisable>> preallocIPreDisables;

		static PreDisableExtensionMethods()
		{
			PREALLOC_STACK_HEIGHT = 16;
			PREALLOC_STACK_WIDTH = 64;
			preallocIPreDisables = new Stack<List<IPreDisable>>(PREALLOC_STACK_HEIGHT);
			for (int i = 0; i < PREALLOC_STACK_HEIGHT; i++)
			{
				preallocIPreDisables.Push(new List<IPreDisable>(PREALLOC_STACK_WIDTH));
			}
		}

		public static void SetActive_Clean(this GameObject go, bool active)
		{
			if (!active)
			{
				go.SetActive_CleanDisable();
			}
			else
			{
				go.SetActive(value: true);
			}
		}

		public static void SetActive_CleanDisable(this GameObject go)
		{
			if (!go.activeInHierarchy)
			{
				return;
			}
			List<IPreDisable> list = preallocIPreDisables.Pop();
			go.GetComponentsInChildren(list);
			foreach (IPreDisable item in list)
			{
				item.OnPreDisable();
			}
			list.Clear();
			preallocIPreDisables.Push(list);
			go.SetActive(value: false);
		}

		public static void Destroy_Clean(this GameObject go)
		{
			go.SetActive_CleanDisable();
			Object.Destroy(go);
		}
	}
}
