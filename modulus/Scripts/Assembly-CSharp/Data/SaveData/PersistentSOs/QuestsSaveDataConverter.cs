using System;

namespace Data.SaveData.PersistentSOs
{
	public class QuestsSaveDataConverter : SaveDataConverter<QuestsSaveData>
	{
		public QuestsSaveDataConverter()
			: base(2)
		{
		}

		public override Type GetPreviousVersion(int version)
		{
			return version switch
			{
				0 => typeof(QuestsSaveData_Version0), 
				1 => typeof(QuestsSaveData_Version1), 
				_ => null, 
			};
		}
	}
}
