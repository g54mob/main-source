using Assets.Nimbatus.Scripts.WorldObjects;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class ExecuteActionOnOtherObject : NimbatusAction
	{
		public InteractiveWorldObject OtherObject;

		public NimbatusAction Action;

		protected override void OnInit()
		{
			base.OnInit();
			Action.Init(OtherObject.Behaviour, EventReaction, OtherObject);
		}

		protected override void OnRelease()
		{
			base.OnRelease();
			Action.Release();
		}

		public override void Execute()
		{
			Action.Execute();
		}
	}
}
