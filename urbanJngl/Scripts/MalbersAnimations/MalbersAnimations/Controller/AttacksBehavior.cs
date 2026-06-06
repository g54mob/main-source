using System;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public class AttacksBehavior
	{
		[HideInInspector]
		public string name;

		[Tooltip("0: Disable All Attack Triggers\n-1: Enable All Attack Triggers\nx: Enable the Attack Trigger by its index")]
		public int AttackTrigger = 1;

		[Tooltip("Profile to activate on the Damager")]
		[Min(0f)]
		public int Profile;

		[Tooltip("Range on the Animation that the Attack Trigger will be Active")]
		[MinMaxRange(0f, 1f)]
		public RangedFloat AttackActivation = new RangedFloat(0.3f, 0.6f);

		public bool isOn { get; set; }

		public bool isOff { get; set; }
	}
}
