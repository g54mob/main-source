using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(EntertainmentComponent))]
	public class EntertainmentViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private EntertainmentComponent entertainmentComponent;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			entertainmentComponent = GetComponent<EntertainmentComponent>();
		}
	}
}
