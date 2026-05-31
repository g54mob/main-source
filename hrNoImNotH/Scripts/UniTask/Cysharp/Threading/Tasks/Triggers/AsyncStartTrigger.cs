using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncStartTrigger : AsyncTriggerBase<AsyncUnit>
	{
		private bool called;

		private void Start()
		{
		}

		public UniTask StartAsync()
		{
			return default(UniTask);
		}
	}
}
