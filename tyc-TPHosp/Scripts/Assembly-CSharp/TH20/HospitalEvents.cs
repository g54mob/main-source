using System;

namespace TH20
{
	public class HospitalEvents : IGameEventsBase
	{
		public Action OnHospitalOpened;

		public Action OnHospitalClosed;

		public void Initialise()
		{
			GameEventsRegistry.RegisterLevelEvent(this);
		}

		public void VerifyEvents()
		{
			OnHospitalOpened.VerifyIsNull();
			OnHospitalClosed.VerifyIsNull();
		}
	}
}
