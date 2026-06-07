using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
	[ExecuteAlways]
	public class ScrollRectAutoExpand : MonoBehaviour
	{
		[InfoBox("This script only works when placed on the Content object inside the Viewport of a ScrollRect object.", EInfoBoxType.Warning)]
		[Space]
		[SerializeField]
		private LayoutElement _scrollRectLayoutElement;

		[SerializeField]
		private RectTransform _content;

		[SerializeField]
		private float _maxHeight = 500f;

		private void OnRectTransformDimensionsChange()
		{
			_scrollRectLayoutElement.preferredHeight = Mathf.Min(_content.rect.height, _maxHeight);
		}
	}
}
