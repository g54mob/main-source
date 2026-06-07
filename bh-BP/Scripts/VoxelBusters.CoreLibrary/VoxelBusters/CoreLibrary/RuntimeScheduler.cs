using System.Collections;
using System.Runtime.CompilerServices;

namespace VoxelBusters.CoreLibrary
{
	internal class RuntimeScheduler : PrivateSingletonBehaviour<RuntimeScheduler>, IScheduler
	{
		private event Callback UpdateEvent
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

		event Callback IScheduler.Update
		{
			add
			{
			}
			remove
			{
			}
		}

		public static RuntimeScheduler Initialize()
		{
			return null;
		}

		private void Update()
		{
		}

		private void SendUpdateEvent()
		{
		}

		void IScheduler.StartCoroutine(IEnumerator routine)
		{
		}

		void IScheduler.StopCoroutine(IEnumerator routine)
		{
		}

		void IScheduler.StopAllCoroutines()
		{
		}
	}
}
