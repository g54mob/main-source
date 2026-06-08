using Rhizomatic.UI;

namespace Rhizomatic.ImUI
{
	public class TextareaView : ImUIView<TextareaViewState>
	{
		public InputFieldAdapter inputField;

		protected override void OnCreated()
		{
		}

		protected override void LoadState(TextareaViewState state)
		{
		}

		public override ImUIViewState GetState()
		{
			return null;
		}
	}
}
