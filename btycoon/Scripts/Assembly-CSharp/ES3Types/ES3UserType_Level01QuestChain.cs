using CTS;
using CTS.BBT.AI;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "<FirstWorker>k__BackingField", "<PreviousInhabitant>k__BackingField", "_lastQuestSucceeded" })]
	public class ES3UserType_Level01QuestChain : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Level01QuestChain()
			: base(typeof(Level01QuestChain))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Level01QuestChain level01QuestChain = (Level01QuestChain)obj;
			writer.WritePrivateFieldByRef("<FirstWorker>k__BackingField", level01QuestChain);
			writer.WritePrivateFieldByRef("<PreviousInhabitant>k__BackingField", level01QuestChain);
			writer.WriteProperty("IsOpenButtonLocked", level01QuestChain.OpenBarButtonLocker.Locked);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Level01QuestChain level01QuestChain = (Level01QuestChain)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "<FirstWorker>k__BackingField":
					reader.SetPrivateField("<FirstWorker>k__BackingField", reader.Read<Worker>(), level01QuestChain);
					break;
				case "<PreviousInhabitant>k__BackingField":
					reader.SetPrivateField("<PreviousInhabitant>k__BackingField", reader.Read<Customer>(), level01QuestChain);
					break;
				case "IsOpenButtonLocked":
					if (reader.Read<bool>())
					{
						level01QuestChain.OpenBarButtonLocker.Lock();
					}
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
