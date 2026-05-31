using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TaskRandom : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CIEnumRunTaskAfterTut_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool fromMarkAsDoneTask;

		public TaskRandom _003C_003E4__this;

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
		public _003CIEnumRunTaskAfterTut_003Ed__11(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CRandomTask_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TaskRandom _003C_003E4__this;

		public TaskDataType taskLevel;

		public Action countOfTask;

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
		public _003CRandomTask_003Ed__13(int _003C_003E1__state)
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

	public bool randomTasks;

	public SunController sunController;

	public TaskManager taskManager;

	public TasksComputers tasksComputers;

	public TasksPrinters tasksPrinters;

	public TasksNetwork tasksNetwork;

	public TaskRCP tasksRCP;

	public TaskRandomMaxTaskByLevel[] maxCountOfTask;

	public Coroutine TaskCoroutine;

	[ContextMenu("Run Task After Tut")]
	public void RunTaskAfterTut()
	{
	}

	public void StartTaskRandomThread(bool fromMarkAsDoneTask = false)
	{
	}

	[IteratorStateMachine(typeof(_003CIEnumRunTaskAfterTut_003Ed__11))]
	private IEnumerator IEnumRunTaskAfterTut(bool fromMarkAsDoneTask)
	{
		return null;
	}

	private int getMaxTask()
	{
		return 0;
	}

	[IteratorStateMachine(typeof(_003CRandomTask_003Ed__13))]
	private IEnumerator RandomTask(TaskDataType taskLevel, Action countOfTask)
	{
		return null;
	}

	public void RandomTaskTut(string device = "", int selectTask = -1, TaskDataType taskLevel = TaskDataType.Null)
	{
	}

	private bool CheckTheTime()
	{
		return false;
	}
}
