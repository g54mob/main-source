using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Dreamteck
{
	public class AsyncJobSystem : MonoBehaviour
	{
		public class AsyncJobOperation : CustomYieldInstruction
		{
			private IJobData _job;

			public override bool keepWaiting => false;

			public AsyncJobOperation(IJobData job)
			{
			}
		}

		public interface IJobData
		{
			bool done { get; }

			void Initialize();

			void Next();

			void Complete();
		}

		public class JobData<T> : IJobData
		{
			private int _index;

			private int _iterations;

			private IEnumerable<T> _collection;

			private Action<JobData<T>> _onComplete;

			private Action<JobData<T>> _onIteration;

			private IEnumerator<T> _enumerator;

			public T current => default(T);

			public int index => 0;

			public IEnumerable<T> collection => null;

			public bool done { get; private set; }

			public JobData(IEnumerable<T> collection, int iterations, Action<JobData<T>> onIteration)
			{
			}

			public JobData(IEnumerable<T> collection, int iterations, Action<JobData<T>> onIteration, Action<JobData<T>> onComplete)
			{
			}

			public void Initialize()
			{
			}

			public void Complete()
			{
			}

			public void Next()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CJobCoroutine_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AsyncJobSystem _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CJobCoroutine_003Ed__5(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private Queue<IJobData> _jobs;

		private IJobData _currentJob;

		private bool _isWorking;

		public AsyncJobOperation ScheduleJob<T>(JobData<T> data)
		{
			return null;
		}

		private void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CJobCoroutine_003Ed__5))]
		private IEnumerator JobCoroutine()
		{
			return null;
		}
	}
}
