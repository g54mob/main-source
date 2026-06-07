using System;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes.Interfaces;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes
{
	public class NodeDeltaVAdjustorScript : NodeAdjustorScript
	{
		private Vector3d _deltaV;

		private IMapOptions _mapOptions;

		private IOrbitInfoProvider _orbitInfoProvider;

		public Vector3d DeltaV => _deltaV;

		public static NodeDeltaVAdjustorScript Create(IIocContainer ioc, Canvas canvas, Transform parent, Func<Vector3d> maneuverVec, IManeuverNode node, IManeuverNodePositionProvider positionProvider, IOrbitInfoProvider orbitInfoProvider, IDrawModeProvider drawModeProvider, string name, string iconName, Color lineColor)
		{
			NodeDeltaVAdjustorScript nodeDeltaVAdjustorScript = NodeAdjustorScript.Create<NodeDeltaVAdjustorScript>(ioc, canvas, parent, maneuverVec, node, positionProvider, drawModeProvider, name, iconName, lineColor);
			nodeDeltaVAdjustorScript.Initialize(ioc, orbitInfoProvider);
			return nodeDeltaVAdjustorScript;
		}

		public void AdjustDeltaV(float input)
		{
			Vector3d vector3d = base.ManeuverVec * input;
			double num = (double)base.ManeuverNode.DeltaVAdjustmentSensitivityExpo * _mapOptions.ManeuverNodes.SensitivityLinear;
			_deltaV += vector3d * GetDvScalar(_orbitInfoProvider.OrbitInfo.OrbitNode.Orbit) * num;
		}

		public void SetDeltaV(Vector3d deltaV)
		{
			_deltaV = deltaV;
		}

		public void SetDeltaV(double value)
		{
			_deltaV = base.ManeuverVec * value;
		}

		protected override void OnGizmoDragged(float gizmoPercent)
		{
			base.OnGizmoDragged(gizmoPercent);
			AdjustDeltaV(gizmoPercent);
		}

		private static double GetDvScalar(IOrbit orbit)
		{
			return Mathd.Lerp(0.0, orbit.Velocity.magnitude, (double)Time.unscaledDeltaTime / 5.0);
		}

		private void Initialize(IIocContainer ioc, IOrbitInfoProvider orbitInfoProvider)
		{
			_orbitInfoProvider = orbitInfoProvider;
			_mapOptions = ioc.Resolve<IMapOptions>();
		}
	}
}
