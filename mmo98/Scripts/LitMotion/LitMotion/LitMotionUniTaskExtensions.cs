using System.Threading;
using Cysharp.Threading.Tasks;

namespace LitMotion
{
	public static class LitMotionUniTaskExtensions
	{
		public static UniTask ToUniTask(this MotionHandle handle, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!handle.IsActive())
			{
				return UniTask.CompletedTask;
			}
			short token;
			return new UniTask(UniTaskMotionTaskSource.Create(handle, CancelBehavior.Cancel, cancelAwaitOnMotionCanceled: true, cancellationToken, out token), token);
		}

		public static UniTask ToUniTask(this MotionHandle handle, CancelBehavior cancelBehavior, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!handle.IsActive())
			{
				return UniTask.CompletedTask;
			}
			short token;
			return new UniTask(UniTaskMotionTaskSource.Create(handle, cancelBehavior, cancelAwaitOnMotionCanceled: true, cancellationToken, out token), token);
		}

		public static UniTask ToUniTask(this MotionHandle handle, CancelBehavior cancelBehavior, bool cancelAwaitOnMotionCanceled, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (!handle.IsActive())
			{
				return UniTask.CompletedTask;
			}
			short token;
			return new UniTask(UniTaskMotionTaskSource.Create(handle, cancelBehavior, cancelAwaitOnMotionCanceled, cancellationToken, out token), token);
		}

		public static MotionHandle BindToAsyncReactiveProperty<TValue, TOptions, TAdapter>(this MotionBuilder<TValue, TOptions, TAdapter> builder, AsyncReactiveProperty<TValue> reactiveProperty) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			Error.IsNull(reactiveProperty);
			return builder.Bind(reactiveProperty, delegate(TValue x, AsyncReactiveProperty<TValue> target)
			{
				target.Value = x;
			});
		}
	}
}
