using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(ChairComponent))]
	public class ChairViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private ChairComponent chairComponent;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			chairComponent = GetComponent<ChairComponent>();
		}
	}
}
