using DV.Damage;
using DV.JObjectExtstensions;
using DV.MultipleUnit;
using LocoSim.Implementations;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class SimCarStateSave : MonoBehaviour
	{
		private const string SIMULATION_SAVE_KEY = "sim";

		private const string DAMAGE_SAVE_KEY = "dmg";

		private const string MU_CONNECTED_FRONT_KEY = "muF";

		private const string MU_CONNECTED_REAR_KEY = "muR";

		private SimulationFlow simFlow;

		private DamageController damageController;

		private MultipleUnitModule muModule;

		public void Initialize(SimulationFlow simFlow, DamageController damageController, MultipleUnitModule muModule)
		{
			this.simFlow = simFlow;
			this.damageController = damageController;
			this.muModule = muModule;
		}

		public JObject GetStateSaveData()
		{
			JObject jObject = new JObject();
			if (simFlow != null)
			{
				jObject.SetJObject("sim", simFlow.GetSaveStateData());
			}
			if ((bool)damageController)
			{
				jObject.SetJObject("dmg", damageController.GetDamageSaveData());
			}
			if (muModule != null)
			{
				if (muModule.frontCableAdapter.muCable.IsConnected)
				{
					jObject.SetBool("muF", value: true);
				}
				if (muModule.rearCableAdapter.muCable.IsConnected)
				{
					jObject.SetBool("muR", value: true);
				}
			}
			return jObject;
		}

		public void SetStateSaveData(JObject data)
		{
			if (simFlow != null)
			{
				JObject jObject = data.GetJObject("sim");
				if (jObject != null)
				{
					simFlow.SetSaveStateData(jObject);
				}
				else
				{
					Debug.LogError("Couldn't find sim to load!", this);
				}
			}
			if (damageController != null)
			{
				JObject jObject2 = data.GetJObject("dmg");
				if (jObject2 != null)
				{
					damageController.LoadDamagesState(jObject2);
				}
				else
				{
					Debug.LogError("Couldn't find dmg to load!", this);
				}
			}
			if (muModule != null)
			{
				bool flag = data.GetBool("muF") ?? false;
				bool flag2 = data.GetBool("muR") ?? false;
				if (flag || flag2)
				{
					muModule.MultipleUnitStateRestoreOnGameLoad(flag, flag2);
				}
			}
		}
	}
}
