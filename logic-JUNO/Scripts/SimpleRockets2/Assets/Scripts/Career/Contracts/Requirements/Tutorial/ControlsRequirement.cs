using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Levels.LevelScripts.FlightTutorial;
using ModApi.Craft;
using ModApi.Flight.UI;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts.Requirements.Tutorial
{
	public class ControlsRequirement : TutorialRequirement
	{
		private class ControlItem
		{
			public string Name { get; }

			public string Value { get; }

			public bool ValueAsBool => bool.Parse(Value);

			public float ValueAsFloat => float.Parse(Value);

			public int ValueAsInt => int.Parse(Value);

			public ControlItem(string name, string value)
			{
				Name = name;
				Value = value;
			}

			public T ValueAsEnum<T>()
			{
				return (T)Enum.Parse(typeof(T), Value);
			}
		}

		private List<ControlItem> _controls = new List<ControlItem>();

		private CraftControls Controls => base.FlightContext.CraftNode.Controls;

		public ControlsRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			IEnumerable<XAttribute> enumerable = xml.Attributes();
			string[] source = new string[2] { "bypass", "status" };
			foreach (XAttribute item in enumerable)
			{
				string localName = item.Name.LocalName;
				if (!source.Contains(localName))
				{
					_controls.Add(new ControlItem(localName, item.Value));
				}
			}
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			base.Evaluate(craftNode);
			foreach (ControlItem control in _controls)
			{
				if (ProcessControlItem(control) == null)
				{
					return false;
				}
			}
			return true;
		}

		private FlightTutorialState ProcessControlItem(ControlItem c)
		{
			switch (c.Name)
			{
			case "pause":
				return base.Step.State?.SetPauseIfFailed(value: true);
			case "unpause":
				return base.Step.State?.SetPauseIfFailed(value: false)?.EnsureNotPaused();
			case "navSphereHeadingEast":
				return base.Step.State?.EnsureNavSphereVisible(visible: true)?.EnsureHeadingLock()?.EnsureNavSphereHeadingEast();
			case "navSpherePitch":
				return base.Step.State?.EnsureNavSphereVisible(visible: true)?.EnsureHeadingLock()?.EnsureNavSpherePitch(c.ValueAsInt);
			case "navSphereHeading":
				return base.Step.State?.EnsureNavSphereVisible(visible: true)?.EnsureHeadingLock()?.EnsureNavSphereHeading(c.ValueAsInt);
			case "throttle":
				return base.Step.State.EnsureThrottle(c.ValueAsFloat);
			case "pitch":
				return base.Step.State.EnsurePitch(c.ValueAsFloat);
			case "yaw":
				return base.Step.State.EnsureYaw(c.ValueAsFloat);
			case "roll":
				return base.Step.State.EnsureRoll(c.ValueAsFloat);
			case "brake":
				return base.Step.State.EnsureBrake(c.ValueAsFloat);
			case "warpTime":
				if (c.ValueAsBool)
				{
					return base.Step.State.EnsureWarpMode();
				}
				return base.Step.State.EnsureNotTimeWarp();
			case "activateStage":
				return base.Step.State.EnsureStage(c.ValueAsInt, base.Text, autoActivate: false);
			case "navSphereLockPrograde":
				return base.Step.State?.EnsureNavSphereVisible(visible: true)?.EnsureLockedOnPrograde(c.ValueAsBool);
			case "navSphereLockRetrograde":
				return base.Step.State?.EnsureNavSphereVisible(visible: true)?.EnsureLockedOnIndicator(NavSphereIndicatorType.VelocityRetrograde, c.ValueAsBool, "Click the Lock Velocity Retrograde button on the right to lock your heading on your retrograde direction.");
			case "navSphereLockHeading":
				return base.Step.State?.EnsureNavSphereVisible(visible: true)?.EnsureHeadingLock(c.ValueAsBool);
			case "mapView":
				return base.Step.State.EnsureMapView(c.ValueAsBool);
			case "mapViewZoom":
				return base.Step.State.EnsureMapViewZoom(c.ValueAsFloat, c.ValueAsFloat * 0.5f);
			case "activationGroup":
				return base.Step.State?.EnsureActivationPanelOpen()?.EnsureActivationGroupActive(c.ValueAsInt);
			case "forceUnpause":
				base.Step.State.Unpause();
				return base.Step.State.SetPauseIfFailed(value: false);
			case "highlight":
				base.Step.TutorialPanel.HighlightUiElement(c.Value, new Vector2(0f, 0f));
				return base.Step.State;
			case "showPanel":
				base.Step.TutorialPanel.Visible = c.ValueAsBool;
				return base.Step.State;
			case "navball":
				return base.Step.State?.EnsureNavballState(c.ValueAsEnum<NavBallStateType>());
			case "sliderVisible":
				return base.Step.State?.EnsureSliderVisible(c.Value);
			default:
				return base.Step.State;
			}
		}
	}
}
