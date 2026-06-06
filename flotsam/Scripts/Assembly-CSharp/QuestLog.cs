using System.Collections.Generic;
using PajamaLlama.SurvivalGuide;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class QuestLog : Panel, ISelectableGroupFirstSelectedProvider
{
	[SerializeField]
	private QuestCategory[] _categories;

	[SerializeField]
	private ChildBehaviourCache<CategoryPageIndex> _categoryPrefab;

	[SerializeField]
	private QuestLogPage _questLogPage;

	[SerializeField]
	private SelectableGroup _selectableGroup;

	[SerializeField]
	private Accordion _accordion;

	private QuestLogIndex _selectedIndex;

	private List<QuestType> _loggedQuestTypes = new List<QuestType>();

	private Transform _transform;

	private void LateUpdate()
	{
		if ((bool)_transform)
		{
			_accordion.ToggleParent(_transform, instantTransition: true);
			_transform = null;
		}
	}

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (!base.Open(id, context))
		{
			return false;
		}
		_selectableGroup.Initialize(clearSelected: true);
		_accordion.SelectableGroup.RemoveChildren();
		_accordion.Initialize();
		if (TryGetSelectedQuestIndex(out var selectedIndex))
		{
			SetSelectedIndex(selectedIndex);
			_transform = selectedIndex.transform;
		}
		GameEventDispatcher.AddListener(GameEventType.OpenQuestLogPage, OnOpenQuestLogPage);
		return true;
	}

	protected override void OnOpen(IPanelContext context)
	{
		_categoryPrefab.Reset();
		if (StoryManager.TryGetLogQuests(out var logQuests, GetLoggedQuestTypes()))
		{
			QuestCategory[] categories = _categories;
			foreach (QuestCategory questCategory in categories)
			{
				questCategory.Populate(logQuests);
				if (0 < questCategory.SubPages.Count)
				{
					_categoryPrefab.Get(active: true).Initialize(questCategory);
				}
			}
		}
		_categoryPrefab.Trim();
	}

	public override void Close()
	{
		GameEventDispatcher.RemoveListener(GameEventType.OpenQuestLogPage, OnOpenQuestLogPage);
		base.Close();
	}

	public bool TryGetFirstSelected(out Selectable selectable)
	{
		if (TryGetSelectedQuestIndex(out var selectedIndex))
		{
			selectable = selectedIndex.Selectable;
			return true;
		}
		selectable = null;
		return false;
	}

	private bool TryGetSelectedQuestIndex(out QuestLogIndex selectedIndex)
	{
		if ((bool)_selectedIndex)
		{
			selectedIndex = _selectedIndex;
			return true;
		}
		if (StoryManager.TryGetQuestLogQuest(out var quest))
		{
			for (int i = 0; i < _categoryPrefab.Count; i++)
			{
				if (_categoryPrefab[i].TryGetPageIndex<QuestLogIndex>(out selectedIndex, quest))
				{
					return true;
				}
			}
		}
		selectedIndex = null;
		return false;
	}

	private void OnOpenQuestLogPage(GameEvent gameEvent)
	{
		if (gameEvent is PageEvent { Index: QuestLogIndex index })
		{
			SetSelectedIndex(index);
		}
	}

	private void SetSelectedIndex(QuestLogIndex index)
	{
		if (!(index == null))
		{
			if ((bool)_selectedIndex)
			{
				_selectedIndex.SetActivePageIndex(active: false);
			}
			_questLogPage.Initialize(index.Quest);
			_selectedIndex = index;
			_selectedIndex.SetActivePageIndex(active: true);
		}
	}

	public override bool CanBeOpened(PanelID panelID, IPanelContext context = null)
	{
		List<Quest> logQuests;
		if (base.CanBeOpened(panelID, context))
		{
			return StoryManager.TryGetLogQuests(out logQuests, GetLoggedQuestTypes());
		}
		return false;
	}

	private List<QuestType> GetLoggedQuestTypes()
	{
		_loggedQuestTypes.Clear();
		QuestCategory[] categories = _categories;
		for (int i = 0; i < categories.Length; i++)
		{
			categories[i].PopulateQuestType(_loggedQuestTypes);
		}
		return _loggedQuestTypes;
	}
}
