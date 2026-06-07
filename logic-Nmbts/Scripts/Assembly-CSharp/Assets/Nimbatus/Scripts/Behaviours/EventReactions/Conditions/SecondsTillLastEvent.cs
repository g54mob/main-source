using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class SecondsTillLastEvent : NimbatusCondition
	{
		public float MinSeconds;

		public float MaxSeconds;

		private float _startTime = -1f;

		private float _seconds;

		public override bool IsTrue()
		{
			if (_startTime < 0f)
			{
				_startTime = Time.time;
			}
			if (Time.time - _startTime > _seconds)
			{
				_startTime = Time.time;
				return true;
			}
			return false;
		}

		protected override void OnInit()
		{
			_seconds = Random.Range(MinSeconds, MaxSeconds);
			OwnWorldObject.OnUpdate += OwnWorldObject_OnUpdate;
			_startTime = -1f;
		}

		private void OwnWorldObject_OnUpdate()
		{
			if (_startTime > 0f && Time.time - _startTime > _seconds)
			{
				EventReaction.ExecuteEvent();
			}
		}

		protected override void OnRelease()
		{
			OwnWorldObject.OnUpdate -= OwnWorldObject_OnUpdate;
		}
	}
}
