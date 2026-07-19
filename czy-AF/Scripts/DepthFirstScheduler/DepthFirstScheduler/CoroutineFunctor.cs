using System;
using System.Collections;
using System.Collections.Generic;

namespace DepthFirstScheduler
{
	public class CoroutineFunctor<T> : IFunctor<T>
	{
		private Exception m_error;

		private Func<IEnumerator> m_starter;

		private Stack<IEnumerator> m_it;

		private IEnumerator m_last;

		public T GetResult()
		{
			if (m_last?.Current == null)
			{
				return default(T);
			}
			try
			{
				return (T)m_last.Current;
			}
			catch
			{
				return default(T);
			}
		}

		public Exception GetError()
		{
			return m_error;
		}

		public CoroutineFunctor(Func<IEnumerator> starter)
		{
			m_starter = starter;
		}

		public ExecutionStatus Execute()
		{
			if (m_it == null)
			{
				m_it = new Stack<IEnumerator>();
				m_it.Push(m_starter());
			}
			try
			{
				if (m_it.Count != 0)
				{
					if (m_it.Peek().MoveNext())
					{
						if (m_it.Peek().Current is IEnumerator item)
						{
							m_it.Push(item);
						}
					}
					else
					{
						m_last = m_it.Pop();
					}
					return ExecutionStatus.Continue;
				}
				return ExecutionStatus.Done;
			}
			catch (Exception error)
			{
				m_error = error;
				return ExecutionStatus.Error;
			}
		}
	}
	public static class CoroutineFunctor
	{
		public static CoroutineFunctor<T> Create<S, T>(Func<S> arg, Func<S, IEnumerator> starter)
		{
			return new CoroutineFunctor<T>(() => starter(arg()));
		}
	}
}
