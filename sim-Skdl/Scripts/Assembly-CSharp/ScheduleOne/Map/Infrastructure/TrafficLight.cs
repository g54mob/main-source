using ScheduleOne.Misc;
using UnityEngine;

namespace ScheduleOne.Map.Infrastructure
{
	public class TrafficLight : MonoBehaviour
	{
		public enum State
		{
			Red = 0,
			Orange = 1,
			Green = 2
		}

		[SerializeField]
		private ToggleableLight _redLight;

		[SerializeField]
		private ToggleableLight _orangeLight;

		[SerializeField]
		private ToggleableLight _greenLight;

		private State _state;

		public State CurrentState
		{
			get
			{
				return default(State);
			}
			set
			{
			}
		}

		protected virtual void ApplyState()
		{
		}
	}
}
