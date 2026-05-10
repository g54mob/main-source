using System.Collections.Generic;
using CTS.ScriptableSettings;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_PopUpListHelper : MonoBehaviour
	{
		[Foldout("Dev")]
		[SerializeField]
		private TMP_Text _popUpListDisplay;

		[Foldout("Dev")]
		[SerializeField]
		private TMP_Text _currentPresetDisplay;

		[Foldout("Dev")]
		[InfoBox("The ID should be exactly the name of the variable that's changed by this element. CASE SENSITIVE", EInfoBoxType.Error)]
		[SerializeField]
		private string _popUpID;

		[Foldout("Dev")]
		[SerializeField]
		private Image _buttonImage;

		[Foldout("Dev")]
		[SerializeField]
		private GameObject _listObject;

		[Foldout("Dev")]
		[SerializeField]
		private Transform _contentParent;

		[Foldout("Dev")]
		[SerializeField]
		private GameObject _popUpButtonPrefab;

		[Foldout("Dev")]
		[Tooltip("This is for elements like the resolution that requires 2 integers to work, a bit messy sorry :)")]
		[SerializeField]
		private bool _isVector2Int;

		[SerializeField]
		[ShowIf("_isVector2Int")]
		private Vector2IntSetting _vector2IntSetting;

		[BoxGroup("Button")]
		[SerializeField]
		private Color _buttonColor;

		[BoxGroup("Button")]
		[ShowAssetPreview(64, 64)]
		[SerializeField]
		private Sprite _buttonSprite;

		[BoxGroup("Pop Up List Name")]
		[SerializeField]
		private string _popUpListName;

		public List<Vector2Int> _popUpListVector2 = new List<Vector2Int>();

		public List<string> _popUpList = new List<string>();

		private void OnEnable()
		{
		}

		private void Start()
		{
			Settings.OnCurrentDisplayUpdated += UpdateCurrentDisplay;
		}

		private void OnDestroy()
		{
			Settings.OnCurrentDisplayUpdated -= UpdateCurrentDisplay;
		}

		private void UpdateCurrentDisplay(string ID, string textToDisplay)
		{
			if (!(ID != _popUpID))
			{
				_currentPresetDisplay.text = textToDisplay;
			}
		}

		public void OpenList()
		{
			_listObject.SetActive(value: true);
			RectTransform rectTransform = GetComponent<RectTransform>();
			OptionsMenu optionsMenu = null;
			while (rectTransform != null && optionsMenu == null)
			{
				optionsMenu = rectTransform.GetComponent<OptionsMenu>();
				if (optionsMenu == null)
				{
					rectTransform = rectTransform.parent as RectTransform;
				}
			}
			_listObject.transform.SetParent(rectTransform.transform);
			if (_contentParent.childCount != 0)
			{
				return;
			}
			for (int i = 0; i < (_isVector2Int ? _popUpListVector2.Count : _popUpList.Count); i++)
			{
				string text = (_isVector2Int ? $"{_popUpListVector2[i].x} x {_popUpListVector2[i].y}" : _popUpList[i]);
				GameObject newButton = Object.Instantiate(_popUpButtonPrefab, _contentParent);
				Button component = newButton.GetComponent<Button>();
				newButton.transform.GetChild(0).GetComponent<TMP_Text>().text = text;
				component.onClick.AddListener(delegate
				{
					SpawnButton(newButton);
				});
			}
		}

		private void SpawnButton(GameObject newButton)
		{
		}

		public void CloseList()
		{
			_listObject.transform.SetParent(base.transform);
			_listObject.SetActive(value: false);
		}
	}
}
