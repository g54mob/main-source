using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(ShrineComponent))]
	public class ShrineViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private ShrineComponent shrineComponent;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			shrineComponent = GetComponent<ShrineComponent>();
		}
	}
}
