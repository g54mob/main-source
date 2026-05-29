using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UILayoutRebuilderExec : MonoBehaviour
	{
		public void Rebuild()
		{
			StartCoroutine(RefreshLayoutByMethodTwo());
		}

		private IEnumerator RefreshLayoutByMethodTwo()
		{
			yield return new WaitForEndOfFrame();
			if (base.isActiveAndEnabled)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)base.transform);
			}
			yield return null;
		}
	}
}
