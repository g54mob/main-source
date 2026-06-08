using System.Collections.Generic;
using Platforms;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(menuName = "Kitchen/Strings/Platform Substitution", fileName = "StringSubstitution", order = 0)]
	public class PlatformSpecificSubstitution : StringSubstitution
	{
		public Dictionary<PlatformType, Dictionary<string, string>> PlatformSubstitutions = new Dictionary<PlatformType, Dictionary<string, string>>();

		public override bool IsPriority => true;

		public override Dictionary<string, string> Active
		{
			get
			{
				if (PlatformSubstitutions.TryGetValue(PlatformSettings.CurrentPlatformType, out var value))
				{
					return value;
				}
				return Substitutions;
			}
		}
	}
}
