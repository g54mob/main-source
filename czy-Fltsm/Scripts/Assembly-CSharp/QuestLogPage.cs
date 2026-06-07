using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogPage : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _titleField;

	[SerializeField]
	private Toggle _toggle;

	[SerializeField]
	private TextMeshProUGUI _descriptionField;

	[SerializeField]
	private Image _icon;

	[SerializeField]
	private GameObject _objectivesSection;

	[SerializeField]
	private ChildBehaviourCache<QuestLogObjective> _objectivePrefab;

	private Quest _quest;

	private void OnEnable()
	{
		_toggle.onValueChanged.AddListener(OnToggleValueChanged);
	}

	private void OnDisable()
	{
		_toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
	}

	public void Initialize(Quest quest)
	{
		_quest = quest;
		_titleField.text = quest.Properties.QuestTitle;
		if ((bool)_icon)
		{
			_icon.overrideSprite = quest.Properties.PageIcon;
		}
		if ((bool)_descriptionField)
		{
			_descriptionField.text = quest.Properties.QuestDescription;
		}
		if (quest.IsCompleted)
		{
			_toggle.gameObject.SetActive(value: false);
		}
		else
		{
			_toggle.gameObject.SetActive(value: true);
			_toggle.SetIsOnWithoutNotify(_quest.Tracked);
		}
		_objectivePrefab.Reset();
		using ListPool<IQuestObjective>.List list = ListPool<IQuestObjective>.Get();
		quest.PopulateVisibleObjectives(list);
		foreach (IQuestObjective item in list)
		{
			_objectivePrefab.Get(active: true).Initialize(item);
		}
		_objectivePrefab.Trim();
		_objectivesSection.SetActive(_objectivePrefab.Count > 0);
	}

	private void OnToggleValueChanged(bool value)
	{
		if (value)
		{
			_quest.StartTracking();
		}
		else
		{
			_quest.StopTracking();
		}
	}
}
