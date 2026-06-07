using System;
using System.Runtime.CompilerServices;
using ScheduleOne.DevUtilities;
using ScheduleOne.ScriptableObjects;

namespace ScheduleOne.Calling
{
	public class CallManager : Singleton<CallManager>
	{
		private PhoneCallData QueuedCallData { get; set; }

		public event Action<PhoneCallData> OnCallQueued
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void QueueCall(PhoneCallData data)
		{
		}

		public void ClearQueuedCall()
		{
		}

		private void CallCompleted(PhoneCallData call)
		{
		}
	}
}
