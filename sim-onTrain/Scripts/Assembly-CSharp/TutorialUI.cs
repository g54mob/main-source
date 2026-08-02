using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TutorialUI : UIPanelBase
{
	public RectTransform tutorialPanel;

	public TextMeshProUGUI titleText;

	public Transform taskContainer;

	public GameObject taskPrefab;

	[Space(10f)]
	public float slideDistance = 300f;

	public float slideSpeed = 0.5f;

	public Ease slideEase = Ease.OutQuart;

	public float fadeDuration = 0.4f;

	[Space(10f)]
	public float taskSlideDistance = 200f;

	public float taskFadeDuration = 0.3f;

	public float newTaskDelay = 0.1f;

	public float containerSlideUpDistance = 50f;

	private Dictionary<TutorialTask, TutorialTaskUI> taskUIs = new Dictionary<TutorialTask, TutorialTaskUI>();

	private RectTransform taskContainerRect;

	public CanvasGroup panelCanvasGroup;

	private Vector2 originalPosition;

	public bool isShown;

	private bool isLocked;

	private List<TutorialTask> pendingCompletedTasks = new List<TutorialTask>();

	private List<(TutorialTask task, int progress)> pendingProgressUpdates = new List<(TutorialTask, int)>();

	private void Start()
	{
		taskContainerRect = taskContainer.GetComponent<RectTransform>();
		originalPosition = tutorialPanel.localPosition;
	}

	public override void ShowPanel()
	{
		base.ShowPanel();
		isShown = true;
		StartCoroutine(DelayedProcessPendingTasks());
	}

	private IEnumerator DelayedProcessPendingTasks()
	{
		yield return new WaitForSeconds(1f);
		ProcessPendingTasks();
	}

	public void SetTitle(string title)
	{
		titleText.text = title;
	}

	public override void HidePanel()
	{
		panelCanvasGroup.DOKill();
		base.HidePanel();
	}

	public void ShowTutorial()
	{
		if (!isShown)
		{
			isShown = true;
			panelCanvasGroup.DOKill();
			tutorialPanel.DOKill();
			panelCanvasGroup.DOFade(1f, fadeDuration).SetDelay(1f).OnComplete(delegate
			{
				ProcessPendingTasks();
			});
		}
		else
		{
			ProcessPendingTasks();
		}
	}

	public void ShowPanelWithFade()
	{
		isShown = true;
		panelCanvasGroup.DOKill();
		tutorialPanel.DOKill();
		panelCanvasGroup.DOFade(1f, fadeDuration).SetDelay(1f).OnComplete(delegate
		{
			ProcessPendingTasks();
		});
	}

	public void HideTutorial()
	{
		if (isShown)
		{
			isShown = false;
			panelCanvasGroup.DOKill();
			tutorialPanel.DOKill();
			DOTween.Sequence().Append(tutorialPanel.DOLocalMoveX(originalPosition.x - slideDistance, slideSpeed).SetEase(slideEase)).Join(panelCanvasGroup.DOFade(0f, fadeDuration))
				.OnComplete(delegate
				{
					ClearAllTasks();
					tutorialPanel.localPosition = originalPosition;
				});
		}
	}

	public void ShowAllGroupTasks(List<TutorialTask> groupTasks)
	{
		ClearAllTasks();
		Vector2 anchoredPosition = taskContainerRect.anchoredPosition;
		taskContainerRect.anchoredPosition = new Vector2(anchoredPosition.x, anchoredPosition.y - containerSlideUpDistance * (float)groupTasks.Count);
		foreach (TutorialTask groupTask in groupTasks)
		{
			TutorialTaskUI component = Object.Instantiate(taskPrefab, taskContainer).GetComponent<TutorialTaskUI>();
			if (component != null)
			{
				component.Setup(groupTask);
				taskUIs[groupTask] = component;
			}
		}
		StartCoroutine(AnimateAllTasksIn(anchoredPosition));
	}

	private IEnumerator AnimateAllTasksIn(Vector2 targetPos)
	{
		yield return new WaitForEndOfFrame();
		taskContainerRect.DOKill();
		taskContainerRect.DOAnchorPos(targetPos, 0.6f).SetEase(Ease.OutQuart);
	}

	public void CompleteTask(TutorialTask task)
	{
		if (!IsUIVisible())
		{
			if (!pendingCompletedTasks.Contains(task))
			{
				pendingCompletedTasks.Add(task);
				Debug.Log("Task completion queued (UI hidden): " + task.taskText);
			}
		}
		else if (taskUIs.ContainsKey(task))
		{
			TutorialTaskUI taskUI = taskUIs[task];
			StartCoroutine(DelayedTaskComplete(taskUI, task));
		}
	}

	private IEnumerator DelayedTaskComplete(TutorialTaskUI taskUI, TutorialTask task)
	{
		yield return new WaitForSeconds(1f);
		taskUI.SlideOutAndFade(taskSlideDistance, taskFadeDuration, delegate
		{
			taskUIs.Remove(task);
			Object.Destroy(taskUI.gameObject);
		});
	}

	public void UpdateTaskProgress(TutorialTask task)
	{
		if (!IsUIVisible())
		{
			int num = pendingProgressUpdates.FindIndex(((TutorialTask task, int progress) p) => p.task == task);
			if (num >= 0)
			{
				pendingProgressUpdates[num] = (task, task.currentProgress);
			}
			else
			{
				pendingProgressUpdates.Add((task, task.currentProgress));
			}
		}
		else if (taskUIs.ContainsKey(task))
		{
			taskUIs[task].UpdateProgress();
		}
	}

	private bool IsUIVisible()
	{
		if (isShown && panelCanvasGroup != null)
		{
			return panelCanvasGroup.alpha > 0.5f;
		}
		return false;
	}

	private void ProcessPendingTasks()
	{
		if (pendingProgressUpdates.Count > 0)
		{
			Debug.Log($"Processing {pendingProgressUpdates.Count} pending progress updates");
			foreach (var (tutorialTask, currentProgress) in pendingProgressUpdates)
			{
				if (taskUIs.ContainsKey(tutorialTask))
				{
					tutorialTask.currentProgress = currentProgress;
					taskUIs[tutorialTask].UpdateProgress();
				}
			}
			pendingProgressUpdates.Clear();
		}
		if (pendingCompletedTasks.Count > 0)
		{
			Debug.Log($"Processing {pendingCompletedTasks.Count} pending completed tasks");
			StartCoroutine(ProcessPendingCompletedTasks());
		}
	}

	private IEnumerator ProcessPendingCompletedTasks()
	{
		yield return new WaitForSeconds(1f);
		List<TutorialTask> list = new List<TutorialTask>(pendingCompletedTasks);
		pendingCompletedTasks.Clear();
		foreach (TutorialTask task in list)
		{
			if (taskUIs.ContainsKey(task))
			{
				TutorialTaskUI taskUI = taskUIs[task];
				taskUI.SlideOutAndFade(taskSlideDistance, taskFadeDuration, delegate
				{
					taskUIs.Remove(task);
					Object.Destroy(taskUI.gameObject);
				});
				yield return new WaitForSeconds(0.3f);
			}
		}
	}

	public void RefreshTaskTexts()
	{
		foreach (KeyValuePair<TutorialTask, TutorialTaskUI> taskUI in taskUIs)
		{
			if (taskUI.Value != null)
			{
				taskUI.Value.RefreshText();
			}
		}
	}

	private void ClearAllTasks()
	{
		foreach (TutorialTaskUI value in taskUIs.Values)
		{
			if (value != null)
			{
				Object.Destroy(value.gameObject);
			}
		}
		taskUIs.Clear();
	}
}
