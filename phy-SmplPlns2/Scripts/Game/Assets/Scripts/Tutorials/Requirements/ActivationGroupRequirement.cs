using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Tutorials.Requirements.Attributes;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("ActivationGroup")]
	public class ActivationGroupRequirement : TutorialRequirement
	{
		[Serializable]
		public struct AGReq
		{
			public int ActivationGroup { get; }

			public bool TargetState { get; }

			public AGReq(int activationGroup, bool targetState)
			{
				ActivationGroup = activationGroup;
				TargetState = targetState;
			}
		}

		private List<List<HighlightedPart>> _highlightedPartsPerRequirement;

		private List<AGReq> _requirements;

		public IReadOnlyList<AGReq> Requirements => _requirements;

		public ActivationGroupRequirement()
		{
			_highlightedPartsPerRequirement = new List<List<HighlightedPart>>();
			_requirements = new List<AGReq>();
		}

		public ActivationGroupRequirement(int activationGroup, bool state, string message = null)
			: this(new AGReq[1]
			{
				new AGReq(activationGroup, state)
			}, message)
		{
		}

		public ActivationGroupRequirement(int activationGroup1, bool state1, int activationGroup2, bool state2, string message = null)
			: this(new AGReq[2]
			{
				new AGReq(activationGroup1, state1),
				new AGReq(activationGroup2, state2)
			}, message)
		{
		}

		public ActivationGroupRequirement(IEnumerable<AGReq> requirements, string message = null)
		{
			_requirements = new List<AGReq>(requirements);
			_highlightedPartsPerRequirement = new List<List<HighlightedPart>>(Requirements.Count);
			base.RequirementNotMetMessage = message;
		}

		public void AddActivationGroupRequirement(int activationGroup, bool targetState)
		{
			_requirements.Add(new AGReq(activationGroup, targetState));
		}

		public override void OnStepStarted()
		{
			base.OnStepStarted();
			foreach (AGReq requirement in Requirements)
			{
				_highlightedPartsPerRequirement.Add(HighlightInteractablePartsByInput($"Activate{requirement.ActivationGroup}"));
			}
		}

		protected override void GenerateXml(XElement xml)
		{
			base.GenerateXml(xml);
			foreach (AGReq requirement in _requirements)
			{
				xml.Add(new XElement("AG", new XAttribute("id", requirement.ActivationGroup), new XAttribute("state", requirement.TargetState)));
			}
		}

		protected override string GetDefaultRequirementNotMetMessage(bool vr)
		{
			string text = null;
			for (int i = 0; i < Requirements.Count; i++)
			{
				AGReq aGReq = Requirements[i];
				text = ((text == null) ? string.Empty : (text + System.Environment.NewLine));
				text += string.Format("{0} activation group {1}.", aGReq.TargetState ? "Enable" : "Disable", aGReq.ActivationGroup);
			}
			return text;
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			AircraftScript playerAircraft = base.PlayerAircraft;
			if (playerAircraft == null)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			bool flag = true;
			AircraftControls controls = playerAircraft.Controls;
			for (int i = 0; i < Requirements.Count; i++)
			{
				AGReq aGReq = Requirements[i];
				List<HighlightedPart> list = _highlightedPartsPerRequirement[i];
				bool flag2 = controls.GetActivationState(aGReq.ActivationGroup) == aGReq.TargetState;
				flag = flag && flag2;
				base.HighlightPartsEnabled = !flag;
				foreach (HighlightedPart item in list)
				{
					item.Enabled = !flag2;
				}
			}
			if (!flag)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			return TutorialRequirementState.RequirementMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			foreach (XElement item in xml.Elements("AG"))
			{
				_requirements.Add(new AGReq((int)item.Attribute("id"), (bool)item.Attribute("state")));
			}
		}
	}
}
