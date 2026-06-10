using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(DecorationComponent))]
	public class DecorationViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private DecorationComponent decorationComponent;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			decorationComponent = GetComponent<DecorationComponent>();
		}
	}
}
