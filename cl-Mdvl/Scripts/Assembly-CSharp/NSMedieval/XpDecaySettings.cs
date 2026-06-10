using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class XpDecaySettings : NSEipix.Base.Model
	{
		[SerializeField]
		private List<float> xpDecay;

		public float GetXpDecay(int skillLevel)
		{
			if (xpDecay == null)
			{
				Log.Info("XpDecay not found in XpDecaySettings.json, XpDecaySettings.GetXpDecay will return 0.", "C:\\GIT\\dev\\Assets\\Scripts\\Models\\Blueprint\\Settings\\XpDecaySettings.cs");
				return 0f;
			}
			int val = xpDecay.Count - 1;
			int index = Math.Max(0, Math.Min(skillLevel, val));
			return xpDecay[index];
		}

		public override string GetID()
		{
			return "XpDecaySettings";
		}
	}
}
