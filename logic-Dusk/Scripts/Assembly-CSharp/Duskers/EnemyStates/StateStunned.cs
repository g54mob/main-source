using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateStunned : BaseEnemyState
	{
		private IState _returnState;

		public override string StateId
		{
			get
			{
				return "Stunned";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateStunned(BaseEnemyBrain brain)
			: base(brain)
		{
		}

		public void Initialize(IState returnState)
		{
			_returnState = returnState;
		}

		public override void Update()
		{
			if (!_brain.ThisEnemy.IsStunned)
			{
				ChangeState(_returnState);
			}
			_brain.ThisEnemy.TimeStunned -= Time.deltaTime;
			if (_brain.ThisEnemy.TimeStunned <= 0f)
			{
				_brain.ThisEnemy.ClearStun();
				return;
			}
			float num = Random.Range(-0.3f, 0.3f);
			Vector3 a = _brain.ThisEnemy.MainVisibleObject.transform.position + _brain.ThisEnemy.MainVisibleObject.transform.up * (10f * num) * Time.deltaTime;
			float num2 = Vector3.Distance(_brain.ThisEnemy.MainVisibleObject.transform.position, _brain.ThisEnemy.StunPosition);
			float num3 = Vector3.Distance(a, _brain.ThisEnemy.StunPosition);
			if (num3 > num2 && num3 >= 0.5f)
			{
				num *= -1f;
			}
			_brain.ThisEnemy.MainVisibleObject.transform.position += _brain.ThisEnemy.MainVisibleObject.transform.up * (10f * num) * Time.deltaTime;
		}

		public override void EnterState()
		{
		}

		public override void ExitState()
		{
		}
	}
}
