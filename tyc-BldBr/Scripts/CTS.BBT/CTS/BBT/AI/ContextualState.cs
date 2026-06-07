using CTS.Core;

namespace CTS.BBT.AI
{
	public abstract class ContextualState : State<Agent>
	{
		protected readonly float speed;

		public ContextualState(float speed)
		{
			this.speed = speed;
		}

		public virtual void OnEnterFromSave()
		{
			base.parent.SetSpeed(speed);
		}

		public override void OnStateEnter()
		{
			base.parent.SetSpeed(speed);
		}
	}
}
