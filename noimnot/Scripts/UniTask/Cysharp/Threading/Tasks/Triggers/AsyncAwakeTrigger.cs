using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncAwakeTrigger : AsyncTriggerBase<AsyncUnit>
	{
		public UniTask AwakeAsync()
		{
			return default(UniTask);
		}
	}
}
