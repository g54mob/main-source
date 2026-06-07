using System;
using System.Xml.Linq;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using Assets.Scripts.XR.UI;

namespace Assets.Scripts.Tutorials.Requirements.UI
{
	[Serializable]
	[TutorialRequirement("RadialMenuOpen")]
	public class RadialMenuOpenRequirement : TutorialRequirement
	{
		public enum RadialMenuState
		{
			Opened = 0,
			Closed = 1
		}

		public RadialMenuState TargetState { get; set; }

		public RadialMenuOpenRequirement()
		{
		}

		public RadialMenuOpenRequirement(RadialMenuState state)
		{
			TargetState = state;
		}

		public RadialMenuOpenRequirement(RadialMenuState state, string message)
			: this(state)
		{
			base.RequirementNotMetMessage = message;
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("state", TargetState);
			base.GenerateXml(xml);
		}

		protected override string GetDefaultRequirementNotMetMessage(bool vr)
		{
			if (TargetState != RadialMenuState.Closed)
			{
				return "Open the radial menu";
			}
			return "Close the radial menu";
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			int num = 0;
			foreach (FlightMenuScript instance in FlightMenuScript.Instances)
			{
				if (instance.IsOpen)
				{
					num++;
				}
			}
			if ((TargetState != RadialMenuState.Opened || num <= 0) && (TargetState != RadialMenuState.Closed || num != 0))
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			return TutorialRequirementState.RequirementMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			TargetState = xml.GetEnumAttribute("state", RadialMenuState.Opened);
		}
	}
}
