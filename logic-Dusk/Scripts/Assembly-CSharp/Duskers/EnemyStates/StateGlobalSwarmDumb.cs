using System;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateGlobalSwarmDumb : StateGlobalCommon
	{
		private static System.Random _randomGenerator = new System.Random();

		private SwarmDumbBrain _dumbBrain;

		public override string StateId
		{
			get
			{
				return "GlobalSwarmDumb";
			}
		}

		public StateGlobalSwarmDumb(BaseEnemyBrain brain)
			: base(brain)
		{
			_dumbBrain = (SwarmDumbBrain)brain;
		}

		public override IState GetStunReturnState()
		{
			return ((SwarmDumbBrain)_brain).StateSwarmDumbAttack;
		}

		public override void Update()
		{
			base.Update();
			_randomGenerator.Next();
			if (!_brain.ThisEnemy.IsStunned && !_brain.ThisEnemy.IsDead)
			{
				GameObject mainVisibleObject = _brain.ThisEnemy.MainVisibleObject;
				float num = Vector3.Distance(mainVisibleObject.transform.position, _brain.ThisEnemy.transform.position);
				if (num > _dumbBrain.SwarmEnemy.CurrentFlightRadius)
				{
					_brain.ThisEnemy.DisconnectOverlay();
					LookAt(mainVisibleObject, _brain.ThisEnemy.transform.position);
					mainVisibleObject.transform.Rotate(GetSimpleSwarmRandomRotation());
					_brain.ThisEnemy.ReconnectOverlay();
				}
				Vector3 vector = mainVisibleObject.transform.up * _dumbBrain.SwarmEnemy.CurrentFlightSpeed * Time.deltaTime;
				mainVisibleObject.transform.position += new Vector3(vector.x, vector.y, 0f);
			}
		}

		private Vector3 GetSimpleSwarmRandomRotation()
		{
			int num = _randomGenerator.Next(0, 90);
			float z = ((num < 45) ? (359f - (float)num) : ((float)num - 45f));
			return new Vector3(0f, 0f, z);
		}

		public void LookAt(GameObject objectToDoTheLookin, Vector3 lookPosition)
		{
			Quaternion rotation = Quaternion.LookRotation(lookPosition - objectToDoTheLookin.transform.position, Vector3.back);
			rotation.x = 0f;
			rotation.y = 0f;
			objectToDoTheLookin.transform.rotation = rotation;
		}
	}
}
