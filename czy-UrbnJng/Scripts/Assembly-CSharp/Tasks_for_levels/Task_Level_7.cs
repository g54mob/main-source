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
	public class Task_Level_7 : MonoBehaviour, ITask, ISavedProgress, ISavedProgressReader
	{
		private delegate void TaskDelegate();

		private bool[] taskDone = new bool[8];

		private List<int> currentTasks = new List<int>();

		public LayerMask interactableLayerMask;

		public LayerMask plantLayerMask;

		[SerializeField]
		private Collider coffeeZone;

		[SerializeField]
		private Collider stairsZone;

		[SerializeField]
		private Collider tableZone;

		[SerializeField]
		private Collider seedlingsZone;

		[SerializeField]
		private Collider emptyTableZone1;

		[SerializeField]
		private Collider emptyTableZone2;

		[SerializeField]
		private Collider streetZone;

		[SerializeField]
		private Collider tableZone1;

		[SerializeField]
		private Collider tableZone2;

		[SerializeField]
		private Collider terrariumZone;

		[SerializeField]
		private Collider wallPlantZone;

		[SerializeField]
		private List<int> tasksReward;

		[SerializeField]
		private List<TaskUI> tasksUI;

		[SerializeField]
		private List<GameObject> plantsForDelivery;

		[SerializeField]
		private BoxOnLevel box;

		[SerializeField]
		private BoxOnLevel boxWithFertilizers;

		[SerializeField]
		private BoxOnLevel boxWithFurniture;

		private Vector3 bearStartPosition;

		private ITaskService taskService;

		private bool taskCat_Start;

		private Vector3 hatStartPosition;

		private const int LevelNumber = 7;

		private PlayerProgress progress;

		private TaskDelegate[] taskDelegates;

		public event Action TaskFinished;

		private void Awake()
		{
			taskService = AllServices.Container.Single<ITaskService>();
			taskDelegates = new TaskDelegate[8] { Task_0_FinishBoxesOnTheFirstFloor, Task_1_Signboard, Task_2_PlantInCoffeeZone, Task_3_PlantsForDelivery, Task_4_PlantsInTerrarium, Task_5_PlantsStars, Task_6_Seedling, Task_7_FlowerOnTables };
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
				if (!progress.ACH_TaskDoneList.Contains(7))
				{
					progress.ACH_TaskDoneList.Add(7);
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

		private void Task_0_FinishBoxesOnTheFirstFloor()
		{
			int num = 0;
			int num2 = 0;
			if (box.boxIsFinished)
			{
				num2++;
			}
			if (boxWithFertilizers.boxIsFinished)
			{
				num2++;
			}
			if (boxWithFurniture.boxIsFinished)
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

		private void Task_1_Signboard()
		{
			int num = 1;
			if (Physics.OverlapBox(streetZone.bounds.center, streetZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "Signboard") == 1)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_2_PlantInCoffeeZone()
		{
			int num = 2;
			Collider[] array = Physics.OverlapBox(coffeeZone.bounds.center, coffeeZone.bounds.extents, Quaternion.identity, plantLayerMask);
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
			string update = $"{num2}/{3}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 3)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_3_PlantsForDelivery()
		{
			int num = 3;
			int num2 = 0;
			foreach (GameObject item in plantsForDelivery)
			{
				if (item.activeInHierarchy)
				{
					num2++;
				}
			}
			string update = $"{3 - num2}/{3}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 0)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_4_PlantsInTerrarium()
		{
			int num = 4;
			Collider[] array = Physics.OverlapBox(terrariumZone.bounds.center, terrariumZone.bounds.extents, Quaternion.identity, plantLayerMask);
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
			string update = $"{num2}/{4}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 4)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_6_Seedling()
		{
			int num = 6;
			int num2 = Physics.OverlapBox(seedlingsZone.bounds.center, seedlingsZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "Seedling");
			string update = $"{num2}/{15}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 15)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_7_FlowerOnTables()
		{
			int num = 7;
			if (emptyTableZone1.gameObject.activeInHierarchy)
			{
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
		}

		private void Task_8_PlantOnWall()
		{
			int num = 8;
			Collider[] array = Physics.OverlapBox(wallPlantZone.bounds.center, wallPlantZone.bounds.extents, Quaternion.identity, plantLayerMask);
			int num2 = 0;
			Collider[] array2 = array;
			foreach (Collider obj in array2)
			{
				if (obj.transform.parent.transform.parent.TryGetComponent<Plant>(out var component) && component.IsWallPlant())
				{
					num2++;
				}
				if (obj.transform.parent.transform.parent.transform.parent.TryGetComponent<Plant>(out var component2) && component2.IsWallPlant())
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

		private void Task_7_EmptyTables()
		{
			int num = 7;
			if (emptyTableZone1.gameObject.activeInHierarchy)
			{
				Collider[] source = Physics.OverlapBox(emptyTableZone1.bounds.center, emptyTableZone1.bounds.extents, Quaternion.identity, interactableLayerMask);
				Collider[] source2 = Physics.OverlapBox(emptyTableZone2.bounds.center, emptyTableZone2.bounds.extents, Quaternion.identity, interactableLayerMask);
				if (source.Count((Collider collider) => collider.name == "FlowerBox") + source2.Count((Collider collider) => collider.name == "FlowerBox") == 0)
				{
					TaskDone(num, tasksReward[num]);
				}
			}
		}

		private void Task_7_BigPlantsStars()
		{
			int num = 7;
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

		private void Task_9_MediumPlantOnTable()
		{
			int num = 9;
			Collider[] array = Physics.OverlapBox(tableZone.bounds.center, tableZone.bounds.extents, Quaternion.identity, plantLayerMask);
			int num2 = 0;
			Collider[] array2 = array;
			foreach (Collider obj in array2)
			{
				if (obj.transform.parent.transform.parent.TryGetComponent<Plant>(out var component) && component.plantSize == PlantSize.Middle)
				{
					num2++;
				}
				if (obj.transform.parent.transform.parent.transform.parent.TryGetComponent<Plant>(out var component2) && component2.plantSize == PlantSize.Middle)
				{
					num2++;
				}
			}
			if (num2 >= 3)
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
