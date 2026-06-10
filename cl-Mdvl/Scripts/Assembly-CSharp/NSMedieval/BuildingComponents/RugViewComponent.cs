using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(RugComponent))]
	public class RugViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private RugComponent rugComponent;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			rugComponent = GetComponent<RugComponent>();
		}
	}
}
