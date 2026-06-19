using System;

namespace TH20.UI
{
	[Serializable]
	public class InfoMessageSourceCloseToDeath : InfoMessageSource
	{
		public override string GetMessage(Level level)
		{
			int num = 0;
			float patientLowHealth = GameAlgorithms.Config.PatientLowHealth;
			foreach (Patient patient in level.CharacterManager.Patients)
			{
				if (patient.Health.Value() < patientLowHealth)
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
