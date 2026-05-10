using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ActionWorkerPriority : InstantAction
	{
		[SerializeField]
		private SerializableDictionary<ChoreCategory, bool> _specificChoreCategories = new SerializableDictionary<ChoreCategory, bool>();

		protected override bool PlayAction(ActionSequence sequence)
		{
			if (!(sequence.PlayerAgent is Worker worker))
			{
				return false;
			}
			foreach (KeyValuePair<ChoreCategory, bool> specificChoreCategory in _specificChoreCategories)
			{
				worker.ChoreAssigner.TogglePriority(specificChoreCategory.Key, specificChoreCategory.Value);
			}
			return true;
		}
	}
}
