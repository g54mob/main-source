using Rhizomatic.UI;

namespace Rhizomatic.ImUI
{
	public class NumberView : ImUIView<NumberViewState>
	{
		public NumberField numberField;

		protected override void OnCreated()
		{
		}

		protected override void LoadState(NumberViewState state)
		{
		}

		public override ImUIViewState GetState()
		{
			return null;
		}
	}
}
