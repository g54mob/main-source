using Rhizomatic.UI;

namespace Rhizomatic.ImUI
{
	public class ToggleView : ImUIView<ToggleViewState>
	{
		public ToggleAdapter toggle;

		protected override void OnCreated()
		{
		}

		protected override void LoadState(ToggleViewState state)
		{
		}

		public override ImUIViewState GetState()
		{
			return null;
		}
	}
}
