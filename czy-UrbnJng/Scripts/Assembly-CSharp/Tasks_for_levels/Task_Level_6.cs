using System;
using System.Collections.Generic;
using System.Linq;
using Data.Enums;
using Infrastructure.Services;
using Infrastructure.Services.BoxService;
using Infrastructure.Services.CoinService;
using Infrastructure.Services.PersistentProgress;
using NewGameplayScripts;
using UnityEngine;

namespace Tasks_for_levels
{
	public class Task_Level_6 : MonoBehaviour, ITask, ISavedProgress, ISavedProgressReader
	{
		private delegate void TaskDelegate();

		private bool[] taskDone = new bool[6];

		private List<int> currentTasks = new List<int>();

		public LayerMask interactableLayerMask;

		public LayerMask plantLayerMask;

		[SerializeField]
		private Collider roofZone;

		[SerializeField]
		private Collider vanZone;

		[SerializeField]
		private Collider benchZone;

		[SerializeField]
		private Collider tableZone1;

		[SerializeField]
		private Collider tableZone2;

		[SerializeField]
		private List<int> tasksReward;

		[SerializeField]
		private List<TaskUI> tasksUI;

		[SerializeField]
		private BoxOnLevel boxWithPots;

		[SerializeField]
		private BoxOnLevel boxWithPots2;

		[SerializeField]
		private BoxOnLevel boxWithFertilizers;

		[SerializeField]
		private List<GameObject> deliveryPlants;

		private Vector3 bearStartPosition;

		private ITaskService taskService;

		private bool taskCat_Start;

		private bool taskDog_Start;

		private Vector3 hatStartPosition;

		private const int LevelNumber = 6;

		private PlayerProgress progress;

		private TaskDelegate[] taskDelegates;

		public event Action TaskFinished;

		private void Awake()
		{
			taskService = AllServices.Container.Single<ITaskService>();
			taskDelegates = new TaskDelegate[6] { Task_0_FinishBoxes, Task_1_FlowerOnTables, Task_2_DeliveryPlants, Task_3_WoodenBoxes, Task_4_PlantsOnRoof, Task_5_PlantsStars };
			taskService.SetCurrentTask(this);
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
				if (!progress.ACH_TaskDoneList.Contains(6))
				{
					progress.ACH_TaskDoneList.Add(6);
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

		private void Task_0_FinishBoxes()
		{
			int num = 0;
			int num2 = 0;
			if (boxWithPots.boxIsFinished)
			{
				num2++;
			}
			if (boxWithPots2.boxIsFinished)
			{
				num2++;
			}
			if (boxWithFertilizers.boxIsFinished)
			{
				num2++;
			}
			string update = $"{num2}/{3}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 3)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_1_FlowerOnTables()
		{
			int num = 1;
			Collider[] array = Physics.OverlapBox(tableZone1.bounds.center, tableZone1.bounds.extents, Quaternion.identity, plantLayerMask);
			Collider[] array2 = Physics.OverlapBox(tableZone2.bounds.center, tableZone2.bounds.extents, Quaternion.identity, plantLayerMask);
			int num2 = 0;
			if (array.Length != 0)
			{
				num2++;
			}
			if (array2.Length != 0)
			{
				num2++;
			}
			string update = $"{num2}/{2}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 2)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_2_DeliveryPlants()
		{
			int num = 2;
			int num2 = 0;
			foreach (GameObject deliveryPlant in deliveryPlants)
			{
				if (deliveryPlant.activeInHierarchy)
				{
					num2++;
				}
			}
			string update = $"{5 - num2}/{5}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 0)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_3_WoodenBoxes()
		{
			int num = 3;
			int num2 = Physics.OverlapBox(roofZone.bounds.center, roofZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider1) => collider1.name == "WoodBox");
			string update = $"{3 - num2}/{3}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 0)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_4_PlantsOnRoof()
		{
			int num = 4;
			Collider[] array = Physics.OverlapBox(roofZone.bounds.center, roofZone.bounds.extents, Quaternion.identity, plantLayerMask);
			int num2 = 0;
			Collider[] array2 = array;
			foreach (Collider obj in array2)
			{
				if (obj.transform.parent.transform.parent.TryGetComponent<Plant>(out var _))
				{
					num2++;
				}
				if (obj.transform.parent.transform.parent.transform.parent.TryGetComponent<Plant>(out var _))
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

		private void Task_5_PlantsStars()
		{
			int num = 5;
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

		private void Task_2_SmallPlantsStars()
		{
			int num = 2;
			int num2 = 0;
			foreach (Plant item in PlantsOnSceneCollection.Instance.collection)
			{
				if (item.plantSize == PlantSize.Small && item.GetStars() == 2)
				{
					num2++;
				}
			}
			if (num2 >= 3)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_3_EmptyTables()
		{
			int num = 3;
			if (Physics.OverlapBox(roofZone.bounds.center, roofZone.bounds.extents, Quaternion.identity, interactableLayerMask).Length == 0)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_5_MiddlePlantsStars()
		{
			int num = 5;
			int num2 = 0;
			foreach (Plant item in PlantsOnSceneCollection.Instance.collection)
			{
				if (item.plantSize == PlantSize.Middle && item.GetStars() == 2)
				{
					num2++;
				}
			}
			if (num2 >= 2)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_7_CardboardBox()
		{
			int num = 7;
			if (Physics.OverlapBox(vanZone.bounds.center, vanZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "CardboardBox") == 3)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_9_BigPlantsStars()
		{
			int num = 9;
			int num2 = 0;
			foreach (Plant item in PlantsOnSceneCollection.Instance.collection)
			{
				if (item.plantSize == PlantSize.Big && item.GetStars() == 2)
				{
					num2++;
				}
			}
			if (num2 >= 2)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_11_SmallPlantOnBench()
		{
			int num = 11;
			Collider[] array = Physics.OverlapBox(benchZone.bounds.center, benchZone.bounds.extents, Quaternion.identity, plantLayerMask);
			int num2 = 0;
			Collider[] array2 = array;
			foreach (Collider obj in array2)
			{
				if (obj.transform.parent.transform.parent.TryGetComponent<Plant>(out var component) && component.plantSize == PlantSize.Small)
				{
					num2++;
				}
				if (obj.transform.parent.transform.parent.transform.parent.TryGetComponent<Plant>(out var component2) && component2.plantSize == PlantSize.Small)
				{
					num2++;
				}
			}
			if (num2 >= 4)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void OnDestroy()
		{
			taskService.ClearCurrentTask();
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
