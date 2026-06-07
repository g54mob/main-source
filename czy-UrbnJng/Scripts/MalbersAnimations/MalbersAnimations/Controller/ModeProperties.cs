using System;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public class ModeProperties
	{
		[Tooltip("Exclude: The mode will not be activated when is on a State of the List.\nInclude: The mode will only be actived when the Animal is on a State of the List")]
		public AffectStates affect;

		[Tooltip("Include/Exclude the  States on this list depending the Affect variable")]
		public List<StateID> affectStates = new List<StateID>();

		[Tooltip("Exlcude: The mode will not be activated when is on a Stance of the List.\nInclude: The mode will only be actived when the Animal is on a Stance of the List")]
		public AffectStates affect_Stance;

		[Tooltip("Include/Exclude the Stances on this list depending the Affect Stanes variable")]
		public List<StanceID> Stances = new List<StanceID>();

		[Tooltip("Modes can transition from other abilities inside the same mode. E.g Seat -> Lie -> Sleep")]
		public List<int> TransitionFrom = new List<int>();

		public ModeProperties(ModeProperties properties)
		{
			affect = properties.affect;
			affect_Stance = properties.affect_Stance;
			affectStates = new List<StateID>(properties.affectStates);
			Stances = new List<StanceID>(properties.Stances);
			TransitionFrom = new List<int>();
		}
	}
}
