namespace Duskers.EnemyStates
{
	public class StateNil : BaseEnemyState
	{
		public override string StateId
		{
			get
			{
				return "Nil";
			}
		}

		public StateNil(BaseEnemyBrain brain)
			: base(brain)
		{
		}
	}
}
