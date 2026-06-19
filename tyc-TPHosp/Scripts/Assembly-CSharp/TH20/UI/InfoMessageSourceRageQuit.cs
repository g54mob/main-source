using System;

namespace TH20.UI
{
	[Serializable]
	public class InfoMessageSourceRageQuit : InfoMessageSource
	{
		public override string GetMessage(Level level)
		{
			int num = 0;
			float patientLowHappiness = GameAlgorithms.Config.PatientLowHappiness;
			foreach (Patient patient in level.CharacterManager.Patients)
			{
				if (patient.Happiness.Value() < patientLowHappiness)
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
