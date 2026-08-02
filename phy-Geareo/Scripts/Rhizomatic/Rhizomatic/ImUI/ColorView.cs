using Rhizomatic.UI;

namespace Rhizomatic.ImUI
{
	public class ColorView : ImUIView<ColorViewState>
	{
		public ColorPicker picker;

		protected override void OnCreated()
		{
		}

		protected override void LoadState(ColorViewState state)
		{
		}

		public override ImUIViewState GetState()
		{
			return null;
		}
	}
}
