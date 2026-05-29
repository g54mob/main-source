using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDelayedRebuildLayer_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TaskManager _003C_003E4__this;

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
		public _003CDelayedRebuildLayer_003Ed__42(int _003C_003E1__state)
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
	private sealed class _003CEnumUpdateUI_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TaskManager _003C_003E4__this;

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
		public _003CEnumUpdateUI_003Ed__44(int _003C_003E1__state)
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
	private sealed class _003CRefreshTasksTime_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TaskManager _003C_003E4__this;

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
		public _003CRefreshTasksTime_003Ed__45(int _003C_003E1__state)
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

	public static TaskManager instance;

	public TaskRandom taskRandom;

	public TasksComputers tasksComputer;

	public TasksPrinters tasksPrinters;

	public SunController sunController;

	public SaveManager saveManager;

	[Header("UI Pause")]
	public VerticalLayoutGroup VerticalLayoutGroupTaskDataView;

	public RectTransform PauseUI_ViewTaskParent;

	public RectTransform PauseUI_ViewTaskPrefab;

	public TMP_Text PauseUI_Title;

	public TMP_Text PauseUI_Description;

	public Image PauseUI_TaskTime;

	public Image PauseUI_TaskTimeBarColor;

	public TMP_Text PauseUI_TaskTimeText;

	public RectTransform PauseUI_OrderDataParent;

	public RectTransform PauseUI_TaskJournalParent;

	public RectTransform PauseUI_TaskJournalPrefab;

	public RectTransform PauseUI_AwardsParent;

	public RectTransform PauseUI_AwardsPrefab;

	public RectTransform PauseUI_PenaltiesParent;

	public RectTransform PauseUI_PenaltiesPrefab;

	public RectTransform PauseUI_MarkAsDoneTaskButton;

	public RectTransform PauseUI_NoTaskSelected;

	public RectTransform PauseUI_ViewTask;

	[Header("UI Tips")]
	public RectTransform DataTaskView;

	public RectTransform TipView;

	public TMP_Text TipDes;

	public RectTransform TipButtonOpen;

	public RectTransform TipButtonClose;

	[Header("Progress bar")]
	public Gradient ColorProgressBar;

	[Header("Tasks")]
	public List<TaskData> activeTasks;

	private TaskData nowOpenTask;

	private Coroutine coroutineUpdateUI;

	public TaskData GetNowOpenTask()
	{
		return null;
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	[ContextMenu("Save Tasks")]
	public void Save()
	{
	}

	public void Load()
	{
	}

	public void EndOfDay()
	{
	}

	public void EndOfDayAfter()
	{
	}

	[ContextMenu("Get GetChapterCompleted")]
	public void GetChapterCompleted()
	{
	}

	public void ViewTask(string _idTask)
	{
	}

	public void OpenTask(TaskData task)
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedRebuildLayer_003Ed__42))]
	private IEnumerator DelayedRebuildLayer()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CEnumUpdateUI_003Ed__44))]
	private IEnumerator EnumUpdateUI()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CRefreshTasksTime_003Ed__45))]
	private IEnumerator RefreshTasksTime()
	{
		return null;
	}

	public void ButtonOpenTip()
	{
	}

	public void ButtonCloseTip()
	{
	}

	public void RefreshUI()
	{
	}

	public void OpenMenu()
	{
	}

	public void VerifyAllTask()
	{
	}

	public static T GetComponent<T>(UnityEngine.Object[] parameters, int id) where T : class
	{
		return null;
	}

	private void RefreshButton_MarkAsDoneTask()
	{
	}

	public void MarkAsDoneTask()
	{
	}
}
