using System;

namespace R3
{
	internal sealed class SubjectToObserver<T> : Observer<T>
	{
		public SubjectToObserver(ISubject<T> subject)
		{
			_003Csubject_003EP = subject;
			base._002Ector();
		}

		protected override void OnNextCore(T value)
		{
			_003Csubject_003EP.OnNext(value);
		}

		protected override void OnErrorResumeCore(Exception error)
		{
			_003Csubject_003EP.OnErrorResume(error);
		}

		protected override void OnCompletedCore(Result result)
		{
			_003Csubject_003EP.OnCompleted(result);
		}
	}
}
