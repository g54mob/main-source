using System.Threading;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers
{
	[DisallowMultipleComponent]
	public sealed class AsyncRenderImageTrigger : AsyncTriggerBase<(RenderTexture source, RenderTexture destination)>
	{
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
		}

		public IAsyncOnRenderImageHandler GetOnRenderImageAsyncHandler()
		{
			return null;
		}

		public IAsyncOnRenderImageHandler GetOnRenderImageAsyncHandler(CancellationToken cancellationToken)
		{
			return null;
		}

		public UniTask<(RenderTexture, RenderTexture)> OnRenderImageAsync()
		{
			return default(UniTask<(RenderTexture, RenderTexture)>);
		}

		public UniTask<(RenderTexture, RenderTexture)> OnRenderImageAsync(CancellationToken cancellationToken)
		{
			return default(UniTask<(RenderTexture, RenderTexture)>);
		}
	}
}
