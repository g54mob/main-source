public class FarmerStateRocketRide : FarmerStateBase
{
	public override void StartState()
	{
		base.StartState();
		m_Farmer.m_ModelRoot.SetActive(false);
	}

	public override void EndState()
	{
		base.EndState();
		m_Farmer.m_ModelRoot.SetActive(true);
	}

	public override void UpdateState()
	{
		base.UpdateState();
	}
}
