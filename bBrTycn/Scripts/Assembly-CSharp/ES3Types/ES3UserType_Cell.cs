using CTS;
using CTS.BBT.AI;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_Cell : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Cell()
			: base(typeof(Cell))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Cell cell = (Cell)obj;
			writer.WriteProperty("Synced", cell.Syncing.IsSynced);
			if ((bool)cell.Victim)
			{
				writer.WriteProperty("Victim", cell.Victim, ES3.ReferenceMode.ByRef);
			}
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Cell cell = (Cell)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "Victim"))
				{
					if (property == "Synced")
					{
						cell.Syncing?.SetSyncing(reader.Read<bool>());
					}
					else
					{
						reader.Skip();
					}
					continue;
				}
				Agent agent = reader.Read<Agent>();
				if ((bool)agent && !cell.Victim)
				{
					cell.SetVictim(agent);
					agent.ContextualFSM.SetStateStuck();
					agent.transform.SetPositionAndRotation(cell.LoadedPosition.transform.position, cell.LoadedPosition.transform.rotation);
				}
			}
			cell.doorStatus = EDoorStatus.Closed;
		}
	}
}
