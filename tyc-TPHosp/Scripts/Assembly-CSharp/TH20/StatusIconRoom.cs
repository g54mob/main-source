using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StatusIconRoom : StatusIcon
	{
		[SerializeField]
		private GameObject _root;

		[SerializeField]
		private Image _doctorImage;

		[SerializeField]
		private Image _doctorQualificationImage;

		[SerializeField]
		private Image _nurseImage;

		[SerializeField]
		private Image _nurseQualificationImage;

		[SerializeField]
		private Image _janitorImage;

		[SerializeField]
		private Image _janitorQualificationImage;

		[SerializeField]
		private Image _assistantImage;

		[SerializeField]
		private Image _assistantQualificationImage;

		[SerializeField]
		private Image _priorityJobImage;

		[SerializeField]
		private Image _itemRequiredImage;

		[SerializeField]
		private GameObject _queueWarning;

		[SerializeField]
		private TMP_Text _queueWarningText;

		private Room _room;

		private RoomItem _roomItem;

		private List<StaffRequired> _requiredStaff = new List<StaffRequired>();

		public override void Initialise(IStatusIconEmitter emitter, Level level, int priority)
		{
			base.Initialise(emitter, level, priority);
			_room = emitter as Room;
			_roomItem = emitter as RoomItem;
			Update();
			GameObjectUtils.SetActive(_root, isActive: false);
		}

		private void Update()
		{
			bool flag = false;
			if (_roomItem != null)
			{
				flag |= UpdateRoomItemIcons();
			}
			else if (_room != null)
			{
				flag |= UpdateRoomIcons();
			}
			flag |= UpdateQueueWarningIcon();
			GameObjectUtils.SetActive(_root, flag);
		}

		private int GetQueueLength()
		{
			if (_room != null && _room.Definition._hasQueue)
			{
				return _room.QueueLength;
			}
			if (_roomItem != null && _roomItem.Definition.ShowQueuePositions)
			{
				return _roomItem.QueueLength;
			}
			return 0;
		}

		private bool UpdateQueueWarningIcon()
		{
			int queueLength = GetQueueLength();
			bool flag = queueLength >= _level.HospitalPolicy.QueueWarningLength;
			if (flag && _room != null)
			{
				flag = _room.Definition._allowQueueWarningStatusIcon;
			}
			_queueWarningText.text = (flag ? queueLength.ToString() : string.Empty);
			if (_queueWarning.activeSelf != flag)
			{
				_queueWarning.SetActive(flag);
			}
			return flag;
		}

		private bool UpdateRoomIcons()
		{
			if (_room.GetMissingRequiredItem(out var missing))
			{
				_itemRequiredImage.sprite = missing.GetIcon();
				GameObjectUtils.SetActive(_doctorImage.gameObject, isActive: false);
				GameObjectUtils.SetActive(_nurseImage.gameObject, isActive: false);
				GameObjectUtils.SetActive(_assistantImage.gameObject, isActive: false);
				GameObjectUtils.SetActive(_janitorImage.gameObject, isActive: false);
				GameObjectUtils.SetActive(_itemRequiredImage.gameObject, isActive: true);
				GameObjectUtils.SetActive(_priorityJobImage.gameObject, isActive: false);
				return true;
			}
			bool flag = _room.Definition._hasQueue && _room.QueueLength == 0;
			RoomLogic component = _room.GetComponent<RoomLogic>();
			bool flag2 = component != null && !component.IsProjectAssigned();
			bool flag3 = !_room.Definition._allowQueueWarningStatusIcon;
			bool flag4 = _room.IsStaffed() || flag || flag2 || !_room.IsOpen || flag3;
			_room.RemainingStaffRequired(_requiredStaff);
			if (!flag4)
			{
				UpdateStaffIcons();
			}
			else
			{
				GameObjectUtils.SetActive(_doctorImage.gameObject, isActive: false);
				GameObjectUtils.SetActive(_nurseImage.gameObject, isActive: false);
				GameObjectUtils.SetActive(_assistantImage.gameObject, isActive: false);
				GameObjectUtils.SetActive(_janitorImage.gameObject, isActive: false);
				GameObjectUtils.SetActive(_itemRequiredImage.gameObject, isActive: false);
			}
			bool highPriorityJobs = _room.HighPriorityJobs;
			GameObjectUtils.SetActive(_priorityJobImage.gameObject, highPriorityJobs);
			if (highPriorityJobs || !flag4)
			{
				return true;
			}
			return false;
		}

		private bool UpdateRoomItemIcons()
		{
			_requiredStaff.Clear();
			RoomItemJobComponent component = _roomItem.GetComponent<RoomItemJobComponent>();
			if (component != null && component.Job != null && component.Job.GetStaff() == null)
			{
				_requiredStaff.Add(component.StaffRequired);
			}
			bool flag = _roomItem.QueueLength == 0;
			bool num = _requiredStaff.Count == 0 || flag;
			if (!num)
			{
				UpdateStaffIcons();
			}
			else
			{
				GameObjectUtils.SetActive(_doctorImage.gameObject, isActive: false);
				GameObjectUtils.SetActive(_nurseImage.gameObject, isActive: false);
				GameObjectUtils.SetActive(_assistantImage.gameObject, isActive: false);
				GameObjectUtils.SetActive(_janitorImage.gameObject, isActive: false);
				GameObjectUtils.SetActive(_itemRequiredImage.gameObject, isActive: false);
			}
			GameObjectUtils.SetActive(_priorityJobImage.gameObject, isActive: false);
			return !num;
		}

		private void UpdateStaffIcons()
		{
			bool isActive = false;
			bool isActive2 = false;
			bool isActive3 = false;
			bool isActive4 = false;
			foreach (StaffRequired item in _requiredStaff)
			{
				QualificationDefinition qualificationInstance = item.QualificationInstance;
				switch (item.Definition._type)
				{
				case StaffDefinition.Type.Doctor:
					isActive = true;
					SetQualificationIcon(qualificationInstance, _doctorQualificationImage);
					break;
				case StaffDefinition.Type.Nurse:
					isActive2 = true;
					SetQualificationIcon(qualificationInstance, _nurseQualificationImage);
					break;
				case StaffDefinition.Type.Assistant:
					isActive3 = true;
					SetQualificationIcon(qualificationInstance, _assistantQualificationImage);
					break;
				case StaffDefinition.Type.Janitor:
					isActive4 = true;
					SetQualificationIcon(qualificationInstance, _janitorQualificationImage);
					break;
				}
			}
			GameObjectUtils.SetActive(_doctorImage.gameObject, isActive);
			GameObjectUtils.SetActive(_nurseImage.gameObject, isActive2);
			GameObjectUtils.SetActive(_assistantImage.gameObject, isActive3);
			GameObjectUtils.SetActive(_janitorImage.gameObject, isActive4);
			GameObjectUtils.SetActive(_itemRequiredImage.gameObject, isActive: false);
		}

		private void SetQualificationIcon(QualificationDefinition qualification, Image qualificationImage)
		{
			if (qualification == null)
			{
				GameObjectUtils.SetActive(qualificationImage.gameObject, isActive: false);
				return;
			}
			qualificationImage.sprite = qualification.Icon;
			GameObjectUtils.SetActive(qualificationImage.gameObject, isActive: true);
		}

		public override bool HasTimedOut()
		{
			if (GetQueueLength() >= _level.HospitalPolicy.QueueWarningLength)
			{
				return false;
			}
			if (_roomItem != null)
			{
				RoomItemJobComponent component = _roomItem.GetComponent<RoomItemJobComponent>();
				if (component == null || component.Job == null)
				{
					return true;
				}
				return component.Job.GetStaff() != null;
			}
			if (_room == null)
			{
				return true;
			}
			if (_room.HighPriorityJobs)
			{
				return false;
			}
			if (_requiredStaff.Count != 0)
			{
				return false;
			}
			IRoomItemDefinition missing;
			return !_room.GetMissingRequiredItem(out missing);
		}
	}
}
