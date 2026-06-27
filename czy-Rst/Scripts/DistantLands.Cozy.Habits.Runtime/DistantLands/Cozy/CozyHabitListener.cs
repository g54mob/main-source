using DistantLands.Cozy.Data;
using UnityEngine;
using UnityEngine.Events;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyHabitListener : MonoBehaviour
	{
		public CozyHabitProfile habit;

		public UnityEvent startEvent;

		public UnityEvent updateEvent;

		public UnityEvent endEvent;

		public void OnEnable()
		{
			if (!(habit == null))
			{
				habit.onStart += startEvent.Invoke;
				habit.onUpdate += updateEvent.Invoke;
				habit.onEnd += endEvent.Invoke;
			}
		}

		public void OnDisable()
		{
			if (!(habit == null))
			{
				habit.onStart -= startEvent.Invoke;
				habit.onUpdate -= updateEvent.Invoke;
				habit.onEnd -= endEvent.Invoke;
			}
		}
	}
}
