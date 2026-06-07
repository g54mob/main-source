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
	public class Task_Level_5 : MonoBehaviour, ITask, ISavedProgress, ISavedProgressReader
	{
		private delegate void TaskDelegate();

		private bool[] taskDone = new bool[10];

		private List<int> currentTasks = new List<int>();

		public LayerMask interactableLayerMask;

		public LayerMask plantLayerMask;

		[SerializeField]
		private AnimalAIClick cat;

		[SerializeField]
		private MovableItem hat;

		[SerializeField]
		private Collider gardenZone;

		[SerializeField]
		private Collider hallZone;

		[SerializeField]
		private Collider flowerShelfZone;

		[SerializeField]
		private Collider fireplaceZone;

		[SerializeField]
		private Collider kitchenShelfForBoxesZone;

		[SerializeField]
		private Collider corridorZone;

		[SerializeField]
		private Collider momsRoomZone;

		[SerializeField]
		private Collider kitchenZone;

		[SerializeField]
		private Collider photoZone;

		[SerializeField]
		private Collider wallPlantZone;

		[SerializeField]
		private List<int> tasksReward;

		[SerializeField]
		private List<TaskUI> tasksUI;

		[SerializeField]
		private List<GameObject> cups;

		[SerializeField]
		private List<GameObject> tablets;

		[SerializeField]
		private BoxOnLevel boxWithPots;

		[SerializeField]
		private BoxOnLevel boxWithFertilizers;

		[SerializeField]
		private GameObject secondFloor;

		private Vector3 bearStartPosition;

		private ITaskService taskService;

		private bool taskCat_Start;

		private Vector3 hatStartPosition;

		private const int LevelNumber = 5;

		private PlayerProgress progress;

		private TaskDelegate[] taskDelegates;

		public event Action TaskFinished;

		private void Awake()
		{
			taskService = AllServices.Container.Single<ITaskService>();
			taskDelegates = new TaskDelegate[10] { Task_0_Cups, Task_1_FinishBoxWithFertilizers, Task_2_Cat, Task_3_PlantInPhotoZone, Task_4_Hat, Task_5_PlantsInHall, Task_6_Pills, Task_7_Seedling, Task_8_Chorons, Task_9_BoxesOnTable };
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
				if (!progress.ACH_TaskDoneList.Contains(5))
				{
					progress.ACH_TaskDoneList.Add(5);
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

		private void Task_0_PlantOnWall()
		{
			int num = 0;
			Collider[] array = Physics.OverlapBox(wallPlantZone.bounds.center, wallPlantZone.bounds.extents, Quaternion.identity, plantLayerMask);
			int num2 = 0;
			Collider[] array2 = array;
			foreach (Collider obj in array2)
			{
				if (obj.transform.parent.transform.parent.TryGetComponent<Plant>(out var component) && component.IsWallPlant())
				{
					num2++;
				}
				if (obj.transform.parent.transform.parent.transform.parent.TryGetComponent<Plant>(out var _) && component.IsWallPlant())
				{
					num2++;
				}
			}
			if (num2 >= 1)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_0_Cups()
		{
			if (!secondFloor.activeInHierarchy)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			foreach (GameObject cup in cups)
			{
				if (cup.activeInHierarchy)
				{
					num2++;
				}
			}
			string update = $"{10 - num2}/{10}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 0)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_1_FinishBoxWithFertilizers()
		{
			int num = 1;
			int num2 = 0;
			if (boxWithPots.boxIsFinished)
			{
				num2++;
			}
			if (boxWithFertilizers.boxIsFinished)
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

		private void Task_2_Cat()
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
				int num = 2;
				cat.OnCatInteracted -= TaskCat_Finished;
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_3_PlantInPhotoZone()
		{
			int num = 3;
			Collider[] array = Physics.OverlapBox(photoZone.bounds.center, photoZone.bounds.extents, Quaternion.identity, plantLayerMask);
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
			if (num2 >= 1)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_4_Hat()
		{
			int num = 4;
			if (hatStartPosition == Vector3.zero)
			{
				hatStartPosition = hat.transform.position;
			}
			if (Mathf.Abs(hat.transform.position.x - hatStartPosition.x) > 0.1f || Mathf.Abs(hat.transform.position.y - hatStartPosition.y) > 0.1f || Mathf.Abs(hat.transform.position.z - hatStartPosition.z) > 0.1f)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_5_PlantsInHall()
		{
			int num = 5;
			Collider[] array = Physics.OverlapBox(hallZone.bounds.center, hallZone.bounds.extents, Quaternion.identity, plantLayerMask);
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
			if (num2 >= 1)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_6_Pills()
		{
			int num = 6;
			int num2 = 0;
			foreach (GameObject tablet in tablets)
			{
				if (tablet.activeInHierarchy)
				{
					num2++;
				}
			}
			string update = $"{4 - num2}/{4}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 0)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_7_Seedling()
		{
			int num = 7;
			int num2 = Physics.OverlapBox(gardenZone.bounds.center, gardenZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "Seedling");
			string update = $"{num2}/{6}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 6)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_8_Chorons()
		{
			int num = 8;
			int num2 = Physics.OverlapBox(fireplaceZone.bounds.center, fireplaceZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "Choron");
			string update = $"{num2}/{3}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 3)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_9_BoxesOnTable()
		{
			int num = 9;
			int num2 = Physics.OverlapBox(kitchenShelfForBoxesZone.bounds.center, kitchenShelfForBoxesZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "BoxForKitchen");
			string update = $"{num2}/{8}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 8)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void OnDestroy()
		{
			taskService.ClearCurrentTask();
			if (cat != null)
			{
				cat.OnCatInteracted -= CatCountUpdate;
			}
			if (cat != null)
			{
				cat.OnCatInteracted -= TaskCat_Finished;
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
