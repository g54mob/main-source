using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class GeneralSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public bool StartedTutorial;

		public bool SupportersEditionModal;

		public bool GDPRModal;

		public GeneralSaveData(bool startedTutorial, bool supportersEditionModal, bool gDPRModal)
			: base(0)
		{
			StartedTutorial = startedTutorial;
			SupportersEditionModal = supportersEditionModal;
			GDPRModal = gDPRModal;
		}
	}
}
