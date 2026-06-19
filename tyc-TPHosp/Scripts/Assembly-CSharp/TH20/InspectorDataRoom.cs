using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class InspectorDataRoom : InspectorData
	{
		private enum Tab
		{
			Stats = 0,
			Queue = 1,
			Info = 2,
			Templates = 3,
			NumTabs = 4
		}

		private enum Button
		{
			Objects = 0,
			Edit = 1,
			Close = 2,
			Sell = 3,
			JobPriority = 4,
			NumButtons = 5
		}

		private enum ButtonExtra
		{
			Copy = 0,
			Customisation = 1,
			SpecialAction = 2,
			NumButtons = 3
		}

		private Room _room;

		private InspectorSubItemRoomInfo _roomStats;

		private InspectorSubItemRoomQueue _roomQueue;

		private InspectorSubItemRoomDescription _roomDescription;

		private InspectorSubItemRoomTemplatesList _roomTemplates;

		private InspectorSubDataRoom _roomSubData;

		public Room CurrentRoom => _room;

		public InspectorDataRoom(InspectorMenu owner, Level level, InspectorMenuAssetReference assetReference)
			: base(owner, level, assetReference)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(AssetReference.RoomStatsPrefab);
			_roomStats = gameObject.GetComponent<InspectorSubItemRoomInfo>();
			GameObject gameObject2 = UnityEngine.Object.Instantiate(AssetReference.RoomQueuePrefab);
			_roomQueue = gameObject2.GetComponent<InspectorSubItemRoomQueue>();
			GameObject gameObject3 = UnityEngine.Object.Instantiate(AssetReference.RoomDescriptionPrefab);
			_roomDescription = gameObject3.GetComponent<InspectorSubItemRoomDescription>();
			GameObject gameObject4 = UnityEngine.Object.Instantiate(AssetReference.RoomTemplatesPrefab);
			_roomTemplates = gameObject4.GetComponent<InspectorSubItemRoomTemplatesList>();
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			if (_roomStats != null)
			{
				UnityEngine.Object.Destroy(_roomStats.gameObject);
				_roomStats = null;
			}
			if (_roomQueue != null)
			{
				UnityEngine.Object.Destroy(_roomQueue.gameObject);
				_roomQueue = null;
			}
			if (_roomDescription != null)
			{
				UnityEngine.Object.Destroy(_roomDescription.gameObject);
				_roomDescription = null;
			}
			if (_roomTemplates != null)
			{
				UnityEngine.Object.Destroy(_roomTemplates.gameObject);
				_roomTemplates = null;
			}
			base.Destroy();
		}

		public bool SelectRoom(Room room)
		{
			_roomSubData = null;
			if (InspectorMenu.ShouldShowInspector(room))
			{
				_room = room;
				switch (_room.Definition._type)
				{
				case RoomDefinition.Type.Training:
					_roomSubData = new InspectorSubDataRoomTraining(room);
					break;
				case RoomDefinition.Type.Research:
					_roomSubData = new InspectorSubDataRoomResearch(room);
					break;
				case RoomDefinition.Type.Marketing:
					_roomSubData = new InspectorSubDataRoomMarketing(room);
					break;
				}
				return true;
			}
			return false;
		}

		public override string GetHeaderTitle()
		{
			if (_room == null)
			{
				return string.Empty;
			}
			return _room.GetRoomName();
		}

		public override string GetUserSpecifiedNameEditButtonTooltip()
		{
			return ScriptLocalization.Inspector_TitleEdit.RoomNameEditButton_CS;
		}

		public override void SetUserSpecifiedName(string userSpecifiedName)
		{
			if (_room != null)
			{
				_room.SetUserSpecifiedName(userSpecifiedName);
			}
		}

		public override string GetUserSpecifiedName()
		{
			string result = string.Empty;
			if (_room != null)
			{
				result = _room.GetUserSpecifiedName();
			}
			return result;
		}

		public override Texture GetHeaderPolaroidTexture()
		{
			return null;
		}

		public override Sprite GetHeaderIcon()
		{
			return _room.Definition._icon;
		}

		public override bool UsePolaroidBacking()
		{
			return false;
		}

		public override int GetDefaultTabIndex()
		{
			return 0;
		}

		public override int GetTabCount()
		{
			return 4;
		}

		public override string GetTabText(int tabIndex)
		{
			return (Tab)tabIndex switch
			{
				Tab.Stats => ScriptLocalization.Menu_Inspector.ButtonStats_CS, 
				Tab.Queue => ScriptLocalization.Menu_Inspector.ButtonQueue_CS, 
				Tab.Info => ScriptLocalization.Menu_Inspector.ButtonInfo_CS, 
				Tab.Templates => ScriptLocalization.Menu_Inspector.ButtonTemplates_CS, 
				_ => string.Empty, 
			};
		}

		public override bool IsTabEnabled(int tabIndex)
		{
			return (Tab)tabIndex switch
			{
				Tab.Stats => true, 
				Tab.Queue => _room.Definition._canManageQueue, 
				Tab.Info => true, 
				Tab.Templates => true, 
				_ => true, 
			};
		}

		public override void OnTabSelected(int tabIndex)
		{
		}

		public override void OnGoToPressed()
		{
			if (_room != null)
			{
				Level.CameraLogic.TrackObject(_room.GetCameraTrackObject().transform);
			}
		}

		public override void OnCycleLeftPressed()
		{
			if (_room == null)
			{
				Owner.CloseMenu();
				return;
			}
			int num = Level.WorldState.AllRooms.IndexOf(_room);
			int num2 = num;
			num--;
			Room room = null;
			bool flag = false;
			while ((room == null || !InspectorMenu.ShouldShowInspector(room)) && !flag)
			{
				if (num <= -1)
				{
					num = Level.WorldState.AllRooms.Count - 1;
				}
				if (num == num2)
				{
					flag = true;
				}
				Room room2 = Level.WorldState.AllRooms[num];
				if (InspectorMenu.ShouldShowInspector(room2))
				{
					room = room2;
				}
				num--;
			}
			if (room != null)
			{
				Owner.Inspect(room, selectQueueTab: false);
			}
			else
			{
				Owner.CloseAndRestoreGeneralNotifications();
			}
		}

		public override void OnCycleRightPressed()
		{
			if (_room == null)
			{
				Owner.CloseAndRestoreGeneralNotifications();
				return;
			}
			int num = Level.WorldState.AllRooms.IndexOf(_room);
			int num2 = num;
			num++;
			Room room = null;
			bool flag = false;
			while ((room == null || !InspectorMenu.ShouldShowInspector(room)) && !flag)
			{
				if (num >= Level.WorldState.AllRooms.Count)
				{
					num = 0;
				}
				if (num == num2)
				{
					flag = true;
				}
				Room room2 = Level.WorldState.AllRooms[num];
				if (InspectorMenu.ShouldShowInspector(room2))
				{
					room = room2;
				}
				num++;
			}
			if (room != null)
			{
				Owner.Inspect(room, selectQueueTab: false);
			}
			else
			{
				Owner.CloseAndRestoreGeneralNotifications();
			}
		}

		public override GameObject GetBodyPrefab(int tabIndex)
		{
			switch ((Tab)tabIndex)
			{
			case Tab.Stats:
				_roomStats.Setup(_room);
				return _roomStats.gameObject;
			case Tab.Queue:
				_roomQueue.Setup(Level, _room, Owner);
				return _roomQueue.gameObject;
			case Tab.Info:
				_roomDescription.Setup(_room);
				return _roomDescription.gameObject;
			case Tab.Templates:
				_roomTemplates.Setup(_room, Level, Level.HUD);
				return _roomTemplates.gameObject;
			default:
				return null;
			}
		}

		public override bool UsesSmallFooter()
		{
			return true;
		}

		public override string GetFooterButtonText(int buttonIndex)
		{
			switch ((Button)buttonIndex)
			{
			case Button.Objects:
				return ScriptLocalization.Menu_Inspector.ButtonObjects_CS;
			case Button.Edit:
				return ScriptLocalization.Menu_Inspector.ButtonEdit_CS;
			case Button.Close:
				if (!_room.IsOpen)
				{
					return ScriptLocalization.Menu_Inspector.ButtonOpen_CS;
				}
				return ScriptLocalization.Menu_Inspector.ButtonClose_CS;
			case Button.Sell:
				return ScriptLocalization.Menu_Inspector.ButtonSell_CS;
			case Button.JobPriority:
				if (!_room.HighPriorityJobs)
				{
					return ScriptLocalization.Menu_Inspector.ButtonJobPriorityHigh_CS;
				}
				return ScriptLocalization.Menu_Inspector.ButtonJobPriorityLow_CS;
			default:
				return string.Empty;
			}
		}

		public override int GetFooterButtonCount()
		{
			return 5;
		}

		public override int GetSmallFooterExtraButtonCount()
		{
			return 3;
		}

		public override Sprite GetFooterButtonImage(int buttonIndex)
		{
			return (Button)buttonIndex switch
			{
				Button.Objects => AssetReference.ObjectsButtonIcon, 
				Button.Edit => AssetReference.EditButtonIcon, 
				Button.Close => AssetReference.CloseRoomButtonIcon, 
				Button.Sell => AssetReference.SellButtonIcon, 
				Button.JobPriority => AssetReference.JobPriorityButtonIcon, 
				_ => null, 
			};
		}

		public override bool IsFooterButtonVisible(int buttonIndex)
		{
			switch ((Button)buttonIndex)
			{
			case Button.JobPriority:
				return RoomHasJobs();
			case Button.Close:
				if (_room.IsOpen)
				{
					return true;
				}
				return _room.CanBeOpened();
			default:
				return true;
			}
		}

		public override bool IsFooterButtonEnabled(int buttonIndex)
		{
			switch ((Button)buttonIndex)
			{
			case Button.JobPriority:
				return RoomHasJobs();
			case Button.Close:
				if (_room.IsOpen)
				{
					return true;
				}
				return _room.CanBeOpened();
			default:
				return true;
			}
		}

		public override void OnFooterButtonPressed(int buttonIndex)
		{
			switch ((Button)buttonIndex)
			{
			case Button.Objects:
				EditRoomObjects();
				break;
			case Button.Edit:
				EditRoom();
				break;
			case Button.Close:
				if (_room.IsOpen)
				{
					CloseRoom();
				}
				else
				{
					OpenRoom();
				}
				break;
			case Button.Sell:
				SellRoom();
				break;
			case Button.JobPriority:
				ToggleJobPriorities();
				break;
			}
		}

		public override string GetFooterButtonTooltip(int buttonIndex)
		{
			switch ((Button)buttonIndex)
			{
			case Button.Objects:
				return ScriptLocalization.Tooltip.InspectorDataRoom_Objects_CS;
			case Button.Edit:
				return ScriptLocalization.Tooltip.InspectorDataRoom_Edit_CS;
			case Button.Close:
				if (!_room.IsOpen)
				{
					return ScriptLocalization.Tooltip.InspectorDataRoom_Open_CS;
				}
				return ScriptLocalization.Tooltip.InspectorDataRoom_Close_CS;
			case Button.Sell:
				return ScriptLocalization.Tooltip.InspectorDataRoom_Sell_CS;
			case Button.JobPriority:
				if (!_room.HighPriorityJobs)
				{
					return ScriptLocalization.Menu_Inspector.ButtonJobPriorityHigher_CS;
				}
				return ScriptLocalization.Menu_Inspector.ButtonJobPriorityLower_CS;
			default:
				return string.Empty;
			}
		}

		public override string GetFooterButtonNotVisibleTooltip(int buttonIndex)
		{
			if (buttonIndex == 2)
			{
				return ScriptLocalization.Tooltip.InspectorDataRoom_Open_NoEnergy_CS;
			}
			return string.Empty;
		}

		public override int GetFooterButtonNotificationCount(int buttonIndex)
		{
			return 0;
		}

		private void EditRoomObjects()
		{
			Level.BuildingLogic.TransitionToEditRoomObjectsState(_room);
			Owner.CloseAndRestoreGeneralNotifications();
		}

		private void EditRoom()
		{
			Level.BuildingLogic.TransitionToEditRoomBlueprintState(_room);
			Owner.CloseAndRestoreGeneralNotifications();
		}

		private void CopyRoom()
		{
			Level.BuildingLogic.TransitionToCopyRoomBlueprintState(_room);
			Owner.CloseAndRestoreGeneralNotifications();
		}

		private void CustomiseRoom()
		{
			RoomCustomisationMenu roomCustomisationMenu = Level.HUD.FindMenu<RoomCustomisationMenu>();
			if (!(roomCustomisationMenu != null))
			{
				return;
			}
			if (roomCustomisationMenu.IsClosing() || roomCustomisationMenu.IsClosed())
			{
				Level.HospitalHUDManager.ToggleInfoMenu(delegate(RoomCustomisationMenu menu)
				{
					menu.Setup();
				});
			}
			roomCustomisationMenu.InspectedRoom = _room;
		}

		private void CloseRoom()
		{
			_room.Close();
		}

		private void OpenRoom()
		{
			_room.Open();
		}

		private void SellRoom()
		{
			Owner.CloseAndRestoreGeneralNotifications();
			Level.BuildEvents.DeleteRoom(_room);
		}

		private bool RoomHasJobs()
		{
			List<Job> jobList = new List<Job>();
			Level.StaffWorkScheduler.GatherJobRoomsInRoom(ref jobList, _room);
			return jobList.Count != 0;
		}

		private void ToggleJobPriorities()
		{
			bool highPriorityJobs = !_room.HighPriorityJobs;
			_room.SetHighPriorityJobs(highPriorityJobs);
		}

		public override bool UsesSmallFooterExtra()
		{
			return true;
		}

		public override Sprite GetSmallFooterExtraImage(int buttonIndex)
		{
			Sprite result = null;
			switch ((ButtonExtra)buttonIndex)
			{
			case ButtonExtra.Copy:
				result = AssetReference.CopyButtonIcon;
				break;
			case ButtonExtra.Customisation:
				result = AssetReference.CustomisationButtonIcon;
				break;
			case ButtonExtra.SpecialAction:
				result = AssetReference.ExtraButtonIcon;
				break;
			}
			return result;
		}

		public override string GetSmallFooterExtraText(int buttonIndex)
		{
			string result = string.Empty;
			switch ((ButtonExtra)buttonIndex)
			{
			case ButtonExtra.Copy:
				result = ScriptLocalization.Menu_Inspector.ButtonCopy_CS;
				break;
			case ButtonExtra.Customisation:
				result = AssetReference.ButtonRoomCustomisationText.Translation;
				break;
			case ButtonExtra.SpecialAction:
				result = ((_roomSubData != null) ? _roomSubData.GetText() : string.Empty);
				break;
			}
			return result;
		}

		public override string GetSmallFooterExtraTooltip(int buttonIndex)
		{
			string result = string.Empty;
			switch ((ButtonExtra)buttonIndex)
			{
			case ButtonExtra.Copy:
				result = ScriptLocalization.Tooltip.InspectorDataRoom_Copy_CS;
				break;
			case ButtonExtra.Customisation:
				result = AssetReference.ButtonRoomCustomisationTooltipText.Translation;
				break;
			case ButtonExtra.SpecialAction:
				result = ((_roomSubData != null) ? _roomSubData.GetTooltip() : string.Empty);
				break;
			}
			return result;
		}

		public override bool IsSmallFooterExtraButtonVisible(int buttonIndex)
		{
			return true;
		}

		public override bool IsSmallFooterExtraButtonEnabled(int buttonIndex)
		{
			bool result = false;
			switch ((ButtonExtra)buttonIndex)
			{
			case ButtonExtra.Copy:
				result = true;
				break;
			case ButtonExtra.Customisation:
				result = true;
				break;
			case ButtonExtra.SpecialAction:
				result = _roomSubData != null && _roomSubData.ShouldShowButton();
				break;
			}
			return result;
		}

		public override bool OnSmallFooterExtraButtonPressed(int buttonIndex)
		{
			bool result = false;
			switch ((ButtonExtra)buttonIndex)
			{
			case ButtonExtra.Copy:
				result = true;
				CopyRoom();
				break;
			case ButtonExtra.Customisation:
				result = true;
				CustomiseRoom();
				break;
			case ButtonExtra.SpecialAction:
				result = _roomSubData != null && _roomSubData.OnButtonPressed();
				break;
			}
			return result;
		}

		private void OnRoomDeleted(Room room)
		{
			if (room == _room)
			{
				Owner.CloseAndRestoreGeneralNotifications();
			}
		}
	}
}
