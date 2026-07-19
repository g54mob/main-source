using System;

namespace DepthFirstScheduler
{
	public class Functor<T> : IFunctor<T>
	{
		private T m_result;

		private Exception m_error;

		private Action m_pred;

		public T GetResult()
		{
			return m_result;
		}

		public Exception GetError()
		{
			return m_error;
		}

		public Functor(Func<T> func)
		{
			Functor<T> functor = this;
			m_pred = delegate
			{
				functor.m_result = func();
			};
		}

		public ExecutionStatus Execute()
		{
			try
			{
				m_pred();
				return ExecutionStatus.Done;
			}
			catch (Exception error)
			{
				m_error = error;
				return ExecutionStatus.Error;
			}
		}
	}
	public static class Functor
	{
		public static Functor<T> Create<S, T>(Func<S> arg, Func<S, T> pred)
		{
			return new Functor<T>(() => pred(arg()));
		}
	}
}
