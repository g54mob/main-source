using PajamaLlama.SurvivalGuide;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogIndex : PageIndex
{
	[Header("Quest Log Index")]
	[SerializeField]
	private Image _questIcon;

	[SerializeField]
	private Image _trackedIcon;

	[Header("Animator Parameters")]
	[SerializeField]
	private string _trackedParameter = "QuestLog_Tracked";

	[SerializeField]
	private string _completedParameter = "QuestLog_Completed";

	public Quest Quest { get; private set; }

	protected override void OnEnable()
	{
		FocusManager.CurrentSelectedGameObjectChanged.AddListener(OnCurrentSelectedGameObjectChanged);
		base.OnEnable();
	}

	private void OnDisable()
	{
		FocusManager.CurrentSelectedGameObjectChanged.RemoveListener(OnCurrentSelectedGameObjectChanged);
		RemoveListeners();
	}

	internal override void Initialize(IPage page)
	{
		base.Initialize(page);
		if (page is Quest quest)
		{
			Quest = quest;
			if ((bool)_questIcon)
			{
				_questIcon.overrideSprite = quest.Properties.IndexIcon;
			}
			OnQuestUpdated();
			RemoveListeners();
			AddListeners();
			UpdateAnimatorState();
		}
	}

	protected override void UpdateAnimatorState()
	{
		if (!(base.Animator == null))
		{
			base.Animator.SetBool(_trackedParameter, Quest.Tracked);
			base.Animator.SetBool(_completedParameter, Quest.IsCompleted);
			base.UpdateAnimatorState();
		}
	}

	private void AddListeners()
	{
		GameEventDispatcher.AddListener(GameEventType.QuestStarted, OnQuestUpdated);
		GameEventDispatcher.AddListener(GameEventType.QuestUpdated, OnQuestUpdated);
		GameEventDispatcher.AddListener(GameEventType.QuestCompleted, OnQuestUpdated);
		GameEventDispatcher.AddListener(GameEventType.QuestFailed, OnQuestUpdated);
		GameEventDispatcher.AddListener(GameEventType.QuestAbandoned, OnQuestUpdated);
		GameEventDispatcher.AddListener(GameEventType.QuestTracked, OnQuestUpdated);
	}

	private void RemoveListeners()
	{
		GameEventDispatcher.RemoveListener(GameEventType.QuestStarted, OnQuestUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.QuestUpdated, OnQuestUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.QuestCompleted, OnQuestUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.QuestFailed, OnQuestUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.QuestAbandoned, OnQuestUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.QuestTracked, OnQuestUpdated);
	}

	private void OnQuestUpdated(GameEvent gameEvent = null)
	{
		UpdateAnimatorState();
		if ((bool)_trackedIcon)
		{
			_trackedIcon.gameObject.SetActive(Quest != null && StoryManager.IsActiveQuest(Quest));
		}
	}

	private void OnCurrentSelectedGameObjectChanged(GameObject gameObject)
	{
		if (base.Selectable.gameObject == gameObject)
		{
			Select();
		}
	}
}
