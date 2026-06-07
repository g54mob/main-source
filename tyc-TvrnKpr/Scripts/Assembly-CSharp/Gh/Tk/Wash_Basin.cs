using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public class Wash_Basin : Prop
	{
		public static HashSet<Wash_Basin> AllWash_Basins;

		private const float _filthIncreasePerUse = 0.2f;

		private float _filthLevel;

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		private void IncreaseFilth()
		{
		}

		private void Clean()
		{
		}

		private void OnUsageFinished(object sender, EventArgs e)
		{
		}
	}
}
