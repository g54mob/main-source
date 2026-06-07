using System;
using System.Collections.Generic;
using System.Linq;
using Data.Enums;
using Infrastructure.Services;
using Infrastructure.Services.CoinService;
using Infrastructure.Services.PersistentProgress;
using MalbersAnimations;
using NewGameplayScripts;
using UnityEngine;

namespace Tasks_for_levels
{
	public class Task_Level_1 : MonoBehaviour, ITask, ISavedProgress, ISavedProgressReader
	{
		private delegate void TaskDelegate();

		private bool[] taskDone = new bool[8];

		private List<int> currentTasks = new List<int>();

		public LayerMask plantLayerMask;

		public LayerMask interactableLayerMask;

		[SerializeField]
		private MovableItem bear;

		[SerializeField]
		private Collider TVzone;

		[SerializeField]
		private AnimalAIClick cat;

		[SerializeField]
		private List<int> tasksReward;

		[SerializeField]
		private List<TaskUI> tasksUI;

		[SerializeField]
		private Lamp lamp_1;

		[SerializeField]
		private Lamp lamp_2;

		[SerializeField]
		private Humidifyer humidifyer;

		[SerializeField]
		private Collider shelfZone;

		[SerializeField]
		private Collider tableZone;

		[SerializeField]
		private JournalButtonUI journalButton;

		private Vector3 bearStartPosition;

		private ITaskService taskService;

		private bool taskCat_Start;

		private PlayerProgress progress;

		private const int LevelNumber = 1;

		private TaskDelegate[] taskDelegates;

		private bool taskJournal_Start;

		public event Action TaskFinished;

		private void Awake()
		{
			taskService = AllServices.Container.Single<ITaskService>();
			bearStartPosition = bear.transform.position;
			taskDelegates = new TaskDelegate[8] { Task_0_Journal, Task_1_Lamp, Task_2_Bear, Task_3_PlateAndCup, Task_4_Books, Task_5_Cactus, Task_6_Cat, Task_7_Stars };
			taskService.SetCurrentTask(this);
			if (cat != null)
			{
				cat.OnCatInteracted += CatCountUpdate;
			}
			progress = AllServices.Container.Single<IPersistentProgressService>().Progress;
		}

		public void UpdateSliders()
		{
			foreach (TaskUI item in tasksUI)
			{
				item.GenerateStrikeThroughLines();
			}
		}

		private void GetCurrentTasks()
		{
			currentTasks.Clear();
			int num = 0;
			for (int i = 0; i < taskDone.Length; i++)
			{
				if (!taskDone[i])
				{
					currentTasks.Add(i);
					num++;
					if (num >= 3)
					{
						break;
					}
				}
			}
			if (num == 0)
			{
				if (!progress.ACH_TaskDoneList.Contains(1))
				{
					progress.ACH_TaskDoneList.Add(1);
				}
				if (progress.ACH_TaskDoneList.Count >= 10)
				{
					SteamIntegration.Instance.UnlockAchievement("TASKS_16", 16);
				}
			}
			num = 0;
			foreach (TaskUI item in tasksUI)
			{
				if (item == null)
				{
					return;
				}
				item.UpdateTaskPrize(tasksReward[num]);
				item.gameObject.SetActive(value: false);
				num++;
			}
			foreach (int currentTask in currentTasks)
			{
				if (tasksUI.Count == 0)
				{
					break;
				}
				tasksUI[currentTask].gameObject.SetActive(value: true);
				if (tasksUI[currentTask].gameObject.activeInHierarchy)
				{
					tasksUI[currentTask].SlowShowTask();
				}
				else
				{
					tasksUI[currentTask].InstantShowTask();
				}
			}
		}

		public void CheckTasks()
		{
			if (taskDelegates == null)
			{
				return;
			}
			for (int i = 0; i < taskDelegates.Length; i++)
			{
				if (!taskDone[i] && currentTasks.Contains(i))
				{
					taskDelegates[i]();
				}
			}
		}

		private void Task_0_Journal()
		{
			if (!taskJournal_Start)
			{
				journalButton.OnFirstJournalButtonClick += JournalTask_Finished;
				taskJournal_Start = true;
			}
		}

