using System;

namespace TH20
{
	public class NotificationStaffPromotion : NotificationStaff
	{
		public int NewSalary { private get; set; }

		public NotificationStaffPromotion(NotificationMessages.Definition definition, Staff staff)
			: base(definition, null, staff)
		{
			_level.ObjectiveEvents.OnGameEvent.InvokeSafe(ObjectiveGameEvent.StaffPromotion);
		}

		protected override void RegisterEvents()
		{
			base.RegisterEvents();
			_delegate = OnDecision;
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffPromoted = (Action<Staff>)System.Delegate.Combine(characterEvents.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
		}

		protected override void UnregisterEvents()
		{
			base.UnregisterEvents();
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnStaffPromoted = (Action<Staff>)System.Delegate.Remove(characterEvents.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
		}

		public override string GetMessageText()
		{
			int num = base.Staff.Rank + 1;
			if (num >= 5)
			{
				num = 4;
			}
			Character.Sex gender = base.Staff.Gender;
			StaffRank staffRank = base.Staff.Definition._rank[num];
			return base.Definition.GetTextStringForGender(gender).Replace("{[NAME]}", base.Staff.Name).Replace("{[RANK]}", (base.Staff.RankDefinition != null) ? base.Staff.RankDefinition.GetTitleLocalised(gender).Translation : "")
				.Replace("{[NEXTRANK]}", staffRank.GetTitleLocalised(gender).Translation);
		}

		private void OnStaffPromoted(Staff staff)
		{
			if (staff == base.Staff)
			{
				_level.Notifications.Remove(this);
			}
		}

		private void OnDecision(int choice)
		{
			if (choice == 0)
			{
				_level.CharacterEvents.OnStaffPromote.InvokeSafe(base.Staff, NewSalary);
			}
		}
	}
}
