using CTS;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using ES3Internal;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_BloodyShaker : ES3ComponentType
	{
		public static ES3Type Instance;

		private Vector3 victimPosition = Vector3.zero;

		private Quaternion victimRotation = Quaternion.identity;

		public ES3UserType_BloodyShaker()
			: base(typeof(BloodyShaker))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			BloodyShaker bloodyShaker = (BloodyShaker)obj;
			writer.WriteProperty("MachinePowerState", bloodyShaker.MachinePowerState, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachinePowerState)));
			writer.WriteProperty("MachineProductionMode", bloodyShaker.MachineProductionMode, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachineProductionMode)));
			writer.WriteProperty("Synced", bloodyShaker.Syncing.IsSynced);
			if ((bool)bloodyShaker.Victim)
			{
				writer.WriteProperty("Victim", bloodyShaker.Victim, ES3.ReferenceMode.ByRef);
				writer.WriteProperty("VictimPosition", bloodyShaker.Victim.transform.position);
				writer.WriteProperty("VictimRotation", bloodyShaker.Victim.transform.rotation);
				writer.WriteProperty("Timer", bloodyShaker.Timer);
				writer.WriteProperty("BagsTarget", bloodyShaker.BloodBagsAmountTarget);
				writer.WriteProperty("Bags", bloodyShaker.BloodBagsGenerated);
				writer.WritePrivateField("_forceStopSuck", bloodyShaker);
				writer.WritePrivateField("_timerUI", bloodyShaker);
				writer.WritePrivateField("_processDuration", bloodyShaker);
				writer.WritePrivateField("_efficiencyTimer", bloodyShaker);
				writer.WritePrivateField("_efficiencyInterval", bloodyShaker);
			}
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			BloodyShaker bloodyShaker = (BloodyShaker)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "MachinePowerState":
					bloodyShaker.MachinePowerState = reader.Read<EMachinePowerState>();
					break;
				case "MachineProductionMode":
					bloodyShaker.MachineProductionMode = reader.Read<EMachineProductionMode>();
					break;
				case "Victim":
				{
					Agent agent = reader.Read<Agent>();
					if ((bool)agent && !bloodyShaker.Victim)
					{
						bloodyShaker.SetVictim(agent);
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
					reader.SetPrivateField("Timer".ToBackingField(), reader.Read<float>(), bloodyShaker);
					break;
				case "BagsTarget":
					reader.SetPrivateField("BloodBagsAmountTarget".ToBackingField(), reader.Read<int>(), bloodyShaker);
					break;
				case "Bags":
					reader.SetPrivateField("BloodBagsGenerated".ToBackingField(), reader.Read<int>(), bloodyShaker);
					break;
				case "_forceStopSuck":
					reader.SetPrivateField("_forceStopSuck", reader.Read<bool>(), bloodyShaker);
					break;
				case "_timerUI":
					reader.SetPrivateField("_timerUI", reader.Read<float>(), bloodyShaker);
					break;
				case "_processDuration":
					reader.SetPrivateField("_processDuration", reader.Read<float>(), bloodyShaker);
					break;
				case "_efficiencyTimer":
					reader.SetPrivateField("_efficiencyTimer", reader.Read<float>(), bloodyShaker);
					break;
				case "_efficiencyInterval":
					reader.SetPrivateField("_efficiencyInterval", reader.Read<float>(), bloodyShaker);
					break;
				case "Synced":
					bloodyShaker.Syncing?.SetSyncing(reader.Read<bool>());
					break;
				default:
					reader.Skip();
					break;
				}
			}
			bloodyShaker.VictimPositionLoaded = victimPosition;
			bloodyShaker.VictimRotationLoaded = victimRotation;
		}
	}
}
