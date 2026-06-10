using System.Collections;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	[RequireComponent(typeof(RectTransform))]
	public class ScaleToLabel : MonoBehaviour
	{
		[SerializeField]
		private float defaultWidth;

		[SerializeField]
		private float defaultHeigth;

		[SerializeField]
		private RectTransform label;

		[SerializeField]
		private Transform layoutParent;

		private void Awake()
		{
			if (layoutParent == null)
			{
				layoutParent = base.transform.parent;
			}
			LocalizationManager.OnLocalizeEvent -= Scale;
			LocalizationManager.OnLocalizeEvent += Scale;
		}

		private void Scale()
		{
			StartCoroutine(ScaleDelay());
		}

		private void OnDestroy()
		{
			LocalizationManager.OnLocalizeEvent -= Scale;
		}

		private IEnumerator ScaleDelay()
		{
			yield return new WaitForEndOfFrame();
			RectTransform component = GetComponent<RectTransform>();
			Rect rect = label.rect;
			float num = ((rect.width > defaultWidth) ? rect.width : 0f);
			float num2 = ((rect.height > defaultHeigth) ? rect.height : 0f);
			component.sizeDelta = new Vector2(defaultWidth + num, defaultHeigth + num2);
			yield return new WaitForEndOfFrame();
			LayoutRebuilder.MarkLayoutForRebuild(layoutParent as RectTransform);
		}
	}
}
