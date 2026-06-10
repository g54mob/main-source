using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(CaravanPostComponent))]
	public class CaravanPostViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private CaravanPostComponent caravanPostComponent;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			caravanPostComponent = GetComponent<CaravanPostComponent>();
		}
	}
}
