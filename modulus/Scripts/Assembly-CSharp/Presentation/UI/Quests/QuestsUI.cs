using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Data.Quests;
using Events;
using Events.UI;
using Presentation.Locators;
using Presentation.UI.Buttons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Quests
{
	public class QuestsUI : MonoBehaviour
	{
		[SerializeField]
		private QuestManagerLocator _questManagerLocator;

		[SerializeField]
		private SubQuestUI _subQuestPrefab;

		[SerializeField]
		private SubQuestUI _hiddenSubQuestPrefab;

		[SerializeField]
		private GameObject _line;

		[SerializeField]
		private CanvasGroup _listParent;

		[SerializeField]
		private TextMeshProUGUI _questNameTextField;

		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private BaseEvent _forceCancelMenuModalDialogEvent;

		[SerializeField]
		private BaseEvent _forceCancelModalDialogEvent;

		[SerializeField]
		private BaseEvent<float> _QuestUIHeightChangedEvent;

		[SerializeField]
		private ToolSystemLocator _toolSystemLocator;

		[SerializeField]
		private ShowBuildBarEvent _showBuildBar;

		[SerializeField]
		private IconFlipper _collapseButton;

		[SerializeField]
		private HorizontalLayoutGroup _titleLayoutGroup;

		[SerializeField]
		private RectTransform _mainQuestIcon;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		private readonly Dictionary<(SubQuestSO, int), SubQuestUI> _spawnedSubQuests = new Dictionary<(SubQuestSO, int), SubQuestUI>();

		private Vector2 _hiddenAnchoredPos;

		private Vector2 _originalAnchoredPos;

		private RectOffset _titleLayoutGroupPadding;

		private RectOffset _titleLayoutGroupPaddingCollapsed;

		private QuestSO _quest;

		private void Awake()
		{
			_titleLayoutGroupPadding = _titleLayoutGroup.padding;
			_titleLayoutGroupPaddingCollapsed = new RectOffset(_titleLayoutGroupPadding.left, _titleLayoutGroupPadding.right - 30, _titleLayoutGroupPadding.top, _titleLayoutGroupPadding.bottom);
			_questManagerLocator.QuestManager.AllQuestsCompleted += HandleAllQuestsCompleted;
			_questManagerLocator.QuestManager.QuestCompleted += HandleQuestCompleted;
			_questManagerLocator.QuestManager.QuestStarted += HandleQuestStarted;
			_questManagerLocator.QuestManager.OnSubQuestStarted += HandleSubQuestStarted;
			_questManagerLocator.QuestManager.OnSubQuestComplete += HandleSubOnQuestCompleted;
			_questManagerLocator.QuestManager.OnQuestReset += HandleQuestReset;
			_collapseButton.FlippedStateChanged += SetCollapsedState;
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
			_originalAnchoredPos = _rectTransform.anchoredPosition;
			_hiddenAnchoredPos = _originalAnchoredPos;
			_hiddenAnchoredPos.x = -1000f;
			_rectTransform.anchoredPosition = _hiddenAnchoredPos;
		}

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
			_collapseButton.FlippedStateChanged -= SetCollapsedState;
			if (_questManagerLocator.QuestManager != null)
			{
				_questManagerLocator.QuestManager.AllQuestsCompleted -= HandleAllQuestsCompleted;
				_questManagerLocator.QuestManager.QuestCompleted -= HandleQuestCompleted;
				_questManagerLocator.QuestManager.QuestStarted -= HandleQuestStarted;
				_questManagerLocator.QuestManager.OnSubQuestStarted -= HandleSubQuestStarted;
				_questManagerLocator.QuestManager.OnSubQuestComplete -= HandleSubOnQuestCompleted;
				_questManagerLocator.QuestManager.OnQuestReset -= HandleQuestReset;
			}
		}

		private void HandleQuestStarted(QuestSO quest)
		{
			_quest = quest;
			_questNameTextField.SetText(quest.QuestName);
			SpawnAllSubquests(quest);
			_audioManagerLocator.AudioManager.PlayNewObjective();
		}

		private void OnLanguageUpdate()
		{
			if (_quest != null)
			{
				_questNameTextField.SetText(_quest.QuestName);
			}
		}

		private void SpawnAllSubquests(QuestSO quest)
		{
			bool flag = false;
			for (int i = 0; i < quest.OrderedSubQuests.Count; i++)
			{
				SubQuestSO subQuest = quest.OrderedSubQuests[i];
				SpawnSubQuest(subQuest, i, out var isVisibleQuest);
				if (isVisibleQuest)
				{
					flag = true;
				}
			}
			for (int j = 0; j < quest.NonOrderedSubQuests.Count; j++)
			{
				SubQuestSO subQuest2 = quest.NonOrderedSubQuests[j];
				SpawnSubQuest(subQuest2, j + 512, out var isVisibleQuest2);
				if (isVisibleQuest2)
				{
					flag = true;
				}
			}
			if (flag)
			{
				_rectTransform.DOAnchorPos(_originalAnchoredPos, 0.5f).From(_hiddenAnchoredPos).SetEase(Ease.OutBack)
					.OnComplete(SubQuestsSpawned);
			}
		}

		private void SubQuestsSpawned()
		{
			_QuestUIHeightChangedEvent.Fire(_rectTransform.rect.height);
		}

		private void HandleSubQuestStarted(SubQuestSO subQuest, int index)
		{
			if (_spawnedSubQuests.TryGetValue((subQuest, index), out var value))
			{
				value.MarkAsStarted();
			}
		}

		private void HandleSubOnQuestCompleted(SubQuestSO subQuest, int index)
		{
			if (_spawnedSubQuests.TryGetValue((subQuest, index), out var value))
			{
				value.MarkAsCompleted();
				UpdateSubQuestsShownAsCompleted();
				_audioManagerLocator.AudioManager.PlaySubQuestComplete();
			}
		}

		private void HandleQuestReset()
		{
			DeleteAllSubQuests();
		}

		private void UpdateSubQuestsShownAsCompleted()
		{
			UpdateOrderedSubQuestsShownAsCompleted();
			UpdateNonOrderedSubQuestsShownAsCompleted();
		}

		private void UpdateNonOrderedSubQuestsShownAsCompleted()
		{
			foreach (SubQuestUI item in (from ssq in _spawnedSubQuests
				where ssq.Key.Item2 >= 512
				select ssq.Value).ToList())
			{
				if (item.IsMarkedCompleted && !item.IsShownCompleted)
				{
					ShowSubQuestAsCompleted(item);
				}
			}
		}

		private void ShowSubQuestAsCompleted(SubQuestUI spawnedSubQuestUI)
		{
			if (_collapseButton.IsFlipped)
			{
				_mainQuestIcon.rotation = Quaternion.Euler(0f, 0f, 0f);
				Sequence sequence = DOTween.Sequence();
				sequence.Append(_mainQuestIcon.DOScale(Vector3.one, 0.4f).From(Vector3.one * 4f));
				sequence.Join(_mainQuestIcon.DORotate(Vector3.forward * -90f, 0.4f));
				sequence.Play();
			}
			spawnedSubQuestUI.ShowAsCompleted();
		}

		private void UpdateOrderedSubQuestsShownAsCompleted()
		{
			List<SubQuestUI> list = (from ssq in _spawnedSubQuests
				where ssq.Key.Item2 < 512
				select ssq.Value).ToList();
			for (int num = 0; num < list.Count; num++)
			{
				SubQuestUI subQuestUI = list.ElementAt(num);
				if (subQuestUI.IsShownCompleted || !subQuestUI.IsMarkedCompleted)
				{
					continue;
				}
				if (subQuestUI.SubQuest.HideInQuestUI)
				{
					ShowSubQuestAsCompleted(subQuestUI);
					continue;
				}
				if (num == list.Count - 1)
				{
					ShowSubQuestAsCompleted(subQuestUI);
					continue;
				}
				for (int num2 = num + 1; num2 < list.Count; num2++)
				{
					SubQuestUI subQuestUI2 = list.ElementAt(num2);
					if (!subQuestUI2.SubQuest.HideInQuestUI)
					{
						ShowSubQuestAsCompleted(subQuestUI);
						break;
					}
					if (subQuestUI2.SubQuest.HideInQuestUI && !subQuestUI2.IsMarkedCompleted)
					{
						break;
					}
					if (subQuestUI2.SubQuest.HideInQuestUI && subQuestUI2.IsMarkedCompleted && num2 == list.Count - 1)
					{
						ShowSubQuestAsCompleted(subQuestUI);
						break;
					}
				}
			}
		}

		private void SpawnSubQuest(SubQuestSO subQuest, int index, out bool isVisibleQuest)
		{
			SubQuestUI subQuestUI;
			if (subQuest.HideInQuestUI)
			{
				isVisibleQuest = false;
				subQuestUI = Object.Instantiate(_hiddenSubQuestPrefab, _listParent.transform);
			}
			else
			{
				isVisibleQuest = true;
				subQuestUI = Object.Instantiate(_subQuestPrefab, _listParent.transform);
			}
			subQuestUI.Show(subQuest);
			_spawnedSubQuests.Add((subQuest, index), subQuestUI);
		}

		private void ClearAndAnimateOutSpawnedSubQuests()
		{
			_rectTransform.DOAnchorPos(_hiddenAnchoredPos, 0.5f).SetEase(Ease.InBack).SetDelay(0.6f)
				.OnComplete(DeleteAllSubQuests);
		}

		private void DeleteAllSubQuests()
		{
			_questNameTextField.SetText(string.Empty);
			foreach (KeyValuePair<(SubQuestSO, int), SubQuestUI> spawnedSubQuest in _spawnedSubQuests)
			{
				Object.Destroy(spawnedSubQuest.Value.gameObject);
			}
			_spawnedSubQuests.Clear();
			_QuestUIHeightChangedEvent.Fire(_rectTransform.rect.height);
		}

		private void HandleQuestCompleted(QuestSO quest)
		{
			ClearAndAnimateOutSpawnedSubQuests();
		}

		private void HandleAllQuestsCompleted()
		{
			ClearAndAnimateOutSpawnedSubQuests();
			_forceCancelMenuModalDialogEvent.Fire();
			_forceCancelModalDialogEvent.Fire();
			_toolSystemLocator.ToolSystem.SelectDefaultTool();
		}

		private void SetCollapsedState(bool activated)
		{
			_listParent.alpha = ((!activated) ? 1 : 0);
			_titleLayoutGroup.transform.DOKill(complete: true);
			if (activated)
			{
				_titleLayoutGroup.transform.DOLocalMoveX(-120f, 0.4f).SetEase(Ease.OutBack);
				_questNameTextField.gameObject.SetActive(value: false);
				_titleLayoutGroup.padding = _titleLayoutGroupPaddingCollapsed;
			}
			else
			{
				_titleLayoutGroup.transform.DOLocalMoveX(-100f, 0.4f).SetEase(Ease.OutBack);
				_questNameTextField.gameObject.SetActive(value: true);
				_titleLayoutGroup.padding = _titleLayoutGroupPadding;
			}
		}
	}
}
