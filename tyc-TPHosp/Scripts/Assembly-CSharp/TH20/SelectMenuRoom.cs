using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SelectMenuRoom : SelectMenuRoomBase
	{
		[SerializeField]
		private Button _objectsButton;

		[SerializeField]
		private Button _editButton;

		[SerializeField]
		private Button _openCloseButton;

		[SerializeField]
		private Button _sellButton;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private ProgressBar _prestigeBar;

		[SerializeField]
		private TMP_Text _staffText;

		[SerializeField]
		private TMP_Text _stateText;

		[SerializeField]
		private TMP_Text _queueText;

		[SerializeField]
		private GameObject _whoCanUsePanel;

		[SerializeField]
		private GameObject _whoCanUseButtonPrefab;

		[SerializeField]
		private Sprite _maleIcon;

		[SerializeField]
		private Sprite _femaleIcon;

		[SerializeField]
		private Sprite _staffIcon;

		[SerializeField]
		private Sprite _patientsIcon;

		[SerializeField]
		private Sprite _doctorsIcon;

		[SerializeField]
		private Sprite _nursesIcon;

		[SerializeField]
		private Sprite _janitorsIcon;

		[SerializeField]
		private Sprite _assistantsIcon;

		public override void Setup(Room room, Level level)
		{
			base.Setup(room, level);
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			_objectsButton.onClick.AddListener(ObjectsButton);
			_editButton.onClick.AddListener(EditButton);
			_openCloseButton.onClick.AddListener(OpenCloseButton);
			_sellButton.onClick.AddListener(SellButton);
			CreateWhoCanUseButtons();
			_openCloseButton.GetComponentInChildren<TMP_Text>().text = (_room.IsOpen ? ScriptLocalization.Menu.Select_Room_Close_CS : ScriptLocalization.Menu.Select_Room_Open_CS);
		}

		private void CreateWhoCanUseButtons()
		{
			WhoCanUseRoom whoCanUse = _room.WhoCanUse;
			WhoCanUseRoom.GroupDefinition[] definition = whoCanUse.Definition;
			if (definition == null)
			{
				_whoCanUsePanel.SetActive(value: false);
			}
			else
			{
				for (int i = 0; i < definition.Length; i++)
				{
					WhoCanUseRoom.GroupDefinition groupDefinition = definition[i];
					for (int j = 0; j < groupDefinition.Members.Length; j++)
					{
						WhoCanUseRoom.MemberType member = whoCanUse.GetMember(i, j);
						bool flag = whoCanUse.IsMember(i, j);
						GameObject gameObject = UnityEngine.Object.Instantiate(_whoCanUseButtonPrefab, _whoCanUseButtonPrefab.transform.parent);
						Image image = gameObject.GetComponentsInChildrenOnly<Image>()[0];
						Button component = gameObject.GetComponent<Button>();
						switch (member)
						{
						case WhoCanUseRoom.MemberType.Male:
							image.overrideSprite = _maleIcon;
							break;
						case WhoCanUseRoom.MemberType.Female:
							image.overrideSprite = _femaleIcon;
							break;
						case WhoCanUseRoom.MemberType.Staff:
							image.overrideSprite = _staffIcon;
							break;
						case WhoCanUseRoom.MemberType.Patients:
							image.overrideSprite = _patientsIcon;
							break;
						case WhoCanUseRoom.MemberType.Doctors:
							image.overrideSprite = _doctorsIcon;
							break;
						case WhoCanUseRoom.MemberType.Nurses:
							image.overrideSprite = _nursesIcon;
							break;
						case WhoCanUseRoom.MemberType.Janitors:
							image.overrideSprite = _janitorsIcon;
							break;
						case WhoCanUseRoom.MemberType.Assistants:
							image.overrideSprite = _assistantsIcon;
							break;
						default:
							throw new ArgumentOutOfRangeException();
						}
						int localGroupIndex = i;
						int localMemberIndex = j;
						image.color = (flag ? Color.white : Color.gray);
						component.onClick.AddListener(delegate
						{
							bool flag2 = whoCanUse.ToggleMember(localGroupIndex, localMemberIndex);
							image.color = (flag2 ? Color.white : Color.gray);
						});
					}
				}
			}
			_whoCanUseButtonPrefab.SetActive(value: false);
		}

		protected override void Update()
		{
			base.Update();
			_name.text = _room.Definition.GetLocalisedName();
			RoomPrestige roomPrestige = GameAlgorithms.CalculateRoomPrestige(_room.FloorPlan);
			_prestigeBar.LabelText = ScriptLocalization.Menu.Hover_Room_Prestige_CS.Replace("{[LEVEL]}", roomPrestige.Level.ToString());
			_prestigeBar.Progress = roomPrestige.Progress;
			if (_room.RequiredStaffAssigned())
			{
				if (_room.AssignedStaff.Count >= 1)
				{
					_staffText.gameObject.SetActive(value: true);
					_staffText.text = ScriptLocalization.Menu.Hover_Room_StaffList_CS;
					foreach (Staff item in _room.AssignedStaff)
					{
						TMP_Text staffText = _staffText;
						staffText.text = staffText.text + "\n" + item.NameWithTitle;
					}
				}
				else
				{
					_staffText.gameObject.SetActive(value: false);
				}
			}
			else
			{
				List<StaffRequired> list = new List<StaffRequired>();
				_room.RemainingStaffRequired(list);
				_staffText.text = ScriptLocalization.Menu.Hover_Room_StaffRequired_CS;
				foreach (StaffRequired item2 in list)
				{
					TMP_Text staffText2 = _staffText;
					staffText2.text = staffText2.text + "\n" + item2;
				}
			}
			_queueText.text = ScriptLocalization.Menu.Hover_Room_QueueLength_CS.Replace("{[LENGTH]}", _room.QueueLength.ToString());
			_stateText.text = (_room.IsOpen ? ScriptLocalization.Menu.Select_Room_StatusOpen_CS : ScriptLocalization.Menu.Select_Room_StatusClosed_CS);
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			base.Destroy();
		}

		private void OnRoomDeleted(Room room)
		{
			if (room == _room)
			{
				CloseMenu();
			}
		}

		private void ObjectsButton()
		{
			base.Level.BuildingLogic.TransitionToEditRoomObjectsState(_room);
			CloseMenu();
		}

		private void EditButton()
		{
			base.Level.BuildingLogic.TransitionToEditRoomBlueprintState(_room);
			CloseMenu();
		}

		private void OpenCloseButton()
		{
			if (_room.IsOpen)
			{
				_room.Close();
			}
			else
			{
				_room.Open();
			}
			CloseMenu();
		}

		private void SellButton()
		{
			CloseMenu();
			base.Level.BuildEvents.DeleteRoom(_room);
		}
	}
}
