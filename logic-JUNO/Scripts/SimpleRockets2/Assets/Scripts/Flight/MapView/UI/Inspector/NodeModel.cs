using Assets.Scripts.Flight.MapView.Automation;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using ModApi.Math;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.UI.Inspector
{
	public class NodeModel
	{
		private IChainableOrbit _chainOrbit;

		private MapViewInspectorScript _mapViewInspector;

		private ProgressBarModel _progressBar;

		private string _selectedNodeName;

		public string ArrivalTime { get; private set; }

		public string BurnTime { get; private set; }

		public string DeltaV { get; private set; }

		public GroupModel Group { get; private set; }

		public ManeuverNodeScript ManeuverNode => _mapViewInspector.PlayerCraft?.ChainNodeManager.FirstIncompleteManeuverNode ?? null;

		public float Progress { get; private set; }

		private NodeNavigator NodeNavigator => _mapViewInspector.PlayerCraft.NodeNavigator;

		public NodeModel(MapViewInspectorScript mapViewInspector)
		{
			_mapViewInspector = mapViewInspector;
			Group = new GroupModel("Next Burn");
			Group.Add(new TextModel("Arrival Time", () => ArrivalTime));
			Group.Add(new TextModel("Delta-V", () => DeltaV));
			Group.Add(new TextModel("Burn Time", () => BurnTime));
			_progressBar = new ProgressBarModel("Delta V", () => Progress);
			Group.Add(_progressBar);
		}

		public void Update()
		{
			Group.Visible = ManeuverNode != null && !_mapViewInspector.SelectedItem.IsManeuverNode;
			if (Group.Visible)
			{
				UpdateInfo(ManeuverNode);
			}
		}

		private void UpdateInfo(IChainableOrbit chainableOrbit)
		{
			double? num = null;
			double? num2 = null;
			double? timeToNode = chainableOrbit.TimeToNode;
			_progressBar.Visible = false;
			if (NodeNavigator.AutoBurnInProgress)
			{
				_progressBar.Visible = true;
				BurnData burnData = NodeNavigator.AutoBurnNode?.BurnData;
				if (burnData != null)
				{
					num = burnData.DeltaVMagRemaining;
					num2 = burnData.BurnTimeRemaining;
				}
				Progress = Mathf.Clamp01(NodeNavigator.Progress);
				_progressBar.Label = Units.GetPercentageString(Progress);
			}
			else if (chainableOrbit is ManeuverNodeScript)
			{
				_progressBar.Visible = false;
				ManeuverNodeScript maneuverNodeScript = chainableOrbit as ManeuverNodeScript;
				num = maneuverNodeScript.GetDeltaVToCompleteManeuver().magnitude;
				num2 = maneuverNodeScript.BurnData.BurnDuration;
				_ = maneuverNodeScript.BurnData.BurnPasses;
			}
			if (num.HasValue)
			{
				DeltaV = Units.GetVelocityString((float)num.Value, Units.UnitPrecisionMode.High);
			}
			else
			{
				DeltaV = "N/A";
			}
			if (num2 > 0.0)
			{
				BurnTime = Units.GetRelativeTimeString((float)num2.Value);
			}
			else
			{
				BurnTime = "N/A";
			}
			if (timeToNode.HasValue)
			{
				ArrivalTime = Units.GetRelativeTimeString((float)timeToNode.Value);
			}
			else
			{
				ArrivalTime = "N/A";
			}
		}
	}
}
