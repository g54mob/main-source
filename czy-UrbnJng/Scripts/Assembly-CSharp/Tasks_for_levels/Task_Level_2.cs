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
	public class Task_Level_2 : MonoBehaviour, ITask, ISavedProgress, ISavedProgressReader
	{
		private delegate void TaskDelegate();

		private bool[] taskDone = new bool[8];

		private List<int> currentTasks = new List<int>();

		private ITaskService taskService;

		[SerializeField]
		private List<TaskUI> tasksUI;

		[SerializeField]
		private List<int> tasksReward;

		[SerializeField]
		private BoxOnLevel box;

		[SerializeField]
		private BoxOnLevel noodleBox;

		[SerializeField]
		private Humidifyer humidifyer1;

		[SerializeField]
		private Humidifyer humidifyer2;

		private TaskDelegate[] taskDelegates;

		[SerializeField]
		private Collider bedZone;

		public LayerMask plantLayerMask;

		[SerializeField]
		private Collider computerZone;

		public LayerMask interactableLayerMask;

		[SerializeField]
		private Collider shoeZone;

		[SerializeField]
		private Collider windowsillZone;

		[SerializeField]
		private Collider closetZone;

		[SerializeField]
		private Collider tableZone;

		private const int LevelNumber = 2;

		private PlayerProgress progress;

		public event Action TaskFinished;

		private void Awake()
		{
			taskService = AllServices.Container.Single<ITaskService>();
			taskDelegates = new TaskDelegate[8] { Task_0_Humidify, Task_1_FinishBoxOnSecondFloor, Task_2_PharitasStuff, Task_3_PlantsOnWindowsill, Task_4_Cactus, Task_5_FinishBoxOnFirstFloor, Task_6_Stars, Task_7_PlantsOnCloset };
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
				if (!progress.ACH_TaskDoneList.Contains(2))
				{
					progress.ACH_TaskDoneList.Add(2);
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

		private void Task_1_FinishBoxOnSecondFloor()
		{
			int num = 1;
			if (box.boxIsFinished)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_2_PharitasStuff()
		{
			int num = 2;
			if (tableZone.gameObject.activeInHierarchy)
			{
				int num2 = Physics.OverlapBox(tableZone.bounds.center, tableZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider1) => collider1.name == "PharitasStuff");
				string update = $"{5 - num2}/{5}";
				tasksUI[num].UpdateTaskCount(update);
				if (num2 == 0)
				{
					TaskDone(num, tasksReward[num]);
				}
			}
		}

		private void Task_3_PlantsOnWindowsill()
		{
			int num = 3;
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
			string update = $"{num2}/{2}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 2)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_4_Cactus()
		{
			int num = 4;
			Collider[] array = Physics.OverlapBox(computerZone.bounds.center, computerZone.bounds.extents, Quaternion.identity, plantLayerMask);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].transform.parent.transform.parent.TryGetComponent<Plant>(out var component) && component.GetObjectSO().objectName == PlantName.Cactus)
				{
					TaskDone(num, tasksReward[num]);
				}
			}
		}

		private void Task_5_FinishBoxOnFirstFloor()
		{
			int num = 5;
			if (noodleBox.boxIsFinished)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_6_Stars()
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
			string update = $"{num2}/{4}";
			tasksUI[num].UpdateTaskCount(update);
			if (num2 >= 4)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_7_PlantsOnCloset()
		{
			int num = 7;
			Collider[] array = Physics.OverlapBox(closetZone.bounds.center, closetZone.bounds.extents, Quaternion.identity, plantLayerMask);
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

		private void Task_0_Box()
		{
			int num = 0;
			if (Physics.OverlapBox(bedZone.bounds.center, bedZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count(delegate(Collider collider)
			{
				string text = collider.name;
				return text == "Box2" || text == "Box3" || text == "Box4";
			}) == 3)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_6_Skin()
		{
			CollectionManager instance = CollectionManager.Instance;
			instance.OnBuySkin = (Action<ObjectSO, string>)Delegate.Combine(instance.OnBuySkin, new Action<ObjectSO, string>(TaskSkin));
		}

		private void Task_2_Shoes()
		{
			int num = 2;
			if (Physics.OverlapBox(shoeZone.bounds.center, shoeZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count(delegate(Collider collider)
			{
				string text = collider.name;
				return text == "Slippers" || text == "Slippers1" || text == "Sneakers";
			}) == 3)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void TaskSkin(ObjectSO obj, string GUID)
		{
			int num = 6;
			if (obj.objectName == PlantName.Monstera && obj.variantsList[1].GUID == GUID)
			{
				TaskDone(num, tasksReward[num]);
				CollectionManager instance = CollectionManager.Instance;
				instance.OnBuySkin = (Action<ObjectSO, string>)Delegate.Remove(instance.OnBuySkin, new Action<ObjectSO, string>(TaskSkin));
			}
		}

		private void Task_7_Noodles()
		{
			int num = 7;
			if (!noodleBox.isActiveAndEnabled)
			{
				TaskDone(num, tasksReward[num]);
			}
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

		private void OnDestroy()
		{
			taskService.ClearCurrentTask();
			taskDelegates = null;
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
