using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BedComponent))]
	public class BedViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private BedComponent bedComponent;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			bedComponent = GetComponent<BedComponent>();
		}
	}
}
