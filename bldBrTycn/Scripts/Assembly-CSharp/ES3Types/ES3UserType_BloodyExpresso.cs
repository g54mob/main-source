using CTS;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_damagesApplied", "_totalDamages", "_victimHealth", "_currentChore", "MachinePowerState", "MachineProductionMode", "_victim", "_isProcessing" })]
	public class ES3UserType_BloodyExpresso : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_BloodyExpresso()
			: base(typeof(BloodyExpresso))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			BloodyExpresso bloodyExpresso = (BloodyExpresso)obj;
			writer.WritePrivateField("_damagesApplied", bloodyExpresso);
			writer.WritePrivateField("_totalDamages", bloodyExpresso);
			writer.WritePrivateField("_victimHealth", bloodyExpresso);
			writer.WritePrivateField("_currentChore", bloodyExpresso);
			writer.WriteProperty("MachinePowerState", bloodyExpresso.MachinePowerState, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachinePowerState)));
			writer.WriteProperty("MachineProductionMode", bloodyExpresso.MachineProductionMode, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachineProductionMode)));
			writer.WritePrivateFieldByRef("_victim", bloodyExpresso);
			writer.WritePrivateField("_isProcessing", bloodyExpresso);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			BloodyExpresso bloodyExpresso = (BloodyExpresso)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_damagesApplied":
					bloodyExpresso = (BloodyExpresso)reader.SetPrivateField("_damagesApplied", reader.Read<int>(), bloodyExpresso);
					break;
				case "_totalDamages":
					bloodyExpresso = (BloodyExpresso)reader.SetPrivateField("_totalDamages", reader.Read<int>(), bloodyExpresso);
					break;
				case "_victimHealth":
					bloodyExpresso = (BloodyExpresso)reader.SetPrivateField("_victimHealth", reader.Read<int>(), bloodyExpresso);
					break;
				case "_currentChore":
					bloodyExpresso = (BloodyExpresso)reader.SetPrivateField("_currentChore", reader.Read<WorkerChore>(), bloodyExpresso);
					break;
				case "MachinePowerState":
					bloodyExpresso.MachinePowerState = reader.Read<EMachinePowerState>();
					break;
				case "MachineProductionMode":
					reader.SetPrivateField("MachineProductionMode".ToBackingField(), reader.Read<EMachineProductionMode>(), bloodyExpresso);
					break;
				case "_victim":
					bloodyExpresso = (BloodyExpresso)reader.SetPrivateField("_victim", reader.Read<Agent>(), bloodyExpresso);
					break;
				case "_isProcessing":
					bloodyExpresso = (BloodyExpresso)reader.SetPrivateField("_isProcessing", reader.Read<bool>(), bloodyExpresso);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
