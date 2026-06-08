using UnityEngine;

namespace Rhizomatic.ImUI
{
	public class HorizontalLayoutView : LayoutView<HorizontalLayoutViewState>
	{
		public RectTransform body;

		public Transform container;

		protected override void LoadView(ImUIView view)
		{
		}

		protected override void LoadState(HorizontalLayoutViewState state)
		{
		}

		public override ImUIViewState GetState()
		{
			return null;
		}
	}
}
