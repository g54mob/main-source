using System.Collections.Generic;
using System.Linq;
using AssembleSystem;
using AssembleSystem.FSM.Parts;
using Items;
using UnityEngine;

namespace Services.Save.Assemble
{
	internal static class AssembleSaveHelper
	{
		internal static AssembleObjectSaveData BuildSaveData(AssembleObjectParent assembleParent)
		{
			Dictionary<string, PartSaveData> dictionary = new Dictionary<string, PartSaveData>();
			foreach (var item in from go in assembleParent.Parts
				select new
				{
					GO = go,
					Part = go.GetComponent<PartObject>(),
					FSM = go.GetComponent<PartObjectStateMachine>()
				} into x
				where x.Part != null && x.FSM != null && x.Part.Config != null
				orderby x.Part.Config.SavePriority
				select x)
			{
				dictionary[item.GO.name] = new PartSaveData
				{
					Placed = item.FSM.Placed,
					Tightened = item.FSM.Tightened,
					Progress = ((IProgressable)item.Part).CurrentProgress
				};
			}
			return new AssembleObjectSaveData
			{
				Parts = dictionary
			};
		}

		internal static void ApplySaveData(AssembleObjectParent assembleParent, AssembleObjectSaveData data)
		{
			if (data.Parts == null)
			{
				return;
			}
			foreach (GameObject part in assembleParent.Parts)
			{
				if (data.Parts.TryGetValue(part.name, out var value))
				{
					PartObject component = part.GetComponent<PartObject>();
					PartObjectStateMachine component2 = part.GetComponent<PartObjectStateMachine>();
					if (!(component == null) && !(component2 == null))
					{
						component2.Placed = value.Placed;
						component2.Tightened = value.Tightened;
						component.SetProgress(value.Progress);
					}
				}
			}
		}
	}
}
