namespace NSMedieval.State
{
	public class CaptiveNpcBehaviourProximity : HumanoidProximityBehaviour
	{
		private bool IsCaptiveLabourer => HumanoidInstance.ActiveBehaviour is CaptiveNpcBehaviour;

		private CaptiveNpcBehaviour CaptiveNpcBehaviour => HumanoidInstance.ActiveBehaviour as CaptiveNpcBehaviour;

		public CaptiveNpcBehaviourProximity(HumanoidInstance humanoidInstance)
			: base(humanoidInstance)
		{
		}
	}
}
