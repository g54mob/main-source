using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GuiNew
{
	public class ListSelectionScript : MonoBehaviour
	{
		private Transform _buttonsContainer;

		private Action<string> _callback;

		[SerializeField]
		private RectTransform _cloneButton;

		[SerializeField]
		private Text _nameText;

		[SerializeField]
		private RectTransform _panel;

		private IEnumerable<string> _selectionList;

		public IEnumerable<string> SelectionList
		{
			get
			{
				return _selectionList;
			}
			set
			{
				_selectionList = value;
				if (_buttonsContainer != null)
				{
					UnityEngine.Object.Destroy(_buttonsContainer.gameObject);
				}
				_buttonsContainer = new GameObject("ButtonsContainer").transform;
				_buttonsContainer.parent = _cloneButton.transform.parent;
				_buttonsContainer.localPosition = Vector3.zero;
				_cloneButton.gameObject.SetActive(value: true);
				float num = 0f;
				foreach (string selection in _selectionList)
				{
					GameObject obj = UnityEngine.Object.Instantiate(_cloneButton.gameObject);
					obj.transform.SetParent(_buttonsContainer, worldPositionStays: false);
					RectTransform component = obj.GetComponent<RectTransform>();
					component.SetParent(_buttonsContainer);
					component.localPosition = new Vector3(0f, num, 0f);
					component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _cloneButton.rect.width);
					obj.GetComponentInChildren<Text>().text = selection;
					Button component2 = obj.GetComponent<Button>();
					string aircraftId = selection;
					component2.onClick.AddListener(delegate
					{
						ButtonClicked(aircraftId);
					});
					num -= component.rect.height;
				}
				_panel.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0f - num);
				_cloneButton.gameObject.SetActive(value: false);
			}
		}

		public void Show(string name, Action<string> callback, IEnumerable<string> selectionList)
		{
			_nameText.text = name;
			_callback = callback;
			base.gameObject.SetActive(value: true);
			SelectionList = selectionList;
		}

		private void ButtonClicked(string id)
		{
			base.gameObject.SetActive(value: false);
			if (_callback != null)
			{
				_callback(id);
			}
		}
	}
}
