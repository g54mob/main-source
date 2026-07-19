using System;
using System.Collections;
using System.Collections.Generic;

namespace DepthFirstScheduler
{
	public class Schedulable<T> : ISchedulable
	{
		private List<ISchedulable> m_children = new List<ISchedulable>();

		public ISchedulable Parent { get; set; }

		public IScheduler Scheduler { get; private set; }

		public IFunctor<T> Func { get; private set; }

		public void AddChild(ISchedulable child)
		{
			child.Parent = this;
			m_children.Add(child);
		}

		public IEnumerable<ISchedulable> Traverse()
		{
			yield return this;
			foreach (ISchedulable child in m_children)
			{
				foreach (ISchedulable item in child.Traverse())
				{
					yield return item;
				}
			}
		}

		public Exception GetError()
		{
			return Func.GetError();
		}

		public Schedulable()
		{
		}

		public Schedulable(IScheduler scheduler, IFunctor<T> func)
		{
			Scheduler = scheduler;
			Func = func;
		}

		public ExecutionStatus Execute()
		{
			if (Func == null)
			{
				return ExecutionStatus.Done;
			}
			return Func.Execute();
		}

		public void ExecuteAll()
		{
			foreach (ISchedulable item in this.GetRoot().Traverse())
			{
				while (true)
				{
					switch (item.Execute())
					{
					case ExecutionStatus.Continue:
						continue;
					case ExecutionStatus.Error:
						throw item.GetError();
					}
					break;
				}
			}
		}

		public Schedulable<Unit> AddTask(IScheduler scheduler, Action pred)
		{
			return AddTask(scheduler, delegate
			{
				pred();
				return Unit.Default;
			});
		}

		public Schedulable<U> AddTask<U>(IScheduler scheduler, Func<U> pred)
		{
			Schedulable<U> schedulable = new Schedulable<U>(scheduler, Functor.Create(() => Unit.Default, (Unit _) => pred()));
			AddChild(schedulable);
			return schedulable;
		}

		public Schedulable<Unit> AddCoroutine(IScheduler scheduler, Func<IEnumerator> starter)
		{
			CoroutineFunctor<Unit> func = CoroutineFunctor.Create<Unit, Unit>(() => default(Unit), (Unit _) => starter());
			Schedulable<Unit> schedulable = new Schedulable<Unit>(scheduler, func);
			AddChild(schedulable);
			return schedulable;
		}

		public Schedulable<Unit> ContinueWith(IScheduler scheduler, Action<T> pred)
		{
			return ContinueWith(scheduler, delegate(T t)
			{
				pred(t);
				return Unit.Default;
			});
		}

		public Schedulable<U> ContinueWith<U>(IScheduler scheduler, Func<T, U> pred)
		{
			if (Parent == null)
			{
				throw new NoParentException();
			}
			Func<T> arg = null;
			if (Func != null)
			{
				arg = Func.GetResult;
			}
			Functor<U> func = Functor.Create(arg, pred);
			Schedulable<U> schedulable = new Schedulable<U>(scheduler, func);
			Parent.AddChild(schedulable);
			return schedulable;
		}

		public Schedulable<Unit> ContinueWithCoroutine(IScheduler scheduler, Func<IEnumerator> starter)
		{
			return ContinueWithCoroutine<Unit>(scheduler, (T _) => starter());
		}

		public Schedulable<U> ContinueWithCoroutine<U>(IScheduler scheduler, Func<T, IEnumerator> starter)
		{
			if (Parent == null)
			{
				throw new NoParentException();
			}
			Func<T> arg = null;
			if (Func != null)
			{
				arg = Func.GetResult;
			}
			CoroutineFunctor<U> func = CoroutineFunctor.Create<T, U>(arg, starter);
			Schedulable<U> schedulable = new Schedulable<U>(scheduler, func);
			Parent.AddChild(schedulable);
			return schedulable;
		}

		public Schedulable<Unit> OnExecute(IScheduler scheduler, Action<Schedulable<Unit>> pred)
		{
			if (Parent == null)
			{
				throw new NoParentException();
			}
			Func<T> arg = null;
			if (Func != null)
			{
				arg = Func.GetResult;
			}
			Schedulable<Unit> schedulable = new Schedulable<Unit>();
			schedulable.Func = Functor.Create(arg, delegate
			{
				pred(schedulable);
				return Unit.Default;
			});
			Parent.AddChild(schedulable);
			return schedulable;
		}
	}
	public static class Schedulable
	{
		public static Schedulable<Unit> Create()
		{
			return new Schedulable<Unit>().AddTask(Scheduler.CurrentThread, delegate
			{
			});
		}
	}
}
