using System;
using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;
using UnityEngine.Playables;

namespace UMA.Timeline
{
	[Serializable]
	public class UmaWardrobeBehaviour : PlayableBehaviour
	{
		public enum WardrobeOptions
		{
			AddRecipes = 0,
			ClearSlots = 1,
			ClearAllSlots = 2
		}

		public WardrobeOptions wardrobeOption;

		public List<UMAWardrobeRecipe> recipesToAdd;

		public List<string> slotsToClear;

		[Tooltip("Whether to rebuild the uma avatar immediately on setting/clearing or instead accummulate the changes.")]
		public bool rebuildImmediately;

		[HideInInspector]
		public bool isAdded;

		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
		}
	}
}
