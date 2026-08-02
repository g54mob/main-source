using Rhizomatic.UI;

namespace Rhizomatic.ImUI
{
	public class Vector3View : ImUIView<Vector3ViewState>
	{
		public NumberField numberX;

		public NumberField numberY;

		public NumberField numberZ;

		protected override void OnCreated()
		{
		}

		protected override void LoadState(Vector3ViewState state)
		{
		}

		public override ImUIViewState GetState()
		{
			return null;
		}

		public void OnValueChange(NumberField number)
		{
		}

		public void SetValue(float num, NumberField field)
		{
		}
	}
}
