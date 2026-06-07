using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class LocationRequirement : ContractRequirement
	{
		public enum DistanceModeType
		{
			Line = 0,
			GreatCircle = 1
		}

		private bool _autoSelectTarget;

		private ButtonInformation _buttonInfo;

		private ContractLocation _contractLocation;

		private double _distance;

		private DistanceModeType _distanceMode;

		private bool _showTargetButton;

		private LocationNode _node;

		public override ButtonInformation ButtonInfo
		{
			get
			{
				if (_node != null)
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

		public override string DisplayValue
		{
			get
			{
				double num = 0.0;
				num = ((!(_contractLocation.Range > 0.0)) ? Mathd.Max(0.0, _distance) : Mathd.Max(0.0, _distance - _contractLocation.Range));
				return Units.GetDistanceString((float)num);
			}
		}

		public double Range => _contractLocation.Range;

		public LocationRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			_autoSelectTarget = xml.GetBoolAttribute("autoSelectTarget", defaultValue: true);
			_distanceMode = xml.GetEnumAttribute("distanceMode", DistanceModeType.Line);
			_showTargetButton = xml.GetBoolAttribute("showTargetButton", defaultValue: true);
			string stringAttribute = xml.GetStringAttribute("locationId");
			_contractLocation = (string.IsNullOrWhiteSpace(stringAttribute) ? null : base.Contract.Context.GetContractLocation(stringAttribute));
			if (_contractLocation == null)
			{
				_contractLocation = new ContractLocation(xml);
			}
			else
			{
				_contractLocation.LoadOverriddenXmlAttributes(xml);
			}
			if (string.IsNullOrEmpty(base.Description) && Range > 0.0)
			{
				base.Description = "Get to " + _contractLocation.Name;
			}
		}

		public override void OnClick(Action refreshUI)
		{
			if (_node != null)
			{
				_node?.SetAsTarget();
			}
		}

		public override void OnFlightEnd()
		{
			base.OnFlightEnd();
			DestroyNode();
		}

		public override void OnFlightStart(IFlightContext flightContext)
		{
			base.OnFlightStart(flightContext);
		}

		public override void OnRequirementsCreated()
		{
			base.OnRequirementsCreated();
			PlanetRequirement parentRequirement = GetParentRequirement<PlanetRequirement>();
			if (string.IsNullOrWhiteSpace(_contractLocation.PlanetName))
			{
				if (parentRequirement == null)
				{
					throw new ContractException("Location requirement has no planet specified.");
				}
				_contractLocation.PlanetName = parentRequirement.PlanetName;
			}
			else if (parentRequirement != null && parentRequirement.PlanetName != _contractLocation.PlanetName)
			{
				throw new ContractException("Location requirement has different planet than its referenced contract location " + parentRequirement.PlanetName + " != " + _contractLocation.PlanetName + ".");
			}
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			if (_node == null)
			{
				_node = base.FlightContext.CreateLocationNode(_contractLocation, "StructureNode");
				_node.Register(base.FlightContext);
				if (_autoSelectTarget)
				{
					_node.SetAsTarget();
				}
			}
			if (craftNode.Parent.Name == _contractLocation.PlanetName)
			{
				if (_distanceMode == DistanceModeType.Line)
				{
					_distance = _node.CalculateDistanceToPosition(craftNode.Position);
				}
				else if (_distanceMode == DistanceModeType.GreatCircle)
				{
					Vector2d latLon = craftNode.LatLon;
					_distance = MathUtils.Haversine(latLon.x, latLon.y, _contractLocation.LatLonAgl.x * 0.01745329, _contractLocation.LatLonAgl.y * 0.01745329, craftNode.Parent.PlanetData.Radius);
				}
				if (!(_contractLocation.Range > 0.0))
				{
					return _distance >= 0.0 - _contractLocation.Range;
				}
				return _distance <= _contractLocation.Range;
			}
			return false;
		}

		protected override void OnStatusChanged()
		{
			base.OnStatusChanged();
			if (base.Status != RequirementStatus.Pass && base.Status != RequirementStatus.Active && _node != null)
			{
				DestroyNode();
			}
		}

		private void DestroyNode()
		{
			_node?.Unregister();
			_node = null;
		}
	}
}
