using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(RallyPointMarkerComponent))]
	public class RallyPointMarkerViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private RallyPointMarkerComponent rallyPoint;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			rallyPoint = GetComponent<RallyPointMarkerComponent>();
		}
	}
}
