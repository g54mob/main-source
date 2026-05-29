using CTS;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_BloodyTeaBag : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_BloodyTeaBag()
			: base(typeof(BloodyTeaBag))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			BloodyTeaBag bloodyTeaBag = (BloodyTeaBag)obj;
			writer.WriteProperty("MachinePowerState", bloodyTeaBag.MachinePowerState, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachinePowerState)));
			writer.WriteProperty("MachineProductionMode", bloodyTeaBag.MachineProductionMode, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachineProductionMode)));
			writer.WriteProperty("Synced", bloodyTeaBag.Syncing.IsSynced);
			if ((bool)bloodyTeaBag.Victim)
			{
				writer.WriteProperty("Victim", bloodyTeaBag.Victim, ES3.ReferenceMode.ByRef);
				writer.WriteProperty("Timer", bloodyTeaBag.Timer);
				writer.WriteProperty("BagsTarget", bloodyTeaBag.BloodBagsAmountTarget);
				writer.WriteProperty("Bags", bloodyTeaBag.BloodBagsGenerated);
				writer.WritePrivateField("_forceStopSuck", bloodyTeaBag);
				writer.WritePrivateField("_timerUI", bloodyTeaBag);
				writer.WritePrivateField("_processDuration", bloodyTeaBag);
				writer.WritePrivateField("_efficiencyTimer", bloodyTeaBag);
				writer.WritePrivateField("_efficiencyInterval", bloodyTeaBag);
				writer.WritePrivateField("_victimIsInstalled", bloodyTeaBag);
			}
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			BloodyTeaBag bloodyTeaBag = (BloodyTeaBag)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "MachinePowerState":
					bloodyTeaBag.MachinePowerState = reader.Read<EMachinePowerState>();
					break;
				case "MachineProductionMode":
					reader.SetPrivateField("MachineProductionMode".ToBackingField(), reader.Read<EMachineProductionMode>(), bloodyTeaBag);
					break;
				case "Victim":
				{
					Agent agent = reader.Read<Agent>();
					if ((bool)agent && !bloodyTeaBag.Victim)
					{
						bloodyTeaBag.SetVictim(agent);
						agent.ContextualFSM.SetStateStuck();
						agent.transform.SetPositionAndRotation(bloodyTeaBag.LoadedPosition.transform.position, bloodyTeaBag.LoadedPosition.transform.rotation);
						agent.SetVisualActive(value: false);
					}
					break;
				}
				case "Timer":
					reader.SetPrivateField("Timer".ToBackingField(), reader.Read<float>(), bloodyTeaBag);
					break;
				case "BagsTarget":
					reader.SetPrivateField("BloodBagsAmountTarget".ToBackingField(), reader.Read<int>(), bloodyTeaBag);
					break;
				case "Bags":
					reader.SetPrivateField("BloodBagsGenerated".ToBackingField(), reader.Read<int>(), bloodyTeaBag);
					break;
				case "_forceStopSuck":
					reader.SetPrivateField("_forceStopSuck", reader.Read<bool>(), bloodyTeaBag);
					break;
				case "_timerUI":
					reader.SetPrivateField("_timerUI", reader.Read<float>(), bloodyTeaBag);
					break;
				case "_processDuration":
					reader.SetPrivateField("_processDuration", reader.Read<float>(), bloodyTeaBag);
					break;
				case "_efficiencyTimer":
					reader.SetPrivateField("_efficiencyTimer", reader.Read<float>(), bloodyTeaBag);
					break;
				case "_efficiencyInterval":
					reader.SetPrivateField("_efficiencyInterval", reader.Read<float>(), bloodyTeaBag);
					break;
				case "Synced":
					bloodyTeaBag.Syncing?.SetSyncing(reader.Read<bool>());
					break;
				case "_victimIsInstalled":
					bloodyTeaBag = (BloodyTeaBag)reader.SetPrivateField("_victimIsInstalled", reader.Read<bool>(), bloodyTeaBag);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			if ((bool)bloodyTeaBag.Victim)
			{
				bloodyTeaBag.MachineUI.DisplayOrHide(_value: true);
				bloodyTeaBag.Victim.Animator.StartLoop(AgentAnim.BloodyTeaBagCustomerIdle);
			}
			if (bloodyTeaBag.BloodBagsGenerated >= bloodyTeaBag.BloodBagsAmountTarget)
			{
				bloodyTeaBag.MachineUI.RunFillArea(1f);
			}
			else if (bloodyTeaBag.MachinePowerState == EMachinePowerState.Off)
			{
				bloodyTeaBag.MachineUI.RunFillArea((float)bloodyTeaBag.BloodBagsGenerated / (float)bloodyTeaBag.BloodBagsAmountTarget);
			}
		}
	}
}
