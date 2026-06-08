using System;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Process", menuName = "Kitchen/Process")]
	public class Process : GameDataObject
	{
		public GameDataObject BasicEnablingAppliance;

		public int EnablingApplianceCount = 1;

		public Process IsPseudoprocessFor;

		public bool CanObfuscateProgress;

		[NonSerialized]
		[HideInInspector]
		public string Icon = "!";

		public LocalisationObject<ProcessInfo> Info;

		protected override void InitialiseDefaults()
		{
		}

		public override bool Localise(Locale locale, StringSubstitutor subs)
		{
			if (Info == null)
			{
				return false;
			}
			ProcessInfo processInfo = Info.Get(locale);
			Icon = subs.Parse(processInfo.Icon);
			return true;
		}
	}
}
