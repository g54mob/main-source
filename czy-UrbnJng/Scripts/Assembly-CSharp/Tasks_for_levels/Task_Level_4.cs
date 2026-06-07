using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services;
using Infrastructure.Services.BoxService;
using Infrastructure.Services.CoinService;
using Infrastructure.Services.PersistentProgress;
using MalbersAnimations;
using NewGameplayScripts;
using UnityEngine;

namespace Tasks_for_levels
{
	public class Task_Level_4 : MonoBehaviour, ITask, ISavedProgress, ISavedProgressReader
	{
		private delegate void TaskDelegate();

		private bool[] taskDone = new bool[8];

		private List<int> currentTasks = new List<int>();

		public LayerMask interactableLayerMask;

		[SerializeField]
		private AnimalAIClick cat;

		[SerializeField]
		private Collider bottlesZone;

		[SerializeField]
		private Collider workTableZone;

		[SerializeField]
		private List<int> tasksReward;

		[SerializeField]
		private List<TaskUI> tasksUI;

		[SerializeField]
		private BoxOnLevel box;

		[SerializeField]
		private BoxOnLevel boxWithDocuments;

		[SerializeField]
		private MovableItem badge;

		[SerializeField]
		private List<GameObject> trash;

		private Vector3 badgeStartPosition;

		private ITaskService taskService;

		private bool taskCat_Start;

		private const int LevelNumber = 4;

		private PlayerProgress progress;

		private TaskDelegate[] taskDelegates;

		public event Action TaskFinished;

		private void Awake()
		{
			taskService = AllServices.Container.Single<ITaskService>();
			taskDelegates = new TaskDelegate[8] { Task_0_FinishBox, Task_1_FinishBoxWithDocuments, Task_2_DocumentsOnTable, Task_3_Badge, Task_4_Bottles, Task_5_TrashOnFirstGround, Task_6_PlantsStars, Task_7_Cat };
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
				if (!progress.ACH_TaskDoneList.Contains(4))
				{
					progress.ACH_TaskDoneList.Add(4);
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

		private void Task_0_FinishBox()
		{
			int num = 0;
			if (box.boxIsFinished)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_1_FinishBoxWithDocuments()
		{
			int num = 1;
			if (boxWithDocuments.boxIsFinished)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_2_DocumentsOnTable()
		{
			int num = 2;
			int num2 = Physics.OverlapBox(workTableZone.bounds.center, workTableZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "Folder");
			string update = $"{num2}/{5}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 5)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_3_Badge()
		{
			int num = 3;
			if (badgeStartPosition == Vector3.zero)
			{
				badgeStartPosition = badge.transform.position;
			}
			if (Mathf.Abs(badge.transform.position.x - badgeStartPosition.x) > 0.1f || Mathf.Abs(badge.transform.position.y - badgeStartPosition.y) > 0.1f || Mathf.Abs(badge.transform.position.z - badgeStartPosition.z) > 0.1f)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_4_Bottles()
		{
			int num = 4;
			int num2 = Physics.OverlapBox(bottlesZone.bounds.center, bottlesZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "Bottle");
			string update = $"{num2}/{2}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 2)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_5_TrashOnFirstGround()
		{
			int num = 5;
			int num2 = 0;
			foreach (GameObject item in trash)
			{
				if (item.activeInHierarchy)
				{
					num2++;
				}
			}
			string update = $"{8 - num2}/{8}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 0)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_6_PlantsStars()
		{
			int num = 6;
			int num2 = 0;
			foreach (Plant item in PlantsOnSceneCollection.Instance.collection)
			{
				if (item.GetStars() == 3)
				{
					num2++;
				}
			}
			string update = $"{num2}/{2}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 2)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_7_Cat()
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
				int num = 7;
				cat.OnCatInteracted -= TaskCat_Finished;
				TaskDone(num, tasksReward[num]);
			}
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
			AllServices.Container.Single<IPersistentProgressService>().Progress.ACH_Cat++;
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.ACH_Cat >= 20)
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
