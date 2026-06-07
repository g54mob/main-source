using System;

namespace BestHTTP.SignalRCore
{
	public sealed class UploadChannel<TResult, T> : IDisposable
	{
		public IUPloadItemController<TResult> Controller { get; private set; }

		public int ParamIdx { get; private set; }

		public bool IsFinished
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public string StreamingId => null;

		internal UploadChannel(IUPloadItemController<TResult> ctrl, int paramIdx)
		{
		}

		public void Upload(T item)
		{
		}

		public void Cancel()
		{
		}

		public void Finish()
		{
		}

		void IDisposable.Dispose()
		{
		}
	}
}
