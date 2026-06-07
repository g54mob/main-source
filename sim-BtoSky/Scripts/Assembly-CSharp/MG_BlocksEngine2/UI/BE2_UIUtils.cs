using System.Collections;
using MG_BlocksEngine2.Core;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.UI
{
	public static class BE2_UIUtils
	{
		public static void ForceRebuildLayout(this RectTransform rectTransform)
		{
			BE2_ExecutionManager.Instance.StartCoroutine(C_RebuildLayout(rectTransform));
		}

		private static IEnumerator C_RebuildLayout(RectTransform rectTransform)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
			yield return new WaitForEndOfFrame();
			LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
		}
	}
}
