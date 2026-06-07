using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public class DamageableProfile
	{
		[HideInInspector]
		public string display;

		[Tooltip("Profile to activate on the Damager")]
		public StringReference Profile = new StringReference();

		[Tooltip("Range on the Animation that the Attack Trigger will be Active")]
		[MinMaxRange(0f, 1f)]
		public RangedFloat ProfileActivation;

		public bool isOn { get; set; }

		public bool isOff { get; set; }
	}
}
