using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncDropTrigger : AsyncTriggerBase<PointerEventData>, IDropHandler, IEventSystemHandler
	{
		void IDropHandler.OnDrop(PointerEventData eventData)
		{
		}

		public IAsyncOnDropHandler GetOnDropAsyncHandler()
		{
			return null;
		}

		public IAsyncOnDropHandler GetOnDropAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask<PointerEventData> OnDropAsync()
		{
			return default(UniTask<PointerEventData>);
		}

		public UniTask<PointerEventData> OnDropAsync(CancellationToken cancellationToken)
		{
			return default(UniTask<PointerEventData>);
		}
	}
}
