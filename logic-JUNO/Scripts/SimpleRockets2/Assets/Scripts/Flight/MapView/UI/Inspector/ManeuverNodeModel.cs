using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using ModApi.Flight.MapView;
using ModApi.Ioc;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.UI.Inspector
{
	public class ManeuverNodeModel
	{
		private DeltaVAdjustorModel _adjustorModelNormalAntiNormal;

		private DeltaVAdjustorModel _adjustorModelProgradeRetrograde;

		private DeltaVAdjustorModel _adjustorModelRadialOutRadialIn;

		private MapViewInspectorScript _mapViewInspector;

		private int _orbitalPeriodActualValue = -1;

		private string _orbitalPeriodDisplayValue;

		private SpinnerModel _orbitalPeriodModel;

		private SliderModel _sensitivitySliderModel;

		public GroupModel Group { get; }

		public IManeuverNode SelectedNode { get; private set; }

		public ManeuverNodeModel(MapViewInspectorScript mapViewInspector, IIocContainer ioc, IMapViewContext mapViewContext)
		{
			_mapViewInspector = mapViewInspector;
			_orbitalPeriodModel = new SpinnerModel(() => _orbitalPeriodDisplayValue, OnNextOrbitalPeriodClicked, OnPreviousOrbitalPeriodClicked);
			_orbitalPeriodModel.Tooltip = "This can be used to position the planned burn one or more orbital periods in the future.";
			_adjustorModelProgradeRetrograde = new DeltaVAdjustorModel(DeltaVAdjustorModelType.ProgradeRetrograde);
			_adjustorModelNormalAntiNormal = new DeltaVAdjustorModel(DeltaVAdjustorModelType.NormalAntiNormal);
			_adjustorModelRadialOutRadialIn = new DeltaVAdjustorModel(DeltaVAdjustorModelType.RadialOutRadialIn);
			_sensitivitySliderModel = new SliderModel("Sensitivity", () => SelectedNode?.DeltaVAdjustmentSensitivityLinear ?? 1f, delegate(float value)
			{
				SelectedNode.DeltaVAdjustmentSensitivityLinear = value;
			}, 0.01f, 2f);
			_sensitivitySliderModel.Tooltip = "Adjusts how sensitive the delta-v adjustment gizmos are. Lower sensitivity results in smaller delta-v changes when interacting with the planned burn gizmos.";
			Group = new GroupModel("Planned Burn");
			Group.Add(_orbitalPeriodModel);
			Group.Add(_adjustorModelProgradeRetrograde);
			Group.Add(_adjustorModelNormalAntiNormal);
			Group.Add(_adjustorModelRadialOutRadialIn);
			Group.Add(_sensitivitySliderModel);
		}

		public void Update()
		{
			IManeuverNode maneuverNode = _mapViewInspector.SelectedItem?.Target as IManeuverNode;
			if (maneuverNode != SelectedNode)
			{
				SelectNode(maneuverNode);
			}
			bool flag = maneuverNode != null && !maneuverNode.Locked;
			if (Group.Visible != flag)
			{
				Group.Visible = flag;
			}
			RefreshOrbitalPeriod();
		}

		private void OnNextOrbitalPeriodClicked(SpinnerModel spinner)
		{
			if (SelectedNode != null)
			{
				SelectedNode.ReferenceOrbitPeriod = Mathf.Clamp(SelectedNode.ReferenceOrbitPeriod + 1, 0, 9999);
				RefreshOrbitalPeriod();
			}
		}

		private void OnPreviousOrbitalPeriodClicked(SpinnerModel spinner)
		{
			if (SelectedNode != null)
			{
				SelectedNode.ReferenceOrbitPeriod = Mathf.Clamp(SelectedNode.ReferenceOrbitPeriod - 1, 0, 9999);
				RefreshOrbitalPeriod();
			}
		}

		private void RefreshOrbitalPeriod()
		{
			bool flag = SelectedNode?.SupportsVariableReferenceOrbitPeriod ?? false;
			_orbitalPeriodModel.PrevButtonVisible = flag;
			_orbitalPeriodModel.NextButtonVisible = flag;
			if (!flag)
			{
				_orbitalPeriodDisplayValue = "Current Period";
				return;
			}
			int num = SelectedNode?.ReferenceOrbitPeriod ?? 0;
			_orbitalPeriodModel.PrevButtonVisible = num > 0;
			if (_orbitalPeriodActualValue != num)
			{
				_orbitalPeriodActualValue = num;
				if (num == 0)
				{
					_orbitalPeriodDisplayValue = "Current Period";
				}
				else if (num == 1)
				{
					_orbitalPeriodDisplayValue = "Next Period";
				}
				else if (num > 1)
				{
					_orbitalPeriodDisplayValue = $"Future Period: {_orbitalPeriodActualValue}";
				}
				else
				{
					_orbitalPeriodDisplayValue = "Error";
				}
			}
		}

		private void SelectNode(IManeuverNode node)
		{
			if (SelectedNode != null)
			{
				_adjustorModelProgradeRetrograde.OnNodeDeselected();
				_adjustorModelNormalAntiNormal.OnNodeDeselected();
				_adjustorModelRadialOutRadialIn.OnNodeDeselected();
			}
			SelectedNode = node;
			if (node != null)
			{
				_adjustorModelProgradeRetrograde.OnNodeSelected(node);
				_adjustorModelNormalAntiNormal.OnNodeSelected(node);
				_adjustorModelRadialOutRadialIn.OnNodeSelected(node);
			}
		}
	}
}
