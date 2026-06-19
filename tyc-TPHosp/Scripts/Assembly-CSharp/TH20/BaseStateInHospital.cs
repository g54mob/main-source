namespace TH20
{
	public class BaseStateInHospital : MetagameState
	{
		protected BaseStateInHospital(MetagameMap map)
			: base(map)
		{
		}

		public virtual void OnReturnToMetagameMap()
		{
		}

		public override bool CanQuickLoadInThisState()
		{
			return true;
		}
	}
}
