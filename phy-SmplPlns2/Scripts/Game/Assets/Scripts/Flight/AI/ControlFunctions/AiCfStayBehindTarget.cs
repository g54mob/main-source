namespace Assets.Scripts.Flight.AI.ControlFunctions
{
	public class AiCfStayBehindTarget : AiCfFlyToLocation
	{
		public override float GetLeadTarget()
		{
			return 0f;
		}
	}
}
