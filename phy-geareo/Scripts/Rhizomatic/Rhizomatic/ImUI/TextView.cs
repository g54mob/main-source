using Rhizomatic.UI;

namespace Rhizomatic.ImUI
{
	public class TextView : ImUIView<TextViewState>
	{
		public InputFieldAdapter inputField;

		protected override void OnCreated()
		{
		}

		protected override void LoadState(TextViewState state)
		{
		}

		public override ImUIViewState GetState()
		{
			return null;
		}
	}
}
