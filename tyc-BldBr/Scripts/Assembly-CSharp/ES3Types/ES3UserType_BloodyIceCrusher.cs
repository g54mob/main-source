using CTS;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_BloodyIceCrusher : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_BloodyIceCrusher()
			: base(typeof(BloodyIceCrusher))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			BloodyIceCrusher bloodyIceCrusher = (BloodyIceCrusher)obj;
			writer.WriteProperty("MachinePowerState", bloodyIceCrusher.MachinePowerState, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachinePowerState)));
			writer.WriteProperty("MachineProductionMode", bloodyIceCrusher.MachineProductionMode, ES3TypeMgr.GetOrCreateES3Type(typeof(EMachineProductionMode)));
			writer.WriteProperty("Synced", bloodyIceCrusher.Syncing.IsSynced);
			if ((bool)bloodyIceCrusher.Victim)
			{
				writer.WriteProperty("Victim", bloodyIceCrusher.Victim, ES3.ReferenceMode.ByRef);
				writer.WriteProperty("Timer", bloodyIceCrusher.Timer);
				writer.WriteProperty("BagsTarget", bloodyIceCrusher.BloodBagsAmountTarget);
				writer.WriteProperty("Bags", bloodyIceCrusher.BloodBagsGenerated);
				writer.WritePrivateField("_forceStopSuck", bloodyIceCrusher);
				writer.WritePrivateField("_timerUI", bloodyIceCrusher);
				writer.WritePrivateField("_processDuration", bloodyIceCrusher);
				writer.WritePrivateField("_efficiencyTimer", bloodyIceCrusher);
				writer.WritePrivateField("_efficiencyInterval", bloodyIceCrusher);
			}
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			BloodyIceCrusher bloodyIceCrusher = (BloodyIceCrusher)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "MachinePowerState":
					bloodyIceCrusher.MachinePowerState = reader.Read<EMachinePowerState>();
					break;
				case "MachineProductionMode":
					reader.SetPrivateField("MachineProductionMode".ToBackingField(), reader.Read<EMachineProductionMode>(), bloodyIceCrusher);
					break;
				case "Victim":
				{
					Agent agent = reader.Read<Agent>();
					if ((bool)agent && !bloodyIceCrusher.Victim)
					{
						bloodyIceCrusher.SetVictim(agent);
						agent.ContextualFSM.SetStateStuck();
						agent.transform.SetPositionAndRotation(bloodyIceCrusher.LoadedPosition.transform.position, bloodyIceCrusher.LoadedPosition.transform.rotation);
						agent.Animator.PlayPunctual(bloodyIceCrusher.FrozenAnimations.GetRandom());
					}
					break;
				}
				case "Timer":
					reader.SetPrivateField("Timer".ToBackingField(), reader.Read<float>(), bloodyIceCrusher);
					break;
				case "BagsTarget":
					reader.SetPrivateField("BloodBagsAmountTarget".ToBackingField(), reader.Read<int>(), bloodyIceCrusher);
					break;
				case "Bags":
					reader.SetPrivateField("BloodBagsGenerated".ToBackingField(), reader.Read<int>(), bloodyIceCrusher);
					break;
				case "_forceStopSuck":
					reader.SetPrivateField("_forceStopSuck", reader.Read<bool>(), bloodyIceCrusher);
					break;
				case "_timerUI":
					reader.SetPrivateField("_timerUI", reader.Read<float>(), bloodyIceCrusher);
					break;
				case "_processDuration":
					reader.SetPrivateField("_processDuration", reader.Read<float>(), bloodyIceCrusher);
					break;
				case "_efficiencyTimer":
					reader.SetPrivateField("_efficiencyTimer", reader.Read<float>(), bloodyIceCrusher);
					break;
				case "_efficiencyInterval":
					reader.SetPrivateField("_efficiencyInterval", reader.Read<float>(), bloodyIceCrusher);
					break;
				case "Synced":
					bloodyIceCrusher.Syncing?.SetSyncing(reader.Read<bool>());
					break;
				default:
					reader.Skip();
					break;
				}
			}
			if (SaveManager.CurrentSaveState != SaveManager.ESaveState.LoadPost || !bloodyIceCrusher.Victim)
			{
				return;
			}
			bloodyIceCrusher.MachineUI.DisplayOrHide(_value: true);
			bloodyIceCrusher.AnimateCloseMachine();
			bloodyIceCrusher.CreateUnloadChore();
			if (bloodyIceCrusher.BloodBagsGenerated < bloodyIceCrusher.BloodBagsAmountTarget)
			{
				if (bloodyIceCrusher.MachinePowerState == EMachinePowerState.On)
				{
					bloodyIceCrusher.StopAllCoroutines();
					bloodyIceCrusher.StartCoroutine(bloodyIceCrusher.GenerateBloodIceCrushed(bloodyIceCrusher.Timer));
				}
				bloodyIceCrusher.MachineUI.RunFillArea((float)bloodyIceCrusher.BloodBagsGenerated / (float)bloodyIceCrusher.BloodBagsAmountTarget);
			}
			else
			{
				bloodyIceCrusher.MachineUI.RunFillArea(1f);
			}
		}
	}
}
