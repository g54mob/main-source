using Rhizomatic.UI;
using UnityEngine.UI;

namespace Rhizomatic.ImUI
{
	public class ButtonView : ImUIView<ButtonViewState>
	{
		public TextAdapter label;

		public Selectable selectable;

		private bool pressed;

		protected override void LoadState(ButtonViewState state)
		{
		}

		public override ImUIViewState GetState()
		{
			return null;
		}

		public void Press()
		{
		}

		public override void Used()
		{
		}
	}
}
