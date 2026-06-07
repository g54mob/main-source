using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(Inventory))]
	public class LuggageDesk : Prop
	{
		public static HashSet<LuggageDesk> AllLuggageDesks;

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
