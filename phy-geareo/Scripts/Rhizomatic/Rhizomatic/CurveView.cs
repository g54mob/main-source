using Rhizomatic.ImUI;

namespace Rhizomatic
{
	public class CurveView : ImUIView<CurveViewState>
	{
		public CurveField curveField;

		protected override void OnCreated()
		{
		}

		protected override void LoadState(CurveViewState state)
		{
		}

		public override ImUIViewState GetState()
		{
			return null;
		}
	}
}
