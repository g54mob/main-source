using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class HeraldryColors
	{
		[SerializeField]
		private List<string> colors = new List<string>();

		public List<string> Colors => colors;
	}
}
