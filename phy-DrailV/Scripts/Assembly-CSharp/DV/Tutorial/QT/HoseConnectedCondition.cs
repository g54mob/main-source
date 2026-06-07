namespace DV.Tutorial.QT
{
	public class HoseConnectedCondition : AQuickTutorialCondition
	{
		private readonly CouplingHoseAdapterBase hose;

		private readonly Coupler couplerOpen1;

		private readonly Coupler couplerOpen2;

		public HoseConnectedCondition(CouplingHoseAdapterBase hose, Coupler couplerOpen1 = null, Coupler couplerOpen2 = null)
		{
			this.hose = hose;
			this.couplerOpen1 = couplerOpen1;
			this.couplerOpen2 = couplerOpen2;
		}

		public override string Check()
		{
			if (hose != null)
			{
				if (hose.IsConnected)
				{
					if (couplerOpen1 != null && !couplerOpen1.IsCockOpen)
					{
						return "nope";
					}
					if (couplerOpen2 != null && !couplerOpen2.IsCockOpen)
					{
						return "nope";
					}
					return string.Empty;
				}
				return "nope";
			}
			return "nope";
		}
	}
}
