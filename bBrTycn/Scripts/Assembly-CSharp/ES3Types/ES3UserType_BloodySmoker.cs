using CTS;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using ES3Internal;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_BloodySmoker : ES3ComponentType
	{
		public static ES3Type Instance;

		private Vector3 victimPosition = Vector3.zero;

		private Quaternion victimRotation = Quaternion.identity;

		public ES3UserType_BloodySmoker()
			: base(typeof(BloodySmoker))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			BloodySmoker bloodySmoker = (BloodySmoker)obj;
			writer.WriteProperty("MachinePowerState", bloodySmoker.MachinePowerState, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachinePowerState)));
			writer.WriteProperty("MachineProductionMode", bloodySmoker.MachineProductionMode, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachineProductionMode)));
			writer.WriteProperty("Synced", bloodySmoker.Syncing.IsSynced);
			if ((bool)bloodySmoker.Victim)
			{
				writer.WriteProperty("Victim", bloodySmoker.Victim, ES3.ReferenceMode.ByRef);
				writer.WriteProperty("VictimPosition", bloodySmoker.Victim.transform.position);
				writer.WriteProperty("VictimRotation", bloodySmoker.Victim.transform.rotation);
				writer.WriteProperty("Timer", bloodySmoker.Timer);
				writer.WriteProperty("BagsTarget", bloodySmoker.BloodBagsAmountTarget);
				writer.WriteProperty("Bags", bloodySmoker.BloodBagsGenerated);
				writer.WritePrivateField("_forceStopSuck", bloodySmoker);
				writer.WritePrivateField("_timerUI", bloodySmoker);
				writer.WritePrivateField("_processDuration", bloodySmoker);
				writer.WritePrivateField("_efficiencyTimer", bloodySmoker);
				writer.WritePrivateField("_efficiencyInterval", bloodySmoker);
				writer.WritePrivateField("_rotorRotationYValue", bloodySmoker);
			}
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			BloodySmoker bloodySmoker = (BloodySmoker)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "MachinePowerState":
					bloodySmoker.MachinePowerState = reader.Read<EMachinePowerState>();
					break;
				case "MachineProductionMode":
					bloodySmoker.MachineProductionMode = reader.Read<EMachineProductionMode>();
					break;
				case "Victim":
				{
					Agent agent = reader.Read<Agent>();
					if ((bool)agent && !bloodySmoker.Victim)
					{
						bloodySmoker.SetVictim(agent);
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
					reader.SetPrivateField("Timer".ToBackingField(), reader.Read<float>(), bloodySmoker);
					break;
				case "BagsTarget":
					reader.SetPrivateField("BloodBagsAmountTarget".ToBackingField(), reader.Read<int>(), bloodySmoker);
					break;
				case "Bags":
					reader.SetPrivateField("BloodBagsGenerated".ToBackingField(), reader.Read<int>(), bloodySmoker);
					break;
				case "_forceStopSuck":
					reader.SetPrivateField("_forceStopSuck", reader.Read<bool>(), bloodySmoker);
					break;
				case "_timerUI":
					reader.SetPrivateField("_timerUI", reader.Read<float>(), bloodySmoker);
					break;
				case "_processDuration":
					reader.SetPrivateField("_processDuration", reader.Read<float>(), bloodySmoker);
					break;
				case "_efficiencyTimer":
					reader.SetPrivateField("_efficiencyTimer", reader.Read<float>(), bloodySmoker);
					break;
				case "_efficiencyInterval":
					reader.SetPrivateField("_efficiencyInterval", reader.Read<float>(), bloodySmoker);
					break;
				case "_rotorRotationYValue":
					reader.SetPrivateField("_rotorRotationYValue", reader.Read<float>(), bloodySmoker);
					break;
				case "Synced":
					bloodySmoker.Syncing?.SetSyncing(reader.Read<bool>());
					break;
				default:
					reader.Skip();
					break;
				}
			}
			bloodySmoker.VictimPositionLoaded = victimPosition;
			bloodySmoker.VictimRotationLoaded = victimRotation;
		}
	}
}
