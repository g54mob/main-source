using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(StairsComponent))]
	public class StairsViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private StairsComponent stairsComponent;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			stairsComponent = GetComponent<StairsComponent>();
		}
	}
}
