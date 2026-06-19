using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InspectorSubItemRoomTemplatesList : InspectorSubItem
	{
		[SerializeField]
		private ScrollRect _scroller;

		[SerializeField]
		private GameObject _rowPrefab;

		[SerializeField]
		private Color _rowBackingColor1;

		[SerializeField]
		private Color _rowBackingColor2;

		[SerializeField]
		private Color _dateTextColor;

		private Room _room;

		private List<RoomTemplate> _roomTemplates = new List<RoomTemplate>();

		private readonly List<InspectorRoomTemplateRow> _rows = new List<InspectorRoomTemplateRow>();

		private bool _templatesChanged;

		private Level _level;

		private HUD _hud;

		private RoomTemplateNamingMenu _nameTemplateMenu;

		public void Setup(Room room, Level level, HUD hud)
		{
			_hud = hud;
			_room = room;
			_level = level;
			_roomTemplates = level.App.RoomTemplatesManager.GetTemplatesForRoom(room.Definition._type);
			_scroller.normalizedPosition = new Vector2(0f, 0f);
			RefreshList();
		}

		private void OnDestroy()
		{
			if (_nameTemplateMenu != null)
			{
				_hud.DestroyMenu(_nameTemplateMenu);
				_nameTemplateMenu = null;
			}
		}

		private void RefreshList()
		{
			_templatesChanged = true;
		}

		private void Update()
		{
			if (_templatesChanged)
			{
				_roomTemplates = _level.App.RoomTemplatesManager.GetTemplatesForRoom(_room.Definition._type);
				int count = _roomTemplates.Count;
				for (int i = count + 1; i < _rows.Count; i++)
				{
					GameObjectUtils.SetActive(_rows[i].gameObject, isActive: false);
				}
				while (count + 1 > _rows.Count)
				{
					InspectorRoomTemplateRow component = UnityEngine.Object.Instantiate(_rowPrefab, _scroller.content).GetComponent<InspectorRoomTemplateRow>();
					_rows.Add(component);
				}
				for (int j = 0; j < count; j++)
				{
					GameObjectUtils.SetActive(_rows[j].gameObject, isActive: true);
					_rows[j].Setup(_roomTemplates[j], this);
				}
				GameObjectUtils.SetActive(_rows[count].gameObject, isActive: true);
				_rows[count].Setup(null, this);
				_templatesChanged = false;
			}
		}

		public void AddOrRenameTemplateMenu(RoomTemplate template = null)
		{
			_nameTemplateMenu = _hud.CreateMenu<RoomTemplateNamingMenu>();
			_nameTemplateMenu.Setup(_level, template, this);
			RoomTemplateNamingMenu nameTemplateMenu = _nameTemplateMenu;
			nameTemplateMenu.OnClosed = (Action)Delegate.Combine(nameTemplateMenu.OnClosed, (Action)delegate
			{
				_nameTemplateMenu = null;
				RefreshList();
			});
		}

		public void AddNewRoomTemplate(string templateName)
		{
			BlueprintFloorPlan blueprintFloorPlan = new BlueprintFloorPlan(_room.FloorPlan)
			{
				AutoFlowActive = false
			};
			BuildingLogic.PrepareDuplicatedFloorPlan(blueprintFloorPlan);
			_level.App.RoomTemplatesManager.AddNewRoomTemplate(_room.Definition._type, blueprintFloorPlan, _room.FloorPlanVisual.FloorVisualOverride, _room.FloorPlanVisual.WallVisualOverride, templateName);
			RefreshList();
			blueprintFloorPlan.Destroy();
		}

		private void RemoveTemplateInternal(RoomTemplate template)
		{
			_level.App.RoomTemplatesManager.RemoveRoomTemplate(template);
			RefreshList();
		}

		public void RemoveTemplate(RoomTemplate template)
		{
			NotificationMessages.Definition definition = new NotificationMessages.Definition();
			definition.LocalisedTitle = new LocalisedString("Notification/DeleteTemplate_Title_CS");
			definition.LocalisedText = new LocalisedString("Notification/DeleteTemplate_Message_CS");
			definition.DefaultChoice = 1;
			definition.Choices = new LocalisedString[2]
			{
				new LocalisedString("Menu/Yes"),
				new LocalisedString("Menu/No")
			};
			NotificationGenericDecision message = new NotificationGenericDecision(definition, delegate(int response)
			{
				if (response == 0)
				{
					RemoveTemplateInternal(template);
				}
			}, _level);
			_level.Notifications.OpenPopup(message);
		}

		public void OverwriteRoomTemplateInternal(RoomTemplate template)
		{
			BlueprintFloorPlan blueprintFloorPlan = new BlueprintFloorPlan(_room.FloorPlan)
			{
				AutoFlowActive = false
			};
			BuildingLogic.PrepareDuplicatedFloorPlan(blueprintFloorPlan);
			_level.App.RoomTemplatesManager.ReplaceTemplate(template, blueprintFloorPlan, _room.FloorPlanVisual.FloorVisualOverride, _room.FloorPlanVisual.WallVisualOverride);
			RefreshList();
			blueprintFloorPlan.Destroy();
		}

		public void OverwriteRoomTemplate(RoomTemplate template)
		{
			NotificationMessages.Definition definition = new NotificationMessages.Definition();
			definition.LocalisedTitle = new LocalisedString("Notification/ReplaceTemplate_Title_CS");
			definition.LocalisedText = new LocalisedString("Notification/ReplaceTemplate_Message_CS");
			definition.DefaultChoice = 1;
			definition.Choices = new LocalisedString[2]
			{
				new LocalisedString("Menu/Yes"),
				new LocalisedString("Menu/No")
			};
			NotificationGenericDecision message = new NotificationGenericDecision(definition, delegate(int response)
			{
				if (response == 0)
				{
					OverwriteRoomTemplateInternal(template);
				}
			}, _level);
			_level.Notifications.OpenPopup(message);
		}
	}
}
