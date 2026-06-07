using UnityEngine;

namespace Assets.Nimbatus.Scripts.Missions.Objectives
{
	public class TimerObjective : MissionObjective
	{
		public float StartTime;

		public float EndTime;

		private bool _started;

		private float _timer;

		private bool Up
		{
			get
			{
				return StartTime < EndTime;
			}
		}

		public void UpdateTimer()
		{
			if (!_started)
			{
				_timer = StartTime;
				_started = true;
			}
			if (!IsFullfilled())
			{
				_timer += (Up ? Time.deltaTime : (0f - Time.deltaTime));
			}
		}

		public override bool IsFullfilled()
		{
			if (!_started)
			{
				return false;
			}
			if (!Up)
			{
				return _timer <= EndTime;
			}
			return _timer >= EndTime;
		}

		public override string GetStatusText()
		{
			float f = Mathf.Max(0f, _timer / 60f);
			float num = Mathf.Max(0f, _timer % 60f);
			return Mathf.FloorToInt(f) + ":" + ((num < 10f) ? "0" : "") + Mathf.FloorToInt(num);
		}

		public override void ResetProgress()
		{
			_started = false;
		}

		public override void Init()
		{
			_started = false;
		}

		public override void SetFullfilled()
		{
			_started = true;
			_timer = EndTime;
		}
	}
}
