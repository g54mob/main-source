using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncMoveTrigger : AsyncTriggerBase<AxisEventData>, IMoveHandler, IEventSystemHandler
	{
		void IMoveHandler.OnMove(AxisEventData eventData)
		{
		}

		public IAsyncOnMoveHandler GetOnMoveAsyncHandler()
		{
			return null;
		}

		public IAsyncOnMoveHandler GetOnMoveAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask<AxisEventData> OnMoveAsync()
		{
			return default(UniTask<AxisEventData>);
		}

		public UniTask<AxisEventData> OnMoveAsync(CancellationToken cancellationToken)
		{
			return default(UniTask<AxisEventData>);
		}
	}
}
