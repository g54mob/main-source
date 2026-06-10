using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public abstract class LimitedHeightPanel : PanelBase
	{
		[SerializeField]
		private float maxHeight = 560f;

		[SerializeField]
		private LayoutElement bodyLayoutElement;

		protected void SetPreferredHeight(float preferredHeight)
		{
			bodyLayoutElement.preferredHeight = Mathf.Min(maxHeight, preferredHeight);
		}

		protected void SetPreferredWidth(float preferredWidth)
		{
			bodyLayoutElement.preferredWidth = preferredWidth;
		}
	}
}
