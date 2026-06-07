namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_TripThreshold : FimpossibleComponent
	{
		public float HitApplyThreshold = 20f;

		public float HitImpact = 1f;

		internal float LastImpulsePower;

		public override string HeaderInfo => "Info component to trigger ragdoll fall when hitted it with big enough velocity";
	}
}
