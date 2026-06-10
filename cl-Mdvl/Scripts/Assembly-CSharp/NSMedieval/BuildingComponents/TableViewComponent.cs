using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(TableComponent))]
	public class TableViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private TableComponent tableComponent;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			tableComponent = GetComponent<TableComponent>();
		}
	}
}
