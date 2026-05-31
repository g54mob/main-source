using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncSubmitTrigger : AsyncTriggerBase<BaseEventData>, ISubmitHandler, IEventSystemHandler
	{
		void ISubmitHandler.OnSubmit(BaseEventData eventData)
		{
		}

		public IAsyncOnSubmitHandler GetOnSubmitAsyncHandler()
		{
			return null;
		}

		public IAsyncOnSubmitHandler GetOnSubmitAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask<BaseEventData> OnSubmitAsync()
		{
			return default(UniTask<BaseEventData>);
		}

		public UniTask<BaseEventData> OnSubmitAsync(CancellationToken cancellationToken)
		{
			return default(UniTask<BaseEventData>);
		}
	}
}
