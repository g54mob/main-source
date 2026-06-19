using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class SaveFileListItem : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _nameText;

		[SerializeField]
		private GameObject _brokenIcon;

		[SerializeField]
		private Toggle _button;

		private SaveFileHeader _saveFile;

		private Action<SaveFileHeader> _selectAction;

		public void Setup(SaveFileHeader saveFile, ToggleGroup toggleGroup, bool selectedByDefault, Action<SaveFileHeader> selectAction)
		{
			_saveFile = saveFile;
			_selectAction = selectAction;
			_nameText.text = saveFile.GetDisplayName();
			_brokenIcon.SetActive(saveFile.IsBroken);
			_button.isOn = selectedByDefault;
			_button.interactable = !saveFile.IsBroken;
			_button.group = toggleGroup;
			_button.onValueChanged.AddListener(ToggleClicked);
		}

		private void ToggleClicked(bool selected)
		{
			if (selected)
			{
				_selectAction(_saveFile);
			}
		}
	}
}
