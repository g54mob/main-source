using CTS;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_BloodDistiller : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_BloodDistiller()
			: base(typeof(BloodDistiller))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			BloodDistiller bloodDistiller = (BloodDistiller)obj;
			writer.WriteProperty("MachinePowerState", bloodDistiller.MachinePowerState, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachinePowerState)));
			writer.WriteProperty("MachineProductionMode", bloodDistiller.MachineProductionMode, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachineProductionMode)));
			writer.WritePrivateField("_selfStorageStack", bloodDistiller);
			writer.WriteProperty("Synced", bloodDistiller.Syncing.IsSynced);
			if ((bool)bloodDistiller.Victim)
			{
				writer.WriteProperty("Victim", bloodDistiller.Victim, ES3.ReferenceMode.ByRef);
				writer.WriteProperty("Timer", bloodDistiller.Timer);
				writer.WriteProperty("BagsTarget", bloodDistiller.BloodBagsAmountTarget);
				writer.WriteProperty("Bags", bloodDistiller.BloodBagsGenerated);
				writer.WritePrivateField("_forceStopSuck", bloodDistiller);
				writer.WritePrivateField("_timerUI", bloodDistiller);
				writer.WritePrivateField("_processDuration", bloodDistiller);
				writer.WritePrivateField("_efficiencyTimer", bloodDistiller);
				writer.WritePrivateField("_efficiencyInterval", bloodDistiller);
			}
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			BloodDistiller bloodDistiller = (BloodDistiller)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "MachinePowerState":
					bloodDistiller.MachinePowerState = reader.Read<EMachinePowerState>();
					break;
				case "MachineProductionMode":
					reader.SetPrivateField("MachineProductionMode".ToBackingField(), reader.Read<EMachineProductionMode>(), bloodDistiller);
					break;
				case "_selfStorageStack":
					reader.SetPrivateField("_selfStorageStack", reader.Read<StockStack>(), bloodDistiller);
					break;
				case "Victim":
				{
					Agent agent = reader.Read<Agent>();
					if ((bool)agent && !bloodDistiller.Victim)
					{
						bloodDistiller.SetVictim(agent);
						agent.ContextualFSM.SetStateStuck();
						agent.transform.SetPositionAndRotation(bloodDistiller.LoadedPosition.transform.position, bloodDistiller.LoadedPosition.transform.rotation);
						agent.SetVisualActive(value: false);
					}
					break;
				}
				case "Timer":
					reader.SetPrivateField("Timer".ToBackingField(), reader.Read<float>(), bloodDistiller);
					break;
				case "BagsTarget":
					reader.SetPrivateField("BloodBagsAmountTarget".ToBackingField(), reader.Read<int>(), bloodDistiller);
					break;
				case "Bags":
					reader.SetPrivateField("BloodBagsGenerated".ToBackingField(), reader.Read<int>(), bloodDistiller);
					break;
				case "_forceStopSuck":
					reader.SetPrivateField("_forceStopSuck", reader.Read<bool>(), bloodDistiller);
					break;
				case "_timerUI":
					reader.SetPrivateField("_timerUI", reader.Read<float>(), bloodDistiller);
					break;
				case "_processDuration":
					reader.SetPrivateField("_processDuration", reader.Read<float>(), bloodDistiller);
					break;
				case "_efficiencyTimer":
					reader.SetPrivateField("_efficiencyTimer", reader.Read<float>(), bloodDistiller);
					break;
				case "_efficiencyInterval":
					reader.SetPrivateField("_efficiencyInterval", reader.Read<float>(), bloodDistiller);
					break;
				case "Synced":
					bloodDistiller.Syncing?.SetSyncing(reader.Read<bool>());
					break;
				default:
					reader.Skip();
					break;
				}
			}
			if (SaveManager.CurrentSaveState != SaveManager.ESaveState.LoadPost || !bloodDistiller.Victim)
			{
				return;
			}
			bloodDistiller.MachineUI.DisplayOrHide(_value: true);
			if (bloodDistiller.BloodBagsGenerated >= bloodDistiller.BloodBagsAmountTarget)
			{
				bloodDistiller.CreateUnloadChore();
				bloodDistiller.MachineUI.RunFillArea(1f);
				return;
			}
			bloodDistiller.DestroyChore();
			if (bloodDistiller.MachinePowerState == EMachinePowerState.On)
			{
				bloodDistiller.StopAllCoroutines();
				bloodDistiller.StartCoroutine(bloodDistiller.GenerateBlood(bloodDistiller.Timer));
			}
			else
			{
				bloodDistiller.MachineUI.RunFillArea((float)bloodDistiller.BloodBagsGenerated / (float)bloodDistiller.BloodBagsAmountTarget);
			}
		}
	}
}
