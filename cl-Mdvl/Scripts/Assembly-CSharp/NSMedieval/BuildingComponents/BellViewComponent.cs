using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BellComponent))]
	public class BellViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private BellComponent component;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			component = GetComponent<BellComponent>();
		}
	}
}
