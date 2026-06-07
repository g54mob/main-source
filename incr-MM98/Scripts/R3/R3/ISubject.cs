using System;

namespace R3
{
	public interface ISubject<T>
	{
		IDisposable Subscribe(Observer<T> observer);

		void OnNext(T value);

		void OnErrorResume(Exception error);

		void OnCompleted(Result complete);
	}
}
