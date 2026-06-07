using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services;
using Infrastructure.Services.BoxService;
using Infrastructure.Services.CoinService;
using Infrastructure.Services.PersistentProgress;
using NewGameplayScripts;
using UnityEngine;

namespace Tasks_for_levels
{
	public class Task_Level_9 : MonoBehaviour, ITask, ISavedProgress, ISavedProgressReader
	{
		private delegate void TaskDelegate();

		private bool[] taskDone = new bool[10];

		private List<int> currentTasks = new List<int>();

		public LayerMask interactableLayerMask;

		public LayerMask plantLayerMask;

		[SerializeField]
		private Collider treatsZone;

		[SerializeField]
		private Collider gardenDen1Zone;

		[SerializeField]
		private Collider gardenDen2Zone;

		[SerializeField]
		private Collider palletZone;

		[SerializeField]
		private Collider truckZone;

		[SerializeField]
		private Collider enterZone;

		[SerializeField]
		private Collider terrariumZone;

		[SerializeField]
		private Collider wallPlantZone;

		[SerializeField]
		private List<int> tasksReward;

		[SerializeField]
		private List<TaskUI> tasksUI;

		[SerializeField]
		private BoxOnLevel boxWithPots;

		[SerializeField]
		private BoxOnLevel boxWithPots2;

		[SerializeField]
		private BoxOnLevel boxWithPlates;

		[SerializeField]
		private BoxOnLevel boxWithFertilizers;

		[SerializeField]
		private GameObject secondFloor;

		[SerializeField]
		private List<GameObject> emptyBoxes;

		private const int LevelNumber = 9;

		private ITaskService taskService;

		private PlayerProgress progress;

		private TaskDelegate[] taskDelegates;

		public event Action TaskFinished;

		private void Awake()
		{
			taskService = AllServices.Container.Single<ITaskService>();
			taskDelegates = new TaskDelegate[10] { Task_0_FinishBoxesOnTheFirstFloor, Task_1_BoxesInTruck, Task_2_Balloons, Task_3_FinishBoxSecondFloor, Task_4_EmptyBoxes, Task_5_PlantsInTerrarium, Task_6_Seedling, Task_7_PlantsStars, Task_8_Treats, Task_9_BagDirt };
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
				if (!progress.ACH_TaskDoneList.Contains(9))
				{
					progress.ACH_TaskDoneList.Add(9);
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
			if (boxWithPots.boxIsFinished)
			{
				num2++;
			}
			if (boxWithPots2.boxIsFinished)
			{
				num2++;
			}
			if (boxWithPlates.boxIsFinished)
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

		private void Task_1_BoxesInTruck()
		{
			int num = 1;
			int num2 = Physics.OverlapBox(truckZone.bounds.center, truckZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "DeliveryBox");
			string update = $"{num2}/{9}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 9)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_2_Balloons()
		{
			int num = 2;
			int num2 = Physics.OverlapBox(enterZone.bounds.center, enterZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "Balloon");
			string update = $"{num2}/{4}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 4)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_3_FinishBoxSecondFloor()
		{
			int num = 3;
			if (boxWithFertilizers.boxIsFinished)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_4_EmptyBoxes()
		{
			if (!secondFloor.activeInHierarchy)
			{
				return;
			}
			int num = 4;
			int num2 = 0;
			foreach (GameObject emptyBox in emptyBoxes)
			{
				if (emptyBox.activeInHierarchy)
				{
					num2++;
				}
			}
			string update = $"{13 - num2}/{13}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 0)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_5_PlantsInTerrarium()
		{
			int num = 5;
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

		private void Task_6_Seedling()
		{
			int num = 6;
			Collider[] source = Physics.OverlapBox(gardenDen1Zone.bounds.center, gardenDen1Zone.bounds.extents, Quaternion.identity, interactableLayerMask);
			int num2 = source.Count((Collider collider) => collider.name == "Seedling");
			source = Physics.OverlapBox(gardenDen2Zone.bounds.center, gardenDen2Zone.bounds.extents, Quaternion.identity, interactableLayerMask);
			num2 += source.Count((Collider collider) => collider.name == "Seedling");
			string update = $"{num2}/{32}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 32)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_7_PlantsStars()
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
			string update = $"{num2}/{4}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 4)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_8_Treats()
		{
			int num = 8;
			int num2 = Physics.OverlapBox(treatsZone.bounds.center, treatsZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "Treat");
			string update = $"{num2}/{10}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 10)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_9_BagDirt()
		{
			int num = 9;
			int num2 = Physics.OverlapBox(palletZone.bounds.center, palletZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "BagDirt1");
			string update = $"{num2}/{16}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 16)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_10_PlantOnWall()
		{
			int num = 10;
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
			string update = $"{num2}/{4}";
			tasksUI[num].UpdateTaskCount(update);
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
