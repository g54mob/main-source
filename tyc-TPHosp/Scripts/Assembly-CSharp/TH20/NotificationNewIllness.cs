namespace TH20
{
	public class NotificationNewIllness : NotificationMessage
	{
		private IllnessDefinition _illness;

		public NotificationNewIllness(NotificationMessages.Definition definition, IllnessDefinition illness, Level level)
			: base(definition, level)
		{
			_illness = illness;
		}

		public override string GetTitleText()
		{
			return base.Definition.GetTitleString().Replace("{[ILLNESS]}", _illness.Name.Translation);
		}

		public override string GetTooltipText()
		{
			return GetTitleText();
		}

		public override string GetMessageText()
		{
			string textString = base.Definition.GetTextString();
			textString = textString.Replace("{[ILLNESS]}", _illness.Name.Translation);
			textString = textString.Replace("{[DESCRIPTION]}", _illness.Description.Translation);
			RoomDefinition treatmentRoom = _illness.GetTreatmentRoom(null, _level.ResearchManager);
			if (treatmentRoom != null)
			{
				textString = textString.Replace("{[ROOM]}", treatmentRoom.GetLocalisedName());
			}
			return textString;
		}

		public override Character GetCharacter()
		{
			return null;
		}
	}
}
