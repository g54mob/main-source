using CTS;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_BloodyRad : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_BloodyRad()
			: base(typeof(BloodyRad))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			BloodyRad bloodyRad = (BloodyRad)obj;
			writer.WriteProperty("MachinePowerState", bloodyRad.MachinePowerState, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachinePowerState)));
			writer.WriteProperty("MachineProductionMode", bloodyRad.MachineProductionMode, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachineProductionMode)));
			writer.WriteProperty("Synced", bloodyRad.Syncing.IsSynced);
			if ((bool)bloodyRad.Victim)
			{
				writer.WriteProperty("Victim", bloodyRad.Victim, ES3.ReferenceMode.ByRef);
				writer.WriteProperty("Timer", bloodyRad.Timer);
				writer.WriteProperty("BagsTarget", bloodyRad.BloodBagsAmountTarget);
				writer.WriteProperty("Bags", bloodyRad.BloodBagsGenerated);
				writer.WritePrivateField("_forceStopSuck", bloodyRad);
				writer.WritePrivateField("_timerUI", bloodyRad);
				writer.WritePrivateField("_processDuration", bloodyRad);
				writer.WritePrivateField("_efficiencyTimer", bloodyRad);
				writer.WritePrivateField("_efficiencyInterval", bloodyRad);
				writer.WritePrivateField("_victimIsInstalled", bloodyRad);
			}
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			BloodyRad bloodyRad = (BloodyRad)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "MachinePowerState":
					bloodyRad.MachinePowerState = reader.Read<EMachinePowerState>();
					break;
				case "MachineProductionMode":
					reader.SetPrivateField("MachineProductionMode".ToBackingField(), reader.Read<EMachineProductionMode>(), bloodyRad);
					break;
				case "Victim":
				{
					Agent agent = reader.Read<Agent>();
					if ((bool)agent && !bloodyRad.Victim)
					{
						bloodyRad.SetVictim(agent);
						agent.ContextualFSM.SetStateStuck();
						agent.transform.SetPositionAndRotation(bloodyRad.LoadedPosition.transform.position, bloodyRad.LoadedPosition.transform.rotation);
						agent.SetVisualActive(value: false);
					}
					break;
				}
				case "Timer":
					reader.SetPrivateField("Timer".ToBackingField(), reader.Read<float>(), bloodyRad);
					break;
				case "BagsTarget":
					reader.SetPrivateField("BloodBagsAmountTarget".ToBackingField(), reader.Read<int>(), bloodyRad);
					break;
				case "Bags":
					reader.SetPrivateField("BloodBagsGenerated".ToBackingField(), reader.Read<int>(), bloodyRad);
					break;
				case "_forceStopSuck":
					reader.SetPrivateField("_forceStopSuck", reader.Read<bool>(), bloodyRad);
					break;
				case "_timerUI":
					reader.SetPrivateField("_timerUI", reader.Read<float>(), bloodyRad);
					break;
				case "_processDuration":
					reader.SetPrivateField("_processDuration", reader.Read<float>(), bloodyRad);
					break;
				case "_efficiencyTimer":
					reader.SetPrivateField("_efficiencyTimer", reader.Read<float>(), bloodyRad);
					break;
				case "_efficiencyInterval":
					reader.SetPrivateField("_efficiencyInterval", reader.Read<float>(), bloodyRad);
					break;
				case "Synced":
					bloodyRad.Syncing?.SetSyncing(reader.Read<bool>());
					break;
				case "_victimIsInstalled":
					bloodyRad = (BloodyRad)reader.SetPrivateField("_victimIsInstalled", reader.Read<bool>(), bloodyRad);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			if ((bool)bloodyRad.Victim)
			{
				bloodyRad.MachineUI.DisplayOrHide(_value: true);
			}
			if (bloodyRad.BloodBagsGenerated >= bloodyRad.BloodBagsAmountTarget)
			{
				bloodyRad.MachineUI.RunFillArea(1f);
			}
			else if (bloodyRad.MachinePowerState == EMachinePowerState.Off)
			{
				bloodyRad.MachineUI.RunFillArea((float)bloodyRad.BloodBagsGenerated / (float)bloodyRad.BloodBagsAmountTarget);
			}
		}
	}
}
