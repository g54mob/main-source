using System;
using System.Collections.Generic;
using FullInspector;
using UnityEngine;
using UnityEngine.Events;

namespace TH20.UI
{
	[Serializable]
	public class StaffTabGraphPanel : OverviewMenuGraphPanelBase
	{
		[Serializable]
		private class StaffGraphStatsSet
		{
			[SerializeField]
			public StaffDefinition.Type StaffType;

			[SerializeField]
			public List<GraphStatDefinition> StatDefinitions;

			[SerializeField]
			public PanelItemToggleButton AssignedButton;

			private DynamicButton _dynamicButton;

			public void AddButtonListener(UnityAction call)
			{
				if ((bool)AssignedButton)
				{
					_dynamicButton = AssignedButton.GetComponent<DynamicButton>();
					if ((bool)_dynamicButton)
					{
						_dynamicButton.onPrimaryDown.AddListener(call);
					}
				}
			}
		}

		[InspectorMargin(8)]
		[SerializeField]
		private PanelItemToggleButton _defaultToggleButton;

		[SerializeField]
		private List<StaffGraphStatsSet> _staffGraphStatSetDefinitions = new List<StaffGraphStatsSet>();

		public override void Setup(OverviewMenuTab theTabRoot)
		{
			base.Setup(theTabRoot);
			_staffGraphStatSetDefinitions = _staffGraphStatSetDefinitions ?? new List<StaffGraphStatsSet>();
			if ((bool)_defaultToggleButton)
			{
				_defaultToggleButton.SetPressedState(state: true);
			}
			foreach (StaffGraphStatsSet staffGraphStatSet in _staffGraphStatSetDefinitions)
			{
				if (staffGraphStatSet.StaffType == StaffDefinition.Type.None || staffGraphStatSet.StatDefinitions == null)
				{
					staffGraphStatSet.StatDefinitions = _statDefinitions;
				}
				else
				{
					SetupStatDefitionSet(staffGraphStatSet.StatDefinitions, theTabRoot.TheOverviewMenu.TheLevel.TimelineManager, theTabRoot.TheOverviewMenu.IsEndOfYear);
				}
				staffGraphStatSet.AddButtonListener(delegate
				{
					ChangeStatSet(staffGraphStatSet.StatDefinitions);
				});
			}
		}

		private void ChangeStatSet(List<GraphStatDefinition> statDefinitions)
		{
			AssignStatDefitionSetToGraphs(statDefinitions);
			foreach (GraphStatDefinition statDefinition in statDefinitions)
			{
				statDefinition.Graph.ShowGraph();
			}
		}
	}
}
