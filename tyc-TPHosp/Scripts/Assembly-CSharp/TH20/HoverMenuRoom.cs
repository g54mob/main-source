using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HoverMenuRoom : HoverMenuRoomBase
	{
		[SerializeField]
		private GameObject _panel;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private TMP_Text _staffText;

		[SerializeField]
		private TMP_Text _stateText;

		public override void Setup(Room room, Level level)
		{
			base.Setup(room, level);
			_panel.SetActive(value: false);
		}

		protected override void Update()
		{
			base.Update();
			_name.text = _room.Definition.GetLocalisedName();
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
			string text = ScriptLocalization.Menu.Hover_Room_QueueLength_CS.Replace("{[LENGTH]}", _room.QueueLength.ToString());
			if (_room.IsOpen)
			{
				text = text + "\n" + ScriptLocalization.Menu.Hover_Room_Closed_CS;
			}
			_stateText.text = text;
			if (_room.RequiredStaffAssigned())
			{
				_panel.SetActive(value: false);
			}
			_room.ShowQueuePositions();
			foreach (RoomItem item3 in _room.FloorPlan.Items)
			{
				ResearchProjectComponent component = item3.GetComponent<ResearchProjectComponent>();
				if (component != null && component.Project == null)
				{
					base.Level.StatusIconManager.ShowStatusIcon(item3, StatusIcon.Type.AvailableProject);
					continue;
				}
				MarketingCampaignComponent component2 = item3.GetComponent<MarketingCampaignComponent>();
				if (component2 != null && component2.ActiveCampaign == null)
				{
					base.Level.StatusIconManager.ShowStatusIcon(item3, StatusIcon.Type.AvailableProject);
				}
				else if (item3.GetComponent<RoomItemTrainingLecternComponent>() != null)
				{
					RoomLogicTrainingRoom component3 = _room.GetComponent<RoomLogicTrainingRoom>();
					if (component3 != null && component3.IsAvailable)
					{
						base.Level.StatusIconManager.ShowStatusIcon(item3, StatusIcon.Type.AvailableProject);
					}
				}
			}
		}
	}
}
