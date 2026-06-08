using Rhizomatic.UI;

namespace Rhizomatic.ImUI
{
	public class DropdownView : ImUIView<DropdownViewState>
	{
		public DropdownAdapter dropdown;

		protected override void OnCreated()
		{
		}

		protected override void LoadState(DropdownViewState state)
		{
		}

		public override ImUIViewState GetState()
		{
			return null;
		}
	}
}
