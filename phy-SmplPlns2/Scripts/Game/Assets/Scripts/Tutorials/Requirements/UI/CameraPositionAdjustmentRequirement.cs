using System;
using System.Xml.Linq;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using Assets.Scripts.XR;
using UnityEngine;

namespace Assets.Scripts.Tutorials.Requirements.UI
{
	[Serializable]
	[TutorialRequirement("CameraPositionAdjustment")]
	public class CameraPositionAdjustmentRequirement : TutorialRequirement
	{
		private float _currentDistance;

		private int _dualHandFrameCount;

		public float RequiredDistance { get; set; }

		protected override float DefaultRequiredMetDuration => 0f;

		public CameraPositionAdjustmentRequirement()
		{
		}

		public CameraPositionAdjustmentRequirement(float requiredDistance)
		{
			RequiredDistance = requiredDistance;
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("distance", RequiredDistance);
			base.GenerateXml(xml);
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			FlightXRRigManager instance = FlightXRRigManager.Instance;
			if (instance == null)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			FlightHand flightHand = instance.FlightHands[0];
			FlightHand flightHand2 = instance.FlightHands[1];
			bool num = flightHand.GripPhysicallyPressed && !flightHand.IsGripped;
			bool flag = flightHand2.GripPhysicallyPressed && !flightHand2.IsGripped;
			bool flag2 = num ^ flag;
			bool flag3 = num && flag;
			_dualHandFrameCount = (flag3 ? (_dualHandFrameCount + 1) : 0);
			if (_currentDistance >= RequiredDistance)
			{
				if (!instance.AdjustingOffset)
				{
					return TutorialRequirementState.RequirementMet;
				}
				base.RequirementNotMetMessage = "Well done. \nNow let go of the grip buttons to complete the adjustment.";
			}
			else if (instance.AdjustingOffset)
			{
				_currentDistance += instance.AdjustingOffsetDelta.magnitude;
				base.RequirementNotMetMessage = "Move your hands while holding down the \ngrip buttons to adjust your camera offset.";
			}
			else if (flag3)
			{
				if (_dualHandFrameCount > 2)
				{
					base.RequirementNotMetMessage = "Your hands were not close enough together when gripped. \nRelease your grips, move your hands closer together and try again.";
				}
			}
			else
			{
				Vector3 position = flightHand.GripTransform.position;
				if ((flightHand2.GripTransform.position - position).sqrMagnitude < 0.0625f)
				{
					if (flag2)
					{
						base.RequirementNotMetMessage = "Press the grip button on both controllers \nwhile keeping your hands close together.";
					}
					else
					{
						base.RequirementNotMetMessage = "Press the grip button on both controllers \nwhile keeping your hands close together.";
					}
				}
				else
				{
					base.RequirementNotMetMessage = "Move your hands close together.";
				}
			}
			return TutorialRequirementState.RequirementNotMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			RequiredDistance = ((float?)xml.Attribute("distance")) ?? 1f;
		}
	}
}
