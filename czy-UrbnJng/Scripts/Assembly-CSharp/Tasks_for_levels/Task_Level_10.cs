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
	public class Task_Level_10 : MonoBehaviour, ITask, ISavedProgress, ISavedProgressReader
	{
		private delegate void TaskDelegate();

		private bool[] taskDone = new bool[13];

		private List<int> currentTasks = new List<int>();

		public LayerMask interactableLayerMask;

		public LayerMask plantLayerMask;

		[SerializeField]
		private Collider breakfastZone;

		[SerializeField]
		private Collider trayZone;

		[SerializeField]
		private Collider shelfZoneForTask;

		[SerializeField]
		private Collider seedlingsZone;

		[SerializeField]
		private Collider hallZone;

		[SerializeField]
		private MovableItem gift;

		private Vector3 giftStartPosition;

		[SerializeField]
		private AnimalAIClick cat;

		[SerializeField]
		private AnimalAIClick dog;

		[SerializeField]
		private Collider helenRoomZone;

		[SerializeField]
		private Collider gameRoomZone;

		[SerializeField]
		private List<int> tasksReward;

		[SerializeField]
		private List<TaskUI> tasksUI;

		[SerializeField]
		private BoxOnLevel boxWithPots;

		[SerializeField]
		private BoxOnLevel boxWithSoil;

		[SerializeField]
		private BoxOnLevel boxWithFertilizers;

		[SerializeField]
		private BoxOnLevel boxWithMomsFood;

		[SerializeField]
		private List<GameObject> boardgameElements;

		private ITaskService taskService;

		private bool taskCat_Start;

		private bool taskDog_Start;

		private const int LevelNumber = 10;

		private PlayerProgress progress;

		private TaskDelegate[] taskDelegates;

		public event Action TaskFinished;

		private void Awake()
		{
			taskService = AllServices.Container.Single<ITaskService>();
			taskDelegates = new TaskDelegate[13]
			{
				Task_0_Boardgame, Task_1_FinishBoxWithFood, Task_2_FestiveTable, Task_3_Cat, Task_4_FinishBoxesInGreenhouse, Task_5_ClayPots, Task_6_Seedling, Task_7_PlantInHelenRoom, Task_8_Dog, Task_9_PlantInGameRoom,
				Task_10_BoxesWithGame, Task_11_Project, Task_12_Gift
			};
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
				if (!progress.ACH_TaskDoneList.Contains(10))
				{
					progress.ACH_TaskDoneList.Add(10);
				}
				if (progress.ACH_TaskDoneList.Count >= 9)
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

		private void Task_0_Boardgame()
		{
			int num = 0;
			int num2 = 0;
			foreach (GameObject boardgameElement in boardgameElements)
			{
				if (boardgameElement.activeInHierarchy)
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

		private void Task_1_FinishBoxWithFood()
		{
			int num = 1;
			if (boxWithMomsFood.boxIsFinished)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_2_FestiveTable()
		{
			int num = 2;
			int num2 = Physics.OverlapBox(breakfastZone.bounds.center, breakfastZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "HolidayFood");
			string update = $"{num2}/{9}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 9)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_3_Cat()
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
				int num = 3;
				cat.OnCatInteracted -= TaskCat_Finished;
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_4_FinishBoxesInGreenhouse()
		{
			int num = 4;
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

		private void Task_5_ClayPots()
		{
			int num = 5;
			int num2 = Physics.OverlapBox(trayZone.bounds.center, trayZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "ClayPot");
			string update = $"{num2}/{5}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 5)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_6_Seedling()
		{
			int num = 6;
			int num2 = Physics.OverlapBox(seedlingsZone.bounds.center, seedlingsZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "Seedling");
			string update = $"{num2}/{10}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 10)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_7_PlantInHelenRoom()
		{
			int num = 7;
			Collider[] array = Physics.OverlapBox(helenRoomZone.bounds.center, helenRoomZone.bounds.extents, Quaternion.identity, plantLayerMask);
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

		private void Task_8_Dog()
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
				int num = 8;
				dog.OnCatInteracted -= TaskDog_Finished;
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_9_PlantInGameRoom()
		{
			int num = 9;
			Collider[] array = Physics.OverlapBox(gameRoomZone.bounds.center, gameRoomZone.bounds.extents, Quaternion.identity, plantLayerMask);
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

		private void Task_10_BoxesWithGame()
		{
			int num = 10;
			int num2 = Physics.OverlapBox(shelfZoneForTask.bounds.center, shelfZoneForTask.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "BoxWithGame");
			string update = $"{num2}/{6}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 6)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_11_Project()
		{
			int num = 11;
			if (Physics.OverlapBox(hallZone.bounds.center, hallZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider) => collider.name == "projector") == 1)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_12_Gift()
		{
			int num = 12;
			if (giftStartPosition == Vector3.zero)
			{
				giftStartPosition = gift.transform.position;
			}
			if (Mathf.Abs(gift.transform.position.x - giftStartPosition.x) > 0.1f || Mathf.Abs(gift.transform.position.y - giftStartPosition.y) > 0.1f || Mathf.Abs(gift.transform.position.z - giftStartPosition.z) > 0.1f)
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
