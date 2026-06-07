using System.Collections;
using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.UI
{
	[ExecuteInEditMode]
	public class BE2_UI_SelectionPanel : MonoBehaviour
	{
		private LayoutGroup _layoutGroup;

		private RectTransform _rectTransform;

		private void OnValidate()
		{
			GetComponent<Image>().raycastTarget = false;
			BE2_Text bE2Text = BE2_Text.GetBE2Text(base.transform.GetChild(0));
			if (bE2Text != null && !bE2Text.isNull)
			{
				bE2Text.raycastTarget = false;
			}
		}

		private void Awake()
		{
			_layoutGroup = GetComponent<HorizontalOrVerticalLayoutGroup>();
			_rectTransform = GetComponent<RectTransform>();
		}

		private void Start()
		{
			UpdateLayout();
		}

		public void UpdateLayout()
		{
			StartCoroutine(C_UpdateLayout());
		}

		private IEnumerator C_UpdateLayout()
		{
			yield return new WaitForEndOfFrame();
			_rectTransform.sizeDelta = new Vector2(_layoutGroup.preferredWidth, _layoutGroup.preferredHeight);
		}
	}
}
