using NSMedieval.State.Timers;
using UnityEngine;

namespace NSMedieval
{
	public class UnscaledTimerController : BaseTimerController<UnscaledTimer>
	{
		protected override int InitialSetCapacity => 30;

		protected override float GetDeltaTime()
		{
			if (Time.timeScale == 0f)
			{
				return Time.unscaledDeltaTime;
			}
			return Time.deltaTime / Time.timeScale;
		}
	}
}
