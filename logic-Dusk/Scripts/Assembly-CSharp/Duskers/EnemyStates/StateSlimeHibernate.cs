using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateSlimeHibernate : BaseEnemyState
	{
		private SlimeBrain _slimeBrain;

		private float _hibernatingTimer;

		public override string StateId
		{
			get
			{
				return "SlimeHibernate";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateSlimeHibernate(BaseEnemyBrain brain)
			: base(brain)
		{
			_slimeBrain = (SlimeBrain)brain;
		}

		public override void Update()
		{
			_hibernatingTimer -= Time.deltaTime;
			if (_hibernatingTimer <= 0f)
			{
				_slimeBrain.SlimeEnemy.UnHibernate();
				_slimeBrain.OtherSlimes.ForEach(delegate(SlimeEnemy x)
				{
					x.UnHibernate();
				});
				ChangeState(_slimeBrain.StateSlimeReplicate);
				_slimeBrain.GeneralReplicateTimer = 20f;
				_slimeBrain.CombatReplicateTimer = 20f;
			}
			else if (!_slimeBrain.SlimeEnemy.IsHibernating)
			{
				ChangeState(_slimeBrain.StateSlimeReplicate);
			}
		}

		public override void EnterState()
		{
			_hibernatingTimer = 20f;
		}

		public override void ExitState()
		{
			_hibernatingTimer = 0f;
		}
	}
}
