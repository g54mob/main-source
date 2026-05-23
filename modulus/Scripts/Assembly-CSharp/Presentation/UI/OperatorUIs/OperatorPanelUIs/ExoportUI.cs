using System;
using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Presentation.UI.Menus;
using UnityEngine;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs
{
	public class ExoportUI : FactoryPanelUIMenu
	{
		[Serializable]
		public class StatUIPair
		{
			public ResourceDeliveredUI ResourceDeliveredUI;

			public ResourceDataSO DeliveredResource;

			public string ResourceLocaKey;

			public bool AlwaysShow;
		}

		[Header("Depot UI")]
		[SerializeField]
		private List<StatUIPair> _statUIPairs = new List<StatUIPair>();

		[SerializeField]
		private ExoportBehaviour _exoportBehaviour;

		protected override void Initialized()
		{
			foreach (StatUIPair statUIPair in _statUIPairs)
			{
				statUIPair.ResourceDeliveredUI.UpdateResource(statUIPair.DeliveredResource);
				statUIPair.ResourceDeliveredUI.UpdateTitleText(statUIPair.ResourceLocaKey);
			}
		}

		private void Update()
		{
			foreach (StatUIPair statUIPair in _statUIPairs)
			{
				int max = -1;
				if (_exoportBehaviour.AllowedResourcesMaxAmountsDemo.TryGetValue(statUIPair.DeliveredResource, out var value))
				{
					max = value;
				}
				statUIPair.ResourceDeliveredUI.UpdateAmountText(statUIPair.DeliveredResource.ID, statUIPair.AlwaysShow, max);
			}
		}
	}
}
