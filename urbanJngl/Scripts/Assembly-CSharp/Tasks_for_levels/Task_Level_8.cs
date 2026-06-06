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
	public class Task_Level_8 : MonoBehaviour, ITask, ISavedProgress, ISavedProgressReader
	{
		private delegate void TaskDelegate();

		private bool[] taskDone = new bool[10];

		private List<int> currentTasks = new List<int>();

		public LayerMask interactableLayerMask;

		public LayerMask plantLayerMask;

		[SerializeField]
		private AnimalAIClick cat;

		[SerializeField]
		private AnimalAIClick dog;

		[SerializeField]
		private Collider tableZone;

		[SerializeField]
		private Collider shelfZone;

		[SerializeField]
		private Collider cristmasTreeZone;

		[SerializeField]
		private Collider kitchenCabinetZone;

		[SerializeField]
		private Collider commodeZone;

		[SerializeField]
		private Collider garageZone;

		[SerializeField]
		private Collider heliRoomZone;

		[SerializeField]
		private Collider computerZone;

		[SerializeField]
		private List<Lamp> candles;

		[SerializeField]
		private List<GameObject> castleItems;

		[SerializeField]
		private List<int> tasksReward;

		[SerializeField]
		private List<TaskUI> tasksUI;

		private Vector3 bearStartPosition;

		private ITaskService taskService;

		private bool taskCat_Start;

		private bool taskDog_Start;

		private Vector3 ballStartPosition;

		private Vector3 dogToyStartPosition;

		private Vector3 greenDogToyStartPosition;

		private const int LevelNumber = 8;

		private PlayerProgress progress;

		private TaskDelegate[] taskDelegates;

		public event Action TaskFinished;

		private void Awake()
		{
			taskService = AllServices.Container.Single<ITaskService>();
			taskDelegates = new TaskDelegate[10] { Task_0_Cat, Task_1_Dog, Task_2_GiftBox, Task_3_Castle, Task_4_HolidayFood, Task_5_Sleigh, Task_6_Cactus, Task_7_PlantInHeliRoom, Task_8_Pots, Task_9_FootballBall };
			taskService.SetCurrentTask(this);
			if (cat != null)
			{
				cat.OnCatInteracted += CatCountUpdate;
			}
			if (dog != null)
			{
				dog.OnDogInteracted += DogCountUpdate;
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
				if (!progress.ACH_TaskDoneList.Contains(8))
				{
					progress.ACH_TaskDoneList.Add(8);
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

		private void Task_0_Cat()
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
				int num = 0;
				cat.OnCatInteracted -= TaskCat_Finished;
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_1_Dog()
		{
			if (!taskDog_Start && !(dog == null))
			{
				dog.OnDogInteracted += TaskDog_Finished;
				taskDog_Start = true;
			}
		}

		private void TaskDog_Finished(object sender, EventArgs e)
		{
			if (taskDog_Start)
			{
				int num = 1;
				dog.OnCatInteracted -= TaskDog_Finished;
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_2_GiftBox()
		{
			int num = 2;
			int num2 = Physics.OverlapBox(cristmasTreeZone.bounds.center, cristmasTreeZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "GiftBox");
			string update = $"{num2}/{4}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 4)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_3_Castle()
		{
			int num = 3;
			int num2 = 0;
			foreach (GameObject castleItem in castleItems)
			{
				if (castleItem.activeInHierarchy)
				{
					num2++;
				}
			}
			string update = $"{20 - num2}/{20}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 0)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_4_HolidayFood()
		{
			int num = 4;
			int num2 = Physics.OverlapBox(tableZone.bounds.center, tableZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "HolidayFood");
			string update = $"{num2}/{7}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 7)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_5_Sleigh()
		{
			int num = 5;
			if (Physics.OverlapBox(garageZone.bounds.center, garageZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "Sleigh") == 1)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_6_Cactus()
		{
			int num = 6;
			Collider[] array = Physics.OverlapBox(computerZone.bounds.center, computerZone.bounds.extents, Quaternion.identity, plantLayerMask);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].transform.parent.transform.parent.TryGetComponent<Plant>(out var component) && component.GetObjectSO().objectName == PlantName.Cactus)
				{
					TaskDone(num, tasksReward[num]);
				}
			}
		}

		private void Task_7_PlantInHeliRoom()
		{
			int num = 7;
			Collider[] array = Physics.OverlapBox(heliRoomZone.bounds.center, heliRoomZone.bounds.extents, Quaternion.identity, plantLayerMask);
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

		private void Task_8_Candles()
		{
			int num = 8;
			int num2 = 0;
			foreach (Lamp candle in candles)
			{
				if (candle.isWorking)
				{
					num2++;
				}
			}
			string update = $"{num2}/{1}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 1)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_8_Pots()
		{
			int num = 8;
			int num2 = Physics.OverlapBox(shelfZone.bounds.center, shelfZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "QuestPot");
			string update = $"{num2}/{7}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 7)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_9_FootballBall()
		{
			int num = 9;
			if (Physics.OverlapBox(heliRoomZone.bounds.center, heliRoomZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "FootballBall") == 1)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_8_SmallPlantOnKitchenCabinet()
		{
			int num = 8;
			Collider[] array = Physics.OverlapBox(kitchenCabinetZone.bounds.center, kitchenCabinetZone.bounds.extents, Quaternion.identity, plantLayerMask);
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
			if (num2 >= 2)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_9_Commode()
		{
			int num = 9;
			if (Physics.OverlapBox(commodeZone.bounds.center, commodeZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "FlowerBox") == 2)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void OnDestroy()
		{
			if (cat != null)
			{
				cat.OnCatInteracted -= TaskCat_Finished;
			}
			if (dog != null)
			{
				dog.OnDogInteracted -= TaskCat_Finished;
			}
			if (cat != null)
			{
				cat.OnCatInteracted -= CatCountUpdate;
			}
			if (dog != null)
			{
				dog.OnDogInteracted -= DogCountUpdate;
			}
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

		private void CatCountUpdate(object sender, EventArgs e)
		{
			AllServices.Container.Single<IPersistentProgressService>().Progress.ACH_Cat++;
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.ACH_Cat >= 20)
			{
				SteamIntegration.Instance.UnlockAchievement("CAT_22", 22);
			}
		}

		private void DogCountUpdate(object sender, EventArgs e)
		{
			AllServices.Container.Single<IPersistentProgressService>().Progress.ACH_Dog++;
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.ACH_Dog >= 20)
			{
				SteamIntegration.Instance.UnlockAchievement("DOG_23", 23);
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
