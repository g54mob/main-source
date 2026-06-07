using System.Collections;
using System.Collections.Generic;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Freighter;
using Data.Variables;
using Presentation.Locators;
using Presentation.UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Freighters
{
	public class FreighterSelectList : MonoBehaviour
	{
		[SerializeField]
		private FreightersManagerLocator _freightersManagerLocator;

		[SerializeField]
		private FreighterSelectItem _prefab;

		[SerializeField]
		private Button _addFreighterButton;

		[SerializeField]
		private ButtonEnabler _addFreighterButtonEnabler;

		[SerializeField]
		private IntVariableSO _maxFreightersAmount;

		[SerializeField]
		private IntVariableSO _selectedFreighterInUI;

		[SerializeField]
		private GameObject _noActiveFreightersText;

		[SerializeField]
		private GameObject _listContainer;

		[SerializeField]
		private ScrollRect _scrollRect;

		[SerializeField]
		private TextInfoPanelContent _outOfFreightersWarning;

		private readonly List<FreighterSelectItem> _items = new List<FreighterSelectItem>();

		private int _freighterIdToFocusOn = -1;

		private void OnEnable()
		{
			_freightersManagerLocator.Manager.OnFreightersChanged += OnFreightersChanged;
			_maxFreightersAmount.ValueChanged += OnFreightersChanged;
			_addFreighterButton.onClick.AddListener(OnClickAddFreighter);
			FreightHubBehaviour.OnFreightHubsChanged += OnFreightersChanged;
			OnFreightersChanged();
			SetOutOfFreightersWarningActive();
		}

		private void OnDisable()
		{
			if (_freightersManagerLocator.Exists)
			{
				_freightersManagerLocator.Manager.OnFreightersChanged -= OnFreightersChanged;
			}
			_maxFreightersAmount.ValueChanged -= OnFreightersChanged;
			_addFreighterButton.onClick.RemoveListener(OnClickAddFreighter);
			FreightHubBehaviour.OnFreightHubsChanged -= OnFreightersChanged;
		}

		private void SetOutOfFreightersWarningActive()
		{
			_outOfFreightersWarning.enabled = _freightersManagerLocator.Manager.FreighterCount >= _maxFreightersAmount.Value;
		}

		private void Start()
		{
			_prefab.gameObject.SetActive(value: false);
			_items.Add(_prefab);
			OnFreightersChanged();
		}

		private void OnFreightersChanged(int _)
		{
			OnFreightersChanged();
		}

		private void OnFreightersChanged()
		{
			UpdateList();
			UpdateAddFreighterButton();
		}

		private void UpdateAddFreighterButton()
		{
			_addFreighterButtonEnabler.Interactable = _freightersManagerLocator.Manager.FreighterCount < _maxFreightersAmount.Value;
			_noActiveFreightersText.SetActive(_freightersManagerLocator.Manager.FreighterCount == 0);
			_listContainer.SetActive(_freightersManagerLocator.Manager.FreighterCount > 0);
		}

		private void OnClickAddFreighter()
		{
			if (_freightersManagerLocator.Manager.TryAddFreighter(out var freighterObject))
			{
				_selectedFreighterInUI.SetValue(freighterObject.CreatedId);
				_freighterIdToFocusOn = freighterObject.CreatedId;
				SetOutOfFreightersWarningActive();
			}
		}

		private void UpdateList()
		{
			IEnumerable<FreighterObject> freighters = _freightersManagerLocator.Manager.Freighters;
			RectTransform rectTransform = null;
			int i = 0;
			foreach (FreighterObject item in freighters)
			{
				FreighterSelectItem freighterSelectItem;
				if (i >= _items.Count)
				{
					freighterSelectItem = Object.Instantiate(_prefab, _prefab.transform.parent, worldPositionStays: true);
					_items.Add(freighterSelectItem);
				}
				else
				{
					freighterSelectItem = _items[i];
				}
				freighterSelectItem.gameObject.SetActive(value: true);
				freighterSelectItem.Initalize(item);
				if (_freighterIdToFocusOn > 0 && item.CreatedId == _freighterIdToFocusOn)
				{
					rectTransform = freighterSelectItem.transform as RectTransform;
				}
				i++;
			}
			for (; i < _items.Count; i++)
			{
				_items[i].gameObject.SetActive(value: false);
			}
			if (rectTransform != null)
			{
				StartCoroutine(ScrollTo(_scrollRect, rectTransform));
			}
		}

		private IEnumerator ScrollTo(ScrollRect scrollRect, RectTransform target)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(scrollRect.content);
			yield return new WaitForEndOfFrame();
			_freighterIdToFocusOn = -1;
			Vector2 vector = target.localPosition;
			float height = scrollRect.content.rect.height;
			float height2 = scrollRect.viewport.rect.height;
			float verticalNormalizedPosition = 1f - Mathf.Clamp01(vector.y * -1f / (height - height2));
			scrollRect.verticalNormalizedPosition = verticalNormalizedPosition;
		}
	}
}
