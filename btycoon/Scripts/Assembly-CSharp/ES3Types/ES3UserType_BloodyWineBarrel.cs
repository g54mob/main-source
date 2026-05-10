using CTS;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using ES3Internal;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_BloodyWineBarrel : ES3ComponentType
	{
		public static ES3Type Instance;

		private Vector3 victimPosition = Vector3.zero;

		private Quaternion victimRotation = Quaternion.identity;

		public ES3UserType_BloodyWineBarrel()
			: base(typeof(BloodyWineBarrel))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			BloodyWineBarrel bloodyWineBarrel = (BloodyWineBarrel)obj;
			writer.WriteProperty("MachinePowerState", bloodyWineBarrel.MachinePowerState, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachinePowerState)));
			writer.WriteProperty("MachineProductionMode", bloodyWineBarrel.MachineProductionMode, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachineProductionMode)));
			writer.WriteProperty("Synced", bloodyWineBarrel.Syncing.IsSynced);
			if ((bool)bloodyWineBarrel.Victim)
			{
				writer.WriteProperty("Victim", bloodyWineBarrel.Victim, ES3.ReferenceMode.ByRef);
				writer.WriteProperty("VictimPosition", bloodyWineBarrel.Victim.transform.position);
				writer.WriteProperty("VictimRotation", bloodyWineBarrel.Victim.transform.rotation);
				writer.WriteProperty("Timer", bloodyWineBarrel.Timer);
				writer.WriteProperty("BagsTarget", bloodyWineBarrel.BloodBagsAmountTarget);
				writer.WriteProperty("Bags", bloodyWineBarrel.BloodBagsGenerated);
				writer.WritePrivateField("_forceStopSuck", bloodyWineBarrel);
				writer.WritePrivateField("_timerUI", bloodyWineBarrel);
				writer.WritePrivateField("_processDuration", bloodyWineBarrel);
				writer.WritePrivateField("_efficiencyTimer", bloodyWineBarrel);
				writer.WritePrivateField("_efficiencyInterval", bloodyWineBarrel);
			}
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			BloodyWineBarrel bloodyWineBarrel = (BloodyWineBarrel)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "MachinePowerState":
					bloodyWineBarrel.MachinePowerState = reader.Read<EMachinePowerState>();
					break;
				case "MachineProductionMode":
					bloodyWineBarrel.MachineProductionMode = reader.Read<EMachineProductionMode>();
					break;
				case "Victim":
				{
					Agent agent = reader.Read<Agent>();
					if ((bool)agent && !bloodyWineBarrel.Victim)
					{
						bloodyWineBarrel.SetVictim(agent);
						agent.ContextualFSM.SetStateStuck();
					}
					break;
				}
				case "VictimPosition":
					victimPosition = reader.Read<Vector3>();
					break;
				case "VictimRotation":
					victimRotation = reader.Read<Quaternion>();
					break;
				case "Timer":
					reader.SetPrivateField("Timer".ToBackingField(), reader.Read<float>(), bloodyWineBarrel);
					break;
				case "BagsTarget":
					reader.SetPrivateField("BloodBagsAmountTarget".ToBackingField(), reader.Read<int>(), bloodyWineBarrel);
					break;
				case "Bags":
					reader.SetPrivateField("BloodBagsGenerated".ToBackingField(), reader.Read<int>(), bloodyWineBarrel);
					break;
				case "_forceStopSuck":
					reader.SetPrivateField("_forceStopSuck", reader.Read<bool>(), bloodyWineBarrel);
					break;
				case "_timerUI":
					reader.SetPrivateField("_timerUI", reader.Read<float>(), bloodyWineBarrel);
					break;
				case "_processDuration":
					reader.SetPrivateField("_processDuration", reader.Read<float>(), bloodyWineBarrel);
					break;
				case "_efficiencyTimer":
					reader.SetPrivateField("_efficiencyTimer", reader.Read<float>(), bloodyWineBarrel);
					break;
				case "_efficiencyInterval":
					reader.SetPrivateField("_efficiencyInterval", reader.Read<float>(), bloodyWineBarrel);
					break;
				case "Synced":
					bloodyWineBarrel.Syncing?.SetSyncing(reader.Read<bool>());
					break;
				default:
					reader.Skip();
					break;
				}
			}
			bloodyWineBarrel.ResetSave();
		}
	}
}
