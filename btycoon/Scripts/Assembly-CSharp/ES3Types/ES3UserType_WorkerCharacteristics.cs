using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "<WorkerType>k__BackingField", "<SpecializedStat>k__BackingField" })]
	public class ES3UserType_WorkerCharacteristics : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_WorkerCharacteristics()
			: base(typeof(WorkerCharacteristics))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			WorkerCharacteristics objectContainingField = (WorkerCharacteristics)obj;
			writer.WritePrivateField("<WorkerType>k__BackingField", objectContainingField);
			writer.WritePrivateField("<SpecializedStat>k__BackingField", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			WorkerCharacteristics objectContainingField = (WorkerCharacteristics)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "<WorkerType>k__BackingField"))
				{
					if (property == "<SpecializedStat>k__BackingField")
					{
						objectContainingField = (WorkerCharacteristics)reader.SetPrivateField("<SpecializedStat>k__BackingField", reader.Read<EAgentStatistics>(), objectContainingField);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					objectContainingField = (WorkerCharacteristics)reader.SetPrivateField("<WorkerType>k__BackingField", reader.Read<EWorkerType>(), objectContainingField);
				}
			}
		}
	}
}