		private void JournalTask_Finished(object sender, EventArgs e)
		{
			if (taskJournal_Start)
			{
				int num = 0;
				journalButton.OnFirstJournalButtonClick -= JournalTask_Finished;
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_1_Lamp()
		{
			int num = 1;
			if (lamp_1.isWorking)
			{
				TaskDone(num, tasksReward[num]);
			}
			else if (lamp_2.isWorking)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_2_Bear()
		{
			int num = 2;
			if (Mathf.Abs(bear.transform.position.x - bearStartPosition.x) > 0.1f || Mathf.Abs(bear.transform.position.y - bearStartPosition.y) > 0.1f || Mathf.Abs(bear.transform.position.z - bearStartPosition.z) > 0.1f)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_3_PlateAndCup()
		{
			int num = 3;
			int num2 = Physics.OverlapBox(tableZone.bounds.center, tableZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider1) => collider1.name == "DirtyDish");
			string update = $"{num2}/{2}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 2)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_4_Books()
		{
			int num = 4;
			int num2 = Physics.OverlapBox(shelfZone.bounds.center, shelfZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider1) => collider1.name == "Book");
			string update = $"{num2}/{12}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 12)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_5_Cactus()
		{
			int num = 5;
			Collider[] array = Physics.OverlapBox(TVzone.bounds.center, TVzone.bounds.extents, Quaternion.identity, plantLayerMask);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].transform.parent.transform.parent.TryGetComponent<Plant>(out var component) && component.GetObjectSO().objectName == PlantName.Cactus)
				{
					TaskDone(num, tasksReward[num]);
				}
			}
		}

		private void Task_6_Cat()
		{
			if (!taskCat_Start && !(cat == null))
			{
				cat.OnCatInteracted += TaskCat_Finished;
				taskCat_Start = true;
			}
		}

		private void TaskCat_Finished(object sender, EventArgs e)
		{
			if (taskCat_Start)
			{
				int num = 6;
				cat.OnCatInteracted -= TaskCat_Finished;
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_7_Stars()
		{
			int num = 7;
			int num2 = 0;
			foreach (Plant item in PlantsOnSceneCollection.Instance.collection)
			{
				if (item.GetStars() == 3)
				{
					num2++;
				}
			}
			string update = $"{num2}/{3}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 3)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_2_Humidify()
		{
			int num = 2;
			if (humidifyer.isWorking)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_5_Skin()
		{
			CollectionManager instance = CollectionManager.Instance;
			instance.OnBuySkin = (Action<ObjectSO, string>)Delegate.Combine(instance.OnBuySkin, new Action<ObjectSO, string>(TaskSkin));
		}

		private void TaskSkin(ObjectSO obj, string GUID)
		{
			int num = 5;
			TaskDone(num, tasksReward[num]);
			CollectionManager instance = CollectionManager.Instance;
			instance.OnBuySkin = (Action<ObjectSO, string>)Delegate.Remove(instance.OnBuySkin, new Action<ObjectSO, string>(TaskSkin));
		}

		private void OnDestroy()
		{
			taskService.ClearCurrentTask();
			if (cat != null)
			{
				cat.OnCatInteracted -= TaskCat_Finished;
			}
			if (cat != null)
			{
				cat.OnCatInteracted -= CatCountUpdate;
			}
			CollectionManager instance = CollectionManager.Instance;
			instance.OnBuySkin = (Action<ObjectSO, string>)Delegate.Remove(instance.OnBuySkin, new Action<ObjectSO, string>(TaskSkin));
			taskDelegates = null;
		}

		public void LoadProgress(PlayerProgress progress)
		{
			for (int i = 0; i < progress.TasksOnLevel.Count; i++)
			{
				taskDone[i] = progress.TasksOnLevel[i];
			}
			GetCurrentTasks();
		}

		public void UpdateProgress(PlayerProgress progress)
		{
			CheckTasks();
			progress.TasksOnLevel = new List<bool>();
			bool[] array = taskDone;
			foreach (bool item in array)
			{
				progress.TasksOnLevel.Add(item);
			}
		}

		private void TaskDone(int taskNumber, int taskReward)
		{
			if (!taskDone[taskNumber])
			{
				taskDone[taskNumber] = true;
				AllServices.Container.Single<ICoinService>().AddCoin(taskReward);
				this.TaskFinished?.Invoke();
				if (tasksUI[taskNumber].gameObject.activeInHierarchy)
				{
					tasksUI[taskNumber].TaskDone(OnTaskCompleted);
				}
				else
				{
					GetCurrentTasks();
				}
			}
		}

		private void OnTaskCompleted()
		{
			GetCurrentTasks();
			CheckTasks();
		}

		private void CatCountUpdate(object sender, EventArgs e)
		{
			progress.ACH_Cat++;
			if (progress.ACH_Cat >= 20)
			{
				SteamIntegration.Instance.UnlockAchievement("CAT_22", 22);
			}
		}

		public string GetFinalTasksCount()
		{
			int num = 0;
			bool[] array = taskDone;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i])
				{
					num++;
				}
			}
			return num + " / " + taskDone.Length;
		}
	}
}
