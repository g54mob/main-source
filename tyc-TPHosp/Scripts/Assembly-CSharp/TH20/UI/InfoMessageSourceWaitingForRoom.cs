using System;

namespace TH20.UI
{
	[Serializable]
	public class InfoMessageSourceWaitingForRoom : InfoMessageSource
	{
		public override string GetMessage(Level level)
		{
			int num = 0;
			foreach (Patient patient in level.CharacterManager.Patients)
			{
				if (patient.GetComponent<WaitForRoomToBeBuiltComponent>() != null)
				{
					num++;
				}
			}
			string text = _localisedString.Translation;
			LocalisationParams.Set("COUNT", num);
			LocalisationParams.Localise(ref text);
			return text;
		}
	}
}
