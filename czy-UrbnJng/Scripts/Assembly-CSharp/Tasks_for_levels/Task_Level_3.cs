using System;
using System.Collections.Generic;
using System.Linq;
using Data.Enums;
using Infrastructure.Services;
using Infrastructure.Services.BoxService;
using Infrastructure.Services.CoinService;
using Infrastructure.Services.PersistentProgress;
using MalbersAnimations;
using NewGameplayScripts;
using UnityEngine;

namespace Tasks_for_levels
{
	public class Task_Level_3 : MonoBehaviour, ITask, ISavedProgress, ISavedProgressReader
	{
		private delegate void TaskDelegate();

		private bool[] taskDone = new bool[10];

		private List<int> currentTasks = new List<int>();

		public LayerMask interactableLayerMask;

		public LayerMask plantLayerMask;

		[SerializeField]
		private AnimalAIClick cat;

		[SerializeField]
		private Collider shoeZone;

		[SerializeField]
		private Collider balconyZone;

		[SerializeField]
		private Collider windowsillZone;

		[SerializeField]
		private Collider sinkZone;

		[SerializeField]
		private MovableItem mouse;

		[SerializeField]
		private List<int> tasksReward;

		[SerializeField]
		private List<TaskUI> tasksUI;

		[SerializeField]
		private BoxOnLevel box_1;

		[SerializeField]
		private BoxOnLevel box_2;

		[SerializeField]
		private Humidifyer humidifyer1;

		[SerializeField]
		private List<GameObject> trashPlants;

		[SerializeField]
		private List<GameObject> trashBoxes;

		private Vector3 mouseStartPosition;

		private ITaskService taskService;

		private bool taskCat_Start;

		private const int LevelNumber = 3;

		private PlayerProgress progress;

		private TaskDelegate[] taskDelegates;

		public event Action TaskFinished;

		private void Awake()
		{
			taskService = AllServices.Container.Single<ITaskService>();
			taskDelegates = new TaskDelegate[10] { Task_0_Humidify, Task_1_TrashBoxes, Task_2_Cat, Task_3_FinishBox, Task_4_TrashPlants, Task_5_SmallPlantsOnWindowsill, Task_6_Shoes, Task_7_PlantsOnBalcony, Task_8_PlantsStars, Task_9_Mouse };
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
				if (!progress.ACH_TaskDoneList.Contains(3))
				{
					progress.ACH_TaskDoneList.Add(3);
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

		private void Task_0_Humidify()
		{
			int num = 0;
			if (humidifyer1.isWorking)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_1_TrashBoxes()
		{
			int num = 1;
			int num2 = 0;
			foreach (GameObject trashBox in trashBoxes)
			{
				if (trashBox.activeInHierarchy)
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

		private void Task_3_FinishBox()
		{
			int num = 3;
			int num2 = 0;
			if (box_1.boxIsFinished)
			{
				num2++;
			}
			if (box_2.boxIsFinished)
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

		private void Task_4_TrashPlants()
		{
			int num = 4;
			int num2 = 0;
			foreach (GameObject trashPlant in trashPlants)
			{
				if (trashPlant.activeInHierarchy)
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

		private void Task_5_SmallPlantsOnWindowsill()
		{
			int num = 5;
			Collider[] array = Physics.OverlapBox(windowsillZone.bounds.center, windowsillZone.bounds.extents, Quaternion.identity, plantLayerMask);
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

		private void Task_6_Shoes()
		{
			int num = 6;
			int num2 = Physics.OverlapBox(shoeZone.bounds.center, shoeZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count(delegate(Collider collider)
			{
				string text = collider.name;
				return text == "Slippers" || text == "Shoes";
			});
			string update = $"{num2}/{2}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 == 2)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_7_PlantsOnBalcony()
		{
			int num = 7;
			Collider[] array = Physics.OverlapBox(balconyZone.bounds.center, balconyZone.bounds.extents, Quaternion.identity, plantLayerMask);
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
			string update = $"{num2}/{4}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 4)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_8_PlantsStars()
		{
			int num = 8;
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

		private void Task_9_Mouse()
		{
			int num = 9;
			if (mouseStartPosition == Vector3.zero)
			{
				mouseStartPosition = mouse.transform.position;
			}
			if (Mathf.Abs(mouse.transform.position.x - mouseStartPosition.x) > 0.1f || Mathf.Abs(mouse.transform.position.y - mouseStartPosition.y) > 0.1f || Mathf.Abs(mouse.transform.position.z - mouseStartPosition.z) > 0.1f)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_4_Dishes()
		{
			int num = 4;
			if (Physics.OverlapBox(sinkZone.bounds.center, sinkZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count(delegate(Collider collider)
			{
				string text = collider.name;
				return text == "Cup" || text == "Plate" || text == "Bowl";
			}) == 3)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_6_BigSkin()
		{
			CollectionManager instance = CollectionManager.Instance;
			instance.OnBuySkin = (Action<ObjectSO, string>)Delegate.Combine(instance.OnBuySkin, new Action<ObjectSO, string>(TaskBigSkin));
		}

		private void TaskBigSkin(ObjectSO obj, string GUID)
		{
			int num = 6;
			if (obj.size == new Vector2(4f, 4f))
			{
				TaskDone(num, tasksReward[num]);
				CollectionManager instance = CollectionManager.Instance;
				instance.OnBuySkin = (Action<ObjectSO, string>)Delegate.Remove(instance.OnBuySkin, new Action<ObjectSO, string>(TaskBigSkin));
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
			if (num2 >= 1)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_10_MiddlePlantsStars()
		{
			int num = 10;
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
			instance.OnBuySkin = (Action<ObjectSO, string>)Delegate.Remove(instance.OnBuySkin, new Action<ObjectSO, string>(TaskBigSkin));
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
