using System;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Tutorials.Requirements.Attributes;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("Target")]
	public class TargetRequirement : TutorialRequirement
	{
		public enum TargetLockState
		{
			Selected = 0,
			AcquiringLock = 1,
			Locked = 2,
			Dead = 3
		}

		private TrackedTarget _lastKnownTarget;

		public TargetLockState LockState { get; set; }

		public string TargetName { get; set; }

		public TargetRequirement()
		{
		}

		public TargetRequirement(string targetName, TargetLockState lockState)
		{
			TargetName = targetName;
			LockState = lockState;
			if (lockState == TargetLockState.Dead)
			{
				base.RequiredMetDuration = 0f;
			}
		}

		public TargetRequirement(string targetName, TargetLockState lockState, string message)
		{
			TargetName = targetName;
			LockState = lockState;
			base.RequirementNotMetMessage = message;
			if (lockState == TargetLockState.Dead)
			{
				base.RequiredMetDuration = 0f;
			}
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("targetName", TargetName);
			xml.SetAttributeValue("lockState", LockState);
			base.GenerateXml(xml);
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			AircraftScript playerAircraft = base.PlayerAircraft;
			if (playerAircraft == null)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			TrackedTarget currentTrackedTarget = playerAircraft.TargetingSystem.CurrentTrackedTarget;
			if (currentTrackedTarget == null)
			{
				if (LockState == TargetLockState.Dead)
				{
					TrackedTarget lastKnownTarget = _lastKnownTarget;
					if (lastKnownTarget != null && lastKnownTarget.Target.IsDead)
					{
						return TutorialRequirementState.RequirementMet;
					}
				}
				return TutorialRequirementState.RequirementNotMet;
			}
			if (currentTrackedTarget.Target.Name != TargetName)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			_lastKnownTarget = currentTrackedTarget;
			switch (LockState)
			{
			case TargetLockState.Dead:
				if (!currentTrackedTarget.Target.IsDead)
				{
					return TutorialRequirementState.RequirementNotMet;
				}
				return TutorialRequirementState.RequirementMet;
			case TargetLockState.Selected:
				return TutorialRequirementState.RequirementMet;
			case TargetLockState.AcquiringLock:
				if (!currentTrackedTarget.IsAcquiring)
				{
					return TutorialRequirementState.RequirementNotMet;
				}
				return TutorialRequirementState.RequirementMet;
			case TargetLockState.Locked:
				if (!currentTrackedTarget.IsLocked)
				{
					return TutorialRequirementState.RequirementNotMet;
				}
				return TutorialRequirementState.RequirementMet;
			default:
				throw new NotSupportedException();
			}
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			TargetName = (string)xml.Attribute("targetName");
			LockState = xml.GetEnumAttribute("lockState", TargetLockState.Selected);
		}
	}
}
