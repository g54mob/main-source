using Rhizomatic.UI;

namespace Rhizomatic.ImUI
{
	public class SliderView : ImUIView<SliderViewState>
	{
		public TextAdapter valueA;

		public TextAdapter valueB;

		public SliderAdapter slider;

		private bool cooking;

		protected override void OnCreated()
		{
		}

		protected override void LoadState(SliderViewState state)
		{
		}

		public override ImUIViewState GetState()
		{
			return null;
		}
	}
}
