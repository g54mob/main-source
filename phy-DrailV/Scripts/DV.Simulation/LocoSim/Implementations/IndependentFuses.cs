using System.Collections.Generic;
using DV.JObjectExtstensions;
using LocoSim.Definitions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class IndependentFuses : SimComponent
	{
		private const string FUSES_STATE_SAVE_KEY = "fuses";

		public readonly bool saveState;

		public override bool HasSaveData => saveState;

		public IndependentFuses(IndependentFusesDefinition ifDef)
			: base(ifDef.ID)
		{
			FuseDefinition[] fuses = ifDef.fuses;
			foreach (FuseDefinition fDef in fuses)
			{
				AddFuse(fDef);
			}
			saveState = ifDef.saveState;
		}

		public override void Tick(float delta)
		{
		}

		public override JObject GetSaveStateData()
		{
			JObject jObject = new JObject();
			List<Fuse> list = GetAllFuses();
			int[] array = new int[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				array[i] = (list[i].State ? 1 : 0);
			}
			jObject.SetIntArray("fuses", array);
			return jObject;
		}

		public override void SetSaveStateData(JObject savedData)
		{
			int[] intArray = savedData.GetIntArray("fuses");
			if (intArray != null)
			{
				List<Fuse> list = GetAllFuses();
				for (int i = 0; i < intArray.Length; i++)
				{
					list[i].ChangeState(intArray[i] == 1);
				}
			}
			else
			{
				Debug.LogError("Unexpected state: Missing data for " + id + ".FUSES_STATE_SAVE_KEY. Loading ignored for this parameter.");
			}
		}
	}
}
