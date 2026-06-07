using Client;

namespace Motorways.Views
{
	public class UnbuiltMotorwayHandleView : BaseMotorwayHandleView
	{
		public override TickResult Tick(TimeInterval tickTime, float stepAlpha)
		{
			base.Tick(tickTime, stepAlpha);
			return TickResult.StopTicking;
		}
	}
}
