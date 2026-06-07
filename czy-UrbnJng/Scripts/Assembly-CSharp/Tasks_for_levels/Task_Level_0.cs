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
	public class Task_Level_0 : MonoBehaviour, ITask, ISavedProgress, ISavedProgressReader
	{
		private delegate void TaskDelegate();

		private bool[] taskDone = new bool[11];

		private List<int> currentTasks = new List<int>();

		public LayerMask plantLayerMask;

		public LayerMask interactableLayerMask;

		[SerializeField]
		private MovableItem bear;

		[SerializeField]
		private Collider TVzone;

		[SerializeField]
		private Collider CabinetZone;

		[SerializeField]
		private Collider TerraceTableZone;

		[SerializeField]
		private InteractableCat cat;

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
		private BoxOnLevel box;

		[SerializeField]
		private Collider TVZone;

		private Vector3 bearStartPosition;

		private ITaskService taskService;

		private bool taskCat_Start;

		private TaskDelegate[] taskDelegates;

		public event Action TaskFinished;

		private void Awake()
		{
			taskService = AllServices.Container.Single<ITaskService>();
			bearStartPosition = bear.transform.position;
			taskDelegates = new TaskDelegate[0];
			taskService.SetCurrentTask(this);
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
			foreach (TaskUI item in tasksUI)
			{
				if (item == null)
				{
					return;
				}
				item.gameObject.SetActive(value: false);
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

		private void Task_0_FlowerSet()
		{
			int num = 0;
			if (Physics.OverlapBox(TerraceTableZone.bounds.center, TerraceTableZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider1) => collider1.name == "FlowerSet") == 3)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_1_SmallPlants()
		{
			int num = 1;
			int num2 = 0;
			foreach (Plant item in PlantsOnSceneCollection.Instance.collection)
			{
				if (item.plantSize == PlantSize.Small)
				{
					num2++;
				}
			}
			if (num2 >= 3)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_2_MiddlePlants()
		{
			int num = 2;
			int num2 = 0;
			foreach (Plant item in PlantsOnSceneCollection.Instance.collection)
			{
				if (item.plantSize == PlantSize.Small)
				{
					num2++;
				}
			}
			if (num2 >= 2)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_3_TVAntenna()
		{
			int num = 3;
			if (Physics.OverlapBox(TVZone.bounds.center, TVZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider1) => collider1.name == "Antenna") == 1)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_4_Radio()
		{
			int num = 4;
			if (Physics.OverlapBox(CabinetZone.bounds.center, CabinetZone.bounds.extents, Quaternion.identity, interactableLayerMask).Count((Collider collider1) => collider1.name == "Radio") == 1)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_0_OpenBox()
		{
			BoxOnLevel boxOnLevel = box;
			boxOnLevel.OnOpenedBox = (Action)Delegate.Combine(boxOnLevel.OnOpenedBox, new Action(TaskBoxOpen));
		}

		private void TaskBoxOpen()
		{
			int num = 0;
			TaskDone(num, tasksReward[num]);
			BoxOnLevel boxOnLevel = box;
			boxOnLevel.OnOpenedBox = (Action)Delegate.Remove(boxOnLevel.OnOpenedBox, new Action(TaskBoxOpen));
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

		private void Task_2_Humidify()
		{
			int num = 2;
			if (humidifyer.isWorking)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_3_Bear()
		{
			int num = 3;
			if (Mathf.Abs(bear.transform.position.x - bearStartPosition.x) > 0.1f || Mathf.Abs(bear.transform.position.y - bearStartPosition.y) > 0.1f || Mathf.Abs(bear.transform.position.z - bearStartPosition.z) > 0.1f)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_6_Skin()
		{
			CollectionManager instance = CollectionManager.Instance;
			instance.OnBuySkin = (Action<ObjectSO, string>)Delegate.Combine(instance.OnBuySkin, new Action<ObjectSO, string>(TaskSkin));
		}

		private void TaskSkin(ObjectSO obj, string GUID)
		{
			int num = 6;
			TaskDone(num, tasksReward[num]);
			CollectionManager instance = CollectionManager.Instance;
			instance.OnBuySkin = (Action<ObjectSO, string>)Delegate.Remove(instance.OnBuySkin, new Action<ObjectSO, string>(TaskSkin));
		}

		private void Task_7_Cactus()
		{
			int num = 7;
			Collider[] array = Physics.OverlapBox(TVzone.bounds.center, TVzone.bounds.extents, Quaternion.identity, plantLayerMask);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].transform.parent.transform.parent.TryGetComponent<Plant>(out var component) && component.GetObjectSO().objectName == PlantName.Cactus)
				{
					TaskDone(num, tasksReward[num]);
				}
			}
		}

		private void Task_8_FinishBox()
		{
			int num = 8;
			if (!box.isActiveAndEnabled)
			{
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_9_Cat()
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
				int num = 9;
				cat.OnCatInteracted -= TaskCat_Finished;
				TaskDone(num, tasksReward[num]);
			}
		}

		private void Task_10_Stars()
		{
			int num = 10;
			int num2 = 0;
			foreach (Plant item in PlantsOnSceneCollection.Instance.collection)
			{
				if (item.GetStars() == 2)
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
			if (cat != null)
			{
				cat.OnCatInteracted -= TaskCat_Finished;
			}
			CollectionManager instance = CollectionManager.Instance;
			instance.OnBuySkin = (Action<ObjectSO, string>)Delegate.Remove(instance.OnBuySkin, new Action<ObjectSO, string>(TaskSkin));
			BoxOnLevel boxOnLevel = box;
			boxOnLevel.OnOpenedBox = (Action)Delegate.Remove(boxOnLevel.OnOpenedBox, new Action(TaskBoxOpen));
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
