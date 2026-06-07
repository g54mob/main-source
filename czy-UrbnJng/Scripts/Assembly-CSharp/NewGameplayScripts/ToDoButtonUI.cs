using Infrastructure.Services;
using Tasks_for_levels;
using UnityEngine;
using UnityEngine.UI;

namespace NewGameplayScripts
{
	public class ToDoButtonUI : MonoBehaviour
	{
		[SerializeField]
		private GameObject toDOList;

		[SerializeField]
		private GameObject notifier;

		[SerializeField]
		private Button toDoButton;

		private bool toDoListActive = true;

		private ITask currentTask;

		private void Start()
		{
			toDoButton.onClick.AddListener(SwitchList);
			currentTask = AllServices.Container.Single<ITaskService>().GetCurrentTask();
			if (currentTask != null)
			{
				currentTask.TaskFinished += TunOnNotifier;
			}
		}

		private void OnDestroy()
		{
			toDoButton.onClick.RemoveAllListeners();
			if (currentTask != null)
			{
				currentTask.TaskFinished -= TunOnNotifier;
			}
		}

		private void TunOnNotifier()
		{
			if (!toDoListActive)
			{
				SwitchList();
			}
		}

		private void SwitchList()
		{
			toDoListActive = !toDoListActive;
			toDOList.SetActive(toDoListActive);
			if (toDoListActive)
			{
				notifier.SetActive(value: false);
			}
		}
	}
}
