using System.Threading;
using NSMedieval.State.Timers;
using UnityEngine;

namespace NSMedieval
{
	public class TimerController : BaseTimerController<NSMedieval.State.Timers.Timer>
	{
		private static float timeSinceStartup;

		public static float TimeSinceStartup
		{
			get
			{
				return Volatile.Read(ref timeSinceStartup);
			}
			private set
			{
				Volatile.Write(ref timeSinceStartup, value);
			}
		}

		protected override int InitialSetCapacity => 30000;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public new static void OnDomainReload()
		{
			timeSinceStartup = 0f;
		}

		protected override void Update()
		{
			TimeSinceStartup = Time.time;
			base.Update();
		}

		protected override float GetDeltaTime()
		{
			return Time.deltaTime;
		}
	}
}
