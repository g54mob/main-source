using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class AllHeraldryPresets
	{
		[SerializeField]
		private List<HeraldryPresets> presets = new List<HeraldryPresets>();

		public List<HeraldryPresets> Presets
		{
			get
			{
				return presets;
			}
			set
			{
				presets = value;
			}
		}
	}
}
