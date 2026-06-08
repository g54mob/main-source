using System.Threading;
using UnityEngine;

namespace LaundryBear
{
	public class StartAndWaitForThread : CustomYieldInstruction
	{
		private Thread m_thread;

		public override bool keepWaiting => m_thread.IsAlive;

		public StartAndWaitForThread(Thread thread)
		{
			m_thread = thread;
			m_thread.Start();
		}
	}
}
