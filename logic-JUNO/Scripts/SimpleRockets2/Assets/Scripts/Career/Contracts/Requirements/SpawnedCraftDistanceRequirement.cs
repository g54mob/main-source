using System;
using System.Xml.Linq;
using Assets.Scripts.Flight;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class SpawnedCraftDistanceRequirement : ContractRequirement
	{
		private bool _autoSelectTarget;

		private ButtonInformation _buttonInfo;

		private double _distance;

		private TrackSpawnedCraftRequirement _parentRequirement;

		private bool _showTargetButton;

		private ICraftNode _target;

		public override ButtonInformation ButtonInfo
		{
			get
			{
				if (_target != null)
				{
					if (_buttonInfo == null && _showTargetButton)
					{
						_buttonInfo = new ButtonInformation("Target Location", "Ui/Sprites/Flight/IconTargetLocation");
					}
				}
				else
				{
					_buttonInfo = null;
				}
				return _buttonInfo;
			}
		}

		public override string DisplayValue => Units.GetDistanceString((float)Mathd.Max(0.0, _distance - Range));

		public double Range { get; private set; }

		public SpawnedCraftDistanceRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			_autoSelectTarget = xml.GetBoolAttribute("autoSelectTarget", defaultValue: true);
			_showTargetButton = xml.GetBoolAttribute("showTargetButton", defaultValue: true);
			Range = xml.GetDoubleAttribute("range", 1000.0);
		}

		public override void OnClick(Action refreshUI)
		{
			if (_target != null)
			{
				FlightSceneScript.Instance.FlightSceneUI.SetCurrentTarget(_target);
			}
		}

		public override void OnFlightEnd()
		{
			base.OnFlightEnd();
			_target = null;
		}

		public override void OnFlightStart(IFlightContext flightContext)
		{
			base.OnFlightStart(flightContext);
		}

		public override void OnRequirementsCreated()
		{
			base.OnRequirementsCreated();
			_parentRequirement = GetParentRequirement<TrackSpawnedCraftRequirement>();
			if (_parentRequirement == null)
			{
				throw new ContractException("Requirement has no parent TrackSpawnedCraft requirement.");
			}
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			if (_target == null)
			{
				_distance = 0.0;
				_target = _parentRequirement?.SpawnedCraftNode;
				if (_target != null)
				{
					FlightSceneScript.Instance.FlightSceneUI.SetCurrentTarget(_target);
				}
			}
			if (_target != null)
			{
				_distance = (_target.SolarPosition - base.FlightContext.CraftNode.SolarPosition).magnitude;
				return _distance <= Range;
			}
			return false;
		}
	}
}
