using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class InspectorRoomTemplateRow : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _templateNameText;

		[SerializeField]
		private TMP_Text _roomSizeText;

		[SerializeField]
		private Image _roomIcon;

		[SerializeField]
		private DynamicButton _deleteButton;

		[SerializeField]
		private DynamicButton _renameButton;

		[SerializeField]
		private DynamicButton _overwriteButton;

		[SerializeField]
		private DynamicButton _addNewTemplateButton;

		[SerializeField]
		private TMP_Text _saveNewTemplateText;

		private InspectorSubItemRoomTemplatesList _templateList;

		private RoomTemplate _template;

		private void OnDestroy()
		{
			RemoveListeners();
		}

		private void RemoveListeners()
		{
			if (_deleteButton != null)
			{
				_deleteButton.onPrimaryDown.RemoveAllListeners();
			}
			if (_renameButton != null)
			{
				_renameButton.onPrimaryDown.RemoveAllListeners();
			}
			if (_overwriteButton != null)
			{
				_overwriteButton.onPrimaryDown.RemoveAllListeners();
			}
			if (_addNewTemplateButton != null)
			{
				_addNewTemplateButton.onPrimaryDown.RemoveAllListeners();
			}
		}

		public void Setup(RoomTemplate template, InspectorSubItemRoomTemplatesList templateList)
		{
			_templateList = templateList;
			_template = template;
			RemoveListeners();
			if (template != null)
			{
				if (_templateNameText != null)
				{
					GameObjectUtils.SetActive(_templateNameText.gameObject, isActive: true);
					_templateNameText.text = template.UserDefinedName;
				}
				if (_saveNewTemplateText != null)
				{
					GameObjectUtils.SetActive(_saveNewTemplateText.gameObject, isActive: false);
				}
				if (_deleteButton != null)
				{
					GameObjectUtils.SetActive(_deleteButton.gameObject, isActive: true);
					_deleteButton.onPrimaryDown.AddListener(RemoveRoomTemplate);
				}
				if (_renameButton != null)
				{
					GameObjectUtils.SetActive(_renameButton.gameObject, isActive: true);
					_renameButton.onPrimaryDown.AddListener(RenameRoomTemplate);
				}
				if (_overwriteButton != null)
				{
					GameObjectUtils.SetActive(_overwriteButton.gameObject, isActive: true);
				}
				if (_roomIcon != null)
				{
					_roomIcon.overrideSprite = template.TemplateFloorPlan.Definition._icon;
					GameObjectUtils.SetActive(_roomIcon.gameObject, isActive: true);
				}
				if (_overwriteButton != null)
				{
					GameObjectUtils.SetActive(_overwriteButton.gameObject, isActive: true);
					_overwriteButton.onPrimaryDown.AddListener(ReplaceRoomTemplate);
				}
				if (_roomSizeText != null)
				{
					GameObjectUtils.SetActive(_roomSizeText.gameObject, isActive: true);
					_roomSizeText.text = template.TemplateFloorPlan.Width() + " x " + template.TemplateFloorPlan.Height();
				}
				if (_addNewTemplateButton != null)
				{
					GameObjectUtils.SetActive(_addNewTemplateButton.gameObject, isActive: false);
				}
			}
			else
			{
				if (_saveNewTemplateText != null)
				{
					GameObjectUtils.SetActive(_saveNewTemplateText.gameObject, isActive: true);
				}
				if (_templateNameText != null)
				{
					GameObjectUtils.SetActive(_templateNameText.gameObject, isActive: false);
				}
				if (_addNewTemplateButton != null)
				{
					GameObjectUtils.SetActive(_addNewTemplateButton.gameObject, isActive: true);
					_addNewTemplateButton.onPrimaryDown.AddListener(AddRoomTemplate);
				}
				if (_deleteButton != null)
				{
					GameObjectUtils.SetActive(_deleteButton.gameObject, isActive: false);
				}
				if (_renameButton != null)
				{
					GameObjectUtils.SetActive(_renameButton.gameObject, isActive: false);
				}
				if (_overwriteButton != null)
				{
					GameObjectUtils.SetActive(_overwriteButton.gameObject, isActive: false);
				}
				if (_roomIcon != null)
				{
					GameObjectUtils.SetActive(_roomIcon.gameObject, isActive: false);
				}
				if (_overwriteButton != null)
				{
					GameObjectUtils.SetActive(_overwriteButton.gameObject, isActive: false);
				}
				if (_roomSizeText != null)
				{
					GameObjectUtils.SetActive(_roomSizeText.gameObject, isActive: false);
				}
			}
		}

		public void AddRoomTemplate()
		{
			if ((bool)_templateList)
			{
				_templateList.AddOrRenameTemplateMenu();
			}
		}

		public void RenameRoomTemplate()
		{
			if ((bool)_templateList)
			{
				_templateList.AddOrRenameTemplateMenu(_template);
			}
		}

		public void RemoveRoomTemplate()
		{
			if (_templateList != null)
			{
				_templateList.RemoveTemplate(_template);
			}
		}

		public void ReplaceRoomTemplate()
		{
			if (_templateList != null)
			{
				_templateList.OverwriteRoomTemplate(_template);
			}
		}
	}
}
